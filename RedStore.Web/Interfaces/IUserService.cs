using RedStore.Models.Dtos;

namespace RedStore.Web.Interfaces
{
    public interface IUserService
    {
        //Get User Information
        Task<UserDto> GetUserInfo(int User_id);

        //Login User
        Task<List<LoginDto>> LoginUser(string username, string password);

        //Registration User
        Task<UserDto> AddUser(UserDto userDto);

        //Update User
        Task<UserDto> UpdateUser(int User_id, UserDto userDto);

        //Check User Exist
        Task<IEnumerable<UserDto>> CheckUserExist(string username, string email, string phone);

        //Check User Update
        Task<IEnumerable<UserDto>> CheckUserUpdate(string username, string email, string phone, int User_id);

        //Add Cart Id
        Task<CartDto> AddCartId(CartDto cartDto);

        //Add Contact
        Task<ContactDto> AddContact(ContactDto contactDto);
    }
}