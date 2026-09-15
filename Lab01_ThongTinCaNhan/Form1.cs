namespace Lab01_ThongTinCaNhan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KhoiTaoDuLieuMacDinh();
        }

        /// <summary>
        /// Khởi tạo dữ liệu mặc định cho ComboBox khoa/lớp khi Form được mở.
        /// </summary>
        private void KhoiTaoDuLieuMacDinh()
        {
            cboKhoa.Items.Clear();
            cboKhoa.Items.Add("Công nghệ thông tin");
            cboKhoa.Items.Add("Kỹ thuật phần mềm");
            cboKhoa.Items.Add("Hệ thống thông tin");
            cboKhoa.Items.Add("An toàn thông tin");
            cboKhoa.SelectedIndex = -1; // Chưa chọn khoa/lớp nào
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng nhấn nút "Hiển thị".
        /// Kiểm tra hợp lệ dữ liệu nhập, nếu hợp lệ thì hiển thị thông tin sinh viên.
        /// </summary>
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            // Danh sách các lỗi (nếu có) để thông báo cho người dùng
            var loiKiemTra = KiemTraDuLieu(out int namSinh);

            if (loiKiemTra.Count > 0)
            {
                // Có lỗi -> hiển thị MessageBox liệt kê tất cả lỗi
                string thongBaoLoi = "Vui lòng kiểm tra lại các thông tin sau:\n\n- " +
                                      string.Join("\n- ", loiKiemTra);
                MessageBox.Show(thongBaoLoi, "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Dữ liệu hợp lệ -> tính tuổi và hiển thị kết quả
            int namHienTai = DateTime.Now.Year;
            int tuoi = namHienTai - namSinh;
            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";

            string ketQua =
                "THÔNG TIN SINH VIÊN\r\n" +
                $"Họ tên: {txtHoTen.Text.Trim()}\r\n" +
                $"Tuổi: {tuoi}\r\n" +
                $"Email: {txtEmail.Text.Trim()}\r\n" +
                $"Giới tính: {gioiTinh}\r\n" +
                $"Khoa/Lớp: {cboKhoa.SelectedItem}";

            txtKetQua.Text = ketQua;
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của toàn bộ dữ liệu nhập.
        /// Trả về danh sách các thông báo lỗi (rỗng nếu dữ liệu hợp lệ).
        /// </summary>
        /// <param name="namSinh">Giá trị năm sinh sau khi chuyển đổi thành công (nếu hợp lệ).</param>
        private List<string> KiemTraDuLieu(out int namSinh)
        {
            var loi = new List<string>();
            namSinh = 0;

            // Kiểm tra họ tên không được rỗng
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                loi.Add("Họ tên không được để trống.");
            }

            // Kiểm tra năm sinh: không rỗng, phải là số nguyên, nằm trong khoảng hợp lệ
            if (string.IsNullOrWhiteSpace(txtNamSinh.Text))
            {
                loi.Add("Năm sinh không được để trống.");
            }
            else if (!int.TryParse(txtNamSinh.Text.Trim(), out namSinh))
            {
                loi.Add("Năm sinh phải là số nguyên.");
            }
            else
            {
                int namHienTai = DateTime.Now.Year;
                if (namSinh < 1900 || namSinh > namHienTai)
                {
                    loi.Add($"Năm sinh phải nằm trong khoảng từ 1900 đến {namHienTai}.");
                }
            }

            // Kiểm tra email không được rỗng
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                loi.Add("Email không được để trống.");
            }

            // Kiểm tra đã chọn giới tính chưa
            if (!radNam.Checked && !radNu.Checked)
            {
                loi.Add("Vui lòng chọn giới tính.");
            }

            // Kiểm tra đã chọn khoa/lớp chưa
            if (cboKhoa.SelectedIndex == -1)
            {
                loi.Add("Vui lòng chọn khoa hoặc lớp.");
            }

            return loi;
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng nhấn nút "Xóa".
        /// Đưa toàn bộ Form về trạng thái nhập liệu ban đầu.
        /// </summary>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtNamSinh.Clear();
            txtEmail.Clear();

            radNam.Checked = false;
            radNu.Checked = false;

            cboKhoa.SelectedIndex = -1; // Không chọn khoa/lớp nào

            txtKetQua.Clear();

            txtHoTen.Focus(); // Đưa con trỏ về ô họ tên để nhập lại
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng nhấn nút "Thoát".
        /// Hỏi xác nhận trước khi đóng chương trình.
        /// </summary>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ketQuaXacNhan = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQuaXacNhan == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
