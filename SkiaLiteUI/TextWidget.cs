using SkiaSharp;
using SkiaSharp.HarfBuzz;

namespace SkiaLiteUI;

public class TextWidget : Widget
{
    public Vector Position { get; set; }
    public string Text { get; set; } = "";
    public required SKFont Font { get; set; }

    public override void Draw(SKCanvas canvas)
    {
        using SKPaint paint = Util.CreatePaint(SKColors.Black);
        canvas.DrawShapedText(Text, Position.X, Position.Y,
                                SKTextAlign.Left, Font, paint);
    }
}
