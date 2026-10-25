using System.Globalization;
using System.Text;
using StudentReportDemo.Models;

namespace StudentReportDemo.Forms;

public partial class FrmBaoCaoSinhVien : Form
{
    // Tiêu đề tiếng Việt cho các cột của báo cáo và của bảng thống kê
    private static readonly Dictionary<string, string> TieuDeCot = new Dictionary<string, string>
    {
        { "MaSV", "Mã SV" },
        { "HoTen", "Họ tên" },
        { "MaLop", "Mã lớp" },
        { "TenLop", "Lớp" },
        { "Diem", "Điểm" },
        { "KetQua", "Kết quả" },
        { "SoLuong", "Số sinh viên" },
        { "SoDat", "Đạt" },
        { "SoKhongDat", "Không đạt" },
        { "DiemTrungBinh", "Điểm trung bình" }
    };

    // Nguồn dữ liệu gốc; mọi báo cáo đều được truy vấn từ danh sách này bằng LINQ
    private List<SinhVien> danhSachSinhVien = new List<SinhVien>();

    public FrmBaoCaoSinhVien()
    {
        InitializeComponent();
    }

    // ---------- Chức năng 1: Load Form ----------
    private void FrmBaoCaoSinhVien_Load(object? sender, EventArgs e)
    {
        TaoDuLieuMau();
        LoadComboBox();
        XemBaoCao();
    }

    private void TaoDuLieuMau()
    {
        danhSachSinhVien = new List<SinhVien>
        {
            new SinhVien { MaSV = "SV001", HoTen = "Nguyễn Văn An",    MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 8.2m },
            new SinhVien { MaSV = "SV002", HoTen = "Trần Thị Bình",    MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 6.5m },
            new SinhVien { MaSV = "SV003", HoTen = "Lê Minh Cường",    MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 4.8m },
            new SinhVien { MaSV = "SV004", HoTen = "Phạm Thanh Dung",  MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 9.1m },
            new SinhVien { MaSV = "SV005", HoTen = "Hoàng Quốc Huy",   MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 7.4m },
            new SinhVien { MaSV = "SV006", HoTen = "Võ Gia Khang",     MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 3.9m },
            new SinhVien { MaSV = "SV007", HoTen = "Đặng Minh Khôi",   MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 5.5m },
            new SinhVien { MaSV = "SV008", HoTen = "Bùi Thảo Linh",    MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 8.0m },
            new SinhVien { MaSV = "SV009", HoTen = "Ngô Tuấn Minh",    MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 6.0m },
            new SinhVien { MaSV = "SV010", HoTen = "Đỗ Bảo Ngọc",      MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 9.3m },
            new SinhVien { MaSV = "SV011", HoTen = "Huỳnh Gia Phúc",   MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 4.2m },
            new SinhVien { MaSV = "SV012", HoTen = "Mai Anh Thư",      MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 7.8m }
        };
    }

    private void LoadComboBox()
    {
        // Select lấy (mã lớp, tên lớp), Distinct bỏ lớp lặp, OrderBy sắp xếp trước khi binding
        List<Lop> dsLop = danhSachSinhVien
            .Select(sv => new Lop(sv.MaLop, sv.TenLop))
            .Distinct()
            .OrderBy(lop => lop.MaLop)
            .ToList();

        cboLop.DisplayMember = nameof(Lop.TenLop);
        cboLop.ValueMember = nameof(Lop.MaLop);
        cboLop.DataSource = dsLop;

        cboKetQua.Items.Clear();
        cboKetQua.Items.AddRange(new object[] { "Tất cả", "Đạt", "Không đạt" });
        cboKetQua.SelectedIndex = 0;
    }

    // ---------- Chức năng 2, 3, 6: Xem báo cáo ----------
    private void btnXemBaoCao_Click(object? sender, EventArgs e)
    {
        XemBaoCao();
    }

