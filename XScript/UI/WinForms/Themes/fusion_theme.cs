using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

//------------------
//Creator: aeonhack
//Site: elitevs.net
//Created: 9/23/2011
//Changed: 9/23/2011
//Version: 1.0.0
//Theme Base: 1.5.2
//------------------
public class FusionTheme : ThemeContainer152
{
    private readonly ColorBlend Blend;
    private readonly GraphicsPath Path;
    private SolidBrush B1;
    private SolidBrush B2;
    private Color C1;
    private Color C2;
    private Color C3;
    private Pen P1;
    private Pen P2;
    private Pen P3;
    private Pen P4;
    private Pen P5;
    private Rectangle RT1;

    public FusionTheme()
    {
        MoveHeight = 34;
        BackColor = Color.White;
        TransparencyKey = Color.Fuchsia;

        SetColor("Sides", 47, 47, 50);
        SetColor("Gradient1", 52, 52, 55);
        SetColor("Gradient2", 47, 47, 50);
        SetColor("Text", Color.White);
        SetColor("Back", Color.White);
        SetColor("Border1", Color.Black);
        SetColor("Border2", 60, 60, 63);
        SetColor("Border3", 60, 60, 63);
        SetColor("Border4", Color.Black);
        SetColor("Blend1", Color.Transparent);
        SetColor("Blend2", 60, 60, 63);

        Path = new GraphicsPath();

        Blend = new ColorBlend();
        Blend.Positions = new[]
        {
            0f,
            0.5f,
            1f
        };
    }

    protected override void ColorHook()
    {
        P1 = new Pen(TransparencyKey, 3);
        P2 = new Pen(GetColor("Border1"));
        P3 = new Pen(GetColor("Border2"));
        P4 = new Pen(GetColor("Border3"));
        P5 = new Pen(GetColor("Border4"));

        C1 = GetColor("Sides");
        C2 = GetColor("Gradient1");
        C3 = GetColor("Gradient2");

        B1 = new SolidBrush(GetColor("Text"));
        B2 = new SolidBrush(GetColor("Back"));

        Blend.Colors = new[]
        {
            GetColor("Blend1"),
            GetColor("Blend2"),
            GetColor("Blend1")
        };

        BackColor = B2.Color;
    }

    protected override void PaintHook()
    {
        G.DrawRectangle(P1, ClientRectangle);
        G.SetClip(Path);

        G.Clear(C1);

        DrawGradient(C2, C3, 0, 0, 16, Height);
        DrawGradient(C2, C3, Width - 16, 0, 16, Height);

        DrawText(B1, HorizontalAlignment.Left, 12, 0);

        RT1 = new Rectangle(12, 34, Width - 24, Height - 34 - 12);

        G.FillRectangle(B2, RT1);
        DrawBorders(P2, RT1, 1);
        DrawBorders(P3, RT1);

        DrawBorders(P4, 1);
        DrawGradient(Blend, 1, 1, Width - 2, 2, 0f);

        G.ResetClip();
        G.DrawPath(P5, Path);
    }

    protected override void OnResize(EventArgs e)
    {
        Path.Reset();
        Path.AddLines(new[]
        {
            new Point(2, 0),
            new Point(Width - 3, 0),
            new Point(Width - 1, 2),
            new Point(Width - 1, Height - 3),
            new Point(Width - 3, Height - 1),
            new Point(2, Height - 1),
            new Point(0, Height - 3),
            new Point(0, 2),
            new Point(2, 0)
        });

        base.OnResize(e);
    }
}

//------------------
//Creator: aeonhack
//Site: elitevs.net
//Created: 9/23/2011
//Changed: 9/23/2011
//Version: 1.0.0
//Theme Base: 1.5.2
//------------------
public class FusionButton : ThemeControl152
{
    private SolidBrush B1;
    private SolidBrush B2;
    private Color C1;
    private Color C2;
    private Color C3;
    private Color C4;
    private Pen P1;
    private Pen P2;

    public FusionButton()
    {
        SetColor("DownGradient1", 255, 127, 1);
        SetColor("DownGradient2", 255, 175, 12);
        SetColor("NoneGradient1", 255, 175, 12);
        SetColor("NoneGradient2", 255, 127, 1);
        SetColor("TextShade", 30, Color.Black);
        SetColor("Text", Color.White);
        SetColor("Border1", 255, 197, 19);
        SetColor("Border2", 254, 133, 0);
    }

    protected override void ColorHook()
    {
        C1 = GetColor("DownGradient1");
        C2 = GetColor("DownGradient2");
        C3 = GetColor("NoneGradient1");
        C4 = GetColor("NoneGradient2");

        B1 = new SolidBrush(GetColor("TextShade"));
        B2 = new SolidBrush(GetColor("Text"));

        P1 = new Pen(GetColor("Border1"));
        P2 = new Pen(GetColor("Border2"));
    }

    protected override void PaintHook()
    {
        if (State == MouseState.Down)
        {
            DrawGradient(C1, C2, ClientRectangle, 90f);
        }
        else
        {
            DrawGradient(C3, C4, ClientRectangle, 90f);
        }

        DrawText(B1, HorizontalAlignment.Center, 1, 1);
        DrawText(B2, HorizontalAlignment.Center, 0, 0);

        DrawBorders(P1, 1);
        DrawBorders(P2);

        DrawCorners(BackColor);
    }
}