using RedStore.Models.Dtos;

namespace RedStore.Web.Interfaces
{
    public interface IProductService
    {
        //Get All Categories
        Task<IEnumerable<CategoryDto>> GetCategories();

        //Get All Carousel
        Task<IEnumerable<CarouselDto>> GetCarousels();

        //Get Sub Category
        Task<IEnumerable<SubCategoryDto>> GeSubCategory(int Category_id);

        //Get All Products
        Task<IEnumerable<ProductViewDto>> GetProducts(int Category_id);

        //Get All Products Sub Category
        Task<IEnumerable<ProductViewDto>> GetProductsSubCategory(int SubCategory_id);

        //Get Single Product
        Task<IEnumerable<ProductViewDto>> GetProduct(int Product_id);

        //Search
        Task<List<SearchDto>> GetSearch();
        //Task<List<SearchDto>> SearchProducts(string searchText);

        //Get Product Colors
        Task<IEnumerable<ProductColorDto>> GetProductColors(int Product_id);

        //Get Product Images
        Task<IEnumerable<ProductImageDto>> GetProductImages(int Product_id);

        //Get Product Size
        Task<IEnumerable<ProductSizeDto>> GetProductSize(int Product_id);

        //Add Review
        Task<ReviewDto> AddReview(ReviewDto ReviewDto);

        //Get Review
        Task<IEnumerable<ReviewDto>> GetReview(int User_id, int Product_id);

        //Get Review Count
        Task<IEnumerable<ReviewDto>> GetReviewCount(int Product_id);

        //Add Favorite
        Task<FavoriteDto> Addfavorite(FavoriteDto FavoriteDto);

        //Get Favorite
        Task<IEnumerable<FavoriteDto>> GetFavorite(int User_id, int Product_id);

        //Remove Favorite
        Task<FavoriteDto> RemoveFavorite(int User_id, int Product_id);

        //Get Favorite
        Task<IEnumerable<FavoriteViewDto>> GetFavoriteView(int User_id);
    }
}