using System.ComponentModel.DataAnnotations;

namespace Home_Program.Model.User
{
    public record LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
