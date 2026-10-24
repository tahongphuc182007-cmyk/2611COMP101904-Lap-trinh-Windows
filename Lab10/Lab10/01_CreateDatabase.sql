/* =====================================================================
   COMP1019 - Lab 10
   File 01: Tạo database EduManagerDB và 6 bảng
   Thứ tự chạy: 01_CreateDatabase.sql -> 02_InsertSampleData.sql -> 03_Queries.sql
   Yêu cầu: SQL Server 2016 trở lên (dùng DROP ... IF EXISTS)
   ===================================================================== */

USE master;
GO

-- Xóa database cũ (nếu có) để có thể chạy lại từ đầu.
-- Chuyển sang SINGLE_USER để ngắt các kết nối đang mở, tránh lỗi "database is in use".
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

/* ---------------------------------------------------------------------
   Bảng KHOA: thông tin khoa
   --------------------------------------------------------------------- */
CREATE TABLE KHOA (
    MaKhoa    VARCHAR(20)   NOT NULL,
    TenKhoa   NVARCHAR(100) NOT NULL,
    DienThoai VARCHAR(15)   NULL,
    CONSTRAINT PK_KHOA PRIMARY KEY (MaKhoa)
);
GO

/* ---------------------------------------------------------------------
   Bảng LOP: mỗi lớp thuộc một khoa (khóa ngoại MaKhoa -> KHOA)
   --------------------------------------------------------------------- */
CREATE TABLE LOP (
    MaLop   VARCHAR(20)   NOT NULL,
    TenLop  NVARCHAR(100) NOT NULL,
    MaKhoa  VARCHAR(20)   NOT NULL,
    CONSTRAINT PK_LOP PRIMARY KEY (MaLop),
    CONSTRAINT FK_LOP_KHOA FOREIGN KEY (MaKhoa) REFERENCES KHOA (MaKhoa)
);
GO

/* ---------------------------------------------------------------------
   Bảng SINHVIEN: mỗi sinh viên thuộc một lớp (khóa ngoại MaLop -> LOP)
   Giới tính chỉ nhận Nam hoặc Nữ
   --------------------------------------------------------------------- */
CREATE TABLE SINHVIEN (
    MaSV     VARCHAR(20)   NOT NULL,
    HoTen    NVARCHAR(100) NOT NULL,
    NgaySinh DATE          NULL,
    GioiTinh NVARCHAR(10)  NOT NULL,
    MaLop    VARCHAR(20)   NOT NULL,
    CONSTRAINT PK_SINHVIEN PRIMARY KEY (MaSV),
    CONSTRAINT CK_SINHVIEN_GioiTinh CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    CONSTRAINT FK_SINHVIEN_LOP FOREIGN KEY (MaLop) REFERENCES LOP (MaLop)
);
GO

/* ---------------------------------------------------------------------
   Bảng MONHOC: thông tin môn học, số tín chỉ phải lớn hơn 0
   --------------------------------------------------------------------- */
CREATE TABLE MONHOC (
    MaMH     VARCHAR(20)   NOT NULL,
    TenMH    NVARCHAR(100) NOT NULL,
    SoTinChi INT           NOT NULL,
    CONSTRAINT PK_MONHOC PRIMARY KEY (MaMH),
    CONSTRAINT CK_MONHOC_SoTinChi CHECK (SoTinChi > 0)
);
GO

/* ---------------------------------------------------------------------
   Bảng KETQUA: điểm của sinh viên theo môn
   Khóa chính ghép (MaSV, MaMH): một sinh viên chỉ có một điểm cho mỗi môn
   Điểm nằm trong khoảng từ 0 đến 10
   --------------------------------------------------------------------- */
CREATE TABLE KETQUA (
    MaSV VARCHAR(20)   NOT NULL,
    MaMH VARCHAR(20)   NOT NULL,
    Diem DECIMAL(4, 2) NOT NULL,
    CONSTRAINT PK_KETQUA PRIMARY KEY (MaSV, MaMH),
    CONSTRAINT CK_KETQUA_Diem CHECK (Diem BETWEEN 0 AND 10),
    CONSTRAINT FK_KETQUA_SINHVIEN FOREIGN KEY (MaSV) REFERENCES SINHVIEN (MaSV),
    CONSTRAINT FK_KETQUA_MONHOC FOREIGN KEY (MaMH) REFERENCES MONHOC (MaMH)
);
GO

/* ---------------------------------------------------------------------
   Bảng TAIKHOAN: tài khoản đăng nhập demo
   (mật khẩu lưu dạng chữ thường chỉ để demo, thực tế phải băm mật khẩu)
   --------------------------------------------------------------------- */
CREATE TABLE TAIKHOAN (
    TenDangNhap VARCHAR(50)   NOT NULL,
    MatKhau     VARCHAR(100)  NOT NULL,
    HoTen       NVARCHAR(100) NOT NULL,
    VaiTro      VARCHAR(20)   NOT NULL CONSTRAINT DF_TAIKHOAN_VaiTro DEFAULT 'User',
    TrangThai   BIT           NOT NULL CONSTRAINT DF_TAIKHOAN_TrangThai DEFAULT 1,
    CONSTRAINT PK_TAIKHOAN PRIMARY KEY (TenDangNhap)
);
GO

-- Kiểm tra nhanh: liệt kê các bảng vừa tạo (phải có đủ 6 bảng)
SELECT name AS TenBang
FROM sys.tables
ORDER BY name;
GO
