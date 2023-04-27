using System.ComponentModel.DataAnnotations;

namespace RedStore.Api.Entities
{
    public class Cart
    {
        [Key]
        public int Cart_id { get; set; }
        public int User_id { get; set; }
        public DateTime Created_at { get; set; }
    }
}