using System.ComponentModel.DataAnnotations;

namespace RedStore.Api.Entities
{
    public class Product
    {
        [Key]
        public int Product_id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int SubCategory_id { get; set; }
        public int Category_id { get; set; }
    }
}