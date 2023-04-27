using System.ComponentModel.DataAnnotations;

namespace RedStore.Api.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public int User_id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Created_at { get; set; }
    }
}