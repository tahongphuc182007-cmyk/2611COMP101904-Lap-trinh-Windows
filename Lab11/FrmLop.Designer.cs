#nullable disable
namespace COMP1019_Buoi11_Lab11;

partial class FrmLop
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        gbThongTin = new GroupBox();
        lblMaLop = new Label();
        txtMaLop = new TextBox();
        lblTenLop = new Label();
        txtTenLop = new TextBox();
        btnThem = new Button();
        btnSua = new Button();
        btnXoa = new Button();
        btnLamMoi = new Button();
        pnlTimKiem = new Panel();
        lblTuKhoa = new Label();
        txtTimKiem = new TextBox();
        btnTimKiem = new Button();
        dgvLop = new DataGridView();

        gbThongTin.SuspendLayout();
        pnlTimKiem.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvLop).BeginInit();
        SuspendLayout();

        // gbThongTin
        gbThongTin.Name = "gbThongTin";
        gbThongTin.Text = "Thông tin lớp";
        gbThongTin.Dock = DockStyle.Top;
        gbThongTin.Height = 175;
        gbThongTin.TabIndex = 0;
        gbThongTin.Controls.AddRange(new Control[] {
            lblMaLop, txtMaLop, lblTenLop, txtTenLop, btnThem, btnSua, btnXoa, btnLamMoi });

        lblMaLop.Name = "lblMaLop"; lblMaLop.Text = "Mã lớp:"; lblMaLop.Location = new Point(20, 38); lblMaLop.AutoSize = true;
        txtMaLop.Name = "txtMaLop"; txtMaLop.Location = new Point(120, 35); txtMaLop.Size = new Size(260, 27); txtMaLop.TabIndex = 0;
        lblTenLop.Name = "lblTenLop"; lblTenLop.Text = "Tên lớp:"; lblTenLop.Location = new Point(20, 78); lblTenLop.AutoSize = true;
        txtTenLop.Name = "txtTenLop"; txtTenLop.Location = new Point(120, 75); txtTenLop.Size = new Size(260, 27); txtTenLop.TabIndex = 1;

        btnThem.Name = "btnThem"; btnThem.Text = "Thêm"; btnThem.Location = new Point(120, 122); btnThem.Size = new Size(90, 34);
        btnThem.TabIndex = 2; btnThem.Click += btnThem_Click;
        btnSua.Name = "btnSua"; btnSua.Text = "Sửa"; btnSua.Location = new Point(220, 122); btnSua.Size = new Size(90, 34);
        btnSua.TabIndex = 3; btnSua.Click += btnSua_Click;
        btnXoa.Name = "btnXoa"; btnXoa.Text = "Xóa"; btnXoa.Location = new Point(320, 122); btnXoa.Size = new Size(90, 34);
        btnXoa.TabIndex = 4; btnXoa.Click += btnXoa_Click;
        btnLamMoi.Name = "btnLamMoi"; btnLamMoi.Text = "Làm mới"; btnLamMoi.Location = new Point(420, 122); btnLamMoi.Size = new Size(100, 34);
        btnLamMoi.TabIndex = 5; btnLamMoi.Click += btnLamMoi_Click;

        // pnlTimKiem
        pnlTimKiem.Name = "pnlTimKiem";
        pnlTimKiem.Dock = DockStyle.Top;
        pnlTimKiem.Height = 55;
        pnlTimKiem.TabIndex = 1;
        pnlTimKiem.Controls.AddRange(new Control[] { lblTuKhoa, txtTimKiem, btnTimKiem });

        lblTuKhoa.Name = "lblTuKhoa"; lblTuKhoa.Text = "Tìm theo mã hoặc tên lớp:"; lblTuKhoa.Location = new Point(20, 18); lblTuKhoa.AutoSize = true;
        txtTimKiem.Name = "txtTimKiem"; txtTimKiem.Location = new Point(230, 14); txtTimKiem.Size = new Size(280, 27); txtTimKiem.TabIndex = 0;
        btnTimKiem.Name = "btnTimKiem"; btnTimKiem.Text = "Tìm kiếm"; btnTimKiem.Location = new Point(525, 11); btnTimKiem.Size = new Size(100, 32);
        btnTimKiem.TabIndex = 1; btnTimKiem.Click += btnTimKiem_Click;

        // dgvLop
        dgvLop.Name = "dgvLop";
        dgvLop.Dock = DockStyle.Fill;
        dgvLop.ReadOnly = true;
        dgvLop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvLop.MultiSelect = false;
        dgvLop.AllowUserToAddRows = false;
        dgvLop.AllowUserToDeleteRows = false;
        dgvLop.RowHeadersVisible = false;
        dgvLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvLop.TabIndex = 2;
        dgvLop.CellClick += dgvLop_CellClick;

        // FrmLop
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(760, 520);
        MinimumSize = new Size(700, 450);
        Name = "FrmLop";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Quản lý lớp học";
        Load += FrmLop_Load;
        Controls.Add(dgvLop);
        Controls.Add(pnlTimKiem);
        Controls.Add(gbThongTin);

        gbThongTin.ResumeLayout(false); gbThongTin.PerformLayout();
        pnlTimKiem.ResumeLayout(false); pnlTimKiem.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvLop).EndInit();
        ResumeLayout(false);
    }

    private GroupBox gbThongTin;
    private Label lblMaLop, lblTenLop, lblTuKhoa;
    private TextBox txtMaLop, txtTenLop, txtTimKiem;
    private Button btnThem, btnSua, btnXoa, btnLamMoi, btnTimKiem;
    private Panel pnlTimKiem;
    private DataGridView dgvLop;
}
