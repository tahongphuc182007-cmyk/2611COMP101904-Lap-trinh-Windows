# COMP1019_Lab09_StudentCard - Lab 09 (COMP1019)

Ứng dụng Windows Forms thiết kế, xem trước và in thẻ sinh viên bằng GDI+, PrintDocument và PrintPreviewDialog.

- Họ tên: [điền họ tên]
- MSSV: [điền MSSV]
- Lớp: [điền lớp]

## Chạy chương trình
- Yêu cầu: Windows, .NET 8 SDK, Visual Studio 2022 trở lên.
- Mở `Lab09.slnx` (hoặc `Lab09.csproj`) bằng Visual Studio rồi nhấn F5, hoặc chạy `dotnet run` trong thư mục project. File `.slnx` cần Visual Studio 2022 phiên bản 17.13 trở lên.
- Muốn thử in mà không có máy in thật, chọn máy in "Microsoft Print to PDF" trong PrintDialog.

## Cách sử dụng
1. Nhập mã sinh viên, họ tên, ngày sinh, giới tính, lớp, khoa, khóa học ở vùng bên trái.
2. Nhấn "Chọn ảnh" để chọn ảnh JPG, JPEG, PNG hoặc BMP.
3. Thẻ ở vùng bên phải được vẽ lại ngay khi dữ liệu thay đổi.
4. Nhấn "Xem trước in" để mở PrintPreviewDialog, nhấn "In" để mở PrintDialog và in.
5. Nhấn "Làm mới" để đưa Form về trạng thái ban đầu.

Mã sinh viên, họ tên và ảnh đại diện là bắt buộc. Nếu thiếu, chương trình báo lỗi và không cho xem trước in hoặc in.

## Cách cài đặt
- `DrawCard(Graphics, RectangleF)` vẽ thẻ bằng GDI+ theo hệ tọa độ thiết kế cố định (856 x 540) rồi dùng `ScaleTransform` để vừa với vùng đích. Cùng một hàm này được gọi từ `pnlPreview_Paint` (vẽ lên Panel) và `printDocument1_PrintPage` (vẽ lên trang in, kích thước thẻ thật 85,6 x 54 mm), nên bản in giống hệt bản xem trước.
- Ảnh được đọc từ file vào một `Bitmap` trong bộ nhớ rồi đóng file ngay, nên không khóa file ảnh. Ảnh quá lớn được thu nhỏ nhưng giữ đúng tỉ lệ. Khi vẽ lên thẻ, ảnh được co theo tỉ lệ vừa khung ảnh nên không bị méo.
- Các đối tượng `Pen`, `Brush`, `Font`, `StringFormat` tự tạo đều dùng `using`.

## Test case
Xem file `TestCases.md`.

## Hình ảnh minh họa
Lưu ảnh chụp màn hình vào thư mục `images/` với đúng tên file dưới đây.

Form chính:

![Form chính](images/01-form-chinh.png)

Print Preview:

![Print Preview](images/02-print-preview.png)
