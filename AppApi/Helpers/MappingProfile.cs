using AppApi.DTOs.Blogs;
using AppApi.DTOs.Cities;
using AppApi.DTOs.Countries;
using AppApi.DTOs.Sliders;
using AppApi.Models;
using AutoMapper;

namespace AppApi.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDto>()
                .ForMember(dest =>dest.Date, opt => opt.MapFrom(src => src.CreatedDate));

            CreateMap<CountryCreateDto, Country>();
            CreateMap<CountryEditDto, Country>();
            CreateMap<CityCreateDto, City>();

            CreateMap<City, CityDto>()
              .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name));

            CreateMap<SliderCreateDto, Slider>();
            CreateMap<Slider, SliderDto>();

            CreateMap<SliderEditDto, Slider>().ForMember(dest => dest.Image, opt => opt.Condition(src => (src.Image is not null)));

            CreateMap<BlogCreateDto, Blog>();

            CreateMap<Blog, BlogDto>().ForMember(dest => dest.Image, opt => opt.MapFrom(src => Convert.ToBase64String(src.Image)));


        }
    }
}
