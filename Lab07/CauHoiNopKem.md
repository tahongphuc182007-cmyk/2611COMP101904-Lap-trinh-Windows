# Câu hỏi nộp kèm - Lab 07

**1. SDI và MDI khác nhau như thế nào?**

SDI (Single Document Interface) là mô hình mà mỗi Form là một cửa sổ độc lập, ngang hàng, không có cửa sổ cha chứa các cửa sổ khác (ví dụ Notepad). MDI (Multiple Document Interface) có một Form cha với IsMdiContainer = true, các Form con được mở bên trong vùng làm việc của Form cha, không kéo ra ngoài được, thu nhỏ hoặc đóng cùng Form cha, và có thể sắp xếp bằng LayoutMdi (Cascade, Tile). Trong bài lab này, FrmMain là MDI Parent còn FrmProduct, FrmCustomer, FrmAbout là Form con.

**2. Vì sao Form đăng nhập nên dùng ShowDialog()?**

ShowDialog() mở Form ở chế độ modal, nghĩa là người dùng phải xử lý xong Form đăng nhập thì chương trình mới chạy tiếp, nên không thể vào FrmMain khi chưa đăng nhập. Hàm này cũng trả về DialogResult, nhờ đó Program biết đăng nhập thành công (OK) hay người dùng đã thoát (Cancel) để quyết định có mở FrmMain hay không.

**3. Trong bài lab này, dữ liệu user được truyền từ FrmLogin sang FrmMain bằng cách nào?**

Khi đăng nhập đúng, FrmLogin gán người dùng tìm được vào property CurrentUser rồi đặt DialogResult = OK. Sau khi ShowDialog() trả về OK, Program đọc login.CurrentUser và truyền sang FrmMain qua constructor FrmMain(User user). FrmMain lưu vào biến currentUser và hiển thị họ tên, vai trò trên StatusStrip.

**4. Nếu người dùng bấm menu sản phẩm nhiều lần, chương trình xử lý như thế nào để không mở trùng Form?**

Hàm OpenChildForm<T> trong FrmMain duyệt danh sách MdiChildren. Nếu đã có Form thuộc kiểu T thì chỉ khôi phục (nếu đang thu nhỏ) và gọi Activate() rồi thoát hàm, không tạo Form mới. Chỉ khi chưa có Form cùng loại thì mới tạo, gán MdiParent = this và Show(). Khi Form con bị đóng, nó không còn nằm trong MdiChildren nên lần bấm sau sẽ tạo mới.

**5. Khi nào nên dùng constructor, khi nào nên dùng property để truyền dữ liệu giữa các Form?**

Dùng constructor khi dữ liệu là bắt buộc để Form hoạt động và chỉ cần gán một lần lúc tạo, ví dụ FrmMain nhận User, FrmProduct và FrmCustomer nhận danh sách dữ liệu. Dùng property khi dữ liệu là tùy chọn, cần gán hoặc đọc sau khi Form đã được tạo, hoặc để lấy kết quả từ Form con trả về, ví dụ FrmLogin.CurrentUser được Program đọc sau khi ShowDialog() kết thúc.
