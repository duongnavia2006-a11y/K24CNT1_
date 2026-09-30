using Microsoft.EntityFrameworkCore;
using NtdLesson12_EF.Models;

namespace NtdLesson12_EF.Data
{
    public class NtdAppDbContext : DbContext
    {
        public NtdAppDbContext(DbContextOptions<NtdAppDbContext> options) : base(options)
        {
        }

        public DbSet<NtdCategory> Categories { get; set; }
        public DbSet<NtdProduct> Products { get; set; }
        public DbSet<NtdBanner> Banners { get; set; }
        public DbSet<NtdStdClass> StdClasses { get; set; }
        public DbSet<NtdStudent> Students { get; set; }
        public DbSet<NtdSubject> Subjects { get; set; }
        public DbSet<NtdMark> Marks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình bảng Category & Product theo slide
            modelBuilder.Entity<NtdCategory>(entity =>
            {
                entity.ToTable("Category");
                entity.HasKey(c => c.Id);
            });

            modelBuilder.Entity<NtdProduct>(entity =>
            {
                entity.ToTable("Product");
                entity.HasKey(p => p.Id);
                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(p => p.CategoryId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Cấu hình bảng Banner theo Bài 3 tự làm
            modelBuilder.Entity<NtdBanner>(entity =>
            {
                entity.ToTable("Banner");
                entity.HasKey(b => b.Id);
            });

            // Cấu hình StudentManager theo Bài 5 tự làm
            modelBuilder.Entity<NtdStudent>(entity =>
            {
                entity.ToTable("Student");
                entity.HasKey(s => s.Id);
                entity.HasIndex(s => s.StudentEmail).IsUnique();
                entity.HasIndex(s => s.StudentPhone).IsUnique();

                entity.HasOne(s => s.StdClass)
                      .WithMany(c => c.Students)
                      .HasForeignKey(s => s.ClassId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<NtdSubject>(entity =>
            {
                entity.ToTable("Subjects");
                entity.HasKey(sub => sub.Id);
                entity.HasIndex(sub => sub.SubjectName).IsUnique();
            });

            // Khóa chính hỗn hợp trên 2 cột (SubjectId, StudentId) cho bảng Marks
            modelBuilder.Entity<NtdMark>(entity =>
            {
                entity.ToTable("Marks");
                entity.HasKey(m => new { m.SubjectId, m.StudentId });

                entity.HasOne(m => m.Subject)
                      .WithMany(s => s.Marks)
                      .HasForeignKey(m => m.SubjectId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(m => m.Student)
                      .WithMany(s => s.Marks)
                      .HasForeignKey(m => m.StudentId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
