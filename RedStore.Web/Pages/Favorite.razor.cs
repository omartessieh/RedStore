using Microsoft.AspNetCore.Components;
using RedStore.Models.Dtos;
using RedStore.Web.Interfaces;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace RedStore.Web.Pages
{
    public partial class Favorite : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }

        public IEnumerable<FavoriteViewDto> FavoriteView { get; set; }

        [Inject]
        public ILocalStorageService? LocalStorage { get; set; }

        public int User_id = 0;

        public int TotalItems { get; set; }

        string productslink = "https://localhost:7068/GetProductsImages";

        protected override async Task OnInitializedAsync()
        {
            User_id = await LocalStorage.GetItemAsync<int>("id");

            try
            {
                FavoriteView = await ProductService.GetFavoriteView(User_id);

                TotalItems = FavoriteView.Count();

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
