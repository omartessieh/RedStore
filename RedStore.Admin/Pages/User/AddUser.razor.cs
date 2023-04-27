using Microsoft.AspNetCore.Components;
using RedStore.Admin.Interfaces;
using RedStore.Models.Dtos;
using System.Text.RegularExpressions;
using MudBlazor;

namespace RedStore.Admin.Pages.User
{
    public partial class AddUser : ComponentBase
    {
        [Inject]
        HttpClient? Http { get; set; }

        [Inject]
        public NavigationManager? NavManager { get; set; }

        [Inject]
        public IAdminService AdminService { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        public IEnumerable<UserDto>? CheckUserExist { get; set; }

        private UserDto userDto = new UserDto();

        protected override async Task OnInitializedAsync()
        {
        }

        public async Task RegistrationSubmit()
        {
            if (userDto.Username != null && userDto.First_Name != null && userDto.Last_Name != null && userDto.Password != null &&
                userDto.Email != null && userDto.Phone_Number != null && userDto.Country != null && userDto.Governorate != null &&
                userDto.City != null && userDto.Street != null && userDto.Building != null && userDto.Floor != null)
            {
                CheckUserExist = await AdminService.CheckUserExist(userDto.Username, userDto.Email, userDto.Phone_Number);

                if (Regex.IsMatch(userDto.Username, @"[0-9]") || Regex.IsMatch(userDto.First_Name, @"[0-9]") || Regex.IsMatch(userDto.Last_Name, @"[0-9]")
                    || Regex.IsMatch(userDto.Country, @"[0-9]") || Regex.IsMatch(userDto.Governorate, @"[0-9]") || Regex.IsMatch(userDto.City, @"[0-9]")
                    || Regex.IsMatch(userDto.Street, @"[0-9]") || Regex.IsMatch(userDto.Building, @"[0-9]"))
                {
                    Snackbar.Add("Field must contain text only", Severity.Error);
                }
                else if (CheckUserExist.Count() > 0)
                {
                    Snackbar.Add("UserName or Email or Phone Number Already Exists", Severity.Error);
                }
                else
                {

                    AdminService.AddUser(userDto);

                    Snackbar.Add("Success", Severity.Success);

                    userDto.Username = null;
                    userDto.First_Name = null;
                    userDto.Last_Name = null;
                    userDto.Password = null;
                    userDto.Email = null;
                    userDto.Phone_Number = null;
                    userDto.Country = null;
                    userDto.Governorate = null;
                    userDto.City = null;
                    userDto.Street = null;
                    userDto.Building = null;
                    userDto.Floor = 0;
                }
            }
        }

    }
}