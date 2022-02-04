namespace BlogAppCore.Data.Entities
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<Blog> Blogs { get; set; }
    }
}
