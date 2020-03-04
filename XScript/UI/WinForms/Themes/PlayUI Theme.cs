#region  Imports

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

//|------DO-NOT-REMOVE------|
//
// Creator: HazelDev
// Site   : HazelDev.com
// Created: 16.Oct.2014
// Changed: 18.Oct.2014
// Version: 1.0.0
//
//|------DO-NOT-REMOVE------|

#region  Theme Container

public class PlayUI_ThemeContainer : ContainerControl
{
    #region  Enums

    public enum MouseState
    {
        None = 0,
        Over = 1,
        Down = 2,
        Block = 3
    }

    #endregion

    public PlayUI_ThemeContainer()
    {
        SetStyle((ControlStyles) (139270), true);
        BackColor = Color.FromArgb(43, 46, 50);
        Padding = new Padding(20, 56, 20, 16);
        DoubleBuffered = true;
        Dock = DockStyle.Fill;
        MoveHeight = 40;
        Font = new Font("Segoe UI", 9);
        _RoundCorners = true;
        _Sizable = false;
    }

    protected override void CreateHandle()
    {
        base.CreateHandle();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var G = e.Graphics;
        G.Clear(Color.FromArgb(43, 46, 50));

        G.DrawRectangle(new Pen(Color.FromArgb(26, 26, 26)), new Rectangle(0, 0, Width - 1, Height - 1));
        G.FillRectangle(
            new LinearGradientBrush(new Point(0, 0), new Point(0, ClientRectangle.Height - 38),
                Color.FromArgb(43, 46, 51), Color.FromArgb(35, 37, 40)),
            new Rectangle(1, 1, Width - 2, ClientRectangle.Height - 38));
        G.DrawLine(new Pen(Color.FromArgb(65, 69, 75)), 1, 1, Width - 2, 1);
        G.DrawLine(new Pen(Color.FromArgb(161, 166, 171)), 1, Height - 37, Width - 2, Height - 37);
        G.FillRectangle(
            new LinearGradientBrush(new Point(0, 0), new Point(0, Height), Color.FromArgb(124, 127, 134),
                Color.FromArgb(114, 117, 124)), new Rectangle(1, Height - 36, Width - 2, 35));
        G.DrawLine(new Pen(Color.FromArgb(65, 69, 75)), 1, 4, 1, Height - 38);
        G.DrawLine(new Pen(Color.FromArgb(65, 69, 75)), Width - 2, 4, Width - 2, Height - 38);

        if (_RoundCorners)
        {
            // Draw Left upper corner
            G.FillRectangle(Brushes.Fuchsia, 0, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 2, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 3, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, 2, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, 3, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, 1, 1, 1);

            G.FillRectangle(new SolidBrush(Color.FromArgb(26, 26, 26)), 1, 3, 1, 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(26, 26, 26)), 1, 2, 1, 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(26, 26, 26)), 2, 1, 1, 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(26, 26, 26)), 3, 1, 1, 1);

            // Draw right upper corner
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 3, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 4, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 2, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 3, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, 1, 1, 1);

            G.FillRectangle(new SolidBrush(Color.FromArgb(26, 26, 26)), Width - 2, 3, 1, 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(26, 26, 26)), Width - 2, 2, 1, 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(26, 26, 26)), Width - 3, 1, 1, 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(26, 26, 26)), Width - 4, 1, 1, 1);

            // Draw Left bottom corner
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 2, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 3, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 4, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 2, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 3, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 2, 1, 1);

            G.FillRectangle(new SolidBrush(Color.FromArgb(26, 26, 26)), 1, Height - 3, 1, 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(26, 26, 26)), 1, Height - 4, 1, 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(26, 26, 26)), 3, Height - 2, 1, 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(26, 26, 26)), 2, Height - 2, 1, 1);

            // Draw right bottom corner
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, Height, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 3, Height, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 4, Height, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 2, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 3, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 3, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 4, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 4, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, Height - 2, 1, 1);

            G.FillRectangle(new SolidBrush(Color.FromArgb(26, 26, 26)), Width - 2, Height - 3, 1, 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(26, 26, 26)), Width - 2, Height - 4, 1, 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(26, 26, 26)), Width - 4, Height - 2, 1, 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(26, 26, 26)), Width - 3, Height - 2, 1, 1);
        }
    }

    #region  Variables

    private Rectangle HeaderRect;
    protected MouseState State;
    private readonly int MoveHeight;
    private readonly Point MouseP = new Point(0, 0);
    private bool Cap;
    private bool HasShown;

    #endregion

    #region  Properties

    private bool _Sizable = true;

    public bool Sizable
    {
        get { return _Sizable; }
        set { _Sizable = value; }
    }

    private bool _SmartBounds = true;

    public bool SmartBounds
    {
        get { return _SmartBounds; }
        set { _SmartBounds = value; }
    }

    private bool _RoundCorners = true;

    public bool RoundCorners
    {
        get { return _RoundCorners; }
        set
        {
            _RoundCorners = value;
            Invalidate();
        }
    }

    protected bool IsParentForm { get; private set; }

    protected bool IsParentMdi
    {
        get
        {
            if (Parent == null)
            {
                return false;
            }
            return Parent.Parent != null;
        }
    }

    private bool _ControlMode;

    protected bool ControlMode
    {
        get { return _ControlMode; }
        set
        {
            _ControlMode = value;
            Invalidate();
        }
    }

    private FormStartPosition _StartPosition;

    public FormStartPosition StartPosition
    {
        get
        {
            if (IsParentForm && !_ControlMode)
            {
                return ParentForm.StartPosition;
            }
            return _StartPosition;
        }
        set
        {
            _StartPosition = value;

            if (IsParentForm && !_ControlMode)
            {
                ParentForm.StartPosition = value;
            }
        }
    }

    #endregion

    #region  EventArgs

    protected override sealed void OnParentChanged(EventArgs e)
    {
        base.OnParentChanged(e);

        if (Parent == null)
        {
            return;
        }
        IsParentForm = Parent is Form;

        if (!_ControlMode)
        {
            InitializeMessages();

            if (IsParentForm)
            {
                ParentForm.FormBorderStyle = FormBorderStyle.None;
                ParentForm.TransparencyKey = Color.Fuchsia;

                if (!DesignMode)
                {
                    ParentForm.Shown += FormShown;
                }
            }
            Parent.BackColor = BackColor;
            Parent.MinimumSize = new Size(261, 65);
        }
    }

    protected override sealed void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        if (!_ControlMode)
        {
            HeaderRect = new Rectangle(0, 0, Width - 14, MoveHeight - 7);
        }
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button == MouseButtons.Left)
        {
            SetState(MouseState.Down);
        }
        if (!(IsParentForm && ParentForm.WindowState == FormWindowState.Maximized || _ControlMode))
        {
            if (HeaderRect.Contains(e.Location))
            {
                Capture = false;
                WM_LMBUTTONDOWN = true;
                DefWndProc(ref Messages[0]);
            }
            else if (_Sizable && !(Previous == 0))
            {
                Capture = false;
                WM_LMBUTTONDOWN = true;
                DefWndProc(ref Messages[Previous]);
            }
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        Cap = false;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (!(IsParentForm && ParentForm.WindowState == FormWindowState.Maximized))
        {
            if (_Sizable && !_ControlMode)
            {
                InvalidateMouse();
            }
        }
        if (Cap)
        {
            Parent.Location = (Point) ((object) (Convert.ToDouble(MousePosition) - Convert.ToDouble(MouseP)));
        }
    }

    protected override void OnInvalidated(InvalidateEventArgs e)
    {
        base.OnInvalidated(e);
        ParentForm.Text = Text;
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
    }

    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);
        Invalidate();
    }

    private void FormShown(object sender, EventArgs e)
    {
        if (_ControlMode || HasShown)
        {
            return;
        }

        if (_StartPosition == FormStartPosition.CenterParent || _StartPosition == FormStartPosition.CenterScreen)
        {
            var SB = Screen.PrimaryScreen.Bounds;
            var CB = ParentForm.Bounds;
            ParentForm.Location = new Point(SB.Width/2 - CB.Width/2, SB.Height/2 - CB.Width/2);
        }
        HasShown = true;
    }

    #endregion

    #region  Mouse & Size

    private void SetState(MouseState current)
    {
        State = current;
        Invalidate();
    }

    private Point GetIndexPoint;
    private bool B1x;
    private bool B2x;
    private bool B3;
    private bool B4;

    private int GetIndex()
    {
        GetIndexPoint = PointToClient(MousePosition);
        B1x = GetIndexPoint.X < 7;
        B2x = GetIndexPoint.X > Width - 7;
        B3 = GetIndexPoint.Y < 7;
        B4 = GetIndexPoint.Y > Height - 7;

        if (B1x && B3)
        {
            return 4;
        }
        if (B1x && B4)
        {
            return 7;
        }
        if (B2x && B3)
        {
            return 5;
        }
        if (B2x && B4)
        {
            return 8;
        }
        if (B1x)
        {
            return 1;
        }
        if (B2x)
        {
            return 2;
        }
        if (B3)
        {
            return 3;
        }
        if (B4)
        {
            return 6;
        }
        return 0;
    }

    private int Current;
    private int Previous;

    private void InvalidateMouse()
    {
        Current = GetIndex();
        if (Current == Previous)
        {
            return;
        }

        Previous = Current;
        switch (Previous)
        {
            case 0:
                Cursor = Cursors.Default;
                break;
            case 6:
                Cursor = Cursors.SizeNS;
                break;
            case 8:
                Cursor = Cursors.SizeNWSE;
                break;
            case 7:
                Cursor = Cursors.SizeNESW;
                break;
        }
    }

    private readonly Message[] Messages = new Message[9];

    private void InitializeMessages()
    {
        Messages[0] = Message.Create(Parent.Handle, 161, new IntPtr(2), IntPtr.Zero);
        for (var I = 1; I <= 8; I++)
        {
            Messages[I] = Message.Create(Parent.Handle, 161, new IntPtr(I + 9), IntPtr.Zero);
        }
    }

    private void CorrectBounds(Rectangle bounds)
    {
        if (Parent.Width > bounds.Width)
        {
            Parent.Width = bounds.Width;
        }
        if (Parent.Height > bounds.Height)
        {
            Parent.Height = bounds.Height;
        }

        var X = Parent.Location.X;
        var Y = Parent.Location.Y;

        if (X < bounds.X)
        {
            X = bounds.X;
        }
        if (Y < bounds.Y)
        {
            Y = bounds.Y;
        }

        var Width = bounds.X + bounds.Width;
        var Height = bounds.Y + bounds.Height;

        if (X + Parent.Width > Width)
        {
            X = Width - Parent.Width;
        }
        if (Y + Parent.Height > Height)
        {
            Y = Height - Parent.Height;
        }

        Parent.Location = new Point(X, Y);
    }

    private bool WM_LMBUTTONDOWN;

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);

        if (WM_LMBUTTONDOWN && m.Msg == 513)
        {
            WM_LMBUTTONDOWN = false;

            SetState(MouseState.Over);
            if (!_SmartBounds)
            {
                return;
            }

            if (IsParentMdi)
            {
                CorrectBounds(new Rectangle(Point.Empty, Parent.Parent.Size));
            }
            else
            {
                CorrectBounds(Screen.FromControl(Parent).WorkingArea);
            }
        }
    }

    #endregion
}

