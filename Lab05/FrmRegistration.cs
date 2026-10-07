using System.Globalization;

namespace CourseRegistrationApp;

public partial class FrmRegistration : Form
{
    private static readonly CultureInfo ViCulture = new CultureInfo("vi-VN");

    // Dữ liệu khóa học theo đề bài
    private readonly List<Course> courses = new List<Course>
    {
        new Course { TenKhoa = "C# WinForms cơ bản",   HocPhiThang = 800000 },
        new Course { TenKhoa = "SQL Server cơ bản",    HocPhiThang = 700000 },
        new Course { TenKhoa = "Web Frontend cơ bản",  HocPhiThang = 750000 },
        new Course { TenKhoa = "Lập trình Python cơ bản", HocPhiThang = 650000 }
    };

    public FrmRegistration()
    {
        InitializeComponent();
    }

    // ---------- Form Load ----------
    private void FrmRegistration_Load(object? sender, EventArgs e)
    {
        cboKhoaHoc.DataSource = courses;
        cboKhoaHoc.DisplayMember = "TenKhoa";
        cboKhoaHoc.SelectedIndex = 0;

        radOnline.Checked = true;

        numSoThang.Minimum = 1;
        numSoThang.Maximum = 12;
        numSoThang.Value = 1;

        UpdateTongTien();
    }

    // ---------- Hàm hỗ trợ ----------
    private decimal CalculateTongTien()
    {
        if (cboKhoaHoc.SelectedItem is Course course)
            return course.HocPhiThang * numSoThang.Value;
        return 0;
    }

    private void UpdateTongTien()
    {
        lblTongTien.Text = FormatMoney(CalculateTongTien());
    }

    private static string FormatMoney(decimal amount)
    {
        return string.Format(ViCulture, "{0:N0} VNĐ", amount);
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtHoTen.Text))
        {
            MessageBox.Show("Họ tên không được để trống.", "Thiếu thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtHoTen.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
        {
            MessageBox.Show("Số điện thoại không được để trống.", "Thiếu thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSoDienThoai.Focus();
            return false;
        }

        if (cboKhoaHoc.SelectedItem == null)
        {
            MessageBox.Show("Vui lòng chọn khóa học.", "Thiếu thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboKhoaHoc.Focus();
            return false;
        }

        return true;
    }

    // ---------- Sự kiện ----------
    private void cboKhoaHoc_SelectedIndexChanged(object? sender, EventArgs e)
    {
        UpdateTongTien();
    }

    private void numSoThang_ValueChanged(object? sender, EventArgs e)
    {
        UpdateTongTien();
    }

    private void btnDangKy_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        Course course = (Course)cboKhoaHoc.SelectedItem!;
        string hinhThuc = radOnline.Checked ? "Online" : "Trực tiếp";
        string nhanEmail = chkNhanEmail.Checked ? "Có" : "Không";

        string phieu =
            $"Họ tên: {txtHoTen.Text.Trim()}\n" +
            $"Số điện thoại: {txtSoDienThoai.Text.Trim()}\n" +
            $"Ngày sinh: {dtpNgaySinh.Value:dd/MM/yyyy}\n" +
            $"Khóa học: {course.TenKhoa}\n" +
            $"Hình thức học: {hinhThuc}\n" +
            $"Số tháng: {numSoThang.Value}\n" +
            $"Tổng tiền: {FormatMoney(CalculateTongTien())}\n" +
            $"Nhận email thông báo: {nhanEmail}";

        MessageBox.Show(phieu, "Phiếu đăng ký khóa học",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnLamMoi_Click(object? sender, EventArgs e)
    {
        txtHoTen.Clear();
        txtSoDienThoai.Clear();
        dtpNgaySinh.Value = DateTime.Today;
        chkNhanEmail.Checked = false;
        cboKhoaHoc.SelectedIndex = 0;
        radOnline.Checked = true;
        numSoThang.Value = 1;
        UpdateTongTien();
        txtHoTen.Focus();
    }

    private void btnThoat_Click(object? sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Xác nhận thoát",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            Close();
        }
    }
}
