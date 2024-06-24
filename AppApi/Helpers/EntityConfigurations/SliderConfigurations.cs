using AppApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppApi.Helpers.EntityConfigurations
{
    public class SliderConfigurations : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(e => e.Title).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Image).IsRequired();
        }
    }
}