#endregion

#region  ControlBox

public class PlayUI_ControlBox : Control
{
    #region  Enums

    public enum MouseState
    {
        None = 0,
        Over = 1,
        Down = 2
    }

    #endregion

    public PlayUI_ControlBox()
    {
        SetStyle(
            ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw |
            ControlStyles.DoubleBuffer, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        Font = new Font("Marlett", 7);
        Anchor = AnchorStyles.Top | AnchorStyles.Right;
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Size = new Size(45, 23);
    }

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        Location = new Point(Parent.Width - 50, 5);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var B = new Bitmap(Width, Height);
        var G = Graphics.FromImage(B);

        base.OnPaint(e);
        G.SmoothingMode = SmoothingMode.AntiAlias;

        var LGBClose = new LinearGradientBrush(CloseBtn, Color.FromArgb(29, 29, 29), Color.FromArgb(29, 29, 29), 90);
        G.FillEllipse(LGBClose, CloseBtn);
        G.DrawString("r", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(117, 117, 119)),
            new Rectangle(26, 8, 0, 0));

        var LGBMinimize = new LinearGradientBrush(MinBtn, Color.FromArgb(29, 29, 29), Color.FromArgb(29, 29, 29), 90);
        G.FillEllipse(LGBMinimize, MinBtn);
        G.DrawString("0", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(117, 117, 119)),
            new Rectangle((int) 6.5, 8, 0, 0));

        switch (State)
        {
            case MouseState.None:
                var xLGBClose_1 = new LinearGradientBrush(CloseBtn, Color.FromArgb(29, 29, 29),
                    Color.FromArgb(29, 29, 29), 90);
                G.FillEllipse(xLGBClose_1, CloseBtn);
                G.DrawString("r", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(117, 117, 119)),
                    new Rectangle(26, 8, 0, 0));

                var xLGBMinimize_1 = new LinearGradientBrush(MinBtn, Color.FromArgb(29, 29, 29),
                    Color.FromArgb(29, 29, 29), 90);
                G.FillEllipse(xLGBMinimize_1, MinBtn);
                G.DrawString("0", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(117, 117, 119)),
                    new Rectangle((int) 6.5, 8, 0, 0));
                break;
            case MouseState.Over:
                if (X > 23 && X < 40)
                {
                    var xLGBClose = new LinearGradientBrush(CloseBtn, Color.FromArgb(37, 37, 37),
                        Color.FromArgb(37, 37, 37), 90);
                    G.FillEllipse(xLGBClose, CloseBtn);
                    G.DrawString("r", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(117, 117, 119)),
                        new Rectangle(26, 8, 0, 0));
                }
                else if (X > 3 && X < 20)
                {
                    var xLGBMinimize = new LinearGradientBrush(MinBtn, Color.FromArgb(37, 37, 37),
                        Color.FromArgb(37, 37, 37), 90);
                    G.FillEllipse(xLGBMinimize, MinBtn);
                    G.DrawString("0", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(117, 117, 119)),
                        new Rectangle((int) 6.5, 8, 0, 0));
                }
                break;
        }

        e.Graphics.DrawImage((Image) (B.Clone()), 0, 0);
        G.Dispose();
        B.Dispose();
    }

    #region  MouseStates

    private MouseState State = MouseState.None;
    private int X;
    private readonly Rectangle MinBtn = new Rectangle(3, 2, 17, 17);
    private readonly Rectangle CloseBtn = new Rectangle(23, 2, 17, 17);

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        State = MouseState.Down;
        Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        if (X > 0 && X < 17)
        {
            FindForm().WindowState = FormWindowState.Minimized;
        }
        else if (X > 20 && X < 40)
        {
            FindForm().Close();
        }

        State = MouseState.Over;
        Invalidate();
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        State = MouseState.Over;
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        State = MouseState.None;
        Invalidate();
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        X = e.Location.X;
        Invalidate();
    }

    #endregion
}

