#nullable disable
namespace CourseRegistrationApp;

partial class FrmRegistration
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        gbHocVien = new GroupBox();
        lblHoTen = new Label();
        txtHoTen = new TextBox();
        lblSoDienThoai = new Label();
        txtSoDienThoai = new TextBox();
        lblNgaySinh = new Label();
        dtpNgaySinh = new DateTimePicker();
        chkNhanEmail = new CheckBox();

        gbKhoaHoc = new GroupBox();
        lblKhoaHoc = new Label();
        cboKhoaHoc = new ComboBox();
        lblHinhThuc = new Label();
        radOnline = new RadioButton();
        radOffline = new RadioButton();
        lblSoThang = new Label();
        numSoThang = new NumericUpDown();
        lblTongTienText = new Label();
        lblTongTien = new Label();

        btnDangKy = new Button();
        btnLamMoi = new Button();
        btnThoat = new Button();

        gbHocVien.SuspendLayout();
        gbKhoaHoc.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numSoThang).BeginInit();
        SuspendLayout();

        // gbHocVien
        gbHocVien.Name = "gbHocVien";
        gbHocVien.Text = "Thông tin học viên";
        gbHocVien.Location = new Point(15, 15);
        gbHocVien.Size = new Size(490, 190);
        gbHocVien.TabIndex = 0;
        gbHocVien.Controls.AddRange(new Control[] {
            lblHoTen, txtHoTen, lblSoDienThoai, txtSoDienThoai, lblNgaySinh, dtpNgaySinh, chkNhanEmail });

        lblHoTen.Text = "Họ tên:"; lblHoTen.Location = new Point(20, 36); lblHoTen.AutoSize = true;
        txtHoTen.Name = "txtHoTen"; txtHoTen.Location = new Point(150, 33); txtHoTen.Size = new Size(310, 27); txtHoTen.TabIndex = 0;

        lblSoDienThoai.Text = "Số điện thoại:"; lblSoDienThoai.Location = new Point(20, 76); lblSoDienThoai.AutoSize = true;
        txtSoDienThoai.Name = "txtSoDienThoai"; txtSoDienThoai.Location = new Point(150, 73); txtSoDienThoai.Size = new Size(310, 27); txtSoDienThoai.TabIndex = 1;

        lblNgaySinh.Text = "Ngày sinh:"; lblNgaySinh.Location = new Point(20, 116); lblNgaySinh.AutoSize = true;
        dtpNgaySinh.Name = "dtpNgaySinh"; dtpNgaySinh.Location = new Point(150, 113); dtpNgaySinh.Size = new Size(310, 27);
        dtpNgaySinh.Format = DateTimePickerFormat.Short; dtpNgaySinh.TabIndex = 2;

        chkNhanEmail.Name = "chkNhanEmail"; chkNhanEmail.Text = "Nhận email thông báo";
        chkNhanEmail.Location = new Point(150, 152); chkNhanEmail.AutoSize = true; chkNhanEmail.TabIndex = 3;

        // gbKhoaHoc
        gbKhoaHoc.Name = "gbKhoaHoc";
        gbKhoaHoc.Text = "Thông tin khóa học";
        gbKhoaHoc.Location = new Point(15, 215);
        gbKhoaHoc.Size = new Size(490, 190);
        gbKhoaHoc.TabIndex = 1;
        gbKhoaHoc.Controls.AddRange(new Control[] {
            lblKhoaHoc, cboKhoaHoc, lblHinhThuc, radOnline, radOffline, lblSoThang, numSoThang, lblTongTienText, lblTongTien });

        lblKhoaHoc.Text = "Khóa học:"; lblKhoaHoc.Location = new Point(20, 36); lblKhoaHoc.AutoSize = true;
        cboKhoaHoc.Name = "cboKhoaHoc"; cboKhoaHoc.Location = new Point(150, 33); cboKhoaHoc.Size = new Size(310, 28);
        cboKhoaHoc.DropDownStyle = ComboBoxStyle.DropDownList; cboKhoaHoc.TabIndex = 0;
        cboKhoaHoc.SelectedIndexChanged += cboKhoaHoc_SelectedIndexChanged;

        lblHinhThuc.Text = "Hình thức học:"; lblHinhThuc.Location = new Point(20, 76); lblHinhThuc.AutoSize = true;
        radOnline.Name = "radOnline"; radOnline.Text = "Online"; radOnline.Location = new Point(150, 74); radOnline.AutoSize = true; radOnline.TabIndex = 1;
        radOffline.Name = "radOffline"; radOffline.Text = "Trực tiếp"; radOffline.Location = new Point(260, 74); radOffline.AutoSize = true; radOffline.TabIndex = 2;

        lblSoThang.Text = "Số tháng đăng ký:"; lblSoThang.Location = new Point(20, 116); lblSoThang.AutoSize = true;
        numSoThang.Name = "numSoThang"; numSoThang.Location = new Point(150, 113); numSoThang.Size = new Size(120, 27);
        numSoThang.Minimum = 1; numSoThang.Maximum = 12; numSoThang.TabIndex = 3;
        numSoThang.ValueChanged += numSoThang_ValueChanged;

        lblTongTienText.Text = "Tổng học phí:"; lblTongTienText.Location = new Point(20, 152); lblTongTienText.AutoSize = true;
        lblTongTien.Name = "lblTongTien"; lblTongTien.Location = new Point(150, 148); lblTongTien.AutoSize = true;
        lblTongTien.Font = new Font("Segoe UI", 11F, FontStyle.Bold); lblTongTien.ForeColor = Color.Firebrick;
        lblTongTien.Text = "0 VNĐ";

        // Nút lệnh
        btnDangKy.Name = "btnDangKy"; btnDangKy.Text = "Đăng ký";
        btnDangKy.Location = new Point(55, 420); btnDangKy.Size = new Size(120, 38); btnDangKy.TabIndex = 2;
        btnDangKy.Click += btnDangKy_Click;

        btnLamMoi.Name = "btnLamMoi"; btnLamMoi.Text = "Làm mới";
        btnLamMoi.Location = new Point(200, 420); btnLamMoi.Size = new Size(120, 38); btnLamMoi.TabIndex = 3;
        btnLamMoi.Click += btnLamMoi_Click;

        btnThoat.Name = "btnThoat"; btnThoat.Text = "Thoát";
        btnThoat.Location = new Point(345, 420); btnThoat.Size = new Size(120, 38); btnThoat.TabIndex = 4;
        btnThoat.Click += btnThoat_Click;

        // FrmRegistration
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(520, 475);
        AcceptButton = btnDangKy;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "FrmRegistration";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "ĐĂNG KÝ KHÓA HỌC";
        Load += FrmRegistration_Load;
        Controls.AddRange(new Control[] { gbHocVien, gbKhoaHoc, btnDangKy, btnLamMoi, btnThoat });

        gbHocVien.ResumeLayout(false); gbHocVien.PerformLayout();
        gbKhoaHoc.ResumeLayout(false); gbKhoaHoc.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numSoThang).EndInit();
        ResumeLayout(false);
    }

    private GroupBox gbHocVien, gbKhoaHoc;
    private Label lblHoTen, lblSoDienThoai, lblNgaySinh, lblKhoaHoc, lblHinhThuc, lblSoThang, lblTongTienText, lblTongTien;
    private TextBox txtHoTen, txtSoDienThoai;
    private DateTimePicker dtpNgaySinh;
    private CheckBox chkNhanEmail;
    private ComboBox cboKhoaHoc;
    private RadioButton radOnline, radOffline;
    private NumericUpDown numSoThang;
    private Button btnDangKy, btnLamMoi, btnThoat;
}
