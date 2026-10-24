using System.Data;
using QLSinhVienLab12.DAL;

namespace QLSinhVienLab12.Forms;

public partial class FrmNhapDiemTheoLop : Form
{
    private readonly KetQuaDAL ketQuaDAL = new KetQuaDAL();
    private readonly BindingSource ketQuaSource = new BindingSource();

    // Môn học của danh sách đang hiển thị. Lưu điểm dùng giá trị này, không dùng ComboBox,
    // vì người dùng có thể đổi môn trong ComboBox sau khi đã tải danh sách.
    private string loadedMaMon = string.Empty;

    public FrmNhapDiemTheoLop()
    {
        InitializeComponent();
    }

    // ---------- Chức năng 1: Load Form ----------
    private void FrmNhapDiemTheoLop_Load(object? sender, EventArgs e)
    {
        ConfigureGrid();
        dgvKetQua.DataSource = ketQuaSource;
        LoadComboBox();
    }

    private void ConfigureGrid()
    {
        dgvKetQua.AutoGenerateColumns = false;
        dgvKetQua.Columns.Clear();
        dgvKetQua.Columns.Add(CreateColumn("colMaSV", "MaSV", "Mã SV", true, 15));
        dgvKetQua.Columns.Add(CreateColumn("colHoTen", "HoTen", "Họ tên", true, 35));

        DataGridViewTextBoxColumn colDiem = CreateColumn("colDiem", "Diem", "Điểm", false, 12);
        colDiem.DefaultCellStyle.Format = "0.##";
        colDiem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        colDiem.MaxInputLength = 6;
        dgvKetQua.Columns.Add(colDiem);

        DataGridViewTextBoxColumn colGhiChu = CreateColumn("colGhiChu", "GhiChu", "Ghi chú", false, 38);
        colGhiChu.MaxInputLength = 255;   // khớp NVARCHAR(255) trong database
        dgvKetQua.Columns.Add(colGhiChu);
    }

    private static DataGridViewTextBoxColumn CreateColumn(string name, string dataProperty, string header,
        bool readOnly, float fillWeight)
    {
        return new DataGridViewTextBoxColumn
        {
            Name = name,
            DataPropertyName = dataProperty,
            HeaderText = header,
            ReadOnly = readOnly,
            FillWeight = fillWeight,
            SortMode = DataGridViewColumnSortMode.NotSortable   // giữ thứ tự dòng khớp với DataTable
        };
    }

