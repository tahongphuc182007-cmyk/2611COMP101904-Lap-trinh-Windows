using System.Drawing.Drawing2D;

namespace COMP1019_Lab08_SimplePaint;

public partial class FrmPaint : Form
{
    // Danh sách đối tượng đã vẽ (dữ liệu gốc, dùng để vẽ lại khi Paint)
    private readonly List<DrawItem> items = new List<DrawItem>();

    // Nét đang vẽ dở (đang giữ chuột), chưa được thêm vào danh sách
    private DrawItem? currentItem;
    private bool isDrawing;
    private Color currentColor = Color.Black;

    public FrmPaint()
    {
        InitializeComponent();
    }

    // ---------- Form Load ----------
    private void FrmPaint_Load(object? sender, EventArgs e)
    {
        cboMode.Items.AddRange(new object[] { "Pen", "Line", "Rectangle", "Ellipse" });
        cboMode.SelectedIndex = 0;

        nudWidth.Minimum = 1;
        nudWidth.Maximum = 20;
        nudWidth.Value = 2;

        pnlColorPreview.BackColor = currentColor;
        lblStatus.Text = "Tọa độ: -";
    }

    // ---------- Hàm hỗ trợ ----------
    private ShapeType GetSelectedShape()
    {
        return cboMode.SelectedIndex >= 0 ? (ShapeType)cboMode.SelectedIndex : ShapeType.Pen;
    }

    /// <summary>
    /// Tạo Rectangle chuẩn hóa từ hai điểm, xử lý được trường hợp kéo chuột theo mọi hướng.
    /// </summary>
    private static Rectangle GetRectangle(Point p1, Point p2)
    {
        int x = Math.Min(p1.X, p2.X);
        int y = Math.Min(p1.Y, p2.Y);
        int width = Math.Abs(p1.X - p2.X);
        int height = Math.Abs(p1.Y - p2.Y);
        return new Rectangle(x, y, width, height);
    }

    /// <summary>Vẽ một đối tượng lên Graphics.</summary>
    private static void DrawShape(Graphics g, DrawItem item)
    {
        using Pen pen = new Pen(item.Color, item.Width)
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round,
            LineJoin = LineJoin.Round
        };

        switch (item.Shape)
        {
            case ShapeType.Pen:
                if (item.Points.Count == 1)
                {
                    // Chỉ nhấp chuột một lần: vẽ một chấm tròn
                    using SolidBrush brush = new SolidBrush(item.Color);
                    Point p = item.Points[0];
                    float r = item.Width / 2f;
                    g.FillEllipse(brush, p.X - r, p.Y - r, item.Width, item.Width);
                }
                else if (item.Points.Count > 1)
                {
                    g.DrawLines(pen, item.Points.ToArray());
                }
                break;

            case ShapeType.Line:
                g.DrawLine(pen, item.Start, item.End);
                break;

            case ShapeType.Rectangle:
                g.DrawRectangle(pen, GetRectangle(item.Start, item.End));
                break;

            case ShapeType.Ellipse:
                g.DrawEllipse(pen, GetRectangle(item.Start, item.End));
                break;
        }
    }

    // ---------- Sự kiện canvas ----------
    private void canvas_Paint(object? sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        // Vẽ lại toàn bộ các nét đã lưu
        foreach (DrawItem item in items)
        {
            DrawShape(e.Graphics, item);
        }

        // Vẽ nét đang kéo chuột (xem trước)
        if (currentItem != null)
        {
            DrawShape(e.Graphics, currentItem);
        }
    }

    private void canvas_MouseDown(object? sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left) return;

        currentItem = new DrawItem
        {
            Shape = GetSelectedShape(),
            Color = currentColor,
            Width = (int)nudWidth.Value,
            Start = e.Location,
            End = e.Location
        };

        if (currentItem.Shape == ShapeType.Pen)
        {
            currentItem.Points.Add(e.Location);
        }

        isDrawing = true;
        canvas.Invalidate();
    }

    private void canvas_MouseMove(object? sender, MouseEventArgs e)
    {
        lblStatus.Text = $"Tọa độ: X = {e.X}, Y = {e.Y}";

        if (!isDrawing || currentItem == null) return;

        if (currentItem.Shape == ShapeType.Pen)
        {
            Point last = currentItem.Points[currentItem.Points.Count - 1];
            if (last != e.Location) currentItem.Points.Add(e.Location);
        }
        else
        {
            currentItem.End = e.Location;
        }

        canvas.Invalidate();
    }

    private void canvas_MouseUp(object? sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left || !isDrawing || currentItem == null) return;

        isDrawing = false;

        if (currentItem.Shape == ShapeType.Pen)
        {
            Point last = currentItem.Points[currentItem.Points.Count - 1];
            if (last != e.Location) currentItem.Points.Add(e.Location);
            items.Add(currentItem);
        }
        else
        {
            currentItem.End = e.Location;
            // Bỏ qua hình có kích thước bằng 0 (nhấp chuột mà không kéo)
            if (currentItem.Start != currentItem.End) items.Add(currentItem);
        }

        currentItem = null;
        canvas.Invalidate();
    }

    private void canvas_MouseLeave(object? sender, EventArgs e)
    {
        if (!isDrawing) lblStatus.Text = "Tọa độ: -";
    }

    // ---------- Các nút ----------
    private void btnColor_Click(object? sender, EventArgs e)
    {
        using ColorDialog dialog = new ColorDialog();
        dialog.Color = currentColor;

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            currentColor = dialog.Color;
            pnlColorPreview.BackColor = currentColor;
        }
    }

    private void btnUndo_Click(object? sender, EventArgs e)
    {
        if (items.Count == 0)
        {
            lblStatus.Text = "Không còn nét vẽ để hoàn tác";
            return;
        }

        items.RemoveAt(items.Count - 1);
        canvas.Invalidate();
    }

    private void btnClear_Click(object? sender, EventArgs e)
    {
        items.Clear();
        currentItem = null;
        isDrawing = false;
        canvas.Invalidate();
    }
}
