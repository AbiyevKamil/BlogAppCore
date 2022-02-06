using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BlogAppCore.Data.Entities
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public DateTime RegisteredAt { get; set; }
        public string? ImagePath { get; set; }


        // Foreign keys
        public List<Blog> Blogs { get; set; }
        public List<Comment> Comments { get; set; }


    }
}
