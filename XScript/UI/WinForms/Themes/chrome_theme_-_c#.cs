using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

// Google Chrome Theme - Ported to C# by Ecco
// Original Theme http://www.hackforums.net/showthread.php?tid=2926688
// Credit to Mavamaarten~ for Google Chrome Theme & Aeonhack for Themebase

public class ChromeForm : ThemeContainer154
{
    private Color TitleColor;
    private int X;
    private Color Xcolor;
    private Color Xellipse;
    private int Y;

    public ChromeForm()
    {
        TransparencyKey = Color.Fuchsia;
        BackColor = Color.White;
        Font = new Font("Segoe UI", 9);
        SetColor("Title color", Color.Black);
        SetColor("X-color", 90, 90, 90);
        SetColor("X-ellipse", 114, 114, 114);
    }

    protected override void ColorHook()
    {
        TitleColor = GetColor("Title color");
        Xcolor = GetColor("X-color");
        Xellipse = GetColor("X-ellipse");
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        X = e.Location.X;
        Y = e.Location.Y;
        base.OnMouseMove(e);
        Invalidate();
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
        OnClick(e);
        var r = new Rectangle(Width - 22, 5, 15, 15);
        if (r.Contains(new Point(e.X, e.Y)) || r.Contains(new Point(X, Y)) && e.Button == MouseButtons.Left)
            FindForm().Close();
    }

    protected override void PaintHook()
    {
        G.Clear(BackColor);
        DrawCorners(Color.Fuchsia);
        DrawCorners(Color.Fuchsia, 1, 0, Width - 2, Height);
        DrawCorners(Color.Fuchsia, 0, 1, Width, Height - 2);
        DrawCorners(Color.Fuchsia, 2, 0, Width - 4, Height);
        DrawCorners(Color.Fuchsia, 0, 2, Width, Height - 4);

        G.SmoothingMode = SmoothingMode.HighQuality;
        if (new Rectangle(Width - 22, 5, 15, 15).Contains(new Point(X, Y)))
        {
            G.FillEllipse(new SolidBrush(Xellipse), new Rectangle(Width - 24, 6, 16, 16));
            G.DrawString("r", new Font("Webdings", 8), new SolidBrush(BackColor), new Point(Width - 23, 5));
        }
        else
        {
            G.DrawString("r", new Font("Webdings", 8), new SolidBrush(Xcolor), new Point(Width - 23, 5));
        }

        DrawText(new SolidBrush(TitleColor), new Point(8, 7));
    }
}

public class ChromeButton : ThemeControl154
{
    private Color Bo;
    private Color GBD;
    private Color GBN;
    private Color GBO;
    private Color GTD;
    private Color GTN;
    private Color GTO;
    private Color TD;
    private Color TDO;
    private Color TN;

    public ChromeButton()
    {
        Font = new Font("Segoe UI", 9);
        SetColor("Gradient top normal", 237, 237, 237);
        SetColor("Gradient top over", 242, 242, 242);
        SetColor("Gradient top down", 235, 235, 235);
        SetColor("Gradient bottom normal", 230, 230, 230);
        SetColor("Gradient bottom over", 235, 235, 235);
        SetColor("Gradient bottom down", 223, 223, 223);
        SetColor("Border", 167, 167, 167);
        SetColor("Text normal", 60, 60, 60);
        SetColor("Text down/over", 20, 20, 20);
        SetColor("Text disabled", Color.Gray);
    }

    protected override void ColorHook()
    {
        GTN = GetColor("Gradient top normal");
        GTO = GetColor("Gradient top over");
        GTD = GetColor("Gradient top down");
        GBN = GetColor("Gradient bottom normal");
        GBO = GetColor("Gradient bottom over");
        GBD = GetColor("Gradient bottom down");
        Bo = GetColor("Border");
        TN = GetColor("Text normal");
        TDO = GetColor("Text down/over");
        TD = GetColor("Text disabled");
    }

