using System.Data;
using Microsoft.Data.SqlClient;

namespace COMP1019_Buoi11_Lab11;

public partial class FrmLop : Form
{
    // Mã lớp đang được chọn trong DataGridView (null nếu chưa chọn lớp nào)
    private string? selectedMaLop;

    public FrmLop()
    {
        InitializeComponent();
    }

    // ---------- F1: Load Form ----------
    private void FrmLop_Load(object? sender, EventArgs e)
    {
        txtMaLop.MaxLength = 20;     // khớp VARCHAR(20)
        txtTenLop.MaxLength = 100;   // khớp NVARCHAR(100)
        LoadData();
    }

    // ---------- Hàm truy cập dữ liệu ----------
    private static SqlConnection CreateConnection()
    {
        return new SqlConnection(Db.ConnectionString);
    }

    /// <summary>
    /// Nạp danh sách lớp kèm số sinh viên lên DataGridView.
    /// keyword rỗng thì lấy tất cả; ngược lại tìm theo mã lớp hoặc tên lớp bằng LIKE.
    /// </summary>
    private void LoadData(string keyword = "")
    {
        try
        {
            const string sql = @"SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
                                 FROM LOP l
                                 LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
                                 WHERE l.MaLop LIKE @kw OR l.TenLop LIKE @kw
                                 GROUP BY l.MaLop, l.TenLop
                                 ORDER BY l.MaLop";

            using SqlConnection conn = CreateConnection();
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@kw", SqlDbType.NVarChar, 400).Value = "%" + EscapeLike(keyword) + "%";
            using SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvLop.DataSource = dt;

            SetHeader("MaLop", "Mã lớp");
            SetHeader("TenLop", "Tên lớp");
            SetHeader("SoSinhVien", "Số sinh viên");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SetHeader(string column, string header)
    {
        DataGridViewColumn? col = dgvLop.Columns[column];
        if (col != null) col.HeaderText = header;
    }

    /// <summary>Đưa các ký tự đặc biệt của LIKE (% _ [) về ký tự thường để tìm đúng nghĩa đen.</summary>
    private static string EscapeLike(string text)
    {
        return text.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]");
    }

    private bool IsMaLopExists(string maLop)
    {
        const string sql = "SELECT COUNT(*) FROM LOP WHERE MaLop = @ma";

        using SqlConnection conn = CreateConnection();
        using SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add("@ma", SqlDbType.VarChar, 20).Value = maLop;

        conn.Open();
        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
    }

    private int CountSinhVienByLop(string maLop)
    {
        const string sql = "SELECT COUNT(*) FROM SINHVIEN WHERE MaLop = @ma";

        using SqlConnection conn = CreateConnection();
        using SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add("@ma", SqlDbType.VarChar, 20).Value = maLop;

        conn.Open();
        return Convert.ToInt32(cmd.ExecuteScalar());
    }

    // ---------- Hàm hỗ trợ giao diện ----------
    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtMaLop.Text))
        {
            MessageBox.Show("Vui lòng nhập mã lớp.", "Thiếu dữ liệu",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtMaLop.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtTenLop.Text))
        {
            MessageBox.Show("Vui lòng nhập tên lớp.", "Thiếu dữ liệu",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenLop.Focus();
            return false;
        }

        return true;
    }

    /// <summary>Bỏ chọn lớp, xóa hai ô nhập và mở khóa txtMaLop.</summary>
    private void ClearEditor()
    {
        selectedMaLop = null;
        txtMaLop.ReadOnly = false;
        txtMaLop.Clear();
        txtTenLop.Clear();
        txtMaLop.Focus();
    }

    private void ClearInput()
    {
        ClearEditor();
        txtTimKiem.Clear();
    }

    // ---------- F2: Chọn dòng ----------
    private void dgvLop_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        DataGridViewRow row = dgvLop.Rows[e.RowIndex];
        selectedMaLop = Convert.ToString(row.Cells["MaLop"].Value);
        txtMaLop.Text = selectedMaLop;
        txtTenLop.Text = Convert.ToString(row.Cells["TenLop"].Value);

        // Mã lớp là khóa chính nên không cho sửa khi đang chọn một lớp
        txtMaLop.ReadOnly = true;
    }

    // ---------- F3: Thêm ----------
    private void btnThem_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        string ma = txtMaLop.Text.Trim();
        string ten = txtTenLop.Text.Trim();

        try
        {
            if (IsMaLopExists(ma))
            {
                MessageBox.Show("Mã lớp đã tồn tại.", "Trùng mã",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLop.Focus();
                return;
            }

            const string sql = "INSERT INTO LOP(MaLop, TenLop) VALUES(@ma, @ten)";

            using SqlConnection conn = CreateConnection();
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ma", SqlDbType.VarChar, 20).Value = ma;
            cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = ten;

            conn.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Thêm lớp thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearInput();
            }
        }
        catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
        {
            // Phòng trường hợp có người khác vừa thêm cùng mã lớp
            MessageBox.Show("Mã lớp đã tồn tại.", "Trùng mã",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi thêm lớp: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ---------- F4: Sửa ----------
    private void btnSua_Click(object? sender, EventArgs e)
    {
        if (selectedMaLop == null)
        {
            MessageBox.Show("Vui lòng chọn lớp cần sửa trong danh sách.", "Chưa chọn lớp",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        if (!ValidateInput()) return;

        string ten = txtTenLop.Text.Trim();

        try
        {
            // Chỉ sửa tên lớp, không sửa mã lớp vì đây là khóa chính
            const string sql = "UPDATE LOP SET TenLop = @ten WHERE MaLop = @ma";

            using SqlConnection conn = CreateConnection();
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ma", SqlDbType.VarChar, 20).Value = selectedMaLop;
            cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = ten;

            conn.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Cập nhật lớp thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearInput();
            }
            else
            {
                MessageBox.Show("Không tìm thấy lớp cần sửa (có thể đã bị xóa).", "Không tìm thấy",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi cập nhật lớp: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ---------- F5: Xóa ----------
    private void btnXoa_Click(object? sender, EventArgs e)
    {
        if (selectedMaLop == null)
        {
            MessageBox.Show("Vui lòng chọn lớp cần xóa trong danh sách.", "Chưa chọn lớp",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        string ma = selectedMaLop;

        try
        {
            if (CountSinhVienByLop(ma) > 0)
            {
                MessageBox.Show("Không thể xóa lớp đang có sinh viên.", "Không thể xóa",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa lớp {ma}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            const string sql = "DELETE FROM LOP WHERE MaLop = @ma";

            using SqlConnection conn = CreateConnection();
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ma", SqlDbType.VarChar, 20).Value = ma;

            conn.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Xóa lớp thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearInput();
            }
        }
        catch (SqlException ex) when (ex.Number == 547)
        {
            // Lỗi khóa ngoại: vừa có sinh viên được thêm vào lớp sau bước kiểm tra
            MessageBox.Show("Không thể xóa lớp đang có sinh viên.", "Không thể xóa",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi xóa lớp: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ---------- F6: Tìm kiếm ----------
    private void btnTimKiem_Click(object? sender, EventArgs e)
    {
        ClearEditor();
        LoadData(txtTimKiem.Text.Trim());
    }

    // ---------- F7: Làm mới ----------
    private void btnLamMoi_Click(object? sender, EventArgs e)
    {
        ClearInput();
        LoadData();
    }
}
