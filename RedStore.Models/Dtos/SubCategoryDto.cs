using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedStore.Models.Dtos
{
    public class SubCategoryDto
    {
        [Key]
        public int SubCategory_id { get; set; }
        public string Title { get; set; }
        public int Category_id { get; set; }
    }
}