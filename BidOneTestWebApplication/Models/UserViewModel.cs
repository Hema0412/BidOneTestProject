using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BidOneTestWebApplication.Models
{
 /// <summary>
 ///  Model for the User Addition with Data Annotation and Validations
 /// </summary>
    public class UserViewModel
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name"), MaxLength(30),MinLength(3,ErrorMessage ="Please Enter Minimun 3 Characters")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "special characters and numbers are not allowed.")]
        [Display(Name = "User First Name")]

        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name"), MaxLength(30), MinLength(3, ErrorMessage = "Please Enter Minimun 3 Characters")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "special characters and numbers are not allowed.")]
        [Display(Name = "User Last Name")]
        public string LastName { get; set; }
    }
}