    protected override void PaintHook()
    {
        G.Clear(BackColor);
        var LGB = default(LinearGradientBrush);
        G.SmoothingMode = SmoothingMode.HighQuality;


        switch (State)
        {
            case MouseState.None:
                LGB = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), GTN, GBN, 90f);
                break;
            case MouseState.Over:
                LGB = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), GTO, GBO, 90f);
                break;
            default:
                LGB = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), GTD, GBD, 90f);
                break;
        }

        if (!Enabled)
        {
            LGB = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), GTN, GBN, 90f);
        }

        var buttonpath = CreateRound(Rectangle.Round(LGB.Rectangle), 3);
        G.FillPath(LGB, CreateRound(Rectangle.Round(LGB.Rectangle), 3));
        if (!Enabled)
            G.FillPath(new SolidBrush(Color.FromArgb(50, Color.White)), CreateRound(Rectangle.Round(LGB.Rectangle), 3));
        G.SetClip(buttonpath);
        LGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height/6), Color.FromArgb(80, Color.White),
            Color.Transparent, 90f);
        G.FillRectangle(LGB, Rectangle.Round(LGB.Rectangle));


        G.ResetClip();
        G.DrawPath(new Pen(Bo), buttonpath);

        if (Enabled)
        {
            switch (State)
            {
                case MouseState.None:
                    DrawText(new SolidBrush(TN), HorizontalAlignment.Center, 1, 0);
                    break;
                default:
                    DrawText(new SolidBrush(TDO), HorizontalAlignment.Center, 1, 0);
                    break;
            }
        }
        else
        {
            DrawText(new SolidBrush(TD), HorizontalAlignment.Center, 1, 0);
        }
    }
}

[DefaultEvent("CheckedChanged")]
public class ChromeCheckbox : ThemeControl154
{
    public delegate void CheckedChangedEventHandler(object sender);

    private bool _Checked;
    private Color Bo;
    private Color GBD;
    private Color GBN;
    private Color GBO;
    private Color GTD;
    private Color GTN;
    private Color GTO;
    private Color T;
    private int X;

    public ChromeCheckbox()
    {
        LockHeight = 17;
        Font = new Font("Segoe UI", 9);
        SetColor("Gradient top normal", 237, 237, 237);
        SetColor("Gradient top over", 242, 242, 242);
        SetColor("Gradient top down", 235, 235, 235);
        SetColor("Gradient bottom normal", 230, 230, 230);
        SetColor("Gradient bottom over", 235, 235, 235);
        SetColor("Gradient bottom down", 223, 223, 223);
        SetColor("Border", 167, 167, 167);
        SetColor("Text", 60, 60, 60);
        Width = 160;
    }

    public bool Checked
    {
        get { return _Checked; }
        set
        {
            _Checked = value;
            Invalidate();
        }
    }

    protected override void ColorHook()
    {
        GTN = GetColor("Gradient top normal");
        GTO = GetColor("Gradient top over");
        GTD = GetColor("Gradient top down");
        GBN = GetColor("Gradient bottom normal");
        GBO = GetColor("Gradient bottom over");
        GBD = GetColor("Gradient bottom down");
        Bo = GetColor("Border");
        T = GetColor("Text");
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        X = e.Location.X;
        Invalidate();
    }

    protected override void PaintHook()
    {
        G.Clear(BackColor);
        var LGB = default(LinearGradientBrush);
        G.SmoothingMode = SmoothingMode.HighQuality;
        switch (State)
        {
            case MouseState.None:
                LGB = new LinearGradientBrush(new Rectangle(0, 0, 14, 14), GTN, GBN, 90f);
                break;
            case MouseState.Over:
                LGB = new LinearGradientBrush(new Rectangle(0, 0, 14, 14), GTO, GBO, 90f);
                break;
            default:
                LGB = new LinearGradientBrush(new Rectangle(0, 0, 14, 14), GTD, GBD, 90f);
                break;
        }
        var buttonpath = CreateRound(Rectangle.Round(LGB.Rectangle), 5);
        G.FillPath(LGB, CreateRound(Rectangle.Round(LGB.Rectangle), 3));
        G.SetClip(buttonpath);
        LGB = new LinearGradientBrush(new Rectangle(0, 0, 14, 5), Color.FromArgb(150, Color.White), Color.Transparent,
            90f);
        G.FillRectangle(LGB, Rectangle.Round(LGB.Rectangle));
        G.ResetClip();
        G.DrawPath(new Pen(Bo), buttonpath);

        DrawText(new SolidBrush(T), 17, -2);


        if (Checked)
        {
            var check =
                Image.FromStream(
                    new MemoryStream(
                        Convert.FromBase64String(
                            "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")));
            G.DrawImage(check, new Rectangle(2, 3, check.Width, check.Height));
        }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        _Checked = !_Checked;
        if (CheckedChanged != null)
            CheckedChanged(this);
        base.OnMouseDown(e);
    }

