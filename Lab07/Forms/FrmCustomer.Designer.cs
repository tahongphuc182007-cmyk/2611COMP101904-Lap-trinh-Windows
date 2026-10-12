#nullable disable
namespace ShopManagerMini.Forms;

partial class FrmCustomer
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
        lblMaKH = new Label(); txtMaKH = new TextBox();
        lblHoTen = new Label(); txtHoTen = new TextBox();
        lblSoDienThoai = new Label(); txtSoDienThoai = new TextBox();
        lblLoaiKH = new Label(); cboLoaiKH = new ComboBox();
        btnThem = new Button();
        dgvCustomers = new DataGridView();
        errorProvider1 = new ErrorProvider(components);

        gbThongTin.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
        SuspendLayout();

        gbThongTin.Name = "gbThongTin"; gbThongTin.Text = "Thông tin khách hàng";
        gbThongTin.Dock = DockStyle.Top; gbThongTin.Height = 190;
        gbThongTin.Controls.AddRange(new Control[] {
            lblMaKH, txtMaKH, lblHoTen, txtHoTen, lblSoDienThoai, txtSoDienThoai, lblLoaiKH, cboLoaiKH, btnThem });

        lblMaKH.Text = "Mã KH:"; lblMaKH.Location = new Point(20, 33); lblMaKH.AutoSize = true;
        txtMaKH.Name = "txtMaKH"; txtMaKH.Location = new Point(140, 30); txtMaKH.Size = new Size(220, 27);
        lblHoTen.Text = "Họ tên:"; lblHoTen.Location = new Point(20, 73); lblHoTen.AutoSize = true;
        txtHoTen.Name = "txtHoTen"; txtHoTen.Location = new Point(140, 70); txtHoTen.Size = new Size(220, 27);
        lblSoDienThoai.Text = "Số điện thoại:"; lblSoDienThoai.Location = new Point(400, 33); lblSoDienThoai.AutoSize = true;
        txtSoDienThoai.Name = "txtSoDienThoai"; txtSoDienThoai.Location = new Point(520, 30); txtSoDienThoai.Size = new Size(200, 27);
        lblLoaiKH.Text = "Loại khách hàng:"; lblLoaiKH.Location = new Point(400, 73); lblLoaiKH.AutoSize = true;
        cboLoaiKH.Name = "cboLoaiKH"; cboLoaiKH.Location = new Point(520, 70); cboLoaiKH.Size = new Size(200, 28);
        cboLoaiKH.DropDownStyle = ComboBoxStyle.DropDownList;

        btnThem.Name = "btnThem"; btnThem.Text = "Thêm"; btnThem.Location = new Point(140, 125); btnThem.Size = new Size(100, 34);
        btnThem.Click += btnThem_Click;

        dgvCustomers.Name = "dgvCustomers"; dgvCustomers.Dock = DockStyle.Fill;
        errorProvider1.ContainerControl = this;

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(820, 500);
        Name = "FrmCustomer";
        Text = "Quản lý khách hàng";
        Load += FrmCustomer_Load;
        Controls.Add(dgvCustomers);
        Controls.Add(gbThongTin);

        gbThongTin.ResumeLayout(false); gbThongTin.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
        ResumeLayout(false);
    }

    private GroupBox gbThongTin;
    private Label lblMaKH, lblHoTen, lblSoDienThoai, lblLoaiKH;
    private TextBox txtMaKH, txtHoTen, txtSoDienThoai;
    private ComboBox cboLoaiKH;
    private Button btnThem;
    private DataGridView dgvCustomers;
    private ErrorProvider errorProvider1;
}
