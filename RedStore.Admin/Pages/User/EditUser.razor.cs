using Microsoft.AspNetCore.Components;
using RedStore.Admin.Interfaces;
using RedStore.Models.Dtos;
using System.Text.RegularExpressions;
using MudBlazor;

namespace RedStore.Admin.Pages.User
{
    public partial class EditUser : ComponentBase
    {
        [Parameter]
        public int User_id { get; set; }

        [Inject]
        public IAdminService AdminService { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        public IEnumerable<UserDto> CheckUserUpdate { get; set; }

        public UserDto userDto = new UserDto();

        public UserDto user = new UserDto();

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                user = await AdminService.GetUserInfo(User_id);
                userDto = await AdminService.GetUserInfo(User_id);
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
                CheckUserUpdate = await AdminService.CheckUserUpdate(userDto.Username, userDto.Email, userDto.Phone_Number, User_id);

                if (Regex.IsMatch(userDto.Username, @"[0-9]") || Regex.IsMatch(userDto.First_Name, @"[0-9]") || Regex.IsMatch(userDto.Last_Name, @"[0-9]")
                    || Regex.IsMatch(userDto.Country, @"[0-9]") || Regex.IsMatch(userDto.Governorate, @"[0-9]") || Regex.IsMatch(userDto.City, @"[0-9]")
                    || Regex.IsMatch(userDto.Street, @"[0-9]") || Regex.IsMatch(userDto.Building, @"[0-9]"))
                {
                    Snackbar.Add("Field must contain text only", Severity.Error);
                }
                else if (CheckUserUpdate.Count() > 0)
                {
                    Snackbar.Add("UserName or Email or Phone Number Already Exists", Severity.Error);
                }
                else
                {
                    AdminService.UpdateUser(User_id, userDto);
                    Snackbar.Add("Edit Success", Severity.Success);
                }
            }
            else
            {
                Snackbar.Add("Nothing Changed", Severity.Error);
            }
        }

    }
}