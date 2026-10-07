#nullable disable
namespace ProductManager;

partial class FrmProduct
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
        mnuFile = new ToolStripMenuItem();
        mnuFileExit = new ToolStripMenuItem();
        mnuQuanLy = new ToolStripMenuItem();
        mnuThem = new ToolStripMenuItem();
        mnuSua = new ToolStripMenuItem();
        mnuXoa = new ToolStripMenuItem();
        mnuLamMoi = new ToolStripMenuItem();
        mnuTimKiem = new ToolStripMenuItem();
        mnuTroGiup = new ToolStripMenuItem();
        mnuAbout = new ToolStripMenuItem();

        toolStrip1 = new ToolStrip();
        tsbThem = new ToolStripButton();
        tsbSua = new ToolStripButton();
        tsbXoa = new ToolStripButton();
        tsbLamMoi = new ToolStripButton();
        tsbTimKiem = new ToolStripButton();

        statusStrip1 = new StatusStrip();
        lblStatus = new ToolStripStatusLabel();

        gbThongTin = new GroupBox();
        lblMaSP = new Label();
        lblTenSP = new Label();
        lblLoaiSP = new Label();
        lblNgayNhap = new Label();
        lblDonGia = new Label();
        lblSoLuong = new Label();
        txtMaSP = new TextBox();
        txtTenSP = new TextBox();
        cboLoaiSP = new ComboBox();
        dtpNgayNhap = new DateTimePicker();
        numDonGia = new NumericUpDown();
        numSoLuong = new NumericUpDown();
        chkConKinhDoanh = new CheckBox();
        btnThem = new Button();
        btnSua = new Button();
        btnXoa = new Button();
        picSanPham = new PictureBox();
        btnChonAnh = new Button();

        pnlTimKiem = new Panel();
        lblTuKhoa = new Label();
        txtTimKiem = new TextBox();
        btnTimKiem = new Button();
        btnLamMoi = new Button();

        dgvProducts = new DataGridView();
        cmsProducts = new ContextMenuStrip(components);
        cmsSua = new ToolStripMenuItem();
        cmsXoa = new ToolStripMenuItem();
        cmsChiTiet = new ToolStripMenuItem();
        errorProvider1 = new ErrorProvider(components);

        menuStrip1.SuspendLayout();
        toolStrip1.SuspendLayout();
        statusStrip1.SuspendLayout();
        gbThongTin.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
        ((System.ComponentModel.ISupportInitialize)picSanPham).BeginInit();
        pnlTimKiem.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
        cmsProducts.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
        SuspendLayout();

        // menuStrip1
        menuStrip1.Items.AddRange(new ToolStripItem[] { mnuFile, mnuQuanLy, mnuTroGiup });
        menuStrip1.Name = "menuStrip1";
        mnuFile.DropDownItems.Add(mnuFileExit);
        mnuFile.Name = "mnuFile";
        mnuFile.Text = "File";
        mnuFileExit.Name = "mnuFileExit";
        mnuFileExit.Text = "Thoát";
        mnuFileExit.ShortcutKeys = Keys.Alt | Keys.F4;
        mnuFileExit.Click += mnuFileExit_Click;

        mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] { mnuThem, mnuSua, mnuXoa, mnuLamMoi, mnuTimKiem });
        mnuQuanLy.Name = "mnuQuanLy";
        mnuQuanLy.Text = "Quản lý";
        mnuThem.Name = "mnuThem";
        mnuThem.Text = "Thêm";
        mnuThem.ShortcutKeys = Keys.Control | Keys.N;
        mnuThem.Click += tsbThem_Click;
        mnuSua.Name = "mnuSua";
        mnuSua.Text = "Sửa";
        mnuSua.ShortcutKeys = Keys.Control | Keys.E;
        mnuSua.Click += tsbSua_Click;
        mnuXoa.Name = "mnuXoa";
        mnuXoa.Text = "Xóa";
        mnuXoa.ShortcutKeys = Keys.Control | Keys.D;
        mnuXoa.Click += tsbXoa_Click;
        mnuLamMoi.Name = "mnuLamMoi";
        mnuLamMoi.Text = "Làm mới";
        mnuLamMoi.ShortcutKeys = Keys.F5;
        mnuLamMoi.Click += tsbLamMoi_Click;
        mnuTimKiem.Name = "mnuTimKiem";
        mnuTimKiem.Text = "Tìm kiếm";
        mnuTimKiem.ShortcutKeys = Keys.Control | Keys.F;
        mnuTimKiem.Click += tsbTimKiem_Click;

        mnuTroGiup.DropDownItems.Add(mnuAbout);
        mnuTroGiup.Name = "mnuTroGiup";
        mnuTroGiup.Text = "Trợ giúp";
        mnuAbout.Name = "mnuAbout";
        mnuAbout.Text = "Giới thiệu";
        mnuAbout.Click += mnuAbout_Click;

        // toolStrip1
        toolStrip1.Items.AddRange(new ToolStripItem[] { tsbThem, tsbSua, tsbXoa, tsbLamMoi, tsbTimKiem });
        toolStrip1.Name = "toolStrip1";
        tsbThem.Name = "tsbThem"; tsbThem.Text = "Thêm"; tsbThem.DisplayStyle = ToolStripItemDisplayStyle.Text; tsbThem.Click += tsbThem_Click;
        tsbSua.Name = "tsbSua"; tsbSua.Text = "Sửa"; tsbSua.DisplayStyle = ToolStripItemDisplayStyle.Text; tsbSua.Click += tsbSua_Click;
        tsbXoa.Name = "tsbXoa"; tsbXoa.Text = "Xóa"; tsbXoa.DisplayStyle = ToolStripItemDisplayStyle.Text; tsbXoa.Click += tsbXoa_Click;
        tsbLamMoi.Name = "tsbLamMoi"; tsbLamMoi.Text = "Làm mới"; tsbLamMoi.DisplayStyle = ToolStripItemDisplayStyle.Text; tsbLamMoi.Click += tsbLamMoi_Click;
        tsbTimKiem.Name = "tsbTimKiem"; tsbTimKiem.Text = "Tìm kiếm"; tsbTimKiem.DisplayStyle = ToolStripItemDisplayStyle.Text; tsbTimKiem.Click += tsbTimKiem_Click;

        // statusStrip1
        statusStrip1.Items.Add(lblStatus);
        statusStrip1.Name = "statusStrip1";
        lblStatus.Name = "lblStatus";
        lblStatus.Text = "Sẵn sàng";

        // gbThongTin
        gbThongTin.Text = "Thông tin sản phẩm";
        gbThongTin.Name = "gbThongTin";
        gbThongTin.Dock = DockStyle.Top;
        gbThongTin.Height = 245;
        gbThongTin.Controls.AddRange(new Control[] {
            lblMaSP, txtMaSP, lblTenSP, txtTenSP, lblLoaiSP, cboLoaiSP, lblNgayNhap, dtpNgayNhap,
            lblDonGia, numDonGia, lblSoLuong, numSoLuong, chkConKinhDoanh,
            btnThem, btnSua, btnXoa, picSanPham, btnChonAnh });

        lblMaSP.Text = "Mã SP:"; lblMaSP.Location = new Point(20, 33); lblMaSP.AutoSize = true;
        txtMaSP.Name = "txtMaSP"; txtMaSP.Location = new Point(120, 30); txtMaSP.Size = new Size(230, 27);
        lblTenSP.Text = "Tên SP:"; lblTenSP.Location = new Point(20, 73); lblTenSP.AutoSize = true;
        txtTenSP.Name = "txtTenSP"; txtTenSP.Location = new Point(120, 70); txtTenSP.Size = new Size(230, 27);
        lblLoaiSP.Text = "Loại SP:"; lblLoaiSP.Location = new Point(20, 113); lblLoaiSP.AutoSize = true;
        cboLoaiSP.Name = "cboLoaiSP"; cboLoaiSP.Location = new Point(120, 110); cboLoaiSP.Size = new Size(230, 28);
        cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
        lblNgayNhap.Text = "Ngày nhập:"; lblNgayNhap.Location = new Point(20, 153); lblNgayNhap.AutoSize = true;
        dtpNgayNhap.Name = "dtpNgayNhap"; dtpNgayNhap.Location = new Point(120, 150); dtpNgayNhap.Size = new Size(230, 27);
        dtpNgayNhap.Format = DateTimePickerFormat.Short;

        lblDonGia.Text = "Đơn giá:"; lblDonGia.Location = new Point(390, 33); lblDonGia.AutoSize = true;
        numDonGia.Name = "numDonGia"; numDonGia.Location = new Point(480, 30); numDonGia.Size = new Size(200, 27);
        numDonGia.Minimum = 0; numDonGia.Maximum = 1000000000; numDonGia.ThousandsSeparator = true;
        lblSoLuong.Text = "Số lượng:"; lblSoLuong.Location = new Point(390, 73); lblSoLuong.AutoSize = true;
        numSoLuong.Name = "numSoLuong"; numSoLuong.Location = new Point(480, 70); numSoLuong.Size = new Size(200, 27);
        numSoLuong.Minimum = 0; numSoLuong.Maximum = 1000000;
        chkConKinhDoanh.Name = "chkConKinhDoanh"; chkConKinhDoanh.Text = "Còn kinh doanh";
        chkConKinhDoanh.Location = new Point(480, 112); chkConKinhDoanh.AutoSize = true; chkConKinhDoanh.Checked = true;

        btnThem.Name = "btnThem"; btnThem.Text = "Thêm"; btnThem.Location = new Point(120, 195); btnThem.Size = new Size(90, 32);
        btnThem.Click += btnThem_Click;
        btnSua.Name = "btnSua"; btnSua.Text = "Sửa"; btnSua.Location = new Point(220, 195); btnSua.Size = new Size(90, 32);
        btnSua.Click += btnSua_Click;
        btnXoa.Name = "btnXoa"; btnXoa.Text = "Xóa"; btnXoa.Location = new Point(320, 195); btnXoa.Size = new Size(90, 32);
        btnXoa.Click += btnXoa_Click;

        picSanPham.Name = "picSanPham"; picSanPham.Location = new Point(740, 25); picSanPham.Size = new Size(160, 160);
        picSanPham.BorderStyle = BorderStyle.FixedSingle; picSanPham.SizeMode = PictureBoxSizeMode.Zoom;
        btnChonAnh.Name = "btnChonAnh"; btnChonAnh.Text = "Chọn ảnh"; btnChonAnh.Location = new Point(740, 195); btnChonAnh.Size = new Size(160, 32);
        btnChonAnh.Click += btnChonAnh_Click;

        // pnlTimKiem
        pnlTimKiem.Dock = DockStyle.Top; pnlTimKiem.Height = 50; pnlTimKiem.Name = "pnlTimKiem";
        pnlTimKiem.Controls.AddRange(new Control[] { lblTuKhoa, txtTimKiem, btnTimKiem, btnLamMoi });
        lblTuKhoa.Text = "Từ khóa (mã hoặc tên):"; lblTuKhoa.Location = new Point(20, 16); lblTuKhoa.AutoSize = true;
        txtTimKiem.Name = "txtTimKiem"; txtTimKiem.Location = new Point(200, 12); txtTimKiem.Size = new Size(250, 27);
        btnTimKiem.Name = "btnTimKiem"; btnTimKiem.Text = "Tìm kiếm"; btnTimKiem.Location = new Point(465, 9); btnTimKiem.Size = new Size(100, 32);
        btnTimKiem.Click += btnTimKiem_Click;
        btnLamMoi.Name = "btnLamMoi"; btnLamMoi.Text = "Làm mới"; btnLamMoi.Location = new Point(575, 9); btnLamMoi.Size = new Size(100, 32);
        btnLamMoi.Click += btnLamMoi_Click;

        // dgvProducts
        dgvProducts.Name = "dgvProducts";
        dgvProducts.Dock = DockStyle.Fill;
        dgvProducts.ContextMenuStrip = cmsProducts;
        dgvProducts.CellClick += dgvProducts_CellClick;
        dgvProducts.CellMouseDown += dgvProducts_CellMouseDown;
        dgvProducts.KeyUp += dgvProducts_KeyUp;

        // cmsProducts
        cmsProducts.Items.AddRange(new ToolStripItem[] { cmsSua, cmsXoa, cmsChiTiet });
        cmsProducts.Name = "cmsProducts";
        cmsSua.Name = "cmsSua"; cmsSua.Text = "Sửa"; cmsSua.Click += cmsSua_Click;
        cmsXoa.Name = "cmsXoa"; cmsXoa.Text = "Xóa"; cmsXoa.Click += cmsXoa_Click;
        cmsChiTiet.Name = "cmsChiTiet"; cmsChiTiet.Text = "Xem chi tiết"; cmsChiTiet.Click += cmsChiTiet_Click;

        // errorProvider1
        errorProvider1.ContainerControl = this;

        // FrmProduct
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(960, 640);
        MainMenuStrip = menuStrip1;
        Name = "FrmProduct";
        Text = "Quản lý sản phẩm";
        StartPosition = FormStartPosition.CenterScreen;
        Load += FrmProduct_Load;
        Controls.Add(dgvProducts);
        Controls.Add(pnlTimKiem);
        Controls.Add(gbThongTin);
        Controls.Add(toolStrip1);
        Controls.Add(menuStrip1);
        Controls.Add(statusStrip1);

        menuStrip1.ResumeLayout(false); menuStrip1.PerformLayout();
        toolStrip1.ResumeLayout(false); toolStrip1.PerformLayout();
        statusStrip1.ResumeLayout(false); statusStrip1.PerformLayout();
        gbThongTin.ResumeLayout(false); gbThongTin.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
        ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
        ((System.ComponentModel.ISupportInitialize)picSanPham).EndInit();
        pnlTimKiem.ResumeLayout(false); pnlTimKiem.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
        cmsProducts.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private MenuStrip menuStrip1;
    private ToolStripMenuItem mnuFile, mnuFileExit, mnuQuanLy, mnuThem, mnuSua, mnuXoa, mnuLamMoi, mnuTimKiem, mnuTroGiup, mnuAbout;
    private ToolStrip toolStrip1;
    private ToolStripButton tsbThem, tsbSua, tsbXoa, tsbLamMoi, tsbTimKiem;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel lblStatus;
    private GroupBox gbThongTin;
    private Label lblMaSP, lblTenSP, lblLoaiSP, lblNgayNhap, lblDonGia, lblSoLuong, lblTuKhoa;
    private TextBox txtMaSP, txtTenSP, txtTimKiem;
    private ComboBox cboLoaiSP;
    private DateTimePicker dtpNgayNhap;
    private NumericUpDown numDonGia, numSoLuong;
    private CheckBox chkConKinhDoanh;
    private Button btnThem, btnSua, btnXoa, btnChonAnh, btnTimKiem, btnLamMoi;
    private PictureBox picSanPham;
    private Panel pnlTimKiem;
    private DataGridView dgvProducts;
    private ContextMenuStrip cmsProducts;
    private ToolStripMenuItem cmsSua, cmsXoa, cmsChiTiet;
    private ErrorProvider errorProvider1;
}
