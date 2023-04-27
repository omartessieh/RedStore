using System.ComponentModel.DataAnnotations;

namespace RedStore.Api.Entities
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }
        public int Product_id { get; set; }
        public string ImageURL { get; set; }
    }
}