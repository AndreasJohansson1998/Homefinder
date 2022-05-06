using System.ComponentModel.DataAnnotations;

namespace House_API.ViewModels.Authorization
{
    public class LoginViewModel
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}