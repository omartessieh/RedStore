using System.ComponentModel.DataAnnotations;

namespace RedStore.Api.Entities
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }
        public int Product_id { get; set; }
        public int Discount_Percent { get; set; }
    }
}