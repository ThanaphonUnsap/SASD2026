using SkiaSharp;
using System;
using System.Collections.Generic;

namespace SkiaLiteUI;

public abstract class Widget
{
    public virtual void Act(float deltaTime) { }
    public abstract void Draw(SKCanvas canvas);
}

public class RectWidget : Widget
{
    public Vector Position { get; }
    public Vector Size { get; }
    public SKColor Color { get; init; } = SKColors.White;
    public float Radius { get; set; } = 0;

    public RectWidget(Vector origin, Vector size)
    {
        Position = origin;
        Size = size;
        var rand = new Random();
        time = rand.NextSingle() * 5;
    }

    float time = 0;
    public override void Act(float deltaTime)
    {
        time += deltaTime;
        this.Radius = MathF.Max((MathF.Sin(time) + 1) * 64.0f, 0);
    }

    public override void Draw(SKCanvas canvas)
    {
        using SKPaint paint = Util.CreatePaint(this.Color);
        canvas.DrawRoundRect(new SKRoundRect((SKRect)this, this.Radius), paint);
    }

    public static explicit operator SKRect(RectWidget r)
    {
        return new SKRect(  r.Position.X, r.Position.Y, // todo: Symmetry Format
                            r.Position.X + r.Size.X,
                            r.Position.Y + r.Size.Y);
    }

    // todo: Where this method should move into ?
    public static RectWidget CreateRandom(Random rand, Vector max, Vector size)
    {
        var widget = new RectWidget(rand.NextVector(max), size)
                            { Color = rand.NextColor() };
        //if(GlobalRandom.Obj.Next(2) == 1)
        //    widget.AddAction(new RectAnimation(widget));

        //widget.Children.Add(new RectWidget(widget.Position, widget.Size / 4));
        return widget;
    }
}
