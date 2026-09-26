using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NguyenTungDuong2410900017_exam.Models;

public partial class NguyenTungDuong2410900017DbContext : DbContext
{
    public NguyenTungDuong2410900017DbContext()
    {
    }

    public NguyenTungDuong2410900017DbContext(DbContextOptions<NguyenTungDuong2410900017DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NtdStudent> NtdStudents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=DUONG;Database=NguyenTungDuong2410900017_Db;Integrated Security=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NtdStudent>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("NtdStudent");

            entity.Property(e => e.NtdEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NtdName).HasMaxLength(100);
            entity.Property(e => e.NtdPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
