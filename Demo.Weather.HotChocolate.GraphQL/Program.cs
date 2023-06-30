using Demo.Weather.GraphQL;
using Demo.Weather.HotChocolate.GraphQL.GraphQL;
using Demo.Weather.Shared.Database;
using Microsoft.EntityFrameworkCore;

namespace Demo.Weather.HotChocolate.GraphQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ProductDbContext>(c =>
            {
                // c.UseInMemoryDatabase("CityInfo");
                c.UseSqlite("Data Source=Product.db");
            });

            // Step #1:
            builder.Services
                .AddGraphQLServer()
                .RegisterDbContext<ProductDbContext>(DbContextKind.Pooled) // More: https://chillicream.com/docs/hotchocolate/integrations/entity-framework
                .AddQueryType<Query>(); // Type generator (HotChocolate.Types.Analyzers) can add types automatically (somewhat like an assembly scanner)

            WebApplication app = builder.Build();

            using IServiceScope serviceScope = app.Services.CreateScope();
            IServiceProvider serviceProvider = serviceScope.ServiceProvider;
            ProductDbContext appDbContext = serviceProvider.GetRequiredService<ProductDbContext>();
            // _ = appDbContext.Database.EnsureDeleted();
            _ = appDbContext.Database.EnsureCreated();

            // Seed if the table is empty
            if (!appDbContext.Products.Any())
            {
                appDbContext.Products.AddRange(DataGenerator.GetProducts());
                _ = appDbContext.SaveChanges();
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