    /// <summary>Lọc theo lớp, kết quả và từ khóa; sắp xếp giảm dần theo điểm; hiển thị lên lưới.</summary>
    private void XemBaoCao()
    {
        if (cboLop.SelectedValue is not string maLop) return;

        string ketQua = cboKetQua.SelectedItem as string ?? "Tất cả";
        string tuKhoa = txtTuKhoa.Text.Trim();

        // Where: lọc theo lớp, rồi thêm điều kiện nếu người dùng chọn
        IEnumerable<SinhVien> query = danhSachSinhVien.Where(sv => sv.MaLop == maLop);

        if (ketQua == "Đạt")
        {
            query = query.Where(sv => sv.Diem >= SinhVien.DiemDat);
        }
        else if (ketQua == "Không đạt")
        {
            query = query.Where(sv => sv.Diem < SinhVien.DiemDat);
        }

        if (tuKhoa.Length > 0)
        {
            query = query.Where(sv =>
                sv.MaSV.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase) ||
                sv.HoTen.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase));
        }

        // OrderByDescending + ThenBy: điểm giảm dần, bằng điểm thì theo họ tên; Select chọn cột hiển thị
        var baoCao = query
            .OrderByDescending(sv => sv.Diem)
            .ThenBy(sv => sv.HoTen)
            .Select(sv => new { sv.MaSV, sv.HoTen, sv.TenLop, sv.Diem, sv.KetQua })
            .ToList();

        HienThiBang(baoCao);
        CapNhatThongKe(baoCao.Count);

        if (baoCao.Count == 0)
        {
            MessageBox.Show("Không có sinh viên nào phù hợp với điều kiện đã chọn.", "Không có dữ liệu",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    /// <summary>Thống kê của lớp đang chọn: tổng số, số đạt, số không đạt, điểm trung bình.</summary>
    private void CapNhatThongKe(int soDongHienThi)
    {
        string maLop = cboLop.SelectedValue as string ?? string.Empty;

        List<SinhVien> dsLop = danhSachSinhVien
            .Where(sv => sv.MaLop == maLop)
            .ToList();

        int tongSo = dsLop.Count;
        int soDat = dsLop.Count(sv => sv.Diem >= SinhVien.DiemDat);
        int soKhongDat = dsLop.Count(sv => sv.Diem < SinhVien.DiemDat);

        // Average trên danh sách rỗng sẽ ném lỗi nên phải kiểm tra tongSo trước
        decimal diemTB = tongSo > 0 ? dsLop.Average(sv => sv.Diem) : 0m;

        lblThongKe.Text = $"Đang hiển thị: {soDongHienThi} | Tổng sinh viên của lớp: {tongSo} | " +
                          $"Đạt: {soDat} | Không đạt: {soKhongDat} | Điểm trung bình: {diemTB:0.00}";
    }

    // ---------- Chức năng 4: Thống kê theo lớp ----------
    private void btnThongKe_Click(object? sender, EventArgs e)
    {
        // GroupBy gom sinh viên theo lớp, Select tính số lượng, số đạt, số không đạt, điểm trung bình
        var thongKe = danhSachSinhVien
            .GroupBy(sv => new { sv.MaLop, sv.TenLop })
            .Select(g => new
            {
                g.Key.MaLop,
                g.Key.TenLop,
                SoLuong = g.Count(),
                SoDat = g.Count(sv => sv.Diem >= SinhVien.DiemDat),
                SoKhongDat = g.Count(sv => sv.Diem < SinhVien.DiemDat),
                DiemTrungBinh = Math.Round(g.Average(sv => sv.Diem), 2, MidpointRounding.AwayFromZero)
            })
            .OrderBy(x => x.MaLop)
            .ToList();

        HienThiBang(thongKe);

        int tongSinhVien = danhSachSinhVien.Count;
        decimal diemChung = tongSinhVien > 0 ? danhSachSinhVien.Average(sv => sv.Diem) : 0m;
        lblThongKe.Text = $"Thống kê theo lớp: {thongKe.Count} lớp | Tổng sinh viên: {tongSinhVien} | " +
                          $"Điểm trung bình chung: {diemChung:0.00}";
    }

    // ---------- Hiển thị lên DataGridView ----------
    private void HienThiBang<T>(List<T> duLieu)
    {
        dgvBaoCao.DataSource = duLieu;

        foreach (DataGridViewColumn cot in dgvBaoCao.Columns)
        {
            if (TieuDeCot.TryGetValue(cot.Name, out string? tieuDe))
            {
                cot.HeaderText = tieuDe;
            }

            if (cot.Name == "Diem") cot.DefaultCellStyle.Format = "0.0";
            if (cot.Name == "DiemTrungBinh") cot.DefaultCellStyle.Format = "0.00";
        }
    }

    // ---------- Chức năng 5: Xuất file ----------
    private void btnXuatFile_Click(object? sender, EventArgs e)
    {
        XuatFile();
    }

    private void XuatFile()
    {
        if (dgvBaoCao.Rows.Count == 0)
        {
            MessageBox.Show("Không có dữ liệu để xuất. Hãy bấm Xem báo cáo hoặc Thống kê trước.",
                "Không có dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using SaveFileDialog hopThoai = new SaveFileDialog();
        hopThoai.Title = "Xuất báo cáo";
        hopThoai.Filter = "CSV file (*.csv)|*.csv|Text file (*.txt)|*.txt";
        hopThoai.FileName = "BaoCaoSinhVien";
        hopThoai.DefaultExt = "csv";
        hopThoai.AddExtension = true;

        if (hopThoai.ShowDialog() != DialogResult.OK) return;

        try
        {
            // CSV ngăn cách bằng dấu phẩy, TXT ngăn cách bằng tab
            bool laTxt = Path.GetExtension(hopThoai.FileName).Equals(".txt", StringComparison.OrdinalIgnoreCase);
            char kyTuNganCach = laTxt ? '\t' : ',';

            string noiDung = TaoNoiDungFile(kyTuNganCach);

            // UTF-8 có BOM để Excel và Notepad đọc đúng tiếng Việt
            File.WriteAllText(hopThoai.FileName, noiDung, new UTF8Encoding(true));

            MessageBox.Show("Xuất file thành công:\n" + hopThoai.FileName, "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (IOException ex)
        {
            MessageBox.Show("Không ghi được file. File có thể đang được mở bởi chương trình khác.\n\n" + ex.Message,
                "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (UnauthorizedAccessException ex)
        {
            MessageBox.Show("Không có quyền ghi vào vị trí đã chọn. Hãy chọn thư mục khác.\n\n" + ex.Message,
                "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi xuất file",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>Tạo nội dung file từ đúng dữ liệu đang hiển thị trên lưới (dòng tiêu đề rồi các dòng dữ liệu).</summary>
    private string TaoNoiDungFile(char kyTuNganCach)
    {
        List<DataGridViewColumn> cacCot = dgvBaoCao.Columns
            .Cast<DataGridViewColumn>()
            .Where(c => c.Visible)
            .OrderBy(c => c.DisplayIndex)
            .ToList();

        StringBuilder sb = new StringBuilder();

        sb.AppendLine(string.Join(kyTuNganCach, cacCot.Select(c => BaoVeTruong(c.HeaderText, kyTuNganCach))));

        foreach (DataGridViewRow dong in dgvBaoCao.Rows)
        {
            if (dong.IsNewRow) continue;

            sb.AppendLine(string.Join(kyTuNganCach, cacCot.Select(c =>
                BaoVeTruong(DinhDangGiaTri(dong.Cells[c.Index].Value, c.DefaultCellStyle.Format), kyTuNganCach))));
        }

        return sb.ToString();
    }

    /// <summary>Định dạng số theo InvariantCulture (dấu chấm thập phân) để dấu phẩy không lẫn với dấu ngăn cách của CSV.</summary>
    private static string DinhDangGiaTri(object? giaTri, string dinhDang)
    {
        if (giaTri == null) return string.Empty;

        if (giaTri is IFormattable coTheDinhDang && !string.IsNullOrEmpty(dinhDang))
        {
            return coTheDinhDang.ToString(dinhDang, CultureInfo.InvariantCulture);
        }

        return Convert.ToString(giaTri, CultureInfo.InvariantCulture) ?? string.Empty;
    }

    /// <summary>Đặt trường trong dấu nháy kép nếu chứa ký tự ngăn cách, dấu nháy kép hoặc xuống dòng (chuẩn CSV).</summary>
    private static string BaoVeTruong(string giaTri, char kyTuNganCach)
    {
        bool canBaoVe = giaTri.Contains(kyTuNganCach) || giaTri.Contains('"') ||
                        giaTri.Contains('\n') || giaTri.Contains('\r');

        return canBaoVe ? "\"" + giaTri.Replace("\"", "\"\"") + "\"" : giaTri;
    }
}
