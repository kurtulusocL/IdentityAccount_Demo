using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountDemo.Core.DTOs.AdminAuth
{
    public class ResetPassword
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Code { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "Your password should be between 6 and 40 characters.")]
        public string Password { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "Your password should be between 6 and 40 characters.")]
        public string ConfirmPassword { get; set; }
    }
}
