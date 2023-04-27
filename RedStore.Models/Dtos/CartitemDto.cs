using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedStore.Models.Dtos
{
    public class CartitemDto
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