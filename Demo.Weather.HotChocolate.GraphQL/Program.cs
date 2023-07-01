using Demo.Weather.GraphQL;
using Demo.Weather.HotChocolate.GraphQL.GraphQL;
using Demo.Weather.HotChocolate.GraphQL.GraphQL.Types;
using Demo.Weather.Shared.Database;
using Microsoft.EntityFrameworkCore;

namespace Demo.Weather.HotChocolate.GraphQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BlogDbContext>(c =>
            {
                // c.UseInMemoryDatabase("CityInfo");
                c.UseSqlite("Data Source=MyBlog.db");
            });

            // Step #1:
            builder.Services
                .AddGraphQLServer()
                .RegisterDbContext<BlogDbContext>(DbContextKind.Pooled) // More: https://chillicream.com/docs/hotchocolate/integrations/entity-framework
                .AddQueryType<Query>() // Type generator (HotChocolate.Types.Analyzers) can add types automatically (somewhat like an assembly scanner)
                .AddType<AuthorType>()
                .AddType<PostType>()
                .AddType<CommentType>();

            WebApplication app = builder.Build();

            using IServiceScope serviceScope = app.Services.CreateScope();
            IServiceProvider serviceProvider = serviceScope.ServiceProvider;
            BlogDbContext appDbContext = serviceProvider.GetRequiredService<BlogDbContext>();
            // _ = appDbContext.Database.EnsureDeleted();
            _ = appDbContext.Database.EnsureCreated();

            // Seed if the table is empty
            if (!appDbContext.Posts.Any())
            {
                DataGenerator.SeedData(appDbContext);
            }

            // Step #2:
            // app.UseRouting().UseEndpoints(endpoint => endpoint.MapGraphQL());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // app.UseGraphQLPlayground("/ui/playground", new PlaygroundOptions { });
            }

            // Step #2:
            // app.Map("/", () => "Hello GraphQL");
            // http://localhost:5266/graphql/
            app.MapGraphQL();

            app.Run();
        }
    }
}