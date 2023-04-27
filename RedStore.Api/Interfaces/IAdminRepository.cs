using RedStore.Api.Entities;
using RedStore.Models.Dtos;

namespace RedStore.Api.Interfaces
{
    public interface IAdminRepository
    {

        //Get Categories
        Task<IEnumerable<Category>> GetCategories();

        //Delete Category
        Task<Category> DeleteCategory(int Category_id);

        //Get SubCategories
        Task<IEnumerable<SubCategoryView>> GetSubCategoriesView();

        //Get Users
        Task<IEnumerable<User>> GetUsers();

        //Get Contacts
        Task<IEnumerable<Contact>> GetContacts();

        //Get Carousels
        Task<IEnumerable<Carousel>> GetCarousels();

        //Get Products
        Task<IEnumerable<Product>> GetProducts();

        //Delete Carousel
        Task<Carousel> DeleteCarousel(int Id);

        //Check Carousel
        Task<IEnumerable<Carousel>> CheckCarousel(string Title, string ImageURL);

        //Check Category
        Task<IEnumerable<Category>> CheckCategory(string Title, string ImageURL);

        //Delete User
        Task<User> DeleteUser(int User_id);

        //Check SubCategory
        Task<IEnumerable<SubCategory>> CheckSubCategory(string Title, int Category_id);

        //Delete SubCategory
        Task<SubCategory> DeleteSubCategory(int SubCategory_id);

        //Check Product
        Task<IEnumerable<Product>> CheckProduct(int SubCategory_id, int Category_id, string Title, string ImageURL);

        //Get Colors Product
        Task<IEnumerable<ProductColor>> GetColorsProduct(int Product_id);

        //Get Images Product
        Task<IEnumerable<ProductImage>> GetImagesProduct(int Product_id);

        //Get Price Product
        Task<IEnumerable<ProductPrice>> GetPriceProduct(int Product_id);

        //Get Size Product
        Task<IEnumerable<ProductSize>> GetSizeProduct(int Product_id);

        //Get Stock Product
        Task<IEnumerable<Stock>> GetStockProduct(int Product_id);

        //Get Discount Product
        Task<IEnumerable<Discount>> GetDiscountProduct(int Product_id);

    }
}