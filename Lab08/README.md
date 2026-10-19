# COMP1019_Lab08_SimplePaint - Lab 08 (COMP1019)

Ứng dụng Paint đơn giản bằng Windows Forms và GDI+.

- Họ tên: [điền họ tên]
- MSSV: [điền MSSV]
- Lớp: [điền lớp]

## Chạy chương trình
- Yêu cầu: Windows, .NET 8 SDK, Visual Studio 2022 trở lên.
- Mở `Lab08.slnx` (hoặc `Lab08.csproj`) bằng Visual Studio rồi nhấn F5, hoặc chạy `dotnet run` trong thư mục project. File `.slnx` cần Visual Studio 2022 phiên bản 17.13 trở lên.

## Cách sử dụng
1. Chọn chế độ vẽ trong ComboBox: Pen, Line, Rectangle hoặc Ellipse.
2. Chọn độ dày nét từ 1 đến 20 bằng ô số.
3. Nhấn "Chọn màu" để mở hộp thoại chọn màu. Ô vuông cạnh nút cho biết màu đang dùng.
4. Giữ chuột trái và kéo trên vùng trắng để vẽ. Hình chữ nhật và ellipse vẽ được khi kéo theo mọi hướng.
5. "Undo" xóa nét vẽ gần nhất, "Clear" xóa toàn bộ.
6. Tọa độ chuột hiện ở thanh trạng thái phía dưới.

## Cách cài đặt
- `DrawItem` lưu dữ liệu gốc của mỗi nét (loại hình, màu, độ dày, điểm đầu, điểm cuối hoặc danh sách điểm của Pen).
- Danh sách `List<DrawItem> items` lưu các nét đã vẽ. Nét đang kéo chuột được giữ riêng trong `currentItem` và thêm vào danh sách khi nhả chuột.
- Toàn bộ việc vẽ nằm trong sự kiện `canvas_Paint`. Khi dữ liệu thay đổi, chương trình gọi `canvas.Invalidate()`. Vì vậy nét vẽ không mất khi resize hoặc khi cửa sổ bị che rồi hiện lại.
- `Pen` và `SolidBrush` tự tạo đều dùng `using`. Canvas dùng `DoubleBufferedPanel` để không bị nhấp nháy.

## Hình ảnh minh họa
Lưu ảnh chụp màn hình vào thư mục `images/` với đúng tên file dưới đây.

Giao diện khi mở chương trình:

![Giao diện chính](images/01-giao-dien.png)

Canvas sau khi vẽ thử đủ 4 loại hình (Pen, Line, Rectangle, Ellipse):

![Vẽ thử 4 loại hình](images/02-ve-4-loai-hinh.png)
