using System.ComponentModel;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms;

public partial class FrmProduct : Form
{
    private readonly BindingList<Product> products;
    private readonly BindingSource productSource = new BindingSource();

    // Constructor mặc định chỉ để Visual Studio Designer mở được Form
    public FrmProduct() : this(new BindingList<Product>()) { }

    // Nhận danh sách sản phẩm dùng chung từ FrmMain
    public FrmProduct(BindingList<Product> data)
    {
        InitializeComponent();
        products = data;
    }

    private void FrmProduct_Load(object? sender, EventArgs e)
    {
        cboLoaiSP.Items.AddRange(new object[] { "Đồ uống", "Thực phẩm", "Văn phòng phẩm", "Gia dụng" });
        cboLoaiSP.SelectedIndex = 0;

        productSource.DataSource = products;
        dgvProducts.AutoGenerateColumns = true;
        dgvProducts.DataSource = productSource;
        dgvProducts.ReadOnly = true;
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.MultiSelect = false;
        dgvProducts.AllowUserToAddRows = false;
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        SetColumn("MaSP", "Mã SP");
        SetColumn("TenSP", "Tên sản phẩm");
        SetColumn("LoaiSP", "Loại");
        SetColumn("DonGia", "Đơn giá", "N0");
        SetColumn("SoLuong", "Số lượng");
    }

    private void SetColumn(string name, string header, string? format = null)
    {
        DataGridViewColumn? col = dgvProducts.Columns[name];
        if (col == null) return;
        col.HeaderText = header;
        if (format != null) col.DefaultCellStyle.Format = format;
    }

    // ---------- Hàm hỗ trợ ----------
    private bool ValidateInput(bool isEdit = false, Product? selected = null)
    {
        errorProvider1.Clear();
        bool isValid = true;
        string ma = txtMaSP.Text.Trim();

        if (string.IsNullOrWhiteSpace(ma))
        {
            errorProvider1.SetError(txtMaSP, "Mã sản phẩm không được rỗng");
            isValid = false;
        }
        else if (!isEdit)
        {
            if (products.Any(p => p.MaSP.Equals(ma, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(txtMaSP, "Mã sản phẩm đã tồn tại");
                isValid = false;
            }
        }
        else if (selected != null && !selected.MaSP.Equals(ma, StringComparison.OrdinalIgnoreCase))
        {
            errorProvider1.SetError(txtMaSP, "Không được đổi mã sản phẩm khi sửa");
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(txtTenSP.Text))
        {
            errorProvider1.SetError(txtTenSP, "Tên sản phẩm không được rỗng");
            isValid = false;
        }

        if (numDonGia.Value < 0)
        {
            errorProvider1.SetError(numDonGia, "Đơn giá không được âm");
            isValid = false;
        }

        if (numSoLuong.Value < 0)
        {
            errorProvider1.SetError(numSoLuong, "Số lượng không được âm");
            isValid = false;
        }

        if (!isValid)
        {
            MessageBox.Show("Dữ liệu nhập chưa hợp lệ. Vui lòng kiểm tra các ô báo lỗi.", "Lỗi dữ liệu",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        return isValid;
    }

    private Product? GetSelectedProduct()
    {
        if (productSource.Current == null || dgvProducts.CurrentRow == null)
        {
            MessageBox.Show("Vui lòng chọn một sản phẩm.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }
        return productSource.Current as Product;
    }

    private void LoadProductToForm(Product p)
    {
        errorProvider1.Clear();
        txtMaSP.Text = p.MaSP;
        txtTenSP.Text = p.TenSP;
        cboLoaiSP.Text = p.LoaiSP;
        numDonGia.Value = Math.Min(Math.Max(p.DonGia, numDonGia.Minimum), numDonGia.Maximum);
        numSoLuong.Value = Math.Min(Math.Max(p.SoLuong, numSoLuong.Minimum), numSoLuong.Maximum);
    }

    private void ClearInput()
    {
        txtMaSP.Clear();
        txtTenSP.Clear();
        cboLoaiSP.SelectedIndex = 0;
        numDonGia.Value = 0;
        numSoLuong.Value = 0;
        txtTimKiem.Clear();
        errorProvider1.Clear();
        txtMaSP.Focus();
    }

    private void ShowAll()
    {
        productSource.DataSource = products;
        productSource.ResetBindings(false);
    }

    // ---------- Sự kiện ----------
    private void btnThem_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        products.Add(new Product
        {
            MaSP = txtMaSP.Text.Trim(),
            TenSP = txtTenSP.Text.Trim(),
            LoaiSP = cboLoaiSP.Text,
            DonGia = numDonGia.Value,
            SoLuong = (int)numSoLuong.Value
        });

        ShowAll();
        ClearInput();
    }

    private void btnSua_Click(object? sender, EventArgs e)
    {
        Product? p = GetSelectedProduct();
        if (p == null) return;
        if (!ValidateInput(isEdit: true, selected: p)) return;

        p.TenSP = txtTenSP.Text.Trim();
        p.LoaiSP = cboLoaiSP.Text;
        p.DonGia = numDonGia.Value;
        p.SoLuong = (int)numSoLuong.Value;

        productSource.ResetBindings(false);
    }

    private void btnXoa_Click(object? sender, EventArgs e)
    {
        Product? p = GetSelectedProduct();
        if (p == null) return;

        DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm {p.TenSP}?", "Xác nhận xóa",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            products.Remove(p);
            ShowAll();
            ClearInput();
        }
    }

    private void btnLamMoi_Click(object? sender, EventArgs e)
    {
        ShowAll();
        ClearInput();
    }

    private void btnTimKiem_Click(object? sender, EventArgs e)
    {
        string keyword = txtTimKiem.Text.Trim();

        var result = products
            .Where(p => p.MaSP.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                     || p.TenSP.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();

        productSource.DataSource = new BindingList<Product>(result);
    }

    private void dgvProducts_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        if (productSource.Current is Product p) LoadProductToForm(p);
    }
}
