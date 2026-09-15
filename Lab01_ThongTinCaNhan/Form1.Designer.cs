namespace Lab01_ThongTinCaNhan
{
    partial class Form1
    {
        /// <summary>
        /// Biến cần thiết cho designer.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Giải phóng tài nguyên đang được sử dụng.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Phương thức bắt buộc cho hỗ trợ Designer - không thay đổi
        /// nội dung phương thức này bằng trình soạn thảo mã.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();

            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();

            this.lblNamSinh = new System.Windows.Forms.Label();
            this.txtNamSinh = new System.Windows.Forms.TextBox();

            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();

            this.grpGioiTinh = new System.Windows.Forms.GroupBox();
            this.radNam = new System.Windows.Forms.RadioButton();
            this.radNu = new System.Windows.Forms.RadioButton();

            this.lblKhoa = new System.Windows.Forms.Label();
            this.cboKhoa = new System.Windows.Forms.ComboBox();

            this.btnHienThi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();

            this.lblKetQua = new System.Windows.Forms.Label();
            this.txtKetQua = new System.Windows.Forms.TextBox();

            this.grpGioiTinh.SuspendLayout();
            this.SuspendLayout();

            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(440, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ỨNG DỤNG THÔNG TIN CÁ NHÂN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //
            // lblHoTen
            //
            this.lblHoTen.Location = new System.Drawing.Point(20, 70);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(100, 23);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "Họ tên:";

            //
            // txtHoTen
            //
            this.txtHoTen.Location = new System.Drawing.Point(140, 67);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(320, 23);
            this.txtHoTen.TabIndex = 2;

            //
            // lblNamSinh
            //
            this.lblNamSinh.Location = new System.Drawing.Point(20, 103);
            this.lblNamSinh.Name = "lblNamSinh";
            this.lblNamSinh.Size = new System.Drawing.Size(100, 23);
            this.lblNamSinh.TabIndex = 3;
            this.lblNamSinh.Text = "Năm sinh:";

            //
            // txtNamSinh
            //
            this.txtNamSinh.Location = new System.Drawing.Point(140, 100);
            this.txtNamSinh.Name = "txtNamSinh";
            this.txtNamSinh.Size = new System.Drawing.Size(150, 23);
            this.txtNamSinh.TabIndex = 4;

            //
            // lblEmail
            //
            this.lblEmail.Location = new System.Drawing.Point(20, 136);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email:";

            //
            // txtEmail
            //
            this.txtEmail.Location = new System.Drawing.Point(140, 133);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(320, 23);
            this.txtEmail.TabIndex = 6;

            //
            // grpGioiTinh
            //
            this.grpGioiTinh.Controls.Add(this.radNam);
            this.grpGioiTinh.Controls.Add(this.radNu);
            this.grpGioiTinh.Location = new System.Drawing.Point(20, 170);
            this.grpGioiTinh.Name = "grpGioiTinh";
            this.grpGioiTinh.Size = new System.Drawing.Size(220, 50);
            this.grpGioiTinh.TabIndex = 7;
            this.grpGioiTinh.TabStop = false;
            this.grpGioiTinh.Text = "Giới tính";

            //
            // radNam
            //
            this.radNam.Location = new System.Drawing.Point(15, 20);
            this.radNam.Name = "radNam";
            this.radNam.Size = new System.Drawing.Size(80, 24);
            this.radNam.TabIndex = 0;
            this.radNam.Text = "Nam";

            //
            // radNu
            //
            this.radNu.Location = new System.Drawing.Point(115, 20);
            this.radNu.Name = "radNu";
            this.radNu.Size = new System.Drawing.Size(80, 24);
            this.radNu.TabIndex = 1;
            this.radNu.Text = "Nữ";

            //
            // lblKhoa
            //
            this.lblKhoa.Location = new System.Drawing.Point(20, 232);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(100, 23);
            this.lblKhoa.TabIndex = 8;
            this.lblKhoa.Text = "Khoa/Lớp:";

            //
            // cboKhoa
            //
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.Location = new System.Drawing.Point(140, 229);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(320, 23);
            this.cboKhoa.TabIndex = 9;

            //
            // btnHienThi
            //
            this.btnHienThi.Location = new System.Drawing.Point(60, 275);
            this.btnHienThi.Name = "btnHienThi";
            this.btnHienThi.Size = new System.Drawing.Size(110, 35);
            this.btnHienThi.TabIndex = 10;
            this.btnHienThi.Text = "Hiển thị";
            this.btnHienThi.UseVisualStyleBackColor = true;
            this.btnHienThi.Click += new System.EventHandler(this.btnHienThi_Click);

            //
            // btnXoa
            //
            this.btnXoa.Location = new System.Drawing.Point(190, 275);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 35);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            //
            // btnThoat
            //
            this.btnThoat.Location = new System.Drawing.Point(320, 275);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(110, 35);
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            //
            // lblKetQua
            //
            this.lblKetQua.Location = new System.Drawing.Point(20, 325);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(200, 23);
            this.lblKetQua.TabIndex = 13;
            this.lblKetQua.Text = "Kết quả:";

            //
            // txtKetQua
            //
            this.txtKetQua.Location = new System.Drawing.Point(20, 350);
            this.txtKetQua.Multiline = true;
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.ReadOnly = true;
            this.txtKetQua.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKetQua.Size = new System.Drawing.Size(440, 170);
            this.txtKetQua.TabIndex = 14;

            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 541);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblNamSinh);
            this.Controls.Add(this.txtNamSinh);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.grpGioiTinh);
            this.Controls.Add(this.lblKhoa);
            this.Controls.Add(this.cboKhoa);
            this.Controls.Add(this.btnHienThi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.txtKetQua);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab 01 - Ứng dụng thông tin cá nhân";
            this.grpGioiTinh.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblNamSinh;
        private System.Windows.Forms.TextBox txtNamSinh;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.GroupBox grpGioiTinh;
        private System.Windows.Forms.RadioButton radNam;
        private System.Windows.Forms.RadioButton radNu;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Button btnHienThi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.TextBox txtKetQua;
    }
}
