# EduManagerDB - Lab 10 (COMP1019)

Thiết kế và cài đặt cơ sở dữ liệu quản lý sinh viên bằng SQL Server và T-SQL.

- Họ tên: [điền họ tên]
- MSSV: [điền MSSV]
- Lớp: [điền lớp]

## Cách chạy
- Yêu cầu: SQL Server 2016 trở lên (cần cho lệnh `DROP ... IF EXISTS`) và SQL Server Management Studio (SSMS).
- Có thể mở `Lab10.slnx` bằng Visual Studio 2022 (17.13 trở lên) để xem gộp 3 file script và README. Việc chạy script vẫn thực hiện trong SSMS.
- Mở và chạy lần lượt từng file trong SSMS, theo đúng thứ tự:
  1. `01_CreateDatabase.sql`: tạo database `EduManagerDB` và 6 bảng. Script tự xóa database cũ (nếu có) nên có thể chạy lại từ đầu.
  2. `02_InsertSampleData.sql`: nhập dữ liệu mẫu.
  3. `03_Queries.sql`: 12 truy vấn theo đề.
- Câu 5 (UPDATE) và câu 6 (DELETE) làm thay đổi dữ liệu. Muốn chạy lại `03_Queries.sql` từ đầu thì chạy lại file 01 và 02 trước.

## Thiết kế cơ sở dữ liệu
| Bảng | Khóa chính | Khóa ngoại | Ràng buộc khác |
|---|---|---|---|
| KHOA | MaKhoa | không | |
| LOP | MaLop | MaKhoa -> KHOA | |
| SINHVIEN | MaSV | MaLop -> LOP | GioiTinh chỉ nhận Nam hoặc Nữ |
| MONHOC | MaMH | không | SoTinChi > 0 |
| KETQUA | (MaSV, MaMH) | MaSV -> SINHVIEN, MaMH -> MONHOC | Diem từ 0 đến 10 |
| TAIKHOAN | TenDangNhap | không | VaiTro mặc định User, TrangThai mặc định 1 |

Quan hệ: một khoa có nhiều lớp, một lớp có nhiều sinh viên, và bảng KETQUA nối sinh viên với môn học (quan hệ nhiều-nhiều). Khóa chính ghép của KETQUA ngăn nhập trùng điểm của cùng một sinh viên cho cùng một môn.

## Dữ liệu mẫu
2 khoa, 3 lớp, 7 sinh viên, 4 môn học, 8 kết quả, 2 tài khoản. SV007 cố ý chưa có điểm để thử câu 6 (xóa sinh viên chưa có điểm).

## Kết quả mong đợi của một số truy vấn
- Câu 8 (điểm trung bình): SV001 = 8.00, SV002 = 8.50, SV003 = 6.50, SV004 = 7.00, SV005 = 8.00, SV006 = 7.80.
- Câu 9 và câu 10 (sau khi câu 6 đã xóa SV007): mỗi lớp CNTT01, CNTT02, SPTIN01 có 2 sinh viên.
- Câu 11 và câu 12: SQL Server báo lỗi ràng buộc (khóa ngoại và CHECK điểm), script in dòng "ĐÚNG ..." ở tab Messages. Hai dòng đếm cuối cùng đều bằng 0.

## Ảnh chụp kết quả
Lưu ảnh chụp màn hình vào thư mục `images/` với đúng tên file dưới đây.

Object Explorer có đủ 6 bảng:

![6 bảng](images/01-object-explorer.png)

Câu 2 (JOIN sinh viên, lớp, khoa):

![Câu 2](images/02-cau2-join.png)

Câu 8 (điểm trung bình) và câu 9 (thống kê theo lớp):

![Câu 8 và 9](images/03-cau8-cau9.png)

Câu 11 và câu 12 (tab Messages hiển thị lỗi ràng buộc):

![Câu 11 và 12](images/04-test-rang-buoc.png)