#endregion

#region  Header Label

public class PlayUI_HeaderLabel : Label
{
    public PlayUI_HeaderLabel()
    {
        Font = new Font("Arial", 9, FontStyle.Bold);
        ForeColor = Color.FromArgb(253, 254, 255);
        BackColor = Color.Transparent;
    }
}

#endregion

#region  Label

public class PlayUI_Label : Label
{
    public PlayUI_Label()
    {
        Font = new Font("Arial", 8, FontStyle.Regular);
        ForeColor = Color.FromArgb(116, 119, 124);
        BackColor = Color.Transparent;
    }
}

#endregion

#region  Link Label

public class PlayUI_LinkLabel : LinkLabel
{
    public PlayUI_LinkLabel()
    {
        Font = new Font("Arial", 8, FontStyle.Regular);
        BackColor = Color.Transparent;
        LinkColor = Color.FromArgb(115, 118, 125);
        ActiveLinkColor = Color.FromArgb(103, 105, 112);
        VisitedLinkColor = Color.FromArgb(115, 118, 125);
        LinkBehavior = LinkBehavior.NeverUnderline;
    }
}

#endregion

#region  Separator

public class PlayUI_Separator : Control
{
    public PlayUI_Separator()
    {
        SetStyle(ControlStyles.ResizeRedraw, true);
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        BackColor = Color.Transparent;
        Size = (Size) (new Point(120, 10));
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        e.Graphics.DrawLine(new Pen(Color.FromArgb(56, 60, 65)), 0, 5, Width, 5);
    }
}

