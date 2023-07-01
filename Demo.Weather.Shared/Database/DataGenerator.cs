using Demo.Weather.Shared.Database;
using Demo.Weather.Shared.Entities;

namespace Demo.Weather.GraphQL
{
    public static class DataGenerator
    {
        public static Product[] GetProducts()
        {
            return new Product[]
            {
                  new Product("Apple", 1.1m) { Id = 1},
                    new Product("Orange", 2.2m) { Id = 2},
                    new Product("Mango", 3.3m) { Id = 3},
                    new Product("Avocado", 4.4m) { Id = 4}
            };
        }

        public static void SeedData(BlogDbContext context)
        {
            List<Author> authors = new()
            {
                new Author { Name = "John Doe" },
                new Author { Name = "Jane Smith" },
            };

            List<Post> posts = new()
            {
                new Post { Title = "First Post", Content = "This is the content of the first post", AuthorId = 1 },
                new Post { Title = "Second Post", Content = "This is the content of the second post", AuthorId = 2 },
            };

            List<Comment> comments = new()
            {
                new Comment { Text = "Great post!", PostId = 1 },
                new Comment { Text = "I enjoyed reading this", PostId = 1 },
                new Comment { Text = "Nice work!", PostId = 2 },
            };

            // Add entities without relationships
            context.Authors.AddRange(authors);
            context.SaveChanges();

            // Assign AuthorId for each post
            posts[0].AuthorId = authors[0].Id;
            posts[1].AuthorId = authors[1].Id;

            // Add posts with relationships
            context.Posts.AddRange(posts);
            context.SaveChanges();

            // Assign PostId for each comment
            comments[0].PostId = posts[0].Id;
            comments[1].PostId = posts[0].Id;
            comments[2].PostId = posts[1].Id;

            // Add comments with relationships
            context.Comments.AddRange(comments);
            context.SaveChanges();
        }
    }
}