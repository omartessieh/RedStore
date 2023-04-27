using Microsoft.AspNetCore.Components;
using RedStore.Models.Dtos;
using RedStore.Web.Interfaces;
using System.Drawing;
using System.Net.Http.Json;

namespace RedStore.Web.Pages
{
    public partial class ProductItems : ComponentBase
    {
        [Parameter]
        public int Category_id { get; set; }

        [Parameter]
        public string Title { get; set; }

        public string ListTitle { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        public IEnumerable<SubCategoryDto> SubCategories { get; set; }

        public IEnumerable<ProductViewDto> Products { get; set; }

        public IEnumerable<ProductViewDto> SubCategoriesProducts { get; set; }

        public List<SearchDto>? searchs;

        int? Product_id;

        string? filter;

        string? ValueText;

        string productslink = "https://localhost:7068/GetProductsImages";

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Products = await ProductService.GetProducts(Category_id);
                SubCategories = await ProductService.GeSubCategory(Category_id);
                ListTitle = Title + " Categories";
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected async Task LoadDataCategory(int Category_id)
        {
            try
            {
                Products = await ProductService.GetProducts(Category_id);
            }
            catch (Exception)
            {
                //Log Exception
            }
        }

        protected async Task LoadData(int SubCategory_id)
        {
            try
            {
                Products = await ProductService.GetProductsSubCategory(SubCategory_id);
            }
            catch (Exception)
            {
                //Log Exception
            }
        }

        protected async Task Low()
        {
            Products = Products.OrderBy(x => x.PriceAfterDiscount);
        }

        protected async Task High()
        {
            Products = Products.OrderByDescending(x => x.PriceAfterDiscount);
        }

        async Task HandleInput(ChangeEventArgs e)
        {
            filter = e.Value?.ToString();
            if (filter?.Length > 0)
            {
                searchs = await ProductService.GetSearch();
                searchs = searchs.Where(i => i.Title.ToLower().Contains(filter)).ToList();
            }
            else
            {
                searchs = null;
            }
        }

        async Task SelectCustomerAsync(int id, string title, string type)
        {
            searchs = null;
            ValueText = null;

            if (type == "Category")
            {
                Category_id = id;
                Title = title;
                Products = await ProductService.GetProducts(Category_id);
                SubCategories = await ProductService.GeSubCategory(Category_id);
            }
            else
            {
                Product_id = id;
                NavigationManager.NavigateTo($"/ProductDetails/{Product_id}");
            }
        }

    }
}