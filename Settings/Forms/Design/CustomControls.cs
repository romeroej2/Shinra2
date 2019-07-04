using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;

namespace ShinraCo.Settings.Forms.Design
{
    [DesignerCategory("code")]
    
    #region CheckBox

    public sealed class CustomCheck : CheckBox
    {
        public CustomCheck()
        {
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Segoe UI", 8.25F);
            ForeColor = Color.White;
            TabStop = false;
        }
    }

    #endregion

    #region CheckBoxDisabled

    public sealed class CustomCheckDisabled : CheckBox
    {
        public CustomCheckDisabled()
        {
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Segoe UI", 8.25F);
            ForeColor = Color.DimGray;
            AutoCheck = false;
            TabStop = false;
        }
    }

    #endregion

    #region ComboBox

    public sealed class CustomCombo : ComboBox
    {
        public CustomCombo()
        {
            BackColor = Color.FromArgb(52, 52, 52);
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Segoe UI", 8.25F);
            ForeColor = Color.White;
            TabStop = false;
        }

        protected override void OnSelectedValueChanged(EventArgs e)
        {
            Parent.Focus();
            base.OnSelectedValueChanged(e);
        }
    }

    #endregion

    #region GroupBox

    public sealed class CustomGroup : GroupBox
    {
        public CustomGroup()
        {
            Font = new Font("Segoe UI", 8.25F);
            TabStop = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            var textRectangle = ClientRectangle;
            const int textOffset = 6;
            textRectangle.X += textOffset;
            textRectangle.Width -= 2 * textOffset;
            const TextFormatFlags flags = TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl;
            var textSize = TextRenderer.MeasureText(Text, Font, new Size(textRectangle.Width, int.MaxValue), flags);
            TextRenderer.DrawText(graphics, Text, Font, textRectangle, Color.White, flags);

            var borderPen = new Pen(new SolidBrush(Color.GreenYellow));
            var textRight = Math.Min(textOffset + textSize.Width, Width - 6);
            var boxTop = FontHeight / 2;
            graphics.DrawLine(borderPen, 0, boxTop, 0, Height - 1);
            graphics.DrawLine(borderPen, 0, Height - 1, Width, Height - 1);
            graphics.DrawLine(borderPen, 0, boxTop, textOffset, boxTop);
            graphics.DrawLine(borderPen, textRight - 2, boxTop, Width - 1, boxTop);
            graphics.DrawLine(borderPen, Width - 1, boxTop, Width - 1, Height - 1);
        }
    }

    #endregion

    #region HotkeyBox

    public class HotkeyBox : TextBox
    {
        [Browsable(false)]
        [DefaultValue(Keys.None)]
        public Keys Hotkey { get; private set; }

        public HotkeyBox()
        {
            BackColor = Color.FromArgb(52, 52, 52);
            BorderStyle = BorderStyle.FixedSingle;
            Font = new Font("Segoe UI", 8.25F);
            ForeColor = Color.White;
            ReadOnly = true;
            TabStop = false;
            AutoSize = false;
        }

        private void RefreshText()
        {
            var converter = new KeysConverter();
            Text = converter.ConvertToString(Hotkey);
            Parent.Focus();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Escape)
            {
                if (e.KeyCode != Keys.Menu &&
                    e.KeyCode != Keys.ShiftKey &&
                    e.KeyCode != Keys.ControlKey &&
                    e.KeyCode != Keys.LWin &&
                    e.KeyCode != Keys.RWin)
                {
                    Hotkey = e.KeyData;
                    RefreshText();
                }
            }
            else
            {
                Hotkey = Keys.None;
                RefreshText();
            }
            base.OnKeyDown(e);
        }

        [DllImport("user32")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);
        private const int WmPaint = 0x0F;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg != WmPaint) return;
            var dc = GetWindowDC(Handle);
            var g = Graphics.FromHdc(dc);
            {
                g.DrawRectangle(Pens.White, 0, 0, Width - 1, Height - 1);
            }
        }
    }

    #endregion

    #region NoSelectButton

    public sealed class NoSelectButton : Button
    {
        public NoSelectButton()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }

    #endregion

    #region NumericUpDown

    public sealed class CustomNumeric : NumericUpDown
    {
        private bool _showSymbol;
        public bool ShowSymbol
        {
            get => _showSymbol;
            set
            {
                if (_showSymbol == value) { return; }
                _showSymbol = value;
                UpdateEditText();
            }
        }

        public CustomNumeric()
        {
            Controls[0].Visible = false;
            BackColor = Color.FromArgb(52, 52, 52);
            ForeColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            TabStop = false;
            Increment = 5;
            Maximum = 100;
            ShowSymbol = true;
        }

        protected override void UpdateEditText()
        {
            base.UpdateEditText();
            if (!ShowSymbol) return;
            ChangingText = true;
            Text += @"%";
        }

        [DllImport("user32")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);
        private const int WmPaint = 0x0F;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg != WmPaint) return;
            var dc = GetWindowDC(Handle);
            var g = Graphics.FromHdc(dc);
            {
                g.Clear(BackColor);
                g.DrawRectangle(Pens.White, 0, 0, Width - 1, Height - 1);
            }
        }
    }

    #endregion

    #region TabControl

    public sealed class CustomTab : TabControl
    {
        private Color BackgroundColor { get; } = Color.FromArgb(32, 32, 32);
        private Color TabColor { get; } = Color.FromArgb(52, 52, 52);

        public CustomTab()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | 
                     ControlStyles.ResizeRedraw | 
                     ControlStyles.UserPaint | 
                     ControlStyles.DoubleBuffer,
                     true);
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(35, 100);
            Font = new Font("Segoe UI", 8.25F);
            TabStop = false;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Left;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var b = new Bitmap(Width, Height);
            var g = Graphics.FromImage(b);
            try
            {
                SelectedTab.BackColor = BackgroundColor;
            }
            catch (Exception) { /* ignored */ }
            g.Clear(BackgroundColor);
            g.DrawLine(new Pen(Color.GreenYellow), new Point(ItemSize.Height + 3, 4), new Point(ItemSize.Height + 3, 999));
            for (var i = 0; i < TabCount; i++)
            {
                var x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y + 2),
                                       new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1));

                if (i == SelectedIndex)
                {
                    g.FillRectangle(new SolidBrush(TabColor), x2);
                    g.DrawString(TabPages[i].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold), Brushes.White, x2,
                                 new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
                }
                else
                {
                    g.DrawString(TabPages[i].Text, Font, Brushes.LightGray, x2,
                                 new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
                }
            }
            e.Graphics.DrawImage((Image)b.Clone(), 0, 0);
            g.Dispose();
            b.Dispose();
        }
    }

    #endregion
}