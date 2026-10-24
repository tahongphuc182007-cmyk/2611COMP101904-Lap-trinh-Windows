#nullable disable
namespace QLSinhVienLab12.Forms;

partial class FrmNhapDiemTheoLop
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        gbChon = new GroupBox();
        lblLop = new Label();
        cboLop = new ComboBox();
        lblMonHoc = new Label();
        cboMonHoc = new ComboBox();
        btnTaiDanhSach = new Button();
        dgvKetQua = new DataGridView();
        pnlBottom = new Panel();
        btnLuuTatCa = new Button();
        statusStrip1 = new StatusStrip();
        lblStatus = new ToolStripStatusLabel();

        gbChon.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvKetQua).BeginInit();
        pnlBottom.SuspendLayout();
        statusStrip1.SuspendLayout();
        SuspendLayout();

        // gbChon
        gbChon.Name = "gbChon";
        gbChon.Text = "Chọn lớp và môn học";
        gbChon.Dock = DockStyle.Top;
        gbChon.Height = 125;
        gbChon.TabIndex = 0;
        gbChon.Controls.AddRange(new Control[] { lblLop, cboLop, lblMonHoc, cboMonHoc, btnTaiDanhSach });

        lblLop.Name = "lblLop"; lblLop.Text = "Lớp:"; lblLop.Location = new Point(20, 38); lblLop.AutoSize = true;
        cboLop.Name = "cboLop"; cboLop.Location = new Point(120, 35); cboLop.Size = new Size(320, 28);
        cboLop.DropDownStyle = ComboBoxStyle.DropDownList; cboLop.TabIndex = 0;

        lblMonHoc.Name = "lblMonHoc"; lblMonHoc.Text = "Môn học:"; lblMonHoc.Location = new Point(20, 78); lblMonHoc.AutoSize = true;
        cboMonHoc.Name = "cboMonHoc"; cboMonHoc.Location = new Point(120, 75); cboMonHoc.Size = new Size(320, 28);
        cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList; cboMonHoc.TabIndex = 1;

        btnTaiDanhSach.Name = "btnTaiDanhSach"; btnTaiDanhSach.Text = "Tải danh sách";
        btnTaiDanhSach.Location = new Point(470, 55); btnTaiDanhSach.Size = new Size(150, 36);
        btnTaiDanhSach.TabIndex = 2; btnTaiDanhSach.Click += btnTaiDanhSach_Click;

        // dgvKetQua
        dgvKetQua.Name = "dgvKetQua";
        dgvKetQua.Dock = DockStyle.Fill;
        dgvKetQua.AllowUserToAddRows = false;
        dgvKetQua.AllowUserToDeleteRows = false;
        dgvKetQua.MultiSelect = false;
        dgvKetQua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvKetQua.BackgroundColor = Color.White;
        dgvKetQua.TabIndex = 1;
        dgvKetQua.DataError += dgvKetQua_DataError;

        // pnlBottom
        pnlBottom.Name = "pnlBottom";
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Height = 60;
        pnlBottom.TabIndex = 2;
        pnlBottom.Controls.Add(btnLuuTatCa);

        btnLuuTatCa.Name = "btnLuuTatCa"; btnLuuTatCa.Text = "Lưu tất cả";
        btnLuuTatCa.Location = new Point(15, 12); btnLuuTatCa.Size = new Size(150, 38);
        btnLuuTatCa.TabIndex = 0; btnLuuTatCa.Click += btnLuuTatCa_Click;

        // statusStrip1
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Items.Add(lblStatus);
        lblStatus.Name = "lblStatus";
        lblStatus.Text = "Sẵn sàng";

        // FrmNhapDiemTheoLop
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(820, 580);
        MinimumSize = new Size(700, 450);
        Name = "FrmNhapDiemTheoLop";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Nhập điểm theo lớp";
        Load += FrmNhapDiemTheoLop_Load;
        Controls.Add(dgvKetQua);
        Controls.Add(pnlBottom);
        Controls.Add(gbChon);
        Controls.Add(statusStrip1);

        gbChon.ResumeLayout(false); gbChon.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvKetQua).EndInit();
        pnlBottom.ResumeLayout(false);
        statusStrip1.ResumeLayout(false); statusStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private GroupBox gbChon;
    private Label lblLop, lblMonHoc;
    private ComboBox cboLop, cboMonHoc;
    private Button btnTaiDanhSach, btnLuuTatCa;
    private DataGridView dgvKetQua;
    private Panel pnlBottom;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel lblStatus;
}
