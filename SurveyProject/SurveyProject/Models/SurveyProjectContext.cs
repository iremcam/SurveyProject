using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection.Emit;

namespace SurveyProject.Models
{
    public partial class SurveyProjectContext:DbContext
    {
        public SurveyProjectContext() { }

        public SurveyProjectContext(DbContextOptions<SurveyProjectContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-2PGSHUI\\SQLEXPRESS;DataBase=SurveyProject;Uid=sa;Pwd=1234;Trusted_Connection=False;Encrypt=True;TrustServerCertificate=True;");
            }
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<Survey> Survey { get; set; }
        public virtual DbSet<Assignment> Assignment { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<Solution> Solution { get; set; }
        public virtual DbSet<Question> Question { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Solution>(entity =>
            {
                entity.Property(a => a.Id).ValueGeneratedOnAdd();


            });
            builder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserType");
            });
            builder.Entity<Assignment>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assignment_User");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assignment_Survey");
            });
            builder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question_Survey");
                entity.Property(a => a.Order).IsRequired();

                
            });
            builder.Entity<Option>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Options)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Option_Question");
               
            });
            builder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(10);
            });
            builder.Entity<Survey>(entity =>
            {
                entity.Property(a => a.Title).HasMaxLength(100).IsRequired();
            });

            OnModelCreatingPartial(builder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
