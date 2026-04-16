namespace MultiMonPresenter
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lFolder = new Label();
            baseFolder = new TextBox();
            bFolderBrowse = new Button();
            selectFolderDialog = new OpenFileDialog();
            menu = new MenuStrip();
            menuFile = new ToolStripMenuItem();
            menuFileRefresh = new ToolStripMenuItem();
            menuFileSave = new ToolStripMenuItem();
            menuFileLoad = new ToolStripMenuItem();
            menuFileSplit1 = new ToolStripSeparator();
            menuFileExit = new ToolStripMenuItem();
            menuMonitors = new ToolStripMenuItem();
            menuMonitorsDetect = new ToolStripMenuItem();
            menuMonitorsToggleNumbers = new ToolStripMenuItem();
            menuMonitorsEnabled = new ToolStripMenuItem();
            lFolderErrorMessage = new Label();
            statusStrip1 = new StatusStrip();
            statusLabel1 = new ToolStripStatusLabel();
            statusLabel2 = new ToolStripStatusLabel();
            statusLabel3 = new ToolStripStatusLabel();
            saveSettingsDialog = new SaveFileDialog();
            loadSettingsDialog = new OpenFileDialog();
            bDoSlideshow = new Button();
            menu.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lFolder
            // 
            lFolder.AutoSize = true;
            lFolder.Location = new Point(15, 37);
            lFolder.Name = "lFolder";
            lFolder.Size = new Size(43, 15);
            lFolder.TabIndex = 0;
            lFolder.Text = "Folder:";
            lFolder.Click += lFolder_Click;
            // 
            // baseFolder
            // 
            baseFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            baseFolder.Location = new Point(68, 34);
            baseFolder.Name = "baseFolder";
            baseFolder.Size = new Size(522, 23);
            baseFolder.TabIndex = 1;
            baseFolder.TextChanged += CheckFolder;
            // 
            // bFolderBrowse
            // 
            bFolderBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bFolderBrowse.Location = new Point(596, 33);
            bFolderBrowse.Name = "bFolderBrowse";
            bFolderBrowse.Size = new Size(75, 23);
            bFolderBrowse.TabIndex = 2;
            bFolderBrowse.Text = "&Browse...";
            bFolderBrowse.UseVisualStyleBackColor = true;
            bFolderBrowse.Click += bFolderBrowse_Click;
            // 
            // selectFolderDialog
            // 
            selectFolderDialog.CheckFileExists = false;
            selectFolderDialog.FileName = "Select Folder";
            selectFolderDialog.Filter = "All files (*.*)|*.*";
            selectFolderDialog.Title = "Select Images Folder";
            // 
            // menu
            // 
            menu.Items.AddRange(new ToolStripItem[] { menuFile, menuMonitors });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(683, 24);
            menu.TabIndex = 3;
            menu.Text = "menu";
            // 
            // menuFile
            // 
            menuFile.DropDownItems.AddRange(new ToolStripItem[] { menuFileRefresh, menuFileSave, menuFileLoad, menuFileSplit1, menuFileExit });
            menuFile.Name = "menuFile";
            menuFile.Size = new Size(37, 20);
            menuFile.Text = "&File";
            // 
            // menuFileRefresh
            // 
            menuFileRefresh.Name = "menuFileRefresh";
            menuFileRefresh.Size = new Size(185, 22);
            menuFileRefresh.Text = "&Refresh Folder";
            menuFileRefresh.Click += menuFileRefresh_Click;
            // 
            // menuFileSave
            // 
            menuFileSave.Name = "menuFileSave";
            menuFileSave.ShortcutKeys = Keys.Control | Keys.S;
            menuFileSave.Size = new Size(185, 22);
            menuFileSave.Text = "&Save Settings";
            menuFileSave.Click += menuFileSave_Click;
            // 
            // menuFileLoad
            // 
            menuFileLoad.Name = "menuFileLoad";
            menuFileLoad.ShortcutKeys = Keys.Control | Keys.L;
            menuFileLoad.Size = new Size(185, 22);
            menuFileLoad.Text = "&Load Settings";
            menuFileLoad.Click += menuFileLoad_Click;
            // 
            // menuFileSplit1
            // 
            menuFileSplit1.Name = "menuFileSplit1";
            menuFileSplit1.Size = new Size(182, 6);
            // 
            // menuFileExit
            // 
            menuFileExit.Name = "menuFileExit";
            menuFileExit.Size = new Size(185, 22);
            menuFileExit.Text = "E&xit";
            menuFileExit.Click += menuFileExit_Click;
            // 
            // menuMonitors
            // 
            menuMonitors.DropDownItems.AddRange(new ToolStripItem[] { menuMonitorsDetect, menuMonitorsToggleNumbers, menuMonitorsEnabled });
            menuMonitors.Name = "menuMonitors";
            menuMonitors.Size = new Size(67, 20);
            menuMonitors.Text = "&Monitors";
            // 
            // menuMonitorsDetect
            // 
            menuMonitorsDetect.Name = "menuMonitorsDetect";
            menuMonitorsDetect.Size = new Size(201, 22);
            menuMonitorsDetect.Text = "&Detect Monitors";
            menuMonitorsDetect.Click += menuMonitorsDetect_Click;
            // 
            // menuMonitorsToggleNumbers
            // 
            menuMonitorsToggleNumbers.Name = "menuMonitorsToggleNumbers";
            menuMonitorsToggleNumbers.Size = new Size(201, 22);
            menuMonitorsToggleNumbers.Text = "&Show Monitor Numbers";
            menuMonitorsToggleNumbers.Click += menuMonitorsShowNumbers_Click;
            // 
            // menuMonitorsEnabled
            // 
            menuMonitorsEnabled.Enabled = false;
            menuMonitorsEnabled.Name = "menuMonitorsEnabled";
            menuMonitorsEnabled.Size = new Size(201, 22);
            menuMonitorsEnabled.Text = "&Enabled";
            // 
            // lFolderErrorMessage
            // 
            lFolderErrorMessage.AutoSize = true;
            lFolderErrorMessage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lFolderErrorMessage.ForeColor = Color.Red;
            lFolderErrorMessage.Location = new Point(69, 59);
            lFolderErrorMessage.Name = "lFolderErrorMessage";
            lFolderErrorMessage.Size = new Size(151, 15);
            lFolderErrorMessage.TabIndex = 4;
            lFolderErrorMessage.Text = "Error: Error Message Here";
            lFolderErrorMessage.Visible = false;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel1, statusLabel2, statusLabel3 });
            statusStrip1.Location = new Point(0, 355);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(683, 22);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel1
            // 
            statusLabel1.Name = "statusLabel1";
            statusLabel1.Size = new Size(42, 17);
            statusLabel1.Text = "Ready.";
            // 
            // statusLabel2
            // 
            statusLabel2.Name = "statusLabel2";
            statusLabel2.Size = new Size(37, 17);
            statusLabel2.Text = "0 files";
            // 
            // statusLabel3
            // 
            statusLabel3.Name = "statusLabel3";
            statusLabel3.Size = new Size(46, 17);
            statusLabel3.Text = "0 Slides";
            // 
            // saveSettingsDialog
            // 
            saveSettingsDialog.DefaultExt = "json";
            saveSettingsDialog.FileName = "MultiMonSettings.json";
            saveSettingsDialog.Filter = "JSON Files (*.json)|*.json";
            saveSettingsDialog.Title = "Choose File to Save Settings";
            // 
            // loadSettingsDialog
            // 
            loadSettingsDialog.DefaultExt = "json";
            loadSettingsDialog.FileName = "MultiMonSettings.json";
            loadSettingsDialog.Filter = "JSON Files (*.json)|*.json";
            loadSettingsDialog.Title = "Load MultiMon Settings";
            // 
            // bDoSlideshow
            // 
            bDoSlideshow.Enabled = false;
            bDoSlideshow.Location = new Point(20, 95);
            bDoSlideshow.Name = "bDoSlideshow";
            bDoSlideshow.Size = new Size(651, 74);
            bDoSlideshow.TabIndex = 6;
            bDoSlideshow.Text = "&Do Slideshow";
            bDoSlideshow.UseVisualStyleBackColor = true;
            bDoSlideshow.Click += bDoSlideshow_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(683, 377);
            Controls.Add(bDoSlideshow);
            Controls.Add(statusStrip1);
            Controls.Add(lFolderErrorMessage);
            Controls.Add(bFolderBrowse);
            Controls.Add(baseFolder);
            Controls.Add(lFolder);
            Controls.Add(menu);
            MainMenuStrip = menu;
            Name = "Main";
            Text = "MultiMonPresenter";
            Load += Main_Load;
            menu.ResumeLayout(false);
            menu.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lFolder;
        private TextBox baseFolder;
        private Button bFolderBrowse;
        private OpenFileDialog selectFolderDialog;
        private MenuStrip menu;
        private ToolStripMenuItem menuFile;
        private ToolStripMenuItem menuMonitors;
        private ToolStripMenuItem menuMonitorsDetect;
        private ToolStripMenuItem menuMonitorsEnabled;
        private ToolStripMenuItem menuMonitorsToggleNumbers;
        private Label lFolderErrorMessage;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel1;
        private ToolStripStatusLabel statusLabel2;
        private ToolStripMenuItem menuFileRefresh;
        private ToolStripMenuItem menuFileSave;
        private ToolStripMenuItem menuFileLoad;
        private ToolStripSeparator menuFileSplit1;
        private ToolStripMenuItem menuFileExit;
        private SaveFileDialog saveSettingsDialog;
        private OpenFileDialog loadSettingsDialog;
        private ToolStripStatusLabel statusLabel3;
        private Button bDoSlideshow;
    }
}
