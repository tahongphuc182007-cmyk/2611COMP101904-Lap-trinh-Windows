# ProductManager - Lab 05 (COMP1019)

Ứng dụng Windows Forms quản lý sản phẩm, dữ liệu lưu trong bộ nhớ (BindingList + BindingSource).


## Chức năng
- Load form: nạp 4 loại sản phẩm vào ComboBox và 3 sản phẩm mẫu vào DataGridView.
- Thêm / Sửa / Xóa (có hộp thoại xác nhận) / Tìm kiếm theo mã hoặc tên (không phân biệt hoa thường) / Làm mới.
- Validation bằng ErrorProvider và MessageBox: mã và tên không rỗng, mã không trùng, đơn giá > 0, số lượng >= 0, ngày nhập không lớn hơn hôm nay. Khi sửa, không cho đổi mã sản phẩm.
- Chọn ảnh bằng OpenFileDialog, hiển thị trong PictureBox.
- StatusStrip hiển thị trạng thái thao tác và số lượng sản phẩm.
- ContextMenuStrip trên DataGridView: Sửa, Xóa, Xem chi tiết.
- Phím tắt: Ctrl+N (Thêm), Ctrl+E (Sửa), Ctrl+D (Xóa), F5 (Làm mới), Ctrl+F (Tìm kiếm), phím Delete trên lưới để xóa.

## Cấu trúc
- `Product.cs`: class dữ liệu.
- `FrmProduct.cs`: xử lý sự kiện và các hàm ValidateInput, ClearInput, LoadProductToForm, UpdateStatus.
- `FrmProduct.Designer.cs`: bố cục giao diện.
