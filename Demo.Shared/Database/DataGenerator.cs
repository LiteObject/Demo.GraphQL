using Demo.Shared.Database;
using Demo.Shared.Entities;

namespace Demo.Weather.GraphQL
{
    public static class DataGenerator
    {
        public static void SeedData(BlogDbContext context)
        {
            List<Author> authors = new()
            {
                new Author { Id = 1, Name = "John Doe" },
                new Author { Id = 2, Name = "Jane Smith" },
            };

            // Add entities without relationships
            context.Authors.AddRange(authors);
            context.SaveChanges();

            Author auth1 = context.Authors.Find(1);
            Author auth2 = context.Authors.Find(2);

            List<Post> posts = new()
            {
                new Post { Id =1, Title = "First Post (by auth 1)", Content = "This is the content of the first post by auth 1", AuthorId = auth1.Id, Author = auth1 },
                new Post { Id =2, Title = "Second Post (by auth 1)", Content = "This is the content of the second post by auth 1", AuthorId = auth1.Id, Author = auth1 },
                new Post { Id = 3, Title = "First Post (by auth 2)", Content = "This is the content of the first post by auth 2", AuthorId = auth2.Id, Author = auth2},
            };

            // Add posts with relationships
            context.Posts.AddRange(posts);
            context.SaveChanges();

            Post post1 = context.Posts.Find(1);
            Post post2 = context.Posts.Find(2);
            Post post3 = context.Posts.Find(3);

            List<Comment> comments = new()
            {
                new Comment { Text = "Great post!", PostId = post1.Id, Post = post1 },
                new Comment { Text = "Wow, Great post!!!!!!!!!!!!", PostId = post1.Id, Post = post1 },
                new Comment { Text = "I enjoyed reading this", PostId = post2.Id, Post = post2 },
                new Comment { Text = "Nice work!", PostId = post3.Id, Post = post3 },
            };

            // Add comments with relationships
            context.Comments.AddRange(comments);
            context.SaveChanges();
        }
    }
}