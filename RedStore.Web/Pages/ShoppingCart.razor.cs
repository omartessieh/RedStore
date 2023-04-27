using Microsoft.AspNetCore.Components;
using RedStore.Models.Dtos;
using RedStore.Web.Interfaces;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace RedStore.Web.Pages
{
    public partial class ShoppingCart : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }

        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        [Inject]
        public ILocalStorageService? LocalStorage { get; set; }

        [Inject]
        public AuthenticationStateProvider? AuthStateProvider { get; set; }

        [Inject]
        public NavigationManager? NavManager { get; set; }

        public IEnumerable<CartItemViewDto> CartItem { get; set; }

        public IEnumerable<OrderDetailDto> orderqty { get; set; }

        public CartDto Cart { get; set; }

        private bool ShowButtons = false;

        public string checktotalqty { get; set; }

        public int TotalItems { get; set; }

        public int TotalQuantity { get; set; }

        public int Shipping { get; set; }

        public int PaymentAmount { get; set; }

        public int Total { get; set; }

        public int User_id = 0;

        public int id = 0;

        private int qty = 0;

        private int sumqty = 0;

        string productslink = "https://localhost:7068/GetProductsImages";

        protected override async Task OnInitializedAsync()
        {
            User_id = await LocalStorage.GetItemAsync<int>("id");

            checktotalqty = null;

            try
            {
                Cart = await ShoppingCartService.GetCartID(User_id);
                CartItem = await ShoppingCartService.GetAllProduct(Cart.Cart_id);

                TotalItems = CartItem.Count();

                if (TotalItems == 0)
                {
                    TotalItems = 0;
                }

                TotalQuantity = CartItem.Sum(i => i.OrderQty);
                PaymentAmount = CartItem.Sum(p => p.OrderPrice);
                Shipping = TotalItems * 10;
                Total = (PaymentAmount + Shipping);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected async Task DeleteCartItem_Click(int Cartitem_id)
        {
            var cartItemDto = await ShoppingCartService.DeleteItem(Cartitem_id);
            CartItem = await ShoppingCartService.GetAllProduct(Cart.Cart_id);

            TotalItems = CartItem.Count();

            if (TotalItems == 0)
            {
                TotalItems = 0;
            }

            TotalQuantity = CartItem.Sum(i => i.OrderQty);
            PaymentAmount = CartItem.Sum(p => p.OrderPrice);
            Shipping = TotalItems * 10;
            Total = (PaymentAmount + Shipping);
        }

        protected async Task UpdateQty_Input(int Cartitem_id)
        {
            id = Cartitem_id;
            ShowButtons = true;
        }

        protected async Task UpdateQtyCartItem_Click(int Cartitem_id, int Product_id, string ProductTitle, int OrderQty, int StockQty)
        {

            orderqty = await ShoppingCartService.GetOrderQty(Product_id);

            if (orderqty.Count() > 0)
            {
                sumqty = orderqty.Sum(i => i.Qty);
                qty = StockQty - sumqty;
            }
            else
            {
                qty = StockQty;
            }

            try
            {
                id = Cartitem_id;
                if (OrderQty <= 0)
                {
                    checktotalqty = " Quantity shouldn't 0";
                }
                else if (OrderQty > qty)
                {
                    checktotalqty = " Not Enough Quantity ";
                }
                else
                {
                    var updateItemDto = new CartitemDto
                    {
                        Cartitem_id = Cartitem_id,
                        Qty = OrderQty
                    };

                    await ShoppingCartService.UpdateQty(updateItemDto);

                    CartItem = await ShoppingCartService.GetAllProduct(Cart.Cart_id);

                    TotalItems = CartItem.Count();

                    if (TotalItems == 0)
                    {
                        TotalItems = 0;
                    }

                    TotalQuantity = CartItem.Sum(i => i.OrderQty);
                    PaymentAmount = CartItem.Sum(p => p.OrderPrice);
                    Shipping = TotalItems * 10;
                    Total = (PaymentAmount + Shipping);

                    ShowButtons = false;
                    checktotalqty = null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected async Task Checkout_Click()
        {
            //try
            //{
                if (CartItem != null && CartItem.Count() > 0)
                {
                    foreach (var item in CartItem)
                    {
                        OrderDetailDto orderDetailDto = new OrderDetailDto()
                        {
                            User_id = User_id,
                            Cart_id = item.Cart_id,
                            Product_id = item.Product_id,
                            Color_id = item.Color_id,
                            Size_id = item.Size_id,
                            Qty = item.OrderQty,
                            Total_Price = item.OrderPrice,
                        };

                        var orderItems = await ShoppingCartService.AddOrder(orderDetailDto);
                    }
                    CartItem = await ShoppingCartService.GetAllProduct(Cart.Cart_id);
                }
            //}
            //catch (Exception)
            //{
            //    //Log Exception
            //}
        }

    }
}