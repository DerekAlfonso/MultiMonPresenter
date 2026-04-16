using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MultiMonPresenter
{
    public class MultiMonitorSlideshow
    {
        private readonly string _baseFolder;
        private readonly List<int> _monitorIndices;
        private readonly Dictionary<int, List<string>> _monitorFiles = new();
        private readonly List<string> _slideNames = new();
        private int _currentSlide = -1; // -1 = black, 0 = first slide
        private List<SlideshowForm> _forms = new();

        public MultiMonitorSlideshow(string folderPath, List<int> selectedMonitors)
        {
            _baseFolder = folderPath;
            _monitorIndices = selectedMonitors;
            ScanSlides();
        }

        private void ScanSlides()
        {
            _monitorFiles.Clear();
            var allNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var idx in _monitorIndices)
            {
                string monFolder = Path.Combine(_baseFolder, idx.ToString());
                if (Directory.Exists(monFolder))
                {
                    var files = Directory.GetFiles(monFolder, "*.*", SearchOption.TopDirectoryOnly)
                        .Where(f => IsImageFile(f))
                        .OrderBy(f => Path.GetFileName(f), StringComparer.OrdinalIgnoreCase)
                        .ToList();
                    _monitorFiles[idx] = files;
                    foreach (var f in files)
                        allNames.Add(Path.GetFileName(f));
                }
                else
                {
                    _monitorFiles[idx] = new List<string>();
                }
            }
            // Only keep slide names that exist for all monitors
            _slideNames.Clear();
            foreach (var name in allNames.OrderBy(n => n, StringComparer.OrdinalIgnoreCase))
            {
                if (_monitorIndices.All(idx => _monitorFiles[idx].Any(f => Path.GetFileName(f).Equals(name, StringComparison.OrdinalIgnoreCase))))
                {
                    _slideNames.Add(name);
                }
            }
        }

        private bool IsImageFile(string path)
        {
            string ext = Path.GetExtension(path).ToLowerInvariant();
            return ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp" || ext == ".gif";
        }

        public int TotalFiles => _monitorFiles.Values.Sum(list => list.Count);
        public int TotalSlides => _slideNames.Count;

        public void Run()
        {
            _currentSlide = -1;
            _forms = new List<SlideshowForm>();
            foreach (var idx in _monitorIndices)
            {
                var screen = Screen.AllScreens.ElementAtOrDefault(idx - 1); // 1-based
                if (screen != null)
                {
                    var form = new SlideshowForm(this, idx, screen);
                    _forms.Add(form);
                }
            }
            foreach (var form in _forms)
            {
                form.Show();
            }
        }

        public void NextSlide()
        {
            if (_currentSlide < _slideNames.Count)
            {
                _currentSlide++;
                UpdateSlides();
            }
        }
        public void PrevSlide()
        {
            if (_currentSlide > -1)
            {
                _currentSlide--;
                UpdateSlides();
            }
        }
        public void ExitSlides()
        {
            foreach (var form in _forms)
            {
                form.Close();
            }
        }
        private void UpdateSlides()
        {
            foreach (var form in _forms)
            {
                form.Invalidate();
            }
        }
        public string GetImagePath(int monitorIdx)
        {
            if (_currentSlide < 0 || _currentSlide >= _slideNames.Count)
                return null;
            string slideName = _slideNames[_currentSlide];
            var files = _monitorFiles[monitorIdx];
            return files.FirstOrDefault(f => Path.GetFileName(f).Equals(slideName, StringComparison.OrdinalIgnoreCase));
        }

        private class SlideshowForm : Form
        {
            private readonly MultiMonitorSlideshow _slideshow;
            private readonly int _monitorIdx;
            private readonly Screen _screen;
            public SlideshowForm(MultiMonitorSlideshow slideshow, int monitorIdx, Screen screen)
            {
                _slideshow = slideshow;
                _monitorIdx = monitorIdx;
                _screen = screen;
                FormBorderStyle = FormBorderStyle.None;
                StartPosition = FormStartPosition.Manual;
                Bounds = screen.Bounds;
                WindowState = FormWindowState.Normal;
                TopMost = true;
                BackColor = Color.Black;
                KeyPreview = true;
                ShowInTaskbar = false;
                Load += (s, e) => { Focus(); BringToFront(); }; // Ensure focus for key events
                Paint += SlideshowForm_Paint;
                KeyDown += SlideshowForm_KeyDown;
            }
            protected override void OnShown(EventArgs e)
            {
                base.OnShown(e);
                // Full screen, cover everything
                WindowState = FormWindowState.Normal;
                Bounds = _screen.Bounds;
                TopMost = true;
            }
            private void SlideshowForm_Paint(object sender, PaintEventArgs e)
            {
                string imgPath = _slideshow.GetImagePath(_monitorIdx);
                if (imgPath == null)
                {
                    // Black slide
                    e.Graphics.Clear(Color.Black);
                    return;
                }
                try
                {
                    using (var img = Image.FromFile(imgPath))
                    {
                        Rectangle destRect = GetAspectFitRect(img.Size, ClientSize);
                        e.Graphics.Clear(Color.Black);
                        e.Graphics.DrawImage(img, destRect);
                    }
                }
                catch
                {
                    e.Graphics.Clear(Color.Black);
                }
            }
            private Rectangle GetAspectFitRect(Size imgSize, Size clientSize)
            {
                float imgAspect = (float)imgSize.Width / imgSize.Height;
                float clientAspect = (float)clientSize.Width / clientSize.Height;
                int w, h, x, y;
                if (imgAspect > clientAspect)
                {
                    w = clientSize.Width;
                    h = (int)(w / imgAspect);
                }
                else
                {
                    h = clientSize.Height;
                    w = (int)(h * imgAspect);
                }
                x = (clientSize.Width - w) / 2;
                y = (clientSize.Height - h) / 2;
                return new Rectangle(x, y, w, h);
            }
            private void SlideshowForm_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Right)
                {
                    _slideshow.NextSlide();
                }
                else if (e.KeyCode == Keys.Left)
                {
                    _slideshow.PrevSlide();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    _slideshow.ExitSlides();
                }
            }
        }
    }
}
