using Microsoft.AspNetCore.Components;
using RedStore.Models.Dtos;
using RedStore.Web.Interfaces;
using Microsoft.JSInterop;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Text;

namespace RedStore.Web.Pages
{
    public partial class Login : ComponentBase
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

        private CartDto cartDto = new CartDto();

        private LoginDto LoginDto = new LoginDto();

        string LogFaild = null;

        protected override async Task OnInitializedAsync()
        {
            LogFaild = null;
        }

        public async Task LoginSubmit()
        {

            if (LoginDto.Username != null && LoginDto.Password != null)
            {
                LoginUser = await UserService.LoginUser(LoginDto.Username, LoginDto.Password);

                if (LoginUser.Count() > 0)
                {

                    LogFaild = null;

                    foreach (var LoginUser in LoginUser)
                    {
                        if (LoginUser.User_id != null)
                        {
                            //Add Cart Id
                            UserService.AddCartId(new CartDto { User_id = LoginUser.User_id });
                        }

                        string encodedUsername = Convert.ToBase64String(Encoding.UTF8.GetBytes(LoginUser.Username));
                        string encodedEmail = Convert.ToBase64String(Encoding.UTF8.GetBytes(LoginUser.Email));

                        await LocalStorage.SetItemAsync<string>("username", encodedUsername);
                        await LocalStorage.SetItemAsync<int>("id", LoginUser.User_id);
                        await LocalStorage.SetItemAsync<string>("email", encodedEmail);

                        await AuthStateProvider.GetAuthenticationStateAsync();

                        NavManager.NavigateTo("");
                    }
                }
                else
                {
                    LogFaild = "UserName or Password Incorrect";
                }
            }
        }

    }
}