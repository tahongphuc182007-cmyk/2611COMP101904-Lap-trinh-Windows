# Lab 01 - Ứng dụng Thông tin cá nhân

**Học phần:** 2611COMP101904 - Lập trình trên Windows
**Sinh viên:** *(điền tên bạn ở đây)*
**Công nghệ:** C# - Windows Forms App (.NET 8)

## 1. Mô tả

Ứng dụng Windows Forms cho phép nhập thông tin cá nhân của sinh viên (họ tên, năm sinh, email, giới
tính, khoa/lớp), kiểm tra tính hợp lệ của dữ liệu, sau đó hiển thị thông tin tổng hợp khi người dùng
nhấn nút **Hiển thị**.

## 2. Danh sách control

| STT | Control | Tên | Chức năng |
|---|---|---|---|
| 1 | Label | `lblTitle` | Tiêu đề chương trình |
| 2 | TextBox | `txtHoTen` | Nhập họ tên |
| 3 | TextBox | `txtNamSinh` | Nhập năm sinh |
| 4 | TextBox | `txtEmail` | Nhập email |
| 5 | RadioButton | `radNam`, `radNu` | Chọn giới tính (trong `grpGioiTinh`) |
| 6 | ComboBox | `cboKhoa` | Chọn khoa/lớp |
| 7 | Button | `btnHienThi` | Kiểm tra và hiển thị thông tin |
| 8 | Button | `btnXoa` | Xóa toàn bộ dữ liệu đã nhập |
| 9 | Button | `btnThoat` | Thoát chương trình (có xác nhận) |
| 10 | TextBox | `txtKetQua` | Hiển thị kết quả tổng hợp |

## 3. Kiểm tra dữ liệu

- Họ tên không được rỗng.
- Năm sinh không được rỗng, phải là số nguyên, trong khoảng 1900 đến năm hiện tại.
- Email không được rỗng.
- Phải chọn giới tính.
- Phải chọn khoa/lớp.

Nếu có lỗi, chương trình hiển thị `MessageBox` liệt kê tất cả các lỗi cùng lúc.

## 4. Cách chạy chương trình

1. Mở file `Lab01_ThongTinCaNhan.csproj` bằng Visual Studio (yêu cầu .NET 8 SDK + workload
   ".NET Desktop Development").
2. Nhấn **F5** hoặc **Start** để build và chạy.

## 5. Kết quả chạy chương trình

*(Chèn ảnh chụp màn hình chương trình vào đây, ví dụ:)*

- Ảnh giao diện ban đầu:
  `![Giao diện ban đầu](images/giao-dien-ban-dau.png)`

- Ảnh khi nhập đầy đủ thông tin và nhấn Hiển thị:
  `![Kết quả hiển thị](images/ket-qua-hien-thi.png)`

- Ảnh thông báo lỗi khi nhập thiếu/sai dữ liệu:
  `![Thông báo lỗi](images/thong-bao-loi.png)`

- Ảnh khi nhấn nút Xóa:
  `![Sau khi xóa](images/sau-khi-xoa.png)`

- Ảnh hộp thoại xác nhận khi nhấn Thoát:
  `![Xác nhận thoát](images/xac-nhan-thoat.png)`

*(Mô tả ngắn gọn kết quả từng ảnh ở đây sau khi bạn chạy chương trình và chụp màn hình thực tế.)*

## 6. Ví dụ dữ liệu mẫu

Nhập: Họ tên = `Nguyễn Văn A`, Năm sinh = `2000`, Email = `ngueynvana@example.com`, Giới tính = `Nam`,
Khoa = `Công nghệ thông tin`.

Kết quả hiển thị:

```
THÔNG TIN SINH VIÊN
Họ tên: Nguyễn Văn A
Tuổi: 26
Email: nguyenvana@example.com
Giới tính: Nam
Khoa/Lớp: Công nghệ thông tin
```
