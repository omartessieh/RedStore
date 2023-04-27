using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using RedStore.Admin.Interfaces;
using RedStore.Models.Dtos;
using System.Net.Http.Headers;

namespace RedStore.Admin.Pages.Product
{
    public partial class Product : ComponentBase
    {
        [Inject] HttpClient? Http { get; set; }

        [Inject]
        public IAdminService AdminService { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IEnumerable<CategoryDto> GetCategories { get; set; }

        public IEnumerable<ProductDto> GetProducts { get; set; }

        public IEnumerable<ProductDto> CheckProduct { get; set; }

        public IEnumerable<SubCategoryViewDto> GetSubCategoriesView { get; set; }

        string Productslink = "https://localhost:7068/GetProductsImages";

        private IBrowserFile files;

        public List<string> fileNames = new();

        public int maxAllowedFiles = int.MaxValue;

        public long maxFileSize = long.MaxValue;

        public string PopDescription;

        public int SelectedCategoryId;

        public int SelectedSubCategoryId;

        public string ProductTitle;

        public string ProductDescription;

        bool fixed_header = true;

        bool fixed_footer = false;

        private string _searchString;

        private bool _sortNameByLength;

        public string imageSource;

        public bool _isOpen = false;

        public bool _DescriptionisOpen = false;

        public bool _isOpenAddProduct = false;

        protected override async Task OnInitializedAsync()
        {
            GetCategories = await AdminService.GetCategories();
            GetSubCategoriesView = await AdminService.GetSubCategoriesView();
            GetProducts = await AdminService.GetProducts();
        }

        private Func<ProductDto, object> _sortBy => x =>
        {
            if (_sortNameByLength)
                return x.Title.Length;
            else
                return x.Title;
        };

        private Func<ProductDto, bool> _quickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            if (x.Title.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };

        private void OpenImage(string ProductImage)
        {
            if (_isOpen)
            {
                _isOpen = false;
            }
            else
            {
                _isOpen = true;
                imageSource = ProductImage;
            }
        }

        private void OpenDescription(string Description)
        {
            if (_DescriptionisOpen)
            {
                _DescriptionisOpen = false;
            }
            else
            {
                _DescriptionisOpen = true;
                PopDescription = Description;
            }
        }

        private void OpenAddProduct()
        {
            if (_isOpenAddProduct)
            {
                _isOpenAddProduct = false;
            }
            else
            {
                _isOpenAddProduct = true;
            }
        }

        private void OnInputFileChanged(InputFileChangeEventArgs e)
        {
            files = e.File;
            Snackbar.Add("Image was completed", Severity.Success);
        }

        protected async Task SubmitProduct()
        {
            var Category_id = SelectedCategoryId;
            var SubCategory_id = SelectedSubCategoryId;
            var Title = ProductTitle;
            var Description = ProductDescription;

            if (Category_id == 0)
            {
                Snackbar.Add("Select Category is Null", Severity.Error);
            }
            else if (SubCategory_id == 0)
            {
                Snackbar.Add("Select SubCategory is Null", Severity.Error);
            }
            else if (Title == null)
            {
                Snackbar.Add("Title is Null", Severity.Error);
            }
            else if (Description == null)
            {
                Snackbar.Add("Description is Null", Severity.Error);
            }
            else if (files == null)
            {
                Snackbar.Add("Uload Product Image", Severity.Error);
            }
            else
            {
                CheckProduct = await AdminService.CheckProduct(SubCategory_id, Category_id, Title, files.Name);

                if (CheckProduct.Count() > 0)
                {
                    Snackbar.Add("Already Exists", Severity.Error);
                }
                else
                {

                    using var content = new MultipartFormDataContent();
                    var fileContent = new StreamContent(files.OpenReadStream(maxFileSize));
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(files.ContentType);
                    fileNames.Add(files.Name);

                    content.Add(
                        content: fileContent,
                        name: "\"files\"",
                        fileName: files.Name
                        );

                    var response = await Http.PostAsync($"/api/File/PostProductImage/{Title}/{Description}/{SubCategory_id}/{Category_id}", content);

                    GetProducts = await AdminService.GetProducts();

                    SelectedCategoryId = 0;
                    SelectedSubCategoryId = 0;
                    ProductTitle = null;
                    ProductDescription = null;

                    _isOpenAddProduct = false;

                    Snackbar.Add("Operation successful", Severity.Success);

                }
            }
        }

        protected async Task OpenInfo(int Product_id, string Title)
        {
            NavigationManager.NavigateTo($"ProductInfo/{Product_id}/{Title}");
        }

        public async Task Delete(int Product_id)
        {
            bool? result = await DialogService.ShowMessageBox(
            "Warning",
            "Are you sure you want to delete this Product! " +
            "Note all Information affiliated to this Product will deleted.",
            yesText: "Delete!", cancelText: "Cancel");

            if (result == true)
            {
                //var deletecarouselDto = await AdminService.DeleteCarousel(Id, ImageURL);
                //GetProducts = await AdminService.GetProducts();
            }
            StateHasChanged();
        }
    }
}