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
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users").HasKey(u => u.Id);

            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("id");
            modelBuilder.Entity<User>().Property(u => u.full_name).HasColumnName("full_name");
            modelBuilder.Entity<User>().Property(u => u.email).HasColumnName("email");

            //Question
            modelBuilder.Entity<Question>().ToTable("question").HasKey(q => q.Id);

            modelBuilder.Entity<Question>().Property(q => q.Id).HasColumnName("id");
            modelBuilder.Entity<Question>().Property(q => q.QuestionText).HasColumnName("question_text");

            //Question options
            modelBuilder.Entity<QuestionOption>().ToTable("question_options").HasKey(qo => qo.Id);
            modelBuilder.Entity<QuestionOption>().Property(qo => qo.Id).HasColumnName("id");
            modelBuilder.Entity<QuestionOption>().Property(qo => qo.QuestionId).HasColumnName("question_id");
            modelBuilder.Entity<QuestionOption>().Property(qo => qo.Description).HasColumnName("description");
            modelBuilder.Entity<QuestionOption>().Property(qo => qo.ImgDescription).HasColumnName("img_description");
        }
    }
}