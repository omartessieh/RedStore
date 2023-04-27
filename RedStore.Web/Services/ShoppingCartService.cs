using RedStore.Models.Dtos;
using RedStore.Web.Interfaces;
using System.Net.Http.Json;

namespace RedStore.Web.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly HttpClient httpClient;

        public ShoppingCartService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        //Add Product To Cart Item
        public async Task<CartitemDto> AddItem(CartitemDto cartitemDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<CartitemDto>("api/ShoppingCart", cartitemDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(CartitemDto);
                    }

                    return await response.Content.ReadFromJsonAsync<CartitemDto>();

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

        //Delete Item From Cart Item
        public async Task<CartitemDto> DeleteItem(int Cartitem_id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/ShoppingCart/{Cartitem_id}/Delete");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CartitemDto>();
                }
                return default(CartitemDto);
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        //Check Cart Item
        public async Task<IEnumerable<CartitemDto>> CheckCartItems(int Cart_id, int Product_id, int Color_id, int Size_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/ShoppingCart/{Cart_id}/{Product_id}/{Color_id}/{Size_id}/CheckCartItems");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CartitemDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<CartitemDto>>();
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

        //Get Cart ID
        public async Task<CartDto> GetCartID(int User_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/ShoppingCart/{User_id}/GetCartID");

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
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        //Get Order Qty
        public async Task<IEnumerable<OrderDetailDto>> GetOrderQty(int Product_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/ShoppingCart/{Product_id}/GetOrderQty");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<OrderDetailDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<OrderDetailDto>>();
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

        //Get All Product Cart Item View
        public async Task<IEnumerable<CartItemViewDto>> GetAllProduct(int Cart_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/ShoppingCart/{Cart_id}/GetAllProduct");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CartItemViewDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<CartItemViewDto>>();
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

        //Update Qty
        public async Task<CartitemDto> UpdateQty(CartitemDto cartItemDto)
        {
            try
            {

                var response = await httpClient.PostAsJsonAsync<CartitemDto>($"api/ShoppingCart/UpdateQty/{cartItemDto.Cartitem_id}", cartItemDto);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CartitemDto>();
                }
                return null;

            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        //Add Order Item
        public async Task<OrderDetailDto> AddOrder(OrderDetailDto orderDetailDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<OrderDetailDto>("api/ShoppingCart/AddOrder", orderDetailDto);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<OrderDetailDto>();
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get All Order Details 
        public async Task<IEnumerable<OrderDetailsViewDto>> GetOrderDetails(int User_id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/ShoppingCart/{User_id}/GetOrderDetails");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<OrderDetailsViewDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<OrderDetailsViewDto>>();
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