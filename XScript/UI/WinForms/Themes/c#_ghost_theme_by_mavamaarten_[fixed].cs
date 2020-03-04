using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

//---------/CREDITS/-----------
//
//Themebase creator: Aeonhack
//Site: elitevs.net
//Created: 08/02/2011
//Changed: 12/06/2011
//Version: 1.5.4
//
//Theme creator: Mavamaarten
//Created: 9/12/2011
//Changed: 3/03/2012
//Version: 2.0
//
//Thanks to Tedd for helping
//with combobox & tabcontrol!
//
//Converted to C# by: Ethernal Five
//On: 3/04/2012
//--------/CREDITS/------------

#region "THEMEBASE"

public abstract class ThemeContainer154 : ContainerControl
{
    private bool HasShown;

    private void DoAnimation(bool i)
    {
        OnAnimation();
        if (i)
            Invalidate();
    }

    protected override sealed void OnPaint(PaintEventArgs e)
    {
        if (Width == 0 || Height == 0)
            return;

        if (_Transparent && _ControlMode)
        {
            PaintHook();
            e.Graphics.DrawImage(B, 0, 0);
        }
        else
        {
            G = e.Graphics;
            PaintHook();
        }
    }

    protected override void OnHandleDestroyed(EventArgs e)
    {
        ThemeShare.RemoveAnimationCallback(DoAnimation);
        base.OnHandleDestroyed(e);
    }

    private void FormShown(object sender, EventArgs e)
    {
        if (_ControlMode || HasShown)
            return;

        if (_StartPosition == FormStartPosition.CenterParent || _StartPosition == FormStartPosition.CenterScreen)
        {
            var SB = Screen.PrimaryScreen.Bounds;
            var CB = ParentForm.Bounds;
            ParentForm.Location = new Point(SB.Width / 2 - CB.Width / 2, SB.Height / 2 - CB.Width / 2);
        }

        HasShown = true;
    }

    #region " Initialization "

    protected Graphics G;

    protected Bitmap B;

    public ThemeContainer154()
    {
        SetStyle((ControlStyles)139270, true);

        ImageSize = Size.Empty;
        Font = new Font("Verdana", 8);

        MeasureBitmap = new Bitmap(1, 1);
        MeasureGraphics = Graphics.FromImage(MeasureBitmap);

        DrawRadialPath = new GraphicsPath();

        InvalidateCustimization();
    }

    protected override sealed void OnHandleCreated(EventArgs e)
    {
        if (DoneCreation)
            InitializeMessages();

        InvalidateCustimization();
        ColorHook();

        if (!(_LockWidth == 0))
            Width = _LockWidth;
        if (!(_LockHeight == 0))
            Height = _LockHeight;
        if (!_ControlMode)
            base.Dock = DockStyle.Fill;

        Transparent = _Transparent;
        if (_Transparent && _BackColor)
            BackColor = Color.Transparent;

        base.OnHandleCreated(e);
    }

    private bool DoneCreation;

    protected override sealed void OnParentChanged(EventArgs e)
    {
        base.OnParentChanged(e);

        if (Parent == null)
            return;
        IsParentForm = Parent is Form;

        if (!_ControlMode)
        {
            InitializeMessages();

            if (IsParentForm)
            {
                ParentForm.FormBorderStyle = _BorderStyle;
                ParentForm.TransparencyKey = _TransparencyKey;

                if (!DesignMode)
                {
                    ParentForm.Shown += FormShown;
                }
            }

            Parent.BackColor = BackColor;
        }

        OnCreation();
        DoneCreation = true;
        InvalidateTimer();
    }

    #endregion

    #region " Size Handling "

    private Rectangle Frame;

    protected override sealed void OnSizeChanged(EventArgs e)
    {
        if (_Movable && !_ControlMode)
        {
            Frame = new Rectangle(7, 7, Width - 14, _Header - 7);
        }

        InvalidateBitmap();
        Invalidate();

        base.OnSizeChanged(e);
    }

    protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
    {
        if (!(_LockWidth == 0))
            width = _LockWidth;
        if (!(_LockHeight == 0))
            height = _LockHeight;
        base.SetBoundsCore(x, y, width, height, specified);
    }

    #endregion

    #region " State Handling "

    protected MouseState State;

    private void SetState(MouseState current)
    {
        State = current;
        Invalidate();
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (!(IsParentForm && ParentForm.WindowState == FormWindowState.Maximized))
        {
            if (_Sizable && !_ControlMode)
                InvalidateMouse();
        }

        base.OnMouseMove(e);
    }

