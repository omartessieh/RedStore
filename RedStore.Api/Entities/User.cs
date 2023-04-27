using System.ComponentModel.DataAnnotations;

namespace RedStore.Api.Entities
{
    public class User
    {
        [Key]
        public int User_id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public string Country { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public int Floor { get; set; }
        public DateTime Created_at { get; set; }
    }
}