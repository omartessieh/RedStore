using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedStore.Models.Dtos
{
    public class FavoriteDto
    {
        [Key]
        public int Id { get; set; }

        public int User_id { get; set; }

        public int Product_id { get; set; }

        public DateTime Created_at { get; set; }
    }
}