    protected override void OnEnabledChanged(EventArgs e)
    {
        if (Enabled)
            SetState(MouseState.None);
        else
            SetState(MouseState.Block);
        base.OnEnabledChanged(e);
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        SetState(MouseState.Over);
        base.OnMouseEnter(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        SetState(MouseState.Over);
        base.OnMouseUp(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        SetState(MouseState.None);

        if (GetChildAtPoint(PointToClient(MousePosition)) != null)
        {
            if (_Sizable && !_ControlMode)
            {
                Cursor = Cursors.Default;
                Previous = 0;
            }
        }

        base.OnMouseLeave(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
            SetState(MouseState.Down);

        if (!(IsParentForm && ParentForm.WindowState == FormWindowState.Maximized || _ControlMode))
        {
            if (_Movable && Frame.Contains(e.Location))
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

        base.OnMouseDown(e);
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
                return;

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

    private Point GetIndexPoint;
    private bool B1;
    private bool B2;
    private bool B3;
    private bool B4;

    private int GetIndex()
    {
        GetIndexPoint = PointToClient(MousePosition);
        B1 = GetIndexPoint.X < 7;
        B2 = GetIndexPoint.X > Width - 7;
        B3 = GetIndexPoint.Y < 7;
        B4 = GetIndexPoint.Y > Height - 7;

        if (B1 && B3)
            return 4;
        if (B1 && B4)
            return 7;
        if (B2 && B3)
            return 5;
        if (B2 && B4)
            return 8;
        if (B1)
            return 1;
        if (B2)
            return 2;
        if (B3)
            return 3;
        if (B4)
            return 6;
        return 0;
    }

    private int Current;
    private int Previous;

    private void InvalidateMouse()
    {
        Current = GetIndex();
        if (Current == Previous)
            return;

        Previous = Current;
        switch (Previous)
        {
            case 0:
                Cursor = Cursors.Default;
                break;
            case 1:
            case 2:
                Cursor = Cursors.SizeWE;
                break;
            case 3:
            case 6:
                Cursor = Cursors.SizeNS;
                break;
            case 4:
            case 8:
                Cursor = Cursors.SizeNWSE;
                break;
            case 5:
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
            Parent.Width = bounds.Width;
        if (Parent.Height > bounds.Height)
            Parent.Height = bounds.Height;

        var X = Parent.Location.X;
        var Y = Parent.Location.Y;

        if (X < bounds.X)
            X = bounds.X;
        if (Y < bounds.Y)
            Y = bounds.Y;

        var Width = bounds.X + bounds.Width;
        var Height = bounds.Y + bounds.Height;

        if (X + Parent.Width > Width)
            X = Width - Parent.Width;
        if (Y + Parent.Height > Height)
            Y = Height - Parent.Height;

        Parent.Location = new Point(X, Y);
    }

    #endregion

    #region " Base Properties "

    public override DockStyle Dock
    {
        get { return base.Dock; }
        set
        {
            if (!_ControlMode)
                return;
            base.Dock = value;
        }
    }

    private bool _BackColor;

    [Category("Misc")]
    public override Color BackColor
    {
        get { return base.BackColor; }
        set
        {
            if (value == base.BackColor)
                return;

            if (!IsHandleCreated && _ControlMode && value == Color.Transparent)
            {
                _BackColor = true;
                return;
            }

            base.BackColor = value;
            if (Parent != null)
            {
                if (!_ControlMode)
                    Parent.BackColor = value;
                ColorHook();
            }
        }
    }

    public override Size MinimumSize
    {
        get { return base.MinimumSize; }
        set
        {
            base.MinimumSize = value;
            if (Parent != null)
                Parent.MinimumSize = value;
        }
    }

    public override Size MaximumSize
    {
        get { return base.MaximumSize; }
        set
        {
            base.MaximumSize = value;
            if (Parent != null)
                Parent.MaximumSize = value;
        }
    }

    public override string Text
    {
        get { return base.Text; }
        set
        {
            base.Text = value;
            Invalidate();
        }
    }

    public override Font Font
    {
        get { return base.Font; }
        set
        {
            base.Font = value;
            Invalidate();
        }
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color ForeColor
    {
        get { return Color.Empty; }
        set { }
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Image BackgroundImage
    {
        get { return null; }
        set { }
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override ImageLayout BackgroundImageLayout
    {
        get { return ImageLayout.None; }
        set { }
    }

    #endregion

    #region " Public Properties "

    private bool _SmartBounds = true;

    public bool SmartBounds
    {
        get { return _SmartBounds; }
        set { _SmartBounds = value; }
    }

    private bool _Movable = true;

    public bool Movable
    {
        get { return _Movable; }
        set { _Movable = value; }
    }

    private bool _Sizable = true;

    public bool Sizable
    {
        get { return _Sizable; }
        set { _Sizable = value; }
    }

    private Color _TransparencyKey;

    public Color TransparencyKey
    {
        get
        {
            if (IsParentForm && !_ControlMode)
                return ParentForm.TransparencyKey;
            return _TransparencyKey;
        }
        set
        {
            if (value == _TransparencyKey)
                return;
            _TransparencyKey = value;

            if (IsParentForm && !_ControlMode)
            {
                ParentForm.TransparencyKey = value;
                ColorHook();
            }
        }
    }

    private FormBorderStyle _BorderStyle;

    public FormBorderStyle BorderStyle
    {
        get
        {
            if (IsParentForm && !_ControlMode)
                return ParentForm.FormBorderStyle;
            return _BorderStyle;
        }
        set
        {
            _BorderStyle = value;

            if (IsParentForm && !_ControlMode)
            {
                ParentForm.FormBorderStyle = value;

                if (!(value == FormBorderStyle.None))
                {
                    Movable = false;
                    Sizable = false;
                }
            }
        }
    }

    private FormStartPosition _StartPosition;

    public FormStartPosition StartPosition
    {
        get
        {
            if (IsParentForm && !_ControlMode)
                return ParentForm.StartPosition;
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

    private bool _NoRounding;

    public bool NoRounding
    {
        get { return _NoRounding; }
        set
        {
            _NoRounding = value;
            Invalidate();
        }
    }

    private Image _Image;

    public Image Image
    {
        get { return _Image; }
        set
        {
            if (value == null)
                ImageSize = Size.Empty;
            else
                ImageSize = value.Size;

            _Image = value;
            Invalidate();
        }
    }

    private readonly Dictionary<string, Color> Items = new Dictionary<string, Color>();

    public Bloom[] Colors
    {
        get
        {
            var T = new List<Bloom>();
            var E = Items.GetEnumerator();

            while (E.MoveNext())
            {
                T.Add(new Bloom(E.Current.Key, E.Current.Value));
            }

            return T.ToArray();
        }
        set
        {
            foreach (var B in value)
            {
                if (Items.ContainsKey(B.Name))
                    Items[B.Name] = B.Value;
            }

            InvalidateCustimization();
            ColorHook();
            Invalidate();
        }
    }

    private string _Customization;

    public string Customization
    {
        get { return _Customization; }
        set
        {
            if (value == _Customization)
                return;

            byte[] Data = null;
            var Items = Colors;

            try
            {
                Data = Convert.FromBase64String(value);
                for (var I = 0; I <= Items.Length - 1; I++)
                {
                    Items[I].Value = Color.FromArgb(BitConverter.ToInt32(Data, I * 4));
                }
            }
            catch
            {
                return;
            }

            _Customization = value;

            Colors = Items;
            ColorHook();
            Invalidate();
        }
    }

    private bool _Transparent;

    public bool Transparent
    {
        get { return _Transparent; }
        set
        {
            _Transparent = value;
            if (!(IsHandleCreated || _ControlMode))
                return;

            if (!value && !(BackColor.A == 255))
            {
                throw new Exception("Unable to change value to false while a transparent BackColor is in use.");
            }

            SetStyle(ControlStyles.Opaque, !value);
            SetStyle(ControlStyles.SupportsTransparentBackColor, value);

            InvalidateBitmap();
            Invalidate();
        }
    }

    #endregion

    #region " Private Properties "

    protected Size ImageSize { get; private set; }

    protected bool IsParentForm { get; private set; }

    protected bool IsParentMdi
    {
        get
        {
            if (Parent == null)
                return false;
            return Parent.Parent != null;
        }
    }

    private int _LockWidth;

    protected int LockWidth
    {
        get { return _LockWidth; }
        set
        {
            _LockWidth = value;
            if (!(LockWidth == 0) && IsHandleCreated)
                Width = LockWidth;
        }
    }

    private int _LockHeight;

    protected int LockHeight
    {
        get { return _LockHeight; }
        set
        {
            _LockHeight = value;
            if (!(LockHeight == 0) && IsHandleCreated)
                Height = LockHeight;
        }
    }

    private int _Header = 24;

    protected int Header
    {
        get { return _Header; }
        set
        {
            _Header = value;

            if (!_ControlMode)
            {
                Frame = new Rectangle(7, 7, Width - 14, value - 7);
                Invalidate();
            }
        }
    }

    private bool _ControlMode;

    protected bool ControlMode
    {
        get { return _ControlMode; }
        set
        {
            _ControlMode = value;

            Transparent = _Transparent;
            if (_Transparent && _BackColor)
                BackColor = Color.Transparent;

            InvalidateBitmap();
            Invalidate();
        }
    }

    private bool _IsAnimated;

    protected bool IsAnimated
    {
        get { return _IsAnimated; }
        set
        {
            _IsAnimated = value;
            InvalidateTimer();
        }
    }

    #endregion

    #region " Property Helpers "

    protected Pen GetPen(string name)
    {
        return new Pen(Items[name]);
    }

    protected Pen GetPen(string name, float width)
    {
        return new Pen(Items[name], width);
    }

    protected SolidBrush GetBrush(string name)
    {
        return new SolidBrush(Items[name]);
    }

    protected Color GetColor(string name)
    {
        return Items[name];
    }

    protected void SetColor(string name, Color value)
    {
        if (Items.ContainsKey(name))
            Items[name] = value;
        else
            Items.Add(name, value);
    }

    protected void SetColor(string name, byte r, byte g, byte b)
    {
        SetColor(name, Color.FromArgb(r, g, b));
    }

    protected void SetColor(string name, byte a, byte r, byte g, byte b)
    {
        SetColor(name, Color.FromArgb(a, r, g, b));
    }

    protected void SetColor(string name, byte a, Color value)
    {
        SetColor(name, Color.FromArgb(a, value));
    }

    private void InvalidateBitmap()
    {
        if (_Transparent && _ControlMode)
        {
            if (Width == 0 || Height == 0)
                return;
            B = new Bitmap(Width, Height, PixelFormat.Format32bppPArgb);
            G = Graphics.FromImage(B);
        }
        else
        {
            G = null;
            B = null;
        }
    }

    private void InvalidateCustimization()
    {
        var M = new MemoryStream(Items.Count * 4);

        foreach (var B in Colors)
        {
            M.Write(BitConverter.GetBytes(B.Value.ToArgb()), 0, 4);
        }

        M.Close();
        _Customization = Convert.ToBase64String(M.ToArray());
    }

    private void InvalidateTimer()
    {
        if (DesignMode || !DoneCreation)
            return;

        if (_IsAnimated)
        {
            ThemeShare.AddAnimationCallback(DoAnimation);
        }
        else
        {
            ThemeShare.RemoveAnimationCallback(DoAnimation);
        }
    }

    #endregion

    #region " User Hooks "

    protected abstract void ColorHook();
    protected abstract void PaintHook();

    protected virtual void OnCreation()
    {
    }

    protected virtual void OnAnimation()
    {
    }

    #endregion

    #region " Offset "

    private Rectangle OffsetReturnRectangle;

    protected Rectangle Offset(Rectangle r, int amount)
    {
        OffsetReturnRectangle = new Rectangle(r.X + amount, r.Y + amount, r.Width - (amount * 2), r.Height - (amount * 2));
        return OffsetReturnRectangle;
    }

    private Size OffsetReturnSize;

    protected Size Offset(Size s, int amount)
    {
        OffsetReturnSize = new Size(s.Width + amount, s.Height + amount);
        return OffsetReturnSize;
    }

    private Point OffsetReturnPoint;

    protected Point Offset(Point p, int amount)
    {
        OffsetReturnPoint = new Point(p.X + amount, p.Y + amount);
        return OffsetReturnPoint;
    }

    #endregion

    #region " Center "

    private Point CenterReturn;

    protected Point Center(Rectangle p, Rectangle c)
    {
        CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X + c.X, (p.Height / 2 - c.Height / 2) + p.Y + c.Y);
        return CenterReturn;
    }

    protected Point Center(Rectangle p, Size c)
    {
        CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X, (p.Height / 2 - c.Height / 2) + p.Y);
        return CenterReturn;
    }

    protected Point Center(Rectangle child)
    {
        return Center(Width, Height, child.Width, child.Height);
    }

    protected Point Center(Size child)
    {
        return Center(Width, Height, child.Width, child.Height);
    }

    protected Point Center(int childWidth, int childHeight)
    {
        return Center(Width, Height, childWidth, childHeight);
    }

    protected Point Center(Size p, Size c)
    {
        return Center(p.Width, p.Height, c.Width, c.Height);
    }

    protected Point Center(int pWidth, int pHeight, int cWidth, int cHeight)
    {
        CenterReturn = new Point(pWidth / 2 - cWidth / 2, pHeight / 2 - cHeight / 2);
        return CenterReturn;
    }

    #endregion

    #region " Measure "

    private readonly Bitmap MeasureBitmap;

    private readonly Graphics MeasureGraphics;

    protected Size Measure()
    {
        lock (MeasureGraphics)
        {
            return MeasureGraphics.MeasureString(Text, Font, Width).ToSize();
        }
    }

    protected Size Measure(string text)
    {
        lock (MeasureGraphics)
        {
            return MeasureGraphics.MeasureString(text, Font, Width).ToSize();
        }
    }

    #endregion

    #region " DrawPixel "

    private SolidBrush DrawPixelBrush;

    protected void DrawPixel(Color c1, int x, int y)
    {
        if (_Transparent)
        {
            B.SetPixel(x, y, c1);
        }
        else
        {
            DrawPixelBrush = new SolidBrush(c1);
            G.FillRectangle(DrawPixelBrush, x, y, 1, 1);
        }
    }

    #endregion

    #region " DrawCorners "

    private SolidBrush DrawCornersBrush;

    protected void DrawCorners(Color c1, int offset)
    {
        DrawCorners(c1, 0, 0, Width, Height, offset);
    }

    protected void DrawCorners(Color c1, Rectangle r1, int offset)
    {
        DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height, offset);
    }

    protected void DrawCorners(Color c1, int x, int y, int width, int height, int offset)
    {
        DrawCorners(c1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
    }

    protected void DrawCorners(Color c1)
    {
        DrawCorners(c1, 0, 0, Width, Height);
    }

    protected void DrawCorners(Color c1, Rectangle r1)
    {
        DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height);
    }

    protected void DrawCorners(Color c1, int x, int y, int width, int height)
    {
        if (_NoRounding)
            return;

        if (_Transparent)
        {
            B.SetPixel(x, y, c1);
            B.SetPixel(x + (width - 1), y, c1);
            B.SetPixel(x, y + (height - 1), c1);
            B.SetPixel(x + (width - 1), y + (height - 1), c1);
        }
        else
        {
            DrawCornersBrush = new SolidBrush(c1);
            G.FillRectangle(DrawCornersBrush, x, y, 1, 1);
            G.FillRectangle(DrawCornersBrush, x + (width - 1), y, 1, 1);
            G.FillRectangle(DrawCornersBrush, x, y + (height - 1), 1, 1);
            G.FillRectangle(DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1);
        }
    }

    #endregion

    #region " DrawBorders "

    protected void DrawBorders(Pen p1, int offset)
    {
        DrawBorders(p1, 0, 0, Width, Height, offset);
    }

    protected void DrawBorders(Pen p1, Rectangle r, int offset)
    {
        DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset);
    }

    protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
    {
        DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
    }

    protected void DrawBorders(Pen p1)
    {
        DrawBorders(p1, 0, 0, Width, Height);
    }

    protected void DrawBorders(Pen p1, Rectangle r)
    {
        DrawBorders(p1, r.X, r.Y, r.Width, r.Height);
    }

    protected void DrawBorders(Pen p1, int x, int y, int width, int height)
    {
        G.DrawRectangle(p1, x, y, width - 1, height - 1);
    }

    #endregion

    #region " DrawText "

    private Point DrawTextPoint;

    private Size DrawTextSize;

    protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y)
    {
        DrawText(b1, Text, a, x, y);
    }

    protected void DrawText(Brush b1, string text, HorizontalAlignment a, int x, int y)
    {
        if (text.Length == 0)
            return;

        DrawTextSize = Measure(text);
        DrawTextPoint = new Point(Width / 2 - DrawTextSize.Width / 2, Header / 2 - DrawTextSize.Height / 2);

        switch (a)
        {
            case HorizontalAlignment.Left:
                G.DrawString(text, Font, b1, x, DrawTextPoint.Y + y);
                break;
            case HorizontalAlignment.Center:
                G.DrawString(text, Font, b1, DrawTextPoint.X + x, DrawTextPoint.Y + y);
                break;
            case HorizontalAlignment.Right:
                G.DrawString(text, Font, b1, Width - DrawTextSize.Width - x, DrawTextPoint.Y + y);
                break;
        }
    }

    protected void DrawText(Brush b1, Point p1)
    {
        if (Text.Length == 0)
            return;
        G.DrawString(Text, Font, b1, p1);
    }

    protected void DrawText(Brush b1, int x, int y)
    {
        if (Text.Length == 0)
            return;
        G.DrawString(Text, Font, b1, x, y);
    }

    #endregion

    #region " DrawImage "

    private Point DrawImagePoint;

    protected void DrawImage(HorizontalAlignment a, int x, int y)
    {
        DrawImage(_Image, a, x, y);
    }

    protected void DrawImage(Image image, HorizontalAlignment a, int x, int y)
    {
        if (image == null)
            return;
        DrawImagePoint = new Point(Width / 2 - image.Width / 2, Header / 2 - image.Height / 2);

        switch (a)
        {
            case HorizontalAlignment.Left:
                G.DrawImage(image, x, DrawImagePoint.Y + y, image.Width, image.Height);
                break;
            case HorizontalAlignment.Center:
                G.DrawImage(image, DrawImagePoint.X + x, DrawImagePoint.Y + y, image.Width, image.Height);
                break;
            case HorizontalAlignment.Right:
                G.DrawImage(image, Width - image.Width - x, DrawImagePoint.Y + y, image.Width, image.Height);
                break;
        }
    }

    protected void DrawImage(Point p1)
    {
        DrawImage(_Image, p1.X, p1.Y);
    }

    protected void DrawImage(int x, int y)
    {
        DrawImage(_Image, x, y);
    }

    protected void DrawImage(Image image, Point p1)
    {
        DrawImage(image, p1.X, p1.Y);
    }

    protected void DrawImage(Image image, int x, int y)
    {
        if (image == null)
            return;
        G.DrawImage(image, x, y, image.Width, image.Height);
    }

    #endregion

    #region " DrawGradient "

    private LinearGradientBrush DrawGradientBrush;

    private Rectangle DrawGradientRectangle;

    protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
    {
        DrawGradientRectangle = new Rectangle(x, y, width, height);
        DrawGradient(blend, DrawGradientRectangle);
    }

    protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
    {
        DrawGradientRectangle = new Rectangle(x, y, width, height);
        DrawGradient(blend, DrawGradientRectangle, angle);
    }

    protected void DrawGradient(ColorBlend blend, Rectangle r)
    {
        DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, 90f);
        DrawGradientBrush.InterpolationColors = blend;
        G.FillRectangle(DrawGradientBrush, r);
    }

    protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
    {
        DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
        DrawGradientBrush.InterpolationColors = blend;
        G.FillRectangle(DrawGradientBrush, r);
    }


    protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
    {
        DrawGradientRectangle = new Rectangle(x, y, width, height);
        DrawGradient(c1, c2, DrawGradientRectangle);
    }

    protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
    {
        DrawGradientRectangle = new Rectangle(x, y, width, height);
        DrawGradient(c1, c2, DrawGradientRectangle, angle);
    }

    protected void DrawGradient(Color c1, Color c2, Rectangle r)
    {
        DrawGradientBrush = new LinearGradientBrush(r, c1, c2, 90f);
        G.FillRectangle(DrawGradientBrush, r);
    }

    protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
    {
        DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
        G.FillRectangle(DrawGradientBrush, r);
    }

    #endregion

    #region " DrawRadial "

    private readonly GraphicsPath DrawRadialPath;
    private PathGradientBrush DrawRadialBrush1;
    private LinearGradientBrush DrawRadialBrush2;

    private Rectangle DrawRadialRectangle;

    public void DrawRadial(ColorBlend blend, int x, int y, int width, int height)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(blend, DrawRadialRectangle, width / 2, height / 2);
    }

    public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, Point center)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(blend, DrawRadialRectangle, center.X, center.Y);
    }

    public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, int cx, int cy)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(blend, DrawRadialRectangle, cx, cy);
    }

