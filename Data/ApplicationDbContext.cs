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
        public DbSet<City> Cities { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Answer> Answers { get; set; }

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

            //City
            modelBuilder.Entity<City>().ToTable("city").HasKey(c => c.Id);
            modelBuilder.Entity<City>().Property(c => c.Id).HasColumnName("id");
            modelBuilder.Entity<City>().Property(c => c.Description).HasColumnName("description");
            modelBuilder.Entity<City>().Property(c => c.img_city).HasColumnName("img_city");

            //Destination
            modelBuilder.Entity<Destination>().ToTable("destination").HasKey(d => d.Id);
            modelBuilder.Entity<Destination>().Property(d => d.Id).HasColumnName("id");
            modelBuilder.Entity<Destination>().Property(d => d.Combination).HasColumnName("combination");
            modelBuilder.Entity<Destination>().Property(d => d.FirstCityId).HasColumnName("first_city_id");
            modelBuilder.Entity<Destination>().Property(d => d.SecondCityId).HasColumnName("second_city_id");

            //Answer
            modelBuilder.Entity<Answer>().ToTable("answer").HasKey(a => a.Id);
            modelBuilder.Entity<Answer>().Property(a => a.Id).HasColumnName("id");
            modelBuilder.Entity<Answer>().Property(a => a.UserId).HasColumnName("user_id");
            modelBuilder.Entity<Answer>().Property(a => a.QuestionId).HasColumnName("question_id");
            modelBuilder.Entity<Answer>().Property(a => a.QuestionOptionId).HasColumnName("question_option_id");
            modelBuilder.Entity<Answer>().Property(a => a.CreatedAt).HasColumnName("date");
        }
    }
}