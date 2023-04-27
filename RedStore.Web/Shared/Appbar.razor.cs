using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace RedStore.Web.Shared
{
    public partial class Appbar
    {
        [Inject]
        public ILocalStorageService? LocalStorage { get; set; }

    }
}