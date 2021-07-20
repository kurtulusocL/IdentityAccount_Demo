using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountDemo.Core.DTOs.AdminAuth
{
    public class Register
    {
        [Required]
        [Display(Name = "Ad Soyad")]
        public string NameSurname { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Your Birthdate")]
        public DateTime Birthdate { get; set; }

        [Required]
        [Display(Name = "Respond Title")]
        public string RespondTitle { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Your Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Your City")]
        public string City { get; set; }

        [Display(Name = "Your Province")]
        public string Province { get; set; }

        [Required]
        [Display(Name = "Your Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Your E-Mail Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Your Password")]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "Your password should be between 6 and 40 characters.")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Your Password")]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "Your password should be between 6 and 40 characters.")]
        [Compare("Password", ErrorMessage = "Passwords are not same. Please check them.")]
        public string ConfirmPassword { get; set; }
        public DateTime CreatedDate { get; set; }
        public Register()
        {
            CreatedDate = DateTime.Now.ToLocalTime();
        }
    }
}
