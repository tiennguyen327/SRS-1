using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SRS.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100, ErrorMessage ="The {0} must be at least {2} and at max {1} characters long.", MinimumLength =6)]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage ="The password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }
        [Required]
        public string SelectedRoleId { get; set; }
    }
}
