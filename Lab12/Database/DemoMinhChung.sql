/* =====================================================================
   Lab 12 - Câu lệnh hỗ trợ chụp ảnh minh chứng chạy demo
   Bôi đen và chạy TỪNG PHẦN (A, B, C) trong SSMS, không chạy cả file một lần.
   ===================================================================== */

USE QLSinhVienLab12;
GO

/* ---- PHẦN A: Xem bảng KETQUA ----
   Chạy trước khi lưu và chạy lại sau khi lưu trong ứng dụng, chụp cả hai kết quả. */
SELECT kq.MaSV, sv.HoTen, kq.MaMon, kq.Diem, kq.GhiChu
FROM KETQUA kq
JOIN SINHVIEN sv ON sv.MaSV = kq.MaSV
ORDER BY kq.MaMon, kq.MaSV;
GO

/* ---- PHẦN B: Chuẩn bị demo rollback ----
   Thêm một ràng buộc thử nghiệm: database từ chối điểm 9.99.
   Điểm 9.99 vẫn hợp lệ với kiểm tra 0 đến 10 trong ứng dụng, nên ứng dụng sẽ gửi xuống database
   và database báo lỗi ở dòng đó. Trong ứng dụng: tải CTK47A, môn COMP1019, nhập điểm hợp lệ cho các
   dòng đầu và nhập 9.99 cho dòng CUỐI CÙNG (Trần Thị Bình), bấm Lưu tất cả.
   Kết quả đúng: ứng dụng báo lỗi và rollback, chạy lại PHẦN A thấy KETQUA không thay đổi. */
ALTER TABLE KETQUA ADD CONSTRAINT CK_DEMO_ROLLBACK CHECK (Diem <> 9.99);
GO

/* ---- PHẦN C: Dọn dẹp sau khi demo rollback (bắt buộc chạy) ---- */
ALTER TABLE KETQUA DROP CONSTRAINT CK_DEMO_ROLLBACK;
GO
