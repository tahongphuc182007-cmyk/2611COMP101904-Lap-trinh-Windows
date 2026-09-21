# Bài tập trên lớp - Quản lý nhân viên

## Thông tin sinh viên

* Họ tên: Tạ Hồng Phúc
* MSSV: 51.01.104.076
* Lớp: 51.01.CNTT.A

## Mô tả bài toán

Xây dựng ứng dụng Console C# quản lý tiền lương nhân viên ứng dụng đầy đủ các tính chất Lập trình hướng đối tượng (OOP):

* **Tính đóng gói (Encapsulation):** Bảo vệ dữ liệu qua các Property.
* **Tính kế thừa (Inheritance):** Xây dựng các lớp nhân viên kế thừa từ lớp cơ sở `NhanVien`.
* **Tính đa hình (Polymorphism):** Sử dụng `virtual` và `override` cho phương thức tính lương và hiển thị thông tin.

## Các chức năng chính

1. Xuất danh sách nhân viên áp dụng tính đa hình.
2. Tìm nhân viên theo mã.
3. Tìm nhân viên có lương cao nhất.
4. Tính tổng lương công ty phải trả.

## Các lớp nhân viên

* `NhanVien`: lớp cơ sở, gồm `MaNhanVien`, `HoTen`, `LuongCoBan` (> 0).
* `NhanVienVanPhong`: kế thừa `NhanVien`, thêm `SoNgayLamViec` (0–31). Lương = Lương cơ bản + Số ngày làm việc × 200.000.
* `NhanVienKinhDoanh`: kế thừa `NhanVien`, thêm `DoanhSo` (≥ 0). Lương = Lương cơ bản + 5% × Doanh số.
* `NhanVienThoiVu` (bonus): kế thừa `NhanVien`, thêm `SoGioLam`, `LuongTheoGio`. Lương = Số giờ làm × Lương theo giờ.

## Ghi chú kỹ thuật

Các chức năng xuất danh sách, tìm lương cao nhất và tính tổng lương chỉ thao tác qua kiểu `NhanVien`, gọi `TinhLuong()` / `HienThiThongTin()` — không dùng `if`/`switch` để kiểm tra loại nhân viên. Nhờ vậy thêm `NhanVienThoiVu` không cần sửa thuật toán tìm lương cao nhất hay tính tổng lương.

## Chạy chương trình

```bash
dotnet run
```
