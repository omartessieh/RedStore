using RedStore.Api.Entities;
using RedStore.Models.Dtos;

namespace RedStore.Api.Interfaces
{
    public interface IProductRepository
    {
        //Get All Categories
        Task<IEnumerable<Category>> GetCategories();

        //Get All Carousel
        Task<IEnumerable<Carousel>> GetCarousels();

        //Get Sub Category
        Task<IEnumerable<SubCategory>> GeSubCategory(int Category_id);

        //Get All Products
        Task<IEnumerable<ProductView>> GetProducts(int Category_id);

        //Get All Products Sub Category
        Task<IEnumerable<ProductView>> GetProductsSubCategory(int SubCategory_id);

        //Get Single Product
        Task<IEnumerable<ProductView>> GetProduct(int Product_id);

        //Get All Search Value
        Task<List<Search>> GetSearch();

        //Task<List<Search>> SearchProducts(string searchText);

        //Get Product Colors
        Task<IEnumerable<ProductColor>> GetProductColors(int Product_id);

        //Get Product Images
        Task<IEnumerable<ProductImage>> GetProductImages(int Product_id);

        //Get Product Size
        Task<IEnumerable<ProductSize>> GetProductSize(int Product_id);

        //Add Review
        Task<Review> AddReview(ReviewDto ReviewDto);

        //Get Review
        Task<IEnumerable<Review>> GetReview(int User_id, int Product_id);

        //Get Review Count
        Task<IEnumerable<Review>> GetReviewCount(int Product_id);

        //Add Favorite
        Task<Favorite> Addfavorite(FavoriteDto FavoriteDto);

        //Get Favorite
        Task<IEnumerable<Favorite>> GetFavorite(int User_id, int Product_id);

        //Remove Favorite
        Task<Favorite> RemoveFavorite(int User_id, int Product_id);

        //Get Favorite
        Task<IEnumerable<FavoriteView>> GetFavoriteView(int User_id);






        //ionic Get All Categories
        //Task<IEnumerable<Category>> GetionicCategories(int limit);



    }
}