    public void DrawRadial(ColorBlend blend, Rectangle r)
    {
        DrawRadial(blend, r, r.Width / 2, r.Height / 2);
    }

    public void DrawRadial(ColorBlend blend, Rectangle r, Point center)
    {
        DrawRadial(blend, r, center.X, center.Y);
    }

    public void DrawRadial(ColorBlend blend, Rectangle r, int cx, int cy)
    {
        DrawRadialPath.Reset();
        DrawRadialPath.AddEllipse(r.X, r.Y, r.Width - 1, r.Height - 1);

        DrawRadialBrush1 = new PathGradientBrush(DrawRadialPath);
        DrawRadialBrush1.CenterPoint = new Point(r.X + cx, r.Y + cy);
        DrawRadialBrush1.InterpolationColors = blend;

        if (G.SmoothingMode == SmoothingMode.AntiAlias)
        {
            G.FillEllipse(DrawRadialBrush1, r.X + 1, r.Y + 1, r.Width - 3, r.Height - 3);
        }
        else
        {
            G.FillEllipse(DrawRadialBrush1, r);
        }
    }


    protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(c1, c2, DrawGradientRectangle);
    }

    protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height, float angle)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(c1, c2, DrawGradientRectangle, angle);
    }

    protected void DrawRadial(Color c1, Color c2, Rectangle r)
    {
        DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, 90f);
        G.FillRectangle(DrawGradientBrush, r);
    }

    protected void DrawRadial(Color c1, Color c2, Rectangle r, float angle)
    {
        DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, angle);
        G.FillEllipse(DrawGradientBrush, r);
    }

    #endregion

    #region " CreateRound "

    private GraphicsPath CreateRoundPath;

    private Rectangle CreateRoundRectangle;

    public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
    {
        CreateRoundRectangle = new Rectangle(x, y, width, height);
        return CreateRound(CreateRoundRectangle, slope);
    }

    public GraphicsPath CreateRound(Rectangle r, int slope)
    {
        CreateRoundPath = new GraphicsPath(FillMode.Winding);
        CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
        CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
        CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
        CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
        CreateRoundPath.CloseFigure();
        return CreateRoundPath;
    }

    #endregion
}

public abstract class ThemeControl154 : Control
{
    private void DoAnimation(bool i)
    {
        OnAnimation();
        if (i)
            Invalidate();
    }

    protected override sealed void OnPaint(PaintEventArgs e)
    {
        if (Width == 0 || Height == 0)
            return;

        if (_Transparent)
        {
            PaintHook();
            e.Graphics.DrawImage(B, 0, 0);
        }
        else
        {
            G = e.Graphics;
            PaintHook();
        }
    }

    protected override void OnHandleDestroyed(EventArgs e)
    {
        ThemeShare.RemoveAnimationCallback(DoAnimation);
        base.OnHandleDestroyed(e);
    }

    #region " Initialization "

    protected Graphics G;

    protected Bitmap B;

    public ThemeControl154()
    {
        SetStyle((ControlStyles)139270, true);

        ImageSize = Size.Empty;
        Font = new Font("Verdana", 8);

        MeasureBitmap = new Bitmap(1, 1);
        MeasureGraphics = Graphics.FromImage(MeasureBitmap);

        DrawRadialPath = new GraphicsPath();

        InvalidateCustimization();
        //Remove?
    }

    protected override sealed void OnHandleCreated(EventArgs e)
    {
        InvalidateCustimization();
        ColorHook();

        if (!(_LockWidth == 0))
            Width = _LockWidth;
        if (!(_LockHeight == 0))
            Height = _LockHeight;

        Transparent = _Transparent;
        if (_Transparent && _BackColor)
            BackColor = Color.Transparent;

        base.OnHandleCreated(e);
    }

    private bool DoneCreation;

    protected override sealed void OnParentChanged(EventArgs e)
    {
        if (Parent != null)
        {
            OnCreation();
            DoneCreation = true;
            InvalidateTimer();
        }

        base.OnParentChanged(e);
    }

    #endregion

    #region " Size Handling "

    protected override sealed void OnSizeChanged(EventArgs e)
    {
        if (_Transparent)
        {
            InvalidateBitmap();
        }

        Invalidate();
        base.OnSizeChanged(e);
    }

    protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
    {
        if (!(_LockWidth == 0))
            width = _LockWidth;
        if (!(_LockHeight == 0))
            height = _LockHeight;
        base.SetBoundsCore(x, y, width, height, specified);
    }

    #endregion

    #region " State Handling "

    private bool InPosition;

    protected override void OnMouseEnter(EventArgs e)
    {
        InPosition = true;
        SetState(MouseState.Over);
        base.OnMouseEnter(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        if (InPosition)
            SetState(MouseState.Over);
        base.OnMouseUp(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
            SetState(MouseState.Down);
        base.OnMouseDown(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        InPosition = false;
        SetState(MouseState.None);
        base.OnMouseLeave(e);
    }

    protected override void OnEnabledChanged(EventArgs e)
    {
        if (Enabled)
            SetState(MouseState.None);
        else
            SetState(MouseState.Block);
        base.OnEnabledChanged(e);
    }

    protected MouseState State;

    private void SetState(MouseState current)
    {
        State = current;
        Invalidate();
    }

    #endregion

    #region " Base Properties "

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color ForeColor
    {
        get { return Color.Empty; }
        set { }
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Image BackgroundImage
    {
        get { return null; }
        set { }
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override ImageLayout BackgroundImageLayout
    {
        get { return ImageLayout.None; }
        set { }
    }

    public override string Text
    {
        get { return base.Text; }
        set
        {
            base.Text = value;
            Invalidate();
        }
    }

    public override Font Font
    {
        get { return base.Font; }
        set
        {
            base.Font = value;
            Invalidate();
        }
    }

    private bool _BackColor;

    [Category("Misc")]
    public override Color BackColor
    {
        get { return base.BackColor; }
        set
        {
            if (!IsHandleCreated && value == Color.Transparent)
            {
                _BackColor = true;
                return;
            }

            base.BackColor = value;
            if (Parent != null)
                ColorHook();
        }
    }

    #endregion

    #region " Public Properties "

    private bool _NoRounding;

    public bool NoRounding
    {
        get { return _NoRounding; }
        set
        {
            _NoRounding = value;
            Invalidate();
        }
    }

    private Image _Image;

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

    private bool _Transparent;

    public bool Transparent
    {
        get { return _Transparent; }
        set
        {
            _Transparent = value;
            if (!IsHandleCreated)
                return;

            if (!value && !(BackColor.A == 255))
            {
                throw new Exception("Unable to change value to false while a transparent BackColor is in use.");
            }

            SetStyle(ControlStyles.Opaque, !value);
            SetStyle(ControlStyles.SupportsTransparentBackColor, value);

            if (value)
                InvalidateBitmap();
            else
                B = null;
            Invalidate();
        }
    }

    private readonly Dictionary<string, Color> Items = new Dictionary<string, Color>();

    public Bloom[] Colors
    {
        get
        {
            var T = new List<Bloom>();
            var E = Items.GetEnumerator();

            while (E.MoveNext())
            {
                T.Add(new Bloom(E.Current.Key, E.Current.Value));
            }

            return T.ToArray();
        }
        set
        {
            foreach (var B in value)
            {
                if (Items.ContainsKey(B.Name))
                    Items[B.Name] = B.Value;
            }

            InvalidateCustimization();
            ColorHook();
            Invalidate();
        }
    }

    private string _Customization;

    public string Customization
    {
        get { return _Customization; }
        set
        {
            if (value == _Customization)
                return;

            byte[] Data = null;
            var Items = Colors;

            try
            {
                Data = Convert.FromBase64String(value);
                for (var I = 0; I <= Items.Length - 1; I++)
                {
                    Items[I].Value = Color.FromArgb(BitConverter.ToInt32(Data, I * 4));
                }
            }
            catch
            {
                return;
            }

            _Customization = value;

            Colors = Items;
            ColorHook();
            Invalidate();
        }
    }

    #endregion

    #region " Private Properties "

    protected Size ImageSize { get; private set; }

    private int _LockWidth;

    protected int LockWidth
    {
        get { return _LockWidth; }
        set
        {
            _LockWidth = value;
            if (!(LockWidth == 0) && IsHandleCreated)
                Width = LockWidth;
        }
    }

    private int _LockHeight;

    protected int LockHeight
    {
        get { return _LockHeight; }
        set
        {
            _LockHeight = value;
            if (!(LockHeight == 0) && IsHandleCreated)
                Height = LockHeight;
        }
    }

    private bool _IsAnimated;

    protected bool IsAnimated
    {
        get { return _IsAnimated; }
        set
        {
            _IsAnimated = value;
            InvalidateTimer();
        }
    }

    #endregion

    #region " Property Helpers "

    protected Pen GetPen(string name)
    {
        return new Pen(Items[name]);
    }

    protected Pen GetPen(string name, float width)
    {
        return new Pen(Items[name], width);
    }

    protected SolidBrush GetBrush(string name)
    {
        return new SolidBrush(Items[name]);
    }

    protected Color GetColor(string name)
    {
        return Items[name];
    }

    protected void SetColor(string name, Color value)
    {
        if (Items.ContainsKey(name))
            Items[name] = value;
        else
            Items.Add(name, value);
    }

    protected void SetColor(string name, byte r, byte g, byte b)
    {
        SetColor(name, Color.FromArgb(r, g, b));
    }

    protected void SetColor(string name, byte a, byte r, byte g, byte b)
    {
        SetColor(name, Color.FromArgb(a, r, g, b));
    }

    protected void SetColor(string name, byte a, Color value)
    {
        SetColor(name, Color.FromArgb(a, value));
    }

    private void InvalidateBitmap()
    {
        if (Width == 0 || Height == 0)
            return;
        B = new Bitmap(Width, Height, PixelFormat.Format32bppPArgb);
        G = Graphics.FromImage(B);
    }

    private void InvalidateCustimization()
    {
        var M = new MemoryStream(Items.Count * 4);

        foreach (var B in Colors)
        {
            M.Write(BitConverter.GetBytes(B.Value.ToArgb()), 0, 4);
        }

        M.Close();
        _Customization = Convert.ToBase64String(M.ToArray());
    }

    private void InvalidateTimer()
    {
        if (DesignMode || !DoneCreation)
            return;

        if (_IsAnimated)
        {
            ThemeShare.AddAnimationCallback(DoAnimation);
        }
        else
        {
            ThemeShare.RemoveAnimationCallback(DoAnimation);
        }
    }

    #endregion

    #region " User Hooks "

    protected abstract void ColorHook();
    protected abstract void PaintHook();

    protected virtual void OnCreation()
    {
    }

    protected virtual void OnAnimation()
    {
    }

    #endregion

    #region " Offset "

    private Rectangle OffsetReturnRectangle;

    protected Rectangle Offset(Rectangle r, int amount)
    {
        OffsetReturnRectangle = new Rectangle(r.X + amount, r.Y + amount, r.Width - (amount * 2), r.Height - (amount * 2));
        return OffsetReturnRectangle;
    }

    private Size OffsetReturnSize;

    protected Size Offset(Size s, int amount)
    {
        OffsetReturnSize = new Size(s.Width + amount, s.Height + amount);
        return OffsetReturnSize;
    }

    private Point OffsetReturnPoint;

    protected Point Offset(Point p, int amount)
    {
        OffsetReturnPoint = new Point(p.X + amount, p.Y + amount);
        return OffsetReturnPoint;
    }

    #endregion

    #region " Center "

    private Point CenterReturn;

    protected Point Center(Rectangle p, Rectangle c)
    {
        CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X + c.X, (p.Height / 2 - c.Height / 2) + p.Y + c.Y);
        return CenterReturn;
    }

    protected Point Center(Rectangle p, Size c)
    {
        CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X, (p.Height / 2 - c.Height / 2) + p.Y);
        return CenterReturn;
    }

    protected Point Center(Rectangle child)
    {
        return Center(Width, Height, child.Width, child.Height);
    }

    protected Point Center(Size child)
    {
        return Center(Width, Height, child.Width, child.Height);
    }

    protected Point Center(int childWidth, int childHeight)
    {
        return Center(Width, Height, childWidth, childHeight);
    }

    protected Point Center(Size p, Size c)
    {
        return Center(p.Width, p.Height, c.Width, c.Height);
    }

    protected Point Center(int pWidth, int pHeight, int cWidth, int cHeight)
    {
        CenterReturn = new Point(pWidth / 2 - cWidth / 2, pHeight / 2 - cHeight / 2);
        return CenterReturn;
    }

    #endregion

    #region " Measure "

    private readonly Bitmap MeasureBitmap;
    //TODO: Potential issues during multi-threading.
    private readonly Graphics MeasureGraphics;

    protected Size Measure()
    {
        return MeasureGraphics.MeasureString(Text, Font, Width).ToSize();
    }

    protected Size Measure(string text)
    {
        return MeasureGraphics.MeasureString(text, Font, Width).ToSize();
    }

    #endregion

    #region " DrawPixel "

    private SolidBrush DrawPixelBrush;

    protected void DrawPixel(Color c1, int x, int y)
    {
        if (_Transparent)
        {
            B.SetPixel(x, y, c1);
        }
        else
        {
            DrawPixelBrush = new SolidBrush(c1);
            G.FillRectangle(DrawPixelBrush, x, y, 1, 1);
        }
    }

    #endregion

    #region " DrawCorners "

    private SolidBrush DrawCornersBrush;

    protected void DrawCorners(Color c1, int offset)
    {
        DrawCorners(c1, 0, 0, Width, Height, offset);
    }

    protected void DrawCorners(Color c1, Rectangle r1, int offset)
    {
        DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height, offset);
    }

    protected void DrawCorners(Color c1, int x, int y, int width, int height, int offset)
    {
        DrawCorners(c1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
    }

    protected void DrawCorners(Color c1)
    {
        DrawCorners(c1, 0, 0, Width, Height);
    }

    protected void DrawCorners(Color c1, Rectangle r1)
    {
        DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height);
    }

    protected void DrawCorners(Color c1, int x, int y, int width, int height)
    {
        if (_NoRounding)
            return;

        if (_Transparent)
        {
            B.SetPixel(x, y, c1);
            B.SetPixel(x + (width - 1), y, c1);
            B.SetPixel(x, y + (height - 1), c1);
            B.SetPixel(x + (width - 1), y + (height - 1), c1);
        }
        else
        {
            DrawCornersBrush = new SolidBrush(c1);
            G.FillRectangle(DrawCornersBrush, x, y, 1, 1);
            G.FillRectangle(DrawCornersBrush, x + (width - 1), y, 1, 1);
            G.FillRectangle(DrawCornersBrush, x, y + (height - 1), 1, 1);
            G.FillRectangle(DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1);
        }
    }

    #endregion

    #region " DrawBorders "

    protected void DrawBorders(Pen p1, int offset)
    {
        DrawBorders(p1, 0, 0, Width, Height, offset);
    }

    protected void DrawBorders(Pen p1, Rectangle r, int offset)
    {
        DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset);
    }

    protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
    {
        DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
    }

    protected void DrawBorders(Pen p1)
    {
        DrawBorders(p1, 0, 0, Width, Height);
    }

    protected void DrawBorders(Pen p1, Rectangle r)
    {
        DrawBorders(p1, r.X, r.Y, r.Width, r.Height);
    }

    protected void DrawBorders(Pen p1, int x, int y, int width, int height)
    {
        G.DrawRectangle(p1, x, y, width - 1, height - 1);
    }

    #endregion

    #region " DrawText "

    private Point DrawTextPoint;

    private Size DrawTextSize;

    protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y)
    {
        DrawText(b1, Text, a, x, y);
    }

