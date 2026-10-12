#nullable disable
namespace ShopManagerMini.Forms;

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
        gbThongTin = new GroupBox();
        lblMaSP = new Label(); txtMaSP = new TextBox();
        lblTenSP = new Label(); txtTenSP = new TextBox();
        lblLoaiSP = new Label(); cboLoaiSP = new ComboBox();
        lblDonGia = new Label(); numDonGia = new NumericUpDown();
        lblSoLuong = new Label(); numSoLuong = new NumericUpDown();
        btnThem = new Button(); btnSua = new Button(); btnXoa = new Button(); btnLamMoi = new Button();
        pnlTimKiem = new Panel(); lblTuKhoa = new Label(); txtTimKiem = new TextBox(); btnTimKiem = new Button();
        dgvProducts = new DataGridView();
        errorProvider1 = new ErrorProvider(components);

        gbThongTin.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
        pnlTimKiem.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
        SuspendLayout();

        // gbThongTin
        gbThongTin.Name = "gbThongTin"; gbThongTin.Text = "Thông tin sản phẩm";
        gbThongTin.Dock = DockStyle.Top; gbThongTin.Height = 200;
        gbThongTin.Controls.AddRange(new Control[] {
            lblMaSP, txtMaSP, lblTenSP, txtTenSP, lblLoaiSP, cboLoaiSP,
            lblDonGia, numDonGia, lblSoLuong, numSoLuong,
            btnThem, btnSua, btnXoa, btnLamMoi });

        lblMaSP.Text = "Mã SP:"; lblMaSP.Location = new Point(20, 33); lblMaSP.AutoSize = true;
        txtMaSP.Name = "txtMaSP"; txtMaSP.Location = new Point(120, 30); txtMaSP.Size = new Size(220, 27);
        lblTenSP.Text = "Tên SP:"; lblTenSP.Location = new Point(20, 73); lblTenSP.AutoSize = true;
        txtTenSP.Name = "txtTenSP"; txtTenSP.Location = new Point(120, 70); txtTenSP.Size = new Size(220, 27);
        lblLoaiSP.Text = "Loại SP:"; lblLoaiSP.Location = new Point(20, 113); lblLoaiSP.AutoSize = true;
        cboLoaiSP.Name = "cboLoaiSP"; cboLoaiSP.Location = new Point(120, 110); cboLoaiSP.Size = new Size(220, 28);
        cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;

        lblDonGia.Text = "Đơn giá:"; lblDonGia.Location = new Point(400, 33); lblDonGia.AutoSize = true;
        numDonGia.Name = "numDonGia"; numDonGia.Location = new Point(490, 30); numDonGia.Size = new Size(200, 27);
        numDonGia.Minimum = 0; numDonGia.Maximum = 1000000000; numDonGia.ThousandsSeparator = true;
        lblSoLuong.Text = "Số lượng:"; lblSoLuong.Location = new Point(400, 73); lblSoLuong.AutoSize = true;
        numSoLuong.Name = "numSoLuong"; numSoLuong.Location = new Point(490, 70); numSoLuong.Size = new Size(200, 27);
        numSoLuong.Minimum = 0; numSoLuong.Maximum = 1000000;

        btnThem.Name = "btnThem"; btnThem.Text = "Thêm"; btnThem.Location = new Point(120, 155); btnThem.Size = new Size(90, 32); btnThem.Click += btnThem_Click;
        btnSua.Name = "btnSua"; btnSua.Text = "Sửa"; btnSua.Location = new Point(220, 155); btnSua.Size = new Size(90, 32); btnSua.Click += btnSua_Click;
        btnXoa.Name = "btnXoa"; btnXoa.Text = "Xóa"; btnXoa.Location = new Point(320, 155); btnXoa.Size = new Size(90, 32); btnXoa.Click += btnXoa_Click;
        btnLamMoi.Name = "btnLamMoi"; btnLamMoi.Text = "Làm mới"; btnLamMoi.Location = new Point(420, 155); btnLamMoi.Size = new Size(90, 32); btnLamMoi.Click += btnLamMoi_Click;

        // pnlTimKiem
        pnlTimKiem.Name = "pnlTimKiem"; pnlTimKiem.Dock = DockStyle.Top; pnlTimKiem.Height = 50;
        pnlTimKiem.Controls.AddRange(new Control[] { lblTuKhoa, txtTimKiem, btnTimKiem });
        lblTuKhoa.Text = "Từ khóa (mã hoặc tên):"; lblTuKhoa.Location = new Point(20, 16); lblTuKhoa.AutoSize = true;
        txtTimKiem.Name = "txtTimKiem"; txtTimKiem.Location = new Point(200, 12); txtTimKiem.Size = new Size(250, 27);
        btnTimKiem.Name = "btnTimKiem"; btnTimKiem.Text = "Tìm kiếm"; btnTimKiem.Location = new Point(465, 9); btnTimKiem.Size = new Size(100, 32);
        btnTimKiem.Click += btnTimKiem_Click;

        // dgvProducts
        dgvProducts.Name = "dgvProducts"; dgvProducts.Dock = DockStyle.Fill;
        dgvProducts.CellClick += dgvProducts_CellClick;

        errorProvider1.ContainerControl = this;

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(820, 540);
        Name = "FrmProduct";
        Text = "Quản lý sản phẩm";
        Load += FrmProduct_Load;
        Controls.Add(dgvProducts);
        Controls.Add(pnlTimKiem);
        Controls.Add(gbThongTin);

        gbThongTin.ResumeLayout(false); gbThongTin.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
        ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
        pnlTimKiem.ResumeLayout(false); pnlTimKiem.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
        ResumeLayout(false);
    }

    private GroupBox gbThongTin;
    private Label lblMaSP, lblTenSP, lblLoaiSP, lblDonGia, lblSoLuong, lblTuKhoa;
    private TextBox txtMaSP, txtTenSP, txtTimKiem;
    private ComboBox cboLoaiSP;
    private NumericUpDown numDonGia, numSoLuong;
    private Button btnThem, btnSua, btnXoa, btnLamMoi, btnTimKiem;
    private Panel pnlTimKiem;
    private DataGridView dgvProducts;
    private ErrorProvider errorProvider1;
}
