using System.ComponentModel;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms;

public partial class FrmMain : Form
{
    private readonly User currentUser;

    // Dữ liệu dùng chung, FrmMain giữ và truyền vào Form con qua constructor
    // để dữ liệu không bị mất khi đóng rồi mở lại Form con.
    private readonly BindingList<Product> products = new BindingList<Product>();
    private readonly BindingList<Customer> customers = new BindingList<Customer>();

    /// <summary>Đúng khi người dùng chọn Đăng xuất (Program sẽ hiện lại FrmLogin).</summary>
    public bool IsLoggingOut { get; private set; }

    // Nhận thông tin người dùng từ FrmLogin (qua Program) bằng constructor
    public FrmMain(User user)
    {
        InitializeComponent();
        currentUser = user;
    }

    private void FrmMain_Load(object? sender, EventArgs e)
    {
        SeedData();

        lblNguoiDung.Text = $"Người dùng: {currentUser.FullName}";
        lblVaiTro.Text = $"Vai trò: {currentUser.Role}";
        UpdateTime();
        timer1.Start();
    }

    private void SeedData()
    {
        products.Add(new Product { MaSP = "SP01", TenSP = "Nước suối", LoaiSP = "Đồ uống", DonGia = 5000, SoLuong = 120 });
        products.Add(new Product { MaSP = "SP02", TenSP = "Mì gói", LoaiSP = "Thực phẩm", DonGia = 4500, SoLuong = 200 });
        products.Add(new Product { MaSP = "SP03", TenSP = "Bút bi", LoaiSP = "Văn phòng phẩm", DonGia = 3000, SoLuong = 80 });

        customers.Add(new Customer { MaKH = "KH01", HoTen = "Nguyễn Văn An", SoDienThoai = "0901234567", LoaiKH = "Thường" });
        customers.Add(new Customer { MaKH = "KH02", HoTen = "Trần Thị Bình", SoDienThoai = "0912345678", LoaiKH = "VIP" });
    }

    private void UpdateTime()
    {
        lblThoiGian.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
    }

    private void timer1_Tick(object? sender, EventArgs e)
    {
        UpdateTime();
    }

    /// <summary>
    /// Mở Form con MDI. Nếu đã có Form cùng loại thì kích hoạt Form cũ, không tạo Form mới.
    /// </summary>
    private void OpenChildForm<T>(Func<T> createForm) where T : Form
    {
        foreach (Form child in MdiChildren)
        {
            if (child is T)
            {
                if (child.WindowState == FormWindowState.Minimized)
                    child.WindowState = FormWindowState.Normal;
                child.Activate();
                return;
            }
        }

        T form = createForm();
        form.MdiParent = this;
        form.Show();
    }

    // ---------- Menu ----------
    private void mnuSanPham_Click(object? sender, EventArgs e)
    {
        OpenChildForm(() => new FrmProduct(products));
    }

    private void mnuKhachHang_Click(object? sender, EventArgs e)
    {
        OpenChildForm(() => new FrmCustomer(customers));
    }

    private void mnuGioiThieu_Click(object? sender, EventArgs e)
    {
        OpenChildForm(() => new FrmAbout());
    }

    private void mnuDangXuat_Click(object? sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận đăng xuất",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            IsLoggingOut = true;
            Close();
        }
    }

    private void mnuThoat_Click(object? sender, EventArgs e)
    {
        Close(); // việc hỏi xác nhận được xử lý trong FormClosing
    }

    private void FrmMain_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (IsLoggingOut) return;                         // đã xác nhận ở bước đăng xuất
        if (e.CloseReason != CloseReason.UserClosing) return; // tắt máy, đóng bởi hệ thống

        DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Xác nhận thoát",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.No) e.Cancel = true;
    }
}
