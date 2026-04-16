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
            menuMonitors = new ToolStripMenuItem();
            menuMonitorsDetect = new ToolStripMenuItem();
            menuMonitorsEnabled = new ToolStripMenuItem();
            menuMonitorsToggleNumbers = new ToolStripMenuItem();
            menu.SuspendLayout();
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
            menuFile.Name = "menuFile";
            menuFile.Size = new Size(37, 20);
            menuFile.Text = "&File";
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
            // menuMonitorsEnabled
            // 
            menuMonitorsEnabled.Enabled = false;
            menuMonitorsEnabled.Name = "menuMonitorsEnabled";
            menuMonitorsEnabled.Size = new Size(201, 22);
            menuMonitorsEnabled.Text = "&Enabled";
            // 
            // menuMonitorsToggleNumbers
            // 
            menuMonitorsToggleNumbers.Name = "menuMonitorsToggleNumbers";
            menuMonitorsToggleNumbers.Size = new Size(201, 22);
            menuMonitorsToggleNumbers.Text = "&Show Monitor Numbers";
            menuMonitorsToggleNumbers.Click += showMonitorNumbersToolStripMenuItem_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(683, 377);
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
    }
}
