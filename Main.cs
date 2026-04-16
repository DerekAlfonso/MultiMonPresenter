namespace MultiMonPresenter
{
    public partial class Main : Form
    {
        MonitorHelper mh = new MonitorHelper();
        MultiMonSettings settings = new MultiMonSettings();
        MultiMonitorSlideshow? slideshow = null;
        public Main()
        {
            InitializeComponent();
        }

        private void lFolder_Click(object sender, EventArgs e)
        {
            baseFolder.Focus();
            baseFolder.SelectAll();
        }

        private void bFolderBrowse_Click(object sender, EventArgs e)
        {
            if (selectFolderDialog.ShowDialog() == DialogResult.OK)
            {
                baseFolder.Text = Path.GetFullPath(selectFolderDialog.FileName).Replace("Select Folder", "");
            }
        }

        private void menuMonitorsDetect_Click(object sender, EventArgs e)
        {
            var monitors = mh.GetMonitors();
            menuMonitorsEnabled.DropDownItems.Clear();
            foreach (var m in monitors)
            {
                var mi = new ToolStripMenuItem($"{m.Index}: {m.Resolution.Width}x{m.Resolution.Height}")
                {
                    Tag = $"{m.Index}",
                    CheckOnClick = true,
                    Checked = settings.SelectedMonitors.Contains(m.Index) || settings.SelectedMonitors.Count == 0
                };
                mi.Click += (s, e) => CheckFiles(s, e);
                menuMonitorsEnabled.DropDownItems.Add(mi);
            }
            menuMonitorsEnabled.Enabled = monitors.Count > 0;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            settings = MultiMonSettings.Load("MultiMonSettings.json");
            menuMonitorsDetect_Click(sender, e);
            SettingsLoaded(sender, e);
        }

        private void menuMonitorsShowNumbers_Click(object sender, EventArgs e)
        {
            menuMonitorsToggleNumbers.Checked = mh.ToggleMonitorNumbers();
        }

        private void CheckFolder(object sender, EventArgs e)
        {
            lFolderErrorMessage.Visible = false;

            if (string.IsNullOrWhiteSpace(baseFolder.Text))
            {
                statusLabel1.Text = "Select folder.";
                return;
            }

            if (!Directory.Exists(baseFolder.Text))
            {
                lFolderErrorMessage.Text = "Folder does not exist.";
                lFolderErrorMessage.Visible = true;
                statusLabel1.Text = "Folder not found.";
                return;
            }

            foreach (var item in menuMonitorsEnabled.DropDownItems)
            {
                if (item is ToolStripMenuItem menuItem && menuItem.Enabled)
                {
                    var folderCheck = Path.Combine(baseFolder.Text, (string)menuItem.Tag);
                    if (!Directory.Exists(folderCheck))
                        Directory.CreateDirectory(folderCheck);
                }
            }

            CheckFiles(sender, e);

            if (!lFolderErrorMessage.Visible)
                menuFileRefresh_Click(sender, e);
        }

        private void menuFileLoad_Click(object sender, EventArgs e)
        {
            if (loadSettingsDialog.ShowDialog() == DialogResult.OK)
            {
                settings = MultiMonSettings.Load(loadSettingsDialog.FileName);
                CheckFolder(sender, e);
                SettingsLoaded(sender, e);
            }
        }

        private void SettingsLoaded(object sender, EventArgs e)
        {
            baseFolder.Text = settings.FilePath;
            if (settings.SelectedMonitors.Count > 0)
            {
                foreach (var item in menuMonitorsEnabled.DropDownItems)
                {
                    if (item is ToolStripMenuItem menuItem && menuItem.Enabled)
                    {
                        menuItem.Checked = settings.SelectedMonitors.Contains(int.Parse((string)menuItem.Tag));
                    }
                }
            }
            CheckFiles(sender, e);
        }

        private void CheckFiles(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(baseFolder.Text) || !Directory.Exists(baseFolder.Text))
            {
                statusLabel1.Text = String.IsNullOrEmpty(baseFolder.Text) ? "Select folder." : "Folder does not exist.";
                statusLabel2.Text = "0 Files";
                statusLabel3.Text = "0 Slides";
                return;
            }
            else if (Directory.Exists(baseFolder.Text))
            {
                slideshow = new MultiMonitorSlideshow(baseFolder.Text, SelectedMonitors);
                statusLabel2.Text = $"{slideshow.TotalFiles:#,##0} Files";
                statusLabel3.Text = $"{slideshow.TotalSlides:#,##0} Slides";
                if(slideshow.TotalSlides == 0)
                {
                    statusLabel1.Text = "No image files found in selected monitor folders.";
                    bDoSlideshow.Enabled = false;
                }
                else
                {
                    statusLabel1.Text = "Ready.";
                    bDoSlideshow.Enabled = true;
                }
            }
        }

        private List<int> SelectedMonitors
        {
            get
            {
                var selected = new List<int>();
                foreach (var item in menuMonitorsEnabled.DropDownItems)
                {
                    if (item is ToolStripMenuItem menuItem && menuItem.Enabled && menuItem.Checked)
                    {
                        selected.Add(int.Parse((string)menuItem.Tag));
                    }
                }
                return selected;
            }
        }

        private void menuFileSave_Click(object sender, EventArgs e)
        {
            if (saveSettingsDialog.ShowDialog() == DialogResult.OK)
            {
                settings.Save(saveSettingsDialog.FileName);
            }
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuFileRefresh_Click(object sender, EventArgs e)
        {
            CheckFiles(sender, e);
        }

        private void bDoSlideshow_Click(object sender, EventArgs e)
        {
            if (slideshow != null)
                slideshow.Run();
        }
    }
}
