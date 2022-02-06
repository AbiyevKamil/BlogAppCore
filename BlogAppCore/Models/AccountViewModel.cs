using BlogAppCore.Data.Entities;

namespace BlogAppCore.Models
{
    public class AccountViewModel
    {
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public AppUser User { get; set; }
    }
}
