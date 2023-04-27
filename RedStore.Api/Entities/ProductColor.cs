using System.ComponentModel.DataAnnotations;

namespace RedStore.Api.Entities
{
    public class ProductColor
    {
        [Key]
        public int Color_id { get; set; }
        public int Product_id { get; set; }
        public string Color { get; set; }
    }
}