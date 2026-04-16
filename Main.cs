namespace MultiMonPresenter
{
    public partial class Main : Form
    {
        MonitorHelper mh = new MonitorHelper();
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
                menuMonitorsEnabled.DropDownItems.Add(new ToolStripMenuItem($"{m.Index}: {m.Resolution.Width}x{m.Resolution.Height}") { Tag = $"{m.Index}" });
            }
            menuMonitorsEnabled.Enabled = monitors.Count > 0;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            menuMonitorsDetect_Click(sender, e);
        }

        private void showMonitorNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mh.ToggleMonitorNumbers())
            {
                menuMonitorsToggleNumbers.Text = "Hide Monitor &Numbers";
            }
            else
            {
                menuMonitorsToggleNumbers.Text = "Show Monitor &Numbers";
            }
        }
    }
}
