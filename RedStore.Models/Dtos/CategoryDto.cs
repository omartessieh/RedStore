using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedStore.Models.Dtos
{
    public class CategoryDto
    {
        [Key]
        public int Category_id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
    }
}