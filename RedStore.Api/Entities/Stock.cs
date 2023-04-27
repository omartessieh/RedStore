using System.ComponentModel.DataAnnotations;

namespace RedStore.Api.Entities
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        public int Product_id { get; set; }
        public int Qty { get; set; }
    }
}