    public event CheckedChangedEventHandler CheckedChanged;
}

[DefaultEvent("CheckedChanged")]
public class ChromeRadioButton : ThemeControl154
{
    public delegate void CheckedChangedEventHandler(object sender);

    private bool _Checked;
    private int _Field = 16;
    private Color Bb;
    private Color Bo;
    private Color G1;
    private Color G2;
    private Color TextColor;
    private int X;

    public ChromeRadioButton()
    {
        Font = new Font("Segoe UI", 9);
        LockHeight = 17;
        SetColor("Text", 60, 60, 60);
        SetColor("Gradient top", 237, 237, 237);
        SetColor("Gradient bottom", 230, 230, 230);
        SetColor("Borders", 167, 167, 167);
        SetColor("Bullet", 100, 100, 100);
        Width = 180;
    }

    public int Field
    {
        get { return _Field; }
        set
        {
            if (value < 4)
                return;
            _Field = value;
            LockHeight = value;
            Invalidate();
        }
    }

    public bool Checked
    {
        get { return _Checked; }
        set
        {
            _Checked = value;
            InvalidateControls();
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }
            Invalidate();
        }
    }

    protected override void ColorHook()
    {
        TextColor = GetColor("Text");
        G1 = GetColor("Gradient top");
        G2 = GetColor("Gradient bottom");
        Bb = GetColor("Bullet");
        Bo = GetColor("Borders");
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        X = e.Location.X;
        Invalidate();
    }

    protected override void PaintHook()
    {
        G.Clear(BackColor);
        G.SmoothingMode = SmoothingMode.HighQuality;
        if (_Checked)
        {
            var LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(14, 14)), G1, G2, 90f);
            G.FillEllipse(LGB, new Rectangle(new Point(0, 0), new Size(14, 14)));
        }
        else
        {
            var LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(14, 16)), G1, G2, 90f);
            G.FillEllipse(LGB, new Rectangle(new Point(0, 0), new Size(14, 14)));
        }

        if (State == MouseState.Over & X < 15)
        {
            var SB = new SolidBrush(Color.FromArgb(10, Color.Black));
            G.FillEllipse(SB, new Rectangle(new Point(0, 0), new Size(14, 14)));
        }
        else if (State == MouseState.Down & X < 15)
        {
            var SB = new SolidBrush(Color.FromArgb(20, Color.Black));
            G.FillEllipse(SB, new Rectangle(new Point(0, 0), new Size(14, 14)));
        }

        var P = new GraphicsPath();
        P.AddEllipse(new Rectangle(0, 0, 14, 14));
        G.SetClip(P);

        var LLGGBB = new LinearGradientBrush(new Rectangle(0, 0, 14, 5), Color.FromArgb(150, Color.White),
            Color.Transparent, 90f);
        G.FillRectangle(LLGGBB, LLGGBB.Rectangle);

        G.ResetClip();

        G.DrawEllipse(new Pen(Bo), new Rectangle(new Point(0, 0), new Size(14, 14)));

        if (_Checked)
        {
            var LGB = new SolidBrush(Bb);
            G.FillEllipse(LGB, new Rectangle(new Point(4, 4), new Size(6, 6)));
        }

        DrawText(new SolidBrush(TextColor), HorizontalAlignment.Left, 17, -2);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (!_Checked)
            Checked = true;
        base.OnMouseDown(e);
    }

    public event CheckedChangedEventHandler CheckedChanged;

    protected override void OnCreation()
    {
        InvalidateControls();
    }

    private void InvalidateControls()
    {
        if (!IsHandleCreated || !_Checked)
            return;

        foreach (Control C in Parent.Controls)
        {
            if (!ReferenceEquals(C, this) && C is ChromeRadioButton)
            {
                ((ChromeRadioButton) C).Checked = false;
            }
        }
    }
}

