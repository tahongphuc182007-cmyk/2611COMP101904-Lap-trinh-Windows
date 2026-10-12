namespace ShopManagerMini.Forms;

public partial class FrmAbout : Form
{
    // Điền thông tin của bạn tại đây
    private const string StudentName = "[Họ tên sinh viên]";
    private const string StudentClass = "[Lớp]";

    public FrmAbout()
    {
        InitializeComponent();
        lblSinhVien.Text = $"Sinh viên: {StudentName}";
        lblLop.Text = $"Lớp: {StudentClass}";
    }

    private void btnDong_Click(object? sender, EventArgs e)
    {
        Close();
    }
}
