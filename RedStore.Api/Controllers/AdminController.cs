using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedStore.Api.Data;
using RedStore.Api.Entities;
using RedStore.Api.Interfaces;
using RedStore.Models.Dtos;

namespace RedStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IAdminRepository adminRepository;

        private readonly IWebHostEnvironment _env;

        public AdminController(IAdminRepository adminRepository, IWebHostEnvironment env, ApplicationDbContext context)
        {
            this.adminRepository = adminRepository;
            _env = env;
            _context = context;
        }

        //Get Categories
        [HttpGet("AdminGetCategories")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            try
            {
                var categories = await this.adminRepository.GetCategories();

                if (categories == null)
                {
                    return NotFound();
                }
                else
                {
                    var categoriesDtos = categories.ToList();
                    return Ok(categoriesDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        //Delete Category
        [HttpDelete("DeleteCategory/{Category_id:int}/{ImageURL}")]
        public async Task<ActionResult<CarouselDto>> DeleteCategory(int Category_id, string ImageURL)
        {
            try
            {
                var Category = await this.adminRepository.DeleteCategory(Category_id);

                var path = Path.Combine(_env.ContentRootPath, "Images", "Categories", ImageURL);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                if (Category == null)
                {
                    return NotFound();
                }

                var CategoryDto = Category;

                return Ok(CategoryDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Get SubCategories
        [HttpGet("AdminGetSubCategoriesView")]
        public async Task<ActionResult<IEnumerable<SubCategoryViewDto>>> GetSubCategoriesView()
        {
            try
            {
                var SubCategories = await this.adminRepository.GetSubCategoriesView();

                if (SubCategories == null)
                {
                    return NotFound();
                }
                else
                {
                    var subCategoryDto = SubCategories.ToList();
                    return Ok(subCategoryDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        //Get Users
        [HttpGet("AdminGetUsers")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            try
            {
                var users = await this.adminRepository.GetUsers();

                if (users == null)
                {
                    return NotFound();
                }
                else
                {
                    var usersDto = users.ToList();
                    return Ok(usersDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        //Get Contacts
        [HttpGet("AdminGetContacts")]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetContacts()
        {
            try
            {
                var contacts = await this.adminRepository.GetContacts();

                if (contacts == null)
                {
                    return NotFound();
                }
                else
                {
                    var contactsDto = contacts.ToList();
                    return Ok(contactsDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        //Get Carousels
        [HttpGet("AdminGetCarousels")]
        public async Task<ActionResult<IEnumerable<CarouselDto>>> GetCarousels()
        {
            try
            {
                var carousels = await this.adminRepository.GetCarousels();

                if (carousels == null)
                {
                    return NotFound();
                }
                else
                {
                    var carouselsDto = carousels.ToList();
                    return Ok(carouselsDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        //Delete Carousel
        [HttpDelete("DeleteCarousel/{Id:int}/{ImageURL}")]
        public async Task<ActionResult<CarouselDto>> DeleteCarousel(int Id, string ImageURL)
        {
            try
            {
                var Carousel = await this.adminRepository.DeleteCarousel(Id);

                var path = Path.Combine(_env.ContentRootPath, "Images", "Carousels", ImageURL);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                if (Carousel == null)
                {
                    return NotFound();
                }

                var CarouselDto = Carousel;

                return Ok(CarouselDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Check Carousel
        [HttpGet]
        [Route("{Title}/{ImageURL}/CheckCarousel")]
        public async Task<ActionResult<IEnumerable<CarouselDto>>> CheckCartItems(string Title, string ImageURL)
        {
            try
            {
                var Check = await this.adminRepository.CheckCarousel(Title, ImageURL);

                if (Check == null)
                {
                    return NoContent();
                }

                var CheckDto = Check.ToList();

                return Ok(Check);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Delete User
        [HttpDelete("DeleteUser/{User_id:int}")]
        public async Task<ActionResult<UserDto>> DeleteUser(int User_id)
        {
            try
            {
                var User = await this.adminRepository.DeleteUser(User_id);

                if (User == null)
                {
                    return NotFound();
                }

                var UserDto = User;

                return Ok(UserDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Check Category
        [HttpGet]
        [Route("{Title}/{ImageURL}/CheckCategory")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> CheckCategory(string Title, string ImageURL)
        {
            try
            {
                var Check = await this.adminRepository.CheckCategory(Title, ImageURL);

                if (Check == null)
                {
                    return NoContent();
                }

                var CheckDto = Check.ToList();

                return Ok(Check);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Check SubCategory
        [HttpGet]
        [Route("{Title}/{Category_id:int}/CheckSubCategory")]
        public async Task<ActionResult<IEnumerable<SubCategoryDto>>> CheckSubCategory(string Title, int Category_id)
        {
            try
            {
                var Check = await this.adminRepository.CheckSubCategory(Title, Category_id);

                if (Check == null)
                {
                    return NoContent();
                }

                var CheckDto = Check.ToList();

                return Ok(Check);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Add SubCategory
        [HttpPost("AddSubCategory")]
        public async Task<ActionResult<SubCategoryDto>> AddSubCategory([FromBody] SubCategoryDto subCategoryDto)
        {
            try
            {
                var subCategory = new SubCategory()
                {
                    Title = subCategoryDto.Title,
                    Category_id = subCategoryDto.Category_id,
                };

                var result = await _context.SubCategories.AddAsync(subCategory);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Delete SubCategory
        [HttpDelete("DeleteSubCategory/{SubCategory_id:int}")]
        public async Task<ActionResult<SubCategoryDto>> DeleteSubCategory(int SubCategory_id)
        {
            try
            {
                var SubCategory = await this.adminRepository.DeleteSubCategory(SubCategory_id);

                if (SubCategory == null)
                {
                    return NotFound();
                }

                var SubCategoryDto = SubCategory;

                return Ok(SubCategoryDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Get Products
        [HttpGet("AdminGetProducts")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            try
            {
                var products = await this.adminRepository.GetProducts();

                if (products == null)
                {
                    return NotFound();
                }
                else
                {
                    var productsDtos = products.ToList();
                    return Ok(productsDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        //Check Product
        [HttpGet]
        [Route("{SubCategory_id:int}/{Category_id:int}/{Title}/{ImageURL}/CheckProduct")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> CheckProduct(int SubCategory_id, int Category_id, string Title, string ImageURL)
        {
            try
            {
                var Check = await this.adminRepository.CheckProduct(SubCategory_id, Category_id, Title, ImageURL);

                if (Check == null)
                {
                    return NoContent();
                }

                var CheckDto = Check.ToList();

                return Ok(Check);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Get Colors Product
        [HttpGet]
        [Route("{Product_id:int}/GetColorsProduct")]
        public async Task<ActionResult<IEnumerable<ProductColorDto>>> GetColorsProduct(int Product_id)
        {
            try
            {
                var Colors = await this.adminRepository.GetColorsProduct(Product_id);

                if (Colors == null)
                {
                    return NoContent();
                }

                var ColorsDto = Colors.ToList();

                return Ok(Colors);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Get Images Product
        [HttpGet]
        [Route("{Product_id:int}/GetImagesProduct")]
        public async Task<ActionResult<IEnumerable<ProductImageDto>>> GetImagesProduct(int Product_id)
        {
            try
            {
                var Images = await this.adminRepository.GetImagesProduct(Product_id);

                if (Images == null)
                {
                    return NoContent();
                }

                var ImagesDto = Images.ToList();

                return Ok(ImagesDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Get Price Product
        [HttpGet]
        [Route("{Product_id:int}/GetPriceProduct")]
        public async Task<ActionResult<IEnumerable<ProductPriceDto>>> GetPriceProduct(int Product_id)
        {
            try
            {
                var Price = await this.adminRepository.GetPriceProduct(Product_id);

                if (Price == null)
                {
                    return NoContent();
                }

                var PriceDto = Price.ToList();

                return Ok(PriceDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Get Size Product
        [HttpGet]
        [Route("{Product_id:int}/GetSizeProduct")]
        public async Task<ActionResult<IEnumerable<ProductSizeDto>>> GetSizeProduct(int Product_id)
        {
            try
            {
                var Size = await this.adminRepository.GetSizeProduct(Product_id);

                if (Size == null)
                {
                    return NoContent();
                }

                var SizeDto = Size.ToList();

                return Ok(SizeDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Get Stock Product
        [HttpGet]
        [Route("{Product_id:int}/GetStockProduct")]
        public async Task<ActionResult<IEnumerable<StockDto>>> GetStockProduct(int Product_id)
        {
            try
            {
                var Stock = await this.adminRepository.GetStockProduct(Product_id);

                if (Stock == null)
                {
                    return NoContent();
                }

                var StockDto = Stock.ToList();

                return Ok(StockDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Get Discount Product
        [HttpGet]
        [Route("{Product_id:int}/GetDiscountProduct")]
        public async Task<ActionResult<IEnumerable<DiscountDto>>> GetDiscountProduct(int Product_id)
        {
            try
            {
                var Discount = await this.adminRepository.GetDiscountProduct(Product_id);

                if (Discount == null)
                {
                    return NoContent();
                }

                var DiscountDto = Discount.ToList();

                return Ok(DiscountDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}