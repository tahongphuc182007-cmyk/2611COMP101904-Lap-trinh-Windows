# ShopManagerMini - Lab 07 (COMP1019)

Ứng dụng WinForms quản lý cửa hàng mini nhiều Form (SDI + MDI), dữ liệu lưu trong bộ nhớ.

## Chạy chương trình
- Yêu cầu: Windows, .NET 8 SDK, Visual Studio 2022 trở lên.
- Mở `Lab07.csproj` bằng Visual Studio rồi nhấn F5, hoặc chạy `dotnet run`.

## Tài khoản mẫu
- admin / 123 (Quản trị viên, Admin)
- user / 123 (Nhân viên bán hàng, User)

## Chức năng
- FrmLogin: kiểm tra bỏ trống, kiểm tra tài khoản, trả DialogResult.OK khi thành công.
- FrmMain (MDI Parent): menu Hệ thống, Danh mục, Trợ giúp; StatusStrip hiển thị tên người dùng, vai trò, thời gian; không mở trùng Form con; hỏi xác nhận khi thoát và khi đăng xuất.
- FrmProduct: thêm, sửa, xóa (có xác nhận), làm mới, tìm kiếm theo mã hoặc tên; không trùng mã, không âm đơn giá và số lượng.
- FrmCustomer: thêm khách hàng và hiển thị bằng DataGridView.
- FrmAbout: thông tin ứng dụng. Cần sửa hai hằng `StudentName` và `StudentClass` trong `Forms/FrmAbout.cs`.

## Câu hỏi nộp kèm
Xem file `CauHoiNopKem.md`.
