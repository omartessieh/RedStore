using Microsoft.AspNetCore.Components;
using RedStore.Models.Dtos;
using RedStore.Web.Interfaces;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace RedStore.Web.Pages
{
    public partial class ProductDetails : ComponentBase
    {
        [Parameter]
        public int Product_id { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        public IEnumerable<ProductViewDto> Product { get; set; }

        public IEnumerable<ProductColorDto> Colors { get; set; }

        public IEnumerable<ProductImageDto> Images { get; set; }

        public IEnumerable<ProductSizeDto> Size { get; set; }

        [Inject]
        public ILocalStorageService? LocalStorage { get; set; }

        [Inject]
        public AuthenticationStateProvider? AuthStateProvider { get; set; }

        [Inject]
        public NavigationManager? NavManager { get; set; }

        public IEnumerable<CartitemDto> CheckCartItem { get; set; }

        public IEnumerable<OrderDetailDto> OrderQty { get; set; }

        public IEnumerable<ReviewDto> GetReview { get; set; }

        public IEnumerable<FavoriteDto> GetFavorite { get; set; }

        public IEnumerable<ReviewDto> GetReviewCount { get; set; }

        public CartDto Cart { get; set; }

        private int qty = 1;

        private string? imageSource;

        private string? CategoryTitle;

        private string? SubCategoryTitle;

        private string? ProductTitle;

        public int sizeValue { get; set; }

        public int colorsValue { get; set; }

        public string checksize { get; set; }

        public string checkcolor { get; set; }

        public string checksuccess { get; set; }

        public string checkcartitem { get; set; }

        public string checktotalqty { get; set; }

        public int User_id = 0;

        private int orderqty = 0;

        private int stockqty = 0;

        private int sumqty = 0;
        public int Rating { get; set; }
        public string Message { get; set; }

        string productslink = "https://localhost:7068/GetProductsImages";

        protected override async Task OnInitializedAsync()
        {
            User_id = await LocalStorage.GetItemAsync<int>("id");

            checksize = null;
            checkcolor = null;
            checksuccess = null;
            checkcartitem = null;
            checktotalqty = null;

            try
            {
                Product = await ProductService.GetProduct(Product_id);
                Colors = await ProductService.GetProductColors(Product_id);
                Images = await ProductService.GetProductImages(Product_id);
                Size = await ProductService.GetProductSize(Product_id);
                GetFavorite = await ProductService.GetFavorite(User_id, Product_id);

                if (User_id != 0)
                {
                    Cart = await ShoppingCartService.GetCartID(User_id);
                }
                OrderQty = await ShoppingCartService.GetOrderQty(Product_id);
                GetReview = await ProductService.GetReview(User_id, Product_id);
                GetReviewCount = await ProductService.GetReviewCount(Product_id);

                foreach (var product in Product)
                {
                    imageSource = @product.ProductImage;
                    CategoryTitle = @product.CategoryTitle;
                    SubCategoryTitle = @product.SubCategoryTitle;
                    ProductTitle = @product.ProductTitle;
                }

                foreach (var product in Product)
                {
                    stockqty = product.Qty;
                }

                if (OrderQty.Count() > 0)
                {
                    sumqty = OrderQty.Sum(i => i.Qty);
                    orderqty = stockqty - sumqty;
                }
                else
                {
                    orderqty = stockqty;
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        void sizeselectedValue(ChangeEventArgs e)
        {
            if (Convert.ToInt32(e.Value) != null)
            {
                sizeValue = Convert.ToInt32(e.Value);
            }
            else
            {
                colorsValue = 0;
            }
        }

        void colorsselectedValue(ChangeEventArgs e)
        {
            if (Convert.ToInt32(e.Value) != null)
            {
                colorsValue = Convert.ToInt32(e.Value);
            }
            else
            {
                colorsValue = 0;
            }
        }

        private void ShowImage(string ImageURL)
        {
            imageSource = ImageURL;
        }

        private void IncrementCount()
        {
            if (qty < orderqty)
            {
                qty++;
            }
        }

        private void DecrementCount()
        {
            if (qty > 1)
            {
                qty--;
            }
        }

        protected async Task AddToCart_Click(CartitemDto cartitemDto)
        {
            CheckCartItem = await ShoppingCartService.CheckCartItems(Cart.Cart_id, cartitemDto.Product_id, cartitemDto.Color_id, cartitemDto.Size_id);
            OrderQty = await ShoppingCartService.GetOrderQty(Product_id);

            if (OrderQty.Count() > 0)
            {
                sumqty = OrderQty.Sum(i => i.Qty);
                orderqty = stockqty - sumqty;
            }
            else
            {
                orderqty = stockqty;
            }

            try
            {
                if (Size.Count() > 0 && sizeValue == 0)
                {
                    checksize = "Select Size";
                    checkcolor = null;
                    checksuccess = null;
                    checkcartitem = null;
                    checktotalqty = null;
                }
                else if (Colors.Count() > 0 && colorsValue == 0)
                {
                    checkcolor = "Select Color";
                    checksize = null;
                    checksuccess = null;
                    checkcartitem = null;
                    checktotalqty = null;
                }
                else if (CheckCartItem.Count() > 0)
                {
                    checkcartitem = "Already Set In Basket";
                    checkcolor = null;
                    checksize = null;
                    checksuccess = null;
                    checktotalqty = null;
                }
                else if (orderqty == 0 || qty > orderqty)
                {
                    checktotalqty = "No Items Qty";
                    checksuccess = null;
                    checksize = null;
                    checkcartitem = null;
                    checkcolor = null;
                }
                else
                {
                    checksuccess = "Success";
                    checksize = null;
                    checkcartitem = null;
                    checkcolor = null;
                    checktotalqty = null;
                    var cartItem = await ShoppingCartService.AddItem(cartitemDto);
                }
            }
            catch (Exception)
            {
                //Log Exception
            }
        }

        public async Task AddReview()
        {

            ReviewDto ReviewDto = new ReviewDto()
            {
                User_id = User_id,
                Product_id = Product_id,
                Rating = Rating,
                Message = Message,
            };

            if (Rating != 0 && Message != null)
            {

                await ProductService.AddReview(ReviewDto);

                GetReview = await ProductService.GetReview(User_id, Product_id);
                GetReviewCount = await ProductService.GetReviewCount(Product_id);
            }
        }

        public async Task AddFavorite()
        {
            FavoriteDto FavoriteDto = new FavoriteDto()
            {
                User_id = User_id,
                Product_id = Product_id
            };

            if (User_id != 0 && Product_id != null)
            {
                await ProductService.Addfavorite(FavoriteDto);
            }
            GetFavorite = await ProductService.GetFavorite(User_id, Product_id);
            //GetReviewCount = await ProductService.GetReviewCount(Product_id);

        }

        public async Task RemoveFavorite()
        {
            var FavoriteDto = await ProductService.RemoveFavorite(User_id, Product_id);
            GetFavorite = await ProductService.GetFavorite(User_id, Product_id);
        }

    }
}