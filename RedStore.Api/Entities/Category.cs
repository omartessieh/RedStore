using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedStore.Api.Entities
{
    public class Category
    {
        [Key]
        public int Category_id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
    }
}