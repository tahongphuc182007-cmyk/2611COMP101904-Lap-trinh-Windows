using System.ComponentModel;

namespace ProductManager;

public partial class FrmProduct : Form
{
    private BindingList<Product> products = new BindingList<Product>();
    private BindingSource productSource = new BindingSource();
    private string selectedImagePath = string.Empty;

    public FrmProduct()
    {
        InitializeComponent();
    }

    // ---------- Load form ----------
    private void FrmProduct_Load(object? sender, EventArgs e)
    {
        cboLoaiSP.Items.AddRange(new object[] { "Điện tử", "Văn phòng", "Gia dụng", "Thời trang" });
        cboLoaiSP.SelectedIndex = 0;

        products.Add(new Product
        {
            MaSP = "SP01", TenSP = "Chuột không dây", LoaiSP = "Điện tử",
            DonGia = 150000, SoLuong = 20, NgayNhap = DateTime.Today, ConKinhDoanh = true
        });
        products.Add(new Product
        {
            MaSP = "SP02", TenSP = "Bút bi", LoaiSP = "Văn phòng",
            DonGia = 5000, SoLuong = 100, NgayNhap = DateTime.Today, ConKinhDoanh = true
        });
        products.Add(new Product
        {
            MaSP = "SP03", TenSP = "Nồi cơm điện", LoaiSP = "Gia dụng",
            DonGia = 850000, SoLuong = 8, NgayNhap = DateTime.Today.AddDays(-3), ConKinhDoanh = true
        });

        productSource.DataSource = products;
        dgvProducts.AutoGenerateColumns = true;
        dgvProducts.DataSource = productSource;

        dgvProducts.ReadOnly = true;
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.MultiSelect = false;
        dgvProducts.AllowUserToAddRows = false;
        dgvProducts.AllowUserToDeleteRows = false;
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        ConfigureColumns();
        ClearInput();
        UpdateStatus("Sẵn sàng");
    }

    private void ConfigureColumns()
    {
        SetColumn("MaSP", "Mã SP");
        SetColumn("TenSP", "Tên sản phẩm");
        SetColumn("LoaiSP", "Loại");
        SetColumn("DonGia", "Đơn giá", "N0");
        SetColumn("SoLuong", "Số lượng");
        SetColumn("NgayNhap", "Ngày nhập", "dd/MM/yyyy");
        SetColumn("ConKinhDoanh", "Còn kinh doanh");
        SetColumn("DuongDanAnh", "Đường dẫn ảnh");
        SetColumn("ThanhTien", "Thành tiền", "N0");
    }

    private void SetColumn(string name, string header, string? format = null)
    {
        DataGridViewColumn? col = dgvProducts.Columns[name];
        if (col == null) return;
        col.HeaderText = header;
        if (format != null) col.DefaultCellStyle.Format = format;
    }

    // ---------- Validation ----------
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

        if (cboLoaiSP.SelectedIndex < 0)
        {
            errorProvider1.SetError(cboLoaiSP, "Vui lòng chọn loại sản phẩm");
            isValid = false;
        }

        if (numDonGia.Value <= 0)
        {
            errorProvider1.SetError(numDonGia, "Đơn giá phải lớn hơn 0");
            isValid = false;
        }

        if (numSoLuong.Value < 0)
        {
            errorProvider1.SetError(numSoLuong, "Số lượng phải lớn hơn hoặc bằng 0");
            isValid = false;
        }

        if (dtpNgayNhap.Value.Date > DateTime.Today)
        {
            errorProvider1.SetError(dtpNgayNhap, "Ngày nhập không được lớn hơn hôm nay");
            isValid = false;
        }

        if (!isValid)
        {
            MessageBox.Show("Dữ liệu nhập chưa hợp lệ. Vui lòng kiểm tra các ô báo lỗi.",
                "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        return isValid;
    }

    // ---------- Helpers ----------
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
        dtpNgayNhap.Value = p.NgayNhap < dtpNgayNhap.MinDate ? dtpNgayNhap.MinDate : p.NgayNhap;
        chkConKinhDoanh.Checked = p.ConKinhDoanh;
        selectedImagePath = p.DuongDanAnh;
        ShowImage(selectedImagePath);
    }

    private void ShowImage(string path)
    {
        Image? old = picSanPham.Image;
        picSanPham.Image = null;
        old?.Dispose();

        if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
        {
            try
            {
                // Copy vào Bitmap để không khóa file ảnh trên đĩa
                using Image img = Image.FromFile(path);
                picSanPham.Image = new Bitmap(img);
            }
            catch (Exception)
            {
                picSanPham.Image = null;
            }
        }
    }

    private void ClearInput()
    {
        txtMaSP.Clear();
        txtTenSP.Clear();
        cboLoaiSP.SelectedIndex = 0;
        numDonGia.Value = 0;
        numSoLuong.Value = 0;
        dtpNgayNhap.Value = DateTime.Today;
        chkConKinhDoanh.Checked = true;
        txtTimKiem.Clear();
        ShowImage(string.Empty);
        selectedImagePath = string.Empty;
        errorProvider1.Clear();
        txtMaSP.Focus();
    }

