using Microsoft.EntityFrameworkCore;
using RedStore.Api.Data;
using RedStore.Api.Entities;
using RedStore.Api.Interfaces;
using RedStore.Models.Dtos;

namespace RedStore.Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        //Get All Categories
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await this.applicationDbContext.Categories.ToListAsync();
            return categories;
        }

        //Get All Carousel
        public async Task<IEnumerable<Carousel>> GetCarousels()
        {
            var carousels = await this.applicationDbContext.Carousels.ToListAsync();
            return carousels;
        }

        //Get Sub Category
        public async Task<IEnumerable<SubCategory>> GeSubCategory(int Category_id)
        {
            var subcategories = await this.applicationDbContext.SubCategories.Where(i => i.Category_id == Category_id).ToListAsync();
            return subcategories;
        }

        //Get All Products
        public async Task<IEnumerable<ProductView>> GetProducts(int Category_id)
        {
            var products = await this.applicationDbContext.ProductViews.Where(i => i.Category_id == Category_id).ToListAsync();
            return products;
        }

        //Get All Products Sub Category
        public async Task<IEnumerable<ProductView>> GetProductsSubCategory(int SubCategory_id)
        {
            var productssubcategory = await this.applicationDbContext.ProductViews.Where(i => i.SubCategory_id == SubCategory_id).ToListAsync();
            return productssubcategory;
        }

        //Get Single Product
        public async Task<IEnumerable<ProductView>> GetProduct(int Product_id)
        {
            var product = await applicationDbContext.ProductViews.Where(i => i.Product_id == Product_id).ToListAsync();
            return product;
        }

        //Get All Search Value
        public async Task<List<Search>> GetSearch()
        {
            var search = await this.applicationDbContext.Searchs.ToListAsync();
            return search;
        }

        //public async Task<List<Search>> SearchProducts(string searchText)
        //{
        //    var search = await applicationDbContext.Searchs.Where(i => i.Title.Contains(searchText)).ToListAsync();
        //    return search;
        //}

        //Get Product Colors
        public async Task<IEnumerable<ProductColor>> GetProductColors(int Product_id)
        {
            var colors = await applicationDbContext.ProductColors.Where(c => c.Product_id == Product_id).ToListAsync();
            return colors;
        }

        //Get Product Images
        public async Task<IEnumerable<ProductImage>> GetProductImages(int Product_id)
        {
            var images = await applicationDbContext.ProductImages.Where(i => i.Product_id == Product_id).ToListAsync();
            return images;
        }

        //Get Product Size
        public async Task<IEnumerable<ProductSize>> GetProductSize(int Product_id)
        {
            var size = await applicationDbContext.ProductSizes.Where(i => i.Product_id == Product_id).ToListAsync();
            return size;
        }

        //Add Review
        public async Task<Review> AddReview(ReviewDto ReviewDto)
        {
            var item = new Review()
            {
                User_id = ReviewDto.User_id,
                Product_id = ReviewDto.Product_id,
                Rating = ReviewDto.Rating,
                Message = ReviewDto.Message,
                Created_at = DateTime.Now,
            };

            if (item != null)
            {
                var result = await this.applicationDbContext.Reviews.AddAsync(item);
                await this.applicationDbContext.SaveChangesAsync();
                return result.Entity;
            }

            return null;
        }

        //Get Review
        public async Task<IEnumerable<Review>> GetReview(int User_id, int Product_id)
        {
            var Review = await applicationDbContext.Reviews.Where(i => i.User_id == User_id && i.Product_id == Product_id).ToListAsync();
            return Review;
        }

        //Get Review Count
        public async Task<IEnumerable<Review>> GetReviewCount(int Product_id)
        {
            var Review = await applicationDbContext.Reviews.Where(i => i.Product_id == Product_id).ToListAsync();
            return Review;
        }

        //ionic Get All Categories
        public async Task<IEnumerable<Category>> GetionicCategories(int limit)
        {
            var category = await applicationDbContext.Categories.Take(limit).ToListAsync();
            return (IEnumerable<Category>)category;
        }

        //Add Favorite
        public async Task<Favorite> Addfavorite(FavoriteDto FavoriteDto)
        {
            var item = new Favorite()
            {
                User_id = FavoriteDto.User_id,
                Product_id = FavoriteDto.Product_id,
                Created_at = DateTime.Now,
            };

            if (item != null)
            {
                var result = await this.applicationDbContext.Favorites.AddAsync(item);
                await this.applicationDbContext.SaveChangesAsync();
                return result.Entity;
            }

            return null;
        }

        //Get Favorite
        public async Task<IEnumerable<Favorite>> GetFavorite(int User_id, int Product_id)
        {
            var Favorite = await applicationDbContext.Favorites.Where(i => i.User_id == User_id && i.Product_id == Product_id).ToListAsync();
            return Favorite;
        }

        //Remove Favorite
        public async Task<Favorite> RemoveFavorite(int User_id, int Product_id)
        {
            var item = await this.applicationDbContext.Favorites.Where(i => i.User_id == User_id && i.Product_id == Product_id).FirstOrDefaultAsync();

            if (item != null)
            {
                this.applicationDbContext.Favorites.Remove(item);
                await this.applicationDbContext.SaveChangesAsync();
            }

            return item;
        }

        //Get Favorite
        public async Task<IEnumerable<FavoriteView>> GetFavoriteView(int User_id)
        {
            var Favorite = await this.applicationDbContext.FavoriteViews.Where(i => i.User_id == User_id).ToListAsync();
            return Favorite;
        }
    }

}