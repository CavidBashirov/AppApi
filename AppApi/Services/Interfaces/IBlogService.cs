using AppApi.DTOs.Blogs;

namespace AppApi.Services.Interfaces
{
    public interface IBlogService
    {
        Task CreateAsync(BlogCreateDto request);
        Task<IEnumerable<BlogDto>> GetAllAsync();
    }
}
