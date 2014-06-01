namespace Scheduler
{
    partial class Scheduler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scheduler));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statStrip1 = new System.Windows.Forms.StatusStrip();
            this.mnuMainMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMyScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSharedScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savedScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMyScheduleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSharedScheduleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendScheduleToDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlDateBrowserAndAudio = new System.Windows.Forms.Panel();
            this.wmpPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.gbAvailableAudioFiles = new System.Windows.Forms.GroupBox();
            this.btnDeleteAudioFile = new System.Windows.Forms.Button();
            this.btnCreateCategory = new System.Windows.Forms.Button();
            this.tvAvailableAudioFiles = new System.Windows.Forms.TreeView();
            this.btnAddAudioFile = new System.Windows.Forms.Button();
            this.gbDateBrowser = new System.Windows.Forms.GroupBox();
            this.btnRepeatEvents = new System.Windows.Forms.Button();
            this.btnCopyEvents = new System.Windows.Forms.Button();
            this.mntCalendarDateBrowser = new System.Windows.Forms.MonthCalendar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbScheduledEvents = new System.Windows.Forms.GroupBox();
            this.radBtnViewAllEvents = new System.Windows.Forms.RadioButton();
            this.radBtnViewSelectedDateOnly = new System.Windows.Forms.RadioButton();
            this.dgvScheduledEvents = new System.Windows.Forms.DataGridView();
            this.GUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartPlay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioFileFullPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartRecord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabCreateEvents = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCreateEvent = new System.Windows.Forms.Button();
            this.gbCreateEventRecord = new System.Windows.Forms.GroupBox();
            this.chkBoxRecordEnabled = new System.Windows.Forms.CheckBox();
            this.txtCreateEventRecordDuration = new System.Windows.Forms.TextBox();
            this.dtpCreateEventStartRecord = new System.Windows.Forms.DateTimePicker();
            this.lblCreateEventRecordDuration = new System.Windows.Forms.Label();
            this.gbCreateEventPlay = new System.Windows.Forms.GroupBox();
            this.chkBoxPlayEnabled = new System.Windows.Forms.CheckBox();
            this.dtpCreateEventStartPlay = new System.Windows.Forms.DateTimePicker();
            this.txtCreateEventPlayDuration = new System.Windows.Forms.TextBox();
            this.lblCreateEventPlayDuration = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabScheduler = new System.Windows.Forms.TabPage();
            this.ofdAddAudioFile = new System.Windows.Forms.OpenFileDialog();
            this.sfdSaveScheduleAs = new System.Windows.Forms.SaveFileDialog();
            this.ofdOpenSavedSchedule = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.mnuMainMenu.SuspendLayout();
            this.pnlDateBrowserAndAudio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wmpPlayer)).BeginInit();
            this.gbAvailableAudioFiles.SuspendLayout();
            this.gbDateBrowser.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbScheduledEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScheduledEvents)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabCreateEvents.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbCreateEventRecord.SuspendLayout();
            this.gbCreateEventPlay.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabScheduler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // statStrip1
            // 
            this.statStrip1.Location = new System.Drawing.Point(0, 596);
            this.statStrip1.Name = "statStrip1";
            this.statStrip1.Size = new System.Drawing.Size(1050, 22);
            this.statStrip1.TabIndex = 1;
            this.statStrip1.Text = "statusStrip1";
            // 
            // mnuMainMenu
            // 
            this.mnuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.exportToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mnuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMainMenu.Name = "mnuMainMenu";
            this.mnuMainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMainMenu.Size = new System.Drawing.Size(1050, 24);
            this.mnuMainMenu.TabIndex = 2;
            this.mnuMainMenu.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.newFileToolStripMenuItem.Text = "New";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMyScheduleToolStripMenuItem,
            this.openSharedScheduleToolStripMenuItem,
            this.savedScheduleToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // openMyScheduleToolStripMenuItem
            // 
            this.openMyScheduleToolStripMenuItem.Name = "openMyScheduleToolStripMenuItem";
            this.openMyScheduleToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.openMyScheduleToolStripMenuItem.Text = "My Schedule";
            this.openMyScheduleToolStripMenuItem.Click += new System.EventHandler(this.openMyScheduleToolStripMenuItem_Click);
            // 
            // openSharedScheduleToolStripMenuItem
            // 
            this.openSharedScheduleToolStripMenuItem.Name = "openSharedScheduleToolStripMenuItem";
            this.openSharedScheduleToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.openSharedScheduleToolStripMenuItem.Text = "Shared Schedule";
            this.openSharedScheduleToolStripMenuItem.Click += new System.EventHandler(this.openSharedScheduleToolStripMenuItem_Click);
            // 
            // savedScheduleToolStripMenuItem
            // 
            this.savedScheduleToolStripMenuItem.Name = "savedScheduleToolStripMenuItem";
            this.savedScheduleToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.savedScheduleToolStripMenuItem.Text = "Saved Schedule";
            this.savedScheduleToolStripMenuItem.Click += new System.EventHandler(this.savedScheduleToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMyScheduleToolStripMenuItem1,
            this.saveSharedScheduleToolStripMenuItem1});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.saveToolStripMenuItem.Text = "Save To";
            // 
            // saveMyScheduleToolStripMenuItem1
            // 
            this.saveMyScheduleToolStripMenuItem1.Name = "saveMyScheduleToolStripMenuItem1";
            this.saveMyScheduleToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.saveMyScheduleToolStripMenuItem1.Text = "My Schedule";
            this.saveMyScheduleToolStripMenuItem1.Click += new System.EventHandler(this.saveMyScheduleToolStripMenuItem1_Click);
            // 
            // saveSharedScheduleToolStripMenuItem1
            // 
            this.saveSharedScheduleToolStripMenuItem1.Name = "saveSharedScheduleToolStripMenuItem1";
            this.saveSharedScheduleToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.saveSharedScheduleToolStripMenuItem1.Text = "Shared Schedule";
            this.saveSharedScheduleToolStripMenuItem1.Click += new System.EventHandler(this.saveSharedScheduleToolStripMenuItem1_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendScheduleToDesktopToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // sendScheduleToDesktopToolStripMenuItem
            // 
            this.sendScheduleToDesktopToolStripMenuItem.Name = "sendScheduleToDesktopToolStripMenuItem";
            this.sendScheduleToDesktopToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.sendScheduleToDesktopToolStripMenuItem.Text = "Send Schedule to Desktop";
            this.sendScheduleToDesktopToolStripMenuItem.Click += new System.EventHandler(this.sendScheduleToDesktopToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pnlDateBrowserAndAudio
            // 
            this.pnlDateBrowserAndAudio.Controls.Add(this.wmpPlayer);
            this.pnlDateBrowserAndAudio.Controls.Add(this.gbAvailableAudioFiles);
            this.pnlDateBrowserAndAudio.Controls.Add(this.gbDateBrowser);
            this.pnlDateBrowserAndAudio.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDateBrowserAndAudio.Location = new System.Drawing.Point(3, 3);
            this.pnlDateBrowserAndAudio.Name = "pnlDateBrowserAndAudio";
            this.pnlDateBrowserAndAudio.Size = new System.Drawing.Size(237, 537);
            this.pnlDateBrowserAndAudio.TabIndex = 3;
            // 
            // wmpPlayer
            // 
            this.wmpPlayer.AllowDrop = true;
            this.wmpPlayer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.wmpPlayer.Enabled = true;
            this.wmpPlayer.Location = new System.Drawing.Point(0, 492);
            this.wmpPlayer.Name = "wmpPlayer";
            this.wmpPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpPlayer.OcxState")));
            this.wmpPlayer.Size = new System.Drawing.Size(237, 45);
            this.wmpPlayer.TabIndex = 5;
            // 
            // gbAvailableAudioFiles
            // 
            this.gbAvailableAudioFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbAvailableAudioFiles.Controls.Add(this.btnDeleteAudioFile);
            this.gbAvailableAudioFiles.Controls.Add(this.btnCreateCategory);
            this.gbAvailableAudioFiles.Controls.Add(this.tvAvailableAudioFiles);
            this.gbAvailableAudioFiles.Controls.Add(this.btnAddAudioFile);
            this.gbAvailableAudioFiles.Location = new System.Drawing.Point(0, 213);
            this.gbAvailableAudioFiles.Name = "gbAvailableAudioFiles";
            this.gbAvailableAudioFiles.Size = new System.Drawing.Size(237, 273);
            this.gbAvailableAudioFiles.TabIndex = 2;
            this.gbAvailableAudioFiles.TabStop = false;
            this.gbAvailableAudioFiles.Text = "Audio Files";
            // 
            // btnDeleteAudioFile
            // 
            this.btnDeleteAudioFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteAudioFile.Location = new System.Drawing.Point(95, 245);
            this.btnDeleteAudioFile.Name = "btnDeleteAudioFile";
            this.btnDeleteAudioFile.Size = new System.Drawing.Size(68, 23);
            this.btnDeleteAudioFile.TabIndex = 6;
            this.btnDeleteAudioFile.Text = "Delete";
            this.btnDeleteAudioFile.UseVisualStyleBackColor = true;
            this.btnDeleteAudioFile.Click += new System.EventHandler(this.btnDeleteAudioFile_Click);
            // 
            // btnCreateCategory
            // 
            this.btnCreateCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateCategory.Location = new System.Drawing.Point(7, 245);
            this.btnCreateCategory.Name = "btnCreateCategory";
            this.btnCreateCategory.Size = new System.Drawing.Size(84, 23);
            this.btnCreateCategory.TabIndex = 5;
            this.btnCreateCategory.Text = "New Category";
            this.btnCreateCategory.UseVisualStyleBackColor = true;
            this.btnCreateCategory.Click += new System.EventHandler(this.btnCreateCategory_Click);
            // 
            // tvAvailableAudioFiles
            // 
            this.tvAvailableAudioFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvAvailableAudioFiles.BackColor = System.Drawing.Color.White;
            this.tvAvailableAudioFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvAvailableAudioFiles.HideSelection = false;
            this.tvAvailableAudioFiles.Location = new System.Drawing.Point(7, 19);
            this.tvAvailableAudioFiles.Name = "tvAvailableAudioFiles";
            this.tvAvailableAudioFiles.Size = new System.Drawing.Size(224, 219);
            this.tvAvailableAudioFiles.TabIndex = 1;
            this.tvAvailableAudioFiles.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvAvailableAudioFiles_NodeMouseDoubleClick);
            this.tvAvailableAudioFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvAvailableAudioFiles_MouseClick);
            // 
            // btnAddAudioFile
            // 
            this.btnAddAudioFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAudioFile.Location = new System.Drawing.Point(167, 245);
            this.btnAddAudioFile.Name = "btnAddAudioFile";
            this.btnAddAudioFile.Size = new System.Drawing.Size(64, 23);
            this.btnAddAudioFile.TabIndex = 4;
            this.btnAddAudioFile.Text = "Add Audio";
            this.btnAddAudioFile.UseVisualStyleBackColor = true;
            this.btnAddAudioFile.Click += new System.EventHandler(this.btnAddAudioFile_Click);
            // 
            // gbDateBrowser
            // 
            this.gbDateBrowser.Controls.Add(this.btnRepeatEvents);
            this.gbDateBrowser.Controls.Add(this.btnCopyEvents);
            this.gbDateBrowser.Controls.Add(this.mntCalendarDateBrowser);
            this.gbDateBrowser.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDateBrowser.Location = new System.Drawing.Point(0, 0);
            this.gbDateBrowser.Name = "gbDateBrowser";
            this.gbDateBrowser.Size = new System.Drawing.Size(237, 211);
            this.gbDateBrowser.TabIndex = 1;
            this.gbDateBrowser.TabStop = false;
            this.gbDateBrowser.Text = "Date Browser";
            // 
            // btnRepeatEvents
            // 
            this.btnRepeatEvents.Location = new System.Drawing.Point(122, 182);
            this.btnRepeatEvents.Name = "btnRepeatEvents";
            this.btnRepeatEvents.Size = new System.Drawing.Size(108, 23);
            this.btnRepeatEvents.TabIndex = 2;
            this.btnRepeatEvents.Text = "Repeat";
            this.btnRepeatEvents.UseVisualStyleBackColor = true;
            this.btnRepeatEvents.Click += new System.EventHandler(this.btnRepeatEvents_Click);
            // 
            // btnCopyEvents
            // 
            this.btnCopyEvents.Location = new System.Drawing.Point(3, 182);
            this.btnCopyEvents.Name = "btnCopyEvents";
            this.btnCopyEvents.Size = new System.Drawing.Size(109, 23);
            this.btnCopyEvents.TabIndex = 1;
            this.btnCopyEvents.Text = "Copy Events";
            this.btnCopyEvents.UseVisualStyleBackColor = true;
            this.btnCopyEvents.Click += new System.EventHandler(this.btnCopyEvents_Click);
            // 
            // mntCalendarDateBrowser
            // 
            this.mntCalendarDateBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mntCalendarDateBrowser.Location = new System.Drawing.Point(3, 16);
            this.mntCalendarDateBrowser.MaxSelectionCount = 31;
            this.mntCalendarDateBrowser.Name = "mntCalendarDateBrowser";
            this.mntCalendarDateBrowser.TabIndex = 0;
            this.mntCalendarDateBrowser.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mntCalendarDateBrowser_DateChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(246, 3);
            this.splitContainer1.MinimumSize = new System.Drawing.Size(300, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbScheduledEvents);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(793, 537);
            this.splitContainer1.SplitterDistance = 575;
            this.splitContainer1.TabIndex = 4;
            // 
            // gbScheduledEvents
            // 
            this.gbScheduledEvents.Controls.Add(this.radBtnViewAllEvents);
            this.gbScheduledEvents.Controls.Add(this.radBtnViewSelectedDateOnly);
            this.gbScheduledEvents.Controls.Add(this.dgvScheduledEvents);
            this.gbScheduledEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbScheduledEvents.Location = new System.Drawing.Point(0, 0);
            this.gbScheduledEvents.MinimumSize = new System.Drawing.Size(300, 0);
            this.gbScheduledEvents.Name = "gbScheduledEvents";
            this.gbScheduledEvents.Size = new System.Drawing.Size(575, 537);
            this.gbScheduledEvents.TabIndex = 1;
            this.gbScheduledEvents.TabStop = false;
            this.gbScheduledEvents.Text = "Scheduled Events";
            // 
            // radBtnViewAllEvents
            // 
            this.radBtnViewAllEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radBtnViewAllEvents.AutoSize = true;
            this.radBtnViewAllEvents.Location = new System.Drawing.Point(166, 15);
            this.radBtnViewAllEvents.Name = "radBtnViewAllEvents";
            this.radBtnViewAllEvents.Size = new System.Drawing.Size(152, 17);
            this.radBtnViewAllEvents.TabIndex = 2;
            this.radBtnViewAllEvents.TabStop = true;
            this.radBtnViewAllEvents.Text = "View All Scheduled Events";
            this.radBtnViewAllEvents.UseVisualStyleBackColor = true;
            this.radBtnViewAllEvents.CheckedChanged += new System.EventHandler(this.radBtnViewAllEvents_CheckedChanged);
            // 
            // radBtnViewSelectedDateOnly
            // 
            this.radBtnViewSelectedDateOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radBtnViewSelectedDateOnly.AutoSize = true;
            this.radBtnViewSelectedDateOnly.Location = new System.Drawing.Point(6, 15);
            this.radBtnViewSelectedDateOnly.Name = "radBtnViewSelectedDateOnly";
            this.radBtnViewSelectedDateOnly.Size = new System.Drawing.Size(154, 17);
            this.radBtnViewSelectedDateOnly.TabIndex = 1;
            this.radBtnViewSelectedDateOnly.TabStop = true;
            this.radBtnViewSelectedDateOnly.Text = "View Selected Date(s) Only";
            this.radBtnViewSelectedDateOnly.UseVisualStyleBackColor = true;
            this.radBtnViewSelectedDateOnly.CheckedChanged += new System.EventHandler(this.radBtnViewSelectedDateOnly_CheckedChanged);
            // 
            // dgvScheduledEvents
            // 
            this.dgvScheduledEvents.AllowUserToAddRows = false;
            this.dgvScheduledEvents.AllowUserToOrderColumns = true;
            this.dgvScheduledEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvScheduledEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvScheduledEvents.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvScheduledEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScheduledEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GUID,
            this.StartPlay,
            this.AudioFile,
            this.AudioFileFullPath,
            this.PlayDuration,
            this.StartRecord,
            this.RecordDuration});
            this.dgvScheduledEvents.Location = new System.Drawing.Point(6, 39);
            this.dgvScheduledEvents.MinimumSize = new System.Drawing.Size(300, 0);
            this.dgvScheduledEvents.Name = "dgvScheduledEvents";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScheduledEvents.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvScheduledEvents.RowTemplate.Height = 24;
            this.dgvScheduledEvents.Size = new System.Drawing.Size(563, 492);
            this.dgvScheduledEvents.TabIndex = 0;
            this.dgvScheduledEvents.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScheduledEvents_CellValueChanged);
            this.dgvScheduledEvents.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvScheduledEvents_RowPostPaint);
            this.dgvScheduledEvents.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScheduledEvents_CellContentDoubleClick);
            this.dgvScheduledEvents.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvScheduledEvents_EditingControlShowing);
            // 
            // GUID
            // 
            this.GUID.DataPropertyName = "GUID";
            this.GUID.HeaderText = "GUID";
            this.GUID.Name = "GUID";
            this.GUID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GUID.Visible = false;
            // 
            // StartPlay
            // 
            this.StartPlay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.StartPlay.DataPropertyName = "StartPlay";
            this.StartPlay.FillWeight = 85F;
            this.StartPlay.HeaderText = "Start Play (Date/Time)";
            this.StartPlay.MinimumWidth = 70;
            this.StartPlay.Name = "StartPlay";
            this.StartPlay.ReadOnly = true;
            this.StartPlay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StartPlay.ToolTipText = "Double-click a cell to enter a new date/time";
            this.StartPlay.Width = 70;
            // 
            // AudioFile
            // 
            this.AudioFile.DataPropertyName = "AudioFile";
            this.AudioFile.FillWeight = 125F;
            this.AudioFile.HeaderText = "Audio File";
            this.AudioFile.Name = "AudioFile";
            this.AudioFile.ReadOnly = true;
            this.AudioFile.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AudioFile.ToolTipText = "Double-click a cell to change audio file";
            // 
            // AudioFileFullPath
            // 
            this.AudioFileFullPath.DataPropertyName = "AudioFileFullPath";
            this.AudioFileFullPath.HeaderText = "AudioFileFullPath";
            this.AudioFileFullPath.Name = "AudioFileFullPath";
            this.AudioFileFullPath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AudioFileFullPath.Visible = false;
            // 
            // PlayDuration
            // 
            this.PlayDuration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.PlayDuration.DataPropertyName = "PlayDuration";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = null;
            this.PlayDuration.DefaultCellStyle = dataGridViewCellStyle1;
            this.PlayDuration.FillWeight = 35F;
            this.PlayDuration.HeaderText = "Play Duration (Seconds)";
            this.PlayDuration.MaxInputLength = 5;
            this.PlayDuration.MinimumWidth = 60;
            this.PlayDuration.Name = "PlayDuration";
            this.PlayDuration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlayDuration.Width = 60;
            // 
            // StartRecord
            // 
            this.StartRecord.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.StartRecord.DataPropertyName = "StartRecord";
            this.StartRecord.FillWeight = 85F;
            this.StartRecord.HeaderText = "Start Record (Date/Time)";
            this.StartRecord.MinimumWidth = 70;
            this.StartRecord.Name = "StartRecord";
            this.StartRecord.ReadOnly = true;
            this.StartRecord.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StartRecord.ToolTipText = "Double-click a cell to enter a new date/time";
            this.StartRecord.Width = 70;
            // 
            // RecordDuration
            // 
            this.RecordDuration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.RecordDuration.DataPropertyName = "RecordDuration";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = null;
            this.RecordDuration.DefaultCellStyle = dataGridViewCellStyle2;
            this.RecordDuration.FillWeight = 35F;
            this.RecordDuration.HeaderText = "Record Duration (Seconds)";
            this.RecordDuration.MaxInputLength = 5;
            this.RecordDuration.MinimumWidth = 60;
            this.RecordDuration.Name = "RecordDuration";
            this.RecordDuration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RecordDuration.Width = 60;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabCreateEvents);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(214, 537);
            this.tabControl2.TabIndex = 2;
            // 
            // tabCreateEvents
            // 
            this.tabCreateEvents.BackColor = System.Drawing.Color.White;
            this.tabCreateEvents.Controls.Add(this.panel2);
            this.tabCreateEvents.Location = new System.Drawing.Point(4, 22);
            this.tabCreateEvents.Name = "tabCreateEvents";
            this.tabCreateEvents.Padding = new System.Windows.Forms.Padding(3);
            this.tabCreateEvents.Size = new System.Drawing.Size(206, 511);
            this.tabCreateEvents.TabIndex = 1;
            this.tabCreateEvents.Text = "Create Events";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCreateEvent);
            this.panel2.Controls.Add(this.gbCreateEventRecord);
            this.panel2.Controls.Add(this.gbCreateEventPlay);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 227);
            this.panel2.TabIndex = 17;
            // 
            // btnCreateEvent
            // 
            this.btnCreateEvent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCreateEvent.Location = new System.Drawing.Point(0, 204);
            this.btnCreateEvent.Name = "btnCreateEvent";
            this.btnCreateEvent.Size = new System.Drawing.Size(200, 23);
            this.btnCreateEvent.TabIndex = 3;
            this.btnCreateEvent.Text = "Create Event";
            this.btnCreateEvent.UseVisualStyleBackColor = true;
            this.btnCreateEvent.Click += new System.EventHandler(this.btnCreateEvent_Click);
            // 
            // gbCreateEventRecord
            // 
            this.gbCreateEventRecord.BackColor = System.Drawing.Color.Transparent;
            this.gbCreateEventRecord.Controls.Add(this.chkBoxRecordEnabled);
            this.gbCreateEventRecord.Controls.Add(this.txtCreateEventRecordDuration);
            this.gbCreateEventRecord.Controls.Add(this.dtpCreateEventStartRecord);
            this.gbCreateEventRecord.Controls.Add(this.lblCreateEventRecordDuration);
            this.gbCreateEventRecord.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCreateEventRecord.Location = new System.Drawing.Point(0, 98);
            this.gbCreateEventRecord.Name = "gbCreateEventRecord";
            this.gbCreateEventRecord.Size = new System.Drawing.Size(200, 98);
            this.gbCreateEventRecord.TabIndex = 16;
            this.gbCreateEventRecord.TabStop = false;
            this.gbCreateEventRecord.Text = "Record";
            // 
            // chkBoxRecordEnabled
            // 
            this.chkBoxRecordEnabled.AutoSize = true;
            this.chkBoxRecordEnabled.Checked = true;
            this.chkBoxRecordEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxRecordEnabled.Location = new System.Drawing.Point(9, 19);
            this.chkBoxRecordEnabled.Name = "chkBoxRecordEnabled";
            this.chkBoxRecordEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkBoxRecordEnabled.TabIndex = 16;
            this.chkBoxRecordEnabled.Text = "Enabled";
            this.chkBoxRecordEnabled.UseVisualStyleBackColor = true;
            this.chkBoxRecordEnabled.CheckedChanged += new System.EventHandler(this.chkBoxRecordEnabled_CheckedChanged);
            // 
            // txtCreateEventRecordDuration
            // 
            this.txtCreateEventRecordDuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreateEventRecordDuration.Location = new System.Drawing.Point(126, 68);
            this.txtCreateEventRecordDuration.MaxLength = 5;
            this.txtCreateEventRecordDuration.Name = "txtCreateEventRecordDuration";
            this.txtCreateEventRecordDuration.Size = new System.Drawing.Size(68, 20);
            this.txtCreateEventRecordDuration.TabIndex = 15;
            this.txtCreateEventRecordDuration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCreateEventRecordDuration_KeyPress);
            // 
            // dtpCreateEventStartRecord
            // 
            this.dtpCreateEventStartRecord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpCreateEventStartRecord.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpCreateEventStartRecord.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCreateEventStartRecord.Location = new System.Drawing.Point(6, 42);
            this.dtpCreateEventStartRecord.Name = "dtpCreateEventStartRecord";
            this.dtpCreateEventStartRecord.Size = new System.Drawing.Size(186, 20);
            this.dtpCreateEventStartRecord.TabIndex = 12;
            // 
            // lblCreateEventRecordDuration
            // 
            this.lblCreateEventRecordDuration.AutoSize = true;
            this.lblCreateEventRecordDuration.Location = new System.Drawing.Point(6, 71);
            this.lblCreateEventRecordDuration.Name = "lblCreateEventRecordDuration";
            this.lblCreateEventRecordDuration.Size = new System.Drawing.Size(98, 13);
            this.lblCreateEventRecordDuration.TabIndex = 14;
            this.lblCreateEventRecordDuration.Text = "Duration (Seconds)";
            this.lblCreateEventRecordDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbCreateEventPlay
            // 
            this.gbCreateEventPlay.BackColor = System.Drawing.Color.Transparent;
            this.gbCreateEventPlay.Controls.Add(this.chkBoxPlayEnabled);
            this.gbCreateEventPlay.Controls.Add(this.dtpCreateEventStartPlay);
            this.gbCreateEventPlay.Controls.Add(this.txtCreateEventPlayDuration);
            this.gbCreateEventPlay.Controls.Add(this.lblCreateEventPlayDuration);
            this.gbCreateEventPlay.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCreateEventPlay.Location = new System.Drawing.Point(0, 0);
            this.gbCreateEventPlay.Name = "gbCreateEventPlay";
            this.gbCreateEventPlay.Size = new System.Drawing.Size(200, 98);
            this.gbCreateEventPlay.TabIndex = 7;
            this.gbCreateEventPlay.TabStop = false;
            this.gbCreateEventPlay.Text = "Play";
            // 
            // chkBoxPlayEnabled
            // 
            this.chkBoxPlayEnabled.AutoSize = true;
            this.chkBoxPlayEnabled.Checked = true;
            this.chkBoxPlayEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxPlayEnabled.Location = new System.Drawing.Point(9, 20);
            this.chkBoxPlayEnabled.Name = "chkBoxPlayEnabled";
            this.chkBoxPlayEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkBoxPlayEnabled.TabIndex = 11;
            this.chkBoxPlayEnabled.Text = "Enabled";
            this.chkBoxPlayEnabled.UseVisualStyleBackColor = true;
            this.chkBoxPlayEnabled.CheckedChanged += new System.EventHandler(this.chkBoxPlayEnabled_CheckedChanged);
            // 
            // dtpCreateEventStartPlay
            // 
            this.dtpCreateEventStartPlay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpCreateEventStartPlay.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpCreateEventStartPlay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCreateEventStartPlay.Location = new System.Drawing.Point(6, 43);
            this.dtpCreateEventStartPlay.Name = "dtpCreateEventStartPlay";
            this.dtpCreateEventStartPlay.Size = new System.Drawing.Size(187, 20);
            this.dtpCreateEventStartPlay.TabIndex = 7;
            // 
            // txtCreateEventPlayDuration
            // 
            this.txtCreateEventPlayDuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreateEventPlayDuration.Location = new System.Drawing.Point(126, 69);
            this.txtCreateEventPlayDuration.MaxLength = 5;
            this.txtCreateEventPlayDuration.Name = "txtCreateEventPlayDuration";
            this.txtCreateEventPlayDuration.Size = new System.Drawing.Size(68, 20);
            this.txtCreateEventPlayDuration.TabIndex = 7;
            this.txtCreateEventPlayDuration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCreateEventPlayDuration_KeyPress);
            // 
            // lblCreateEventPlayDuration
            // 
            this.lblCreateEventPlayDuration.AutoSize = true;
            this.lblCreateEventPlayDuration.Location = new System.Drawing.Point(6, 72);
            this.lblCreateEventPlayDuration.Name = "lblCreateEventPlayDuration";
            this.lblCreateEventPlayDuration.Size = new System.Drawing.Size(98, 13);
            this.lblCreateEventPlayDuration.TabIndex = 10;
            this.lblCreateEventPlayDuration.Text = "Duration (Seconds)";
            this.lblCreateEventPlayDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabScheduler);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1050, 572);
            this.tabControl1.TabIndex = 5;
            // 
            // tabScheduler
            // 
            this.tabScheduler.BackColor = System.Drawing.SystemColors.Control;
            this.tabScheduler.Controls.Add(this.pnlDateBrowserAndAudio);
            this.tabScheduler.Controls.Add(this.splitContainer1);
            this.tabScheduler.Location = new System.Drawing.Point(4, 25);
            this.tabScheduler.Name = "tabScheduler";
            this.tabScheduler.Padding = new System.Windows.Forms.Padding(3);
            this.tabScheduler.Size = new System.Drawing.Size(1042, 543);
            this.tabScheduler.TabIndex = 0;
            this.tabScheduler.Text = "Scheduler";
            this.tabScheduler.UseVisualStyleBackColor = true;
            // 
            // ofdAddAudioFile
            // 
            this.ofdAddAudioFile.Filter = "WAV|*.wav";
            this.ofdAddAudioFile.Multiselect = true;
            this.ofdAddAudioFile.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdAddAudioFile_FileOk);
            // 
            // sfdSaveScheduleAs
            // 
            this.sfdSaveScheduleAs.Filter = "XML|*.xml";
            this.sfdSaveScheduleAs.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdSaveScheduleAs_FileOk);
            // 
            // ofdOpenSavedSchedule
            // 
            this.ofdOpenSavedSchedule.Filter = "XML|*.xml";
            this.ofdOpenSavedSchedule.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdOpenSavedSchedule_FileOk);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Scheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1050, 618);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statStrip1);
            this.Controls.Add(this.mnuMainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMainMenu;
            this.MinimumSize = new System.Drawing.Size(859, 498);
            this.Name = "Scheduler";
            this.Text = "Hoot!";
            this.mnuMainMenu.ResumeLayout(false);
            this.mnuMainMenu.PerformLayout();
            this.pnlDateBrowserAndAudio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wmpPlayer)).EndInit();
            this.gbAvailableAudioFiles.ResumeLayout(false);
            this.gbDateBrowser.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.gbScheduledEvents.ResumeLayout(false);
            this.gbScheduledEvents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScheduledEvents)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabCreateEvents.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.gbCreateEventRecord.ResumeLayout(false);
            this.gbCreateEventRecord.PerformLayout();
            this.gbCreateEventPlay.ResumeLayout(false);
            this.gbCreateEventPlay.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabScheduler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statStrip1;
        private System.Windows.Forms.MenuStrip mnuMainMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendScheduleToDesktopToolStripMenuItem;
        private System.Windows.Forms.Panel pnlDateBrowserAndAudio;
        private System.Windows.Forms.MonthCalendar mntCalendarDateBrowser;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvScheduledEvents;
        private System.Windows.Forms.GroupBox gbDateBrowser;
        private System.Windows.Forms.GroupBox gbAvailableAudioFiles;
        private System.Windows.Forms.GroupBox gbScheduledEvents;
        private System.Windows.Forms.RadioButton radBtnViewAllEvents;
        private System.Windows.Forms.RadioButton radBtnViewSelectedDateOnly;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabScheduler;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabCreateEvents;
        private System.Windows.Forms.Button btnCreateEvent;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dtpCreateEventStartPlay;
        private System.Windows.Forms.TextBox txtCreateEventPlayDuration;
        private System.Windows.Forms.Label lblCreateEventPlayDuration;
        private System.Windows.Forms.TextBox txtCreateEventRecordDuration;
        private System.Windows.Forms.Label lblCreateEventRecordDuration;
        private System.Windows.Forms.DateTimePicker dtpCreateEventStartRecord;
        private System.Windows.Forms.GroupBox gbCreateEventPlay;
        private System.Windows.Forms.GroupBox gbCreateEventRecord;
        private System.Windows.Forms.Button btnAddAudioFile;
        private System.Windows.Forms.TreeView tvAvailableAudioFiles;
        private AxWMPLib.AxWindowsMediaPlayer wmpPlayer;
        private System.Windows.Forms.CheckBox chkBoxRecordEnabled;
        private System.Windows.Forms.CheckBox chkBoxPlayEnabled;
        private System.Windows.Forms.OpenFileDialog ofdAddAudioFile;
        private System.Windows.Forms.Button btnCreateCategory;
        private System.Windows.Forms.Button btnDeleteAudioFile;
        private System.Windows.Forms.ToolStripMenuItem openMyScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSharedScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMyScheduleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveSharedScheduleToolStripMenuItem1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRepeatEvents;
        private System.Windows.Forms.Button btnCopyEvents;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfdSaveScheduleAs;
        private System.Windows.Forms.ToolStripMenuItem savedScheduleToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdOpenSavedSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn GUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartPlay;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioFileFullPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordDuration;
        private System.IO.FileSystemWatcher fileSystemWatcher1;

    }
}

