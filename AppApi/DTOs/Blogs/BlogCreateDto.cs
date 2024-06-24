using Swashbuckle.AspNetCore.Annotations;

namespace AppApi.DTOs.Blogs
{
    public class BlogCreateDto
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public byte[] Image { get; set; }
        public IFormFile UploadImage { get; set; }
    }
}
