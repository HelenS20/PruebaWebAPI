using Microsoft.EntityFrameworkCore;
using PruebaWebAPI.Domain.Entities;

namespace PruebaWebAPI.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(eb =>
            {
                eb.Property(e => e.Email).IsRequired().HasMaxLength(256);
                eb.Property(e => e.Password).IsRequired().HasMaxLength(200);
                eb.Property(e => e.Username).IsRequired().HasMaxLength(100);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
