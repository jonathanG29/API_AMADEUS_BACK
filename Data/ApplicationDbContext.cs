using Microsoft.EntityFrameworkCore;
using API_AMADEUS.Models;

namespace API_AMADEUS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users").HasKey(u => u.Id);

            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("id");
            modelBuilder.Entity<User>().Property(u => u.full_name).HasColumnName("full_name");
            modelBuilder.Entity<User>().Property(u => u.email).HasColumnName("email");
        }
    }
}