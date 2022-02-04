using System.ComponentModel.DataAnnotations;

namespace BlogAppCore.Data.Entities
{
    public class Comment
    {
        public long Id { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public DateTime AddedAt { get; set; }

        [Required]
        public string AppUserId { get; set; }
        [Required]
        public long BlogId { get; set; }

        public AppUser AppUser { get; set; }
        public Blog Blog { get; set; }
    }
}
