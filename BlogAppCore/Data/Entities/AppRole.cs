using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BlogAppCore.Data.Entities
{
    public class AppRole : IdentityRole
    {
        [Required]
        public string Description { get; set; }

    }
}
