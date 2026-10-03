using Microsoft.EntityFrameworkCore;
using NtdLesson14.Models;

namespace NtdLesson14.Data;

public static class NtdDbInitializer
{
    public static void Initialize(NtdStoreDbContext ntdContext)
    {
        if (!ntdContext.NtdCategories.Any())
        {
            ntdContext.NtdCategories.AddRange(
                new NtdCategory
                {
                    NtdName = "Đồ gia dụng",
                    NtdStatus = 1,
                    NtdCreatedDate = DateTime.Today,
                    NtdDescription = "Sản phẩm tiện ích cho gia đình."
                },
                new NtdCategory
                {
                    NtdName = "Thiết bị công nghệ",
                    NtdStatus = 1,
                    NtdCreatedDate = DateTime.Today,
                    NtdDescription = "Thiết bị công nghệ và phụ kiện."
                });
            ntdContext.SaveChanges();
        }

        if (!ntdContext.NtdProducts.Any())
        {
            var ntdCategoryId = ntdContext.NtdCategories
                .OrderBy(ntdCategory => ntdCategory.NtdId)
                .Select(ntdCategory => ntdCategory.NtdId)
                .First();
            ntdContext.NtdProducts.Add(new NtdProduct
            {
                NtdName = "Bình giữ nhiệt",
                NtdPrice = 250000m,
                NtdSalePrice = 0m,
                NtdStatus = 1,
                NtdCategoryId = ntdCategoryId,
                NtdCreatedDate = DateTime.Today,
                NtdDescription = "Bình giữ nhiệt dung tích 500 ml."
            });
        }

        if (!ntdContext.NtdBanners.Any())
        {
            ntdContext.NtdBanners.Add(new NtdBanner
            {
                NtdName = "Banner trang chủ",
                NtdStatus = 1,
                NtdPrioty = 0,
                NtdDescription = "Banner giới thiệu trên trang chủ."
            });
        }

        if (!ntdContext.NtdBlogs.Any())
        {
            ntdContext.NtdBlogs.Add(new NtdBlog
            {
                NtdName = "Chào mừng đến với cửa hàng",
                NtdStatus = 1,
                NtdCreatedDate = DateTime.Today,
                NtdDescription = "Tin tức và bài viết mới nhất."
            });
        }

        ntdContext.SaveChanges();
    }
}
