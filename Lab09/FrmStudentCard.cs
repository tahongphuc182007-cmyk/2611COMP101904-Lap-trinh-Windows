using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Drawing.Text;

namespace COMP1019_Lab09_StudentCard;

public partial class FrmStudentCard : Form
{
    // Kích thước thiết kế của thẻ (đơn vị tự chọn). Mọi thứ trên thẻ được vẽ theo
    // hệ tọa độ này rồi phóng to/thu nhỏ cho vừa Panel preview hoặc trang in.
    private const float CardW = 856f;
    private const float CardH = 540f;

    private static readonly DateTime DefaultBirthDate = new DateTime(2005, 1, 1);

    // Ảnh đại diện (bản sao trong bộ nhớ, không giữ khóa file gốc)
    private Bitmap? studentPhoto;

    public FrmStudentCard()
    {
        InitializeComponent();
    }

    // ---------- Form Load / Closed ----------
    private void FrmStudentCard_Load(object? sender, EventArgs e)
    {
        cboLop.Items.AddRange(new object[] { "K49-CNTT-A", "K49-CNTT-B", "K50-CNTT-A", "K51-CNTT-A" });
        cboKhoa.Items.AddRange(new object[] { "Công nghệ thông tin", "Toán - Tin học", "Vật lý", "Ngữ văn", "Tiếng Anh" });
        cboKhoaHoc.Items.AddRange(new object[] { "K49", "K50", "K51" });
        cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });

        ResetForm();
    }

    private void FrmStudentCard_FormClosed(object? sender, FormClosedEventArgs e)
    {
        picAnh.Image = null;
        studentPhoto?.Dispose();
        studentPhoto = null;
    }

    // ---------- Hàm hỗ trợ: dữ liệu và ảnh ----------
    private void ResetForm()
    {
        txtMaSV.Clear();
        txtHoTen.Clear();
        dtpNgaySinh.Value = DefaultBirthDate;
        cboGioiTinh.SelectedIndex = 0;
        cboLop.SelectedIndex = 0;
        cboKhoa.SelectedIndex = 0;
        cboKhoaHoc.SelectedIndex = 0;
        SetPhoto(null);
        errorProvider1.Clear();
        txtMaSV.Focus();
        pnlPreview.Invalidate();
    }

    /// <summary>Gán ảnh mới, giải phóng ảnh cũ sau khi đã thay thế trong PictureBox.</summary>
    private void SetPhoto(Bitmap? photo)
    {
        Bitmap? old = studentPhoto;
        studentPhoto = photo;
        picAnh.Image = photo;
        old?.Dispose();

        errorProvider1.SetError(btnChonAnh, string.Empty);
        pnlPreview.Invalidate();
    }

    /// <summary>
    /// Đọc ảnh từ file vào bộ nhớ rồi đóng file ngay (không khóa file),
    /// thu nhỏ nếu ảnh quá lớn nhưng luôn giữ đúng tỉ lệ.
    /// </summary>
    private static Bitmap LoadPhoto(string path)
    {
        const int maxSize = 800;

        using FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        using Image source = Image.FromStream(stream);

        double ratio = Math.Min(1.0, (double)maxSize / Math.Max(source.Width, source.Height));
        int width = Math.Max(1, (int)(source.Width * ratio));
        int height = Math.Max(1, (int)(source.Height * ratio));

        Bitmap copy = new Bitmap(width, height);
        using (Graphics g = Graphics.FromImage(copy))
        {
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(source, 0, 0, width, height);
        }
        return copy;
    }

    // ---------- Validation (F3) ----------
    private bool ValidateForPrint()
    {
        errorProvider1.Clear();
        List<string> missing = new List<string>();
        Control? firstInvalid = null;

        if (string.IsNullOrWhiteSpace(txtMaSV.Text))
        {
            errorProvider1.SetError(txtMaSV, "Mã sinh viên không được rỗng");
            missing.Add("mã sinh viên");
            firstInvalid ??= txtMaSV;
        }

        if (string.IsNullOrWhiteSpace(txtHoTen.Text))
        {
            errorProvider1.SetError(txtHoTen, "Họ tên không được rỗng");
            missing.Add("họ tên");
            firstInvalid ??= txtHoTen;
        }

        if (studentPhoto == null)
        {
            errorProvider1.SetError(btnChonAnh, "Chưa chọn ảnh đại diện");
            missing.Add("ảnh đại diện");
            firstInvalid ??= btnChonAnh;
        }

        if (missing.Count > 0)
        {
            MessageBox.Show("Vui lòng bổ sung: " + string.Join(", ", missing) + ".", "Thiếu dữ liệu bắt buộc",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            firstInvalid?.Focus();
            return false;
        }

        return true;
    }

    // ---------- Vẽ thẻ bằng GDI+ (dùng chung cho Panel preview và bản in) ----------
    /// <summary>
    /// Vẽ thẻ sinh viên vào hình chữ nhật bounds của Graphics g.
    /// Dùng GraphicsUnit.World cho Font để chữ co giãn theo ScaleTransform ở mọi đơn vị trang.
    /// </summary>
    private void DrawCard(Graphics g, RectangleF bounds)
    {
        GraphicsState state = g.Save();
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.TextRenderingHint = TextRenderingHint.AntiAlias;
        g.TranslateTransform(bounds.X, bounds.Y);
        g.ScaleTransform(bounds.Width / CardW, bounds.Height / CardH);

        Color mainColor = Color.FromArgb(31, 78, 140);

        using SolidBrush backBrush = new SolidBrush(Color.FromArgb(234, 244, 255));
        using SolidBrush headerBrush = new SolidBrush(mainColor);
        using SolidBrush whiteBrush = new SolidBrush(Color.White);
        using SolidBrush goldBrush = new SolidBrush(Color.FromArgb(255, 214, 102));
        using SolidBrush labelBrush = new SolidBrush(Color.FromArgb(80, 80, 80));
        using SolidBrush valueBrush = new SolidBrush(Color.Black);
        using SolidBrush grayBrush = new SolidBrush(Color.FromArgb(225, 225, 225));
        using Pen borderPen = new Pen(mainColor, 10f);
        using Pen photoPen = new Pen(mainColor, 3f);

        using Font schoolFont = new Font("Segoe UI", 26f, FontStyle.Bold, GraphicsUnit.World);
        using Font titleFont = new Font("Segoe UI", 44f, FontStyle.Bold, GraphicsUnit.World);
        using Font labelFont = new Font("Segoe UI", 22f, FontStyle.Regular, GraphicsUnit.World);
        using Font valueFont = new Font("Segoe UI", 24f, FontStyle.Bold, GraphicsUnit.World);
        using Font hintFont = new Font("Segoe UI", 24f, FontStyle.Regular, GraphicsUnit.World);

        using StringFormat centerFormat = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center,
            Trimming = StringTrimming.EllipsisCharacter,
            FormatFlags = StringFormatFlags.NoWrap
        };
        using StringFormat leftFormat = new StringFormat
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center,
            Trimming = StringTrimming.EllipsisCharacter,
            FormatFlags = StringFormatFlags.NoWrap
        };

        // Nền, dải tiêu đề, khung ngoài
        g.FillRectangle(backBrush, 0f, 0f, CardW, CardH);
        g.FillRectangle(headerBrush, 0f, 0f, CardW, 150f);
        g.DrawRectangle(borderPen, 5f, 5f, CardW - 10f, CardH - 10f);

        // Tên trường và tiêu đề
        g.DrawString("TRƯỜNG ĐẠI HỌC SƯ PHẠM TP. HỒ CHÍ MINH", schoolFont, whiteBrush,
            new RectangleF(10f, 18f, CardW - 20f, 50f), centerFormat);
        g.DrawString("THẺ SINH VIÊN", titleFont, goldBrush,
            new RectangleF(10f, 68f, CardW - 20f, 70f), centerFormat);

        // Ảnh sinh viên bên trái (giữ đúng tỉ lệ, không méo)
        RectangleF photoRect = new RectangleF(40f, 175f, 240f, 320f);
        if (studentPhoto != null)
        {
            g.FillRectangle(whiteBrush, photoRect);
            float scale = Math.Min(photoRect.Width / studentPhoto.Width, photoRect.Height / studentPhoto.Height);
            float drawW = studentPhoto.Width * scale;
            float drawH = studentPhoto.Height * scale;
            float drawX = photoRect.X + (photoRect.Width - drawW) / 2f;
            float drawY = photoRect.Y + (photoRect.Height - drawH) / 2f;
            g.DrawImage(studentPhoto, drawX, drawY, drawW, drawH);
        }
        else
        {
            g.FillRectangle(grayBrush, photoRect);
            g.DrawString("Ảnh 3x4", hintFont, labelBrush, photoRect, centerFormat);
        }
        g.DrawRectangle(photoPen, photoRect.X, photoRect.Y, photoRect.Width, photoRect.Height);

        // Thông tin sinh viên bên phải
        (string Label, string Value)[] rows =
        {
            ("Mã SV:", txtMaSV.Text.Trim()),
            ("Họ tên:", txtHoTen.Text.Trim()),
            ("Ngày sinh:", dtpNgaySinh.Value.ToString("dd/MM/yyyy")),
            ("Giới tính:", cboGioiTinh.Text),
            ("Lớp:", cboLop.Text),
            ("Khoa:", cboKhoa.Text),
            ("Khóa:", cboKhoaHoc.Text)
        };

        float y = 172f;
        foreach (var row in rows)
        {
            g.DrawString(row.Label, labelFont, labelBrush, new RectangleF(310f, y, 160f, 44f), leftFormat);
            g.DrawString(row.Value, valueFont, valueBrush, new RectangleF(470f, y, 366f, 44f), leftFormat);
            y += 48f;
        }

        g.Restore(state);
    }

    // ---------- Sự kiện: preview ----------
    private void pnlPreview_Paint(object? sender, PaintEventArgs e)
    {
        e.Graphics.Clear(pnlPreview.BackColor);

        const float margin = 15f;
        float availW = pnlPreview.ClientSize.Width - 2 * margin;
        float availH = pnlPreview.ClientSize.Height - 2 * margin;
        if (availW <= 0 || availH <= 0) return;

        // Giữ đúng tỉ lệ thẻ, đặt giữa Panel
        float aspect = CardW / CardH;
        float width = Math.Min(availW, availH * aspect);
        float height = width / aspect;
        RectangleF cardRect = new RectangleF(
            (pnlPreview.ClientSize.Width - width) / 2f,
            (pnlPreview.ClientSize.Height - height) / 2f,
            width, height);

        DrawCard(e.Graphics, cardRect);
    }

    // Dùng chung cho mọi control nhập liệu: vẽ lại preview và xóa báo lỗi của control đó
    private void InputChanged(object? sender, EventArgs e)
    {
        if (sender is Control control)
        {
            errorProvider1.SetError(control, string.Empty);
        }
        pnlPreview.Invalidate();
    }

    // ---------- Sự kiện: nút lệnh ----------
    private void btnChonAnh_Click(object? sender, EventArgs e)
    {
        using OpenFileDialog dialog = new OpenFileDialog();
        dialog.Title = "Chọn ảnh đại diện";
        dialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

        if (dialog.ShowDialog() != DialogResult.OK) return;

        try
        {
            SetPhoto(LoadPhoto(dialog.FileName));
        }
        catch (Exception ex) when (ex is ArgumentException or OutOfMemoryException
                                       or IOException or UnauthorizedAccessException)
        {
            MessageBox.Show("Không thể mở file ảnh này. Vui lòng chọn file JPG, PNG hoặc BMP hợp lệ.",
                "Lỗi ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnLamMoi_Click(object? sender, EventArgs e)
    {
        ResetForm();
    }

    private void btnXemTruocIn_Click(object? sender, EventArgs e)
    {
        if (!ValidateForPrint()) return;

        try
        {
            using PrintPreviewDialog dialog = new PrintPreviewDialog();
            dialog.Document = printDocument1;
            dialog.Width = 900;
            dialog.Height = 700;
            dialog.ShowDialog();
        }
        catch (InvalidPrinterException)
        {
            ShowNoPrinterMessage();
        }
    }

    private void btnIn_Click(object? sender, EventArgs e)
    {
        if (!ValidateForPrint()) return;

        try
        {
            using PrintDialog dialog = new PrintDialog();
            dialog.Document = printDocument1;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        catch (InvalidPrinterException)
        {
            ShowNoPrinterMessage();
        }
        catch (Win32Exception ex)
        {
            MessageBox.Show("Lỗi khi in: " + ex.Message, "Lỗi in ấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnThoat_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private static void ShowNoPrinterMessage()
    {
        MessageBox.Show("Không tìm thấy máy in. Hãy cài đặt máy in (ví dụ Microsoft Print to PDF) rồi thử lại.",
            "Không có máy in", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    // ---------- In ấn ----------
    private void printDocument1_PrintPage(object? sender, PrintPageEventArgs e)
    {
        Graphics? g = e.Graphics;
        if (g == null) return;

        // Kích thước thẻ thật 85,6 x 54 mm, đổi sang 1/100 inch (đơn vị của trang in)
        const float cardWidth = 337f;
        const float cardHeight = 213f;

        // Đặt thẻ ở giữa theo chiều ngang, sát lề trên
        RectangleF cardRect = new RectangleF(
            e.MarginBounds.Left + (e.MarginBounds.Width - cardWidth) / 2f,
            e.MarginBounds.Top,
            cardWidth, cardHeight);

        DrawCard(g, cardRect);
        e.HasMorePages = false;
    }
}
