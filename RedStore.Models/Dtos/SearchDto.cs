using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedStore.Models.Dtos
{
    public class SearchDto
    {
        [Key]
        public long MId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }
}