    protected void DrawText(Brush b1, string text, HorizontalAlignment a, int x, int y)
    {
        if (text.Length == 0)
            return;

        DrawTextSize = Measure(text);
        DrawTextPoint = Center(DrawTextSize);

        switch (a)
        {
            case HorizontalAlignment.Left:
                G.DrawString(text, Font, b1, x, DrawTextPoint.Y + y);
                break;
            case HorizontalAlignment.Center:
                G.DrawString(text, Font, b1, DrawTextPoint.X + x, DrawTextPoint.Y + y);
                break;
            case HorizontalAlignment.Right:
                G.DrawString(text, Font, b1, Width - DrawTextSize.Width - x, DrawTextPoint.Y + y);
                break;
        }
    }

    protected void DrawText(Brush b1, Point p1)
    {
        if (Text.Length == 0)
            return;
        G.DrawString(Text, Font, b1, p1);
    }

    protected void DrawText(Brush b1, int x, int y)
    {
        if (Text.Length == 0)
            return;
        G.DrawString(Text, Font, b1, x, y);
    }

    #endregion

    #region " DrawImage "

    private Point DrawImagePoint;

    protected void DrawImage(HorizontalAlignment a, int x, int y)
    {
        DrawImage(_Image, a, x, y);
    }

    protected void DrawImage(Image image, HorizontalAlignment a, int x, int y)
    {
        if (image == null)
            return;
        DrawImagePoint = Center(image.Size);

        switch (a)
        {
            case HorizontalAlignment.Left:
                G.DrawImage(image, x, DrawImagePoint.Y + y, image.Width, image.Height);
                break;
            case HorizontalAlignment.Center:
                G.DrawImage(image, DrawImagePoint.X + x, DrawImagePoint.Y + y, image.Width, image.Height);
                break;
            case HorizontalAlignment.Right:
                G.DrawImage(image, Width - image.Width - x, DrawImagePoint.Y + y, image.Width, image.Height);
                break;
        }
    }

    protected void DrawImage(Point p1)
    {
        DrawImage(_Image, p1.X, p1.Y);
    }

    protected void DrawImage(int x, int y)
    {
        DrawImage(_Image, x, y);
    }

    protected void DrawImage(Image image, Point p1)
    {
        DrawImage(image, p1.X, p1.Y);
    }

    protected void DrawImage(Image image, int x, int y)
    {
        if (image == null)
            return;
        G.DrawImage(image, x, y, image.Width, image.Height);
    }

    #endregion

    #region " DrawGradient "

    private LinearGradientBrush DrawGradientBrush;

    private Rectangle DrawGradientRectangle;

    protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
    {
        DrawGradientRectangle = new Rectangle(x, y, width, height);
        DrawGradient(blend, DrawGradientRectangle);
    }

    protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
    {
        DrawGradientRectangle = new Rectangle(x, y, width, height);
        DrawGradient(blend, DrawGradientRectangle, angle);
    }

    protected void DrawGradient(ColorBlend blend, Rectangle r)
    {
        DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, 90f);
        DrawGradientBrush.InterpolationColors = blend;
        G.FillRectangle(DrawGradientBrush, r);
    }

    protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
    {
        DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
        DrawGradientBrush.InterpolationColors = blend;
        G.FillRectangle(DrawGradientBrush, r);
    }


    protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
    {
        DrawGradientRectangle = new Rectangle(x, y, width, height);
        DrawGradient(c1, c2, DrawGradientRectangle);
    }

    protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
    {
        DrawGradientRectangle = new Rectangle(x, y, width, height);
        DrawGradient(c1, c2, DrawGradientRectangle, angle);
    }

    protected void DrawGradient(Color c1, Color c2, Rectangle r)
    {
        DrawGradientBrush = new LinearGradientBrush(r, c1, c2, 90f);
        G.FillRectangle(DrawGradientBrush, r);
    }

    protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
    {
        DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
        G.FillRectangle(DrawGradientBrush, r);
    }

    #endregion

    #region " DrawRadial "

    private readonly GraphicsPath DrawRadialPath;
    private PathGradientBrush DrawRadialBrush1;
    private LinearGradientBrush DrawRadialBrush2;

    private Rectangle DrawRadialRectangle;

    public void DrawRadial(ColorBlend blend, int x, int y, int width, int height)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(blend, DrawRadialRectangle, width / 2, height / 2);
    }

    public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, Point center)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(blend, DrawRadialRectangle, center.X, center.Y);
    }

    public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, int cx, int cy)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(blend, DrawRadialRectangle, cx, cy);
    }

    public void DrawRadial(ColorBlend blend, Rectangle r)
    {
        DrawRadial(blend, r, r.Width / 2, r.Height / 2);
    }

    public void DrawRadial(ColorBlend blend, Rectangle r, Point center)
    {
        DrawRadial(blend, r, center.X, center.Y);
    }

    public void DrawRadial(ColorBlend blend, Rectangle r, int cx, int cy)
    {
        DrawRadialPath.Reset();
        DrawRadialPath.AddEllipse(r.X, r.Y, r.Width - 1, r.Height - 1);

        DrawRadialBrush1 = new PathGradientBrush(DrawRadialPath);
        DrawRadialBrush1.CenterPoint = new Point(r.X + cx, r.Y + cy);
        DrawRadialBrush1.InterpolationColors = blend;

        if (G.SmoothingMode == SmoothingMode.AntiAlias)
        {
            G.FillEllipse(DrawRadialBrush1, r.X + 1, r.Y + 1, r.Width - 3, r.Height - 3);
        }
        else
        {
            G.FillEllipse(DrawRadialBrush1, r);
        }
    }


    protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(c1, c2, DrawRadialRectangle);
    }

    protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height, float angle)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(c1, c2, DrawRadialRectangle, angle);
    }

    protected void DrawRadial(Color c1, Color c2, Rectangle r)
    {
        DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, 90f);
        G.FillEllipse(DrawRadialBrush2, r);
    }

    protected void DrawRadial(Color c1, Color c2, Rectangle r, float angle)
    {
        DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, angle);
        G.FillEllipse(DrawRadialBrush2, r);
    }

    #endregion

    #region " CreateRound "

    private GraphicsPath CreateRoundPath;

    private Rectangle CreateRoundRectangle;

    public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
    {
        CreateRoundRectangle = new Rectangle(x, y, width, height);
        return CreateRound(CreateRoundRectangle, slope);
    }

    public GraphicsPath CreateRound(Rectangle r, int slope)
    {
        CreateRoundPath = new GraphicsPath(FillMode.Winding);
        CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
        CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
        CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
        CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
        CreateRoundPath.CloseFigure();
        return CreateRoundPath;
    }

    #endregion
}

public static class ThemeShare
{
    #region " Animation "

    private static int Frames;
    private static bool Invalidate;

    public static PrecisionTimer ThemeTimer = new PrecisionTimer();
    //1000 / 50 = 20 FPS
    public static int FPS = 20;

    public static int Rate = 50;

    public delegate void AnimationDelegate(bool invalidate);


    private static readonly List<AnimationDelegate> Callbacks = new List<AnimationDelegate>();

    private static void HandleCallbacks(IntPtr state, bool reserve)
    {
        Invalidate = (Frames >= FPS);
        if (Invalidate)
            Frames = 0;

        lock (Callbacks)
        {
            for (var I = 0; I <= Callbacks.Count - 1; I++)
            {
                Callbacks[I].Invoke(Invalidate);
            }
        }

        Frames += Rate;
    }

    private static void InvalidateThemeTimer()
    {
        if (Callbacks.Count == 0)
        {
            ThemeTimer.Delete();
        }
        else
        {
            ThemeTimer.Create(0, (uint)Rate, HandleCallbacks);
        }
    }

    public static void AddAnimationCallback(AnimationDelegate callback)
    {
        lock (Callbacks)
        {
            if (Callbacks.Contains(callback))
                return;

            Callbacks.Add(callback);
            InvalidateThemeTimer();
        }
    }

    public static void RemoveAnimationCallback(AnimationDelegate callback)
    {
        lock (Callbacks)
        {
            if (!Callbacks.Contains(callback))
                return;

            Callbacks.Remove(callback);
            InvalidateThemeTimer();
        }
    }

    #endregion
}

public enum MouseState : byte
{
    None = 0,
    Over = 1,
    Down = 2,
    Block = 3
}

public struct Bloom
{
    public string _Name;
    private Color _Value;

    public Bloom(string name, Color value)
    {
        _Name = name;
        _Value = value;
    }

    public string Name
    {
        get { return _Name; }
    }

    public Color Value
    {
        get { return _Value; }
        set { _Value = value; }
    }

    public string ValueHex
    {
        get
        {
            return string.Concat("#", _Value.R.ToString("X2", null), _Value.G.ToString("X2", null),
                _Value.B.ToString("X2", null));
        }
        set
        {
            try
            {
                _Value = ColorTranslator.FromHtml(value);
            }
            catch
            {
            }
        }
    }
}

//------------------
//Creator: aeonhack
//Site: elitevs.net
//Created: 11/30/2011
//Changed: 11/30/2011
//Version: 1.0.0
//------------------
public class PrecisionTimer : IDisposable
{
    public delegate void TimerDelegate(IntPtr r1, bool r2);

    private IntPtr Handle;
    private TimerDelegate TimerCallback;
    public bool Enabled { get; private set; }

    public void Dispose()
    {
        Delete();
    }

    [DllImport("kernel32.dll", EntryPoint = "CreateTimerQueueTimer")]
    private static extern bool CreateTimerQueueTimer(ref IntPtr handle, IntPtr queue, TimerDelegate callback,
        IntPtr state, uint dueTime, uint period, uint flags);

