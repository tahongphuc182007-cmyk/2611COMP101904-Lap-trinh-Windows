#nullable disable
namespace StudentReportDemo.Forms;

partial class FrmBaoCaoSinhVien
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        gbDieuKien = new GroupBox();
        lblLop = new Label();
        cboLop = new ComboBox();
        lblKetQua = new Label();
        cboKetQua = new ComboBox();
        lblTuKhoa = new Label();
        txtTuKhoa = new TextBox();
        lblGoiY = new Label();
        btnXemBaoCao = new Button();
        btnThongKe = new Button();
        btnXuatFile = new Button();
        dgvBaoCao = new DataGridView();
        lblThongKe = new Label();

        gbDieuKien.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
        SuspendLayout();

        // gbDieuKien
        gbDieuKien.Name = "gbDieuKien";
        gbDieuKien.Text = "Điều kiện báo cáo";
        gbDieuKien.Dock = DockStyle.Top;
        gbDieuKien.Height = 170;
        gbDieuKien.TabIndex = 0;
        gbDieuKien.Controls.AddRange(new Control[] {
            lblLop, cboLop, lblKetQua, cboKetQua, lblTuKhoa, txtTuKhoa, lblGoiY,
            btnXemBaoCao, btnThongKe, btnXuatFile });

        lblLop.Name = "lblLop"; lblLop.Text = "Lớp:"; lblLop.Location = new Point(20, 36); lblLop.AutoSize = true;
        cboLop.Name = "cboLop"; cboLop.Location = new Point(110, 33); cboLop.Size = new Size(240, 28);
        cboLop.DropDownStyle = ComboBoxStyle.DropDownList; cboLop.TabIndex = 0;

        lblKetQua.Name = "lblKetQua"; lblKetQua.Text = "Kết quả:"; lblKetQua.Location = new Point(390, 36); lblKetQua.AutoSize = true;
        cboKetQua.Name = "cboKetQua"; cboKetQua.Location = new Point(470, 33); cboKetQua.Size = new Size(170, 28);
        cboKetQua.DropDownStyle = ComboBoxStyle.DropDownList; cboKetQua.TabIndex = 1;

        lblTuKhoa.Name = "lblTuKhoa"; lblTuKhoa.Text = "Từ khóa:"; lblTuKhoa.Location = new Point(20, 76); lblTuKhoa.AutoSize = true;
        txtTuKhoa.Name = "txtTuKhoa"; txtTuKhoa.Location = new Point(110, 73); txtTuKhoa.Size = new Size(240, 27); txtTuKhoa.TabIndex = 2;
        lblGoiY.Name = "lblGoiY"; lblGoiY.Text = "(mã sinh viên hoặc họ tên)"; lblGoiY.Location = new Point(360, 76); lblGoiY.AutoSize = true;

        btnXemBaoCao.Name = "btnXemBaoCao"; btnXemBaoCao.Text = "Xem báo cáo";
        btnXemBaoCao.Location = new Point(110, 115); btnXemBaoCao.Size = new Size(140, 36);
        btnXemBaoCao.TabIndex = 3; btnXemBaoCao.Click += btnXemBaoCao_Click;

        btnThongKe.Name = "btnThongKe"; btnThongKe.Text = "Thống kê theo lớp";
        btnThongKe.Location = new Point(260, 115); btnThongKe.Size = new Size(160, 36);
        btnThongKe.TabIndex = 4; btnThongKe.Click += btnThongKe_Click;

        btnXuatFile.Name = "btnXuatFile"; btnXuatFile.Text = "Xuất file";
        btnXuatFile.Location = new Point(430, 115); btnXuatFile.Size = new Size(120, 36);
        btnXuatFile.TabIndex = 5; btnXuatFile.Click += btnXuatFile_Click;

        // dgvBaoCao
        dgvBaoCao.Name = "dgvBaoCao";
        dgvBaoCao.Dock = DockStyle.Fill;
        dgvBaoCao.ReadOnly = true;
        dgvBaoCao.AllowUserToAddRows = false;
        dgvBaoCao.AllowUserToDeleteRows = false;
        dgvBaoCao.MultiSelect = false;
        dgvBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvBaoCao.RowHeadersVisible = false;
        dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvBaoCao.BackgroundColor = Color.White;
        dgvBaoCao.TabIndex = 1;

        // lblThongKe
        lblThongKe.Name = "lblThongKe";
        lblThongKe.Dock = DockStyle.Bottom;
        lblThongKe.Height = 42;
        lblThongKe.BorderStyle = BorderStyle.FixedSingle;
        lblThongKe.TextAlign = ContentAlignment.MiddleLeft;
        lblThongKe.Padding = new Padding(8, 0, 0, 0);
        lblThongKe.Text = "Sẵn sàng";

        // FrmBaoCaoSinhVien
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(900, 580);
        MinimumSize = new Size(760, 450);
        AcceptButton = btnXemBaoCao;
        Name = "FrmBaoCaoSinhVien";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Báo cáo danh sách sinh viên";
        Load += FrmBaoCaoSinhVien_Load;
        Controls.Add(dgvBaoCao);
        Controls.Add(lblThongKe);
        Controls.Add(gbDieuKien);

        gbDieuKien.ResumeLayout(false); gbDieuKien.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
        ResumeLayout(false);
    }

    private GroupBox gbDieuKien;
    private Label lblLop, lblKetQua, lblTuKhoa, lblGoiY, lblThongKe;
    private ComboBox cboLop, cboKetQua;
    private TextBox txtTuKhoa;
    private Button btnXemBaoCao, btnThongKe, btnXuatFile;
    private DataGridView dgvBaoCao;
}
