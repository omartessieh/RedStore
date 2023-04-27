using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedStore.Models.Dtos
{
    public class CartDto
    {
        [Key]
        public int Cart_id { get; set; }
        public int User_id { get; set; }
        public DateTime Created_at { get; set; }
    }
}