    [DllImport("kernel32.dll", EntryPoint = "DeleteTimerQueueTimer")]
    private static extern bool DeleteTimerQueueTimer(IntPtr queue, IntPtr handle, IntPtr callback);

    public void Create(uint dueTime, uint period, TimerDelegate callback)
    {
        if (Enabled)
            return;

        TimerCallback = callback;
        var Success = CreateTimerQueueTimer(ref Handle, IntPtr.Zero, TimerCallback, IntPtr.Zero, dueTime, period, 0);

        if (!Success)
            ThrowNewException("CreateTimerQueueTimer");
        Enabled = Success;
    }

    public void Delete()
    {
        if (!Enabled)
            return;
        var Success = DeleteTimerQueueTimer(IntPtr.Zero, Handle, IntPtr.Zero);

        if (!Success && !(Marshal.GetLastWin32Error() == 997))
        {
            //ThrowNewException("DeleteTimerQueueTimer")
        }

        Enabled = !Success;
    }

    private void ThrowNewException(string name)
    {
        throw new Exception(string.Format("{0} failed. Win32Error: {1}", name, Marshal.GetLastWin32Error()));
    }
}

#endregion

public class GhostTheme : ThemeContainer154
{
    private bool _ShowIcon;

    public GhostTheme()
    {
        TransparencyKey = Color.Fuchsia;
    }

    public bool ShowIcon
    {
        get { return _ShowIcon; }
        set
        {
            _ShowIcon = value;
            Invalidate();
        }
    }

    protected override void ColorHook()
    {
    }

    protected override void PaintHook()
    {
        G.Clear(Color.DimGray);
        var hatch = new ColorBlend(2);
        DrawBorders(Pens.Gray, 1);
        hatch.Colors[0] = Color.DimGray;
        hatch.Colors[1] = Color.FromArgb(60, 60, 60);
        hatch.Positions[0] = 0;
        hatch.Positions[1] = 1;
        DrawGradient(hatch, new Rectangle(0, 0, Width, 24));
        hatch.Colors[0] = Color.FromArgb(100, 100, 100);
        hatch.Colors[1] = Color.DimGray;
        DrawGradient(hatch, new Rectangle(0, 0, Width, 12));
        HatchBrush asdf = null;
        asdf = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(15, Color.Black),
            Color.FromArgb(0, Color.Gray));
        hatch.Colors[0] = Color.FromArgb(120, Color.Black);
        hatch.Colors[1] = Color.FromArgb(0, Color.Black);
        DrawGradient(hatch, new Rectangle(0, 0, Width, 30));
        G.FillRectangle(asdf, 0, 0, Width, 24);
        G.DrawLine(Pens.Black, 6, 24, Width - 7, 24);
        G.DrawLine(Pens.Black, 6, 24, 6, Height - 7);
        G.DrawLine(Pens.Black, 6, Height - 7, Width - 7, Height - 7);
        G.DrawLine(Pens.Black, Width - 7, 24, Width - 7, Height - 7);
        G.FillRectangle(new SolidBrush(Color.FromArgb(60, 60, 60)), new Rectangle(1, 24, 5, Height - 6 - 24));
        G.FillRectangle(asdf, 1, 24, 5, Height - 6 - 24);
        G.FillRectangle(new SolidBrush(Color.FromArgb(60, 60, 60)),
            new Rectangle(Width - 6, 24, Width - 1, Height - 6 - 24));
        G.FillRectangle(asdf, Width - 6, 24, Width - 2, Height - 6 - 24);
        G.FillRectangle(new SolidBrush(Color.FromArgb(60, 60, 60)), new Rectangle(1, Height - 6, Width - 2, Height - 1));
        G.FillRectangle(asdf, 1, Height - 6, Width - 2, Height - 1);
        DrawBorders(Pens.Black);
        asdf = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.DimGray);
        G.FillRectangle(asdf, 7, 25, Width - 14, Height - 24 - 8);
        G.FillRectangle(new SolidBrush(Color.FromArgb(230, 20, 20, 20)), 7, 25, Width - 14, Height - 24 - 8);
        DrawCorners(Color.Fuchsia);
        DrawCorners(Color.Fuchsia, 0, 1, 1, 1);
        DrawCorners(Color.Fuchsia, 1, 0, 1, 1);
        DrawPixel(Color.Black, 1, 1);

        DrawCorners(Color.Fuchsia, 0, Height - 2, 1, 1);
        DrawCorners(Color.Fuchsia, 1, Height - 1, 1, 1);
        DrawPixel(Color.Black, Width - 2, 1);

        DrawCorners(Color.Fuchsia, Width - 1, 1, 1, 1);
        DrawCorners(Color.Fuchsia, Width - 2, 0, 1, 1);
        DrawPixel(Color.Black, 1, Height - 2);

        DrawCorners(Color.Fuchsia, Width - 1, Height - 2, 1, 1);
        DrawCorners(Color.Fuchsia, Width - 2, Height - 1, 1, 1);
        DrawPixel(Color.Black, Width - 2, Height - 2);

        var cblend = new ColorBlend(2);
        cblend.Colors[0] = Color.FromArgb(35, Color.Black);
        cblend.Colors[1] = Color.FromArgb(0, 0, 0, 0);
        cblend.Positions[0] = 0;
        cblend.Positions[1] = 1;
        DrawGradient(cblend, 7, 25, 15, Height - 6 - 24, 0);
        cblend.Colors[0] = Color.FromArgb(0, 0, 0, 0);
        cblend.Colors[1] = Color.FromArgb(35, Color.Black);
        DrawGradient(cblend, Width - 24, 25, 17, Height - 6 - 24, 0);
        cblend.Colors[1] = Color.FromArgb(0, 0, 0, 0);
        cblend.Colors[0] = Color.FromArgb(35, Color.Black);
        DrawGradient(cblend, 7, 25, Width - 14, 17, 90);
        cblend.Colors[0] = Color.FromArgb(0, 0, 0, 0);
        cblend.Colors[1] = Color.FromArgb(35, Color.Black);
        DrawGradient(cblend, 8, Height - 24, Width - 14, 17, 90);
        if (_ShowIcon == false)
        {
            G.DrawString(Text, Font, Brushes.White, new Point(6, 6));
        }
        else
        {
            G.DrawIcon(FindForm().Icon, new Rectangle(new Point(9, 5), new Size(16, 16)));
            G.DrawString(Text, Font, Brushes.White, new Point(28, 6));
        }
    }
}

public class GhostButton : ThemeControl154
{
    private int a;
    private bool Glass = true;

    public GhostButton()
    {
        IsAnimated = true;
    }

    public bool EnableGlass
    {
        get { return Glass; }
        set { Glass = value; }
    }

    public Color Color { get; set; }

    protected override void ColorHook()
    {
    }

    protected override void OnAnimation()
    {
        base.OnAnimation();
        switch (State)
        {
            case MouseState.Over:
                if (a < 20)
                {
                    a += 5;
                    Invalidate();
                    Application.DoEvents();
                }
                break;
            case MouseState.None:
                if (a > 0)
                {
                    a -= 5;
                    if (a < 0)
                        a = 0;
                    Invalidate();
                    Application.DoEvents();
                }
                break;
        }
    }

    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);
        var gg = CreateGraphics();
        var textSize = CreateGraphics().MeasureString(Text, Font);
        gg.DrawString(Text, Font, Brushes.White, new RectangleF(0, 0, Width, Height));
    }

    protected override void PaintHook()
    {
        G.Clear(Color);
        if (State == MouseState.Over)
        {
            var cblend = new ColorBlend(2);
            cblend.Colors[0] = Color.FromArgb(200, 50, 50, 50);
            cblend.Colors[1] = Color.FromArgb(200, 70, 70, 70);
            cblend.Positions[0] = 0;
            cblend.Positions[1] = 1;
            DrawGradient(cblend, new Rectangle(0, 0, Width, Height));
            cblend.Colors[0] = Color.FromArgb(0, 0, 0, 0);
            cblend.Colors[1] = Color.FromArgb(40, Color.White);
            if (Glass)
                DrawGradient(cblend, new Rectangle(0, 0, Width, Height / 5 * 2));
        }
        else if (State == MouseState.None)
        {
            var cblend = new ColorBlend(2);
            cblend.Colors[0] = Color.FromArgb(200, 50, 50, 50);
            cblend.Colors[1] = Color.FromArgb(200, 70, 70, 70);
            cblend.Positions[0] = 0;
            cblend.Positions[1] = 1;
            DrawGradient(cblend, new Rectangle(0, 0, Width, Height));
            cblend.Colors[0] = Color.FromArgb(0, 0, 0, 0);
            cblend.Colors[1] = Color.FromArgb(40, Color.White);
            if (Glass)
                DrawGradient(cblend, new Rectangle(0, 0, Width, Height / 5 * 2));
        }
        else
        {
            var cblend = new ColorBlend(2);
            cblend.Colors[0] = Color.FromArgb(200, 30, 30, 30);
            cblend.Colors[1] = Color.FromArgb(200, 50, 50, 50);
            cblend.Positions[0] = 0;
            cblend.Positions[1] = 1;
            DrawGradient(cblend, new Rectangle(0, 0, Width, Height));
            cblend.Colors[0] = Color.FromArgb(0, 0, 0, 0);
            cblend.Colors[1] = Color.FromArgb(40, Color.White);
            if (Glass)
                DrawGradient(cblend, new Rectangle(0, 0, Width, Height / 5 * 2));
        }
        G.FillRectangle(new SolidBrush(Color.FromArgb(a, Color.White)), 0, 0, Width, Height);
        HatchBrush hatch = null;
        hatch = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(25, Color.Black),
            Color.FromArgb(0, Color.Gray));
        G.FillRectangle(hatch, 0, 0, Width, Height);
        var textSize = CreateGraphics().MeasureString(Text, Font, Width - 4);
        var sf = new StringFormat();
        sf.LineAlignment = StringAlignment.Center;
        sf.Alignment = StringAlignment.Center;
        G.DrawString(Text, Font, Brushes.White, new RectangleF(2, 2, Width - 5, Height - 4), sf);
        DrawBorders(Pens.Black);
        DrawBorders(new Pen(Color.FromArgb(90, 90, 90)), 1);
    }
}

public class GhostProgressbar : ThemeControl154
{
    private int _Maximum = 100;
    private int _Value;
    private int HOffset;
    private int Progress;

    public GhostProgressbar()
    {
        _Maximum = 100;
        IsAnimated = true;
    }

    public int Maximum
    {
        get { return _Maximum; }
        set
        {
            if (value < 1)
                value = 1;
            if (value < _Value)
                _Value = value;
            _Maximum = value;
            Invalidate();
        }
    }

    public int Value
    {
        get { return _Value; }
        set
        {
            if (value > _Maximum)
                value = Maximum;
            _Value = value;
            Invalidate();
        }
    }

    public bool Animated
    {
        get { return IsAnimated; }
        set
        {
            IsAnimated = value;
            Invalidate();
        }
    }

    protected override void ColorHook()
    {
    }

    protected override void OnAnimation()
    {
        HOffset -= 1;
        if (HOffset == 7)
            HOffset = 0;
    }

    protected override void PaintHook()
    {
        var hatch = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(60, Color.Black));
        G.Clear(Color.FromArgb(0, 30, 30, 30));
        var cblend = new ColorBlend(2);
        cblend.Colors[0] = Color.FromArgb(50, 50, 50);
        cblend.Colors[1] = Color.FromArgb(70, 70, 70);
        cblend.Positions[0] = 0;
        cblend.Positions[1] = 1;
        DrawGradient(cblend, new Rectangle(0, 0, Convert.ToInt32(((Width / _Maximum) * _Value) - 2), Height - 2));
        cblend.Colors[1] = Color.FromArgb(80, 80, 80);
        DrawGradient(cblend, new Rectangle(0, 0, Convert.ToInt32(((Width / _Maximum) * _Value) - 2), Height / 5 * 2));
        G.RenderingOrigin = new Point(HOffset, 0);
        hatch = new HatchBrush(HatchStyle.ForwardDiagonal, Color.FromArgb(40, Color.Black),
            Color.FromArgb(0, Color.Gray));
        G.FillRectangle(hatch, 0, 0, Convert.ToInt32(((Width / _Maximum) * _Value) - 2), Height - 2);
        DrawBorders(Pens.Black);
        DrawBorders(new Pen(Color.FromArgb(90, 90, 90)), 1);
        DrawCorners(Color.Black);
        G.DrawLine(new Pen(Color.FromArgb(200, 90, 90, 90)), Convert.ToInt32(((Width / _Maximum) * _Value) - 2), 1,
            Convert.ToInt32(((Width / _Maximum) * _Value) - 2), Height - 2);
        G.DrawLine(Pens.Black, Convert.ToInt32(((Width / _Maximum) * _Value) - 2) + 1, 2,
            Convert.ToInt32(((Width / _Maximum) * _Value) - 2) + 1, Height - 3);
        Progress = Convert.ToInt32(((Width / _Maximum) * _Value));
        var cblend2 = new ColorBlend(3);
        cblend2.Colors[0] = Color.FromArgb(0, Color.Gray);
        cblend2.Colors[1] = Color.FromArgb(80, Color.DimGray);
        cblend2.Colors[2] = Color.FromArgb(0, Color.Gray);
        cblend2.Positions = new[]
        {
            0,
            0.5F,
            1
        };
        if (Value > 0)
            G.FillRectangle(new SolidBrush(Color.FromArgb(5, 5, 5)), Convert.ToInt32(((Width / _Maximum) * _Value)) - 1, 2,
                Width - Convert.ToInt32(((Width / _Maximum) * _Value)) - 1, Height - 4);
    }
}

