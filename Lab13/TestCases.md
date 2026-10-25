# Test case - Lab 13 (Báo cáo sinh viên bằng LINQ)

Dữ liệu mẫu có 12 sinh viên của 3 lớp, mỗi lớp 4 sinh viên.
Cột "Kết quả thực tế" và "Đạt/Không đạt" cần điền sau khi chạy thử chương trình.

| STT | Tình huống | Các bước và dữ liệu test | Kết quả mong đợi | Kết quả thực tế | Đạt/Không đạt |
|---|---|---|---|---|---|
| TC01 | Load Form | Mở chương trình | cboLop có 3 lớp (CNTT K47A, K47B, K48A); cboKetQua có Tất cả, Đạt, Không đạt; lưới tự hiện báo cáo lớp K47A | | |
| TC02 | Sắp xếp giảm dần theo điểm | Chọn CNTT K47A, Tất cả, bấm Xem báo cáo | Thứ tự: Phạm Thanh Dung 9.1, Nguyễn Văn An 8.2, Trần Thị Bình 6.5, Lê Minh Cường 4.8 | | |
| TC03 | Lọc Đạt | CNTT K47A, kết quả Đạt | 3 dòng (Dung, An, Bình), không có Cường | | |
| TC04 | Lọc Không đạt | CNTT K47A, kết quả Không đạt | 1 dòng: Lê Minh Cường, cột Kết quả là "Không đạt" | | |
| TC05 | Điểm biên | CNTT K47B, kết quả Đạt | Có Đặng Minh Khôi (5.5) và các sinh viên Đạt khác, không có Võ Gia Khang (3.9) | | |
| TC06 | Tìm theo mã | CNTT K47A, Tất cả, từ khóa SV002 | 1 dòng: Trần Thị Bình | | |
| TC07 | Tìm theo họ tên, không phân biệt hoa thường | CNTT K47A, Tất cả, từ khóa "cường" | 1 dòng: Lê Minh Cường | | |
| TC08 | Kết hợp nhiều điều kiện | CNTT K47A, kết quả Đạt, từ khóa "Văn" | 1 dòng: Nguyễn Văn An | | |
| TC09 | Không có dữ liệu | CNTT K47A, Không đạt, từ khóa "Bình" | Hộp thoại thông báo không có sinh viên phù hợp, lưới trống | | |
| TC10 | Thống kê của lớp | CNTT K47A, Tất cả, bấm Xem báo cáo | Dòng dưới cùng: Tổng sinh viên của lớp 4, Đạt 3, Không đạt 1, Điểm trung bình 7.15 | | |
| TC11 | Thống kê theo lớp | Bấm Thống kê theo lớp | 3 dòng: K47A (4 SV, đạt 3, không đạt 1, ĐTB 7.15), K47B (4, 3, 1, 6.2), K48A (4, 3, 1, 6.83) | | |
| TC12 | Xuất CSV báo cáo | Xem báo cáo K47A, bấm Xuất file, lưu `BaoCaoSinhVien.csv`, mở bằng Notepad | Dòng đầu là tiêu đề cột, tiếp theo là 4 dòng dữ liệu, tiếng Việt hiển thị đúng, điểm dùng dấu chấm (ví dụ 8.2) | | |
| TC13 | Xuất CSV thống kê | Bấm Thống kê theo lớp, bấm Xuất file | File có 3 dòng dữ liệu của bảng thống kê | | |
| TC14 | Xuất TXT | Xem báo cáo, bấm Xuất file, chọn kiểu Text file | File .txt, các cột ngăn cách bằng tab | | |
| TC15 | Xuất khi file đang mở | Mở file CSV vừa xuất bằng Excel, giữ nguyên, xuất lại cùng tên | Thông báo lỗi không ghi được file, chương trình không bị đóng | | |
| TC16 | Hủy hộp thoại lưu | Bấm Xuất file rồi Cancel | Không có thông báo, không tạo file | | |
