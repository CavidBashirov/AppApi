using AppApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AppApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Category>().HasData(
                new Category {
                     Id= 1,
                     CreatedDate = DateTime.Now, 
                     Name = "UI UX", 
                },

                new Category
                {
                     Id = 2,
                     CreatedDate = DateTime.Now,
                     Name = "Backend",
                },

                new Category
                {
                      Id = 3,
                      CreatedDate = DateTime.Now,
                      Name = "Frontend",
                }

            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
