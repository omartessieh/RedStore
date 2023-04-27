using RedStore.Admin.Interfaces;
using RedStore.Models.Dtos;
using System.Net.Http.Json;
using System.Collections.Generic;

namespace RedStore.Admin.Services
{
    public class AdminService : IAdminService
    {
        private readonly HttpClient httpClient;

        public AdminService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        //Get Categories
        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            try
            {
                var response = await this.httpClient.GetAsync("api/Admin/AdminGetCategories");

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

        //Delete Category
        public async Task<CategoryDto> DeleteCategory(int Category_id, string ImageURL)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/Admin/DeleteCategory/{Category_id}/{ImageURL}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CategoryDto>();
                }
                return default(CategoryDto);
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        //Get SubCategories
        public async Task<IEnumerable<SubCategoryViewDto>> GetSubCategoriesView()
        {
            try
            {
                var response = await this.httpClient.GetAsync("api/Admin/AdminGetSubCategoriesView");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<SubCategoryViewDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<SubCategoryViewDto>>();
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

        //Get Users
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            try
            {
                var response = await this.httpClient.GetAsync("api/Admin/AdminGetUsers");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<UserDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();
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

        //Get Contacts
        public async Task<IEnumerable<ContactDto>> GetContacts()
        {
            try
            {
                var response = await this.httpClient.GetAsync("api/Admin/AdminGetContacts");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ContactDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<ContactDto>>();
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

        //Get Carousels
        public async Task<IEnumerable<CarouselDto>> GetCarousels()
        {
            try
            {
                var response = await this.httpClient.GetAsync("api/Admin/AdminGetCarousels");

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

        //Delete Carousel
        public async Task<CarouselDto> DeleteCarousel(int Id, string ImageURL)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/Admin/DeleteCarousel/{Id}/{ImageURL}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CarouselDto>();
                }
                return default(CarouselDto);
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        //Check Carousel
        public async Task<IEnumerable<CarouselDto>> CheckCarousel(string Title, string ImageURL)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Admin/{Title}/{ImageURL}/CheckCarousel");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CarouselDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<CarouselDto>>();
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

        //Get User Information
        public async Task<UserDto> GetUserInfo(int User_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/User/{User_id}/UserInfo");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(UserDto);
                    }
                    return await response.Content.ReadFromJsonAsync<UserDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        //Update User
        public async Task<UserDto> UpdateUser(int User_id, UserDto userDto)
        {
            try
            {

                var response = await httpClient.PostAsJsonAsync($"api/User/UpdateUser/{User_id}", userDto);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<UserDto>();
                }
                return null;

            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        //Check User Update
        public async Task<IEnumerable<UserDto>> CheckUserUpdate(string username, string email, string phone, int User_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/User/{username}/{email}/{phone}/{User_id}/CheckUserUpdate");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<UserDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<UserDto>>();
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

        //Add User
        public async Task<UserDto> AddUser(UserDto userDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<UserDto>("api/User", userDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(UserDto);
                    }

                    return await response.Content.ReadFromJsonAsync<UserDto>();

                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Check User Exist
        public async Task<IEnumerable<UserDto>> CheckUserExist(string username, string email, string phone)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/User/{username}/{email}/{phone}/CheckUserExist");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<UserDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<UserDto>>();
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

        //Delete User
        public async Task<UserDto> DeleteUser(int User_id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/Admin/DeleteUser/{User_id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<UserDto>();
                }
                return default(UserDto);
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        //Check Category
        public async Task<IEnumerable<CategoryDto>> CheckCategory(string Title, string ImageURL)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Admin/{Title}/{ImageURL}/CheckCategory");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CategoryDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<CategoryDto>>();
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

        //Check SubCategory
        public async Task<IEnumerable<SubCategoryDto>> CheckSubCategory(string Title, int Category_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Admin/{Title}/{Category_id}/CheckSubCategory");

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

        //Delete SubCategory
        public async Task<SubCategoryDto> DeleteSubCategory(int SubCategory_id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/Admin/DeleteSubCategory/{SubCategory_id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<SubCategoryDto>();
                }
                return default(SubCategoryDto);
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        //Get Products
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            try
            {
                var response = await this.httpClient.GetAsync("api/Admin/AdminGetProducts");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>();
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

        //Check Product
        public async Task<IEnumerable<ProductDto>> CheckProduct(int SubCategory_id, int Category_id, string Title, string ImageURL)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Admin/{SubCategory_id}/{Category_id}/{Title}/{ImageURL}/CheckProduct");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<ProductDto>>();
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

        //Get Colors Product
        public async Task<IEnumerable<ProductColorDto>> GetColorsProduct(int Product_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Admin/{Product_id}/GetColorsProduct");

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

        //Get Images Product
        public async Task<IEnumerable<ProductImageDto>> GetImagesProduct(int Product_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Admin/{Product_id}/GetImagesProduct");

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

        //Get Price Product
        public async Task<IEnumerable<ProductPriceDto>> GetPriceProduct(int Product_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Admin/{Product_id}/GetPriceProduct");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductPriceDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<ProductPriceDto>>();
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

        //Get Size Product
        public async Task<IEnumerable<ProductSizeDto>> GetSizeProduct(int Product_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Admin/{Product_id}/GetSizeProduct");

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

        //Get Stock Product
        public async Task<IEnumerable<StockDto>> GetStockProduct(int Product_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Admin/{Product_id}/GetStockProduct");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<StockDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<StockDto>>();
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

        //Get Discount Product
        public async Task<IEnumerable<DiscountDto>> GetDiscountProduct(int Product_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Admin/{Product_id}/GetDiscountProduct");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<DiscountDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<DiscountDto>>();
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