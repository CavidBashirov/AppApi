using AppApi.DTOs.Blogs;
using AppApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _blogService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] BlogCreateDto request)
        {
            await _blogService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), request);
        }
    }
}
