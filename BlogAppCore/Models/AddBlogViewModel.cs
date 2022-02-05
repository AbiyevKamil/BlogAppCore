using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Build.Framework;

namespace BlogAppCore.Models
{
    public class AddBlogViewModel
    {
        [Required]
        public string Title { get; set; } 
        [Required]
        public string Content { get; set; }
        [Required]
        //[NotMapped]
        //public IFormFile Banner { get; set; }


        // Foreign keys
        public long CategoryId { get; set; }
    }
}
