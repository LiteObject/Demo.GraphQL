using Demo.Weather.HotChocolate.GraphQL.GraphQL;
using Demo.Weather.Shared.Database;
using Microsoft.EntityFrameworkCore;

namespace Demo.Weather.HotChocolate.GraphQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddPooledDbContextFactory<CityWeatherDbContext>(c =>
            {
                c.UseInMemoryDatabase("CityInfo");
            });

            // Step #1:
            builder.Services
                .AddGraphQLServer()
                .RegisterDbContext<CityWeatherDbContext>(DbContextKind.Pooled) // More: https://chillicream.com/docs/hotchocolate/integrations/entity-framework
                .AddQueryType<Query>(); // Type generator (HotChocolate.Types.Analyzers) can add types automatically (somewhat like an assembly scanner)

            var app = builder.Build();

            // Step #2:
            app.UseRouting().UseEndpoints(endpoint => endpoint.MapGraphQL());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // app.UseGraphQLPlayground("/ui/playground", new PlaygroundOptions { });
            }

            app.Map("/", () => "Hello GraphQL");

            app.Run();
        }
    }
}