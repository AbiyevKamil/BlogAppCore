namespace BlogAppCore.Data.Entities
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}