public class ChromeSeparator : ThemeControl154
{
    public ChromeSeparator()
    {
        LockHeight = 1;
        BackColor = Color.FromArgb(238, 238, 238);
    }

    protected override void ColorHook()
    {
    }

    protected override void PaintHook()
    {
        G.Clear(BackColor);
    }
}

public class ChromeTabcontrol : TabControl
{
    private Color C1 = Color.FromArgb(78, 87, 100);
    private bool OB;

    public ChromeTabcontrol()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
        DoubleBuffered = true;
        SizeMode = TabSizeMode.Fixed;
        ItemSize = new Size(30, 115);
    }

    public Color SquareColor
    {
        get { return C1; }
        set
        {
            C1 = value;
            Invalidate();
        }
    }

    public bool ShowOuterBorders
    {
        get { return OB; }
        set
        {
            OB = value;
            Invalidate();
        }
    }

    protected override void CreateHandle()
    {
        base.CreateHandle();
        Alignment = TabAlignment.Left;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var B = new Bitmap(Width, Height);
        var G = Graphics.FromImage(B);
        try
        {
            SelectedTab.BackColor = Color.White;
        }
        catch
        {
        }
        G.Clear(Color.White);
        for (var i = 0; i <= TabCount - 1; i++)
        {
            var x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2),
                new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1));
            var textrectangle = new Rectangle(x2.Location.X + 20, x2.Location.Y, x2.Width - 20, x2.Height);
            if (i == SelectedIndex)
            {
                G.FillRectangle(new SolidBrush(C1), new Rectangle(x2.Location, new Size(9, x2.Height)));


                if (ImageList != null)
                {
                    try
                    {
                        if (ImageList.Images[TabPages[i].ImageIndex] != null)
                        {
                            G.DrawImage(ImageList.Images[TabPages[i].ImageIndex],
                                new Point(textrectangle.Location.X + 8, textrectangle.Location.Y + 6));
                            G.DrawString("      " + TabPages[i].Text, Font, Brushes.Black, textrectangle,
                                new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Near
                                });
                        }
                        else
                        {
                            G.DrawString(TabPages[i].Text, Font, Brushes.Black, textrectangle, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Near
                            });
                        }
                    }
                    catch
                    {
                        G.DrawString(TabPages[i].Text, Font, Brushes.Black, textrectangle, new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Near
                        });
                    }
                }
                else
                {
                    G.DrawString(TabPages[i].Text, Font, Brushes.Black, textrectangle, new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Near
                    });
                }
            }
            else
            {
                if (ImageList != null)
                {
                    try
                    {
                        if (ImageList.Images[TabPages[i].ImageIndex] != null)
                        {
                            G.DrawImage(ImageList.Images[TabPages[i].ImageIndex],
                                new Point(textrectangle.Location.X + 8, textrectangle.Location.Y + 6));
                            G.DrawString("      " + TabPages[i].Text, Font, Brushes.DimGray, textrectangle,
                                new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Near
                                });
                        }
                        else
                        {
                            G.DrawString(TabPages[i].Text, Font, Brushes.DimGray, textrectangle, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Near
                            });
                        }
                    }
                    catch
                    {
                        G.DrawString(TabPages[i].Text, Font, Brushes.DimGray, textrectangle, new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Near
                        });
                    }
                }
                else
                {
                    G.DrawString(TabPages[i].Text, Font, Brushes.DimGray, textrectangle, new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Near
                    });
                }
            }
        }

        e.Graphics.DrawImage((Image) B.Clone(), 0, 0);
        G.Dispose();
        B.Dispose();
    }
}