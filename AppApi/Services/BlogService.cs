using AppApi.Data;
using AppApi.DTOs.Blogs;
using AppApi.Models;
using AppApi.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AppApi.Services
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BlogService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(BlogCreateDto request)
        {
            using (var ms = new MemoryStream())
            {
                request.UploadImage.CopyTo(ms);
                request.Image = ms.ToArray();
            }

            await _context.AddAsync(_mapper.Map<Blog>(request));
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<BlogDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<BlogDto>>(await _context.Blogs.AsNoTracking().ToListAsync());
        }
    }
}