[DefaultEvent("CheckedChanged")]
public class GhostCheckbox : ThemeControl154
{
    public delegate void CheckedChangedEventHandler(object sender);

    private bool _Checked;
    private int X;

    public GhostCheckbox()
    {
        Size = new Size(16, 50);
    }

    public bool Checked
    {
        get { return _Checked; }
        set
        {
            _Checked = value;
            Invalidate();
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }
        }
    }

    public event CheckedChangedEventHandler CheckedChanged;

    protected override void ColorHook()
    {
    }

    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);
        var textSize = 0;
        textSize = (int)CreateGraphics().MeasureString(Text, Font).Width;
        Width = 20 + textSize;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        X = e.X;
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (_Checked)
            _Checked = false;
        else
            _Checked = true;
    }

    protected override void PaintHook()
    {
        G.Clear(Color.FromArgb(60, 60, 60));
        HatchBrush asdf = null;
        asdf = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(35, Color.Black),
            Color.FromArgb(0, Color.Gray));
        G.FillRectangle(new SolidBrush(Color.FromArgb(60, 60, 60)), new Rectangle(0, 0, Width, Height));
        asdf = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.DimGray);
        G.FillRectangle(asdf, 0, 0, Width, Height);
        G.FillRectangle(new SolidBrush(Color.FromArgb(230, 20, 20, 20)), 0, 0, Width, Height);

        G.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), 3, 3, 10, 10);
        if (_Checked)
        {
            var cblend = new ColorBlend(2);
            cblend.Colors[0] = Color.FromArgb(60, 60, 60);
            cblend.Colors[1] = Color.FromArgb(80, 80, 80);
            cblend.Positions[0] = 0;
            cblend.Positions[1] = 1;
            DrawGradient(cblend, new Rectangle(3, 3, 10, 10));
            cblend.Colors[0] = Color.FromArgb(70, 70, 70);
            cblend.Colors[1] = Color.FromArgb(100, 100, 100);
            DrawGradient(cblend, new Rectangle(3, 3, 10, 4));
            HatchBrush hatch = null;
            hatch = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(60, Color.Black),
                Color.FromArgb(0, Color.Gray));
            G.FillRectangle(hatch, 3, 3, 10, 10);
        }
        else
        {
            HatchBrush hatch = null;
            hatch = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(20, Color.White),
                Color.FromArgb(0, Color.Gray));
            G.FillRectangle(hatch, 3, 3, 10, 10);
        }

        if (State == MouseState.Over & X < 15)
        {
            G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Gray)), new Rectangle(3, 3, 10, 10));
        }
        else if (State == MouseState.Down)
        {
            G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), new Rectangle(3, 3, 10, 10));
        }

        G.DrawRectangle(Pens.Black, 0, 0, 15, 15);
        G.DrawRectangle(new Pen(Color.FromArgb(90, 90, 90)), 1, 1, 13, 13);
        G.DrawString(Text, Font, Brushes.White, 17, 1);
    }
}

[DefaultEvent("CheckedChanged")]
public class GhostRadiobutton : ThemeControl154
{
    public delegate void CheckedChangedEventHandler(object sender);

    private bool _Checked;
    private int X;

    public GhostRadiobutton()
    {
        Size = new Size(50, 14);
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
            if (!ReferenceEquals(C, this) && C is GhostRadiobutton)
            {
                ((GhostRadiobutton)C).Checked = false;
            }
        }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (!_Checked)
            Checked = true;
        base.OnMouseDown(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        X = e.X;
        Invalidate();
    }

    protected override void ColorHook()
    {
    }

    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);
        var textSize = 0;
        textSize = (int)CreateGraphics().MeasureString(Text, Font).Width;
        Width = 20 + textSize;
    }

    protected override void PaintHook()
    {
        G.Clear(Color.FromArgb(60, 60, 60));
        HatchBrush asdf = null;
        asdf = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(35, Color.Black),
            Color.FromArgb(0, Color.Gray));
        G.FillRectangle(new SolidBrush(Color.FromArgb(60, 60, 60)), new Rectangle(0, 0, Width, Height));
        asdf = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.DimGray);
        G.FillRectangle(asdf, 0, 0, Width, Height);
        G.FillRectangle(new SolidBrush(Color.FromArgb(230, 20, 20, 20)), 0, 0, Width, Height);

        G.SmoothingMode = SmoothingMode.AntiAlias;
        G.FillEllipse(new SolidBrush(Color.Black), 2, 2, 11, 11);
        G.DrawEllipse(Pens.Black, 0, 0, 13, 13);
        G.DrawEllipse(new Pen(Color.FromArgb(90, 90, 90)), 1, 1, 11, 11);

        if (_Checked == false)
        {
            HatchBrush hatch = null;
            hatch = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(20, Color.White),
                Color.FromArgb(0, Color.Gray));
            G.FillEllipse(hatch, 2, 2, 10, 10);
        }
        else
        {
            G.FillEllipse(new SolidBrush(Color.FromArgb(80, 80, 80)), 3, 3, 7, 7);
            HatchBrush hatch = null;
            hatch = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(60, Color.Black),
                Color.FromArgb(0, Color.Gray));
            G.FillRectangle(hatch, 3, 3, 7, 7);
        }

        if (State == MouseState.Over & X < 13)
        {
            G.FillEllipse(new SolidBrush(Color.FromArgb(20, Color.White)), 2, 2, 11, 11);
        }

        G.DrawString(Text, Font, Brushes.White, 16, 0);
    }
}

public class GhostTabControl : TabControl
{
    //Stupid VB.Net bug. Please don't use more than 9999 tabs :3
    private readonly int[] Xstart = new int[10000];
    //Stupid VB.Net bug. Please don't use more than 9999 tabs :3
    private readonly int[] Xstop = new int[10000];

    public GhostTabControl()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
        DoubleBuffered = true;
        foreach (TabPage p in TabPages)
        {
            p.BackColor = Color.White;
            Application.DoEvents();
            p.BackColor = Color.Transparent;
        }
    }

    protected override void CreateHandle()
    {
        base.CreateHandle();
        Alignment = TabAlignment.Top;
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
        base.OnMouseClick(e);
        var index = 0;
        var height = (int)CreateGraphics().MeasureString("Mava is awesome", Font).Height + 8;
        foreach (var a in Xstart)
        {
            if (e.X > a & e.X < Xstop[index] & e.Y < height & e.Button == MouseButtons.Left)
            {
                SelectedIndex = index;
                Invalidate();
            }
            index += 1;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var B = new Bitmap(Width, Height);
        var G = Graphics.FromImage(B);
        G.Clear(Color.FromArgb(60, 60, 60));
        HatchBrush asdf = null;
        asdf = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(35, Color.Black),
            Color.FromArgb(0, Color.Gray));
        G.FillRectangle(new SolidBrush(Color.FromArgb(60, 60, 60)), new Rectangle(0, 0, Width, Height));
        asdf = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.DimGray);
        G.FillRectangle(asdf, 0, 0, Width, Height);
        G.FillRectangle(new SolidBrush(Color.FromArgb(230, 20, 20, 20)), 0, 0, Width, Height);

        G.FillRectangle(Brushes.Black, 0, 0, Width, CreateGraphics().MeasureString("Mava is awesome", Font).Height + 8);
        G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)), 2,
            CreateGraphics().MeasureString("Mava is awesome", Font).Height + 7, Width - 2, Height - 2);

        var totallength = 0;
        var index = 0;
        foreach (TabPage tab in TabPages)
        {
            if (SelectedIndex == index)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(60, 60, 60)), totallength, 1,
                    CreateGraphics().MeasureString(tab.Text, Font).Width + 15,
                    CreateGraphics().MeasureString("Mava is awesome", Font).Height + 10);
                asdf = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(35, Color.Black),
                    Color.FromArgb(0, Color.Gray));
                G.FillRectangle(new SolidBrush(Color.FromArgb(60, 60, 60)), totallength, 1,
                    CreateGraphics().MeasureString(tab.Text, Font).Width + 15,
                    CreateGraphics().MeasureString("Mava is awesome", Font).Height + 10);
                asdf = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.DimGray);
                G.FillRectangle(asdf, totallength, 1, CreateGraphics().MeasureString(tab.Text, Font).Width + 15,
                    CreateGraphics().MeasureString("Mava is awesome", Font).Height + 10);
                G.FillRectangle(new SolidBrush(Color.FromArgb(230, 20, 20, 20)), totallength, 1,
                    CreateGraphics().MeasureString(tab.Text, Font).Width + 15,
                    CreateGraphics().MeasureString("Mava is awesome", Font).Height + 10);

                var gradient = new LinearGradientBrush(new Point(totallength, 1),
                    new Point(totallength, (int)CreateGraphics().MeasureString("Mava is awesome", Font).Height + 8),
                    Color.FromArgb(15, Color.White), Color.Transparent);
                G.FillRectangle(gradient, totallength, 1, CreateGraphics().MeasureString(tab.Text, Font).Width + 15,
                    CreateGraphics().MeasureString("Mava is awesome", Font).Height + 5);

                G.DrawLine(new Pen(Color.FromArgb(60, 60, 60)),
                    totallength + CreateGraphics().MeasureString(tab.Text, Font).Width + 15, 2,
                    totallength + CreateGraphics().MeasureString(tab.Text, Font).Width + 15,
                    CreateGraphics().MeasureString("Mava is awesome", Font).Height + 8);
                G.DrawLine(new Pen(Color.FromArgb(60, 60, 60)), totallength, 2, totallength,
                    CreateGraphics().MeasureString("Mava is awesome", Font).Height + 8);

                G.DrawLine(new Pen(Color.FromArgb(60, 60, 60)),
                    totallength + CreateGraphics().MeasureString(tab.Text, Font).Width + 15,
                    CreateGraphics().MeasureString("Mava is awesome", Font).Height + 8, Width - 1,
                    CreateGraphics().MeasureString("Mava is awesome", Font).Height + 8);
                G.DrawLine(new Pen(Color.FromArgb(60, 60, 60)), 1,
                    CreateGraphics().MeasureString("Mava is awesome", Font).Height + 8, totallength,
                    CreateGraphics().MeasureString("Mava is awesome", Font).Height + 8);
            }
            Xstart[index] = totallength;
            Xstop[index] = totallength + (int)CreateGraphics().MeasureString(tab.Text, Font).Width + 15;
            G.DrawString(tab.Text, Font, Brushes.White, totallength + 8, 5);
            totallength += (int)CreateGraphics().MeasureString(tab.Text, Font).Width + 15;
            index += 1;
        }

        G.DrawLine(new Pen(Color.FromArgb(90, 90, 90)), 1, 1, Width - 2, 1);
        //boven
        G.DrawLine(new Pen(Color.FromArgb(90, 90, 90)), 1, Height - 2, Width - 2, Height - 2);
        //onder
        G.DrawLine(new Pen(Color.FromArgb(90, 90, 90)), 1, 1, 1, Height - 2);
        //links
        G.DrawLine(new Pen(Color.FromArgb(90, 90, 90)), Width - 2, 1, Width - 2, Height - 2);
        //rechts

        G.DrawLine(Pens.Black, 0, 0, Width - 1, 0);
        //boven
        G.DrawLine(Pens.Black, 0, Height - 1, Width, Height - 1);
        //onder
        G.DrawLine(Pens.Black, 0, 0, 0, Height - 1);
        //links
        G.DrawLine(Pens.Black, Width - 1, 0, Width - 1, Height - 1);
        //rechts

        e.Graphics.DrawImage(B, 0, 0);
        G.Dispose();
        B.Dispose();
    }

    protected override void OnSelectedIndexChanged(EventArgs e)
    {
        base.OnSelectedIndexChanged(e);
        Invalidate();
    }
}

public class GhostTabControlLagFree : TabControl
{
    private Color _Forecolor = Color.White;

