using Microsoft.AspNetCore.Components;
using RedStore.Models.Dtos;
using RedStore.Web.Interfaces;
using Microsoft.JSInterop;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Mail;

namespace RedStore.Web.Shared
{
    public partial class Footer : ComponentBase
    {
        [Inject]
        public IWebsiteService WebsiteService { get; set; }

        public InformationDto Information { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Information = await WebsiteService.GetInformation();
        }

    }
}