#endregion

#region  Panel

public class PlayUI_Panel : ContainerControl
{
    private GraphicsPath Shape;

    public PlayUI_Panel()
    {
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        SetStyle(ControlStyles.UserPaint, true);

        BackColor = Color.Transparent;
        Size = new Size(187, 117);
        Padding = new Padding(5, 5, 5, 5);
        DoubleBuffered = true;
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        Shape = new GraphicsPath();
        Shape.AddArc(0, 0, 10, 10, 180, 90);
        Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
        Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
        Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
        Shape.CloseAllFigures();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var B = new Bitmap(Width, Height);
        var G = Graphics.FromImage(B);

        G.SmoothingMode = SmoothingMode.HighQuality;

        G.Clear(Color.Transparent); // Set control background to transparent
        G.FillPath(new SolidBrush(Color.FromArgb(47, 49, 53)), Shape); // Draw RTB background
        G.DrawPath(new Pen(Color.FromArgb(37, 38, 41)), Shape); // Draw border

        G.Dispose();
        e.Graphics.DrawImage((Image) (B.Clone()), 0, 0);
        B.Dispose();
    }
}

#endregion

#region  Button Base

public class PlayUI_ButtonBase : ContainerControl
{
    public PlayUI_ButtonBase()
    {
        DoubleBuffered = true;
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        BackColor = Color.Transparent;
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Size = new Size(110, 50);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        var G = e.Graphics;

        G.SmoothingMode = SmoothingMode.AntiAlias;

        var LGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(36, 38, 41),
            Color.FromArgb(36, 38, 41), 90.0F);

