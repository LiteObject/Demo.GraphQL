using Demo.Weather.Shared.Database;
using Demo.Weather.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Demo.Weather.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly ILogger<PostsController> _logger;
        private readonly BlogDbContext _blogDbContext;

        public PostsController(ILogger<PostsController> logger, BlogDbContext PostDbContext)
        {
            _logger = logger;
            _blogDbContext = PostDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetByPostsAsync(string keyWord = "")
        {
            List<Post>? result = string.IsNullOrWhiteSpace(keyWord) ?
                await _blogDbContext.Posts.ToListAsync()
                : await _blogDbContext.Posts.Where(p => p.Content.Contains(keyWord, StringComparison.OrdinalIgnoreCase)).ToListAsync();

            if (result is null || result.Count == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}