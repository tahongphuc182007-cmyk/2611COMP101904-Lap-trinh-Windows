#nullable disable
namespace ShopManagerMini.Forms;

partial class FrmAbout
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTenUngDung = new Label();
        lblPhienBan = new Label();
        lblMonHoc = new Label();
        lblSinhVien = new Label();
        lblLop = new Label();
        btnDong = new Button();
        SuspendLayout();

        lblTenUngDung.Text = "ShopManagerMini";
        lblTenUngDung.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTenUngDung.Location = new Point(30, 20); lblTenUngDung.AutoSize = true;
        lblPhienBan.Text = "Ứng dụng quản lý cửa hàng mini - Phiên bản 1.0"; lblPhienBan.Location = new Point(30, 65); lblPhienBan.AutoSize = true;
        lblMonHoc.Text = "Môn học: COMP1019 - Lập trình trên Windows"; lblMonHoc.Location = new Point(30, 100); lblMonHoc.AutoSize = true;
        lblSinhVien.Name = "lblSinhVien"; lblSinhVien.Location = new Point(30, 135); lblSinhVien.AutoSize = true;
        lblLop.Name = "lblLop"; lblLop.Location = new Point(30, 170); lblLop.AutoSize = true;
        btnDong.Name = "btnDong"; btnDong.Text = "Đóng"; btnDong.Location = new Point(300, 205); btnDong.Size = new Size(90, 32);
        btnDong.Click += btnDong_Click;

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(420, 260);
        Name = "FrmAbout";
        Text = "Giới thiệu";
        StartPosition = FormStartPosition.CenterParent;
        Controls.AddRange(new Control[] { lblTenUngDung, lblPhienBan, lblMonHoc, lblSinhVien, lblLop, btnDong });
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTenUngDung, lblPhienBan, lblMonHoc, lblSinhVien, lblLop;
    private Button btnDong;
}
