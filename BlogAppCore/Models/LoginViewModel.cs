using System.ComponentModel.DataAnnotations;

namespace BlogAppCore.Models
{
    public class LoginViewModel
    {
        [Required, DataType(DataType.EmailAddress),
         EmailAddress(ErrorMessage = "Email address is not valid.")]
        public string Email { get; set; } = string.Empty;
        [Required, DataType(DataType.Password), MinLength(6)]
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; }
    }
}
