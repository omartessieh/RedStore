using Microsoft.EntityFrameworkCore;
using RedStore.Api.Data;
using RedStore.Api.Entities;
using RedStore.Api.Interfaces;
using RedStore.Models.Dtos;

namespace RedStore.Api.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        //Get User Information
        public async Task<User> GetUserInfo(int User_id)
        {
            var userInfo = await applicationDbContext.Users.FindAsync(User_id);
            return userInfo;
        }

        //Login User
        public async Task<IEnumerable<User>> LoginUser(string username, string password)
        {
            return await this.applicationDbContext.Users.Where(i => i.Username == username && i.Password == password).ToListAsync();
        }

        //Registration User
        public async Task<User> AddUser(UserDto userDto)
        {
            if (CheckUser(userDto.Username, userDto.Email, userDto.Phone_Number) == false)
            {
                var user = new User()
                {
                    Username = userDto.Username,
                    Password = userDto.Password,
                    First_Name = userDto.First_Name,
                    Last_Name = userDto.Last_Name,
                    Email = userDto.Email,
                    Phone_Number = userDto.Phone_Number,
                    Country = userDto.Country,
                    Governorate = userDto.Governorate,
                    City = userDto.City,
                    Street = userDto.Street,
                    Building = userDto.Building,
                    Floor = userDto.Floor,
                    Created_at = DateTime.Now,
                };

                var result = await this.applicationDbContext.Users.AddAsync(user);
                await this.applicationDbContext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        //Update User
        public async Task<User> UpdateUser(int User_id, UserDto userDto)
        {
            var user = await this.applicationDbContext.Users.FindAsync(User_id);

            if (user != null)
            {
                user.Username = userDto.Username;
                user.Password = userDto.Password;
                user.First_Name = userDto.First_Name;
                user.Last_Name = userDto.Last_Name;
                user.Email = userDto.Email;
                user.Phone_Number = userDto.Phone_Number;
                user.Country = userDto.Country;
                user.Governorate = userDto.Governorate;
                user.City = userDto.City;
                user.Street = userDto.Street;
                user.Building = userDto.Building;
                user.Floor = userDto.Floor;
                user.Created_at = user.Created_at;
                await this.applicationDbContext.SaveChangesAsync();
                return user;
            }

            return null;
        }

        //Check User Exist
        public async Task<IEnumerable<User>> CheckUserExist(string username, string email, string phone)
        {
            return await this.applicationDbContext.Users.Where(u => u.Username == username || u.Email == email || u.Phone_Number == phone).ToListAsync();
        }

        //Bool Check User Exist
        public bool CheckUser(string username, string email, string phone)
        {
            return this.applicationDbContext.Users.Where(u => u.Username == username || u.Email == email || u.Phone_Number == phone).Any();
        }

        //Add Cart Id
        public async Task<Cart> AddCartId(CartDto cartDto)
        {
            if (CheckCartId(cartDto.User_id) == false)
            {
                var Cart = new Cart()
                {
                    User_id = cartDto.User_id,
                    Created_at = DateTime.Now,
                };

                var result = await this.applicationDbContext.Carts.AddAsync(Cart);
                await this.applicationDbContext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        //Bool Check Cart Id
        public bool CheckCartId(int User_id)
        {
            return this.applicationDbContext.Carts.Where(u => u.User_id == User_id).Any();
        }

        //Check User Update
        public async Task<IEnumerable<User>> CheckUserUpdate(string username, string email, string phone, int User_id)
        {
            return await this.applicationDbContext.Users.Where(u => (u.Username == username || u.Email == email || u.Phone_Number == phone) && u.User_id != User_id).ToListAsync();
        }

        //Add Contact
        public async Task<Contact> AddContact(ContactDto contactDto)
        {

            var contact = new Contact()
            {
                User_id = contactDto.User_id,
                Username = contactDto.Username,
                Email = contactDto.Email,
                Subject = contactDto.Subject,
                Message = contactDto.Message,
                Created_at = DateTime.Now,
            };

            var result = await this.applicationDbContext.Contacts.AddAsync(contact);
            await this.applicationDbContext.SaveChangesAsync();
            return result.Entity;
        }

    }
}