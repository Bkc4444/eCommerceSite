using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eCommerceSite.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? Phone { get; set; } // adding the question marks makes this field optional

        public string? Username { get; set; } // adding the question marks makes this field optional
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]//makes this look like an email address input
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Compare(nameof(Email))]//using nameof so that we can use the class name instead of a string
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }

        [Required]
        [StringLength(75, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConformPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
