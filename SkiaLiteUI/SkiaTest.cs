using System.Collections.Generic;
using System;
using SkiaSharp;
using SkiaSharp.HarfBuzz;

namespace SkiaLiteUI;

// adapted from: https://gist.github.com/tottaka/702c5103b9574bcf773cfd53b669b888
public class SkiaTest : IDisposable //, Renderer
{
    // todo: make nullable
    GRGlInterface grgInterface;
    GRContext grContext;
    SKSurface surface;
    GRBackendRenderTarget renderTarget;

    Vector clientSize;
    List<Widget> widgets = new();

    public void Init(int ClientSizeX, int ClientSizeY)
    {
        clientSize = new (ClientSizeX, ClientSizeY);
        grgInterface = GRGlInterface.Create();
        grContext = GRContext.CreateGl(grgInterface);
        // Thana: at this point, Skia is linked to current GLContext
        // see: Skia doc. GrDirectContext::MakeGl()

        uint rgba8 = 32856; // (uint)SizedInternalFormat.Rgba8
        renderTarget = new GRBackendRenderTarget(ClientSizeX, ClientSizeY, 0, 8, 
                                        new GRGlFramebufferInfo(0, rgba8));
        surface = SKSurface.Create(grContext, renderTarget, GRSurfaceOrigin.BottomLeft, SKColorType.Rgba8888);

        Random rand = new Random();
        for (int i = 0; i < 100; ++i)
            widgets.Add(RectWidget.CreateRandom(rand, clientSize, new (256, 256)));
        AddText();
    }

    public void Dispose()
    {
        surface.Dispose();
        renderTarget.Dispose();
        grContext.Dispose();
        grgInterface.Dispose();
    }

    public void Render(float deltaTime)
    {
        SKCanvas canvas = surface.Canvas;
        canvas.Clear(SKColors.CornflowerBlue);

        for (int i = 0; i < widgets.Count; i++)
        {
            var widget = widgets[i];
            widget.Act(deltaTime);
            widget.Draw(canvas);
        }
        //DrawText(canvas);

        canvas.Flush();
    }

/*    void DrawText(SKCanvas canvas)
    {
        var typeface = SKTypeface.FromFile(@"Resources\Trirong-Regular.ttf");
        if (typeface == null) return;
        var font = new SKFont(typeface, 40);

        // ถ้ามีภาษาไทย อักษรตัวแรกต้องเป็นภาษาไทย ถึงจะ format สระบนซ้อนกันได้ถูกต้อง
        var text = "รู้กตัญญูกล้ำกลืนนี้นั้นโน้น abc";

        using SKPaint paint2 = Util.CreatePaint(SKColors.Black);
        canvas.DrawShapedText(text, 128, 300, SKTextAlign.Left, font, paint2);
    }*/
    void AddText()
    {
        var typeface = SKTypeface.FromFile(@"Resources\Trirong-Regular.ttf");
        var font = new SKFont(typeface, 40);

        // ถ้ามีภาษาไทย อักษรตัวแรกต้องเป็นภาษาไทย ถึงจะ format สระบนซ้อนกันได้ถูกต้อง
        var text = "รู้กตัญญูกล้ำกลืนนี้นั้นโน้น abc";
        var widget = new TextWidget() { Font = font, Text = text, Position = new(128, 300) };
        widgets.Add(widget);
    }
}