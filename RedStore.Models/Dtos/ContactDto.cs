using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedStore.Models.Dtos
{
    public class ContactDto
    {
        [Key]
        public int Id { get; set; }
        public int User_id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Created_at { get; set; }
    }
}