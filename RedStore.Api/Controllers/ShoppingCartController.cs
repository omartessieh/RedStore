using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedStore.Api.Interfaces;
using RedStore.Models.Dtos;

namespace RedStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IProductRepository productRepository;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
        }

        //Add Product To Cart Item
        [HttpPost]
        public async Task<ActionResult<CartitemDto>> PostItem([FromBody] CartitemDto cartitemDto)
        {
            try
            {
                var newCartItem = await this.shoppingCartRepository.AddItem(cartitemDto);

                if (newCartItem == null)
                {
                    return NoContent();
                }

                var cart = new CartitemDto
                {
                    Cart_id = cartitemDto.Cart_id,
                    Product_id = cartitemDto.Product_id,
                    Color_id = cartitemDto.Color_id,
                    Size_id = cartitemDto.Size_id,
                    Qty = cartitemDto.Qty,
                };

                var newCartItemDto = cart;

                return Ok(newCartItemDto);
                //return CreatedAtAction(nameof(cartitemDto), new { id = newCartItemDto.Cartitem_id }, newCartItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Check Cart Item
        [HttpGet]
        [Route("{Cart_id}/{Product_id}/{Color_id}/{Size_id}/CheckCartItems")]
        public async Task<ActionResult<IEnumerable<CartitemDto>>> CheckCartItems(int Cart_id, int Product_id, int Color_id, int Size_id)
        {
            try
            {
                var Check = await this.shoppingCartRepository.CheckCartItems(Cart_id, Product_id, Color_id, Size_id);

                if (Check == null)
                {
                    return NoContent();
                }

                var CheckDto = Check.ToList();

                return Ok(Check);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Get Cart ID
        [HttpGet("{User_id:int}/GetCartID")]
        public async Task<ActionResult<CartDto>> GetCartID(int User_id)
        {
            try
            {
                var cartid = await this.shoppingCartRepository.GetCartID(User_id);

                if (cartid == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(cartid);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");

            }
        }

        //Get Order Qty
        [HttpGet]
        [Route("{Product_id}/GetOrderQty")]
        public async Task<ActionResult<IEnumerable<OrderDetailDto>>> GetOrderQty(int Product_id)
        {
            try
            {
                var Qty = await this.shoppingCartRepository.GetOrderQty(Product_id);

                if (Qty == null)
                {
                    return NoContent();
                }

                var QtyDto = Qty.ToList();

                return Ok(QtyDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Get All Product Cart Item View
        [HttpGet]
        [Route("{Cart_id}/GetAllProduct")]
        public async Task<ActionResult<IEnumerable<CartItemViewDto>>> GetAllProduct(int Cart_id)
        {
            try
            {
                var cartitem = await this.shoppingCartRepository.GetAllProduct(Cart_id);

                if (cartitem == null)
                {
                    return NoContent();
                }

                var cartitemDto = cartitem.ToList();

                return Ok(cartitemDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Delete Item From Cart Item
        [HttpDelete("{Cartitem_id:int}/Delete")]
        public async Task<ActionResult<CartitemDto>> DeleteItem(int Cartitem_id)
        {
            try
            {
                var cartitem = await this.shoppingCartRepository.DeleteItem(Cartitem_id);

                if (cartitem == null)
                {
                    return NotFound();
                }

                var cartitemDto = cartitem;

                return Ok(cartitemDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Update Qty
        [HttpPost("UpdateQty/{Cartitem_id:int}")]
        public async Task<ActionResult<CartitemDto>> UpdateQty(int Cartitem_id, CartitemDto cartItemDto)
        {
            try
            {
                var cartItem = await this.shoppingCartRepository.UpdateQty(Cartitem_id, cartItemDto);
                if (cartItem == null)
                {
                    return NotFound();
                }

                var cartItemUpdateDto = cartItem;

                return Ok(cartItemUpdateDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Add Order Item
        [HttpPost("AddOrder")]
        public async Task<ActionResult<OrderDetailDto>> AddOrder([FromBody] OrderDetailDto orderDetailDto)
        {
            try
            {

                var neworder = await this.shoppingCartRepository.AddOrder(orderDetailDto);

                if (neworder == null)
                {
                    return NoContent();
                }

                var order = new OrderDetailDto
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

                var neworderDto = order;

                return Ok(neworderDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Get All Order Details
        [HttpGet]
        [Route("{User_id}/GetOrderDetails")]
        public async Task<ActionResult<IEnumerable<OrderDetailsViewDto>>> GetOrderDetails(int User_id)
        {
            try
            {
                var orderDetails = await this.shoppingCartRepository.GetOrderDetails(User_id);

                if (orderDetails == null)
                {
                    return NoContent();
                }

                var orderDetailsDto = orderDetails.ToList();

                return Ok(orderDetailsDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}