    private void LoadComboBox()
    {
        try
        {
            // Đặt DisplayMember và ValueMember trước DataSource để ComboBox không hiện "System.Data.DataRowView"
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
            cboLop.DataSource = ketQuaDAL.GetLop();

            cboMonHoc.DisplayMember = "TenMon";
            cboMonHoc.ValueMember = "MaMon";
            cboMonHoc.DataSource = ketQuaDAL.GetMonHoc();

            SetStatus("Sẵn sàng. Chọn lớp và môn học rồi bấm Tải danh sách.");
        }
        catch (Exception ex)
        {
            SetStatus("Không kết nối được cơ sở dữ liệu.");
            MessageBox.Show("Không tải được danh sách lớp và môn học: " + ex.Message +
                "\n\nHãy kiểm tra SQL Server đang chạy, đã chạy script Database/QLSinhVienLab12.sql " +
                "và chuỗi kết nối trong appsettings.json.",
                "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ---------- Chức năng 2: Tải danh sách ----------
    private void btnTaiDanhSach_Click(object? sender, EventArgs e)
    {
        string maLop = Convert.ToString(cboLop.SelectedValue) ?? string.Empty;
        string maMon = Convert.ToString(cboMonHoc.SelectedValue) ?? string.Empty;

        if (maLop.Length == 0 || maMon.Length == 0)
        {
            MessageBox.Show("Vui lòng chọn lớp và môn học.", "Thiếu dữ liệu",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (HasUnsavedChanges())
        {
            DialogResult answer = MessageBox.Show(
                "Danh sách hiện tại có điểm đã sửa nhưng chưa lưu. Tải danh sách mới sẽ mất các thay đổi này. Tiếp tục?",
                "Chưa lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes) return;
        }

        try
        {
            DataTable table = ketQuaDAL.GetKetQuaByLopMon(maLop, maMon);
            ketQuaSource.DataSource = table;
            loadedMaMon = maMon;
            ClearRowErrors();

            SetStatus($"Đã tải {table.Rows.Count} sinh viên - lớp {cboLop.Text} - môn {cboMonHoc.Text}.");
        }
        catch (Exception ex)
        {
            SetStatus("Tải danh sách thất bại.");
            MessageBox.Show("Không thể tải danh sách: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private bool HasUnsavedChanges()
    {
        dgvKetQua.EndEdit();
        ketQuaSource.EndEdit();
        return ketQuaSource.DataSource is DataTable table && table.GetChanges() != null;
    }

    // ---------- Chức năng 5, 6, 7: Lưu tất cả ----------
    private void btnLuuTatCa_Click(object? sender, EventArgs e)
    {
        // Đẩy giá trị ô đang sửa về DataTable trước khi đọc dữ liệu
        dgvKetQua.EndEdit();
        ketQuaSource.EndEdit();

        if (ketQuaSource.DataSource is not DataTable table || table.Rows.Count == 0)
        {
            MessageBox.Show("Chưa có danh sách sinh viên để lưu. Hãy chọn lớp, môn học và bấm Tải danh sách.",
                "Chưa có dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (!ValidateData(table)) return;

        try
        {
            int count = ketQuaDAL.SaveAll(loadedMaMon, table);
            table.AcceptChanges();

            SetStatus($"Đã lưu thành công {count} dòng.");
            MessageBox.Show($"Đã lưu thành công {count} dòng.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            SetStatus("Lưu thất bại, đã hủy toàn bộ (rollback).");
            MessageBox.Show("Không thể lưu dữ liệu. Toàn bộ thao tác lưu đã được hủy (rollback), " +
                "không có dòng nào được ghi vào database.\n\nChi tiết: " + ex.Message,
                "Lỗi khi lưu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ---------- Chức năng 4: Kiểm tra dữ liệu ----------
    /// <summary>Kiểm tra tất cả dòng, đánh dấu dòng lỗi trên lưới. Trả về true nếu mọi dòng hợp lệ.</summary>
    private bool ValidateData(DataTable table)
    {
        ClearRowErrors();
        List<string> errors = new List<string>();

        for (int i = 0; i < table.Rows.Count; i++)
        {
            string? message = GetRowError(table.Rows[i]);
            if (message == null) continue;

            string maSV = Convert.ToString(table.Rows[i]["MaSV"]) ?? string.Empty;
            errors.Add($"{maSV}: {message}");
            if (i < dgvKetQua.Rows.Count) dgvKetQua.Rows[i].ErrorText = message;
        }

        if (errors.Count == 0) return true;

        const int maxShown = 8;
        string detail = string.Join("\n", errors.Take(maxShown).Select(x => "- " + x));
        if (errors.Count > maxShown) detail += $"\n... và {errors.Count - maxShown} dòng khác";

        SetStatus($"Có {errors.Count} dòng không hợp lệ, chưa lưu dòng nào.");
        MessageBox.Show($"Có {errors.Count} dòng không hợp lệ nên chưa lưu dòng nào:\n\n{detail}",
            "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
    }

    /// <summary>Trả về nội dung lỗi của một dòng, hoặc null nếu dòng hợp lệ.</summary>
    private static string? GetRowError(DataRow row)
    {
        object value = row["Diem"];
        if (value is DBNull) return "Chưa nhập điểm.";

        double diem = Convert.ToDouble(value);
        if (double.IsNaN(diem) || diem < 0 || diem > 10) return "Điểm phải từ 0 đến 10.";

        string ghiChu = Convert.ToString(row["GhiChu"]) ?? string.Empty;
        if (ghiChu.Length > 255) return "Ghi chú tối đa 255 ký tự.";

        return null;
    }

    private void ClearRowErrors()
    {
        foreach (DataGridViewRow row in dgvKetQua.Rows)
        {
            row.ErrorText = string.Empty;
        }
    }

    /// <summary>Cột Diem là kiểu số nên chữ cái không vào được DataTable; báo lỗi thân thiện thay vì hộp thoại mặc định.</summary>
    private void dgvKetQua_DataError(object? sender, DataGridViewDataErrorEventArgs e)
    {
        e.ThrowException = false;

        MessageBox.Show("Điểm phải là một số từ 0 đến 10 (ví dụ 8.5).\nNhấn Esc để hủy giá trị vừa nhập.",
            "Điểm không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void SetStatus(string message)
    {
        lblStatus.Text = message;
    }
}
