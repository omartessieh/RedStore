using System.ComponentModel.DataAnnotations;

namespace RedStore.Api.Entities
{
    public class Carousel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
    }
}