using Microsoft.EntityFrameworkCore;

namespace NtdLesson10EFDbFirst.Models;

public partial class NtdK24cntt2lesson10EFdbContext : DbContext
{
    public NtdK24cntt2lesson10EFdbContext(DbContextOptions<NtdK24cntt2lesson10EFdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NtdMember> NtdMembers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NtdMember>(entity =>
        {
            entity.HasKey(e => e.NtdMemberId);
            entity.Property(e => e.NtdMemberId).ValueGeneratedOnAdd();
            entity.Property(e => e.NtdUserName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.NtdPassword).HasMaxLength(100).IsRequired();
            entity.Property(e => e.NtdFullName).HasMaxLength(150).IsRequired();
            entity.Property(e => e.NtdEmail).HasMaxLength(150).IsRequired();
            entity.Property(e => e.NtdPhone).HasMaxLength(20);
        });
    }
}
