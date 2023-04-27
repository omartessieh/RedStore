using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using MudBlazor;
using RedStore.Admin.Interfaces;
using RedStore.Models.Dtos;
using System.Net.Http.Headers;

namespace RedStore.Admin.Pages
{
    public partial class Category : ComponentBase
    {
        [Inject] HttpClient? Http { get; set; }

        [Inject] IJSRuntime? JS { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        [Inject]
        public IAdminService AdminService { get; set; }

        public IEnumerable<CategoryDto> GetCategories { get; set; }

        public IEnumerable<CategoryDto> CheckCategory { get; set; }

        public string CategoryTitle { get; set; }

        private CategoryDto categoryDto = new CategoryDto();

        private IBrowserFile files;

        public List<string> fileNames = new();

        public int maxAllowedFiles = int.MaxValue;

        public long maxFileSize = long.MaxValue;

        bool fixed_header = true;

        bool fixed_footer = false;

        private string _searchString;

        private bool _sortNameByLength;

        public string imageSource;

        public bool _isOpen = false;

        public bool _isOpenCategory = false;

        string Categorieslink = "https://localhost:7068/GetCategoriesImages";

        protected override async Task OnInitializedAsync()
        {
            GetCategories = await AdminService.GetCategories();
        }

        private Func<CategoryDto, object> _sortBy => x =>
        {
            if (_sortNameByLength)
                return x.Title.Length;
            else
                return x.Title;
        };

        private Func<CategoryDto, bool> _quickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            if (x.Title.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };

        private void OpenImage(string ImageURL)
        {
            if (_isOpen)
            {
                _isOpen = false;
            }
            else
            {
                _isOpen = true;
                imageSource = ImageURL;
            }
        }

        private void OpenAddCategory()
        {
            if (_isOpenCategory)
            {
                _isOpenCategory = false;
                CategoryTitle = null;
            }
            else
            {
                _isOpenCategory = true;
            }
        }

        private void OnInputFileChanged(InputFileChangeEventArgs e)
        {
            files = e.File;
            Snackbar.Add("Image was completed", Severity.Success);
        }

        public async Task SubmitCategory()
        {

            var Title = CategoryTitle;

            if (Title == null)
            {
                Snackbar.Add("Category Title is Null", Severity.Error);
            }
            else
            {

                CheckCategory = await AdminService.CheckCategory(Title, files.Name);

                if (CheckCategory.Count() > 0)
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

                    var response = await Http.PostAsync($"/api/File/PostCategoryImage/{Title}", content);

                    GetCategories = await AdminService.GetCategories();

                    CategoryTitle = null;

                    _isOpenCategory = false;

                    Snackbar.Add("Operation successful", Severity.Success);
                }
            }
        }

        public async Task Delete(int Category_id, string ImageURL)
        {
            bool? result = await DialogService.ShowMessageBox(
            "Warning",
            "Are you sure you want to delete this Category! " +
            "Note all SubCategories and all Products affiliated to this Category will deleted.",
            yesText: "Delete!", cancelText: "Cancel");

            if (result == true)
            {
                var deletecategoryDto = await AdminService.DeleteCategory(Category_id, ImageURL);
                GetCategories = await AdminService.GetCategories();
            }
            StateHasChanged();
        }

    }
}