        G.FillEllipse(LGB1, new Rectangle(0, 9, 30, 30));
        G.FillEllipse(LGB1, new Rectangle(29, 0, 48, 48));
        G.FillEllipse(LGB1, new Rectangle(76, 9, 30, 30));

        LGB1.Dispose();
    }
}

#endregion

#region  Normal Button

public class PlayUI_Button_N : Control
{
    public PlayUI_Button_N()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

        BackColor = Color.Transparent;
        DoubleBuffered = true;
        Font = new Font("Segoe UI", 8);
        ForeColor = Color.FromArgb(255, 255, 255);
        Size = new Size(42, 24);
        _TextAlignment = StringAlignment.Center;
        P1 = new Pen(Color.FromArgb(25, 26, 28)); // P1 = Border color
    }

    protected override void OnResize(EventArgs e)
    {
        if (Width > 0 && Height > 0)
        {
            Shape = new GraphicsPath();
            R1 = new Rectangle(0, 0, Width, Height);

            InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(31, 31, 31),
                Color.FromArgb(30, 30, 30), 90.0F);
            PressedGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(26, 26, 26),
                Color.FromArgb(26, 26, 26), 90.0F);
            PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(23, 23, 23),
                Color.FromArgb(23, 23, 23), 90.0F);

            P3 = new Pen(PressedContourGB);
        }

        Shape.AddArc(0, 0, 10, 10, 180, 90);
        Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
        Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
        Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
        Shape.CloseAllFigures();

        Invalidate();
        base.OnResize(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

        switch (MouseState)
        {
            case 0: //Inactive
                e.Graphics.FillPath(InactiveGB, Shape); // Fill button body with InactiveGB color gradient
                e.Graphics.DrawLine(new Pen(Color.FromArgb(39, 39, 39)), 2, 1, Width - 3, 1);
                e.Graphics.DrawPath(P1, Shape); // Draw button border [InactiveGB]
                e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), R1,
                    new StringFormat {Alignment = _TextAlignment, LineAlignment = StringAlignment.Center});
                break;
            case 1: //Pressed
                e.Graphics.FillPath(PressedGB, Shape); // Fill button body with PressedGB color gradient
                e.Graphics.DrawPath(P3, Shape); // Draw button border [PressedGB]
                e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), R1,
                    new StringFormat {Alignment = _TextAlignment, LineAlignment = StringAlignment.Center});
                break;
        }
        base.OnPaint(e);
    }

    #region  Variables

    private int MouseState;
    private GraphicsPath Shape;
    private LinearGradientBrush InactiveGB;
    private LinearGradientBrush PressedGB;
    private LinearGradientBrush PressedContourGB;
    private Rectangle R1;
    private readonly Pen P1;
    private Pen P3;
    private StringAlignment _TextAlignment = StringAlignment.Center;

    private Color _TextColor;
        // VBConversions Note: Initial value cannot be assigned here since it is non-static.  Assignment has been moved to the class constructors.

    #endregion

    #region  Properties

    public StringAlignment TextAlignment
    {
        get { return _TextAlignment; }
        set
        {
            _TextAlignment = value;
            Invalidate();
        }
    }

    public override Color ForeColor
    {
        get { return _TextColor; }
        set
        {
            _TextColor = value;
            Invalidate();
        }
    }

    #endregion

    #region  EventArgs

    protected override void OnMouseUp(MouseEventArgs e)
    {
        MouseState = 0;
        Invalidate();
        base.OnMouseUp(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        MouseState = 1;
        Invalidate();
        base.OnMouseDown(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        MouseState = 0;
        Invalidate();
        base.OnMouseLeave(e);
    }

    protected override void OnTextChanged(EventArgs e)
    {
        Invalidate();
        base.OnTextChanged(e);
    }

    #endregion
}

#endregion

#region  Round Button

public class PlayUI_Button_R : Control
{
    #region  Enums

    public enum MyRadius
    {
        R12,
        R21
    }

    #endregion

    public PlayUI_Button_R()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

        BackColor = Color.Transparent;
        DoubleBuffered = true;
        Size = new Size(25, 25);
        P1 = new Pen(Color.FromArgb(116, 119, 126)); // P1 = Border color
    }

    protected override void OnResize(EventArgs e)
    {
        switch (_Radius)
        {
            case MyRadius.R12:
                Size = new Size(25, 25);
                break;
            case MyRadius.R21:
                Size = new Size(44, 44);
                break;
        }

        InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(116, 119, 126),
            Color.FromArgb(116, 119, 126), 90.0F);
        PressedGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(95, 97, 103),
            Color.FromArgb(95, 97, 103), 90.0F);
        PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(95, 97, 103),
            Color.FromArgb(95, 97, 103), 90.0F);
        P3 = new Pen(PressedContourGB); // P3 = Border color when button is pressed

        Invalidate();
        base.OnResize(e);
    }

    private void FinishDrawing(Graphics g, Point center, int radius)
    {
        var MyCircle = new Rectangle(center.X/2, center.Y/2, radius*2, radius*2);

        switch (MouseState)
        {
            case 0: //Inactive
                g.FillEllipse(InactiveGB, MyCircle);
                g.DrawEllipse(P1, MyCircle);

                if (Image == null)
                {
                }
                else
                {
                    g.DrawImage(_Image, 5, 5, ImageSize.Width, ImageSize.Height);
                }
                break;

            case 1: //Pressed
                g.FillEllipse(PressedGB, MyCircle);
                g.DrawEllipse(P3, MyCircle);

                if (Image == null)
                {
                }
                else
                {
                    g.DrawImage(_Image, 5, 5, ImageSize.Width, ImageSize.Height);
                }
                break;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
        switch (_Radius)
        {
            case MyRadius.R12:
                FinishDrawing(e.Graphics, new Point(0, 0), 12);
                break;
            case MyRadius.R21:
                FinishDrawing(e.Graphics, new Point(0, 0), 21);
                break;
        }
    }

    #region  Variables

    private int MouseState;
    private LinearGradientBrush InactiveGB;
    private LinearGradientBrush PressedGB;
    private LinearGradientBrush PressedContourGB;
    private readonly Pen P1;
    private Pen P3;
    private Image _Image;
    private MyRadius _Radius;

    #endregion

    #region  Properties

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

    public MyRadius Radius
    {
        get { return _Radius; }
        set
        {
            _Radius = value;
            switch (_Radius)
            {
                case MyRadius.R12:
                    Size = new Size(25, 25);
                    break;
                case MyRadius.R21:
                    Size = new Size(44, 44);
                    break;
            }
            Invalidate();
        }
    }

    #endregion

    #region  EventArgs

    protected override void OnMouseUp(MouseEventArgs e)
    {
        MouseState = 0;
        Invalidate();
        base.OnMouseUp(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        MouseState = 1;
        Invalidate();
        base.OnMouseDown(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        MouseState = 0;
        Invalidate();
        base.OnMouseLeave(e);
    }

    #endregion
}

#endregion

#region  Star Rating

public class PlayUI_StarRating : UserControl
{
    public PlayUI_StarRating()
    {
        Size = new Size(82, 17);
        BackColor = Color.Transparent;
        DoubleBuffered = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var G = e.Graphics;

        if (_ImageRated == null || _ImageUnrated == null)
        {
            return;
        }

        for (var i = 0; i <= _MaximumStars - 1; i++)
        {
            if (i < (TempStar == -1 ? _Stars : TempStar))
            {
                G.DrawImage(_ImageRated, _ImageRated.Width*i, 0, ImageSize.Width, ImageSize.Height);
            }
            else
            {
                G.DrawImage(_ImageUnrated, _ImageRated.Width*i, 0, ImageSize.Width, ImageSize.Height);
            }
        }
    }

    #region  Variables

    private Image _ImageRated;
    private Image _ImageUnrated;
    private int _Stars;
    private int _MaximumStars = 5;
    private int TempStar = -1;

    #endregion

    #region  Properties

    protected Size ImageSize { get; private set; }

    public int Stars
    {
        get { return _Stars; }
        set
        {
            if (value > _MaximumStars)
            {
                MessageBox.Show("Value can\'t be higher than the maximum number of stars!");
            }
            _Stars = value;
            Invalidate();
        }
    }

    public int MaximumStars
    {
        get { return _MaximumStars; }
        set { _MaximumStars = value; }
    }

    public Image ImageRated
    {
        get { return _ImageRated; }
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
            _ImageRated = value;
            Invalidate();
        }
    }

    public Image ImageUnrated
    {
        get { return _ImageUnrated; }
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
            _ImageUnrated = value;
            Invalidate();
        }
    }

    #endregion

    #region  EventArgs

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        double StarLoc = (e.X + _ImageRated.Width - 5)/_ImageRated.Width;
        var HoverStar = Convert.ToInt32(Math.Floor(StarLoc));

        if (!HoverStar.Equals(TempStar))
        {
            TempStar = HoverStar;
            Invalidate();
        }
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        TempStar = -1;
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        double StarLoc = (e.X + _ImageRated.Width - 5)/_ImageRated.Width;
        var StarToAdd = Convert.ToInt32(Math.Floor(StarLoc));

        if (!StarToAdd.Equals(_Stars))
        {
            _Stars = StarToAdd;
            if (_Stars > _MaximumStars)
            {
                _Stars = _MaximumStars;
            }
            Invalidate();
        }
    }

    #endregion
}

