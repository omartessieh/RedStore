using Microsoft.EntityFrameworkCore;
using RedStore.Api.Entities;

namespace RedStore.Api.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carousel>().ToTable("Carousel");
            modelBuilder.Entity<Cart>().ToTable("Cart");
            modelBuilder.Entity<Cartitem>().ToTable("Cartitem");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Discount>().ToTable("Discount");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductColor>().ToTable("ProductColor");
            modelBuilder.Entity<ProductImage>().ToTable("ProductImage");
            modelBuilder.Entity<ProductPrice>().ToTable("ProductPrice");
            modelBuilder.Entity<ProductSize>().ToTable("ProductSize");
            modelBuilder.Entity<Stock>().ToTable("Stock");
            modelBuilder.Entity<SubCategory>().ToTable("SubCategory");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<ProductView>().ToTable("ProductView");
            modelBuilder.Entity<Search>().ToTable("Search");
            modelBuilder.Entity<CartItemView>().ToTable("CartItemView");
            modelBuilder.Entity<OrderDetailsView>().ToTable("OrderDetailsView");
            modelBuilder.Entity<Information>().ToTable("Information");
            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<Favorite>().ToTable("Favorite"); 
            modelBuilder.Entity<FavoriteView>().ToTable("FavoriteView"); 
            modelBuilder.Entity<SubCategoryView>().ToTable("SubCategoryView");
        }

        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Cartitem> Cartitems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductView> ProductViews { get; set; }
        public DbSet<Search> Searchs { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<CartItemView> CartItemViews { get; set; }
        public DbSet<OrderDetailsView> OrderDetailsViews { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<FavoriteView> FavoriteViews { get; set; }
        public DbSet<SubCategoryView> SubCategoryViews { get; set; } 
    }
}