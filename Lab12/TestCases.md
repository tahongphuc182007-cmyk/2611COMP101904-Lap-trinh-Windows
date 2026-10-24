# Test case - Lab 12 (Nhập điểm theo lớp)

Chạy `Database/QLSinhVienLab12.sql` trước khi test. Dữ liệu mẫu: lớp CTK47A có 3 sinh viên (SV001 đã có điểm 8 môn COMP1019), lớp CTK47B có 1 sinh viên.
Cột "Kết quả thực tế" và "Đạt/Không đạt" cần điền sau khi chạy thử chương trình.

| STT | Tình huống | Các bước và dữ liệu test | Kết quả mong đợi | Kết quả thực tế | Đạt/Không đạt |
|---|---|---|---|---|---|
| TC01 | Load Form | Mở chương trình | ComboBox lớp hiện tên lớp, ComboBox môn học hiện tên môn (không hiện `System.Data.DataRowView`) | | |
| TC02 | Tải danh sách có điểm sẵn | Chọn CTK47A, Lập trình trên Windows, bấm Tải danh sách | Hiện 3 sinh viên sắp theo họ tên; SV001 có điểm 8 và ghi chú "Chuyên cần tốt", hai sinh viên còn lại để trống điểm | | |
| TC03 | Lưu khi chưa có danh sách | Vừa mở chương trình, bấm Lưu tất cả | Thông báo chưa có danh sách, không lỗi chương trình | | |
| TC04 | Lưu khi còn ô điểm trống | Tải CTK47A, nhập điểm cho một sinh viên, để trống các sinh viên khác, bấm Lưu tất cả | Thông báo các dòng chưa nhập điểm, dòng lỗi có biểu tượng lỗi ở đầu dòng, không lưu dòng nào | | |
| TC05 | Điểm ngoài khoảng | Nhập 15 cho một sinh viên, các dòng còn lại hợp lệ, bấm Lưu tất cả | Thông báo "Điểm phải từ 0 đến 10" cho dòng đó, không lưu dòng nào (kiểm tra bảng KETQUA không đổi) | | |
| TC06 | Điểm âm | Nhập -1 rồi bấm Lưu tất cả | Thông báo điểm phải từ 0 đến 10, không lưu | | |
| TC07 | Điểm không phải số | Gõ chữ "abc" vào ô điểm rồi rời ô | Thông báo điểm phải là số; nhấn Esc thì ô trở về giá trị cũ | | |
| TC08 | Lưu thành công (thêm mới và cập nhật) | Nhập điểm hợp lệ cho cả 3 sinh viên (ví dụ 9, 7.5, 6), sửa ghi chú, bấm Lưu tất cả | Báo đã lưu thành công 3 dòng; trong SSMS bảng KETQUA có 3 dòng môn COMP1019, SV001 được cập nhật thay vì thêm trùng | | |
| TC09 | Tải lại sau khi lưu | Bấm Tải danh sách lần nữa | Hiện đúng các điểm vừa lưu | | |
| TC10 | Rollback khi database báo lỗi | Làm theo PHẦN B của `Database/DemoMinhChung.sql`, nhập điểm hợp lệ cho các dòng đầu và 9.99 cho dòng cuối, bấm Lưu tất cả | Ứng dụng báo lỗi và thông báo đã rollback; chạy PHẦN A thấy bảng KETQUA không thay đổi so với trước khi lưu (các dòng đầu cũng không được lưu). Sau đó chạy PHẦN C để dọn dẹp | | |
| TC11 | Cảnh báo khi có thay đổi chưa lưu | Sửa một điểm, chưa lưu, bấm Tải danh sách | Hộp thoại hỏi có bỏ thay đổi chưa lưu không; chọn No thì giữ nguyên danh sách | | |
| TC12 | Đổi môn sau khi đã tải danh sách | Tải CTK47A môn COMP1019, đổi ComboBox sang môn COMP1017 (không tải lại), nhập điểm và bấm Lưu tất cả | Điểm vẫn được lưu cho môn COMP1019 (môn của danh sách đang hiển thị), thanh trạng thái ghi rõ lớp và môn đã tải | | |
| TC13 | Lớp khác | Tải CTK47B | Hiện 1 sinh viên Phạm Thanh Dung | | |
| TC14 | Mất kết nối database | Dừng dịch vụ SQL Server rồi mở chương trình | Thông báo lỗi kết nối kèm hướng dẫn kiểm tra, chương trình không bị đóng đột ngột | | |
