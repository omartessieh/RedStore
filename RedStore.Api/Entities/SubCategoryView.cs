using System.ComponentModel.DataAnnotations;

namespace RedStore.Api.Entities
{
    public class SubCategoryView
    {
        [Key]
        public long Id { get; set; }
        public int SubCategory_id { get; set; }
        public int Category_id { get; set; }
        public string Title { get; set; }
        public string CategoryTitle { get; set; }
        public string ImageURL { get; set; }
    }
}