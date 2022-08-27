using System.ComponentModel.DataAnnotations;

namespace eCommerceSite.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Username { get; set; }
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
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        public string ConformPassword { get; set; }
    }
}
