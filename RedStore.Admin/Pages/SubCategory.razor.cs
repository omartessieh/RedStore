using Microsoft.AspNetCore.Components;
using MudBlazor;
using RedStore.Admin.Interfaces;
using RedStore.Models.Dtos;
using System.Net.Http.Json;

namespace RedStore.Admin.Pages
{
    public partial class SubCategory : ComponentBase
    {
        [Inject] 
        HttpClient? Http { get; set; }

        [Inject]
        public IAdminService AdminService { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        public IEnumerable<CategoryDto> GetCategories { get; set; }

        public IEnumerable<SubCategoryViewDto> GetSubCategoriesView { get; set; }

        public IEnumerable<SubCategoryDto> CheckSubCategory { get; set; }

        private SubCategoryDto subCategoryDto = new SubCategoryDto();

        bool fixed_header = true;

        bool fixed_footer = false;

        private string _searchString;

        private bool _sortNameByLength;

        public bool _isOpenSubCategory = false;

        public int SelectedCategoryId;

        public string SubCategoryTitle { get; set; }

        protected override async Task OnInitializedAsync()
        {
            GetCategories = await AdminService.GetCategories();
            GetSubCategoriesView = await AdminService.GetSubCategoriesView();
        }

        private Func<SubCategoryViewDto, object> _sortBy => x =>
        {
            if (_sortNameByLength)
                return x.Title.Length;
            else
                return x.Title;
        };

        private Func<SubCategoryViewDto, bool> _quickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            if (x.Title.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.CategoryTitle.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };

        private void OpenAddSubCategory()
        {
            if (_isOpenSubCategory)
            {
                _isOpenSubCategory = false;
                SubCategoryTitle = null;
                SelectedCategoryId = 0;
            }
            else
            {
                _isOpenSubCategory = true;
                SubCategoryTitle = null;
                SelectedCategoryId = 0;
            }
        }

        public async Task SubmitSubCategory()
        {
            var Title = SubCategoryTitle;
            var Category_id = SelectedCategoryId;

            if (Title == null)
            {
                Snackbar.Add("SubCategory Title is Null", Severity.Error);
            }
            else if (Category_id == 0)
            {
                Snackbar.Add("Please Select Category Title", Severity.Error);
            }
            else
            {
                CheckSubCategory = await AdminService.CheckSubCategory(Title, Category_id);

                if (CheckSubCategory.Count() > 0)
                {
                    Snackbar.Add("Already Exists", Severity.Error);
                }
                else
                {
                    var subCategoryDto = new SubCategoryDto()
                    {
                        Title = Title,
                        Category_id = Category_id,
                    };

                    var response = await Http.PostAsJsonAsync<SubCategoryDto>("api/Admin/AddSubCategory", subCategoryDto);

                    GetSubCategoriesView = await AdminService.GetSubCategoriesView();

                    Title = null;
                    Category_id = 0;

                    _isOpenSubCategory = false;

                    Snackbar.Add("Operation successful", Severity.Success);
                }
            }
        }

        public async Task Delete(int SubCategory_id)
        {
            bool? result = await DialogService.ShowMessageBox(
            "Warning",
            "Are you sure you want to delete this SubCategory! " +
            "Note all Products affiliated to this SubCategory will deleted.",
            yesText: "Delete!", cancelText: "Cancel");

            if (result == true)
            {
                var deletesubcategoryDto = await AdminService.DeleteSubCategory(SubCategory_id);
                GetSubCategoriesView = await AdminService.GetSubCategoriesView();
            }
            StateHasChanged();
        }

    }
}