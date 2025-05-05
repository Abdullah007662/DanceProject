using DanceEntityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DanceDataAccessLayer.Concrete
{
    public class DanceContext : IdentityDbContext<AppUser, AppRole, int>
    {
        private readonly IConfiguration _configuration;

        public DanceContext(DbContextOptions<DanceContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(_configuration.GetConnectionString("DefaultConnection")!);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>(entity =>
            {
                entity.HasKey(e => e.Id);

                // Id alanı otomatik arttırılsın
                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd();
            });

            // Diğer tabloların konfigürasyonu varsa buraya ekleyebilirsin
        }


        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
