using Microsoft.EntityFrameworkCore;
using NtdLesson14.Models;

namespace NtdLesson14.Data;

public class NtdStoreDbContext(DbContextOptions<NtdStoreDbContext> ntdOptions) : DbContext(ntdOptions)
{
    public DbSet<NtdCategory> NtdCategories => Set<NtdCategory>();
    public DbSet<NtdProduct> NtdProducts => Set<NtdProduct>();
    public DbSet<NtdBanner> NtdBanners => Set<NtdBanner>();
    public DbSet<NtdBlog> NtdBlogs => Set<NtdBlog>();

    protected override void OnModelCreating(ModelBuilder ntdModelBuilder)
    {
        ntdModelBuilder.Entity<NtdCategory>().HasIndex(ntdCategory => ntdCategory.NtdName).IsUnique();
        ntdModelBuilder.Entity<NtdProduct>()
            .HasOne(ntdProduct => ntdProduct.NtdCategory)
            .WithMany()
            .HasForeignKey(ntdProduct => ntdProduct.NtdCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        ntdModelBuilder.Entity<NtdProduct>().HasIndex(ntdProduct => ntdProduct.NtdName).IsUnique();
        ntdModelBuilder.Entity<NtdBanner>().HasIndex(ntdBanner => ntdBanner.NtdName).IsUnique();
        ntdModelBuilder.Entity<NtdBlog>().HasIndex(ntdBlog => ntdBlog.NtdName).IsUnique();
    }
}
