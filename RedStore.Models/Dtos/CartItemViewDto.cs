using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedStore.Models.Dtos
{
    public class CartItemViewDto
    {
        [Key]
        public long Id { get; set; }
        public int user_id { get; set; }
        public int Cart_id { get; set; }
        public int Cartitem_id { get; set; }
        public int Product_id { get; set; }
        public int Color_id { get; set; }
        public int Size_id { get; set; }
        public int PricePerUnit { get; set; }
        public int Discount_Percent { get; set; }
        public int PriceAfterDiscount { get; set; }
        public int OrderPrice { get; set; }
        public int OrderQty { get; set; }
        public int StockQty { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string ProductTitle { get; set; }
        public string CategoryTitle { get; set; }
        public string SubCategoryTitle { get; set; }
        public string ProductImage { get; set; }
    }
}