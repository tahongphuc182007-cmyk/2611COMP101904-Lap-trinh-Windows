#nullable disable
namespace ShopManagerMini.Forms;

partial class FrmMain
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        menuStrip1 = new MenuStrip();
        mnuHeThong = new ToolStripMenuItem();
        mnuDangXuat = new ToolStripMenuItem();
        mnuThoat = new ToolStripMenuItem();
        mnuDanhMuc = new ToolStripMenuItem();
        mnuSanPham = new ToolStripMenuItem();
        mnuKhachHang = new ToolStripMenuItem();
        mnuTroGiup = new ToolStripMenuItem();
        mnuGioiThieu = new ToolStripMenuItem();
        statusStrip1 = new StatusStrip();
        lblNguoiDung = new ToolStripStatusLabel();
        lblVaiTro = new ToolStripStatusLabel();
        lblThoiGian = new ToolStripStatusLabel();
        timer1 = new System.Windows.Forms.Timer(components);
        menuStrip1.SuspendLayout();
        statusStrip1.SuspendLayout();
        SuspendLayout();

        // menuStrip1
        menuStrip1.Items.AddRange(new ToolStripItem[] { mnuHeThong, mnuDanhMuc, mnuTroGiup });
        menuStrip1.Name = "menuStrip1";

        mnuHeThong.Name = "mnuHeThong"; mnuHeThong.Text = "Hệ thống";
        mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuDangXuat, mnuThoat });
        mnuDangXuat.Name = "mnuDangXuat"; mnuDangXuat.Text = "Đăng xuất"; mnuDangXuat.Click += mnuDangXuat_Click;
        mnuThoat.Name = "mnuThoat"; mnuThoat.Text = "Thoát"; mnuThoat.Click += mnuThoat_Click;

        mnuDanhMuc.Name = "mnuDanhMuc"; mnuDanhMuc.Text = "Danh mục";
        mnuDanhMuc.DropDownItems.AddRange(new ToolStripItem[] { mnuSanPham, mnuKhachHang });
        mnuSanPham.Name = "mnuSanPham"; mnuSanPham.Text = "Quản lý sản phẩm"; mnuSanPham.Click += mnuSanPham_Click;
        mnuKhachHang.Name = "mnuKhachHang"; mnuKhachHang.Text = "Quản lý khách hàng"; mnuKhachHang.Click += mnuKhachHang_Click;

        mnuTroGiup.Name = "mnuTroGiup"; mnuTroGiup.Text = "Trợ giúp";
        mnuTroGiup.DropDownItems.Add(mnuGioiThieu);
        mnuGioiThieu.Name = "mnuGioiThieu"; mnuGioiThieu.Text = "Giới thiệu"; mnuGioiThieu.Click += mnuGioiThieu_Click;

        // statusStrip1
        statusStrip1.Items.AddRange(new ToolStripItem[] { lblNguoiDung, lblVaiTro, lblThoiGian });
        statusStrip1.Name = "statusStrip1";
        lblNguoiDung.Name = "lblNguoiDung"; lblNguoiDung.Text = "Người dùng:"; lblNguoiDung.BorderSides = ToolStripStatusLabelBorderSides.Right;
        lblVaiTro.Name = "lblVaiTro"; lblVaiTro.Text = "Vai trò:"; lblVaiTro.BorderSides = ToolStripStatusLabelBorderSides.Right;
        lblThoiGian.Name = "lblThoiGian"; lblThoiGian.Spring = true; lblThoiGian.TextAlign = ContentAlignment.MiddleRight;

        // timer1
        timer1.Interval = 1000;
        timer1.Tick += timer1_Tick;

        // FrmMain
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1000, 650);
        IsMdiContainer = true;
        MainMenuStrip = menuStrip1;
        Name = "FrmMain";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "ShopManagerMini - Quản lý cửa hàng mini";
        WindowState = FormWindowState.Maximized;
        Load += FrmMain_Load;
        FormClosing += FrmMain_FormClosing;
        Controls.Add(menuStrip1);
        Controls.Add(statusStrip1);
        menuStrip1.ResumeLayout(false); menuStrip1.PerformLayout();
        statusStrip1.ResumeLayout(false); statusStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private MenuStrip menuStrip1;
    private ToolStripMenuItem mnuHeThong, mnuDangXuat, mnuThoat, mnuDanhMuc, mnuSanPham, mnuKhachHang, mnuTroGiup, mnuGioiThieu;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel lblNguoiDung, lblVaiTro, lblThoiGian;
    private System.Windows.Forms.Timer timer1;
}
