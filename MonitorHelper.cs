using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MultiMonPresenter
{
    public class MonitorHelper
    {
        public class MonitorInfo
        {
            public int Index { get; set; }
            public Rectangle Bounds { get; set; }
            public Size Resolution => Bounds.Size;
        }

        public List<MonitorInfo> GetMonitors()
        {
            var screens = Screen.AllScreens;
            var monitors = new List<MonitorInfo>();
            for (int i = 0; i < screens.Length; i++)
            {
                monitors.Add(new MonitorInfo
                {
                    Index = i + 1, // 1-based index for user display
                    Bounds = screens[i].Bounds
                });
            }
            return monitors;
        }

        private List<Form> _overlays = new List<Form>();

        public bool ToggleMonitorNumbers()
        {
            if (_overlays.Count > 0)
            {
                // Overlays are showing, remove them
                foreach (var overlay in _overlays)
                {
                    overlay.Close();
                    overlay.Dispose();
                }
                _overlays.Clear();
                return false;
            }
            else
            {
                var monitors = GetMonitors();
                foreach (var monitor in monitors)
                {
                    var overlay = new MonitorOverlayForm(monitor.Index, monitor.Bounds);
                    overlay.Show();
                    _overlays.Add(overlay);
                }
                return true;
            }
        }

        // Overlay form for displaying the number
        private class MonitorOverlayForm : Form
        {
            public MonitorOverlayForm(int number, Rectangle bounds)
            {
                FormBorderStyle = FormBorderStyle.None;
                ShowInTaskbar = false;
                StartPosition = FormStartPosition.Manual;
                Bounds = bounds;
                TopMost = true;
                BackColor = Color.LimeGreen;
                //Opacity = 0.4;
                TransparencyKey = Color.LimeGreen;
                // Make the window click-through
                Load += (s, e) => MakeClickThrough();
                Paint += (s, e) => DrawNumber(e.Graphics, number, bounds);
            }

            private void DrawNumber(Graphics g, int number, Rectangle bounds)
            {
                string text = number.ToString();
                using (Font font = new Font("Segoe UI", 96, FontStyle.Bold, GraphicsUnit.Pixel))
                using (Brush brush = new SolidBrush(Color.Red))
                {
                    SizeF textSize = g.MeasureString(text, font);
                    float x = bounds.Width - textSize.Width - 40;
                    float y = bounds.Height - textSize.Height - 20;
                    g.DrawString(text, font, brush, x, y);
                }
            }

            // Make the window click-through
            protected override CreateParams CreateParams
            {
                get
                {
                    var cp = base.CreateParams;
                    cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                    return cp;
                }
            }

            private void MakeClickThrough()
            {
                int wl = GetWindowLong(this.Handle, GWL_EXSTYLE);
                SetWindowLong(this.Handle, GWL_EXSTYLE, wl | WS_EX_LAYERED | WS_EX_TRANSPARENT);
            }

            private const int GWL_EXSTYLE = -20;
            private const int WS_EX_LAYERED = 0x80000;
            private const int WS_EX_TRANSPARENT = 0x20;

            [DllImport("user32.dll")]
            private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
            [DllImport("user32.dll")]
            private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        }
    }
}
