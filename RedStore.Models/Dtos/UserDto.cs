using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedStore.Models.Dtos
{
    public class UserDto
    {
        [Key]
        public int User_id { get; set; }

        [Required(ErrorMessage = "Username is Required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Enter Valid UserName.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [MinLength(6, ErrorMessage = "The Password field must be a minimum of 6 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Enter Valid First Name.")]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Enter Valid Last Name.")]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Enter valid Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Enter Valid Phone Number.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone_Number { get; set; }

        [Required(ErrorMessage = "Country is Required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Enter Valid Country.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Governorate is Required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Enter Valid Governorate.")]
        public string Governorate { get; set; }

        [Required(ErrorMessage = "City is Required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Enter Valid City.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Street is Required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Enter Valid Street.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Building is Required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Enter Valid Building.")]
        public string Building { get; set; }

        [Required(ErrorMessage = "Floor is Required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Enter Valid Floor.")]
        public int Floor { get; set; }

        public DateTime Created_at { get; set; }
    }
}