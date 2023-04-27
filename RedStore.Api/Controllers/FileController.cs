using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedStore.Api.Data;
using RedStore.Api.Entities;
using RedStore.Api.Interfaces;
using RedStore.Models.Dtos;
using RedStore.Admin;
using Microsoft.Extensions.Hosting.Internal;


namespace RedStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDbContext _context;

        public FileController(IWebHostEnvironment env, ApplicationDbContext context)
        {
            _env = env;
            _context = context;
        }

        //Upload Images

        [HttpPost]
        public async Task<ActionResult<List<CarouselDto>>> UploadFile(List<IFormFile> files)
        {
            List<CarouselDto> uploadResults = new List<CarouselDto>();

            foreach (var file in files)
            {

                var path = Path.Combine(_env.ContentRootPath, "Images", "Carousels", file.FileName);

                await using FileStream fs = new(path, FileMode.Create);
                await file.CopyToAsync(fs);

                var item = new Carousel()
                {
                    Title = Path.GetFileNameWithoutExtension(file.FileName),
                    ImageURL = file.FileName,
                };

                if (item != null)
                {
                    var result = await _context.Carousels.AddAsync(item);
                    await _context.SaveChangesAsync();
                }
            }
            return Ok(uploadResults);
        }


        [HttpPost("PostCategoryImage/{Title}")]
        public async Task<ActionResult<List<CategoryDto>>> UploadCategoryFile(List<IFormFile> files, string Title)
        {
            List<CategoryDto> uploadResults = new List<CategoryDto>();

            foreach (var file in files)
            {

                var path = Path.Combine(_env.ContentRootPath, "Images", "Categories", file.FileName);

                await using FileStream fs = new(path, FileMode.Create);
                await file.CopyToAsync(fs);

                var item = new Category()
                {
                    Title = Title,
                    ImageURL = file.FileName,
                };

                if (item != null)
                {
                    var result = await _context.Categories.AddAsync(item);
                    await _context.SaveChangesAsync();
                }
            }
            return Ok(uploadResults);
        }

        [HttpPost("PostProductImage/{Title}/{Description}/{SubCategory_id:int}/{Category_id:int}")]
        public async Task<ActionResult<List<ProductDto>>> UploadProductFile(List<IFormFile> files, string Title, string Description, int SubCategory_id, int Category_id)
        {
            List<ProductDto> uploadResults = new List<ProductDto>();

            foreach (var file in files)
            {

                var path = Path.Combine(_env.ContentRootPath, "Images", "products", file.FileName);

                await using FileStream fs = new(path, FileMode.Create);
                await file.CopyToAsync(fs);

                var item = new Product()
                {
                    Title = Title,
                    Description = Description,
                    ImageURL = file.FileName,
                    SubCategory_id = SubCategory_id,
                    Category_id = Category_id,
                };

                if (item != null)
                {
                    var result = await _context.Products.AddAsync(item);
                    await _context.SaveChangesAsync();
                }
            }
            return Ok(uploadResults);
        }

        // Get Images

        [HttpGet("/GetCarouselsImages/{filename}")]
        public IActionResult CarouselsImages(string filename)
        {
            var type = 1;

            var contentType = type == 1 ? "image/jpeg" : "video/mp4";

            var filePath = Path.Combine(_env.ContentRootPath, "Images", "Carousels", $"{filename}");

            if (!System.IO.File.Exists(filePath))
            {
                contentType = "image/jpeg";
                filePath = "default_notfound_image_path_here";
            }

            return PhysicalFile(filePath, contentType);
        }

        [HttpGet("/GetCategoriesImages/{filename}")]
        public IActionResult CategoriesImages(string filename)
        {
            var type = 1;

            var contentType = type == 1 ? "image/jpeg" : "video/mp4";

            var filePath = Path.Combine(_env.ContentRootPath, "Images", "Categories", $"{filename}");

            if (!System.IO.File.Exists(filePath))
            {
                contentType = "image/jpeg";
                filePath = "default_notfound_image_path_here";
            }

            return PhysicalFile(filePath, contentType);
        }

        [HttpGet("/GetProductsImages/{filename}")]
        public IActionResult ProductsImages(string filename)
        {
            var type = 1;

            var contentType = type == 1 ? "image/jpeg" : "video/mp4";

            var filePath = Path.Combine(_env.ContentRootPath, "Images", "products", $"{filename}");

            if (!System.IO.File.Exists(filePath))
            {
                contentType = "image/jpeg";
                filePath = "default_notfound_image_path_here";
            }

            return PhysicalFile(filePath, contentType);
        }

    }
}