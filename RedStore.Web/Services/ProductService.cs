using RedStore.Models.Dtos;
using RedStore.Web.Interfaces;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace RedStore.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        //Get All Categories
        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            try
            {
                var response = await this.httpClient.GetAsync("api/Product/GetCategories");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CategoryDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<CategoryDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        //Get All Carousel
        public async Task<IEnumerable<CarouselDto>> GetCarousels()
        {
            try
            {
                var response = await this.httpClient.GetAsync("api/Product/GetCarousels");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CarouselDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<CarouselDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        //Get Sub Category
        public async Task<IEnumerable<SubCategoryDto>> GeSubCategory(int Category_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Product/{Category_id}/GeSubCategory");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<SubCategoryDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<SubCategoryDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get All Products
        public async Task<IEnumerable<ProductViewDto>> GetProducts(int Category_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Product/{Category_id}/GetProducts");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductViewDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<ProductViewDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get All Products Sub Category
        public async Task<IEnumerable<ProductViewDto>> GetProductsSubCategory(int SubCategory_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Product/{SubCategory_id}/GetProductsSubCategory");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductViewDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<ProductViewDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ProductViewDto>> GetProduct(int Product_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Product/{Product_id}/GetSingleProduct");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductViewDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<ProductViewDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Search  GetSearch

        public async Task<List<SearchDto>> GetSearch()
        {
            try
            {
                var response = await this.httpClient.GetAsync($"api/Product/GetSearch");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<SearchDto>().ToList();
                    }

                    return await response.Content.ReadFromJsonAsync<List<SearchDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        //Get Product Colors
        public async Task<IEnumerable<ProductColorDto>> GetProductColors(int Product_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Product/{Product_id}/GetProductColors");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductColorDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<ProductColorDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get Product Images
        public async Task<IEnumerable<ProductImageDto>> GetProductImages(int Product_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Product/{Product_id}/GetProductImages");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductImageDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<ProductImageDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get Product Size
        public async Task<IEnumerable<ProductSizeDto>> GetProductSize(int Product_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Product/{Product_id}/GetProductSize");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductSizeDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<ProductSizeDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Add Review
        public async Task<ReviewDto> AddReview(ReviewDto ReviewDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<ReviewDto>("api/Product/AddReview", ReviewDto);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ReviewDto>();
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get Review
        public async Task<IEnumerable<ReviewDto>> GetReview(int User_id, int Product_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Product/{User_id}/{Product_id}/GetReview");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ReviewDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<ReviewDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get Review Count
        public async Task<IEnumerable<ReviewDto>> GetReviewCount(int Product_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Product/{Product_id}/GetReviewCount");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ReviewDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<ReviewDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Add Favorite
        public async Task<FavoriteDto> Addfavorite(FavoriteDto FavoriteDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<FavoriteDto>("api/Product/Addfavorite", FavoriteDto);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<FavoriteDto>();
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get Favorite
        public async Task<IEnumerable<FavoriteDto>> GetFavorite(int User_id, int Product_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Product/{User_id}/{Product_id}/GetFavorite");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<FavoriteDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<FavoriteDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FavoriteDto> RemoveFavorite(int User_id, int Product_id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/Product/{User_id}/{Product_id}/RemoveFavorite");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<FavoriteDto>();
                }
                return default(FavoriteDto);
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        //Get Favorite
        public async Task<IEnumerable<FavoriteViewDto>> GetFavoriteView(int User_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Product/{User_id}/GetFavoriteView");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<FavoriteViewDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<FavoriteViewDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}