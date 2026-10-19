namespace COMP1019_Lab08_SimplePaint;

/// <summary>Loại hình có thể vẽ. Thứ tự khớp với thứ tự mục trong cboMode.</summary>
public enum ShapeType
{
    Pen,
    Line,
    Rectangle,
    Ellipse
}

/// <summary>Dữ liệu gốc của một nét vẽ, dùng để vẽ lại trong sự kiện Paint.</summary>
public class DrawItem
{
    public ShapeType Shape { get; set; }
    public Color Color { get; set; } = Color.Black;
    public int Width { get; set; } = 1;

    /// <summary>Điểm bắt đầu (Line, Rectangle, Ellipse).</summary>
    public Point Start { get; set; }

    /// <summary>Điểm kết thúc (Line, Rectangle, Ellipse).</summary>
    public Point End { get; set; }

    /// <summary>Danh sách các điểm của nét vẽ tự do (Pen).</summary>
    public List<Point> Points { get; } = new List<Point>();
}
