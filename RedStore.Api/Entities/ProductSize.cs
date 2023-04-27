using System.ComponentModel.DataAnnotations;

namespace RedStore.Api.Entities
{
    public class ProductSize
    {
        [Key]
        public int Size_id { get; set; }
        public int Product_id { get; set; }
        public string Size { get; set; }
    }
}