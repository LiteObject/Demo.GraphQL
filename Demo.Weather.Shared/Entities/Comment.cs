namespace Demo.Weather.Shared.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}