using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

//|------DO-NOT-REMOVE------|

// Creator: HazelDev
// Site : HazelDev.co.nr
// Created: 23.Jun.2014
// Changed: 8.Aug.2014
// Version: 1.1.3

//|------DO-NOT-REMOVE------|

#region NotificationBox

public class NotificationBox : Control
{
    #region Enums

    // Create a list of Notification Types
    public enum Type
    {
        Notice,
        Success,
        Warning,
        Error,
        Other
    }

    #endregion

    public NotificationBox()
    {
        // AllPaintingInWmPaint - deals with drawing both the background and the foreground
        // UserPaint - the control paints itself, not by the default system operation
        // OptimizedDoubleBuffer - reduce graphics flicker when (AllPaintingInWmPaint) is used
        // ResizeRedraw - the control redraw itself when it's resized
        SetStyle(
            ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw, true);

        Font = new Font("Tahoma", 9);
        Size = new Size(135, 40);
        MinimumSize = new Size(100, 40);
        RoundCorners = true;
        ShowCloseButton = true;
    }

    internal GraphicsPath CreateRoundRect(Rectangle r, int curve)
    {
        // Draw a border radius
        try
        {
            CreateRoundPath = new GraphicsPath(FillMode.Winding);
            CreateRoundPath.AddArc(r.X, r.Y, curve, curve, 180f, 90f);
            CreateRoundPath.AddArc(r.Right - curve, r.Y, curve, curve, 270f, 90f);
            CreateRoundPath.AddArc(r.Right - curve, r.Bottom - curve, curve, curve, 0f, 90f);
            CreateRoundPath.AddArc(r.X, r.Bottom - curve, curve, curve, 90f, 90f);
            CreateRoundPath.CloseFigure();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message + Environment.NewLine + Environment.NewLine + "Value must be either '1' or higher",
                "Invalid Integer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            // Return to the default border curve if the parameter is less than "1"
            _BorderCurve = 8;
            BorderCurve = 8;
        }
        return CreateRoundPath;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        var GFX = e.Graphics;
        var ForeColor = default(Color);
        var BackgroundColor = default(Color);
        var BorderColor = default(Color);
        var TypeFont = new Font(Font.FontFamily, Font.Size, FontStyle.Bold);
        var MainRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
        var CrvBorderPath = CreateRoundRect(MainRectangle, _BorderCurve);

        GFX.SmoothingMode = SmoothingMode.HighQuality;
        GFX.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        GFX.Clear(Parent.BackColor);

        switch (_NotificationType)
        {
            case Type.Notice:
                BackgroundColor = Color.FromArgb(227, 247, 252);
                BorderColor = Color.FromArgb(142, 217, 246);
                ForeColor = Color.DimGray;
                break;
            case Type.Success:
                BackgroundColor = Color.FromArgb(233, 255, 217);
                BorderColor = Color.FromArgb(166, 202, 138);
                ForeColor = Color.DimGray;
                break;
            case Type.Warning:
                BackgroundColor = Color.FromArgb(255, 248, 196);
                BorderColor = Color.FromArgb(242, 199, 121);
                ForeColor = Color.DimGray;
                break;
            case Type.Error:
                BackgroundColor = Color.FromArgb(255, 236, 236);
                BorderColor = Color.FromArgb(245, 172, 166);
                ForeColor = Color.DimGray;
                break;
            case Type.Other:
                BackgroundColor = Color.FromArgb(230, 230, 230);
                BorderColor = Color.FromArgb(180, 180, 180);
                ForeColor = Color.DimGray;
                break;
        }

        if (_RoundedCorners)
        {
            GFX.FillPath(new SolidBrush(BackgroundColor), CrvBorderPath);
            GFX.DrawPath(new Pen(BorderColor), CrvBorderPath);
        }
        else
        {
            GFX.FillRectangle(new SolidBrush(BackgroundColor), MainRectangle);
            GFX.DrawRectangle(new Pen(BorderColor), MainRectangle);
        }

        switch (_NotificationType)
        {
            case Type.Notice:
                NotificationText = "NOTICE";
                break;
            case Type.Success:
                NotificationText = "SUCCESS";
                break;
            case Type.Warning:
                NotificationText = "WARNING";
                break;
            case Type.Error:
                NotificationText = "ERROR";
                break;
            case Type.Other:
                NotificationText = "OTHER";
                break;
        }

        if ((Image == null))
        {
            GFX.DrawString(NotificationText, TypeFont, new SolidBrush(ForeColor), new Point(10, 5));
            GFX.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(10, 21, Width - 17, Height - 5));
        }
        else
        {
            GFX.DrawImage(_Image, 12, 4, 16, 16);
            GFX.DrawString(NotificationText, TypeFont, new SolidBrush(ForeColor), new Point(30, 5));
            GFX.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(10, 21, Width - 17, Height - 5));
        }

        CloseCoordinates = new Point(Width - 26, 4);

        if (_ShowCloseButton)
        {
            // If the mouse is over the specified coordinates, ellipse will be drawn to give the control more interactivity
            if (IsOverClose)
            {
                GFX.FillEllipse(new SolidBrush(BorderColor), new Rectangle(Width - 23, 4, 17, 17));
            }
            // Draw the close button
            GFX.DrawString("r", new Font("Marlett", 7, FontStyle.Regular), new SolidBrush(ForeColor),
                new Rectangle(Width - 20, 10, Width, Height), new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Near
                });
        }

        // Clean up
        CrvBorderPath.Dispose();
    }

    #region Variables

    private Point CloseCoordinates;
    private bool IsOverClose;
    private int _BorderCurve = 8;
    private GraphicsPath CreateRoundPath;
    private string NotificationText;
    private Type _NotificationType;
    private bool _RoundedCorners;
    private bool _ShowCloseButton;
    private Image _Image;

    #endregion

    #region Custom Properties

    public Type NotificationType
    {
        get { return _NotificationType; }
        set
        {
            _NotificationType = value;
            Invalidate();
        }
    }

    public bool RoundCorners
    {
        get { return _RoundedCorners; }
        set
        {
            _RoundedCorners = value;
            Invalidate();
        }
    }

    public bool ShowCloseButton
    {
        get { return _ShowCloseButton; }
        set
        {
            _ShowCloseButton = value;
            Invalidate();
        }
    }

    public int BorderCurve
    {
        get { return _BorderCurve; }
        set
        {
            _BorderCurve = value;
            Invalidate();
        }
    }

    public Image Image
    {
        get { return _Image; }
        set
        {
            if (value == null)
            {
                ImageSize = Size.Empty;
            }
            else
            {
                ImageSize = value.Size;
            }

            _Image = value;
            Invalidate();
        }
    }

    protected Size ImageSize { get; private set; }

    #endregion

    #region EventArgs

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        // Decides the location of the drawn ellipse. If mouse is over the correct coordinates, "IsOverClose" boolean will be triggered to draw the ellipse
        if (e.X >= Width - 19 && e.X <= Width - 10 && e.Y > CloseCoordinates.Y && e.Y < CloseCoordinates.Y + 12)
        {
            IsOverClose = true;
        }
        else
        {
            IsOverClose = false;
        }
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);

        if (_ShowCloseButton)
        {
            if (IsOverClose)
            {
                Dispose();
            }
        }
    }

    #endregion
}

#endregion