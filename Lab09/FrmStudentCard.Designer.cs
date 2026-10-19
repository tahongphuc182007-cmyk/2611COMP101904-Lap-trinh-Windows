#nullable disable
namespace COMP1019_Lab09_StudentCard;

partial class FrmStudentCard
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
        lblMaSV = new Label(); txtMaSV = new TextBox();
        lblHoTen = new Label(); txtHoTen = new TextBox();
        lblNgaySinh = new Label(); dtpNgaySinh = new DateTimePicker();
        lblGioiTinh = new Label(); cboGioiTinh = new ComboBox();
        lblLop = new Label(); cboLop = new ComboBox();
        lblKhoa = new Label(); cboKhoa = new ComboBox();
        lblKhoaHoc = new Label(); cboKhoaHoc = new ComboBox();

        gbAnh = new GroupBox();
        picAnh = new PictureBox();
        btnChonAnh = new Button();
        lblGoiYAnh = new Label();

        gbPreview = new GroupBox();
        pnlPreview = new DoubleBufferedPanel();

        btnLamMoi = new Button();
        btnXemTruocIn = new Button();
        btnIn = new Button();
        btnThoat = new Button();

        printDocument1 = new System.Drawing.Printing.PrintDocument();
        errorProvider1 = new ErrorProvider(components);

        gbThongTin.SuspendLayout();
        gbAnh.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picAnh).BeginInit();
        gbPreview.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
        SuspendLayout();

        // gbThongTin
        gbThongTin.Name = "gbThongTin"; gbThongTin.Text = "Thông tin sinh viên";
        gbThongTin.Location = new Point(15, 15); gbThongTin.Size = new Size(430, 330); gbThongTin.TabIndex = 0;
        gbThongTin.Controls.AddRange(new Control[] {
            lblMaSV, txtMaSV, lblHoTen, txtHoTen, lblNgaySinh, dtpNgaySinh, lblGioiTinh, cboGioiTinh,
            lblLop, cboLop, lblKhoa, cboKhoa, lblKhoaHoc, cboKhoaHoc });

        lblMaSV.Text = "Mã sinh viên:"; lblMaSV.Location = new Point(15, 38); lblMaSV.AutoSize = true;
        txtMaSV.Name = "txtMaSV"; txtMaSV.Location = new Point(125, 35); txtMaSV.Size = new Size(285, 27); txtMaSV.TabIndex = 0;
        txtMaSV.TextChanged += InputChanged;

        lblHoTen.Text = "Họ tên:"; lblHoTen.Location = new Point(15, 80); lblHoTen.AutoSize = true;
        txtHoTen.Name = "txtHoTen"; txtHoTen.Location = new Point(125, 77); txtHoTen.Size = new Size(285, 27); txtHoTen.TabIndex = 1;
        txtHoTen.TextChanged += InputChanged;

        lblNgaySinh.Text = "Ngày sinh:"; lblNgaySinh.Location = new Point(15, 122); lblNgaySinh.AutoSize = true;
        dtpNgaySinh.Name = "dtpNgaySinh"; dtpNgaySinh.Location = new Point(125, 119); dtpNgaySinh.Size = new Size(285, 27);
        dtpNgaySinh.Format = DateTimePickerFormat.Short; dtpNgaySinh.TabIndex = 2;
        dtpNgaySinh.ValueChanged += InputChanged;

        lblGioiTinh.Text = "Giới tính:"; lblGioiTinh.Location = new Point(15, 164); lblGioiTinh.AutoSize = true;
        cboGioiTinh.Name = "cboGioiTinh"; cboGioiTinh.Location = new Point(125, 161); cboGioiTinh.Size = new Size(285, 28);
        cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList; cboGioiTinh.TabIndex = 3;
        cboGioiTinh.TextChanged += InputChanged;

        lblLop.Text = "Lớp:"; lblLop.Location = new Point(15, 206); lblLop.AutoSize = true;
        cboLop.Name = "cboLop"; cboLop.Location = new Point(125, 203); cboLop.Size = new Size(285, 28); cboLop.TabIndex = 4;
        cboLop.TextChanged += InputChanged;

        lblKhoa.Text = "Khoa:"; lblKhoa.Location = new Point(15, 248); lblKhoa.AutoSize = true;
        cboKhoa.Name = "cboKhoa"; cboKhoa.Location = new Point(125, 245); cboKhoa.Size = new Size(285, 28); cboKhoa.TabIndex = 5;
        cboKhoa.TextChanged += InputChanged;

        lblKhoaHoc.Text = "Khóa học:"; lblKhoaHoc.Location = new Point(15, 290); lblKhoaHoc.AutoSize = true;
        cboKhoaHoc.Name = "cboKhoaHoc"; cboKhoaHoc.Location = new Point(125, 287); cboKhoaHoc.Size = new Size(285, 28); cboKhoaHoc.TabIndex = 6;
        cboKhoaHoc.TextChanged += InputChanged;

        // gbAnh
        gbAnh.Name = "gbAnh"; gbAnh.Text = "Ảnh đại diện";
        gbAnh.Location = new Point(15, 355); gbAnh.Size = new Size(430, 205); gbAnh.TabIndex = 1;
        gbAnh.Controls.AddRange(new Control[] { picAnh, btnChonAnh, lblGoiYAnh });

        picAnh.Name = "picAnh"; picAnh.Location = new Point(20, 30); picAnh.Size = new Size(130, 160);
        picAnh.BorderStyle = BorderStyle.FixedSingle; picAnh.SizeMode = PictureBoxSizeMode.Zoom; picAnh.TabStop = false;
        btnChonAnh.Name = "btnChonAnh"; btnChonAnh.Text = "Chọn ảnh"; btnChonAnh.Location = new Point(175, 30);
        btnChonAnh.Size = new Size(120, 36); btnChonAnh.TabIndex = 0; btnChonAnh.Click += btnChonAnh_Click;
        lblGoiYAnh.Text = "Hỗ trợ file JPG, JPEG, PNG, BMP.\nẢnh được giữ đúng tỉ lệ."; lblGoiYAnh.Location = new Point(175, 80);
        lblGoiYAnh.AutoSize = true;

        // gbPreview
        gbPreview.Name = "gbPreview"; gbPreview.Text = "Xem trước thẻ sinh viên";
        gbPreview.Location = new Point(460, 15); gbPreview.Size = new Size(625, 545); gbPreview.TabIndex = 2;
        gbPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        gbPreview.Padding = new Padding(10);
        gbPreview.Controls.Add(pnlPreview);

        pnlPreview.Name = "pnlPreview"; pnlPreview.Dock = DockStyle.Fill; pnlPreview.BackColor = Color.Gainsboro;
        pnlPreview.Paint += pnlPreview_Paint;

        // Nút lệnh
        btnLamMoi.Name = "btnLamMoi"; btnLamMoi.Text = "Làm mới"; btnLamMoi.Location = new Point(15, 580);
        btnLamMoi.Size = new Size(120, 38); btnLamMoi.TabIndex = 3; btnLamMoi.Click += btnLamMoi_Click;
        btnLamMoi.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnXemTruocIn.Name = "btnXemTruocIn"; btnXemTruocIn.Text = "Xem trước in"; btnXemTruocIn.Location = new Point(145, 580);
        btnXemTruocIn.Size = new Size(150, 38); btnXemTruocIn.TabIndex = 4; btnXemTruocIn.Click += btnXemTruocIn_Click;
        btnXemTruocIn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnIn.Name = "btnIn"; btnIn.Text = "In"; btnIn.Location = new Point(305, 580);
        btnIn.Size = new Size(120, 38); btnIn.TabIndex = 5; btnIn.Click += btnIn_Click;
        btnIn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnThoat.Name = "btnThoat"; btnThoat.Text = "Thoát"; btnThoat.Location = new Point(435, 580);
        btnThoat.Size = new Size(120, 38); btnThoat.TabIndex = 6; btnThoat.Click += btnThoat_Click;
        btnThoat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

        // printDocument1
        printDocument1.DocumentName = "The sinh vien";
        printDocument1.PrintPage += printDocument1_PrintPage;

        // errorProvider1
        errorProvider1.ContainerControl = this;

        // FrmStudentCard
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1100, 635);
        MinimumSize = new Size(1000, 600);
        Name = "FrmStudentCard";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Thiết kế và in thẻ sinh viên";
        Load += FrmStudentCard_Load;
        FormClosed += FrmStudentCard_FormClosed;
        Controls.AddRange(new Control[] { gbThongTin, gbAnh, gbPreview, btnLamMoi, btnXemTruocIn, btnIn, btnThoat });

        gbThongTin.ResumeLayout(false); gbThongTin.PerformLayout();
        gbAnh.ResumeLayout(false); gbAnh.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)picAnh).EndInit();
        gbPreview.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
        ResumeLayout(false);
    }

    private GroupBox gbThongTin, gbAnh, gbPreview;
    private Label lblMaSV, lblHoTen, lblNgaySinh, lblGioiTinh, lblLop, lblKhoa, lblKhoaHoc, lblGoiYAnh;
    private TextBox txtMaSV, txtHoTen;
    private DateTimePicker dtpNgaySinh;
    private ComboBox cboGioiTinh, cboLop, cboKhoa, cboKhoaHoc;
    private PictureBox picAnh;
    private Button btnChonAnh, btnLamMoi, btnXemTruocIn, btnIn, btnThoat;
    private DoubleBufferedPanel pnlPreview;
    private System.Drawing.Printing.PrintDocument printDocument1;
    private ErrorProvider errorProvider1;
}