    public GhostTabControlLagFree()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
        DoubleBuffered = true;
        foreach (TabPage p in TabPages)
        {
            try
            {
                p.BackColor = Color.Black;
                p.BackColor = Color.Transparent;
            }
            catch
            {
            }
        }
    }

    public override Color ForeColor
    {
        get { return _Forecolor; }
        set { _Forecolor = value; }
    }

    protected override void CreateHandle()
    {
        base.CreateHandle();
        Alignment = TabAlignment.Top;
        foreach (TabPage p in TabPages)
        {
            try
            {
                p.BackColor = Color.Black;
                p.BackColor = Color.Transparent;
            }
            catch
            {
            }
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var B = new Bitmap(Width, Height);
        var G = Graphics.FromImage(B);

        G.Clear(Color.FromArgb(60, 60, 60));

        HatchBrush asdf = null;
        asdf = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(35, Color.Black),
            Color.FromArgb(0, Color.Gray));
        G.FillRectangle(new SolidBrush(Color.FromArgb(60, 60, 60)), new Rectangle(0, 0, Width, Height));
        asdf = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.DimGray);
        G.FillRectangle(asdf, 0, 0, Width, Height);
        G.FillRectangle(new SolidBrush(Color.FromArgb(230, 20, 20, 20)), 0, 0, Width, Height);

        G.FillRectangle(Brushes.Black, new Rectangle(new Point(0, 4), new Size(Width - 2, 20)));

        G.DrawRectangle(Pens.Black, new Rectangle(new Point(0, 3), new Size(Width - 1, Height - 4)));
        G.DrawRectangle(new Pen(Color.FromArgb(90, 90, 90)),
            new Rectangle(new Point(1, 4), new Size(Width - 3, Height - 6)));

        for (var i = 0; i <= TabCount - 1; i++)
        {
            if (i == SelectedIndex)
            {
                var x2 = new Rectangle(GetTabRect(i).X, GetTabRect(i).Y + 2, GetTabRect(i).Width + 2,
                    GetTabRect(i).Height - 1);

                asdf = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(35, Color.Black),
                    Color.FromArgb(0, Color.Gray));
                G.FillRectangle(new SolidBrush(Color.FromArgb(60, 60, 60)),
                    new Rectangle(GetTabRect(i).X, GetTabRect(i).Y + 3, GetTabRect(i).Width + 1,
                        GetTabRect(i).Height - 2));
                asdf = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.DimGray);
                G.FillRectangle(asdf,
                    new Rectangle(GetTabRect(i).X, GetTabRect(i).Y + 3, GetTabRect(i).Width + 1,
                        GetTabRect(i).Height - 2));
                G.FillRectangle(new SolidBrush(Color.FromArgb(230, 20, 20, 20)),
                    new Rectangle(GetTabRect(i).X, GetTabRect(i).Y + 3, GetTabRect(i).Width + 1,
                        GetTabRect(i).Height - 2));

                var gradient =
                    new LinearGradientBrush(
                        new Rectangle(GetTabRect(i).X, GetTabRect(i).Y + 2, GetTabRect(i).Width + 2,
                            GetTabRect(i).Height - 1), Color.FromArgb(15, Color.White), Color.Transparent, 90f);
                G.FillRectangle(gradient,
                    new Rectangle(GetTabRect(i).X, GetTabRect(i).Y + 2, GetTabRect(i).Width + 2,
                        GetTabRect(i).Height - 1));
                G.DrawLine(new Pen(Color.FromArgb(90, 90, 90)), new Point(GetTabRect(i).Right, 4),
                    new Point(GetTabRect(i).Right, GetTabRect(i).Height + 3));
                if (!(SelectedIndex == 0))
                {
                    G.DrawLine(new Pen(Color.FromArgb(90, 90, 90)), new Point(GetTabRect(i).X, 4),
                        new Point(GetTabRect(i).X, GetTabRect(i).Height + 3));
                    G.DrawLine(new Pen(Color.FromArgb(90, 90, 90)), new Point(1, GetTabRect(i).Height + 3),
                        new Point(GetTabRect(i).X, GetTabRect(i).Height + 3));
                }
                G.DrawLine(new Pen(Color.FromArgb(90, 90, 90)), new Point(GetTabRect(i).Right, GetTabRect(i).Height + 3),
                    new Point(Width - 2, GetTabRect(i).Height + 3));
                G.DrawString(TabPages[i].Text, Font, new SolidBrush(_Forecolor), x2, new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                });
            }
            else
            {
                var x2 = new Rectangle(GetTabRect(i).X, GetTabRect(i).Y + 2, GetTabRect(i).Width + 2,
                    GetTabRect(i).Height - 1);
                G.DrawString(TabPages[i].Text, Font, new SolidBrush(_Forecolor), x2, new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                });
            }
        }

        e.Graphics.DrawImage(B, 0, 0);
        G.Dispose();
        B.Dispose();
    }
}

public class GhostListBoxPretty : ThemeControl154
{
    private string[] __Items = { "" };
    private ListBox withEventsField_LBox = new ListBox();

    public GhostListBoxPretty()
    {
        Controls.Add(LBox);
        Size = new Size(131, 101);

        LBox.BackColor = Color.FromArgb(0, 0, 0);
        LBox.BorderStyle = BorderStyle.None;
        LBox.DrawMode = DrawMode.OwnerDrawVariable;
        LBox.Location = new Point(3, 3);
        LBox.ForeColor = Color.White;
        LBox.ItemHeight = 20;
        LBox.Items.Clear();
        LBox.IntegralHeight = false;
        Invalidate();
    }

    public ListBox LBox
    {
        get { return withEventsField_LBox; }
        set
        {
            if (withEventsField_LBox != null)
            {
                withEventsField_LBox.DrawItem -= DrawItem;
            }
            withEventsField_LBox = value;
            if (withEventsField_LBox != null)
            {
                withEventsField_LBox.DrawItem += DrawItem;
            }
        }
    }

    public string[] Items
    {
        get { return __Items; }
        set
        {
            __Items = value;
            LBox.Items.Clear();
            Invalidate();
            LBox.Items.AddRange(value);
            Invalidate();
        }
    }

    public string SelectedItem
    {
        get { return LBox.SelectedItem.ToString(); }
    }

    protected override void ColorHook()
    {
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        LBox.Width = Width - 4;
        LBox.Height = Height - 4;
    }

    protected override void PaintHook()
    {
        G.Clear(Color.Black);
        G.DrawRectangle(Pens.Black, 0, 0, Width - 2, Height - 2);
        G.DrawRectangle(new Pen(Color.FromArgb(90, 90, 90)), 1, 1, Width - 3, Height - 3);
        LBox.Size = new Size(Width - 5, Height - 5);
    }

    public void DrawItem(object sender, DrawItemEventArgs e)
    {
        if (e.Index < 0)
            return;
        e.DrawBackground();
        e.DrawFocusRectangle();
        if (e.State.ToString().Contains("Selected"))
        {
            e.Graphics.FillRectangle(Brushes.Black, e.Bounds);
            var x2 = new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width - 1, e.Bounds.Height));
            var x3 = new Rectangle(x2.Location, new Size(x2.Width, (x2.Height / 2) - 2));
            var G1 = new LinearGradientBrush(new Point(x2.X, x2.Y), new Point(x2.X, x2.Y + x2.Height),
                Color.FromArgb(60, 60, 60), Color.FromArgb(50, 50, 50));
            var H = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(15, Color.Black), Color.Transparent);
            e.Graphics.FillRectangle(G1, x2);
            G1.Dispose();
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(25, Color.White)), x3);
            e.Graphics.FillRectangle(H, x2);
            G1.Dispose();
            e.Graphics.DrawString(" " + LBox.Items[e.Index], Font, Brushes.White, e.Bounds.X, e.Bounds.Y + 2);
        }
        else
        {
            e.Graphics.DrawString(" " + LBox.Items[e.Index], Font, Brushes.White, e.Bounds.X, e.Bounds.Y + 2);
        }
    }

    public void AddRange(object[] Items)
    {
        LBox.Items.Remove("");
        LBox.Items.AddRange(Items);
        Invalidate();
    }

    public void AddItem(object Item)
    {
        LBox.Items.Remove("");
        LBox.Items.Add(Item);
        Invalidate();
    }
}

public class GhostListboxLessPretty : ListBox
{
    public GhostListboxLessPretty()
    {
        SetStyle(ControlStyles.DoubleBuffer, true);
        Font = new Font("Microsoft Sans Serif", 9);
        BorderStyle = BorderStyle.None;
        DrawMode = DrawMode.OwnerDrawFixed;
        ItemHeight = 20;
        ForeColor = Color.DeepSkyBlue;
        BackColor = Color.FromArgb(7, 7, 7);
        IntegralHeight = false;
    }

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == 15)
            CustomPaint();
    }

    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        try
        {
            if (e.Index < 0)
                return;
            e.DrawBackground();
            var rect = new Rectangle(new Point(e.Bounds.Left, e.Bounds.Top + 2), new Size(Bounds.Width, 16));
            e.DrawFocusRectangle();
            if (e.State.ToString().Contains("Selected"))
            {
                e.Graphics.FillRectangle(Brushes.Black, e.Bounds);
                var x2 = new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width - 1, e.Bounds.Height));
                var x3 = new Rectangle(x2.Location, new Size(x2.Width, (x2.Height / 2)));
                var G1 = new LinearGradientBrush(new Point(x2.X, x2.Y), new Point(x2.X, x2.Y + x2.Height),
                    Color.FromArgb(60, 60, 60), Color.FromArgb(50, 50, 50));
                var H = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(15, Color.Black),
                    Color.Transparent);
                e.Graphics.FillRectangle(G1, x2);
                G1.Dispose();
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(25, Color.White)), x3);
                e.Graphics.FillRectangle(H, x2);
                G1.Dispose();
                e.Graphics.DrawString(" " + Items[e.Index], Font, Brushes.White, e.Bounds.X, e.Bounds.Y + 1);
            }
            else
            {
                e.Graphics.DrawString(" " + Items[e.Index], Font, Brushes.White, e.Bounds.X, e.Bounds.Y + 1);
            }
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(0, 0, 0)), new Rectangle(1, 1, Width - 3, Height - 3));
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(90, 90, 90)), new Rectangle(0, 0, Width - 1, Height - 1));
            base.OnDrawItem(e);
        }
        catch
        {
        }
    }

    public void CustomPaint()
    {
        CreateGraphics().DrawRectangle(new Pen(Color.FromArgb(0, 0, 0)), new Rectangle(1, 1, Width - 3, Height - 3));
        CreateGraphics().DrawRectangle(new Pen(Color.FromArgb(90, 90, 90)), new Rectangle(0, 0, Width - 1, Height - 1));
    }
}

public class GhostComboBox : ComboBox
{
    private int X;

