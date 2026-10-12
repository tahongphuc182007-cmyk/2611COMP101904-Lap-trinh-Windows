using ShopManagerMini.Models;

namespace ShopManagerMini.Forms;

public partial class FrmLogin : Form
{
    // Tài khoản mẫu theo đề bài
    private readonly List<User> users = new List<User>
    {
        new User { Username = "admin", Password = "123", FullName = "Quản trị viên", Role = "Admin" },
        new User { Username = "user", Password = "123", FullName = "Nhân viên bán hàng", Role = "User" }
    };

    /// <summary>Người dùng đăng nhập thành công, Program đọc property này sau khi ShowDialog trả về OK.</summary>
    public User? CurrentUser { get; private set; }

    public FrmLogin()
    {
        InitializeComponent();
    }

    private void btnDangNhap_Click(object? sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
        {
            MessageBox.Show("Vui lòng nhập đầy đủ username và password.", "Cảnh báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        User? found = users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (found == null)
        {
            MessageBox.Show("Sai username hoặc password.", "Đăng nhập thất bại",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtPassword.Clear();
            txtPassword.Focus();
            return;
        }

        CurrentUser = found;
        DialogResult = DialogResult.OK; // đóng FrmLogin và báo thành công cho Program
    }
}
