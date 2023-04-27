using Microsoft.AspNetCore.Components;
using MudBlazor;
using RedStore.Admin.Interfaces;
using RedStore.Models.Dtos;

namespace RedStore.Admin.Pages.Product
{
    public partial class ProductInfo : ComponentBase
    {
        [Parameter]
        public int Product_id { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Inject]
        public IAdminService AdminService { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IEnumerable<ProductColorDto> GetProductColors { get; set; }

        public IEnumerable<ProductImageDto> GetProductImages { get; set; }

        public IEnumerable<ProductPriceDto> GetProductPrice { get; set; }

        public IEnumerable<ProductSizeDto> GetProductSize { get; set; }

        public IEnumerable<StockDto> GetStock { get; set; }

        public IEnumerable<DiscountDto> GetDiscount { get; set; }

        protected override async Task OnInitializedAsync()
        {
            GetProductColors = await AdminService.GetColorsProduct(Product_id);
            GetProductImages = await AdminService.GetImagesProduct(Product_id);
            GetProductPrice = await AdminService.GetPriceProduct(Product_id);
            GetProductSize = await AdminService.GetSizeProduct(Product_id);
            GetStock = await AdminService.GetStockProduct(Product_id);
            GetDiscount = await AdminService.GetDiscountProduct(Product_id);
        }

    }
}