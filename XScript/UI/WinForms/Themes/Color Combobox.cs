#region About

//|------DO-NOT-REMOVE------|

// Creator: HazelDev
// Site   : HazelDev.co.nr
// Created: 5.Mar.2012
// Changed: 13.Jul.2014
// Version: 1.1
// NET FW : 2.0 and above

//|------DO-NOT-REMOVE------|

// This component was created for user projects in which you want to put
// a limit to the amount of available colors in the ComboBox.

// See the License file, included in the same directory as this one for
// usage and distribution details.

#endregion

using System;
using System.Drawing;
using System.Windows.Forms;

public class ColorComboBox : ComboBox
{
    public ColorComboBox()
    {
        // Initialize the control once it's added to the form designer.
        InitializeComboBox();
        DrawMode = DrawMode.OwnerDrawFixed;
        DropDownStyle = ComboBoxStyle.DropDownList;
        FlatStyle = FlatStyle.System;
        BeginUpdate();
        InitializeComboBox();
        EndUpdate();
    }

    public string[] MyCustomColors
    {
        // This is a control property which can be modified from the control's property panel to add your own colors to the ComboBox.
        // By default, the colors in [ColorArray] are added. You can remove them if not desired.
        get { return ColorArray; }
        set
        {
            var ValNum = value.Length;
            ColorArray = new string[ValNum - 1 + 1];
            for (var i = 0; i <= ValNum - 1; i++)
            {
                ColorArray[i] = value[i];
            }
            Items.Clear();
            InitializeComboBox();
        }
    }

    private void InitializeComboBox()
    {
        // Update the control.
        if (ColorArray == null)
        {
            return;
        }
        foreach (var Item in ColorArray)
        {
            try
            {
                if (Color.FromName(Item).IsKnownColor)
                {
                    Items.Add(Item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thrown Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }

    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        base.OnDrawItem(e);
        // Draw the selection background.
        if ((e.State & DrawItemState.ComboBoxEdit) != DrawItemState.ComboBoxEdit)
        {
            e.DrawBackground();
        }

        if (e.Index == -1)
        {
            return;
        }

        var G = e.Graphics;

        // Get the color names of each item in the ComboBox. This is used to draw the string value in the ComboBox.
        _Color = Color.FromName((string) Items[e.Index]);

        // Draw rectangle which will contain the colors of the control's ColorArray.
        G.FillRectangle(new SolidBrush(_Color), 5, e.Bounds.Top + 2, 25, e.Bounds.Height - 5);
        // Draw a border around the color rectangle. You can remove the line below if you don't want a border to be drawn.
        G.DrawRectangle(Pens.Black, 5, e.Bounds.Top + 2, 25, e.Bounds.Height - 5);
        // Draw the string value of the chosen color depending on the selected item.
        G.DrawString(_Color.Name, e.Font, new SolidBrush(ForeColor), 33,
            ((e.Bounds.Height - Font.Height)/2) + e.Bounds.Top);

        // Me.Invalidate() --> Makes the control more interactive by creating a dynamic hover-like pre-selection. You can remove this line if not desired.
        //                 +-> However, using [Invalidate] means that the control will keep on redrawing itself. Therefore, using it on Flat and Popup styles will cause the control to flicker.
    }

    #region Variables

    private string[] ColorArray =
    {
        "Black",
        "White",
        "DimGray",
        "Gray",
        "DarkGray",
        "Silver",
        "LightGray",
        "Gainsboro",
        "WhiteSmoke",
        "Maroon",
        "DarkRed",
        "Red",
        "Brown",
        "FireBrick",
        "IndianRed"
        // The colors that will be added to the ComboBox control. You can add your own colors to the ComboBox using "MyCustomColors" Property (look below) from the designer.
    };

    // This declaration is used to retrieve the color name and value from the color array, and also used to draw the color rectangle inside the ComboBox.
    private Color _Color;

    #endregion
}