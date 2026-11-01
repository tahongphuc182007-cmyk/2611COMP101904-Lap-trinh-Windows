# StudentReportDemo - Lab 13 (COMP1019)

Module Báo cáo danh sách sinh viên theo lớp bằng C# WinForms và LINQ. Dữ liệu mẫu nằm trong bộ nhớ (12 sinh viên, 3 lớp), không cần database.

- Họ tên: Tạ Hồng Phúc
- MSSV: 51.01.104.076
- Lớp: 51.01.CNTT.A

## Cách chạy
- Yêu cầu: Windows, .NET 8 SDK, Visual Studio 2022 trở lên.
- Mở `Lab13.slnx` (Visual Studio 2022 phiên bản 17.13 trở lên) hoặc `Lab13.csproj`, nhấn F5. Hoặc chạy `dotnet run` trong thư mục project.

## Cách sử dụng
1. Chọn lớp, chọn kết quả (Tất cả, Đạt, Không đạt), có thể nhập từ khóa là mã sinh viên hoặc họ tên (không phân biệt hoa thường), rồi bấm **Xem báo cáo** (hoặc nhấn Enter trong ô từ khóa).
2. Bấm **Thống kê theo lớp** để xem số sinh viên, số đạt, số không đạt và điểm trung bình của từng lớp.
3. Bấm **Xuất file** để lưu dữ liệu đang hiển thị ra file CSV hoặc TXT. File CSV dùng dấu phẩy, file TXT dùng tab, cả hai là UTF-8 có BOM.
4. Dòng cuối cửa sổ hiện số dòng đang hiển thị, tổng sinh viên của lớp, số đạt, số không đạt và điểm trung bình.

Nếu mở file CSV bằng cách nhấp đôi trong Excel mà tất cả dữ liệu dồn vào một cột (do cài đặt vùng Việt Nam dùng dấu chấm phẩy làm dấu ngăn cách), hãy dùng Excel > Data > From Text/CSV và chọn dấu ngăn cách là Comma.

## LINQ được dùng ở đâu
| Toán tử | Vị trí | Mục đích |
|---|---|---|
| `Select`, `Distinct`, `OrderBy` | `LoadComboBox` | Lấy danh sách lớp không trùng, sắp theo mã lớp |
| `Where` | `XemBaoCao` | Lọc theo lớp, kết quả, từ khóa |
| `OrderByDescending`, `ThenBy` | `XemBaoCao` | Điểm giảm dần, bằng điểm thì theo họ tên |
| `Select` | `XemBaoCao` | Chọn các cột hiển thị |
| `Count`, `Average` | `CapNhatThongKe` | Tổng số, số đạt, số không đạt, điểm trung bình |
| `GroupBy`, `Count`, `Average` | `btnThongKe_Click` | Thống kê theo lớp |

## Tổ chức code
- `Models/SinhVien.cs`: lớp `SinhVien` với `KetQua` là thuộc tính chỉ đọc tính từ `Diem`. `Models/Lop.cs`: mục của ComboBox lớp.
- `Forms/FrmBaoCaoSinhVien.cs`: các hàm `TaoDuLieuMau`, `LoadComboBox`, `XemBaoCao`, `CapNhatThongKe`, `XuatFile`, và các hàm phụ `HienThiBang`, `TaoNoiDungFile`, `BaoVeTruong`.
- Điểm dùng kiểu `decimal` để làm tròn điểm trung bình chính xác (6.825 luôn thành 6.83).
- Khi xuất file, số được ghi theo dấu chấm thập phân và trường có chứa dấu ngăn cách hoặc dấu nháy kép được đặt trong dấu nháy kép, nên dữ liệu không bị vỡ cột.
- Xuất file có xử lý lỗi `IOException` (file đang mở) và `UnauthorizedAccessException` (không có quyền ghi).

## Test case
Xem file `TestCases.md` (16 test case).

## Hình ảnh chạy thử




