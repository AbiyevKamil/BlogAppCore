using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Build.Framework;

namespace BlogAppCore.Models
{
    public class UpdateBlogViewModel
    {
        public long Id { get; set; }
        [Required]
        public string Title { get; set; } 
        [Required]
        public string Content { get; set; }
        public IFormFile? Banner { get; set; }

        // Foreign keys
        [Required]
        public long CategoryId { get; set; }
    }
}
