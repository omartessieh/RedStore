using Microsoft.AspNetCore.Components;
using RedStore.Admin.Interfaces;
using RedStore.Models.Dtos;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using MudBlazor;

namespace RedStore.Admin.Pages
{
    public partial class Carousel : ComponentBase
    {
        [Inject] HttpClient? Http { get; set; }
        [Inject] IJSRuntime? JS { get; set; }

        [Inject]
        public IAdminService AdminService { get; set; }

        public IEnumerable<CarouselDto> GetCarousels = new List<CarouselDto>();

        public IEnumerable<CarouselDto> CheckCarousels { get; set; }

        [Inject] 
        private IDialogService DialogService { get; set; }

        bool fixed_header = true;

        bool fixed_footer = false;

        private string _searchString;

        private bool _sortNameByLength;

        public string imageSource;

        public bool _isOpen = false;

        string Carouselslink = "https://localhost:7068/GetCarouselsImages";

        IList<IBrowserFile> files = new List<IBrowserFile>();

        public int maxAllowedFiles = int.MaxValue;

        public long maxFileSize = long.MaxValue;

        public List<string> fileNames = new();

        protected override async Task OnInitializedAsync()
        {
            GetCarousels = await AdminService.GetCarousels();
        }

        private Func<CarouselDto, object> _sortBy => x =>
        {
            if (_sortNameByLength)
                return x.Title.Length;
            else
                return x.Title;
        };

        private Func<CarouselDto, bool> _quickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            if (x.Title.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.ImageURL.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };

        private void OpenImage(string ImageURL)
        {
            if (_isOpen)
            {
                _isOpen = false;
            }
            else
            {
                _isOpen = true;
                imageSource = ImageURL;
            }
        }

        public async Task Delete(int Id, string ImageURL)
        {
            bool? result = await DialogService.ShowMessageBox(
            "Warning",
            "Are you sure you want to delete this Carousel!",
            yesText: "Delete!", cancelText: "Cancel");

            if (result == true)
            {
                var deletecarouselDto = await AdminService.DeleteCarousel(Id, ImageURL);
                GetCarousels = await AdminService.GetCarousels();
            }
            StateHasChanged();
        }

        private async Task UploadFilesAsync(IReadOnlyList<IBrowserFile> files)
        {

            foreach (var file in files)
            {
                var Title = Path.GetFileNameWithoutExtension(file.Name);

                CheckCarousels = await AdminService.CheckCarousel(Title, file.Name);

                this.files.Add(file);

                if (CheckCarousels.Count() > 0)
                {
                    Snackbar.Add(Title + " Already Exists", Severity.Error);
                }
                else
                {
                    using var content = new MultipartFormDataContent();

                    var fileContent = new StreamContent(file.OpenReadStream(maxFileSize));
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                    this.files.Add(file);
                    fileNames.Add(file.Name);

                    content.Add(
                        content: fileContent,
                        name: "\"files\"",
                        fileName: file.Name
                        );

                    var response = await Http.PostAsync("/api/File", content);

                    GetCarousels = await AdminService.GetCarousels();

                    Snackbar.Add(Title + " Added", Severity.Success);
                }

            }
        }

    }
}