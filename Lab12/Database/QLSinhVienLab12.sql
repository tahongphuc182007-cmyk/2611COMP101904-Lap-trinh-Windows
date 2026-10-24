/* =====================================================================
   COMP1019 - Lab 12: Data Binding, Stored Procedure và Transaction
   Script tạo database QLSinhVienLab12, 4 bảng, 4 stored procedure và dữ liệu mẫu.
   Chạy cả file bằng SSMS. Script xóa database QLSinhVienLab12 cũ (nếu có) rồi tạo lại.
   Yêu cầu SQL Server 2016 SP1 trở lên (dùng CREATE OR ALTER).
   ===================================================================== */

USE master;
GO

IF DB_ID(N'QLSinhVienLab12') IS NOT NULL
BEGIN
    ALTER DATABASE QLSinhVienLab12 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLSinhVienLab12;
END
GO

CREATE DATABASE QLSinhVienLab12;
GO

USE QLSinhVienLab12;
GO

/* ---------------------------------------------------------------------
   Các bảng
   --------------------------------------------------------------------- */
CREATE TABLE LOP (
    MaLop  NVARCHAR(20)  NOT NULL,
    TenLop NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_LOP PRIMARY KEY (MaLop)
);
GO

CREATE TABLE SINHVIEN (
    MaSV     NVARCHAR(20)  NOT NULL,
    HoTen    NVARCHAR(100) NOT NULL,
    NgaySinh DATE          NULL,
    MaLop    NVARCHAR(20)  NOT NULL,
    CONSTRAINT PK_SINHVIEN PRIMARY KEY (MaSV),
    CONSTRAINT FK_SINHVIEN_LOP FOREIGN KEY (MaLop) REFERENCES LOP (MaLop)
);
GO

CREATE TABLE MONHOC (
    MaMon    NVARCHAR(20)  NOT NULL,
    TenMon   NVARCHAR(100) NOT NULL,
    SoTinChi INT           NOT NULL,
    CONSTRAINT PK_MONHOC PRIMARY KEY (MaMon),
    CONSTRAINT CK_MONHOC_SoTinChi CHECK (SoTinChi > 0)
);
GO

/* Khóa chính ghép (MaSV, MaMon): mỗi sinh viên chỉ có một điểm cho một môn.
   Điểm nằm trong khoảng 0 đến 10. */
CREATE TABLE KETQUA (
    MaSV   NVARCHAR(20)  NOT NULL,
    MaMon  NVARCHAR(20)  NOT NULL,
    Diem   FLOAT         NOT NULL,
    GhiChu NVARCHAR(255) NULL,
    CONSTRAINT PK_KETQUA PRIMARY KEY (MaSV, MaMon),
    CONSTRAINT CK_KETQUA_Diem CHECK (Diem >= 0 AND Diem <= 10),
    CONSTRAINT FK_KETQUA_SINHVIEN FOREIGN KEY (MaSV) REFERENCES SINHVIEN (MaSV),
    CONSTRAINT FK_KETQUA_MONHOC FOREIGN KEY (MaMon) REFERENCES MONHOC (MaMon)
);
GO

/* ---------------------------------------------------------------------
   Dữ liệu mẫu
   --------------------------------------------------------------------- */
INSERT INTO LOP (MaLop, TenLop) VALUES
(N'CTK47A', N'Công nghệ thông tin K47A'),
(N'CTK47B', N'Công nghệ thông tin K47B');
GO

INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, MaLop) VALUES
(N'SV001', N'Nguyễn Văn An',    '2005-01-15', N'CTK47A'),
(N'SV002', N'Trần Thị Bình',    '2005-05-20', N'CTK47A'),
(N'SV003', N'Lê Minh Cường',    '2005-03-11', N'CTK47A'),
(N'SV004', N'Phạm Thanh Dung',  '2005-07-09', N'CTK47B');
GO

INSERT INTO MONHOC (MaMon, TenMon, SoTinChi) VALUES
(N'COMP1019', N'Lập trình trên Windows', 3),
(N'COMP1017', N'Cơ sở lập trình',        3);
GO

-- Một điểm có sẵn: lần tải đầu tiên SV001 có điểm 8, các sinh viên còn lại chưa có điểm (ô điểm để trống)
INSERT INTO KETQUA (MaSV, MaMon, Diem, GhiChu) VALUES
(N'SV001', N'COMP1019', 8, N'Chuyên cần tốt');
GO

/* ---------------------------------------------------------------------
   Stored procedure
   --------------------------------------------------------------------- */

-- Lấy danh sách lớp
CREATE OR ALTER PROCEDURE sp_Lop_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaLop, TenLop
    FROM LOP
    ORDER BY TenLop;
END;
GO

-- Lấy danh sách môn học
CREATE OR ALTER PROCEDURE sp_MonHoc_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaMon, TenMon, SoTinChi
    FROM MONHOC
    ORDER BY TenMon;
END;
GO

-- Lấy sinh viên của một lớp kèm điểm môn học (nếu đã có).
-- LEFT JOIN để sinh viên chưa có điểm vẫn hiện; Diem là NULL để Form biết là chưa nhập.
CREATE OR ALTER PROCEDURE sp_KetQua_GetByLopMon
    @MaLop NVARCHAR(20),
    @MaMon NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT sv.MaSV,
           sv.HoTen,
           CAST(kq.Diem AS FLOAT) AS Diem,
           ISNULL(kq.GhiChu, N'') AS GhiChu
    FROM SINHVIEN sv
    LEFT JOIN KETQUA kq
        ON sv.MaSV = kq.MaSV AND kq.MaMon = @MaMon
    WHERE sv.MaLop = @MaLop
    ORDER BY sv.HoTen;
END;
GO

-- Lưu điểm: đã có thì cập nhật, chưa có thì thêm mới
CREATE OR ALTER PROCEDURE sp_KetQua_Save
    @MaSV   NVARCHAR(20),
    @MaMon  NVARCHAR(20),
    @Diem   FLOAT,
    @GhiChu NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE KETQUA
    SET Diem = @Diem,
        GhiChu = @GhiChu
    WHERE MaSV = @MaSV AND MaMon = @MaMon;

    IF @@ROWCOUNT = 0
    BEGIN
        INSERT INTO KETQUA (MaSV, MaMon, Diem, GhiChu)
        VALUES (@MaSV, @MaMon, @Diem, @GhiChu);
    END
END;
GO

-- Kiểm tra nhanh
EXEC sp_KetQua_GetByLopMon @MaLop = N'CTK47A', @MaMon = N'COMP1019';
GO
