using Demo.Shared.Database;
using Demo.Weather.GraphQL;
using Demo.Weather.Shared.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Demo.Weather.RestApi
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

            builder.Services.AddSqlite<BlogDbContext>("Data Source=MyBlog.db");

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