#endregion

#region  ProgressBar

public class PlayUI_ProgressBar : Control
{
    private double Percent;

    public PlayUI_ProgressBar()
    {
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        BackColor = Color.Transparent;
        DoubleBuffered = true;
        Size = new Size(100, 10);
    }

    public void Increment(int value)
    {
        _Value += value;
        Invalidate();
    }

    public void Deincrement(int value)
    {
        _Value -= value;
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var G = e.Graphics;
        G.SmoothingMode = SmoothingMode.HighQuality;

        Percent = _Value/(double) _Maximum*100;

        var Slope = 8;
        var MyRect = new Rectangle(0, 0, Width - 1, Height - 1);

        var BorderPath = CreateRound(MyRect, Slope);
        G.FillPath(new SolidBrush(Color.FromArgb(51, 52, 55)), BorderPath);

        var ProgressBlend = new ColorBlend(3);
        ProgressBlend.Colors[0] = _ValueColour;
        ProgressBlend.Colors[1] = _ValueColour;
        ProgressBlend.Colors[2] = _ValueColour;
        ProgressBlend.Positions = new[] {0, 0.5F, 1};
        var LGB = new LinearGradientBrush(MyRect, Color.Black, Color.Black, 90.0F);
        LGB.InterpolationColors = ProgressBlend;

        var ProgressRect = new Rectangle(1, 1, (int) Math.Round((Width/(double) _Maximum*_Value - 3.0)), Height - 3);
        var ProgressPath = CreateRound(ProgressRect, Slope);

        if (Percent >= 1)
        {
            G.FillPath(LGB, ProgressPath);
        }

        try
        {
            G.DrawPath(new Pen(Color.FromArgb(51, 52, 55)), BorderPath);
        }
        catch (Exception)
        {
        }
    }

