using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedStore.Models.Dtos
{
    public class CarouselDto
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
    }
}