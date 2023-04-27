using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedStore.Api.Interfaces;
using RedStore.Models.Dtos;

namespace RedStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        //Get All Categories
        [HttpGet("GetCategories")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            try
            {
                var categories = await this.productRepository.GetCategories();

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

        //Get All Carousel
        [HttpGet("GetCarousels")]
        public async Task<ActionResult<IEnumerable<CarouselDto>>> GetCarousels()
        {
            try
            {
                var carousels = await this.productRepository.GetCarousels();

                if (carousels == null)
                {
                    return NotFound();
                }
                else
                {
                    var carouselsDtos = carousels.ToList();
                    return Ok(carouselsDtos);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        //Get Sub Category
        [HttpGet]
        [Route("{Category_id}/GeSubCategory")]
        public async Task<ActionResult<IEnumerable<SubCategoryDto>>> GeSubCategory(int Category_id)
        {
            try
            {
                var subcategories = await this.productRepository.GeSubCategory(Category_id);

                if (subcategories == null)
                {
                    return NoContent();
                }

                var subcategoriesDto = subcategories.ToList();

                return Ok(subcategoriesDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Get All Products
        [HttpGet]
        [Route("{Category_id}/GetProducts")]
        public async Task<ActionResult<IEnumerable<ProductViewDto>>> GetProducts(int Category_id)
        {
            try
            {
                var products = await this.productRepository.GetProducts(Category_id);

                if (products == null)
                {
                    return NoContent();
                }

                var productsDto = products.ToList().OrderBy(x => Guid.NewGuid()).ToList();

                return Ok(productsDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        //Get All Products Sub Category
        [HttpGet]
        [Route("{SubCategory_id}/GetProductsSubCategory")]
        public async Task<ActionResult<IEnumerable<ProductViewDto>>> GetProductsSubCategory(int SubCategory_id)
        {
            try
            {
                var productssubcategory = await this.productRepository.GetProductsSubCategory(SubCategory_id);

                if (productssubcategory == null)
                {
                    return NoContent();
                }

                var productssubcategoryDto = productssubcategory.ToList();

                return Ok(productssubcategoryDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Get Single Product
        [HttpGet("{Product_id:int}/GetSingleProduct")]
        public async Task<ActionResult<IEnumerable<ProductViewDto>>> GetProduct(int Product_id)
        {
            try
            {
                var product = await this.productRepository.GetProduct(Product_id);

                if (product == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(product);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");

            }
        }

        //Get All Search Value
        //[HttpGet("GetGlobalSearch/{searchText}")]
        //public async Task<ActionResult<List<SearchDto>>> SearchProducts(string searchText)
        //{
        //    try
        //    {
        //        var search = await this.productRepository.SearchProducts(searchText);

        //        if (search == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            var searchDtos = search.ToList();
        //            return Ok(searchDtos);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        //    }
        //}

        [HttpGet("GetSearch")]
        public async Task<ActionResult<List<SearchDto>>> GetSearch()
        {
            try
            {
                var search = await this.productRepository.GetSearch();

                if (search == null)
                {
                    return NotFound();
                }
                else
                {
                    var searchDtos = search.ToList();
                    return Ok(searchDtos);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        //Get Product Colors
        [HttpGet("{Product_id:int}/GetProductColors")]
        public async Task<ActionResult<IEnumerable<ProductColorDto>>> GetProductColors(int Product_id)
        {
            try
            {
                var colors = await this.productRepository.GetProductColors(Product_id);

                if (colors == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(colors);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");

            }
        }

        //Get Product Images
        [HttpGet("{Product_id:int}/GetProductImages")]
        public async Task<ActionResult<IEnumerable<ProductImageDto>>> GetProductImages(int Product_id)
        {
            try
            {
                var images = await this.productRepository.GetProductImages(Product_id);

                if (images == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(images);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");

            }
        }

        //Get Product Size
        [HttpGet("{Product_id:int}/GetProductSize")]
        public async Task<ActionResult<IEnumerable<ProductSizeDto>>> GetProductSize(int Product_id)
        {
            try
            {
                var size = await this.productRepository.GetProductSize(Product_id);

                if (size == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(size);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");

            }
        }

        //Add Review
        [HttpPost("AddReview")]
        public async Task<ActionResult<ReviewDto>> AddReview([FromBody] ReviewDto ReviewDto)
        {
            try
            {
                var newReview = await this.productRepository.AddReview(ReviewDto);

                if (newReview == null)
                {
                    return NoContent();
                }

                var Review = new ReviewDto
                {
                    User_id = ReviewDto.User_id,
                    Product_id = ReviewDto.Product_id,
                    Rating = ReviewDto.Rating,
                    Message = ReviewDto.Message,
                    Created_at = ReviewDto.Created_at,
                };

                var newReviewDto = Review;

                return Ok(newReviewDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Get Review
        [HttpGet("{User_id:int}/{Product_id:int}/GetReview")]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReview(int User_id, int Product_id)
        {
            try
            {
                var Review = await this.productRepository.GetReview(User_id, Product_id);

                if (Review == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(Review);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");

            }
        }

        //Get Review Count
        [HttpGet("{Product_id:int}/GetReviewCount")]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReviewCount(int Product_id)
        {
            try
            {
                var Review = await this.productRepository.GetReviewCount(Product_id);

                if (Review == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(Review);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");

            }
        }

        //Add Favorite
        [HttpPost("Addfavorite")]
        public async Task<ActionResult<FavoriteDto>> Addfavorite([FromBody] FavoriteDto FavoriteDto)
        {
            try
            {
                var newFavorite = await this.productRepository.Addfavorite(FavoriteDto);

                if (newFavorite == null)
                {
                    return NoContent();
                }

                var Favorite = new FavoriteDto
                {
                    User_id = FavoriteDto.User_id,
                    Product_id = FavoriteDto.Product_id,
                    Created_at = FavoriteDto.Created_at,
                };

                var newFavoriteDto = Favorite;

                return Ok(newFavoriteDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Get Favorite
        [HttpGet("{User_id:int}/{Product_id:int}/GetFavorite")]
        public async Task<ActionResult<IEnumerable<FavoriteDto>>> GetFavorite(int User_id, int Product_id)
        {
            try
            {
                var Favorite = await this.productRepository.GetFavorite(User_id, Product_id);

                if (Favorite == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(Favorite);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");

            }
        }

        //Remove Favorite
        [HttpDelete("{User_id:int}/{Product_id:int}/RemoveFavorite")]
        public async Task<ActionResult<FavoriteDto>> RemoveFavorite(int User_id, int Product_id)
        {
            try
            {
                var Favorite = await this.productRepository.RemoveFavorite(User_id, Product_id);

                if (Favorite == null)
                {
                    return NotFound();
                }

                var FavoriteDto = Favorite;

                return Ok(FavoriteDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Get Favorite
        [HttpGet]
        [Route("{User_id}/GetFavoriteView")]
        public async Task<ActionResult<IEnumerable<FavoriteViewDto>>> GetFavoriteView(int User_id)
        {
            try
            {
                var Favorite = await this.productRepository.GetFavoriteView(User_id);

                if (Favorite == null)
                {
                    return NoContent();
                }

                var FavoriteDto = Favorite.ToList();

                return Ok(FavoriteDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }





        //ionic Get All Categories
        //[HttpGet("{limit:int}/GetionicCategories")]
        //public async Task<ActionResult<IEnumerable<CategoryDto>>> GetionicCategories(int limit)
        //{
        //    try
        //    {
        //        var Category = await this.productRepository.GetionicCategories(limit);

        //        if (Category == null)
        //        {
        //            return BadRequest();
        //        }
        //        else
        //        {
        //            return Ok(Category);
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");

        //    }
        //}
    }
}