    #region  RoundRect

    private GraphicsPath CreateRoundPath;

    public GraphicsPath CreateRound(Rectangle r, int slope)
    {
        CreateRoundPath = new GraphicsPath(FillMode.Winding);
        CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180.0F, 90.0F);
        CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270.0F, 90.0F);
        CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0.0F, 90.0F);
        CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90.0F, 90.0F);
        CreateRoundPath.CloseFigure();
        return CreateRoundPath;
    }

    #endregion

    #region  Custom Properties

    private int _Maximum = 100;

    public int Maximum
    {
        get { return _Maximum; }
        set
        {
            if (value < 1)
            {
                value = 1;
            }
            if (value < _Value)
            {
                _Value = value;
            }
            _Maximum = value;
            Invalidate();
        }
    }

    private int _Minimum;

    public int Minimum
    {
        get { return _Minimum; }
        set
        {
            _Minimum = value;

            if (value > _Maximum)
            {
                _Maximum = value;
            }
            if (value > _Value)
            {
                _Value = value;
            }

            Invalidate();
        }
    }

    private int _Value;

    public int Value
    {
        get { return _Value; }
        set
        {
            if (value > _Maximum)
            {
                value = Maximum;
            }
            _Value = value;
            Invalidate();
        }
    }

    private Color _ValueColour = Color.FromArgb(42, 119, 220);

    [Category("Colours")]
    public Color ValueColour
    {
        get { return _ValueColour; }
        set
        {
            _ValueColour = value;
            Invalidate();
        }
    }

    #endregion
}

#endregion