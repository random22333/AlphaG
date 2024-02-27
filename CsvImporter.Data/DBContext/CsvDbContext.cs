using CsvImporter.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CsvImporter.Data
{
    public class CsvDbContext : DbContext
    {
        public DbSet<Vehicles> Vehicles { get; set; } 

        private readonly IConfiguration _configuration;

        public CsvDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicles>().HasKey(v => v.Id);
        }
    }
}

