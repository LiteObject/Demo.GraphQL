namespace Demo.Shared.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Post>? Posts { get; set; }
    }
}