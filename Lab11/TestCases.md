# Test case - Lab 11 (Quản lý lớp học)

Chạy `Database/EduManagerDB.sql` trước khi test. Cột "Kết quả thực tế" và "Đạt/Không đạt" cần điền sau khi chạy thử chương trình.

| STT | Tình huống | Các bước và dữ liệu test | Kết quả mong đợi | Kết quả thực tế | Đạt/Không đạt |
|---|---|---|---|---|---|
| TC01 | Load Form | Mở chương trình | DataGridView hiện 3 lớp CNTT01 (2 sinh viên), CNTT02 (0), SPTIN01 (0) | | |
| TC02 | Thêm hợp lệ | MaLop = TEST01, TenLop = Lớp test, nhấn Thêm | Báo thêm thành công, lớp TEST01 xuất hiện trong danh sách, các ô nhập được xóa | | |
| TC03 | Thêm thiếu mã | Để trống MaLop, nhập TenLop, nhấn Thêm | Thông báo nhập mã lớp, con trỏ về ô mã lớp, không thêm | | |
| TC04 | Thêm thiếu tên | Nhập MaLop = TEST02, để trống TenLop, nhấn Thêm | Thông báo nhập tên lớp, không thêm | | |
| TC05 | Thêm trùng mã | MaLop = CNTT01, nhấn Thêm | Thông báo mã lớp đã tồn tại, không thêm | | |
| TC06 | Chọn dòng | Nhấp vào dòng TEST01 | Mã lớp và tên lớp hiện lên hai ô nhập, ô mã lớp bị khóa | | |
| TC07 | Sửa hợp lệ | Chọn TEST01, đổi tên lớp, nhấn Sửa | Báo cập nhật thành công, danh sách hiện tên mới | | |
| TC08 | Sửa khi chưa chọn lớp | Nhấn Làm mới, rồi nhấn Sửa | Thông báo chọn lớp cần sửa, không lỗi chương trình | | |
| TC09 | Xóa khi chưa chọn lớp | Nhấn Làm mới, rồi nhấn Xóa | Thông báo chọn lớp cần xóa, không lỗi chương trình | | |
| TC10 | Xóa lớp đang có sinh viên | Chọn CNTT01, nhấn Xóa | Thông báo không thể xóa lớp đang có sinh viên, lớp vẫn còn | | |
| TC11 | Xóa, chọn Không | Chọn TEST01, nhấn Xóa, chọn No ở hộp xác nhận | Lớp không bị xóa | | |
| TC12 | Xóa lớp chưa có sinh viên | Chọn TEST01, nhấn Xóa, chọn Yes | Báo xóa thành công, TEST01 biến mất khỏi danh sách | | |
| TC13 | Tìm kiếm theo mã | Nhập CNTT, nhấn Tìm kiếm | Hiện CNTT01 và CNTT02 | | |
| TC14 | Tìm kiếm theo tên, không phân biệt hoa thường | Nhập "sư phạm", nhấn Tìm kiếm | Hiện SPTIN01 | | |
| TC15 | Tìm kiếm không có kết quả | Nhập XYZ, nhấn Tìm kiếm | Danh sách trống, không lỗi | | |
| TC16 | Dữ liệu nhập chứa ký tự SQL (kiểm tra parameter) | Nhập `' OR 1=1 --` vào ô tìm kiếm, nhấn Tìm kiếm | Danh sách trống, không lỗi, không hiện toàn bộ lớp | | |
| TC17 | Làm mới | Chọn một dòng, gõ vào ô tìm kiếm, nhấn Làm mới | Các ô nhập và ô tìm kiếm được xóa, ô mã lớp được mở khóa, danh sách tải lại đầy đủ | | |
