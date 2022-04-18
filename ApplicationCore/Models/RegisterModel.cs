using ApplicationCore.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    // data Annotations
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email cannot be empty")]
        [EmailAddress(ErrorMessage = "Email address shoould be in right format")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        // minimum of 8 charcater
        // 1 number, 1 upper case, 1 lower case
        // strong password
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage =
            "Password Should have minimum 8 with at least one upper, lower, number and special character")]
        public string Password { get; set; }

        [Required(ErrorMessage = "First  Name cannot be empty")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name cannot be empty")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        // Mimiumu year and Max Year that a person can enter
        // Custom Validator 
        // Max 1900
        // Min 2002
        [YearValidation(1900)]
        public DateTime DateOfBirth { get; set; }
    }
}