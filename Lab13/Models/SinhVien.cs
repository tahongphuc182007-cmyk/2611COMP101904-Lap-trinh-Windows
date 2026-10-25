namespace StudentReportDemo.Models;

public class SinhVien
{
    /// <summary>Điểm từ mức này trở lên là Đạt.</summary>
    public const decimal DiemDat = 5m;

    public string MaSV { get; set; } = string.Empty;
    public string HoTen { get; set; } = string.Empty;
    public string MaLop { get; set; } = string.Empty;
    public string TenLop { get; set; } = string.Empty;

    // Dùng decimal để tính điểm trung bình và làm tròn chính xác (ví dụ 6.825 luôn làm tròn thành 6.83)
    public decimal Diem { get; set; }

    /// <summary>Thuộc tính chỉ đọc, tính từ Diem nên không bao giờ lệch với điểm.</summary>
    public string KetQua
    {
        get { return Diem >= DiemDat ? "Đạt" : "Không đạt"; }
    }
}
