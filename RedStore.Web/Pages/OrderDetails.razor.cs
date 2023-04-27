using Microsoft.AspNetCore.Components;
using RedStore.Models.Dtos;
using RedStore.Web.Interfaces;
using Microsoft.JSInterop;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Text.Json;

namespace RedStore.Web.Pages
{
    public partial class OrderDetails : ComponentBase
    {
        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        [Inject]
        public ILocalStorageService? LocalStorage { get; set; }

        [Inject]
        public AuthenticationStateProvider? AuthStateProvider { get; set; }

        [Inject]
        public NavigationManager? NavManager { get; set; }

        public IEnumerable<OrderDetailsViewDto> OrderDetail { get; set; }

        public int User_id = 0;

        public int TotalItems { get; set; }

        string productslink = "https://localhost:7068/GetProductsImages";

        protected override async Task OnInitializedAsync()
        {
            User_id = await LocalStorage.GetItemAsync<int>("id");

            try
            {
                OrderDetail = await ShoppingCartService.GetOrderDetails(User_id);

                TotalItems = OrderDetail.Count();

                if (TotalItems == 0)
                {
                    TotalItems = 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
