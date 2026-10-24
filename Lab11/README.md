# COMP1019_Buoi11_Lab11 - Lab 11 (COMP1019)

Ứng dụng Windows Forms quản lý lớp học, kết nối SQL Server bằng ADO.NET (`Microsoft.Data.SqlClient`). Dữ liệu lưu trong bảng `LOP` của database `EduManagerDB`.

- Họ tên: [điền họ tên]
- MSSV: [điền MSSV]
- Lớp: [điền lớp]

## Cách chạy
1. Cài SQL Server (bản Express miễn phí là đủ) và SQL Server Management Studio (SSMS).
2. Trong SSMS, mở và chạy file `Database/EduManagerDB.sql`. Script **xóa database `EduManagerDB` cũ (nếu có, kể cả của Lab 10) rồi tạo lại** với 2 bảng `LOP`, `SINHVIEN` và dữ liệu mẫu.
3. Kiểm tra chuỗi kết nối trong file `appsettings.json` (xem mục dưới).
4. Mở `Lab11.slnx` (Visual Studio 2022 phiên bản 17.13 trở lên) hoặc `Lab11.csproj`, nhấn F5. Lần đầu build cần Internet để tải gói NuGet `Microsoft.Data.SqlClient`.

## Connection string
Chuỗi kết nối nằm trong `appsettings.json`, đổi được mà không cần biên dịch lại. Giá trị mặc định của project:

```
Data Source=.;Initial Catalog=EduManagerDB;Integrated Security=True;TrustServerCertificate=True
```

- `Data Source=.` là SQL Server mặc định trên máy. Nếu dùng SQL Server Express thì đổi thành `.\\SQLEXPRESS` (trong file JSON phải viết hai dấu gạch chéo ngược).
- Chuỗi kết nối đang dùng trên máy của tôi: [điền lại nếu khác mặc định ở trên]

## Chức năng
| Mã | Chức năng | Cách cài đặt |
|---|---|---|
| F1 | Tự động load danh sách lớp khi mở Form | `FrmLop_Load` gọi `LoadData()`, câu SELECT kèm `LEFT JOIN` để đếm số sinh viên mỗi lớp |
| F2 | Chọn dòng đổ dữ liệu lên Form | `dgvLop_CellClick`, ô mã lớp bị khóa vì là khóa chính |
| F3 | Thêm lớp | `ValidateInput` kiểm tra rỗng, `IsMaLopExists` kiểm tra trùng mã |
| F4 | Sửa tên lớp | Không cho sửa khi chưa chọn lớp, chỉ sửa tên lớp |
| F5 | Xóa lớp | Hỏi xác nhận; `CountSinhVienByLop` chặn xóa lớp đang có sinh viên, có bắt thêm lỗi khóa ngoại (547) |
| F6 | Tìm kiếm theo mã hoặc tên | `LIKE` với parameter, các ký tự `%`, `_`, `[` được escape để tìm đúng nghĩa đen |
| F7 | Làm mới | Xóa các ô nhập, mở khóa ô mã lớp, load lại dữ liệu |
| F8 | Dùng SqlParameter | Mọi câu SQL nhận dữ liệu từ người dùng đều dùng `Parameters.Add` với kiểu dữ liệu và độ dài cụ thể, không nối chuỗi |

## Test case
Xem file `TestCases.md` (17 test case).

## Hình ảnh chạy thử
Lưu ảnh chụp màn hình vào thư mục `images/` với đúng tên file dưới đây.

TC01 - Form đang load dữ liệu từ SQL Server:

![Load dữ liệu](images/01-load-du-lieu.png)

TC02 - Thêm lớp hợp lệ:

![Thêm hợp lệ](images/02-them-hop-le.png)

TC03 - Thêm khi thiếu mã lớp:

![Thiếu mã lớp](images/03-them-thieu-ma.png)

TC05 - Thêm trùng mã lớp:

![Trùng mã lớp](images/04-them-trung-ma.png)

TC07 - Sửa tên lớp:

![Sửa hợp lệ](images/05-sua-hop-le.png)

TC12 - Xóa lớp chưa có sinh viên:

![Xóa lớp chưa có sinh viên](images/06-xoa-chua-co-sv.png)

TC10 - Xóa lớp đang có sinh viên bị chặn:

![Xóa lớp có sinh viên](images/07-xoa-lop-co-sv.png)

TC13 - Tìm kiếm theo mã hoặc tên:

![Tìm kiếm](images/08-tim-kiem.png)
