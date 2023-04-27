using Microsoft.AspNetCore.Components;
using RedStore.Models.Dtos;
using RedStore.Web.Interfaces;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Text.RegularExpressions;

namespace RedStore.Web.Pages
{
    public partial class Account : ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public ILocalStorageService? LocalStorage { get; set; }

        [Inject]
        public AuthenticationStateProvider? AuthStateProvider { get; set; }

        [Inject]
        public NavigationManager? NavManager { get; set; }

        public IEnumerable<UserDto> CheckUserUpdate { get; set; }

        public UserDto userDto = new UserDto();

        public UserDto user = new UserDto();

        public string ErrorMessage { get; set; }

        string UpdateFaild = null;
        string UpdateSuccess = null;

        int User_id;

        protected override async Task OnInitializedAsync()
        {
            UpdateFaild = null;
            UpdateSuccess = null;

            User_id = await LocalStorage.GetItemAsync<int>("id");

            try
            {
                user = await UserService.GetUserInfo(User_id);
                userDto = await UserService.GetUserInfo(User_id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }

        public async Task EditSubmit()
        {

            if (userDto.Username != user.Username || userDto.First_Name != user.First_Name || userDto.Last_Name != user.Last_Name ||
                userDto.Email != user.Email || userDto.Password != user.Password || userDto.Phone_Number != user.Phone_Number ||
                userDto.Country != user.Country || userDto.Governorate != user.Governorate || userDto.City != user.City ||
                userDto.Street != user.Street || userDto.Building != user.Building || userDto.Floor != user.Floor)
            {
                CheckUserUpdate = await UserService.CheckUserUpdate(userDto.Username, userDto.Email, userDto.Phone_Number, User_id);

                if (Regex.IsMatch(userDto.Username, @"[0-9]") || Regex.IsMatch(userDto.First_Name, @"[0-9]") || Regex.IsMatch(userDto.Last_Name, @"[0-9]")
                    || Regex.IsMatch(userDto.Country, @"[0-9]") || Regex.IsMatch(userDto.Governorate, @"[0-9]") || Regex.IsMatch(userDto.City, @"[0-9]")
                    || Regex.IsMatch(userDto.Street, @"[0-9]") || Regex.IsMatch(userDto.Building, @"[0-9]"))
                {
                    UpdateFaild = "Field must contain text only";
                    UpdateSuccess = null;
                }
                else if (CheckUserUpdate.Count() > 0)
                {
                    UpdateFaild = "UserName or Email or Phone Number Already Exists";
                    UpdateSuccess = null;
                }
                else
                {
                    UserService.UpdateUser(User_id, userDto);
                    UpdateSuccess = "Edit Success";
                    UpdateFaild = null;
                }
            }
            else
            {
                UpdateFaild = "Nothing Changed";
                UpdateSuccess = null;
            }


        }

    }
}