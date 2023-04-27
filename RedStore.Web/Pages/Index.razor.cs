using Microsoft.AspNetCore.Components;
using RedStore.Web.Interfaces;
using RedStore.Models.Dtos;
using System.Net.Http.Json;
using Microsoft.JSInterop;

namespace RedStore.Web.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject] HttpClient? Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        public IEnumerable<CategoryDto> GetCategories { get; set; }

        public IEnumerable<CarouselDto> GetCarousels { get; set; }
        public string ImageData { get; private set; }

        public List<SearchDto>? searchs;

        int? Category_id;

        int? Product_id;

        string? Title;

        string? filter;

        string? ValueText;

        string Carouselslink = "https://localhost:7068/GetCarouselsImages";

        string Categorieslink = "https://localhost:7068/GetCategoriesImages";

        protected override async Task OnInitializedAsync()
        {
            GetCategories = await ProductService.GetCategories();
            GetCarousels = await ProductService.GetCarousels();        
        }

        async Task HandleInput(ChangeEventArgs e)
        {
            
            filter = e.Value?.ToString();
            if (filter?.Length > 0)
            {
                searchs = await ProductService.GetSearch();
                searchs =  searchs.Where(i => i.Title.ToLower().Contains(filter)).ToList();
            }
            else
            {
                searchs = null;
            }
        }

        void SelectCustomer(int id, string title, string type)
        {
            searchs = null;
            ValueText = null;

            if (type == "Category")
            {
                Category_id = id;
                Title = title;
                NavigationManager.NavigateTo($"/ProductItems/{Category_id}/{Title}");
            }
            else
            {
                Product_id = id;
                NavigationManager.NavigateTo($"/ProductDetails/{Product_id}");
            }
        }

    }
}