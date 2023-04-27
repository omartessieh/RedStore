using RedStore.Models.Dtos;
using RedStore.Web.Interfaces;
using System.Net.Http.Json;

namespace RedStore.Web.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        //Registration User
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

        //Login User
        public async Task<List<LoginDto>> LoginUser(string username, string password)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/User/{username}/{password}/LoginUser");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<LoginDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<LoginDto>>();
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

        //Add Cart Id
        public async Task<CartDto> AddCartId(CartDto cartDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<CartDto>("api/User/AddCartId", cartDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(CartDto);
                    }

                    return await response.Content.ReadFromJsonAsync<CartDto>();

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

        //Add Contact
        public async Task<ContactDto> AddContact(ContactDto contactDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<ContactDto>("api/User/AddContact", contactDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ContactDto);
                    }

                    return await response.Content.ReadFromJsonAsync<ContactDto>();

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

    }
}