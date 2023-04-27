using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedStore.Models.Dtos
{
    public class LoginDto
    {

        [Key]
        public int User_id { get; set; }

        [Required(ErrorMessage = "UserName is Required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Enter Valid UserName")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [MinLength(6, ErrorMessage = "The Password field must be a minimum of 6 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Enter valid Email.")]
        public string Email { get; set; }
    }
}