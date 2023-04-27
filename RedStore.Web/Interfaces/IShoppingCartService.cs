using RedStore.Models.Dtos;

namespace RedStore.Web.Interfaces
{
    public interface IShoppingCartService
    {
        //Add Product To Cart Item
        Task<CartitemDto> AddItem(CartitemDto cartitemDto);

        //Check Cart Item
        Task<IEnumerable<CartitemDto>> CheckCartItems(int Cart_id, int Product_id, int Color_id, int Size_id);

        //Delete Item From Cart Item
        Task<CartitemDto> DeleteItem(int Cartitem_id);

        //Get Cart ID
        Task<CartDto> GetCartID(int User_id);

        //Get Order Qty
        Task<IEnumerable<OrderDetailDto>> GetOrderQty(int Product_id);

        //Get All Product Cart Item View
        Task<IEnumerable<CartItemViewDto>> GetAllProduct(int Cart_id);

        //Update Qty
        Task<CartitemDto> UpdateQty(CartitemDto cartItemDto);

        //Add Order Item
        Task<OrderDetailDto> AddOrder(OrderDetailDto orderDetailDto);

        //Get All Order Details   
        Task<IEnumerable<OrderDetailsViewDto>> GetOrderDetails(int User_id);
    }
}