    public GhostComboBox()
    {
        TextChanged += GhostCombo_TextChanged;
        DropDownClosed += GhostComboBox_DropDownClosed;
        SetStyle(
            ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
        DrawMode = DrawMode.OwnerDrawFixed;
        ItemHeight = 20;
        BackColor = Color.FromArgb(30, 30, 30);
        DropDownStyle = ComboBoxStyle.DropDownList;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        X = e.X;
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        X = -1;
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (!(DropDownStyle == ComboBoxStyle.DropDownList))
            DropDownStyle = ComboBoxStyle.DropDownList;
        var B = new Bitmap(Width, Height);
        var G = Graphics.FromImage(B);

        G.Clear(Color.FromArgb(50, 50, 50));
        var GradientBrush = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 5 * 2), Color.FromArgb(20, 0, 0, 0),
            Color.FromArgb(15, Color.White), 90f);
        G.FillRectangle(GradientBrush, new Rectangle(0, 0, Width, Height / 5 * 2));
        HatchBrush hatch = null;
        hatch = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, Color.Black),
            Color.FromArgb(0, Color.Gray));
        G.FillRectangle(hatch, 0, 0, Width, Height);

        var S1 = (int)G.MeasureString("...", Font).Height;
        if (SelectedIndex != -1)
        {
            G.DrawString(Items[SelectedIndex].ToString(), Font, new SolidBrush(Color.White), 4, Height / 2 - S1 / 2);
        }
        else
        {
            if ((Items != null) & Items.Count > 0)
            {
                G.DrawString(Items[0].ToString(), Font, new SolidBrush(Color.White), 4, Height / 2 - S1 / 2);
            }
            else
            {
                G.DrawString("...", Font, new SolidBrush(Color.White), 4, Height / 2 - S1 / 2);
            }
        }

        if (MouseButtons == MouseButtons.None & X > Width - 25)
        {
            G.FillRectangle(new SolidBrush(Color.FromArgb(7, Color.White)), Width - 25, 1, Width - 25, Height - 3);
        }
        else if (MouseButtons == MouseButtons.None & X < Width - 25 & X >= 0)
        {
            G.FillRectangle(new SolidBrush(Color.FromArgb(7, Color.White)), 2, 1, Width - 27, Height - 3);
        }

        G.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
        G.DrawRectangle(new Pen(Color.FromArgb(90, 90, 90)), 1, 1, Width - 3, Height - 3);
        G.DrawLine(new Pen(Color.FromArgb(90, 90, 90)), Width - 25, 1, Width - 25, Height - 3);
        G.DrawLine(Pens.Black, Width - 24, 0, Width - 24, Height);
        G.DrawLine(new Pen(Color.FromArgb(90, 90, 90)), Width - 23, 1, Width - 23, Height - 3);

        G.FillPolygon(Brushes.Black, Triangle(new Point(Width - 14, Height / 2), new Size(5, 3)));
        G.FillPolygon(Brushes.White, Triangle(new Point(Width - 15, Height / 2 - 1), new Size(5, 3)));

        e.Graphics.DrawImage(B, 0, 0);
        G.Dispose();
        B.Dispose();
    }

    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        if (e.Index < 0)
            return;
        var rect = new Rectangle();
        rect.X = e.Bounds.X;
        rect.Y = e.Bounds.Y;
        rect.Width = e.Bounds.Width - 1;
        rect.Height = e.Bounds.Height - 1;

        e.DrawBackground();
        if ((int)e.State == 785 | (int)e.State == 17)
        {
            e.Graphics.FillRectangle(Brushes.Black, e.Bounds);
            var x2 = new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width - 1, e.Bounds.Height));
            var x3 = new Rectangle(x2.Location, new Size(x2.Width, (x2.Height / 2) - 1));
            var G1 = new LinearGradientBrush(new Point(x2.X, x2.Y), new Point(x2.X, x2.Y + x2.Height),
                Color.FromArgb(60, 60, 60), Color.FromArgb(50, 50, 50));
            var H = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(15, Color.Black), Color.Transparent);
            e.Graphics.FillRectangle(G1, x2);
            G1.Dispose();
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(25, Color.White)), x3);
            e.Graphics.FillRectangle(H, x2);
            G1.Dispose();
            e.Graphics.DrawString(" " + Items[e.Index], Font, Brushes.White, e.Bounds.X, e.Bounds.Y + 2);
        }
        else
        {
            e.Graphics.FillRectangle(new SolidBrush(BackColor), e.Bounds);
            e.Graphics.DrawString(" " + Items[e.Index], Font, Brushes.White, e.Bounds.X, e.Bounds.Y + 2);
        }
        base.OnDrawItem(e);
    }

    public Point[] Triangle(Point Location, Size Size)
    {
        var ReturnPoints = new Point[4];
        ReturnPoints[0] = Location;
        ReturnPoints[1] = new Point(Location.X + Size.Width, Location.Y);
        ReturnPoints[2] = new Point(Location.X + Size.Width / 2, Location.Y + Size.Height);
        ReturnPoints[3] = Location;

        return ReturnPoints;
    }

    private void GhostComboBox_DropDownClosed(object sender, EventArgs e)
    {
        DropDownStyle = ComboBoxStyle.Simple;
        Application.DoEvents();
        DropDownStyle = ComboBoxStyle.DropDownList;
    }

    private void GhostCombo_TextChanged(object sender, EventArgs e)
    {
        Invalidate();
    }
}

[Designer("System.Windows.Forms.Design.ParentControlDesigner,System.Design", typeof(IDesigner))]
public class GhostGroupBox : ThemeControl154
{
    public GhostGroupBox()
    {
        SetStyle(ControlStyles.ResizeRedraw, true);
        SetStyle(ControlStyles.ContainerControl, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
    }

    protected override void ColorHook()
    {
    }

    protected override void PaintHook()
    {
        G.Clear(Color.FromArgb(60, 60, 60));
        HatchBrush asdf = null;
        asdf = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(35, Color.Black),
            Color.FromArgb(0, Color.Gray));
        G.FillRectangle(new SolidBrush(Color.FromArgb(60, 60, 60)), new Rectangle(0, 0, Width, Height));
        asdf = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.DimGray);
        G.FillRectangle(asdf, 0, 0, Width, Height);
        G.FillRectangle(new SolidBrush(Color.FromArgb(230, 20, 20, 20)), 0, 0, Width, Height);
        G.FillRectangle(new SolidBrush(Color.FromArgb(70, Color.Black)), 1, 1, Width - 2,
            CreateGraphics().MeasureString(Text, Font).Height + 8);

        G.DrawLine(new Pen(Color.FromArgb(90, 90, 90)), 1, CreateGraphics().MeasureString(Text, Font).Height + 8,
            Width - 2, CreateGraphics().MeasureString(Text, Font).Height + 8);

        DrawBorders(Pens.Black);
        DrawBorders(new Pen(Color.FromArgb(90, 90, 90)), 1);
        G.DrawString(Text, Font, Brushes.White, 5, 5);
    }
}

[DefaultEvent("TextChanged")]
public class GhostTextBox : ThemeControl154
{
    private readonly TextBox Base;
    private int _MaxLength = 32767;
    private bool _Multiline;
    private bool _ReadOnly;
    private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;
    private bool _UseSystemPasswordChar;
    private Color C1;
    private Pen P1;
    private Pen P2;

    public GhostTextBox()
    {
        Base = new TextBox();

        Base.Font = Font;
        Base.Text = Text;
        Base.MaxLength = _MaxLength;
        Base.Multiline = _Multiline;
        Base.ReadOnly = _ReadOnly;
        Base.UseSystemPasswordChar = _UseSystemPasswordChar;

        Base.BorderStyle = BorderStyle.None;

        Base.Location = new Point(5, 5);
        Base.Width = Width - 10;

        if (_Multiline)
        {
            Base.Height = Height - 11;
        }
        else
        {
            LockHeight = Base.Height + 11;
        }

        Base.TextChanged += OnBaseTextChanged;
        Base.KeyDown += OnBaseKeyDown;


        SetColor("Text", Color.White);
        SetColor("Back", 0, 0, 0);
        SetColor("Border1", Color.Black);
        SetColor("Border2", 90, 90, 90);
    }

    public HorizontalAlignment TextAlign
    {
        get { return _TextAlign; }
        set
        {
            _TextAlign = value;
            if (Base != null)
            {
                Base.TextAlign = value;
            }
        }
    }

    public int MaxLength
    {
        get { return _MaxLength; }
        set
        {
            _MaxLength = value;
            if (Base != null)
            {
                Base.MaxLength = value;
            }
        }
    }

    public bool ReadOnly
    {
        get { return _ReadOnly; }
        set
        {
            _ReadOnly = value;
            if (Base != null)
            {
                Base.ReadOnly = value;
            }
        }
    }

    public bool UseSystemPasswordChar
    {
        get { return _UseSystemPasswordChar; }
        set
        {
            _UseSystemPasswordChar = value;
            if (Base != null)
            {
                Base.UseSystemPasswordChar = value;
            }
        }
    }

    public bool Multiline
    {
        get { return _Multiline; }
        set
        {
            _Multiline = value;
            if (Base != null)
            {
                Base.Multiline = value;

                if (value)
                {
                    LockHeight = 0;
                    Base.Height = Height - 11;
                }
                else
                {
                    LockHeight = Base.Height + 11;
                }
            }
        }
    }

    public override string Text
    {
        get { return base.Text; }
        set
        {
            base.Text = value;
            if (Base != null)
            {
                Base.Text = value;
            }
        }
    }

    public override Font Font
    {
        get { return base.Font; }
        set
        {
            base.Font = value;
            if (Base != null)
            {
                Base.Font = value;
                Base.Location = new Point(3, 5);
                Base.Width = Width - 6;

                if (!_Multiline)
                {
                    LockHeight = Base.Height + 11;
                }
            }
        }
    }

    protected override void OnCreation()
    {
        if (!Controls.Contains(Base))
        {
            Controls.Add(Base);
        }
    }

    protected override void ColorHook()
    {
        C1 = GetColor("Back");

        P1 = GetPen("Border1");
        P2 = GetPen("Border2");

        Base.ForeColor = GetColor("Text");
        Base.BackColor = C1;
    }

    protected override void PaintHook()
    {
        G.Clear(C1);

        DrawBorders(P1, 1);
        DrawBorders(P2);
    }

    private void OnBaseTextChanged(object s, EventArgs e)
    {
        Text = Base.Text;
    }

    private void OnBaseKeyDown(object s, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.A)
        {
            Base.SelectAll();
            e.SuppressKeyPress = true;
        }
    }

    protected override void OnResize(EventArgs e)
    {
        Base.Location = new Point(5, 5);
        Base.Width = Width - 10;

        if (_Multiline)
        {
            Base.Height = Height - 11;
        }


        base.OnResize(e);
    }
}


public class GhostControlBoxNoMax : GhostControlBox
{
    protected override void OnClick(EventArgs e)
    {
        //Disable Maximize Button ;)
        if (X > 22 & X <= 44)
            return;
        base.OnClick(e);
    }
}
public class GhostControlBox : ThemeControl154
{
    private Pen BEdge;
    private Color BG;
    private Color Edge;
    protected int X;

    public GhostControlBox()
    {
        SetColor("Background", Color.FromArgb(64, 64, 64));
        SetColor("Edge color", Color.Black);
        SetColor("Button edge color", Color.FromArgb(90, 90, 90));
        Size = new Size(71, 19);
        Anchor = AnchorStyles.Top | AnchorStyles.Right;
    }

    protected override void ColorHook()
    {
        BG = GetColor("Background");
        Edge = GetColor("Edge color");
        BEdge = new Pen(GetColor("Button edge color"));
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        X = e.X;
        Invalidate();
    }

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
        if (X <= 22)
        {
            FindForm().WindowState = FormWindowState.Minimized;
        }
        else if (X > 22 & X <= 44)
        {
            if (FindForm().WindowState != FormWindowState.Maximized)
                FindForm().WindowState = FormWindowState.Maximized;
            else
                FindForm().WindowState = FormWindowState.Normal;
        }
        else if (X > 44)
        {
            FindForm().Close();
        }
    }

    protected override void PaintHook()
    {
        //Draw outer edge
        G.Clear(Edge);

        //Fill buttons
        var SB = new LinearGradientBrush(new Rectangle(new Point(1, 1), new Size(Width - 2, Height - 2)), BG,
            Color.FromArgb(30, 30, 30), 90f);
        G.FillRectangle(SB, new Rectangle(new Point(1, 1), new Size(Width - 2, Height - 2)));

        //Draw icons
        G.DrawString("0", new Font("Marlett", 8.25F), Brushes.White, new Point(5, 5));
        if (FindForm().WindowState != FormWindowState.Maximized)
            G.DrawString("1", new Font("Marlett", 8.25F), Brushes.White, new Point(27, 4));
        else
            G.DrawString("2", new Font("Marlett", 8.25F), Brushes.White, new Point(27, 4));
        G.DrawString("r", new Font("Marlett", 10), Brushes.White, new Point(49, 3));

        //Glassy effect
        var CBlend = new ColorBlend(2);
        CBlend.Colors = new[]
        {
            Color.FromArgb(100, Color.Black),
            Color.Transparent
        };
        CBlend.Positions = new float[]
        {
            0,
            1
        };
        DrawGradient(CBlend, new Rectangle(new Point(1, 8), new Size(68, 8)), 90f);

        //Draw button outlines
        G.DrawRectangle(BEdge, new Rectangle(new Point(1, 1), new Size(20, 16)));
        G.DrawRectangle(BEdge, new Rectangle(new Point(23, 1), new Size(20, 16)));
        G.DrawRectangle(BEdge, new Rectangle(new Point(45, 1), new Size(24, 16)));

        //Mouse states
        switch (State)
        {
            case MouseState.Over:
                if (X <= 22)
                {
                    G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)),
                        new Rectangle(new Point(1, 1), new Size(21, Height - 2)));
                }
                else if (X > 22 & X <= 44)
                {
                    G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)),
                        new Rectangle(new Point(23, 1), new Size(21, Height - 2)));
                }
                else if (X > 44)
                {
                    G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)),
                        new Rectangle(new Point(45, 1), new Size(25, Height - 2)));
                }
                break;
            case MouseState.Down:
                if (X <= 22)
                {
                    G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)),
                        new Rectangle(new Point(1, 1), new Size(21, Height - 2)));
                }
                else if (X > 22 & X <= 44)
                {
                    G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)),
                        new Rectangle(new Point(23, 1), new Size(21, Height - 2)));
                }
                else if (X > 44)
                {
                    G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)),
                        new Rectangle(new Point(45, 1), new Size(25, Height - 2)));
                }
                break;
        }
    }
}