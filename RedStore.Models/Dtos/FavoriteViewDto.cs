using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedStore.Models.Dtos
{
    public class FavoriteViewDto
    {
        [Key]
        public long Id { get; set; }
        public int User_id { get; set; }
        public int Product_id { get; set; }
        public string CategoryTitle { get; set; }
        public string SubCategoryTitle { get; set; }
        public DateTime Created_at { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
    }
}
