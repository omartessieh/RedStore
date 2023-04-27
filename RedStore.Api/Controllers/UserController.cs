using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedStore.Api.Interfaces;
using RedStore.Models.Dtos;

namespace RedStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        //Get User Information
        [HttpGet("{User_id:int}/UserInfo")]
        public async Task<ActionResult<UserDto>> GetUserInfo(int User_id)
        {
            try
            {
                var userInfo = await this.userRepository.GetUserInfo(User_id);

                if (userInfo == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(userInfo);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");

            }
        }

        //Login User
        [HttpGet]
        [Route("{username}/{password}/LoginUser")]
        public async Task<ActionResult<IEnumerable<LoginDto>>> LoginUser(string username, string password)
        {
            try
            {
                var Login = await this.userRepository.LoginUser(username, password);

                if (Login == null)
                {
                    return NoContent();
                }

                var LoginDto = Login.ToList();

                return Ok(LoginDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Registration User
        [HttpPost]
        public async Task<ActionResult<UserDto>> AddUser([FromBody] UserDto userDto)
        {
            try
            {
                this.userRepository.AddUser(userDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Check User Exist
        [HttpGet]
        [Route("{username}/{email}/{phone}/CheckUserExist")]
        public async Task<ActionResult<IEnumerable<UserDto>>> CheckUserExist(string username, string email, string phone)
        {
            try
            {
                var Check = await this.userRepository.CheckUserExist(username, email, phone);

                if (Check == null)
                {
                    return NoContent();
                }

                var CheckDto = Check.ToList();

                return Ok(CheckDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Update User
        [HttpPost("UpdateUser/{User_id:int}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int User_id, UserDto userDto)
        {
            try
            {
                var user = await this.userRepository.UpdateUser(User_id, userDto);
                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Add Cart Id
        [HttpPost("AddCartId")]
        public async Task<ActionResult<CartDto>> AddCartId([FromBody] CartDto cartDto)
        {
            try
            {
                this.userRepository.AddCartId(cartDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Check User Update
        [HttpGet]
        [Route("{username}/{email}/{phone}/{User_id}/CheckUserUpdate")]
        public async Task<ActionResult<IEnumerable<UserDto>>> CheckUserUpdate(string username, string email, string phone, int User_id)
        {
            try
            {
                var Check = await this.userRepository.CheckUserUpdate(username, email, phone, User_id);

                if (Check == null)
                {
                    return NoContent();
                }

                var CheckDto = Check.ToList();

                return Ok(CheckDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Add Contact
        [HttpPost("AddContact")]
        public async Task<ActionResult<ContactDto>> AddContact([FromBody] ContactDto contactDto)
        {
            try
            {
                this.userRepository.AddContact(contactDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}