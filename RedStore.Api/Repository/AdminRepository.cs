using Microsoft.EntityFrameworkCore;
using RedStore.Api.Data;
using RedStore.Api.Entities;
using RedStore.Api.Interfaces;
using RedStore.Models.Dtos;

namespace RedStore.Api.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AdminRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        //Get Categories
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await this.applicationDbContext.Categories.ToListAsync();
            return categories;
        }

        //Delete Category
        public async Task<Category> DeleteCategory(int Category_id)
        {
            var item = await this.applicationDbContext.Categories.FindAsync(Category_id);

            if (item != null)
            {
                this.applicationDbContext.Categories.Remove(item);
                await this.applicationDbContext.SaveChangesAsync();
            }

            return item;
        }

        //Get SubCategories
        public async Task<IEnumerable<SubCategoryView>> GetSubCategoriesView()
        {
            var SubCategories = await this.applicationDbContext.SubCategoryViews.ToListAsync();
            return SubCategories;
        }

        //Get Users
        public async Task<IEnumerable<User>> GetUsers()
        {
            var Users = await this.applicationDbContext.Users.ToListAsync();
            return Users;
        }

        //Get Contacts
        public async Task<IEnumerable<Contact>> GetContacts()
        {
            var Contacts = await this.applicationDbContext.Contacts.ToListAsync();
            return Contacts;
        }

        //Get Carousels
        public async Task<IEnumerable<Carousel>> GetCarousels()
        {
            var Carousels = await this.applicationDbContext.Carousels.ToListAsync();
            return Carousels;
        }

        //Delete Carousel
        public async Task<Carousel> DeleteCarousel(int Id)
        {
            var item = await this.applicationDbContext.Carousels.FindAsync(Id);

            if (item != null)
            {
                this.applicationDbContext.Carousels.Remove(item);
                await this.applicationDbContext.SaveChangesAsync();
            }

            return item;
        }

        //Check Carousel
        public async Task<IEnumerable<Carousel>> CheckCarousel(string Title, string ImageURL)
        {
            var Check = await this.applicationDbContext.Carousels.Where(i => i.Title == Title && i.ImageURL == ImageURL).ToListAsync();
            return Check;
        }

        //Delete User
        public async Task<User> DeleteUser(int User_id)
        {
            var item = await this.applicationDbContext.Users.FindAsync(User_id);

            if (item != null)
            {
                this.applicationDbContext.Users.Remove(item);
                await this.applicationDbContext.SaveChangesAsync();
            }

            return item;
        }

        //Check Category
        public async Task<IEnumerable<Category>> CheckCategory(string Title, string ImageURL)
        {
            var Check = await this.applicationDbContext.Categories.Where(i => i.Title == Title && i.ImageURL == ImageURL).ToListAsync();
            return Check;
        }

        //Check SubCategory
        public async Task<IEnumerable<SubCategory>> CheckSubCategory(string Title, int Category_id)
        {
            var Check = await this.applicationDbContext.SubCategories.Where(i => i.Title == Title && i.Category_id == Category_id).ToListAsync();
            return Check;
        }

        //Delete SubCategory
        public async Task<SubCategory> DeleteSubCategory(int SubCategory_id)
        {
            var item = await this.applicationDbContext.SubCategories.FindAsync(SubCategory_id);

            if (item != null)
            {
                this.applicationDbContext.SubCategories.Remove(item);
                await this.applicationDbContext.SaveChangesAsync();
            }

            return item;
        }

        //Get Products
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var ProductsView = await this.applicationDbContext.Products.ToListAsync();
            return ProductsView;
        }

        //Check Product
        public async Task<IEnumerable<Product>> CheckProduct(int SubCategory_id, int Category_id, string Title, string ImageURL)
        {
            var Check = await this.applicationDbContext.Products.Where(i => i.Title == Title && i.Category_id == Category_id && i.SubCategory_id == SubCategory_id && i.ImageURL == ImageURL).ToListAsync();
            return Check;
        }

        //Get Colors Product
        public async Task<IEnumerable<ProductColor>> GetColorsProduct(int Product_id)
        {
            var Colors = await this.applicationDbContext.ProductColors.Where(i => i.Product_id == Product_id).ToListAsync();
            return Colors;
        }

        //Get Images Product
        public async Task<IEnumerable<ProductImage>> GetImagesProduct(int Product_id)
        {
            var Images = await this.applicationDbContext.ProductImages.Where(i => i.Product_id == Product_id).ToListAsync();
            return Images;
        }

        //Get Price Product
        public async Task<IEnumerable<ProductPrice>> GetPriceProduct(int Product_id)
        {
            var Price = await this.applicationDbContext.ProductPrices.Where(i => i.Product_id == Product_id).ToListAsync();
            return Price;
        }

        //Get Size Product
        public async Task<IEnumerable<ProductSize>> GetSizeProduct(int Product_id)
        {
            var Size = await this.applicationDbContext.ProductSizes.Where(i => i.Product_id == Product_id).ToListAsync();
            return Size;
        }

        //Get Stock Product
        public async Task<IEnumerable<Stock>> GetStockProduct(int Product_id)
        {
            var Stock = await this.applicationDbContext.Stocks.Where(i => i.Product_id == Product_id).ToListAsync();
            return Stock;
        }

        //Get Discount Product
        public async Task<IEnumerable<Discount>> GetDiscountProduct(int Product_id)
        {
            var Discount = await this.applicationDbContext.Discounts.Where(i => i.Product_id == Product_id).ToListAsync();
            return Discount;
        }

    }
}