-- ========================================================
-- BÀI THI: Phát triển ứng dụng với ASP.NET Core MVC
-- Sinh viên: Nguyễn Tùng Dương
-- Mã SV: 2410900017
-- Lớp: K24CNT1
-- Database: NtdStudent_2410900017_Db
-- ========================================================

CREATE DATABASE NtdStudent_2410900017_Db;
GO

USE NtdStudent_2410900017_Db;
GO

-- Tạo bảng NtdStudent
CREATE TABLE NtdStudent (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NtdName NVARCHAR(100) NOT NULL,
    NtdGender BIT NULL, -- 1: Nam, 0: Nữ
    NtdBirthDay DATE NULL,
    NtdEmail VARCHAR(100) NULL,
    NtdPhone VARCHAR(20) NULL,
    NtdActive BIT DEFAULT 1 -- 1: Đang học, 0: Tạm dừng
);
GO

-- Chèn dữ liệu mẫu
INSERT INTO NtdStudent (NtdName, NtdGender, NtdBirthDay, NtdEmail, NtdPhone, NtdActive)
VALUES 
(N'Nguyễn Tùng Dương', 1, '2006-01-01', 'duong.navia2006@gmail.com', '0987654321', 1),
(N'Trần Thị Mai', 0, '2006-05-15', 'maitt@gmail.com', '0912345678', 1),
(N'Lê Hoàng Nam', 1, '2006-08-20', 'namlh@gmail.com', '0981122334', 1),
(N'Phạm Thu Hà', 0, '2006-11-10', 'hapt@gmail.com', '0977889900', 0),
(N'Vũ Đức Anh', 1, '2006-03-25', 'anhvd@gmail.com', '0966554433', 1);
GO

SELECT * FROM NtdStudent;
GO
