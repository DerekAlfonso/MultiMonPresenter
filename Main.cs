namespace MultiMonPresenter
{
    public partial class Main : Form
    {
        MonitorHelper mh = new MonitorHelper();
        MultiMonSettings settings = new MultiMonSettings();
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
                baseFolder.Text = Path.GetFullPath(selectFolderDialog.FileName);
            }
        }

        private void menuMonitorsDetect_Click(object sender, EventArgs e)
        {
            var monitors = mh.GetMonitors();
            menuMonitorsEnabled.DropDownItems.Clear();
            foreach (var m in monitors)
            {
                menuMonitorsEnabled.DropDownItems.Add(new ToolStripMenuItem($"{m.Index}: {m.Resolution.Width}x{m.Resolution.Height}")
                {
                    Tag = $"{m.Index}",
                    CheckOnClick = true,
                    Checked = settings.SelectedMonitors.Contains(m.Index) || settings.SelectedMonitors.Count == 0
                });
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

            lFolderErrorMessage.Text = lFolderErrorMessage.Visible ? "Folder does not exist." : "";
            lFolderErrorMessage.Visible = !Directory.Exists(baseFolder.Text);

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
            if(loadSettingsDialog.ShowDialog() == DialogResult.OK)
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
            if (Directory.Exists(baseFolder.Text))
            {
                var fileCount = Directory.EnumerateFiles(baseFolder.Text, "*.jpg", SearchOption.AllDirectories).Count();
                if (fileCount == 0)
                {
                    lFolderErrorMessage.Text = "No .jpg files found in the folder.";
                    lFolderErrorMessage.Visible = true;
                    statusLabel2.Text = $"0 Files";
                }
                else
                {
                    statusLabel2.Text = $"{fileCount:0,000} Files";
                }
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
    }
}
