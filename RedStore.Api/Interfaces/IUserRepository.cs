using RedStore.Api.Entities;
using RedStore.Models.Dtos;

namespace RedStore.Api.Interfaces
{
    public interface IUserRepository
    {
        //Get User Information
        Task<User> GetUserInfo(int User_id);

        //Login User
        Task<IEnumerable<User>> LoginUser(string username, string password);

        //Registration User
        Task<User> AddUser(UserDto userDto);

        //Update User
        Task<User> UpdateUser(int User_id, UserDto userDto);

        //Check User Exist
        Task<IEnumerable<User>> CheckUserExist(string username, string email, string phone);

        //Check User Update
        Task<IEnumerable<User>> CheckUserUpdate(string username, string email, string phone, int User_id);

        //Bool Check User Exist
        bool CheckUser(string username, string email, string phone);

        //Add Cart Id
        Task<Cart> AddCartId(CartDto cartDto);

        //Bool Check Cart Id
        bool CheckCartId(int User_id);

        //Add Contact
        Task<Contact> AddContact(ContactDto contactDto);
    }
}