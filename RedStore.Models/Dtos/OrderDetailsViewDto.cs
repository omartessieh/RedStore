using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedStore.Models.Dtos
{
    public class OrderDetailsViewDto
    {
        [Key]
        public long Id { get; set; }
        public int User_id { get; set; }
        public int Cart_id { get; set; }
        public int Product_id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public int Color_id { get; set; }
        public string Color { get; set; }
        public int Size_id { get; set; }
        public string Size { get; set; }
        public int Qty { get; set; }
        public int Total_Price { get; set; }
        public DateTime Created_at { get; set; }
    }
}