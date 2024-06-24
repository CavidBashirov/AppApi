using AppApi.DTOs.Sliders;
using AppApi.Helpers;
using AppApi.Services;
using AppApi.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace AppApi.Injections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<IBlogService, BlogService>();

            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
            });

            services.AddScoped<IValidator<SliderCreateDto>, SliderCreateDtoValidator>();

            return services;
        }
    }
}
