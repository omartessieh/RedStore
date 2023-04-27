using System.ComponentModel.DataAnnotations;

namespace RedStore.Api.Entities
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Cart_id { get; set; }
        public int Product_id { get; set; }
        public int Color_id { get; set; }
        public int Size_id { get; set; }
        public int Qty { get; set; }
        public int Total_Price { get; set; }
        public DateTime Created_at { get; set; }
    }
}