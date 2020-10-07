using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthcareWebApplication.Models
{
    public class EmployeeModel
    {
        [Display(Name = "Employee Id")]
        [Range(1000, 9999)]
        public int EmployeeId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name required")]
        public string LastName { get; set; }

        //[Display(Name = "Gender")]
        //[Required(ErrorMessage = "Gender required")]
        //public string Gender { get; set; }

        //[Display(Name = "Date of birth")]
        //[DataType(DataType.Date)]
        //[Required(ErrorMessage = "Date of birth required")]
        //public string DateOfBirth { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email required")]
        public string EmailAddress { get; set; }

        [Display(Name = "Confirm Email")]
        [DataType(DataType.EmailAddress)]
        [Compare("EmailAddress", ErrorMessage = "The email and confirm email must match.")]
        public string ConfirmEmail { get; set; }

        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 10)]
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirm password must match.")]
        public string ConfirmPassword { get; set; }
    }
}