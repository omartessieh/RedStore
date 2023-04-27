using System.ComponentModel.DataAnnotations;

namespace RedStore.Api.Entities
{
    public class Information
    {
        [Key]
        public int Id { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Google { get; set; }
        public string Instagram { get; set; }
        public string Youtube { get; set; }
        public string Map { get; set; }
    }
}