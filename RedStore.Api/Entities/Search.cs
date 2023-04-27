using System.ComponentModel.DataAnnotations;

namespace RedStore.Api.Entities
{
    public class Search
    {
        [Key]
        public long MId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

    }
}
