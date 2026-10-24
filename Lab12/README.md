# QLSinhVienLab12 - Lab 12 (COMP1019)

Module Quản lý kết quả học tập bằng C# WinForms và SQL Server: chọn lớp và môn học, nhập điểm cho cả lớp trên DataGridView rồi lưu tất cả trong một transaction. Chủ đề của lab: Data Binding, Stored Procedure và Transaction.

- Họ tên: [điền họ tên]
- MSSV: [điền MSSV]
- Lớp: [điền lớp]



## Stored procedure
| Tên | Chức năng |
|---|---|
| `sp_Lop_GetAll` | Lấy danh sách lớp |
| `sp_MonHoc_GetAll` | Lấy danh sách môn học |
| `sp_KetQua_GetByLopMon` | Lấy sinh viên của lớp kèm điểm môn học. Dùng `LEFT JOIN` nên sinh viên chưa có điểm vẫn hiện, với `Diem` là NULL |
| `sp_KetQua_Save` | Đã có điểm thì UPDATE, chưa có thì INSERT |

## Cách cài đặt các yêu cầu chính
- **Data binding:** `cboLop` và `cboMonHoc` gán `DataSource` là `DataTable` với `DisplayMember`, `ValueMember` đặt trước. `dgvKetQua` nối với `BindingSource`, cột Điểm và Ghi chú được sửa trực tiếp trên lưới.
- **Kiểm tra dữ liệu:** `ValidateData` kiểm tra mọi dòng trước khi lưu: điểm không được để trống, nằm trong khoảng 0 đến 10, ghi chú tối đa 255 ký tự. Dòng lỗi được đánh dấu trên lưới và không dòng nào được lưu. Cột điểm là kiểu số nên ký tự chữ bị chặn và báo lỗi thân thiện.
- **Transaction:** `KetQuaDAL.SaveAll` mở một transaction, gọi `sp_KetQua_Save` cho từng dòng bằng cùng một `SqlCommand` đã gắn transaction, chỉ `Commit` một lần sau khi mọi dòng thành công, và `Rollback` rồi ném lại lỗi nếu có lỗi ở bất kỳ dòng nào.
- **Tham số:** mọi lời gọi stored procedure đều dùng `SqlParameter` có kiểu và độ dài cụ thể, không nối chuỗi SQL.
- **Lưu đúng môn:** môn học dùng khi lưu là môn của danh sách đã tải (`loadedMaMon`), không phụ thuộc ComboBox, để tránh lưu nhầm môn khi người dùng đổi ComboBox mà chưa tải lại.

## Test case
Xem file `TestCases.md` (14 test case).

## Hình ảnh minh chứng chạy demo
Lưu ảnh chụp màn hình vào thư mục `images/` với đúng tên file dưới đây. Câu lệnh SQL để chụp ảnh dữ liệu nằm trong `Database/DemoMinhChung.sql`.

Form sau khi tải danh sách, trước khi lưu (đã nhập điểm):

![Form trước khi lưu](images/01-form-truoc-khi-luu.png)

Form sau khi lưu thành công:

![Form sau khi lưu](images/02-form-sau-khi-luu.png)

Bảng KETQUA trong SSMS trước khi lưu:

![SQL trước khi lưu](images/03-sql-truoc-khi-luu.png)

Bảng KETQUA trong SSMS sau khi lưu:

![SQL sau khi lưu](images/04-sql-sau-khi-luu.png)

Báo lỗi khi nhập điểm không hợp lệ (ví dụ 15):

![Điểm không hợp lệ](images/05-diem-khong-hop-le.png)

Rollback khi database báo lỗi (TC10):

![Rollback](images/06-rollback.png)
