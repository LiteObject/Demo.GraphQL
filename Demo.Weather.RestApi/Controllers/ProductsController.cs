using Demo.Weather.Shared.Database;
using Demo.Weather.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Demo.Weather.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly ProductDbContext _productDbContext;

        public ProductsController(ILogger<ProductsController> logger, ProductDbContext cityWeatherDbContext)
        {
            _logger = logger;
            _productDbContext = cityWeatherDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetByNameAsync(string productName = "")
        {
            List<Product>? result = string.IsNullOrWhiteSpace(productName) ?
                await _productDbContext.Products.ToListAsync()
                : await _productDbContext.Products.Where(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase)).ToListAsync();

            if (result is null || result.Count == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}