using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace AppApi.DTOs.Sliders
{
    public class SliderCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }
        public IFormFile UploadImage { get; set; }
    }

    public class SliderCreateDtoValidator : AbstractValidator<SliderCreateDto>
    {
        public SliderCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Title PB101 is required");
            RuleFor(x => x.Description).NotEmpty().NotNull();
        }
    }
}
