using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ShinraCo.Properties;

namespace ShinraCo.Settings.Forms
{
    public partial class ShinraOverlay : Form
    {
        private readonly Image _shinraLogo = Resources.ShinraLogo;

        public ShinraOverlay() => InitializeComponent();

        private void ShinraOverlay_Load(object sender, EventArgs e)
        {
            ShinraLogo.Image = _shinraLogo;
            SetWindowPos(Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
            Location = ShinraEx.Settings.OverlayLocation;
        }

        public void UpdateText()
        {
            var crStatus = ShinraEx.Settings.CrPaused ? "Paused" : "Running";
            RotationModeLabel.Text = $@"[Rotation] {Convert.ToString(ShinraEx.Settings.RotationMode)}";
            CooldownModeLabel.Text = $@"[Cooldown] {Convert.ToString(ShinraEx.Settings.CooldownMode)}";
            TankModeLabel.Text = $@"[Tank] {Convert.ToString(ShinraEx.Settings.TankMode)}";
            CRStatusLabel.Text = $@"[CRStatus] {crStatus}";
        }

        private void ShinraContainer_Paint(object sender, PaintEventArgs e) { }

        #region Draggable

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1,
                          HT_CAPTION = 0x2,
                          WM_EXITSIZEMOVE = 0x0232;

        private void ShinraOverlay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_EXITSIZEMOVE)
            {
                ShinraEx.Settings.OverlayLocation = Location;
                ShinraEx.Settings.Save();
            }

            base.WndProc(ref m);
        }

        #endregion

        #region Always On Top

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const uint SWP_NOSIZE = 0x0001, 
                           SWP_NOMOVE = 0x0002,
                           TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, 
                                                IntPtr hWndInsertAfter, 
                                                int X, int Y, 
                                                int cx, int cy,
                                                uint uFlags);

        #endregion
    }
}