using System.ComponentModel.DataAnnotations;

namespace RedStore.Api.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Product_id { get; set; }
        public int Rating { get; set; }
        public string Message { get; set; }
        public DateTime Created_at { get; set; }
    }
}