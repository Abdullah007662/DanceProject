using DanceEntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceDataAccessLayer.Concrete
{
	public class DanceContext : DbContext
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
		public DbSet<About> Abouts { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Grade> Grades { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<Price> Prices { get; set; }
		public DbSet<Testimonial> Testimonials { get; set; }

	}
}
