using Microsoft.AspNetCore.Components;
using RedStore.Admin.Interfaces;
using RedStore.Models.Dtos;
using MudBlazor;

namespace RedStore.Admin.Pages.User
{
    public partial class User : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject] 
        private IDialogService DialogService { get; set; }

        [Inject]
        public IAdminService AdminService { get; set; }

        public IEnumerable<UserDto> GetUsers { get; set; }

        bool fixed_header = true;

        bool fixed_footer = false;

        private string _searchString;

        private bool _sortNameByLength;

        protected override async Task OnInitializedAsync()
        {
            GetUsers = await AdminService.GetUsers();
        }

        private Func<UserDto, object> _sortBy => x =>
        {
            if (_sortNameByLength)
                return x.Username.Length;
            else
                return x.Username;
        };

        private Func<UserDto, bool> _quickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            if (x.Username.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.First_Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Last_Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Email.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Phone_Number.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Country.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Governorate.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.City.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Street.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Building.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.Created_at}".Contains(_searchString))
                return true;

            return false;
        };

        protected async Task AddUSer()
        {
            NavigationManager.NavigateTo("/AddUser");
        }

        public async Task Delete(int User_id)
        {
            bool? result = await DialogService.ShowMessageBox(
            "Warning",
            "Are you sure you want to delete this user!",
            yesText: "Delete!", cancelText: "Cancel");

            if (result == true)
            {
                var deleteUser = await AdminService.DeleteUser(User_id);
                GetUsers = await AdminService.GetUsers();
            }
            StateHasChanged();
        }

        public async Task Edit(int User_id)
        {
            NavigationManager.NavigateTo($"EditUser/{User_id}");
        }
    }
}