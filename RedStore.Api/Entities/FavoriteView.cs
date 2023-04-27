using System.ComponentModel.DataAnnotations;

namespace RedStore.Api.Entities
{
    public class FavoriteView
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
