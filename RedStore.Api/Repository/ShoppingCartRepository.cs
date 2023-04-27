using Microsoft.EntityFrameworkCore;
using RedStore.Api.Data;
using RedStore.Api.Entities;
using RedStore.Api.Interfaces;
using RedStore.Models.Dtos;

namespace RedStore.Api.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ShoppingCartRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        //Add Product To Cart Item
        public async Task<Cartitem> AddItem(CartitemDto cartitemDto)
        {
            if (CheckCartItem(cartitemDto.Cart_id, cartitemDto.Product_id, cartitemDto.Color_id, cartitemDto.Size_id) == false)
            {

                var item = new Cartitem()
                {
                    Cart_id = cartitemDto.Cart_id,
                    Product_id = cartitemDto.Product_id,
                    Color_id = cartitemDto.Color_id,
                    Size_id = cartitemDto.Size_id,
                    Qty = cartitemDto.Qty,
                    Created_at = DateTime.Now,
                };

                if (item != null)
                {
                    var result = await this.applicationDbContext.Cartitems.AddAsync(item);
                    await this.applicationDbContext.SaveChangesAsync();
                    return result.Entity;
                }
            }
            return null;
        }

        //Check Cart Item
        public bool CheckCartItem(int Cart_id, int Product_id, int Color_id, int Size_id)
        {
            return this.applicationDbContext.Cartitems.Where(c => c.Cart_id == Cart_id && c.Product_id == Product_id && c.Color_id == Color_id && c.Size_id == Size_id).Any();
        }

        //Check Cart Item
        public async Task<IEnumerable<Cartitem>> CheckCartItems(int Cart_id, int Product_id, int Color_id, int Size_id)
        {
            var Check = await this.applicationDbContext.Cartitems.Where(i => i.Cart_id == Cart_id && i.Product_id == Product_id && i.Color_id == Color_id && i.Size_id == Size_id).ToListAsync();
            return Check;
        }

        //Get Cart ID
        public async Task<Cart> GetCartID(int User_id)
        {
            var cartid = await applicationDbContext.Carts.Where(i => i.User_id == User_id).FirstAsync();
            return cartid;
        }

        //Get Order Qty
        public async Task<IEnumerable<OrderDetail>> GetOrderQty(int Product_id)
        {
            var Qty = await this.applicationDbContext.OrderDetails.Where(i => i.Product_id == Product_id).ToListAsync();
            return Qty;
        }

        //Get All Product Cart Item View
        public async Task<IEnumerable<CartItemView>> GetAllProduct(int Cart_id)
        {
            var cartitem = await this.applicationDbContext.CartItemViews.Where(i => i.Cart_id == Cart_id).ToListAsync();
            return cartitem;
        }

        //Delete Item From Cart Item
        public async Task<Cartitem> DeleteItem(int Cartitem_id)
        {
            var item = await this.applicationDbContext.Cartitems.FindAsync(Cartitem_id);

            if (item != null)
            {
                this.applicationDbContext.Cartitems.Remove(item);
                await this.applicationDbContext.SaveChangesAsync();
            }

            return item;
        }

        //Update Qty
        public async Task<Cartitem> UpdateQty(int Cartitem_id, CartitemDto cartItemDto)
        {
            var item = await this.applicationDbContext.Cartitems.FindAsync(Cartitem_id);

            if (item != null)
            {
                item.Qty = cartItemDto.Qty;
                await this.applicationDbContext.SaveChangesAsync();
                return item;
            }

            return null;
        }

        //Add Order Item
        public async Task<OrderDetail> AddOrder(OrderDetailDto orderDetailDto)
        {
            var item = new OrderDetail()
            {
                User_id = orderDetailDto.User_id,
                Cart_id = orderDetailDto.Cart_id,
                Product_id = orderDetailDto.Product_id,
                Color_id = orderDetailDto.Color_id,
                Size_id = orderDetailDto.Size_id,
                Qty = orderDetailDto.Qty,
                Total_Price = orderDetailDto.Total_Price,
                Created_at = DateTime.Now,
            };

            if (item != null)
            {
                var result = await this.applicationDbContext.OrderDetails.FromSqlRaw($"exec SP_OrderDetail @User_id='{item.User_id}', @Cart_id='{item.Cart_id}', @Product_id='{item.Product_id}', @Color_id='{item.Color_id}', @Size_id='{item.Size_id}', @Qty='{item.Qty}', @Total_Price='{item.Total_Price}', @Created_at='{item.Created_at}'").ToListAsync();
            }

            return null;
        }

        //Get All Order Details  
        public async Task<IEnumerable<OrderDetailsView>> GetOrderDetails(int User_id)
        {
            var orderDetails = await this.applicationDbContext.OrderDetailsViews.FromSqlRaw($"exec SP_AllOrderDetails @User_id='{User_id}'").ToListAsync();
            return orderDetails;
        }

    }
}