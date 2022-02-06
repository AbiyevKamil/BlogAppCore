using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BlogAppCore.Data.Entities
{
    public class Blog
    {
        public long Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public DateTime PublishedAt { get; set; }
        [AllowNull]
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageName { get; set; }


        // Foreign keys
        public string AppUserId { get; set; }
        public long CategoryId { get; set; }


        public virtual AppUser AppUser { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual Category Category { get; set; }
    }
}
