using System.ComponentModel;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms;

public partial class FrmCustomer : Form
{
    private readonly BindingList<Customer> customers;
    private readonly BindingSource customerSource = new BindingSource();

    // Constructor mặc định chỉ để Visual Studio Designer mở được Form
    public FrmCustomer() : this(new BindingList<Customer>()) { }

    // Nhận danh sách khách hàng dùng chung từ FrmMain
    public FrmCustomer(BindingList<Customer> data)
    {
        InitializeComponent();
        customers = data;
    }

    private void FrmCustomer_Load(object? sender, EventArgs e)
    {
        cboLoaiKH.Items.AddRange(new object[] { "Thường", "Thân thiết", "VIP" });
        cboLoaiKH.SelectedIndex = 0;

        customerSource.DataSource = customers;
        dgvCustomers.AutoGenerateColumns = true;
        dgvCustomers.DataSource = customerSource;
        dgvCustomers.ReadOnly = true;
        dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCustomers.MultiSelect = false;
        dgvCustomers.AllowUserToAddRows = false;
        dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        SetHeader("MaKH", "Mã KH");
        SetHeader("HoTen", "Họ tên");
        SetHeader("SoDienThoai", "Số điện thoại");
        SetHeader("LoaiKH", "Loại khách hàng");
    }

    private void SetHeader(string name, string header)
    {
        DataGridViewColumn? col = dgvCustomers.Columns[name];
        if (col != null) col.HeaderText = header;
    }

    private bool ValidateInput()
    {
        errorProvider1.Clear();
        bool isValid = true;
        string ma = txtMaKH.Text.Trim();
        string sdt = txtSoDienThoai.Text.Trim();

        if (string.IsNullOrWhiteSpace(ma))
        {
            errorProvider1.SetError(txtMaKH, "Mã khách hàng không được rỗng");
            isValid = false;
        }
        else if (customers.Any(c => c.MaKH.Equals(ma, StringComparison.OrdinalIgnoreCase)))
        {
            errorProvider1.SetError(txtMaKH, "Mã khách hàng đã tồn tại");
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(txtHoTen.Text))
        {
            errorProvider1.SetError(txtHoTen, "Họ tên không được rỗng");
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(sdt))
        {
            errorProvider1.SetError(txtSoDienThoai, "Số điện thoại không được rỗng");
            isValid = false;
        }
        else if (!sdt.All(char.IsDigit) || sdt.Length < 9 || sdt.Length > 11)
        {
            errorProvider1.SetError(txtSoDienThoai, "Số điện thoại chỉ gồm chữ số, dài 9 đến 11 ký tự");
            isValid = false;
        }

        if (!isValid)
        {
            MessageBox.Show("Dữ liệu nhập chưa hợp lệ. Vui lòng kiểm tra các ô báo lỗi.", "Lỗi dữ liệu",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        return isValid;
    }

    private void ClearInput()
    {
        txtMaKH.Clear();
        txtHoTen.Clear();
        txtSoDienThoai.Clear();
        cboLoaiKH.SelectedIndex = 0;
        errorProvider1.Clear();
        txtMaKH.Focus();
    }

    private void btnThem_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        customers.Add(new Customer
        {
            MaKH = txtMaKH.Text.Trim(),
            HoTen = txtHoTen.Text.Trim(),
            SoDienThoai = txtSoDienThoai.Text.Trim(),
            LoaiKH = cboLoaiKH.Text
        });

        ClearInput();
    }
}
