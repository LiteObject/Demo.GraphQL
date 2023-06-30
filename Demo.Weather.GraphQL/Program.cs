using GraphQL;
using Microsoft.Extensions.Options;

namespace Demo.Weather.GraphQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddGraphQL(b => b
            //  .AddSchema<StarWarsSchema>()
            //  .AddSystemTextJson()
            //  .AddValidationRule<InputValidationRule>()
            //  .AddGraphTypes(typeof(StarWarsSchema).Assembly)
            //  .AddMemoryCache()
            //  .AddApolloTracing(options => 
            //  options.RequestServices!.GetRequiredService<IOptions<GraphQLSettings>>().Value.EnableMetrics));

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}