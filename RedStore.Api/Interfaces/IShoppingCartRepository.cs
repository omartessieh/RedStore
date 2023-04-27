using RedStore.Api.Entities;
using RedStore.Models.Dtos;

namespace RedStore.Api.Interfaces
{
    public interface IShoppingCartRepository
    {
        //Add Product To Cart Item
        Task<Cartitem> AddItem(CartitemDto cartitemDto);

        //Delete Item From Cart Item
        Task<Cartitem> DeleteItem(int Cartitem_id);

        //Check Cart Item
        Task<IEnumerable<Cartitem>> CheckCartItems(int Cart_id, int Product_id, int Color_id, int Size_id);

        //Check Cart Item
        bool CheckCartItem(int Cart_id, int Product_id, int Color_id, int Size_id);

        //Get Cart ID
        Task<Cart> GetCartID(int User_id);

        //Get Order Qty
        Task<IEnumerable<OrderDetail>> GetOrderQty(int Product_id);

        //Get All Product Cart Item View
        Task<IEnumerable<CartItemView>> GetAllProduct(int Cart_id);

        //Update Qty
        Task<Cartitem> UpdateQty(int Cartitem_id, CartitemDto cartItemDto);

        //Add Order Item
        Task<OrderDetail> AddOrder(OrderDetailDto orderDetailDto);

        //Get All Order Details   
        Task<IEnumerable<OrderDetailsView>> GetOrderDetails(int User_id);
    }
}