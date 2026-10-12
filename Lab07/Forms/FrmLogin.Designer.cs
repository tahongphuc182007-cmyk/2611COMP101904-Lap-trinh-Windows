#nullable disable
namespace ShopManagerMini.Forms;

partial class FrmLogin
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTieuDe = new Label();
        lblUsername = new Label();
        txtUsername = new TextBox();
        lblPassword = new Label();
        txtPassword = new TextBox();
        btnDangNhap = new Button();
        btnThoat = new Button();
        SuspendLayout();

        lblTieuDe.Text = "ĐĂNG NHẬP";
        lblTieuDe.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTieuDe.Location = new Point(0, 15);
        lblTieuDe.Size = new Size(380, 35);
        lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;

        lblUsername.Text = "Username:"; lblUsername.Location = new Point(30, 73); lblUsername.AutoSize = true;
        txtUsername.Name = "txtUsername"; txtUsername.Location = new Point(120, 70); txtUsername.Size = new Size(220, 27);

        lblPassword.Text = "Password:"; lblPassword.Location = new Point(30, 113); lblPassword.AutoSize = true;
        txtPassword.Name = "txtPassword"; txtPassword.Location = new Point(120, 110); txtPassword.Size = new Size(220, 27);
        txtPassword.UseSystemPasswordChar = true;

        btnDangNhap.Name = "btnDangNhap"; btnDangNhap.Text = "Đăng nhập";
        btnDangNhap.Location = new Point(120, 160); btnDangNhap.Size = new Size(105, 34);
        btnDangNhap.Click += btnDangNhap_Click;

        btnThoat.Name = "btnThoat"; btnThoat.Text = "Thoát";
        btnThoat.Location = new Point(235, 160); btnThoat.Size = new Size(105, 34);
        btnThoat.DialogResult = DialogResult.Cancel;

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(380, 230);
        AcceptButton = btnDangNhap;
        CancelButton = btnThoat;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmLogin";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Đăng nhập";
        Controls.AddRange(new Control[] { lblTieuDe, lblUsername, txtUsername, lblPassword, txtPassword, btnDangNhap, btnThoat });
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTieuDe, lblUsername, lblPassword;
    private TextBox txtUsername, txtPassword;
    private Button btnDangNhap, btnThoat;
}
