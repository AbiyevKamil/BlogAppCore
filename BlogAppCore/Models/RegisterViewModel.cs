using System.ComponentModel.DataAnnotations;

namespace BlogAppCore.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required, 
         RegularExpression(@"^\w+\s\w+\s?$", ErrorMessage = "At least two words needed.")]
        public string FullName { get; set; }
        [Required, DataType(DataType.EmailAddress),
         EmailAddress(ErrorMessage = "Email address is not valid.")]
        public string Email { get; set; }
        [Required, DataType(DataType.Password), MinLength(6)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), MinLength(6),
         Compare(nameof(Password),
             ErrorMessage = "Passwords don't match.")]
        public string PasswordAgain { get; set; }
    }
}