    private void ShowAll()
    {
        productSource.DataSource = products;
        productSource.ResetBindings(false);
    }

    private void UpdateStatus(string message)
    {
        lblStatus.Text = $"{message} | Số sản phẩm: {products.Count}";
    }

    // ---------- CRUD ----------
    private void btnThem_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        Product p = new Product
        {
            MaSP = txtMaSP.Text.Trim(),
            TenSP = txtTenSP.Text.Trim(),
            LoaiSP = cboLoaiSP.Text,
            DonGia = numDonGia.Value,
            SoLuong = (int)numSoLuong.Value,
            NgayNhap = dtpNgayNhap.Value.Date,
            ConKinhDoanh = chkConKinhDoanh.Checked,
            DuongDanAnh = selectedImagePath
        };

        products.Add(p);
        ShowAll();
        ClearInput();
        UpdateStatus("Đã thêm sản phẩm mới");
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
        p.NgayNhap = dtpNgayNhap.Value.Date;
        p.ConKinhDoanh = chkConKinhDoanh.Checked;
        p.DuongDanAnh = selectedImagePath;

        productSource.ResetBindings(false);
        UpdateStatus("Đã cập nhật sản phẩm");
    }

    private void btnXoa_Click(object? sender, EventArgs e)
    {
        Product? p = GetSelectedProduct();
        if (p == null) return;

        DialogResult result = MessageBox.Show(
            $"Bạn có chắc muốn xóa sản phẩm {p.TenSP}?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            products.Remove(p);
            ShowAll();
            ClearInput();
            UpdateStatus("Đã xóa sản phẩm");
        }
    }

    private void btnTimKiem_Click(object? sender, EventArgs e)
    {
        string keyword = txtTimKiem.Text.Trim();

        var result = products
            .Where(p => p.MaSP.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                     || p.TenSP.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();

        productSource.DataSource = new BindingList<Product>(result);
        lblStatus.Text = $"Tìm thấy {result.Count} sản phẩm | Số sản phẩm: {products.Count}";
    }

    private void btnLamMoi_Click(object? sender, EventArgs e)
    {
        ShowAll();
        ClearInput();
        UpdateStatus("Đã làm mới dữ liệu");
    }

    private void btnChonAnh_Click(object? sender, EventArgs e)
    {
        using OpenFileDialog dialog = new OpenFileDialog();
        dialog.Title = "Chọn ảnh sản phẩm";
        dialog.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp";

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            selectedImagePath = dialog.FileName;
            ShowImage(selectedImagePath);
            UpdateStatus("Đã chọn ảnh sản phẩm");
        }
    }

    // ---------- DataGridView ----------
    private void dgvProducts_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        if (productSource.Current is Product p) LoadProductToForm(p);
    }

    private void dgvProducts_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
    {
        // Nhấn chuột phải: chọn dòng trước khi hiện ContextMenuStrip
        if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
        {
            dgvProducts.ClearSelection();
            dgvProducts.Rows[e.RowIndex].Selected = true;
            dgvProducts.CurrentCell = dgvProducts.Rows[e.RowIndex].Cells[0];
            if (productSource.Current is Product p) LoadProductToForm(p);
        }
    }

    private void dgvProducts_KeyUp(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
        {
            if (productSource.Current is Product p) LoadProductToForm(p);
        }
        else if (e.KeyCode == Keys.Delete)
        {
            btnXoa.PerformClick();
        }
    }

    // ---------- Menu, toolbar, context menu ----------
    private void mnuFileExit_Click(object? sender, EventArgs e) { Close(); }

    private void mnuAbout_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("ProductManager - Lab 05\nCOMP1019 - Lập trình trên Windows",
            "Giới thiệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void tsbThem_Click(object? sender, EventArgs e) { btnThem.PerformClick(); }
    private void tsbSua_Click(object? sender, EventArgs e) { btnSua.PerformClick(); }
    private void tsbXoa_Click(object? sender, EventArgs e) { btnXoa.PerformClick(); }
    private void tsbLamMoi_Click(object? sender, EventArgs e) { btnLamMoi.PerformClick(); }
    private void tsbTimKiem_Click(object? sender, EventArgs e) { btnTimKiem.PerformClick(); }

    private void cmsSua_Click(object? sender, EventArgs e) { btnSua.PerformClick(); }
    private void cmsXoa_Click(object? sender, EventArgs e) { btnXoa.PerformClick(); }

    private void cmsChiTiet_Click(object? sender, EventArgs e)
    {
        Product? p = GetSelectedProduct();
        if (p == null) return;

        MessageBox.Show(
            $"Mã: {p.MaSP}\nTên: {p.TenSP}\nLoại: {p.LoaiSP}\nĐơn giá: {p.DonGia:N0}\n" +
            $"Số lượng: {p.SoLuong}\nNgày nhập: {p.NgayNhap:dd/MM/yyyy}\n" +
            $"Còn kinh doanh: {(p.ConKinhDoanh ? "Có" : "Không")}\nTổng tiền: {p.ThanhTien:N0}",
            "Chi tiết sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
