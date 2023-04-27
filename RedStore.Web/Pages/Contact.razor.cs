using Microsoft.AspNetCore.Components;
using RedStore.Models.Dtos;
using RedStore.Web.Interfaces;
using Microsoft.JSInterop;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Mail;
using System.Net;
using Yccnl.Gmailer;
using System.Text;

namespace RedStore.Web.Pages
{
    public partial class Contact : ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public IWebsiteService WebsiteService { get; set; }

        [Inject]
        public ILocalStorageService? LocalStorage { get; set; }

        [Inject]
        public AuthenticationStateProvider? AuthStateProvider { get; set; }

        [Inject]
        public NavigationManager? NavManager { get; set; }

        public InformationDto Information { get; set; }

        private ContactDto contactDto = new ContactDto();

        public int User_id = 0;

        public string Email;

        public string Username;

        protected override async Task OnInitializedAsync()
        {
            
            User_id = await LocalStorage.GetItemAsync<int>("id");

            var encodedUsername = await LocalStorage.GetItemAsync<string>("username");
            var encodedEmail = await LocalStorage.GetItemAsync<string>("email");

            if (encodedUsername != null && encodedEmail != null)
            {
                Username = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsername));
                Email = Encoding.UTF8.GetString(Convert.FromBase64String(encodedEmail));
            }


            Information = await WebsiteService.GetInformation();
        }

        public async Task ContactSubmit()
        {
            contactDto.User_id = User_id;
            contactDto.Username = Username;
            contactDto.Email = Email;
            UserService.AddContact(contactDto);
            contactDto.Subject = null;
            contactDto.Message = null;
        }

    }
}