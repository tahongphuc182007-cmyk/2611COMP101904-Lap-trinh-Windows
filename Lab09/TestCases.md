# Test case - Lab 09 (Thẻ sinh viên)

Cột "Kết quả thực tế" và "Đạt/Không đạt" cần điền sau khi chạy thử chương trình.
Để thử in, có thể chọn máy in "Microsoft Print to PDF".

| STT | Chức năng | Các bước thực hiện | Kết quả mong đợi | Kết quả thực tế | Đạt/Không đạt |
|---|---|---|---|---|---|
| TC01 | Preview theo dữ liệu nhập | Nhập mã SV và họ tên | Thẻ ở Panel bên phải cập nhật ngay khi gõ | | |
| TC02 | Preview khi đổi lựa chọn | Đổi giới tính, lớp, khoa, khóa học và ngày sinh | Thẻ hiển thị đúng giá trị mới | | |
| TC03 | Chọn ảnh hợp lệ | Nhấn "Chọn ảnh", chọn file JPG | Ảnh hiện trong PictureBox và trên thẻ, không bị méo | | |
| TC04 | Lọc loại file | Mở hộp thoại chọn ảnh, xem danh sách file | Chỉ hiện file JPG, JPEG, PNG, BMP | | |
| TC05 | Ảnh ngang và ảnh dọc | Lần lượt chọn một ảnh ngang và một ảnh dọc | Cả hai đều giữ đúng tỉ lệ, có viền trắng thay vì bị kéo giãn | | |
| TC06 | Đổi ảnh, không khóa file | Chọn ảnh A, chọn ảnh B, rồi xóa hoặc đổi tên file ảnh A trong Explorer | Không báo lỗi, file ảnh A thao tác được bình thường | | |
| TC07 | Chọn file không phải ảnh | Đổi bộ lọc sang All files, chọn file .txt đổi đuôi thành .jpg | Hiện thông báo lỗi ảnh, chương trình không bị treo, ảnh cũ giữ nguyên | | |
| TC08 | Thiếu mã sinh viên | Để trống mã SV, nhập họ tên, chọn ảnh, nhấn "Xem trước in" | Hiện cảnh báo thiếu mã sinh viên, có biểu tượng lỗi cạnh ô mã SV, không mở Print Preview | | |
| TC09 | Thiếu họ tên | Nhập mã SV, chọn ảnh, để trống họ tên, nhấn "In" | Hiện cảnh báo thiếu họ tên, không mở PrintDialog | | |
| TC10 | Thiếu ảnh | Nhập mã SV và họ tên, không chọn ảnh, nhấn "Xem trước in" | Hiện cảnh báo thiếu ảnh đại diện, không mở Print Preview | | |
| TC11 | Thiếu cả ba dữ liệu | Để trống tất cả, nhấn "In" | Một thông báo liệt kê đủ ba mục thiếu, con trỏ về ô mã SV | | |
| TC12 | Xem trước khi in | Nhập đủ dữ liệu, nhấn "Xem trước in" | Mở PrintPreviewDialog, thẻ có khung, tiêu đề, ảnh và thông tin, ảnh không méo | | |
| TC13 | In | Nhập đủ dữ liệu, nhấn "In", chọn Microsoft Print to PDF | Mở PrintDialog, in ra file PDF có thẻ đúng nội dung | | |
| TC14 | Làm mới | Nhập dữ liệu, chọn ảnh, nhấn "Làm mới" | Ô nhập trống, ảnh bị xóa, các ComboBox về mục đầu, thẻ về trạng thái ban đầu | | |
| TC15 | Thay đổi kích thước Form | Kéo to, thu nhỏ Form | Thẻ trong Panel luôn đúng tỉ lệ, nằm giữa, không biến dạng | | |
