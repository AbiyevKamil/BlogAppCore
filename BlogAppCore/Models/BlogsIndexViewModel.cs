using BlogAppCore.Data.Entities;

namespace BlogAppCore.Models
{
    public class BlogsIndexViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
    }
}
