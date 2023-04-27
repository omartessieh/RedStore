using Microsoft.AspNetCore.Components;
using RedStore.Models.Dtos;
using RedStore.Web.Interfaces;
using Microsoft.JSInterop;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Text.RegularExpressions;

namespace RedStore.Web.Pages
{
    public partial class Registration : ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public ILocalStorageService? LocalStorage { get; set; }

        [Inject]
        public AuthenticationStateProvider? AuthStateProvider { get; set; }

        [Inject]
        public NavigationManager? NavManager { get; set; }

        public IEnumerable<UserDto> CheckUserExist { get; set; }
        public IEnumerable<LoginDto> LoginUser { get; set; }

        private UserDto userDto = new UserDto();

        string RegFaild = null;

        protected override async Task OnInitializedAsync()
        {
            RegFaild = null;
        }

        public async Task RegistrationSubmit()
        {

            if (userDto.Username != null && userDto.First_Name != null && userDto.Last_Name != null && userDto.Password != null &&
                userDto.Email != null && userDto.Phone_Number != null && userDto.Country != null && userDto.Governorate != null &&
                userDto.City != null && userDto.Street != null && userDto.Building != null && userDto.Floor != null)
            {
                CheckUserExist = await UserService.CheckUserExist(userDto.Username, userDto.Email, userDto.Phone_Number);

                if (Regex.IsMatch(userDto.Username, @"[0-9]") || Regex.IsMatch(userDto.First_Name, @"[0-9]") || Regex.IsMatch(userDto.Last_Name, @"[0-9]")
                    || Regex.IsMatch(userDto.Country, @"[0-9]") || Regex.IsMatch(userDto.Governorate, @"[0-9]") || Regex.IsMatch(userDto.City, @"[0-9]")
                    || Regex.IsMatch(userDto.Street, @"[0-9]") || Regex.IsMatch(userDto.Building, @"[0-9]"))
                {
                    RegFaild = "Field must contain text only";
                }
                else if (CheckUserExist.Count() > 0)
                {
                    RegFaild = "UserName or Email or Phone Number Already Exists";
                }
                else
                {

                    UserService.AddUser(userDto);
                    NavManager.NavigateTo("/Login");
                    RegFaild = null;

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
