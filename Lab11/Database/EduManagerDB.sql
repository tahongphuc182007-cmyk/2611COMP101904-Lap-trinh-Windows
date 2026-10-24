/* =====================================================================
   COMP1019 - Lab 11: ADO.NET và CRUD với SQL Server
   Script tạo database EduManagerDB (2 bảng LOP và SINHVIEN) và dữ liệu mẫu.

   CẢNH BÁO: script này XÓA database EduManagerDB cũ (nếu có) rồi tạo lại.
   Database EduManagerDB của Lab 10 (6 bảng) cũng bị xóa. Cần dữ liệu Lab 10
   thì chạy lại 2 file script của Lab 10 sau khi làm xong Lab 11.
   ===================================================================== */

USE master;
GO

-- Xóa database cũ; SINGLE_USER ngắt các kết nối đang mở để tránh lỗi "database is in use"
IF DB_ID(N'EduManagerDB') IS NOT NULL
BEGIN
    ALTER DATABASE EduManagerDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE EduManagerDB;
END
GO

CREATE DATABASE EduManagerDB;
GO

USE EduManagerDB;
GO

/* Bảng LOP: tên lớp dùng NVARCHAR để lưu được tiếng Việt */
CREATE TABLE LOP (
    MaLop  VARCHAR(20)   NOT NULL,
    TenLop NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_LOP PRIMARY KEY (MaLop)
);
GO

/* Bảng SINHVIEN: mỗi sinh viên thuộc một lớp.
   Khóa ngoại khiến SQL Server không cho xóa lớp đang có sinh viên. */
CREATE TABLE SINHVIEN (
    MaSV  VARCHAR(20)   NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    MaLop VARCHAR(20)   NOT NULL,
    CONSTRAINT PK_SINHVIEN PRIMARY KEY (MaSV),
    CONSTRAINT FK_SINHVIEN_LOP FOREIGN KEY (MaLop) REFERENCES LOP (MaLop)
);
GO

INSERT INTO LOP (MaLop, TenLop) VALUES
('CNTT01',  N'Công nghệ thông tin 01'),
('CNTT02',  N'Công nghệ thông tin 02'),
('SPTIN01', N'Sư phạm Tin học 01');
GO

-- CNTT01 có 2 sinh viên (không được xóa); CNTT02 và SPTIN01 chưa có sinh viên (xóa được)
INSERT INTO SINHVIEN (MaSV, HoTen, MaLop) VALUES
('SV001', N'Nguyễn Văn An', 'CNTT01'),
('SV002', N'Trần Thị Bình', 'CNTT01');
GO

-- Kiểm tra nhanh
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
ORDER BY l.MaLop;
GO
