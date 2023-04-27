using RedStore.Models.Dtos;

namespace RedStore.Admin.Interfaces
{
    public interface IAdminService
    {
        //Get Categories
        Task<IEnumerable<CategoryDto>> GetCategories();

        //Delete Category
        Task<CategoryDto> DeleteCategory(int Category_id, string ImageURL);

        //Get SubCategories
        Task<IEnumerable<SubCategoryViewDto>> GetSubCategoriesView();

        //Get Users
        Task<IEnumerable<UserDto>> GetUsers();

        //Get Contacts
        Task<IEnumerable<ContactDto>> GetContacts();

        //Get Carousels
        Task<IEnumerable<CarouselDto>> GetCarousels();

        //Delete Carousel
        Task<CarouselDto> DeleteCarousel(int Id, string ImageURL);

        //Check Carousel
        Task<IEnumerable<CarouselDto>> CheckCarousel(string Title, string ImageURL);

        //Get User Information
        Task<UserDto> GetUserInfo(int User_id);

        //Update User
        Task<UserDto> UpdateUser(int User_id, UserDto userDto);

        //Check User Update
        Task<IEnumerable<UserDto>> CheckUserUpdate(string username, string email, string phone, int User_id);

        //Add User
        Task<UserDto> AddUser(UserDto userDto);

        //Check User Exist
        Task<IEnumerable<UserDto>> CheckUserExist(string username, string email, string phone);

        //Delete User
        Task<UserDto> DeleteUser(int User_id);

        //Check Category
        Task<IEnumerable<CategoryDto>> CheckCategory(string Title, string ImageURL);

        //Check SubCategory
        Task<IEnumerable<SubCategoryDto>> CheckSubCategory(string Title, int Category_id);

        //Delete SubCategory
        Task<SubCategoryDto> DeleteSubCategory(int SubCategory_id);

        //Get Products
        Task<IEnumerable<ProductDto>> GetProducts();

        //Check Product
        Task<IEnumerable<ProductDto>> CheckProduct(int SubCategory_id, int Category_id, string Title, string ImageURL);

        //Get Colors Product
        Task<IEnumerable<ProductColorDto>> GetColorsProduct(int Product_id);

        //Get Images Product
        Task<IEnumerable<ProductImageDto>> GetImagesProduct(int Product_id);

        //Get Price Product
        Task<IEnumerable<ProductPriceDto>> GetPriceProduct(int Product_id);

        //Get Size Product
        Task<IEnumerable<ProductSizeDto>> GetSizeProduct(int Product_id);

        //Get Stock Product
        Task<IEnumerable<StockDto>> GetStockProduct(int Product_id);

        //Get Discount Product
        Task<IEnumerable<DiscountDto>> GetDiscountProduct(int Product_id);

    }
}
