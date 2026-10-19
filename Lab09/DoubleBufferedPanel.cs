namespace COMP1019_Lab09_StudentCard;

/// <summary>Panel bật DoubleBuffered để vẽ preview không bị nhấp nháy.</summary>
public class DoubleBufferedPanel : Panel
{
    public DoubleBufferedPanel()
    {
        DoubleBuffered = true;
        ResizeRedraw = true;
    }
}
