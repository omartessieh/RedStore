using System.ComponentModel.DataAnnotations;

namespace RedStore.Api.Entities
{
    public class Cartitem
    {
        [Key]
        public int Cartitem_id { get; set; }
        public int Cart_id { get; set; }
        public int Product_id { get; set; }
        public int Color_id { get; set; }
        public int Size_id { get; set; }
        public int Qty { get; set; }
        public DateTime Created_at { get; set; }
    }
}