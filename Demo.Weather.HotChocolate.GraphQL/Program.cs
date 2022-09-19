using Demo.Weather.HotChocolate.GraphQL.Types;
using Demo.Weather.Shared.Database;
using Microsoft.EntityFrameworkCore;

namespace Demo.Weather.HotChocolate.GraphQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<CityWeatherDbContext>(c =>
            {
                c.UseInMemoryDatabase("CityInfo");
            });

            // Step #1:
            builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>();

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