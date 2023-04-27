using System.ComponentModel.DataAnnotations;

namespace RedStore.Api.Entities
{
    public class ProductPrice
    {
        [Key]
        public int Id { get; set; }
        public int Product_id { get; set; }
        public int Price { get; set; }
    }
}