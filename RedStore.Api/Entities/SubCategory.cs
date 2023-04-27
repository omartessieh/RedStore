using System.ComponentModel.DataAnnotations;

namespace RedStore.Api.Entities
{
    public class SubCategory
    {
        [Key]
        public int SubCategory_id { get; set; }
        public string Title { get; set; }
        public int Category_id { get; set; }
    }
}