/* =====================================================================
   COMP1019 - Lab 10
   File 03: Các truy vấn (12 câu theo đề)
   Phải chạy sau 01_CreateDatabase.sql và 02_InsertSampleData.sql.
   Câu 5 và 6 làm thay đổi dữ liệu. Muốn chạy lại từ đầu, chạy lại file 01 và 02.
   ===================================================================== */

USE EduManagerDB;
GO

/* ---------------------------------------------------------------------
   PHẦN 1: Truy vấn cơ bản
   --------------------------------------------------------------------- */

-- Câu 1. Liệt kê toàn bộ sinh viên
SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaLop
FROM SINHVIEN;
GO

-- Câu 2. Liệt kê sinh viên kèm tên lớp và tên khoa
SELECT sv.MaSV, sv.HoTen, l.TenLop, k.TenKhoa
FROM SINHVIEN sv
INNER JOIN LOP  l ON sv.MaLop = l.MaLop
INNER JOIN KHOA k ON l.MaKhoa = k.MaKhoa;
GO

-- Câu 3. Tìm sinh viên theo một phần họ tên bằng LIKE
SELECT MaSV, HoTen, MaLop
FROM SINHVIEN
WHERE HoTen LIKE N'%An%'
ORDER BY HoTen ASC;
GO

-- Câu 4. Liệt kê sinh viên theo mã lớp
SELECT MaSV, HoTen, GioiTinh
FROM SINHVIEN
WHERE MaLop = 'CNTT01';
GO

/* ---------------------------------------------------------------------
   PHẦN 2: Cập nhật và xóa
   --------------------------------------------------------------------- */

-- Câu 5. Cập nhật họ tên của một sinh viên (luôn kiểm tra WHERE trước khi chạy)
UPDATE SINHVIEN
SET HoTen = N'Nguyễn Văn An Updated'
WHERE MaSV = 'SV001';

-- Xem lại kết quả cập nhật
SELECT MaSV, HoTen, MaLop
FROM SINHVIEN
WHERE MaSV = 'SV001';
GO

-- Câu 6. Xóa một sinh viên chưa có dữ liệu điểm
-- Xem trước: các sinh viên chưa có điểm (phải thấy SV007)
SELECT sv.MaSV, sv.HoTen
FROM SINHVIEN sv
LEFT JOIN KETQUA kq ON sv.MaSV = kq.MaSV
WHERE kq.MaSV IS NULL;

-- Điều kiện NOT EXISTS bảo đảm chỉ xóa khi sinh viên chưa có điểm,
-- tránh lỗi khóa ngoại với bảng KETQUA
DELETE FROM SINHVIEN
WHERE MaSV = 'SV007'
  AND NOT EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = 'SV007');

-- Xem lại sau khi xóa (không còn SV007)
SELECT MaSV, HoTen, MaLop
FROM SINHVIEN;
GO

/* ---------------------------------------------------------------------
   PHẦN 3: JOIN và thống kê
   --------------------------------------------------------------------- */

-- Câu 7. Liệt kê điểm của từng sinh viên theo từng môn
SELECT sv.MaSV, sv.HoTen, mh.TenMH, kq.Diem
FROM KETQUA kq
INNER JOIN SINHVIEN sv ON kq.MaSV = sv.MaSV
INNER JOIN MONHOC   mh ON kq.MaMH = mh.MaMH
ORDER BY sv.MaSV, mh.TenMH;
GO

-- Câu 8. Tính điểm trung bình của từng sinh viên
SELECT sv.MaSV, sv.HoTen, ROUND(AVG(kq.Diem), 2) AS DiemTrungBinh
FROM SINHVIEN sv
INNER JOIN KETQUA kq ON sv.MaSV = kq.MaSV
GROUP BY sv.MaSV, sv.HoTen
ORDER BY sv.MaSV;
GO

-- Câu 9. Thống kê số sinh viên theo từng lớp
-- LEFT JOIN để lớp chưa có sinh viên vẫn xuất hiện với số lượng 0
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
ORDER BY l.MaLop;
GO

-- Câu 10. Liệt kê các lớp có từ 2 sinh viên trở lên
-- HAVING lọc sau khi đã gom nhóm
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
HAVING COUNT(sv.MaSV) >= 2
ORDER BY l.MaLop;
GO

/* ---------------------------------------------------------------------
   PHẦN 4: Kiểm thử ràng buộc dữ liệu
   Các câu INSERT dưới đây CỐ TÌNH nhập sai, kết quả đúng là SQL Server báo lỗi.
   Dùng TRY...CATCH để in thông báo lỗi và không dừng script;
   ROLLBACK để chắc chắn không có dữ liệu sai nào được lưu.
   --------------------------------------------------------------------- */

-- Câu 11. Test khóa ngoại: thêm sinh viên vào lớp CNTT99 không tồn tại (phải lỗi)
BEGIN TRY
    BEGIN TRANSACTION;
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV999', N'Sinh viên lỗi', '2005-01-01', N'Nam', 'CNTT99');
    ROLLBACK TRANSACTION;
    PRINT N'KHÔNG ĐÚNG: lệnh INSERT đã chạy được, ràng buộc khóa ngoại chưa hoạt động.';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    PRINT N'ĐÚNG - Câu 11 bị chặn bởi khóa ngoại: ' + ERROR_MESSAGE();
END CATCH
GO

-- Câu 12. Test CHECK điểm: nhập điểm 12, ngoài khoảng 0 đến 10 (phải lỗi)
-- SV004 chưa có điểm môn COMP1020 nên lỗi chỉ có thể đến từ ràng buộc điểm
BEGIN TRY
    BEGIN TRANSACTION;
    INSERT INTO KETQUA (MaSV, MaMH, Diem)
    VALUES ('SV004', 'COMP1020', 12);
    ROLLBACK TRANSACTION;
    PRINT N'KHÔNG ĐÚNG: lệnh INSERT đã chạy được, ràng buộc điểm chưa hoạt động.';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    PRINT N'ĐÚNG - Câu 12 bị chặn bởi CHECK điểm: ' + ERROR_MESSAGE();
END CATCH
GO

-- Xác nhận không có dữ liệu sai nào được lưu (cả hai phải bằng 0)
SELECT
    (SELECT COUNT(*) FROM SINHVIEN WHERE MaSV = 'SV999') AS SoSV_SV999,
    (SELECT COUNT(*) FROM KETQUA WHERE MaSV = 'SV004' AND MaMH = 'COMP1020') AS SoKetQua_Loi;
GO
