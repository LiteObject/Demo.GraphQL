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

            builder.Services.AddSqlite<ProductDbContext>("Data Source=Product.db");

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