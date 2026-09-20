# Quản lý nhân viên (Console C#)

Bài tập OOP: Class, Property, Constructor, Encapsulation, Kế thừa, Đa hình.

## Cấu trúc

| File | Nội dung |
|---|---|
| `NhanVien.cs` | Lớp cơ sở: `MaNV`, `HoTen`, `LuongCoBan` (> 0), `virtual TinhLuong()`, `virtual HienThiThongTin()` |
| `NhanVienVanPhong.cs` | `SoNgayLamViec` (0–31) — Lương = LuongCoBan + SoNgay × 200.000 |
| `NhanVienKinhDoanh.cs` | `DoanhSo` (≥ 0) — Lương = LuongCoBan + 5% × DoanhSo |
| `NhanVienThoiVu.cs` | (bonus) `SoGioLam`, `LuongTheoGio` — Lương = SoGioLam × LuongTheoGio |
| `TienTe.cs` | Hàm định dạng tiền |
| `Program.cs` | Nhập liệu + menu |

## Điểm cần chú ý khi chấm

- Dữ liệu được đóng gói: field `private`, truy cập qua property có kiểm tra ràng buộc (ném `ArgumentException` nếu sai).
- Lớp con dùng `base(...)` trong constructor và `override` cả `TinhLuong()` lẫn `HienThiThongTin()`.
- 4 chức năng của menu chỉ duyệt `List<NhanVien>` và gọi `TinhLuong()` / `HienThiThongTin()`, **không** dùng `if`/`switch` hay `is`/`GetType()` để phân biệt lớp con. Vì vậy thêm `NhanVienThoiVu` không phải sửa thuật toán tìm lương cao nhất và tính tổng lương.

## Chạy

```bash
dotnet run
```

## Nộp bài

```bash
# ở thư mục gốc của repo (cùng cấp với các lab)
mkdir -p BTLOP/16092026
# copy các file .cs, .csproj, README.md vào BTLOP/16092026

git add BTLOP/16092026
git commit -m "BTLOP 16092026: Quan ly nhan vien - ke thua va da hinh"
git push origin main
```
