#region Imports

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#endregion

namespace iTalk
{

    #region RoundRect

    internal static class RoundRectangle
    {
        public static GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
        {
            var GP = new GraphicsPath();
            var EndArcWidth = Curve*2;
            GP.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, EndArcWidth, EndArcWidth), -180, 90);
            GP.AddArc(
                new Rectangle(Rectangle.Width - EndArcWidth + Rectangle.X, Rectangle.Y, EndArcWidth, EndArcWidth), -90,
                90);
            GP.AddArc(
                new Rectangle(Rectangle.Width - EndArcWidth + Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y,
                    EndArcWidth, EndArcWidth), 0, 90);
            GP.AddArc(
                new Rectangle(Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y, EndArcWidth, EndArcWidth), 90,
                90);
            GP.AddLine(new Point(Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y),
                new Point(Rectangle.X, Curve + Rectangle.Y));
            return GP;
        }

        public static GraphicsPath RoundRect(int X, int Y, int Width, int Height, int Curve)
        {
            var Rectangle = new Rectangle(X, Y, Width, Height);
            var GP = new GraphicsPath();
            var EndArcWidth = Curve*2;
            GP.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, EndArcWidth, EndArcWidth), -180, 90);
            GP.AddArc(
                new Rectangle(Rectangle.Width - EndArcWidth + Rectangle.X, Rectangle.Y, EndArcWidth, EndArcWidth), -90,
                90);
            GP.AddArc(
                new Rectangle(Rectangle.Width - EndArcWidth + Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y,
                    EndArcWidth, EndArcWidth), 0, 90);
            GP.AddArc(
                new Rectangle(Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y, EndArcWidth, EndArcWidth), 90,
                90);
            GP.AddLine(new Point(Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y),
                new Point(Rectangle.X, Curve + Rectangle.Y));
            return GP;
        }
    }

    #endregion

    #region  Control Renderer

    #region  Color Table

    public abstract class xColorTable
    {
        public abstract Color TextColor { get; }
        public abstract Color Background { get; }
        public abstract Color SelectionBorder { get; }
        public abstract Color SelectionTopGradient { get; }
        public abstract Color SelectionMidGradient { get; }
        public abstract Color SelectionBottomGradient { get; }
        public abstract Color PressedBackground { get; }
        public abstract Color CheckedBackground { get; }
        public abstract Color CheckedSelectedBackground { get; }
        public abstract Color DropdownBorder { get; }
        public abstract Color Arrow { get; }
        public abstract Color OverflowBackground { get; }
    }

    public abstract class ColorTable
    {
        public abstract xColorTable CommonColorTable { get; }
        public abstract Color BackgroundTopGradient { get; }
        public abstract Color BackgroundBottomGradient { get; }
        public abstract Color DroppedDownItemBackground { get; }
        public abstract Color DropdownTopGradient { get; }
        public abstract Color DropdownBottomGradient { get; }
        public abstract Color Separator { get; }
        public abstract Color ImageMargin { get; }
    }

    public class MSColorTable : ColorTable
    {
        private readonly xColorTable _CommonColorTable;

        public MSColorTable()
        {
            _CommonColorTable = new DefaultCColorTable();
        }

        public override xColorTable CommonColorTable
        {
            get { return _CommonColorTable; }
        }

        public override Color BackgroundTopGradient
        {
            get { return Color.FromArgb(246, 246, 246); }
        }

        public override Color BackgroundBottomGradient
        {
            get { return Color.FromArgb(226, 226, 226); }
        }

        public override Color DropdownTopGradient
        {
            get { return Color.FromArgb(246, 246, 246); }
        }

        public override Color DropdownBottomGradient
        {
            get { return Color.FromArgb(246, 246, 246); }
        }

        public override Color DroppedDownItemBackground
        {
            get { return Color.FromArgb(240, 240, 240); }
        }

        public override Color Separator
        {
            get { return Color.FromArgb(190, 195, 203); }
        }

        public override Color ImageMargin
        {
            get { return Color.FromArgb(240, 240, 240); }
        }
    }

    public class DefaultCColorTable : xColorTable
    {
        public override Color CheckedBackground
        {
            get { return Color.FromArgb(230, 230, 230); }
        }

        public override Color CheckedSelectedBackground
        {
            get { return Color.FromArgb(230, 230, 230); }
        }

        public override Color SelectionBorder
        {
            get { return Color.FromArgb(180, 180, 180); }
        }

        public override Color SelectionTopGradient
        {
            get { return Color.FromArgb(240, 240, 240); }
        }

        public override Color SelectionMidGradient
        {
            get { return Color.FromArgb(235, 235, 235); }
        }

        public override Color SelectionBottomGradient
        {
            get { return Color.FromArgb(230, 230, 230); }
        }

        public override Color PressedBackground
        {
            get { return Color.FromArgb(232, 232, 232); }
        }

        public override Color TextColor
        {
            get { return Color.FromArgb(80, 80, 80); }
        }

        public override Color Background
        {
            get { return Color.FromArgb(188, 199, 216); }
        }

        public override Color DropdownBorder
        {
            get { return Color.LightGray; }
        }

        public override Color Arrow
        {
            get { return Color.Black; }
        }

        public override Color OverflowBackground
        {
            get { return Color.FromArgb(213, 220, 232); }
        }
    }

    #endregion

    #region  Renderer

    public class ControlRenderer : ToolStripProfessionalRenderer
    {
        private ColorTable _ColorTable;

        public ControlRenderer()
            : this(new MSColorTable())
        {
        }

        public ControlRenderer(ColorTable ColorTable)
        {
            this.ColorTable = ColorTable;
        }

        public new ColorTable ColorTable
        {
            get { return _ColorTable ?? (_ColorTable = new MSColorTable()); }
            set { _ColorTable = value; }
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBackground(e);

            // Menu strip bar gradient
            using (
                var LGB = new LinearGradientBrush(e.AffectedBounds, ColorTable.BackgroundTopGradient,
                    ColorTable.BackgroundBottomGradient, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(LGB, e.AffectedBounds);
            }
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip.Parent == null)
            {
                // Draw border around the menu drop-down
                var Rect = new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
                using (var P1 = new Pen(ColorTable.CommonColorTable.DropdownBorder))
                {
                    e.Graphics.DrawRectangle(P1, Rect);
                }


                // Fill the gap between menu drop-down and owner item
                using (var B1 = new SolidBrush(ColorTable.DroppedDownItemBackground))
                {
                    e.Graphics.FillRectangle(B1, e.ConnectedArea);
                }
            }
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Enabled)
            {
                if (e.Item.Selected)
                {
                    if (!e.Item.IsOnDropDown)
                    {
                        var SelRect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
                        RectDrawing.DrawSelection(e.Graphics, ColorTable.CommonColorTable, SelRect);
                    }
                    else
                    {
                        var SelRect = new Rectangle(2, 0, e.Item.Width - 4, e.Item.Height - 1);
                        RectDrawing.DrawSelection(e.Graphics, ColorTable.CommonColorTable, SelRect);
                    }
                }

                if (((ToolStripMenuItem) e.Item).DropDown.Visible && !e.Item.IsOnDropDown)
                {
                    var BorderRect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height);
                    // Fill the background
                    var BackgroundRect = new Rectangle(1, 1, e.Item.Width - 2, e.Item.Height + 2);
                    using (var B1 = new SolidBrush(ColorTable.DroppedDownItemBackground))
                    {
                        e.Graphics.FillRectangle(B1, BackgroundRect);
                    }


                    // Draw border
                    using (var P1 = new Pen(ColorTable.CommonColorTable.DropdownBorder))
                    {
                        RectDrawing.DrawRoundedRectangle(e.Graphics, P1, Convert.ToSingle(BorderRect.X),
                            Convert.ToSingle(BorderRect.Y), Convert.ToSingle(BorderRect.Width),
                            Convert.ToSingle(BorderRect.Height), 2);
                    }
                }
                e.Item.ForeColor = ColorTable.CommonColorTable.TextColor;
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = ColorTable.CommonColorTable.TextColor;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            base.OnRenderItemCheck(e);

            var rect = new Rectangle(3, 1, e.Item.Height - 3, e.Item.Height - 3);
            var c = default(Color);

            if (e.Item.Selected)
            {
                c = ColorTable.CommonColorTable.CheckedSelectedBackground;
            }
            else
            {
                c = ColorTable.CommonColorTable.CheckedBackground;
            }

            using (var b = new SolidBrush(c))
            {
                e.Graphics.FillRectangle(b, rect);
            }


            using (var p = new Pen(ColorTable.CommonColorTable.SelectionBorder))
            {
                e.Graphics.DrawRectangle(p, rect);
            }


            e.Graphics.DrawString("ü", new Font("Wingdings", 13, FontStyle.Regular), Brushes.Black, new Point(4, 2));
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            base.OnRenderSeparator(e);
            var PT1 = 28;
            var PT2 = Convert.ToInt32(e.Item.Width);
            var Y = 3;
            using (var P1 = new Pen(ColorTable.Separator))
            {
                e.Graphics.DrawLine(P1, PT1, Y, PT2, Y);
            }
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            base.OnRenderImageMargin(e);

            var BackgroundRect = new Rectangle(0, -1, e.ToolStrip.Width, e.ToolStrip.Height + 1);
            using (var LGB = new LinearGradientBrush(BackgroundRect,
                ColorTable.DropdownTopGradient,
                ColorTable.DropdownBottomGradient,
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(LGB, BackgroundRect);
            }


            using (var B1 = new SolidBrush(ColorTable.ImageMargin))
            {
                e.Graphics.FillRectangle(B1, e.AffectedBounds);
            }
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var rect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
            var @checked = Convert.ToBoolean(((ToolStripButton) e.Item).Checked);
            var drawBorder = false;

            if (@checked)
            {
                drawBorder = true;

                if (e.Item.Selected && !e.Item.Pressed)
                {
                    using (var b = new SolidBrush(ColorTable.CommonColorTable.CheckedSelectedBackground))
                    {
                        e.Graphics.FillRectangle(b, rect);
                    }
                }
                else
                {
                    using (var b = new SolidBrush(ColorTable.CommonColorTable.CheckedBackground))
                    {
                        e.Graphics.FillRectangle(b, rect);
                    }
                }
            }
            else
            {
                if (e.Item.Pressed)
                {
                    drawBorder = true;
                    using (var b = new SolidBrush(ColorTable.CommonColorTable.PressedBackground))
                    {
                        e.Graphics.FillRectangle(b, rect);
                    }
                }
                else if (e.Item.Selected)
                {
                    drawBorder = true;
                    RectDrawing.DrawSelection(e.Graphics, ColorTable.CommonColorTable, rect);
                }
            }

            if (drawBorder)
            {
                using (var p = new Pen(ColorTable.CommonColorTable.SelectionBorder))
                {
                    e.Graphics.DrawRectangle(p, rect);
                }
            }
        }

        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var rect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
            var drawBorder = false;

            if (e.Item.Pressed)
            {
                drawBorder = true;
                using (var b = new SolidBrush(ColorTable.CommonColorTable.PressedBackground))
                {
                    e.Graphics.FillRectangle(b, rect);
                }
            }
            else if (e.Item.Selected)
            {
                drawBorder = true;
                RectDrawing.DrawSelection(e.Graphics, ColorTable.CommonColorTable, rect);
            }

            if (drawBorder)
            {
                using (var p = new Pen(ColorTable.CommonColorTable.SelectionBorder))
                {
                    e.Graphics.DrawRectangle(p, rect);
                }
            }
        }

        protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderSplitButtonBackground(e);
            var drawBorder = false;
            var drawSeparator = true;
            var item = (ToolStripSplitButton) e.Item;
            checked
            {
                var btnRect = new Rectangle(0, 0, item.ButtonBounds.Width - 1, item.ButtonBounds.Height - 1);
                var borderRect = new Rectangle(0, 0, item.Bounds.Width - 1, item.Bounds.Height - 1);
                var flag = item.DropDownButtonPressed;
                if (flag)
                {
                    drawBorder = true;
                    drawSeparator = false;
                    var b = new SolidBrush(ColorTable.CommonColorTable.PressedBackground);
                    try
                    {
                        e.Graphics.FillRectangle(b, borderRect);
                    }
                    finally
                    {
                        flag = (b != null);
                        if (flag)
                        {
                            ((IDisposable) b).Dispose();
                        }
                    }
                }
                else
                {
                    flag = item.DropDownButtonSelected;
                    if (flag)
                    {
                        drawBorder = true;
                        RectDrawing.DrawSelection(e.Graphics, ColorTable.CommonColorTable, borderRect);
                    }
                }
                flag = item.ButtonPressed;
                if (flag)
                {
                    var b2 = new SolidBrush(ColorTable.CommonColorTable.PressedBackground);
                    try
                    {
                        e.Graphics.FillRectangle(b2, btnRect);
                    }
                    finally
                    {
                        flag = (b2 != null);
                        if (flag)
                        {
                            ((IDisposable) b2).Dispose();
                        }
                    }
                }
                flag = drawBorder;
                if (flag)
                {
                    var p = new Pen(ColorTable.CommonColorTable.SelectionBorder);
                    try
                    {
                        e.Graphics.DrawRectangle(p, borderRect);
                        flag = drawSeparator;
                        if (flag)
                        {
                            e.Graphics.DrawRectangle(p, btnRect);
                        }
                    }
                    finally
                    {
                        flag = (p != null);
                        if (flag)
                        {
                            p.Dispose();
                        }
                    }
                    DrawCustomArrow(e.Graphics, item);
                }
            }
        }

        private void DrawCustomArrow(Graphics g, ToolStripSplitButton item)
        {
            var dropWidth = Convert.ToInt32(item.DropDownButtonBounds.Width - 1);
            var dropHeight = Convert.ToInt32(item.DropDownButtonBounds.Height - 1);
            var triangleWidth = dropWidth/2.0F + 1;
            var triangleLeft = Convert.ToSingle(item.DropDownButtonBounds.Left + (dropWidth - triangleWidth)/2.0F);
            var triangleHeight = triangleWidth/2.0F;
            var triangleTop = Convert.ToSingle(item.DropDownButtonBounds.Top + (dropHeight - triangleHeight)/2.0F + 1);
            var arrowRect = new RectangleF(triangleLeft, triangleTop, triangleWidth, triangleHeight);

            DrawCustomArrow(g, item, Rectangle.Round(arrowRect));
        }

        private void DrawCustomArrow(Graphics g, ToolStripItem item, Rectangle rect)
        {
            var arrowEventArgs = new ToolStripArrowRenderEventArgs(g, item, rect, ColorTable.CommonColorTable.Arrow,
                ArrowDirection.Down);
            OnRenderArrow(arrowEventArgs);
        }

        protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var rect = default(Rectangle);
            var rectEnd = default(Rectangle);
            rect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 2);
            rectEnd = new Rectangle(rect.X - 5, rect.Y, rect.Width - 5, rect.Height);

            if (e.Item.Pressed)
            {
                using (var b = new SolidBrush(ColorTable.CommonColorTable.PressedBackground))
                {
                    e.Graphics.FillRectangle(b, rect);
                }
            }
            else if (e.Item.Selected)
            {
                RectDrawing.DrawSelection(e.Graphics, ColorTable.CommonColorTable, rect);
            }
            else
            {
                using (var b = new SolidBrush(ColorTable.CommonColorTable.OverflowBackground))
                {
                    e.Graphics.FillRectangle(b, rect);
                }
            }

            using (var P1 = new Pen(ColorTable.CommonColorTable.Background))
            {
                RectDrawing.DrawRoundedRectangle(e.Graphics, P1, Convert.ToSingle(rectEnd.X),
                    Convert.ToSingle(rectEnd.Y), Convert.ToSingle(rectEnd.Width), Convert.ToSingle(rectEnd.Height), 3);
            }


            // Icon
            var w = Convert.ToInt32(rect.Width - 1);
            var h = Convert.ToInt32(rect.Height - 1);
            var triangleWidth = w/2.0F + 1;
            var triangleLeft = Convert.ToSingle(rect.Left + (w - triangleWidth)/2.0F + 3);
            var triangleHeight = triangleWidth/2.0F;
            var triangleTop = Convert.ToSingle(rect.Top + (h - triangleHeight)/2.0F + 7);
            var arrowRect = new RectangleF(triangleLeft, triangleTop, triangleWidth, triangleHeight);
            DrawCustomArrow(e.Graphics, e.Item, Rectangle.Round(arrowRect));

            using (var p = new Pen(ColorTable.CommonColorTable.Arrow))
            {
                e.Graphics.DrawLine(p, triangleLeft + 2, triangleTop - 2, triangleLeft + triangleWidth - 2,
                    triangleTop - 2);
            }
        }
    }

    #endregion

    #region  Drawing

    public class RectDrawing
    {
        public static void DrawSelection(Graphics G, xColorTable ColorTable, Rectangle Rect)
        {
            var TopRect = default(Rectangle);
            var BottomRect = default(Rectangle);
            var FillRect = new Rectangle(Rect.X + 1, Rect.Y + 1, Rect.Width - 1, Rect.Height - 1);

            TopRect = FillRect;
            TopRect.Height -= Convert.ToInt32(TopRect.Height/2);
            BottomRect = new Rectangle(TopRect.X, TopRect.Bottom, TopRect.Width, FillRect.Height - TopRect.Height);

            // Top gradient
            using (
                var LGB = new LinearGradientBrush(TopRect, ColorTable.SelectionTopGradient,
                    ColorTable.SelectionMidGradient, LinearGradientMode.Vertical))
            {
                G.FillRectangle(LGB, TopRect);
            }


            // Bottom
            using (var B1 = new SolidBrush(ColorTable.SelectionBottomGradient))
            {
                G.FillRectangle(B1, BottomRect);
            }


            // Border
            using (var P1 = new Pen(ColorTable.SelectionBorder))
            {
                DrawRoundedRectangle(G, P1, Convert.ToSingle(Rect.X), Convert.ToSingle(Rect.Y),
                    Convert.ToSingle(Rect.Width), Convert.ToSingle(Rect.Height), 2);
            }
        }

        public static void DrawRoundedRectangle(Graphics G, Pen P, float X, float Y, float W, float H, float Rad)
        {
            using (var gp = new GraphicsPath())
            {
                gp.AddLine(X + Rad, Y, X + W - (Rad*2), Y);
                gp.AddArc(X + W - (Rad*2), Y, Rad*2, Rad*2, 270, 90);
                gp.AddLine(X + W, Y + Rad, X + W, Y + H - (Rad*2));
                gp.AddArc(X + W - (Rad*2), Y + H - (Rad*2), Rad*2, Rad*2, 0, 90);
                gp.AddLine(X + W - (Rad*2), Y + H, X + Rad, Y + H);
                gp.AddArc(X, Y + H - (Rad*2), Rad*2, Rad*2, 90, 90);
                gp.AddLine(X, Y + H - (Rad*2), X, Y + Rad);
                gp.AddArc(X, Y, Rad*2, Rad*2, 180, 90);
                gp.CloseFigure();

                G.SmoothingMode = SmoothingMode.AntiAlias;
                G.DrawPath(P, gp);
                G.SmoothingMode = SmoothingMode.Default;
            }
        }
    }

    #endregion

    #endregion

    #region  ThemeContainer

    public class iTalk_ThemeContainer : ContainerControl
    {
        #region  Enums

        public enum MouseState
        {
            None = 0,
            Over = 1,
            Down = 2
        }

        #endregion

        public iTalk_ThemeContainer()
        {
            SetStyle((ControlStyles) (139270), true);
            Dock = DockStyle.Fill;
            MoveHeight = 25;
            Padding = new Padding(3, 28, 3, 28);
            Font = new Font("Segoe UI", 8, FontStyle.Regular);
            ForeColor = Color.FromArgb(142, 142, 142);
            BackColor = Color.FromArgb(246, 246, 246);
            DoubleBuffered = true;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            ParentForm.FormBorderStyle = FormBorderStyle.None;
            ParentForm.TransparencyKey = Color.Fuchsia;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var B = new Bitmap(Width, Height);
            var G = Graphics.FromImage(B);
            var clientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            var TransparencyKey = ParentForm.TransparencyKey;

            G.SmoothingMode = SmoothingMode.Default;
            G.Clear(TransparencyKey);

            // Draw the container borders
            G.FillPath(new SolidBrush(Color.FromArgb(52, 52, 52)),
                RoundRectangle.RoundRect(clientRectangle, BorderCurve));
            // Draw a rectangle in which the controls should be added on
            G.FillPath(new SolidBrush(Color.FromArgb(246, 246, 246)),
                RoundRectangle.RoundRect(new Rectangle(2, 20, Width - 5, Height - 42), BorderCurve));

            // Patch the header with a rectangle that has a curve so its border will remain within container bounds
            G.FillPath(new SolidBrush(Color.FromArgb(52, 52, 52)),
                RoundRectangle.RoundRect(new Rectangle(2, 2, Width/2 + 2, 16), BorderCurve));
            G.FillPath(new SolidBrush(Color.FromArgb(52, 52, 52)),
                RoundRectangle.RoundRect(new Rectangle(Width/2 - 3, 2, Width/2, 16), BorderCurve));
            // Fill the header rectangle below the patch
            G.FillRectangle(new SolidBrush(Color.FromArgb(52, 52, 52)), new Rectangle(2, 15, Width - 5, 10));

            // Increase the thickness of the container borders
            G.DrawPath(new Pen(Color.FromArgb(52, 52, 52)),
                RoundRectangle.RoundRect(new Rectangle(2, 2, Width - 5, Height - 5), BorderCurve));
            G.DrawPath(new Pen(Color.FromArgb(52, 52, 52)), RoundRectangle.RoundRect(clientRectangle, BorderCurve));

            // Draw the string from the specified 'Text' property on the header rectangle
            G.DrawString(Text, new Font("Trebuchet MS", 10, FontStyle.Bold),
                new SolidBrush(Color.FromArgb(221, 221, 221)),
                new Rectangle(BorderCurve, BorderCurve - 4, Width - 1, 22),
                new StringFormat {Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near});


            // Draws a rectangle at the bottom of the container
            G.FillRectangle(new SolidBrush(Color.FromArgb(52, 52, 52)), 0, Height - 25, Width - 3, 22 - 2);
            G.DrawLine(new Pen(Color.FromArgb(52, 52, 52)), 5, Height - 5, Width - 6, Height - 5);
            G.DrawLine(new Pen(Color.FromArgb(52, 52, 52)), 7, Height - 4, Width - 7, Height - 4);

            G.DrawString(_TextBottom, new Font("Trebuchet MS", 10, FontStyle.Bold),
                new SolidBrush(Color.FromArgb(221, 221, 221)), 5, Height - 23);

            e.Graphics.DrawImage((Image) (B.Clone()), 0, 0);
            G.Dispose();
            B.Dispose();
        }

        #region  Variables

        private readonly Point MouseP = new Point(0, 0);
        private bool Cap;
        private readonly int MoveHeight;
        private readonly string _TextBottom = null;
        private const int BorderCurve = 7;
        protected MouseState State;
        private bool HasShown;
        private Rectangle HeaderRect;

        #endregion

        #region  Properties

        private bool _Sizable = true;

        public bool Sizable
        {
            get { return _Sizable; }
            set { _Sizable = value; }
        }

        public bool SmartBounds { get; set; }

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
                    Debug.Assert(ParentForm != null, "ParentForm != null");
                    ParentForm.FormBorderStyle = FormBorderStyle.None;
                    ParentForm.TransparencyKey = Color.Fuchsia;

                    if (!DesignMode)
                    {
                        ParentForm.Shown += FormShown;
                    }
                }
                Parent.BackColor = BackColor;
                Parent.MinimumSize = new Size(126, 39);
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
            Debug.Assert(ParentForm != null, "ParentForm != null");
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
                if (!SmartBounds)
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

    #region ControlBox

    public class iTalk_ControlBox : Control
    {
        #region Enums

        public enum MouseState : byte
        {
            None = 0,
            Over = 1,
            Down = 2,
            Block = 3
        }

        #endregion

        public iTalk_ControlBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            var location = new Point(checked(FindForm().Width - 81), -1);
            Location = location;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var B = new Bitmap(Width, Height);
            var G = Graphics.FromImage(B);
            //GraphicsPath GP_MinimizeRect = new GraphicsPath();
            var GP_CloseRect = new GraphicsPath();

            //GP_MinimizeRect.AddRectangle(MinimizeRect);
            GP_CloseRect.AddRectangle(CloseRect);
            G.Clear(BackColor);

            switch (State)
            {
                case MouseState.None:
                    NonePoint:
                    //LinearGradientBrush MinimizeGradient = new LinearGradientBrush(MinimizeRect, Color.FromArgb(73, 73, 73), Color.FromArgb(58, 58, 58), 90);
                    //G.FillPath(MinimizeGradient, GP_MinimizeRect);
                    //G.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), GP_MinimizeRect);
                    //G.DrawString("0", new Font("Marlett", 11, FontStyle.Regular), new SolidBrush(Color.FromArgb(221, 221, 221)), MinimizeRect.Width - 22, MinimizeRect.Height - 16);

                    var CloseGradient = new LinearGradientBrush(CloseRect, Color.FromArgb(73, 73, 73),
                        Color.FromArgb(58, 58, 58), 90);
                    G.FillPath(CloseGradient, GP_CloseRect);
                    G.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), GP_CloseRect);
                    G.DrawString("r", new Font("Marlett", 11, FontStyle.Regular),
                        new SolidBrush(Color.FromArgb(221, 221, 221)), CloseRect.Width - 4, CloseRect.Height - 16);
                    break;
                case MouseState.Over:
                    if (i > 0 & i < 28)
                    {
                        // LinearGradientBrush xMinimizeGradient = new LinearGradientBrush(this.MinimizeRect, Color.FromArgb(76, 76, 76, 76), Color.FromArgb(48, 48, 48), 90f);
                        // G.FillPath(xMinimizeGradient, GP_MinimizeRect);
                        // G.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), GP_MinimizeRect);
                        // G.DrawString("0", new Font("Marlett", 11, FontStyle.Regular), new SolidBrush(Color.FromArgb(221, 221, 221)), MinimizeRect.Width - 22, MinimizeRect.Height - 16);

                        var xCloseGradient = new LinearGradientBrush(CloseRect, Color.FromArgb(73, 73, 73),
                            Color.FromArgb(58, 58, 58), 90);
                        G.FillPath(xCloseGradient, GP_CloseRect);
                        G.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), GP_CloseRect);
                        G.DrawString("r", new Font("Marlett", 11, FontStyle.Regular),
                            new SolidBrush(Color.FromArgb(221, 221, 221)), CloseRect.Width - 4, CloseRect.Height - 16);
                    }
                    else if (i > 30 & i < 75)
                    {
                        var xCloseGradient = new LinearGradientBrush(CloseRect, Color.FromArgb(76, 76, 76, 76),
                            Color.FromArgb(48, 48, 48), 90);
                        G.FillPath(xCloseGradient, GP_CloseRect);
                        G.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), GP_CloseRect);
                        G.DrawString("r", new Font("Marlett", 11, FontStyle.Regular),
                            new SolidBrush(Color.FromArgb(221, 221, 221)), CloseRect.Width - 4, CloseRect.Height - 16);

                        //   LinearGradientBrush xMinimizeGradient = new LinearGradientBrush(MinimizeRect, Color.FromArgb(73, 73, 73), Color.FromArgb(58, 58, 58), 90);
                        //   G.FillPath(xMinimizeGradient, RoundRectangle.RoundRect(MinimizeRect, 1));
                        //   G.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), GP_MinimizeRect);
                        //   G.DrawString("0", new Font("Marlett", 11, FontStyle.Regular), new SolidBrush(Color.FromArgb(221, 221, 221)), MinimizeRect.Width - 22, MinimizeRect.Height - 16);
                    }
                    else
                    {
                        goto NonePoint; // Return to [MouseState = None]     
                    }
                    break;
            }

            e.Graphics.DrawImage((Image) B.Clone(), 0, 0);
            G.Dispose();
            GP_CloseRect.Dispose();
            //GP_MinimizeRect.Dispose();
            B.Dispose();
        }

        #region Variables

        private MouseState State = MouseState.None;
        private int i;
        private Rectangle CloseRect = new Rectangle(28, 0, 47, 18);
        private Rectangle MinimizeRect = new Rectangle(0, 0, 28, 18);

        #endregion

        #region EventArgs

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (i > 0 & i < 28)
            {
                //this.FindForm().WindowState = FormWindowState.Minimized;
            }
            else if (i > 30 & i < 75)
            {
                FindForm().Close();
            }

            State = MouseState.Down;
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

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            i = e.Location.X;
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Width = 77;
            Height = 19;
        }

        #endregion
    }

    #endregion

    #region Button 1

    public class iTalk_Button_1 : Control
    {
        public iTalk_Button_1()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 12);
            ForeColor = Color.FromArgb(150, 150, 150);
            Size = new Size(166, 40);
            _TextAlignment = StringAlignment.Center;
            P1 = new Pen(Color.FromArgb(190, 190, 190)); // P1 = Border color
        }

        protected override void OnResize(EventArgs e)
        {
            if (Width > 0 && Height > 0)
            {
                Shape = new GraphicsPath();
                R1 = new Rectangle(0, 0, Width, Height);

                InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(251, 251, 251),
                    Color.FromArgb(225, 225, 225), 90f);
                PressedGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(235, 235, 235),
                    Color.FromArgb(223, 223, 223), 90f);
                PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height),
                    Color.FromArgb(167, 167, 167), Color.FromArgb(167, 167, 167), 90f);

                P3 = new Pen(PressedContourGB);
            }

            var _Shape = Shape;
            _Shape.AddArc(0, 0, 10, 10, 180, 90);
            _Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
            _Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            _Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
            _Shape.CloseAllFigures();

            Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var _G = e.Graphics;
            _G.SmoothingMode = SmoothingMode.HighQuality;
            var ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);

            switch (MouseState)
            {
                case 0:
                    _G.FillPath(InactiveGB, Shape);
                    _G.DrawPath(P1, Shape);
                    if ((Image == null))
                    {
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
                case 1:
                    _G.FillPath(PressedGB, Shape);
                    _G.DrawPath(P3, Shape);

                    if ((Image == null))
                    {
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
            }
            base.OnPaint(e);
        }

        #region Variables

        private int MouseState;
        private GraphicsPath Shape;
        private LinearGradientBrush InactiveGB;
        private LinearGradientBrush PressedGB;
        private LinearGradientBrush PressedContourGB;
        private Rectangle R1;
        private readonly Pen P1;
        private Pen P3;
        private Image _Image;
        private StringAlignment _TextAlignment = StringAlignment.Center;
        private Color _TextColor = Color.FromArgb(150, 150, 150);
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleLeft;

        #endregion

        #region Image Designer

        private static PointF ImageLocation(StringFormat SF, SizeF Area, SizeF ImageArea)
        {
            var MyPoint = default(PointF);
            switch (SF.Alignment)
            {
                case StringAlignment.Center:
                    MyPoint.X = Convert.ToSingle((Area.Width - ImageArea.Width)/2);
                    break;
                case StringAlignment.Near:
                    MyPoint.X = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.X = Area.Width - ImageArea.Width - 2;

                    break;
            }

            switch (SF.LineAlignment)
            {
                case StringAlignment.Center:
                    MyPoint.Y = Convert.ToSingle((Area.Height - ImageArea.Height)/2);
                    break;
                case StringAlignment.Near:
                    MyPoint.Y = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.Y = Area.Height - ImageArea.Height - 2;
                    break;
            }
            return MyPoint;
        }

        private StringFormat GetStringFormat(ContentAlignment _ContentAlignment)
        {
            var SF = new StringFormat();
            switch (_ContentAlignment)
            {
                case ContentAlignment.MiddleCenter:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleLeft:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.TopCenter:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopLeft:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.BottomRight:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Far;
                    break;
            }
            return SF;
        }

        #endregion

        #region Properties

        public Image Image
        {
            get { return _Image; }
            set
            {
                ImageSize = value == null ? Size.Empty : value.Size;

                _Image = value;
                Invalidate();
            }
        }

        protected Size ImageSize { get; private set; }

        public ContentAlignment ImageAlign
        {
            get { return _ImageAlign; }
            set
            {
                _ImageAlign = value;
                Invalidate();
            }
        }

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

        #region EventArgs

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

    #region Button 2

    public class iTalk_Button_2 : Control
    {
        public iTalk_Button_2()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 14);
            ForeColor = Color.White;
            Size = new Size(166, 40);
            _TextAlignment = StringAlignment.Center;
            P1 = new Pen(Color.FromArgb(0, 118, 176));
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (Width > 0 && Height > 0)
            {
                Shape = new GraphicsPath();
                R1 = new Rectangle(0, 0, Width, Height);

                InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(0, 176, 231),
                    Color.FromArgb(0, 152, 224), 90f);
                PressedGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(0, 118, 176),
                    Color.FromArgb(0, 149, 222), 90f);
                PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height),
                    Color.FromArgb(0, 118, 176), Color.FromArgb(0, 118, 176), 90f);

                P3 = new Pen(PressedContourGB);
            }

            var _Shape = Shape;
            _Shape.AddArc(0, 0, 10, 10, 180, 90);
            _Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
            _Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            _Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
            _Shape.CloseAllFigures();

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var _G = e.Graphics;
            _G.SmoothingMode = SmoothingMode.HighQuality;

            var ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);

            switch (MouseState)
            {
                case 0:
                    _G.FillPath(InactiveGB, Shape);
                    _G.DrawPath(P1, Shape);
                    if ((Image == null))
                    {
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
                case 1:
                    _G.FillPath(PressedGB, Shape);
                    _G.DrawPath(P3, Shape);
                    if ((Image == null))
                    {
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
            }
            base.OnPaint(e);
        }

        #region Variables

        private int MouseState;
        private GraphicsPath Shape;
        private LinearGradientBrush InactiveGB;
        private LinearGradientBrush PressedGB;
        private LinearGradientBrush PressedContourGB;
        private Rectangle R1;
        private readonly Pen P1;
        private Pen P3;
        private Image _Image;
        private StringAlignment _TextAlignment = StringAlignment.Center;
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleLeft;

        #endregion

        #region Image Designer

        private static PointF ImageLocation(StringFormat SF, SizeF Area, SizeF ImageArea)
        {
            var MyPoint = default(PointF);
            switch (SF.Alignment)
            {
                case StringAlignment.Center:
                    MyPoint.X = Convert.ToSingle((Area.Width - ImageArea.Width)/2);
                    break;
                case StringAlignment.Near:
                    MyPoint.X = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.X = Area.Width - ImageArea.Width - 2;
                    break;
            }

            switch (SF.LineAlignment)
            {
                case StringAlignment.Center:
                    MyPoint.Y = Convert.ToSingle((Area.Height - ImageArea.Height)/2);
                    break;
                case StringAlignment.Near:
                    MyPoint.Y = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.Y = Area.Height - ImageArea.Height - 2;
                    break;
            }
            return MyPoint;
        }

        private StringFormat GetStringFormat(ContentAlignment _ContentAlignment)
        {
            var SF = new StringFormat();
            switch (_ContentAlignment)
            {
                case ContentAlignment.MiddleCenter:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleLeft:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.TopCenter:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopLeft:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.BottomRight:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Far;
                    break;
            }
            return SF;
        }

        #endregion

        #region Properties

        public Image Image
        {
            get { return _Image; }
            set
            {
                ImageSize = value == null ? Size.Empty : value.Size;

                _Image = value;
                Invalidate();
            }
        }

        public StringAlignment TextAlignment
        {
            get { return _TextAlignment; }
            set
            {
                _TextAlignment = value;
                Invalidate();
            }
        }

        protected Size ImageSize { get; private set; }

        public ContentAlignment ImageAlign
        {
            get { return _ImageAlign; }
            set
            {
                _ImageAlign = value;
                Invalidate();
            }
        }

        #endregion

        #region EventArgs

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
            // [Inactive]
            Invalidate();
            // Update control
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

    #region Toggle Button

    [DefaultEvent("ToggledChanged")]
    public class iTalk_Toggle : Control
    {
        #region Enums

        public enum _Type
        {
            YesNo,
            OnOff,
            IO
        }

        #endregion

        public iTalk_Toggle()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint, true);
            AnimationTimer.Tick += AnimationTimer_Tick;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            AnimationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            //  Create a slide animation when toggled on/off
            if (_Toggled)
            {
                if ((ToggleLocation < 100))
                {
                    ToggleLocation += 10;
                    Invalidate(false);
                }
            }
            else if ((ToggleLocation > 0))
            {
                ToggleLocation -= 10;
                Invalidate(false);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var G = e.Graphics;
            G.Clear(Parent.BackColor);
            checked
            {
                var point = new Point(0, (int) Math.Round(unchecked(Height/2.0 - cHandle.Height/2.0)));
                var arg_A8_0 = point;
                var point2 = new Point(0, (int) Math.Round(unchecked(Height/2.0 + cHandle.Height/2.0)));
                var Gradient = new LinearGradientBrush(arg_A8_0, point2, Color.FromArgb(250, 250, 250),
                    Color.FromArgb(240, 240, 240));
                Bar = new Rectangle(8, 10, Width - 21, Height - 21);

                G.SmoothingMode = SmoothingMode.AntiAlias;
                G.FillPath(Gradient,
                    (GraphicsPath)
                        Pill(0, (int) Math.Round(unchecked(Height/2.0 - cHandle.Height/2.0)), Width - 1,
                            cHandle.Height - 5, new PillStyle
                            {
                                Left = true,
                                Right = true
                            }));
                G.DrawPath(new Pen(Color.FromArgb(177, 177, 176)),
                    (GraphicsPath)
                        Pill(0, (int) Math.Round(unchecked(Height/2.0 - cHandle.Height/2.0)), Width - 1,
                            cHandle.Height - 5, new PillStyle
                            {
                                Left = true,
                                Right = true
                            }));
                Gradient.Dispose();
                switch (ToggleType)
                {
                    case _Type.YesNo:
                    {
                        var toggled = Toggled;
                        if (toggled)
                        {
                            G.DrawString("Yes", new Font("Segoe UI", 7f, FontStyle.Regular), Brushes.Gray, Bar.X + 7,
                                Bar.Y, new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                });
                        }
                        else
                        {
                            G.DrawString("No", new Font("Segoe UI", 7f, FontStyle.Regular), Brushes.Gray, Bar.X + 18,
                                Bar.Y, new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                });
                        }
                        break;
                    }
                    case _Type.OnOff:
                    {
                        var toggled = Toggled;
                        if (toggled)
                        {
                            G.DrawString("On", new Font("Segoe UI", 7f, FontStyle.Regular), Brushes.Gray, Bar.X + 7,
                                Bar.Y, new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                });
                        }
                        else
                        {
                            G.DrawString("Off", new Font("Segoe UI", 7f, FontStyle.Regular), Brushes.Gray, Bar.X + 18,
                                Bar.Y, new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                });
                        }
                        break;
                    }
                    case _Type.IO:
                    {
                        var toggled = Toggled;
                        if (toggled)
                        {
                            G.DrawString("I", new Font("Segoe UI", 7f, FontStyle.Regular), Brushes.Gray, Bar.X + 7,
                                Bar.Y, new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                });
                        }
                        else
                        {
                            G.DrawString("O", new Font("Segoe UI", 7f, FontStyle.Regular), Brushes.Gray, Bar.X + 18,
                                Bar.Y, new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                });
                        }
                        break;
                    }
                }
                G.FillEllipse(new SolidBrush(Color.FromArgb(249, 249, 249)),
                    Bar.X + (int) Math.Round(unchecked(Bar.Width*(ToggleLocation/80.0))) -
                    (int) Math.Round(cHandle.Width/2.0),
                    Bar.Y + (int) Math.Round(Bar.Height/2.0) - (int) Math.Round(unchecked(cHandle.Height/2.0 - 1.0)),
                    cHandle.Width, cHandle.Height - 5);
                G.DrawEllipse(new Pen(Color.FromArgb(177, 177, 176)),
                    Bar.X +
                    (int)
                        Math.Round(
                            unchecked(Bar.Width*(ToggleLocation/80.0) - checked((int) Math.Round(cHandle.Width/2.0)))),
                    Bar.Y + (int) Math.Round(Bar.Height/2.0) - (int) Math.Round(unchecked(cHandle.Height/2.0 - 1.0)),
                    cHandle.Width, cHandle.Height - 5);
            }
        }

        #region Designer

        //|------DO-NOT-REMOVE------|
        //|---------CREDITS---------|

        // Pill class and functions were originally created by Tedd
        // Last edited by Tedd on: 12/20/2013
        // Modified by HazelDev on: 1/4/2014

        //|---------CREDITS---------|
        //|------DO-NOT-REMOVE------|

        public class PillStyle
        {
            public bool Left;
            public bool Right;
        }

        public GraphicsPath Pill(Rectangle Rectangle, PillStyle PillStyle)
        {
            var functionReturnValue = default(GraphicsPath);
            functionReturnValue = new GraphicsPath();

            if (PillStyle.Left)
            {
                functionReturnValue.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, Rectangle.Height, Rectangle.Height),
                    -270, 180);
            }
            else
            {
                functionReturnValue.AddLine(Rectangle.X, Rectangle.Y + Rectangle.Height, Rectangle.X, Rectangle.Y);
            }

            if (PillStyle.Right)
            {
                functionReturnValue.AddArc(
                    new Rectangle(Rectangle.X + Rectangle.Width - Rectangle.Height, Rectangle.Y, Rectangle.Height,
                        Rectangle.Height), -90, 180);
            }
            else
            {
                functionReturnValue.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y, Rectangle.X + Rectangle.Width,
                    Rectangle.Y + Rectangle.Height);
            }

            functionReturnValue.CloseAllFigures();
            return functionReturnValue;
        }

        public object Pill(int X, int Y, int Width, int Height, PillStyle PillStyle)
        {
            return Pill(new Rectangle(X, Y, Width, Height), PillStyle);
        }

        #endregion

        #region Variables

        private readonly Timer AnimationTimer = new Timer {Interval = 1};
        private int ToggleLocation;
        public event ToggledChangedEventHandler ToggledChanged;

        public delegate void ToggledChangedEventHandler();

        private bool _Toggled;
        private _Type ToggleType;
        private Rectangle Bar;
        private Size cHandle = new Size(15, 20);

        #endregion

        #region Properties

        public bool Toggled
        {
            get { return _Toggled; }
            set
            {
                _Toggled = value;
                Invalidate();

                if (ToggledChanged != null)
                {
                    ToggledChanged();
                }
            }
        }

        public _Type Type
        {
            get { return ToggleType; }
            set
            {
                ToggleType = value;
                Invalidate();
            }
        }

        #endregion

        #region EventArgs

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Width = 41;
            Height = 23;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Toggled = !Toggled;
        }

        #endregion
    }

    #endregion

    #region Label

    public class iTalk_Label : Label
    {
        public iTalk_Label()
        {
            Font = new Font("Segoe UI", 8);
            ForeColor = Color.FromArgb(142, 142, 142);
            BackColor = Color.Transparent;
        }
    }

    #endregion

    #region Link Label

    public class iTalk_LinkLabel : LinkLabel
    {
        public iTalk_LinkLabel()
        {
            Font = new Font("Segoe UI", 8, FontStyle.Regular);
            BackColor = Color.Transparent;
            LinkColor = Color.FromArgb(51, 153, 225);
            ActiveLinkColor = Color.FromArgb(0, 101, 202);
            VisitedLinkColor = Color.FromArgb(0, 101, 202);
            LinkBehavior = LinkBehavior.NeverUnderline;
        }
    }

    #endregion

    #region Header Label

    public class iTalk_HeaderLabel : Label
    {
        public iTalk_HeaderLabel()
        {
            Font = new Font("Segoe UI", 25, FontStyle.Regular);
            ForeColor = Color.FromArgb(80, 80, 80);
            BackColor = Color.Transparent;
        }
    }

    #endregion

    #region Big TextBox

    [DefaultEvent("TextChanged")]
    public class iTalk_TextBox_Big : Control
    {
        public iTalk_TextBox_Big()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);

            AddTextBox();
            Controls.Add(iTalkTB);

            P1 = new Pen(Color.FromArgb(180, 180, 180)); // P1 = Border color
            B1 = new SolidBrush(Color.White); // B1 = Rect Background color
            BackColor = Color.Transparent;
            ForeColor = Color.DimGray;

            Text = null;
            Font = new Font("Tahoma", 11);
            Size = new Size(135, 43);
            DoubleBuffered = true;
        }

        public void AddTextBox()
        {
            var _TB = iTalkTB;
            _TB.Location = new Point(7, 10);
            _TB.Text = string.Empty;
            _TB.BorderStyle = BorderStyle.None;
            _TB.TextAlign = HorizontalAlignment.Left;
            _TB.Font = new Font("Tahoma", 11);
            _TB.UseSystemPasswordChar = UseSystemPasswordChar;
            _TB.Multiline = false;
            iTalkTB.KeyDown += _OnKeyDown;
            iTalkTB.TextChanged += OnBaseTextChanged;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var B = new Bitmap(Width, Height);
            var G = Graphics.FromImage(B);

            G.SmoothingMode = SmoothingMode.AntiAlias;

            if (Image == null)
            {
                iTalkTB.Width = Width - 18;
            }
            else
            {
                iTalkTB.Width = Width - 45;
            }

            iTalkTB.TextAlign = TextAlignment;
            iTalkTB.UseSystemPasswordChar = UseSystemPasswordChar;

            G.Clear(Color.Transparent);
            G.FillPath(B1, Shape); // Draw background
            G.DrawPath(P1, Shape); // Draw border


            if (Image != null)
            {
                G.DrawImage(_Image, 5, 8, 24, 24);
                // 24x24 is the perfect size of the image
            }

            e.Graphics.DrawImage((Image) B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

        #region Variables

        public TextBox iTalkTB = new TextBox();
        private GraphicsPath Shape;
        private int _maxchars = 32767;
        private bool _ReadOnly;
        private bool _Multiline;
        private Image _Image;
        private HorizontalAlignment ALNType;
        private bool isPasswordMasked;
        private readonly Pen P1;
        private readonly SolidBrush B1;

        #endregion

        #region Properties

        public HorizontalAlignment TextAlignment
        {
            get { return ALNType; }
            set
            {
                ALNType = value;
                Invalidate();
            }
        }

        public int MaxLength
        {
            get { return _maxchars; }
            set
            {
                _maxchars = value;
                iTalkTB.MaxLength = MaxLength;
                Invalidate();
            }
        }

        public bool UseSystemPasswordChar
        {
            get { return isPasswordMasked; }
            set
            {
                iTalkTB.UseSystemPasswordChar = UseSystemPasswordChar;
                isPasswordMasked = value;
                Invalidate();
            }
        }

        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (iTalkTB != null)
                {
                    iTalkTB.ReadOnly = value;
                }
            }
        }

        public bool Multiline
        {
            get { return _Multiline; }
            set
            {
                _Multiline = value;
                if (iTalkTB != null)
                {
                    iTalkTB.Multiline = value;

                    if (value)
                    {
                        iTalkTB.Height = Height - 23;
                    }
                    else
                    {
                        Height = iTalkTB.Height + 23;
                    }
                }
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

                if (Image == null)
                {
                    iTalkTB.Location = new Point(8, 10);
                }
                else
                {
                    iTalkTB.Location = new Point(35, 11);
                }
                Invalidate();
            }
        }

        protected Size ImageSize { get; private set; }

        #endregion

        #region EventArgs

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            iTalkTB.Text = Text;
            Invalidate();
        }

        private void OnBaseTextChanged(object s, EventArgs e)
        {
            Text = iTalkTB.Text;
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            iTalkTB.ForeColor = ForeColor;
            Invalidate();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            iTalkTB.Font = Font;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        private void _OnKeyDown(object Obj, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                iTalkTB.SelectAll();
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                iTalkTB.Copy();
                e.SuppressKeyPress = true;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (_Multiline)
            {
                iTalkTB.Height = Height - 23;
            }
            else
            {
                Height = iTalkTB.Height + 23;
            }

            Shape = new GraphicsPath();
            var _with1 = Shape;
            _with1.AddArc(0, 0, 10, 10, 180, 90);
            _with1.AddArc(Width - 11, 0, 10, 10, -90, 90);
            _with1.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            _with1.AddArc(0, Height - 11, 10, 10, 90, 90);
            _with1.CloseAllFigures();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            iTalkTB.Focus();
        }

        #endregion
    }

    #endregion

    #region Small TextBox

    [DefaultEvent("TextChanged")]
    public class iTalk_TextBox_Small : Control
    {
        public iTalk_TextBox_Small()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);

            AddTextBox();
            Controls.Add(iTalkTB);

            P1 = new Pen(Color.FromArgb(180, 180, 180)); // P1 = Border color
            B1 = new SolidBrush(Color.White); // B1 = Rect Background color
            BackColor = Color.Transparent;
            ForeColor = Color.DimGray;

            Text = null;
            Font = new Font("Tahoma", 11);
            Size = new Size(135, 33);
            DoubleBuffered = true;
        }

        public void AddTextBox()
        {
            var _TB = iTalkTB;
            _TB.Size = new Size(Width - 10, 33);
            _TB.Location = new Point(7, 5);
            _TB.Text = string.Empty;
            _TB.BorderStyle = BorderStyle.None;
            _TB.TextAlign = HorizontalAlignment.Left;
            _TB.Font = new Font("Tahoma", 11);
            _TB.UseSystemPasswordChar = UseSystemPasswordChar;
            _TB.Multiline = false;
            iTalkTB.KeyDown += _OnKeyDown;
            iTalkTB.TextChanged += OnBaseTextChanged;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var B = new Bitmap(Width, Height);
            var G = Graphics.FromImage(B);

            G.SmoothingMode = SmoothingMode.AntiAlias;

            var _TB = iTalkTB;
            _TB.Width = Width - 10;
            _TB.TextAlign = TextAlignment;
            _TB.UseSystemPasswordChar = UseSystemPasswordChar;

            G.Clear(Color.Transparent);
            G.FillPath(B1, Shape); // Draw background
            G.DrawPath(P1, Shape); // Draw border

            e.Graphics.DrawImage((Image) B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

        #region Variables

        public TextBox iTalkTB = new TextBox();
        private GraphicsPath Shape;
        private int _maxchars = 32767;
        private bool _ReadOnly;
        private bool _Multiline;
        private HorizontalAlignment ALNType;
        private bool isPasswordMasked;
        private readonly Pen P1;
        private readonly SolidBrush B1;

        #endregion

        #region Properties

        public HorizontalAlignment TextAlignment
        {
            get { return ALNType; }
            set
            {
                ALNType = value;
                Invalidate();
            }
        }

        public int MaxLength
        {
            get { return _maxchars; }
            set
            {
                _maxchars = value;
                iTalkTB.MaxLength = MaxLength;
                Invalidate();
            }
        }

        public bool UseSystemPasswordChar
        {
            get { return isPasswordMasked; }
            set
            {
                iTalkTB.UseSystemPasswordChar = UseSystemPasswordChar;
                isPasswordMasked = value;
                Invalidate();
            }
        }

        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (iTalkTB != null)
                {
                    iTalkTB.ReadOnly = value;
                }
            }
        }

        public bool Multiline
        {
            get { return _Multiline; }
            set
            {
                _Multiline = value;
                if (iTalkTB != null)
                {
                    iTalkTB.Multiline = value;

                    if (value)
                    {
                        iTalkTB.Height = Height - 10;
                    }
                    else
                    {
                        Height = iTalkTB.Height + 10;
                    }
                }
            }
        }

        #endregion

        #region EventArgs

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            iTalkTB.Text = Text;
            Invalidate();
        }

        private void OnBaseTextChanged(object s, EventArgs e)
        {
            Text = iTalkTB.Text;
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            iTalkTB.ForeColor = ForeColor;
            Invalidate();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            iTalkTB.Font = Font;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        private void _OnKeyDown(object Obj, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                iTalkTB.SelectAll();
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                iTalkTB.Copy();
                e.SuppressKeyPress = true;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (_Multiline)
            {
                iTalkTB.Height = Height - 10;
            }
            else
            {
                Height = iTalkTB.Height + 10;
            }

            Shape = new GraphicsPath();
            var _with1 = Shape;
            _with1.AddArc(0, 0, 10, 10, 180, 90);
            _with1.AddArc(Width - 11, 0, 10, 10, -90, 90);
            _with1.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            _with1.AddArc(0, Height - 11, 10, 10, 90, 90);
            _with1.CloseAllFigures();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            iTalkTB.Focus();
        }

        #endregion
    }

    #endregion

    #region RichTextBox

    [DefaultEvent("TextChanged")]
    public class iTalk_RichTextBox : Control
    {
        public iTalk_RichTextBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);

            AddRichTextBox();
            Controls.Add(iTalkRTB);
            BackColor = Color.Transparent;
            ForeColor = Color.DimGray;

            Text = null;
            Font = new Font("Tahoma", 10);
            Size = new Size(150, 100);
            WordWrap = true;
            AutoWordSelection = false;
            DoubleBuffered = true;

            TextChanged += _TextChanged;
        }

        public void AddRichTextBox()
        {
            var _RTB = iTalkRTB;
            _RTB.BackColor = Color.White;
            _RTB.Size = new Size(Width - 10, 100);
            _RTB.Location = new Point(7, 5);
            _RTB.Text = string.Empty;
            _RTB.BorderStyle = BorderStyle.None;
            _RTB.Font = new Font("Tahoma", 10);
            _RTB.Multiline = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var B = new Bitmap(Width, Height);
            var G = Graphics.FromImage(B);
            G.SmoothingMode = SmoothingMode.AntiAlias;
            G.Clear(Color.Transparent);
            G.FillPath(Brushes.White, Shape);
            G.DrawPath(new Pen(Color.FromArgb(180, 180, 180)), Shape);
            G.Dispose();
            e.Graphics.DrawImage((Image) B.Clone(), 0, 0);
            B.Dispose();
        }

        #region Variables

        public RichTextBox iTalkRTB = new RichTextBox();
        private bool _ReadOnly;
        private bool _WordWrap;
        private bool _AutoWordSelection;
        private GraphicsPath Shape;

        #endregion

        #region Properties

        public override string Text
        {
            get { return iTalkRTB.Text; }
            set
            {
                iTalkRTB.Text = value;
                Invalidate();
            }
        }

        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (iTalkRTB != null)
                {
                    iTalkRTB.ReadOnly = value;
                }
            }
        }

        public bool WordWrap
        {
            get { return _WordWrap; }
            set
            {
                _WordWrap = value;
                if (iTalkRTB != null)
                {
                    iTalkRTB.WordWrap = value;
                }
            }
        }

        public bool AutoWordSelection
        {
            get { return _AutoWordSelection; }
            set
            {
                _AutoWordSelection = value;
                if (iTalkRTB != null)
                {
                    iTalkRTB.AutoWordSelection = value;
                }
            }
        }

        #endregion

        #region EventArgs

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            iTalkRTB.ForeColor = ForeColor;
            Invalidate();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            iTalkRTB.Font = Font;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            iTalkRTB.Size = new Size(Width - 13, Height - 11);
        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Shape = new GraphicsPath();
            var _Shape = Shape;
            _Shape.AddArc(0, 0, 10, 10, 180, 90);
            _Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
            _Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            _Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
            _Shape.CloseAllFigures();
        }

        public void _TextChanged(object s, EventArgs e)
        {
            iTalkRTB.Text = Text;
        }

        #endregion
    }

    #endregion

    #region  NumericUpDown

    public class iTalk_NumericUpDown : Control
    {
        #region  Enums

        public enum _TextAlignment
        {
            Near,
            Center
        }

        #endregion

        public iTalk_NumericUpDown()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);

            P1 = new Pen(Color.FromArgb(180, 180, 180)); // P1 = Border color
            B1 = new SolidBrush(Color.White); // B1 = Rect Background color
            BackColor = Color.Transparent;
            ForeColor = Color.DimGray;

            _Minimum = 0;
            _Maximum = 100;

            Font = new Font("Tahoma", 11);
            Size = new Size(70, 28);
            MinimumSize = new Size(62, 28);
            DoubleBuffered = true;
        }

        public void Increment(int Value)
        {
            _Value += Value;
            Invalidate();
        }

        public void Decrement(int Value)
        {
            _Value -= Value;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var B = new Bitmap(Width, Height);
            var G = Graphics.FromImage(B);

            G.SmoothingMode = SmoothingMode.AntiAlias;

            G.Clear(Color.Transparent); // Set control background color
            G.FillPath(B1, Shape); // Draw background
            G.DrawPath(P1, Shape); // Draw border

            var ColorGradient = new LinearGradientBrush(new Rectangle(Width - 23, 4, 19, 19),
                Color.FromArgb(241, 241, 241), Color.FromArgb(241, 241, 241), 90.0F);
            G.FillRectangle(ColorGradient, ColorGradient.Rectangle); // Fills the body of the rectangle

            G.DrawRectangle(new Pen(Color.FromArgb(252, 252, 252)), new Rectangle(Width - 22, 5, 17, 17));
            G.DrawRectangle(new Pen(Color.FromArgb(180, 180, 180)), new Rectangle(Width - 23, 4, 19, 19));

            G.DrawLine(new Pen(Color.FromArgb(250, 252, 250)), new Point(Width - 22, Height - 16),
                new Point(Width - 5, Height - 16));
            G.DrawLine(new Pen(Color.FromArgb(180, 180, 180)), new Point(Width - 22, Height - 15),
                new Point(Width - 5, Height - 15));
            G.DrawLine(new Pen(Color.FromArgb(250, 250, 250)), new Point(Width - 22, Height - 14),
                new Point(Width - 5, Height - 14));

            G.DrawString("+", new Font("Tahoma", 8), Brushes.Gray, Width - 19, Height - 26);
            G.DrawString("-", new Font("Tahoma", 12), Brushes.Gray, Width - 19, Height - 20);

            switch (MyStringAlignment)
            {
                case _TextAlignment.Near:
                    G.DrawString(Convert.ToString(Value), Font, new SolidBrush(ForeColor),
                        new Rectangle(5, 0, Width - 1, Height - 1),
                        new StringFormat {Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center});
                    break;
                case _TextAlignment.Center:
                    G.DrawString(Convert.ToString(Value), Font, new SolidBrush(ForeColor),
                        new Rectangle(0, 0, Width - 1, Height - 1),
                        new StringFormat {Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center});
                    break;
            }

            e.Graphics.DrawImage((Image) B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

        #region  Variables

        private GraphicsPath Shape;
        private readonly Pen P1;
        private readonly SolidBrush B1;

        private long _Value;
        private long _Minimum;
        private long _Maximum;
        private int Xval;
        private int Yval;
        private bool KeyboardNum;
        private _TextAlignment MyStringAlignment;

        #endregion

        #region  Properties

        public long Value
        {
            get { return _Value; }
            set
            {
                if (value <= _Maximum & value >= _Minimum)
                {
                    _Value = value;
                }
                Invalidate();
            }
        }

        public long Minimum
        {
            get { return _Minimum; }
            set
            {
                if (value < _Maximum)
                {
                    _Minimum = value;
                }
                if (_Value < _Minimum)
                {
                    _Value = Minimum;
                }
                Invalidate();
            }
        }

        public long Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value > _Minimum)
                {
                    _Maximum = value;
                }
                if (_Value > _Maximum)
                {
                    _Value = _Maximum;
                }
                Invalidate();
            }
        }

        public _TextAlignment TextAlignment
        {
            get { return MyStringAlignment; }
            set
            {
                MyStringAlignment = value;
                Invalidate();
            }
        }

        #endregion

        #region  EventArgs

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 28;
            Shape = new GraphicsPath();
            Shape.AddArc(0, 0, 10, 10, 180, 90);
            Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
            Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
            Shape.CloseAllFigures();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Xval = e.Location.X;
            Yval = e.Location.Y;
            Invalidate();

            if (e.X < Width - 24)
            {
                Cursor = Cursors.IBeam;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            OnMouseClick(e);
            if (Xval > Width - 23 && Xval < Width - 3)
            {
                if (Yval < 15)
                {
                    if ((Value + 1) <= _Maximum)
                    {
                        _Value++;
                    }
                }
                else
                {
                    if ((Value - 1) >= _Minimum)
                    {
                        _Value--;
                    }
                }
            }
            else
            {
                KeyboardNum = !KeyboardNum;
                Focus();
            }
            Invalidate();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            try
            {
                if (KeyboardNum)
                {
                    _Value = long.Parse((_Value) + e.KeyChar.ToString());
                }
                if (_Value > _Maximum)
                {
                    _Value = _Maximum;
                }
            }
            catch (Exception)
            {
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.Back)
            {
                var TemporaryValue = _Value.ToString();
                TemporaryValue = TemporaryValue.Remove(Convert.ToInt32(TemporaryValue.Length - 1));
                if (TemporaryValue.Length == 0)
                {
                    TemporaryValue = "0";
                }
                _Value = Convert.ToInt32(TemporaryValue);
            }
            Invalidate();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (e.Delta > 0)
            {
                if ((Value + 1) <= _Maximum)
                {
                    _Value++;
                }
                Invalidate();
            }
            else
            {
                if ((Value - 1) >= _Minimum)
                {
                    _Value--;
                }
                Invalidate();
            }
        }

        #endregion
    }

    #endregion

    #region Left Chat Bubble

    public class iTalk_ChatBubble_L : Control
    {
        public iTalk_ChatBubble_L()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            Size = new Size(152, 38);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(52, 52, 52);
            Font = new Font("Segoe UI", 10);
        }

        protected override void OnResize(EventArgs e)
        {
            Shape = new GraphicsPath();

            var _Shape = Shape;
            _Shape.AddArc(9, 0, 10, 10, 180, 90);
            _Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
            _Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            _Shape.AddArc(9, Height - 11, 10, 10, 90, 90);
            _Shape.CloseAllFigures();

            Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var B = new Bitmap(Width, Height);
            var G = Graphics.FromImage(B);
            var _G = G;
            _G.SmoothingMode = SmoothingMode.HighQuality;
            _G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _G.Clear(BackColor);

            // Fill the body of the bubble with the specified color
            _G.FillPath(new SolidBrush(_BubbleColor), Shape);
            // Draw the string specified in 'Text' property
            _G.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(15, 4, Width - 17, Height - 5));

            // Draw a polygon on the right side of the bubble
            if (_DrawBubbleArrow)
            {
                Point[] p =
                {
                    new Point(9, Height - 19),
                    new Point(0, Height - 25),
                    new Point(9, Height - 30)
                };
                _G.FillPolygon(new SolidBrush(_BubbleColor), p);
                _G.DrawPolygon(new Pen(new SolidBrush(_BubbleColor)), p);
            }
            G.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

        #region Variables

        private GraphicsPath Shape;
        private Color _TextColor = Color.FromArgb(52, 52, 52);
        private Color _BubbleColor = Color.FromArgb(217, 217, 217);
        private bool _DrawBubbleArrow = true;

        #endregion

        #region Properties

        public override Color ForeColor
        {
            get { return _TextColor; }
            set
            {
                _TextColor = value;
                Invalidate();
            }
        }

        public Color BubbleColor
        {
            get { return _BubbleColor; }
            set
            {
                _BubbleColor = value;
                Invalidate();
            }
        }

        public bool DrawBubbleArrow
        {
            get { return _DrawBubbleArrow; }
            set
            {
                _DrawBubbleArrow = value;
                Invalidate();
            }
        }

        #endregion
    }

    #endregion

    #region Right Chat Bubble

    public class iTalk_ChatBubble_R : Control
    {
        public iTalk_ChatBubble_R()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            Size = new Size(152, 38);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(52, 52, 52);
            Font = new Font("Segoe UI", 10);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Shape = new GraphicsPath();

            var _with1 = Shape;
            _with1.AddArc(0, 0, 10, 10, 180, 90);
            _with1.AddArc(Width - 18, 0, 10, 10, -90, 90);
            _with1.AddArc(Width - 18, Height - 11, 10, 10, 0, 90);
            _with1.AddArc(0, Height - 11, 10, 10, 90, 90);
            _with1.CloseAllFigures();

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var B = new Bitmap(Width, Height);
            var G = Graphics.FromImage(B);

            var _G = G;
            _G.SmoothingMode = SmoothingMode.HighQuality;
            _G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _G.Clear(BackColor);

            // Fill the body of the bubble with the specified color
            _G.FillPath(new SolidBrush(_BubbleColor), Shape);
            // Draw the string specified in 'Text' property
            _G.DrawString(Text, Font, new SolidBrush(ForeColor), (new Rectangle(6, 4, Width - 15, Height)));

            // Draw a polygon on the right side of the bubble
            if (_DrawBubbleArrow)
            {
                Point[] p =
                {
                    new Point(Width - 8, Height - 19),
                    new Point(Width, Height - 25),
                    new Point(Width - 8, Height - 30)
                };
                _G.FillPolygon(new SolidBrush(_BubbleColor), p);
                _G.DrawPolygon(new Pen(new SolidBrush(_BubbleColor)), p);
            }

            G.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

        #region Variables

        private GraphicsPath Shape;
        private Color _TextColor = Color.FromArgb(52, 52, 52);
        private Color _BubbleColor = Color.FromArgb(192, 206, 215);
        private bool _DrawBubbleArrow = true;

        #endregion

        #region Properties

        public override Color ForeColor
        {
            get { return _TextColor; }
            set
            {
                _TextColor = value;
                Invalidate();
            }
        }

        public Color BubbleColor
        {
            get { return _BubbleColor; }
            set
            {
                _BubbleColor = value;
                Invalidate();
            }
        }

        public bool DrawBubbleArrow
        {
            get { return _DrawBubbleArrow; }
            set
            {
                _DrawBubbleArrow = value;
                Invalidate();
            }
        }

        #endregion
    }

    #endregion

    #region Separator

    public class iTalk_Separator : Control
    {
        public iTalk_Separator()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            Size = new Size(120, 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(184, 183, 188)), 0, 5, Width, 5);
        }
    }

    #endregion

    #region Panel

    public class iTalk_Panel : ContainerControl
    {
        private GraphicsPath Shape;

        public iTalk_Panel()
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
            var _with1 = Shape;
            _with1.AddArc(0, 0, 10, 10, 180, 90);
            _with1.AddArc(Width - 11, 0, 10, 10, -90, 90);
            _with1.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            _with1.AddArc(0, Height - 11, 10, 10, 90, 90);
            _with1.CloseAllFigures();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var B = new Bitmap(Width, Height);
            var G = Graphics.FromImage(B);

            G.SmoothingMode = SmoothingMode.HighQuality;

            G.Clear(Color.Transparent);
            G.FillPath(Brushes.White, Shape); // Draw RTB background
            G.DrawPath(new Pen(Color.FromArgb(180, 180, 180)), Shape); // Draw border

            G.Dispose();
            e.Graphics.DrawImage((Image) B.Clone(), 0, 0);
            B.Dispose();
        }
    }

    #endregion

    #region GroupBox

    public class iTalk_GroupBox : ContainerControl
    {
        public iTalk_GroupBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Size = new Size(212, 104);
            MinimumSize = new Size(136, 50);
            Padding = new Padding(5, 28, 5, 5);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var B = new Bitmap(Width, Height);
            var G = Graphics.FromImage(B);
            var TitleBox = new Rectangle(51, 3, Width - 103, 18);
            var box = new Rectangle(0, 0, Width - 1, Height - 10);

            G.Clear(Color.Transparent);
            G.SmoothingMode = SmoothingMode.HighQuality;

            // Draw the body of the GroupBox
            G.FillPath(Brushes.White, RoundRectangle.RoundRect(new Rectangle(1, 12, Width - 3, box.Height - 1), 8));
            // Draw the border of the GroupBox
            G.DrawPath(new Pen(Color.FromArgb(159, 159, 161)),
                RoundRectangle.RoundRect(new Rectangle(1, 12, Width - 3, Height - 13), 8));

            // Draw the background of the title box
            G.FillPath(Brushes.White, RoundRectangle.RoundRect(TitleBox, 1));
            // Draw the border of the title box
            G.DrawPath(new Pen(Color.FromArgb(182, 180, 186)), RoundRectangle.RoundRect(TitleBox, 4));
            // Draw the specified string from 'Text' property inside the title box
            G.DrawString(Text, new Font("Tahoma", 9, FontStyle.Regular), new SolidBrush(Color.FromArgb(53, 53, 53)),
                TitleBox, new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });

            e.Graphics.DrawImage((Image) B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

    #endregion

    #region CheckBox

    [DefaultEvent("CheckedChanged")]
    public class iTalk_CheckBox : Control
    {
        public iTalk_CheckBox()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10);
            Size = new Size(120, 26);
        }

        #region Properties

        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
                Invalidate();
            }
        }

        #endregion

        protected override void OnClick(EventArgs e)
        {
            _Checked = !_Checked;
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }
            Invalidate();
            base.OnClick(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        protected override void OnResize(EventArgs e)
        {
            if (Width > 0 && Height > 0)
            {
                Shape = new GraphicsPath();

                R1 = new Rectangle(17, 0, Width, Height + 1);
                R2 = new Rectangle(0, 0, Width, Height);
                GB = new LinearGradientBrush(new Rectangle(0, 0, 25, 25), Color.FromArgb(250, 250, 250),
                    Color.FromArgb(240, 240, 240), 90);

                var _Shape = Shape;
                _Shape.AddArc(0, 0, 7, 7, 180, 90);
                _Shape.AddArc(7, 0, 7, 7, -90, 90);
                _Shape.AddArc(7, 7, 7, 7, 0, 90);
                _Shape.AddArc(0, 7, 7, 7, 90, 90);
                _Shape.CloseAllFigures();
                Height = 15;
            }

            Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var _G = e.Graphics;
            _G.Clear(Color.FromArgb(246, 246, 246));
            _G.SmoothingMode = SmoothingMode.AntiAlias;
            // Fill the body of the CheckBox
            _G.FillPath(GB, Shape);
            // Draw the border
            _G.DrawPath(new Pen(Color.FromArgb(160, 160, 160)), Shape);
            // Draw the string
            _G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(142, 142, 142)), R1,
                new StringFormat {LineAlignment = StringAlignment.Center});

            if (Checked)
            {
                _G.DrawString("ü", new Font("Wingdings", 14), new SolidBrush(Color.FromArgb(142, 142, 142)),
                    new Rectangle(-2, 1, Width, Height), new StringFormat {LineAlignment = StringAlignment.Center});
            }
            e.Dispose();
        }

        #region Variables

        private GraphicsPath Shape;
        private LinearGradientBrush GB;
        private Rectangle R1;
        private Rectangle R2;
        private bool _Checked;
        public event CheckedChangedEventHandler CheckedChanged;

        public delegate void CheckedChangedEventHandler(object sender);

        #endregion
    }

    #endregion

    #region RadioButton

    [DefaultEvent("CheckedChanged")]
    public class iTalk_RadioButton : Control
    {
        #region Enums

        public enum MouseState : byte
        {
            None = 0,
            Over = 1,
            Down = 2,
            Block = 3
        }

        #endregion

        public iTalk_RadioButton()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
            Font = new Font("Segoe UI", 10);
            Width = 132;
        }

        #region Properties

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

        #endregion

        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
                return;

            foreach (Control _Control in Parent.Controls)
            {
                if (!ReferenceEquals(_Control, this) && _Control is iTalk_RadioButton)
                {
                    ((iTalk_RadioButton) _Control).Checked = false;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var _G = e.Graphics;

            _G.Clear(Color.FromArgb(246, 246, 246));
            _G.SmoothingMode = SmoothingMode.AntiAlias;

            var LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(14, 14)),
                Color.FromArgb(250, 250, 250), Color.FromArgb(240, 240, 240), 90);
            _G.FillEllipse(LGB, new Rectangle(new Point(0, 0), new Size(14, 14)));

            var GP = new GraphicsPath();
            GP.AddEllipse(new Rectangle(0, 0, 14, 14));
            _G.SetClip(GP);
            _G.ResetClip();

            // Draw ellipse border
            _G.DrawEllipse(new Pen(Color.FromArgb(160, 160, 160)), new Rectangle(new Point(0, 0), new Size(14, 14)));

            // Draw an ellipse inside the body
            if (_Checked)
            {
                var EllipseColor = new SolidBrush(Color.FromArgb(142, 142, 142));
                _G.FillEllipse(EllipseColor, new Rectangle(new Point(4, 4), new Size(6, 6)));
            }
            // Draw the string specified in 'Text' property
            _G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(142, 142, 142)), 16, 8,
                new StringFormat {LineAlignment = StringAlignment.Center});

            e.Dispose();
        }

        #region Variables

        private bool _Checked;
        public event CheckedChangedEventHandler CheckedChanged;

        public delegate void CheckedChangedEventHandler(object sender);

        #endregion

        #region EventArgs

        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 15;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!_Checked)
                Checked = true;
            base.OnMouseDown(e);
        }

        #endregion
    }

    #endregion

    #region Notification Number

    public class iTalk_NotificationNumber : Control
    {
        public iTalk_NotificationNumber()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);

            Text = null;
            DoubleBuffered = true;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 20;
            Width = 20;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var _G = e.Graphics;
            var myString = _Value.ToString();
            _G.Clear(BackColor);
            _G.SmoothingMode = SmoothingMode.AntiAlias;
            var LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(18, 20)),
                Color.FromArgb(197, 69, 68), Color.FromArgb(176, 52, 52), 90f);

            // Fills the body with LGB gradient
            _G.FillEllipse(LGB, new Rectangle(new Point(0, 0), new Size(18, 18)));
            // Draw border
            _G.DrawEllipse(new Pen(Color.FromArgb(205, 70, 66)), new Rectangle(new Point(0, 0), new Size(18, 18)));
            _G.DrawString(myString, new Font("Segoe UI", 8, FontStyle.Bold),
                new SolidBrush(Color.FromArgb(255, 255, 253)), new Rectangle(0, 0, Width - 2, Height), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            e.Dispose();
        }

        #region Variables

        private int _Value;
        private int _Maximum = 99;

        #endregion

        #region Properties

        public int Value
        {
            get
            {
                if (_Value == 0)
                {
                    return 0;
                }
                return _Value;
            }
            set
            {
                if (value > _Maximum)
                {
                    value = _Maximum;
                }
                _Value = value;
                Invalidate();
            }
        }

        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < _Value)
                {
                    _Value = value;
                }
                _Maximum = value;
                Invalidate();
            }
        }

        #endregion
    }

    #endregion

    #region ListView

    public class iTalk_Listview : ListView
    {
        public iTalk_Listview()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            HeaderStyle = ColumnHeaderStyle.Nonclickable;
            BorderStyle = BorderStyle.None;
        }

        [DllImport("uxtheme", CharSet = CharSet.Unicode)]
        public static extern int SetWindowTheme(IntPtr hWnd, string textSubAppName, string textSubIdList);

        protected override void OnHandleCreated(EventArgs e)
        {
            SetWindowTheme(Handle, "explorer", null);
            base.OnHandleCreated(e);
        }
    }

    #endregion

    #region ComboBox

    public class iTalk_ComboBox : ComboBox
    {
        public iTalk_ComboBox()
        {
            SetStyle((ControlStyles) 139286, true);
            SetStyle(ControlStyles.Selectable, false);

            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;

            BackColor = Color.FromArgb(246, 246, 246);
            ForeColor = Color.FromArgb(142, 142, 142);
            Size = new Size(135, 26);
            ItemHeight = 20;
            DropDownHeight = 100;
            Font = new Font("Segoe UI", 10, FontStyle.Regular);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var LGB = default(LinearGradientBrush);
            var GP = default(GraphicsPath);

            e.Graphics.Clear(BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Create a curvy border
            GP = RoundRectangle.RoundRect(0, 0, Width - 1, Height - 1, 5);
            // Fills the body of the rectangle with a gradient
            LGB = new LinearGradientBrush(ClientRectangle, Color.FromArgb(241, 241, 241), Color.FromArgb(241, 241, 241),
                90f);

            e.Graphics.SetClip(GP);
            e.Graphics.FillRectangle(LGB, ClientRectangle);
            e.Graphics.ResetClip();

            // Draw rectangle border
            e.Graphics.DrawPath(new Pen(Color.FromArgb(204, 204, 204)), GP);
            // Draw string
            e.Graphics.DrawString(Text, Font, new SolidBrush(Color.FromArgb(142, 142, 142)),
                new Rectangle(3, 0, Width - 20, Height), new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near
                });

            // Draw the dropdown arrow
            e.Graphics.DrawLine(new Pen(Color.FromArgb(160, 160, 160), 2), new Point(Width - 18, 10),
                new Point(Width - 14, 14));
            e.Graphics.DrawLine(new Pen(Color.FromArgb(160, 160, 160), 2), new Point(Width - 14, 14),
                new Point(Width - 10, 10));
            e.Graphics.DrawLine(new Pen(Color.FromArgb(160, 160, 160)), new Point(Width - 14, 15),
                new Point(Width - 14, 14));

            GP.Dispose();
            LGB.Dispose();
        }

        #region Variables

        private int _StartIndex;
        private Color _HoverSelectionColor = Color.FromArgb(241, 241, 241);

        #endregion

        #region Custom Properties

        public int StartIndex
        {
            get { return _StartIndex; }
            set
            {
                _StartIndex = value;
                try
                {
                    SelectedIndex = value;
                }
                catch
                {
                }
                Invalidate();
            }
        }

        public Color HoverSelectionColor
        {
            get { return _HoverSelectionColor; }
            set
            {
                _HoverSelectionColor = value;
                Invalidate();
            }
        }

        #endregion

        #region EventArgs

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(_HoverSelectionColor), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }

            if (!(e.Index == -1))
            {
                e.Graphics.DrawString(GetItemText(Items[e.Index]), e.Font, Brushes.DimGray, e.Bounds);
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            SuspendLayout();
            Update();
            ResumeLayout();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        #endregion
    }

    #endregion

    #region Circular ProgressBar

    public class iTalk_ProgressBar : Control
    {
        #region Enums

        public enum _ProgressShape
        {
            Round,
            Flat
        }

        #endregion

        public iTalk_ProgressBar()
        {
            Size = new Size(130, 130);
            Font = new Font("Segoe UI", 15);
            MinimumSize = new Size(100, 100);
            DoubleBuffered = true;
        }

        private void SetStandardSize()
        {
            var _Size = Math.Max(Width, Height);
            Size = new Size(_Size, _Size);
        }

        public void Increment(int Val)
        {
            _Value += Val;
            Invalidate();
        }

        public void Decrement(int Val)
        {
            _Value -= Val;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var bitmap = new Bitmap(Width, Height))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.Clear(BackColor);
                    using (
                        var brush = new LinearGradientBrush(ClientRectangle, _ProgressColor1, _ProgressColor2,
                            LinearGradientMode.ForwardDiagonal))
                    {
                        using (var pen = new Pen(brush, 14f))
                        {
                            switch (ProgressShapeVal)
                            {
                                case _ProgressShape.Round:
                                    pen.StartCap = LineCap.Round;
                                    pen.EndCap = LineCap.Round;
                                    break;

                                case _ProgressShape.Flat:
                                    pen.StartCap = LineCap.Flat;
                                    pen.EndCap = LineCap.Flat;
                                    break;
                            }
                            graphics.DrawArc(pen, 0x12, 0x12, (Width - 0x23) - 2, (Height - 0x23) - 2, -90,
                                (int) Math.Round((360.0/_Maximum)*_Value));
                        }
                    }
                    using (
                        var brush2 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(0x34, 0x34, 0x34),
                            Color.FromArgb(0x34, 0x34, 0x34), LinearGradientMode.Vertical))
                    {
                        graphics.FillEllipse(brush2, 0x18, 0x18, (Width - 0x30) - 1, (Height - 0x30) - 1);
                    }
                    var MS = graphics.MeasureString(Convert.ToString(Convert.ToInt32((100/_Maximum)*_Value)), Font);
                    graphics.DrawString(Convert.ToString(Convert.ToInt32((100/_Maximum)*_Value)), Font, Brushes.White,
                        Convert.ToInt32(Width/2 - MS.Width/2), Convert.ToInt32(Height/2 - MS.Height/2));
                    e.Graphics.DrawImage(bitmap, 0, 0);
                    graphics.Dispose();
                    bitmap.Dispose();
                }
            }
        }

        #region Variables

        private long _Value;
        private long _Maximum = 100;
        private Color _ProgressColor1 = Color.FromArgb(92, 92, 92);
        private Color _ProgressColor2 = Color.FromArgb(92, 92, 92);
        private _ProgressShape ProgressShapeVal;

        #endregion

        #region Custom Properties

        public long Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    value = _Maximum;
                _Value = value;
                Invalidate();
            }
        }

        public long Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                    value = 1;
                _Maximum = value;
                Invalidate();
            }
        }

        public Color ProgressColor1
        {
            get { return _ProgressColor1; }
            set
            {
                _ProgressColor1 = value;
                Invalidate();
            }
        }

        public Color ProgressColor2
        {
            get { return _ProgressColor2; }
            set
            {
                _ProgressColor2 = value;
                Invalidate();
            }
        }

        public _ProgressShape ProgressShape
        {
            get { return ProgressShapeVal; }
            set
            {
                ProgressShapeVal = value;
                Invalidate();
            }
        }

        #endregion

        #region EventArgs

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetStandardSize();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetStandardSize();
        }

        protected override void OnPaintBackground(PaintEventArgs p)
        {
            base.OnPaintBackground(p);
        }

        #endregion
    }

    #endregion

    #region Progress Indicator

    public class iTalk_ProgressIndicator : Control
    {
        private PointF _StartingFloatPoint;
        private double Rise;
        private double Run;

        public iTalk_ProgressIndicator()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer, true);

            Size = new Size(80, 80);
            Text = string.Empty;
            MinimumSize = new Size(80, 80);
            SetPoints();
            AnimationSpeed.Interval = 100;
        }

        private PointF EndPoint
        {
            get
            {
                var LocationX = Convert.ToSingle(_StartingFloatPoint.Y + Rise);
                var LocationY = Convert.ToSingle(_StartingFloatPoint.X + Run);

                return new PointF(LocationY, LocationX);
            }
        }

        private void SetStandardSize()
        {
            var _Size = Math.Max(Width, Height);
            Size = new Size(_Size, _Size);
        }

        private void SetPoints()
        {
            var stack = new Stack<PointF>();
            var startingFloatPoint = new PointF(Width/2f, Height/2f);
            for (var i = 0f; i < 360f; i += 45f)
            {
                SetValue(startingFloatPoint, (int) Math.Round((Width/2.0) - 15.0), i);
                var endPoint = EndPoint;
                endPoint = new PointF(endPoint.X - 7.5f, endPoint.Y - 7.5f);
                stack.Push(endPoint);
            }
            FloatPoint = stack.ToArray();
        }

        private void UpdateGraphics()
        {
            if ((Width > 0) && (Height > 0))
            {
                var size2 = new Size(Width + 1, Height + 1);
                GraphicsContext.MaximumBuffer = size2;
                BuffGraphics = GraphicsContext.Allocate(CreateGraphics(), ClientRectangle);
                BuffGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            BuffGraphics.Graphics.Clear(BackColor);
            var num2 = FloatPoint.Length - 1;
            for (var i = 0; i <= num2; i++)
            {
                if (IndicatorIndex == i)
                {
                    BuffGraphics.Graphics.FillEllipse(AnimationColor, FloatPoint[i].X, FloatPoint[i].Y, 15f, 15f);
                }
                else
                {
                    BuffGraphics.Graphics.FillEllipse(BaseColor, FloatPoint[i].X, FloatPoint[i].Y, 15f, 15f);
                }
            }
            BuffGraphics.Render(e.Graphics);
        }

        private X AssignValues<X>(ref X Run, X Length)
        {
            Run = Length;
            return Length;
        }

        private void SetValue(PointF StartingFloatPoint, int Length, double Angle)
        {
            var CircleRadian = Math.PI*Angle/180.0;

            _StartingFloatPoint = StartingFloatPoint;
            Rise = AssignValues(ref Run, Length);
            Rise = Math.Sin(CircleRadian)*Rise;
            Run = Math.Cos(CircleRadian)*Run;
        }

        #region Variables

        private readonly SolidBrush BaseColor = new SolidBrush(Color.DarkGray);
        private readonly SolidBrush AnimationColor = new SolidBrush(Color.DimGray);

        private readonly Timer AnimationSpeed = new Timer();
        private PointF[] FloatPoint;
        private BufferedGraphics BuffGraphics;
        private int IndicatorIndex;
        private readonly BufferedGraphicsContext GraphicsContext = BufferedGraphicsManager.Current;

        #endregion

        #region Custom Properties

        public Color P_BaseColor
        {
            get { return BaseColor.Color; }
            set { BaseColor.Color = value; }
        }

        public Color P_AnimationColor
        {
            get { return AnimationColor.Color; }
            set { AnimationColor.Color = value; }
        }

        public int P_AnimationSpeed
        {
            get { return AnimationSpeed.Interval; }
            set { AnimationSpeed.Interval = value; }
        }

        #endregion

        #region EventArgs

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetStandardSize();
            UpdateGraphics();
            SetPoints();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            AnimationSpeed.Enabled = Enabled;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            AnimationSpeed.Tick += AnimationSpeed_Tick;
            AnimationSpeed.Start();
        }

        private void AnimationSpeed_Tick(object sender, EventArgs e)
        {
            if (IndicatorIndex.Equals(0))
            {
                IndicatorIndex = FloatPoint.Length - 1;
            }
            else
            {
                IndicatorIndex -= 1;
            }
            Invalidate(false);
        }

        #endregion
    }

    #endregion

    #region TabControl

    public class iTalk_TabControl : TabControl
    {
        // NOTE: For best quality icons/images on the TabControl; from the associated ImageList, set
        // the image size (24,24) so it can fit in the tab rectangle. However, to ensure a
        // high-quality image drawing, make sure you only add (32,32) images and not (24,24) as
        // determined in the ImageList

        // INFO: A free, non-commercial icon list that would fit in perfectly with the TabControl is
        // Wireframe Toolbar Icons by Gentleface. Licensed under Creative Commons Attribution.
        // Check it out from here: http://www.gentleface.com/free_icon_set.html

        public iTalk_TabControl()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer, true);

            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(44, 135);
            DrawMode = TabDrawMode.OwnerDrawFixed;

            foreach (TabPage Page in TabPages)
            {
                Page.BackColor = Color.FromArgb(246, 246, 246);
            }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();

            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            Appearance = TabAppearance.Normal;
            Alignment = TabAlignment.Left;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (e.Control is TabPage)
            {
                IEnumerator enumerator;
                try
                {
                    enumerator = Controls.GetEnumerator();
                    while (enumerator != null && enumerator.MoveNext())
                    {
                        var current = (TabPage) enumerator.Current;
                        current = new TabPage();
                    }
                }
                finally
                {
                    e.Control.BackColor = Color.FromArgb(246, 246, 246);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var B = new Bitmap(Width, Height);
            var G = Graphics.FromImage(B);

            var _Graphics = G;

            _Graphics.Clear(Color.FromArgb(246, 246, 246));
            _Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            _Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            _Graphics.CompositingMode = CompositingMode.SourceOver;

            // Draw tab selector background
            _Graphics.FillRectangle(new SolidBrush(Color.FromArgb(54, 57, 64)),
                new Rectangle(-5, 0, ItemSize.Height + 4, Height));
            // Draw vertical line at the end of the tab selector rectangle
            _Graphics.DrawLine(new Pen(Color.FromArgb(25, 26, 28)), ItemSize.Height - 1, 0, ItemSize.Height - 1, Height);

            for (var TabIndex = 0; TabIndex <= TabCount - 1; TabIndex++)
            {
                if (TabIndex == SelectedIndex)
                {
                    var TabRect =
                        new Rectangle(
                            new Point(GetTabRect(TabIndex).Location.X - 2, GetTabRect(TabIndex).Location.Y - 2),
                            new Size(GetTabRect(TabIndex).Width + 3, GetTabRect(TabIndex).Height - 8));

                    // Draw background of the selected tab
                    _Graphics.FillRectangle(new SolidBrush(Color.FromArgb(35, 36, 38)), TabRect.X, TabRect.Y,
                        TabRect.Width - 4, TabRect.Height + 3);
                    // Draw a tab highlighter on the background of the selected tab
                    var TabHighlighter =
                        new Rectangle(
                            new Point(GetTabRect(TabIndex).X - 2,
                                GetTabRect(TabIndex).Location.Y - (TabIndex == 0 ? 1 : 1)),
                            new Size(4, GetTabRect(TabIndex).Height - 7));
                    _Graphics.FillRectangle(new SolidBrush(Color.FromArgb(89, 169, 222)), TabHighlighter);
                    // Draw tab text
                    _Graphics.DrawString(TabPages[TabIndex].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold),
                        new SolidBrush(Color.FromArgb(254, 255, 255)),
                        new Rectangle(TabRect.Left + 40, TabRect.Top + 12, TabRect.Width - 40, TabRect.Height),
                        new StringFormat {Alignment = StringAlignment.Near});

                    if (ImageList != null)
                    {
                        var Index = TabPages[TabIndex].ImageIndex;
                        if (!(Index == -1))
                        {
                            _Graphics.DrawImage(ImageList.Images[TabPages[TabIndex].ImageIndex], TabRect.X + 9,
                                TabRect.Y + 6, 24, 24);
                        }
                    }
                }
                else
                {
                    var TabRect =
                        new Rectangle(
                            new Point(GetTabRect(TabIndex).Location.X - 2, GetTabRect(TabIndex).Location.Y - 2),
                            new Size(GetTabRect(TabIndex).Width + 3, GetTabRect(TabIndex).Height - 8));
                    _Graphics.DrawString(TabPages[TabIndex].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold),
                        new SolidBrush(Color.FromArgb(159, 162, 167)),
                        new Rectangle(TabRect.Left + 40, TabRect.Top + 12, TabRect.Width - 40, TabRect.Height),
                        new StringFormat {Alignment = StringAlignment.Near});

                    if (ImageList != null)
                    {
                        var Index = TabPages[TabIndex].ImageIndex;
                        if (!(Index == -1))
                        {
                            _Graphics.DrawImage(ImageList.Images[TabPages[TabIndex].ImageIndex], TabRect.X + 9,
                                TabRect.Y + 6, 24, 24);
                        }
                    }
                }
            }
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.DrawImage((Image) B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

    #endregion

    #region TabControl_Bigger

    public class iTalk_TabControl2 : TabControl
    {
        // NOTE: For best quality icons/images on the TabControl; from the associated ImageList, set
        // the image size (24,24) so it can fit in the tab rectangle. However, to ensure a
        // high-quality image drawing, make sure you only add (32,32) images and not (24,24) as
        // determined in the ImageList

        // INFO: A free, non-commercial icon list that would fit in perfectly with the TabControl is
        // Wireframe Toolbar Icons by Gentleface. Licensed under Creative Commons Attribution.
        // Check it out from here: http://www.gentleface.com/free_icon_set.html

        public iTalk_TabControl2()
        {
            SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer, true);

            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(44, 200);
            DrawMode = TabDrawMode.OwnerDrawFixed;

            foreach (TabPage Page in TabPages)
            {
                Page.BackColor = Color.FromArgb(54, 57, 64);
            }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();

            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            Appearance = TabAppearance.Normal;
            Alignment = TabAlignment.Left;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (e.Control is TabPage)
            {
                IEnumerator enumerator;
                try
                {
                    enumerator = Controls.GetEnumerator();
                    while (enumerator != null && enumerator.MoveNext())
                    {
                        var current = (TabPage)enumerator.Current;
                        current = new TabPage();
                    }
                }
                finally
                {
                    e.Control.BackColor = Color.FromArgb(54, 57, 64);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var B = new Bitmap(Width, Height);
            var G = Graphics.FromImage(B);

            var _Graphics = G;

            _Graphics.Clear(Color.FromArgb(54, 57, 64));
            _Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            _Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            _Graphics.CompositingMode = CompositingMode.SourceOver;

            // Draw tab selector background
            _Graphics.FillRectangle(new SolidBrush(Color.FromArgb(54, 57, 64)),
                new Rectangle(-5, 0, ItemSize.Height + 4, Height));
            // Draw vertical line at the end of the tab selector rectangle
            _Graphics.DrawLine(new Pen(Color.FromArgb(25, 26, 28)), ItemSize.Height - 1, 0, ItemSize.Height - 1, Height);

            for (var TabIndex = 0; TabIndex <= TabCount - 1; TabIndex++)
            {
                if (TabIndex == SelectedIndex)
                {
                    var TabRect =
                        new Rectangle(
                            new Point(GetTabRect(TabIndex).Location.X - 2, GetTabRect(TabIndex).Location.Y - 2),
                            new Size(GetTabRect(TabIndex).Width + 3, GetTabRect(TabIndex).Height - 8));

                    // Draw background of the selected tab
                    _Graphics.FillRectangle(new SolidBrush(Color.FromArgb(35, 36, 38)), TabRect.X, TabRect.Y,
                        TabRect.Width - 4, TabRect.Height + 3);
                    // Draw a tab highlighter on the background of the selected tab
                    var TabHighlighter =
                        new Rectangle(
                            new Point(GetTabRect(TabIndex).X - 2,
                                GetTabRect(TabIndex).Location.Y - (TabIndex == 0 ? 1 : 1)),
                            new Size(4, GetTabRect(TabIndex).Height - 7));
                    _Graphics.FillRectangle(new SolidBrush(Color.FromArgb(89, 169, 222)), TabHighlighter);
                    // Draw tab text
                    _Graphics.DrawString(TabPages[TabIndex].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold),
                        new SolidBrush(Color.FromArgb(254, 255, 255)),
                        new Rectangle(TabRect.Left + 40, TabRect.Top + 12, TabRect.Width - 40, TabRect.Height),
                        new StringFormat { Alignment = StringAlignment.Near });

                    if (ImageList != null)
                    {
                        var Index = TabPages[TabIndex].ImageIndex;
                        if (!(Index == -1))
                        {
                            _Graphics.DrawImage(ImageList.Images[TabPages[TabIndex].ImageIndex], TabRect.X + 9,
                                TabRect.Y + 6, 24, 24);
                        }
                    }
                }
                else
                {
                    var TabRect =
                        new Rectangle(
                            new Point(GetTabRect(TabIndex).Location.X - 2, GetTabRect(TabIndex).Location.Y - 2),
                            new Size(GetTabRect(TabIndex).Width + 3, GetTabRect(TabIndex).Height - 8));
                    _Graphics.DrawString(TabPages[TabIndex].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold),
                        new SolidBrush(Color.FromArgb(159, 162, 167)),
                        new Rectangle(TabRect.Left + 40, TabRect.Top + 12, TabRect.Width - 40, TabRect.Height),
                        new StringFormat { Alignment = StringAlignment.Near });

                    if (ImageList != null)
                    {
                        var Index = TabPages[TabIndex].ImageIndex;
                        if (!(Index == -1))
                        {
                            _Graphics.DrawImage(ImageList.Images[TabPages[TabIndex].ImageIndex], TabRect.X + 9,
                                TabRect.Y + 6, 24, 24);
                        }
                    }
                }
            }
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

    #endregion

    #region TrackBar

    [DefaultEvent("ValueChanged")]
    public class iTalk_TrackBar : Control
    {
        #region Enums

        public enum ValueDivisor
        {
            By1 = 1,
            By10 = 10,
            By100 = 100,
            By1000 = 1000
        }

        #endregion

        public iTalk_TrackBar()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer, true);

            _DrawHatch = true;
            Size = new Size(80, 22);
            MinimumSize = new Size(37, 22);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = _DrawValueString ? 40 : 22;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var G = e.Graphics;
            var Hatch = new HatchBrush(HatchStyle.WideDownwardDiagonal, Color.FromArgb(20, Color.Black),
                Color.Transparent);
            G.Clear(Parent.BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;
            checked
            {
                PipeBorder = RoundRectangle.RoundRect(1, 6, Width - 3, 8, 3);
                try
                {
                    ValueDrawer =
                        (int)
                            Math.Round(
                                unchecked(
                                    checked((_Value - _Minimum)/(double) (_Maximum - _Minimum))*checked(Width - 11)));
                }
                catch (Exception)
                {
                    // ignored
                }
                TrackBarHandleRect = new Rectangle(ValueDrawer, 0, 10, 20);
                G.SetClip(PipeBorder);
                ValueRect = new Rectangle(1, 7, TrackBarHandleRect.X + TrackBarHandleRect.Width - 2, 7);
                VlaueLGB = new LinearGradientBrush(ValueRect, _ValueColour, _ValueColour, 90f);
                G.FillRectangle(VlaueLGB, ValueRect);

                if (_DrawHatch)
                {
                    G.FillRectangle(Hatch, ValueRect);
                }

                G.ResetClip();
                G.SmoothingMode = SmoothingMode.AntiAlias;
                G.DrawPath(new Pen(Color.FromArgb(180, 180, 180)), PipeBorder);
                TrackBarHandle = RoundRectangle.RoundRect(TrackBarHandleRect, 3);
                TrackBarHandleLGB = new LinearGradientBrush(ClientRectangle, SystemColors.Control, SystemColors.Control,
                    90f);
                G.FillPath(TrackBarHandleLGB, TrackBarHandle);
                G.DrawPath(new Pen(Color.FromArgb(180, 180, 180)), TrackBarHandle);

                if (_DrawValueString)
                {
                    G.DrawString(Convert.ToString(ValueToSet, CultureInfo.InvariantCulture), Font, Brushes.Gray, 0, 25);
                }
            }
        }

        #region Variables

        private GraphicsPath PipeBorder;
        private GraphicsPath TrackBarHandle;
        private Rectangle TrackBarHandleRect;
        private Rectangle ValueRect;
        private LinearGradientBrush VlaueLGB;
        private LinearGradientBrush TrackBarHandleLGB;
        private bool Cap;

        private int ValueDrawer;
        private int _Minimum;
        private int _Maximum = 10;
        private int _Value;
        private Color _ValueColour = Color.FromArgb(224, 224, 224);
        private bool _DrawHatch;
        private bool _DrawValueString;
        private ValueDivisor DividedValue = ValueDivisor.By1;

        #endregion

        #region Custom Properties

        public int Minimum
        {
            get { return _Minimum; }

            set
            {
                if (value >= _Maximum)
                    value = _Maximum - 10;
                if (_Value < value)
                    _Value = value;

                _Minimum = value;
                Invalidate();
            }
        }

        public int Maximum
        {
            get { return _Maximum; }

            set
            {
                if (value <= _Minimum)
                    value = _Minimum + 10;
                if (_Value > value)
                    _Value = value;

                _Maximum = value;
                Invalidate();
            }
        }

        public event ValueChangedEventHandler ValueChanged;

        public delegate void ValueChangedEventHandler();

        public int Value
        {
            get { return _Value; }
            set
            {
                if (_Value != value)
                {
                    if (value < _Minimum)
                    {
                        _Value = _Minimum;
                    }
                    else
                    {
                        _Value = value > _Maximum ? _Maximum : value;
                    }
                    Invalidate();
                    if (ValueChanged != null)
                    {
                        ValueChanged();
                    }
                }
            }
        }

        public ValueDivisor ValueDivison
        {
            get { return DividedValue; }
            set
            {
                DividedValue = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        public float ValueToSet
        {
            get { return (float) (_Value/((double) DividedValue)); }
            set { Value = (int) Math.Round(value*((float) DividedValue)); }
        }

        public Color ValueColour
        {
            get { return _ValueColour; }
            set
            {
                _ValueColour = value;
                Invalidate();
            }
        }

        public bool DrawHatch
        {
            get { return _DrawHatch; }
            set
            {
                _DrawHatch = value;
                Invalidate();
            }
        }

        public bool DrawValueString
        {
            get { return _DrawValueString; }
            set
            {
                _DrawValueString = value;
                Height = _DrawValueString ? 40 : 22;
                Invalidate();
            }
        }

        public bool JumpToMouse { get; set; }

        #endregion

        #region EventArgs

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if ((Cap && (e.X > -1)) && (e.X < (Width + 1)))
            {
                Value = _Minimum + ((int) Math.Round((_Maximum - _Minimum)*(e.X/((double) Width))));
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                ValueDrawer = (int) Math.Round(((_Value - _Minimum)/((double) (_Maximum - _Minimum)))*(Width - 11));
                TrackBarHandleRect = new Rectangle(ValueDrawer, 0, 10, 20);
                Cap = TrackBarHandleRect.Contains(e.Location);
                if (JumpToMouse)
                {
                    Value = _Minimum + ((int) Math.Round((_Maximum - _Minimum)*(e.X/((double) Width))));
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
        }

        #endregion
    }

    #endregion

    #region MenuStrip

    public class iTalk_MenuStrip : MenuStrip
    {
        public iTalk_MenuStrip()
        {
            Renderer = new ControlRenderer();
        }

        public new ControlRenderer Renderer
        {
            get { return (ControlRenderer) base.Renderer; }
            set { base.Renderer = value; }
        }
    }

    #endregion

    #region ContextMenuStrip

    public class iTalk_ContextMenuStrip : ContextMenuStrip
    {
        public iTalk_ContextMenuStrip()
        {
            Renderer = new ControlRenderer();
        }

        public new ControlRenderer Renderer
        {
            get { return (ControlRenderer) base.Renderer; }
            set { base.Renderer = value; }
        }
    }

    #endregion

    #region StatusStrip

    public class iTalk_StatusStrip : StatusStrip
    {
        public iTalk_StatusStrip()
        {
            Renderer = new ControlRenderer();
            SizingGrip = false;
        }

        public new ControlRenderer Renderer
        {
            get { return (ControlRenderer) base.Renderer; }
            set { base.Renderer = value; }
        }
    }

    #endregion

    #region Info Icon

    public class iTalk_Icon_Info : Control
    {
        public iTalk_Icon_Info()
        {
            ForeColor = Color.DimGray;
            BackColor = Color.FromArgb(246, 246, 246);
            Size = new Size(33, 33);
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            e.Graphics.FillEllipse(new SolidBrush(Color.Gray), new Rectangle(1, 1, 29, 29));
            e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(246, 246, 246)), new Rectangle(3, 3, 25, 25));

            e.Graphics.DrawString("¡", new Font("Segoe UI", 25, FontStyle.Bold), new SolidBrush(Color.Gray),
                new Rectangle(4, -14, Width, 43), new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Near
                });
        }
    }

    #endregion

    #region  Tick Icon

    public class iTalk_Icon_Tick : Control
    {
        public iTalk_Icon_Tick()
        {
            ForeColor = Color.DimGray;
            BackColor = Color.FromArgb(246, 246, 246);
            Size = new Size(33, 33);
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            e.Graphics.FillEllipse(new SolidBrush(Color.Gray), new Rectangle(1, 1, 29, 29));
            e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(246, 246, 246)), new Rectangle(3, 3, 25, 25));

            e.Graphics.DrawString("ü", new Font("Wingdings", 25, FontStyle.Bold), new SolidBrush(Color.Gray),
                new Rectangle(0, -3, Width, 43), new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Near
                });
        }
    }

    #endregion
}