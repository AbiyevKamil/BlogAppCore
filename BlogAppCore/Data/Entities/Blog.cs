using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAppCore.Data.Entities
{
    public class Blog
    {
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime PublishedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        [NotMapped]
        public IFormFile Banner { get; set; }


        // Foreign keys
        public string AppUserId { get; set; }
        public long CategoryId { get; set; }


        public virtual AppUser AppUser { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual Category Category { get; set; }
    }
}
