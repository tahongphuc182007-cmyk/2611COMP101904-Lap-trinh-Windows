# CourseRegistrationApp - Lab 05 (COMP1019)

Ứng dụng Windows Forms đăng ký khóa học. Dữ liệu chỉ xử lý trên Form, không lưu cơ sở dữ liệu.

- Họ tên: [điền họ tên]
- MSSV: [điền MSSV]
- Lớp: [điền lớp]

## Chạy chương trình
- Yêu cầu: Windows, .NET 8 SDK, Visual Studio 2022 trở lên.
- Mở `Lab05.csproj` bằng Visual Studio rồi nhấn F5, hoặc chạy `dotnet run` trong thư mục project.

## Dữ liệu khóa học
| Khóa học | Học phí/tháng |
|---|---|
| C# WinForms cơ bản | 800.000 VNĐ |
| SQL Server cơ bản | 700.000 VNĐ |
| Web Frontend cơ bản | 750.000 VNĐ |
| Lập trình Python cơ bản | 650.000 VNĐ |

## Control và tên control
| Nhóm | Control | Tên |
|---|---|---|
| Thông tin học viên | TextBox | txtHoTen |
| Thông tin học viên | TextBox | txtSoDienThoai |
| Thông tin học viên | DateTimePicker | dtpNgaySinh |
| Thông tin học viên | CheckBox | chkNhanEmail |
| Thông tin khóa học | ComboBox | cboKhoaHoc |
| Thông tin khóa học | RadioButton | radOnline, radOffline |
| Thông tin khóa học | NumericUpDown | numSoThang |
| Thông tin khóa học | Label | lblTongTien |
| Nút lệnh | Button | btnDangKy, btnLamMoi, btnThoat |

Hai GroupBox: `gbHocVien` và `gbKhoaHoc`.

## Chức năng
- Form Load: nạp 4 khóa học vào ComboBox, chọn khóa đầu tiên, chọn Online, số tháng từ 1 đến 12, hiển thị tổng học phí ban đầu.
- Tổng học phí tự cập nhật khi đổi khóa học (SelectedIndexChanged) hoặc đổi số tháng (ValueChanged).
- Đăng ký: kiểm tra họ tên, số điện thoại, khóa học; hiển thị phiếu đăng ký bằng MessageBox.
- Làm mới: đưa toàn bộ dữ liệu về giá trị mặc định và đưa con trỏ về ô họ tên.
- Thoát: hỏi xác nhận, chỉ đóng Form khi chọn Yes.

## Hình ảnh minh họa
Lưu ảnh chụp màn hình vào thư mục `images/` với đúng tên file dưới đây.

Giao diện khi mở chương trình:

![Giao diện chính](images/01-giao-dien.png)

Báo lỗi khi để trống họ tên hoặc số điện thoại:

![Báo lỗi](images/02-bao-loi.png)

Tổng học phí thay đổi khi đổi khóa học và số tháng:

![Tính học phí](images/03-tinh-hoc-phi.png)

Phiếu đăng ký:

![Phiếu đăng ký](images/04-phieu-dang-ky.png)

Hộp thoại xác nhận thoát:

![Xác nhận thoát](images/05-xac-nhan-thoat.png)
