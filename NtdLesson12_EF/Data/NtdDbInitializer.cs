using System;
using System.Collections.Generic;
using System.Linq;
using NtdLesson12_EF.Models;

namespace NtdLesson12_EF.Data
{
    public static class NtdDbInitializer
    {
        public static void Initialize(NtdAppDbContext ntdContext)
        {
            // Kiểm tra và tạo database nếu chưa có
            ntdContext.Database.EnsureCreated();

            // 1. Seed Categories nếu chưa có dữ liệu
            if (!ntdContext.Categories.Any())
            {
                var ntdCategories = new List<NtdCategory>
                {
                    new NtdCategory { Name = "Túi xách thời trang", Status = 1, CreatedDate = DateTime.Now },
                    new NtdCategory { Name = "Balo công sở & laptop", Status = 1, CreatedDate = DateTime.Now },
                    new NtdCategory { Name = "Ví da cao cấp", Status = 1, CreatedDate = DateTime.Now },
                    new NtdCategory { Name = "Phụ kiện thời trang", Status = 1, CreatedDate = DateTime.Now }
                };
                ntdContext.Categories.AddRange(ntdCategories);
                ntdContext.SaveChanges();
            }

            // 2. Seed Products (theo các mẫu sản phẩm túi xách trong slide Lab 06)
            if (!ntdContext.Products.Any())
            {
                var ntdCatTuiXach = ntdContext.Categories.FirstOrDefault(c => c.Name == "Túi xách thời trang") 
                                  ?? ntdContext.Categories.First();

                var ntdProducts = new List<NtdProduct>
                {
                    new NtdProduct
                    {
                        Name = "Túi xách da nữ cao cấp đen",
                        Price = 850000,
                        SalePrice = 750000,
                        Status = 1,
                        CategoryId = ntdCatTuiXach.Id,
                        Descriptions = "Chất liệu da tổng hợp cao cấp, kiểu dáng thanh lịch sang trọng.",
                        CreatedDate = DateTime.Now
                    },
                    new NtdProduct
                    {
                        Name = "Túi du lịch thể thao đỏ viền vàng",
                        Price = 450000,
                        SalePrice = 390000,
                        Status = 1,
                        CategoryId = ntdCatTuiXach.Id,
                        Descriptions = "Túi du lịch sức chứa lớn, chống thấm nước, phong cách trẻ trung.",
                        CreatedDate = DateTime.Now
                    },
                    new NtdProduct
                    {
                        Name = "Cặp da công sở nam cao cấp",
                        Price = 1200000,
                        SalePrice = 990000,
                        Status = 1,
                        CategoryId = ntdCatTuiXach.Id,
                        Descriptions = "Thiết kế nhiều ngăn đựng laptop và tài liệu, da bò dập vân sang trọng.",
                        CreatedDate = DateTime.Now
                    },
                    new NtdProduct
                    {
                        Name = "Túi trống thể thao mini cá tính",
                        Price = 380000,
                        SalePrice = 320000,
                        Status = 1,
                        CategoryId = ntdCatTuiXach.Id,
                        Descriptions = "Túi tập gym thể thao gọn nhẹ, dây đeo chắc chắn bền đẹp.",
                        CreatedDate = DateTime.Now
                    }
                };
                ntdContext.Products.AddRange(ntdProducts);
                ntdContext.SaveChanges();
            }

            // 3. Seed Banners (theo Bài 3 & 4 slide)
            if (!ntdContext.Banners.Any())
            {
                var ntdBanners = new List<NtdBanner>
                {
                    new NtdBanner
                    {
                        Name = "Microsoft Azure & ASP.NET Core MVC",
                        Description = "Tìm hiểu nền tảng đám mây và kiến trúc ứng dụng Web hiện đại với EF Core.",
                        Status = 1,
                        CreatedDate = DateTime.Now
                    },
                    new NtdBanner
                    {
                        Name = "Bộ sưu tập túi xách thời trang 2026",
                        Description = "Ưu đãi hấp dẫn giảm giá lên đến 30% cho khách hàng mới.",
                        Status = 1,
                        CreatedDate = DateTime.Now
                    }
                };
                ntdContext.Banners.AddRange(ntdBanners);
                ntdContext.SaveChanges();
            }

            // 4. Seed StdClass, Student, Subjects, Marks (theo Bài 5 & 6)
            if (!ntdContext.StdClasses.Any())
            {
                var ntdClass1 = new NtdStdClass { ClassName = "K24CNT1" };
                var ntdClass2 = new NtdStdClass { ClassName = "K24CNT2" };
                ntdContext.StdClasses.AddRange(ntdClass1, ntdClass2);
                ntdContext.SaveChanges();

                var ntdSub1 = new NtdSubject { SubjectName = "Lập trình ASP.NET Core MVC" };
                var ntdSub2 = new NtdSubject { SubjectName = "Cơ sở dữ liệu SQL Server" };
                var ntdSub3 = new NtdSubject { SubjectName = "Entity Framework Core" };
                ntdContext.Subjects.AddRange(ntdSub1, ntdSub2, ntdSub3);
                ntdContext.SaveChanges();

                var ntdStudent1 = new NtdStudent
                {
                    StudentName = "Nguyễn Tùng Dương",
                    StudentEmail = "tungduong.ntd@gmail.com",
                    StudentPhone = "0987654321",
                    StudentAddress = "Hà Nội",
                    StudentAvatar = "avatar1.png",
                    StudentBirthday = new DateTime(2006, 1, 1),
                    ClassId = ntdClass1.Id
                };
                var ntdStudent2 = new NtdStudent
                {
                    StudentName = "Trần Thị Lan",
                    StudentEmail = "lan.tran@gmail.com",
                    StudentPhone = "0912345678",
                    StudentAddress = "Bắc Ninh",
                    StudentAvatar = "avatar2.png",
                    StudentBirthday = new DateTime(2006, 5, 12),
                    ClassId = ntdClass1.Id
                };
                ntdContext.Students.AddRange(ntdStudent1, ntdStudent2);
                ntdContext.SaveChanges();

                var ntdMarks = new List<NtdMark>
                {
                    new NtdMark { SubjectId = ntdSub1.Id, StudentId = ntdStudent1.Id, Score = 9.0f },
                    new NtdMark { SubjectId = ntdSub2.Id, StudentId = ntdStudent1.Id, Score = 8.5f },
                    new NtdMark { SubjectId = ntdSub3.Id, StudentId = ntdStudent1.Id, Score = 9.5f },
                    new NtdMark { SubjectId = ntdSub1.Id, StudentId = ntdStudent2.Id, Score = 8.0f }
                };
                ntdContext.Marks.AddRange(ntdMarks);
                ntdContext.SaveChanges();
            }
        }
    }
}
