namespace Tsanie.FlvBugger {
    partial class FlvMain {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlvMain));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTimeStamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCodec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFrameType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnOffset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolMenuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolMenuCopyTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMenuRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolLabelProgress = new System.Windows.Forms.ToolStripLabel();
            this.toolLabelMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolComboFolder = new System.Windows.Forms.ToolStripComboBox();
            this.toolButtonFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonRemove = new System.Windows.Forms.ToolStripButton();
            this.toolButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonPlayer = new System.Windows.Forms.ToolStripButton();
            this.toolButtonSplit = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolTextSplit = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolConfig = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolComboFrame = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTransparent = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_100 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_80 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_60 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_40 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMenuTop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolButtonBlack = new System.Windows.Forms.ToolStripSplitButton();
            this.toolBlackTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRateFore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTextRate = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolTextSpeed = new System.Windows.Forms.ToolStripTextBox();
            this.toolButtonSpeed = new System.Windows.Forms.ToolStripSplitButton();
            this.menuRate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSpeedRepair = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolTextTime = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolButtonRepair = new System.Windows.Forms.ToolStripButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolButtonFore = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnID,
            this.columnType,
            this.columnTimeStamp,
            this.columnCodec,
            this.columnFrameType,
            this.columnOffset,
            this.columnSize});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(510, 231);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            // 
            // columnID
            // 
            this.columnID.Text = "#";
            this.columnID.Width = 40;
            // 
            // columnType
            // 
            this.columnType.Text = "类型";
            this.columnType.Width = 52;
            // 
            // columnTimeStamp
            // 
            this.columnTimeStamp.Text = "时间戳";
            this.columnTimeStamp.Width = 76;
            // 
            // columnCodec
            // 
            this.columnCodec.Text = "编码";
            this.columnCodec.Width = 70;
            // 
            // columnFrameType
            // 
            this.columnFrameType.Text = "帧类型";
            this.columnFrameType.Width = 80;
            // 
            // columnOffset
            // 
            this.columnOffset.Text = "数据位置";
            this.columnOffset.Width = 80;
            // 
            // columnSize
            // 
            this.columnSize.Text = "帧大小";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMenuInfo,
            this.toolStripSeparator4,
            this.toolMenuCopyTime,
            this.toolMenuRemove});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 76);
            // 
            // toolMenuInfo
            // 
            this.toolMenuInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolMenuInfo.Name = "toolMenuInfo";
            this.toolMenuInfo.Size = new System.Drawing.Size(124, 22);
            this.toolMenuInfo.Text = "查看详细";
            this.toolMenuInfo.Click += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(121, 6);
            // 
            // toolMenuCopyTime
            // 
            this.toolMenuCopyTime.Name = "toolMenuCopyTime";
            this.toolMenuCopyTime.Size = new System.Drawing.Size(124, 22);
            this.toolMenuCopyTime.Text = "复制时间";
            this.toolMenuCopyTime.Click += new System.EventHandler(this.toolMenuCopyTime_Click);
            // 
            // toolMenuRemove
            // 
            this.toolMenuRemove.Name = "toolMenuRemove";
            this.toolMenuRemove.Size = new System.Drawing.Size(124, 22);
            this.toolMenuRemove.Text = "删除帧";
            this.toolMenuRemove.Click += new System.EventHandler(this.toolButtonRemove_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLabelProgress,
            this.toolLabelMessage,
            this.toolProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 50);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(510, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Resize += new System.EventHandler(this.statusStrip1_Resize);
            // 
            // toolLabelProgress
            // 
            this.toolLabelProgress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolLabelProgress.Image = global::Tsanie.FlvBugger.Properties.Resources.loading;
            this.toolLabelProgress.Margin = new System.Windows.Forms.Padding(4, 2, 0, 0);
            this.toolLabelProgress.Name = "toolLabelProgress";
            this.toolLabelProgress.Size = new System.Drawing.Size(16, 20);
            this.toolLabelProgress.Visible = false;
            // 
            // toolLabelMessage
            // 
            this.toolLabelMessage.AutoSize = false;
            this.toolLabelMessage.Margin = new System.Windows.Forms.Padding(4, 3, 0, 2);
            this.toolLabelMessage.Name = "toolLabelMessage";
            this.toolLabelMessage.Size = new System.Drawing.Size(330, 17);
            this.toolLabelMessage.Text = "请拖入flv文件或者mp4、mkv文件...";
            this.toolLabelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolProgress
            // 
            this.toolProgress.Name = "toolProgress";
            this.toolProgress.Size = new System.Drawing.Size(100, 16);
            this.toolProgress.Visible = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Enabled = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolComboFolder,
            this.toolButtonFolder,
            this.toolStripSeparator5,
            this.toolButtonRemove,
            this.toolButtonSave,
            this.toolStripSeparator3,
            this.toolButtonPlayer,
            this.toolButtonSplit});
            this.toolStrip2.Location = new System.Drawing.Point(3, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(429, 25);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(71, 22);
            this.toolStripLabel2.Text = "输出文件夹:";
            // 
            // toolComboFolder
            // 
            this.toolComboFolder.AutoSize = false;
            this.toolComboFolder.Name = "toolComboFolder";
            this.toolComboFolder.Size = new System.Drawing.Size(192, 25);
            // 
            // toolButtonFolder
            // 
            this.toolButtonFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonFolder.Image = global::Tsanie.FlvBugger.Properties.Resources.open;
            this.toolButtonFolder.Name = "toolButtonFolder";
            this.toolButtonFolder.Size = new System.Drawing.Size(23, 22);
            this.toolButtonFolder.Text = "浏览文件夹";
            this.toolButtonFolder.Click += new System.EventHandler(this.toolButtonFolder_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolButtonRemove
            // 
            this.toolButtonRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonRemove.Image = global::Tsanie.FlvBugger.Properties.Resources.remove;
            this.toolButtonRemove.Name = "toolButtonRemove";
            this.toolButtonRemove.Size = new System.Drawing.Size(23, 22);
            this.toolButtonRemove.Text = "删除帧";
            this.toolButtonRemove.Click += new System.EventHandler(this.toolButtonRemove_Click);
            // 
            // toolButtonSave
            // 
            this.toolButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonSave.Image = global::Tsanie.FlvBugger.Properties.Resources.save;
            this.toolButtonSave.Name = "toolButtonSave";
            this.toolButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolButtonSave.Text = "保存修改";
            this.toolButtonSave.Click += new System.EventHandler(this.toolButtonSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolButtonPlayer
            // 
            this.toolButtonPlayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonPlayer.Image = global::Tsanie.FlvBugger.Properties.Resources.player;
            this.toolButtonPlayer.Name = "toolButtonPlayer";
            this.toolButtonPlayer.Size = new System.Drawing.Size(23, 22);
            this.toolButtonPlayer.Text = "打开播放器";
            this.toolButtonPlayer.Click += new System.EventHandler(this.toolButtonPlayer_Click);
            // 
            // toolButtonSplit
            // 
            this.toolButtonSplit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel5,
            this.toolTextSplit});
            this.toolButtonSplit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolButtonSplit.ForeColor = System.Drawing.Color.Maroon;
            this.toolButtonSplit.Name = "toolButtonSplit";
            this.toolButtonSplit.Size = new System.Drawing.Size(48, 22);
            this.toolButtonSplit.Text = "分割";
            this.toolButtonSplit.ButtonClick += new System.EventHandler(this.toolButtonSplit_ButtonClick);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(95, 17);
            this.toolStripLabel5.Text = "分割长度（秒）:";
            // 
            // toolTextSplit
            // 
            this.toolTextSplit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolTextSplit.Name = "toolTextSplit";
            this.toolTextSplit.Size = new System.Drawing.Size(100, 21);
            this.toolTextSplit.Text = "300.0";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolConfig
            // 
            this.toolConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolComboFrame,
            this.toolStripSeparator6,
            this.toolShow,
            this.toolTransparent,
            this.toolMenuTop});
            this.toolConfig.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolConfig.Name = "toolConfig";
            this.toolConfig.Size = new System.Drawing.Size(48, 22);
            this.toolConfig.Text = "设置";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem1.Text = "生成帧分辨率";
            // 
            // toolComboFrame
            // 
            this.toolComboFrame.Items.AddRange(new object[] {
            "512x384",
            "512x288"});
            this.toolComboFrame.Name = "toolComboFrame";
            this.toolComboFrame.Size = new System.Drawing.Size(121, 25);
            this.toolComboFrame.Text = "512x384";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(178, 6);
            // 
            // toolShow
            // 
            this.toolShow.CheckOnClick = true;
            this.toolShow.Name = "toolShow";
            this.toolShow.Size = new System.Drawing.Size(181, 22);
            this.toolShow.Text = "显示命令行";
            // 
            // toolTransparent
            // 
            this.toolTransparent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_100,
            this.tool_80,
            this.tool_60,
            this.tool_40,
            this.tool_20});
            this.toolTransparent.Name = "toolTransparent";
            this.toolTransparent.Size = new System.Drawing.Size(181, 22);
            this.toolTransparent.Text = "透明度";
            // 
            // tool_100
            // 
            this.tool_100.Checked = true;
            this.tool_100.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tool_100.Name = "tool_100";
            this.tool_100.Size = new System.Drawing.Size(108, 22);
            this.tool_100.Text = "100%";
            this.tool_100.Click += new System.EventHandler(this.toolTransparent_Click);
            // 
            // tool_80
            // 
            this.tool_80.Name = "tool_80";
            this.tool_80.Size = new System.Drawing.Size(108, 22);
            this.tool_80.Text = "80%";
            this.tool_80.Click += new System.EventHandler(this.toolTransparent_Click);
            // 
            // tool_60
            // 
            this.tool_60.Name = "tool_60";
            this.tool_60.Size = new System.Drawing.Size(108, 22);
            this.tool_60.Text = "60%";
            this.tool_60.Click += new System.EventHandler(this.toolTransparent_Click);
            // 
            // tool_40
            // 
            this.tool_40.Name = "tool_40";
            this.tool_40.Size = new System.Drawing.Size(108, 22);
            this.tool_40.Text = "40%";
            this.tool_40.Click += new System.EventHandler(this.toolTransparent_Click);
            // 
            // tool_20
            // 
            this.tool_20.Name = "tool_20";
            this.tool_20.Size = new System.Drawing.Size(108, 22);
            this.tool_20.Text = "20%";
            this.tool_20.Click += new System.EventHandler(this.toolTransparent_Click);
            // 
            // toolMenuTop
            // 
            this.toolMenuTop.Checked = true;
            this.toolMenuTop.CheckOnClick = true;
            this.toolMenuTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolMenuTop.Name = "toolMenuTop";
            this.toolMenuTop.Size = new System.Drawing.Size(181, 22);
            this.toolMenuTop.Text = "窗口置顶";
            this.toolMenuTop.Click += new System.EventHandler(this.toolMenuTop_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Enabled = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolButtonBlack,
            this.toolTextRate,
            this.toolStripLabel1,
            this.toolTextSpeed,
            this.toolButtonSpeed,
            this.toolStripLabel4,
            this.toolTextTime,
            this.toolStripLabel3,
            this.toolButtonFore,
            this.toolButtonRepair});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(488, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolButtonBlack
            // 
            this.toolButtonBlack.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBlackTime,
            this.toolStripSeparator7,
            this.menuRateFore});
            this.toolButtonBlack.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolButtonBlack.ForeColor = System.Drawing.Color.Maroon;
            this.toolButtonBlack.Name = "toolButtonBlack";
            this.toolButtonBlack.Size = new System.Drawing.Size(72, 22);
            this.toolButtonBlack.Text = "后黑处理";
            this.toolButtonBlack.ButtonClick += new System.EventHandler(this.toolButtonBlack_Click);
            // 
            // toolBlackTime
            // 
            this.toolBlackTime.Name = "toolBlackTime";
            this.toolBlackTime.Size = new System.Drawing.Size(170, 22);
            this.toolBlackTime.Text = "根据时间后黑";
            this.toolBlackTime.Click += new System.EventHandler(this.menuTimeBlack_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(167, 6);
            // 
            // menuRateFore
            // 
            this.menuRateFore.Image = global::Tsanie.FlvBugger.Properties.Resources.hot;
            this.menuRateFore.Name = "menuRateFore";
            this.menuRateFore.Size = new System.Drawing.Size(170, 22);
            this.menuRateFore.Text = "码率前黑(无傲娇)";
            this.menuRateFore.Click += new System.EventHandler(this.menuRateFore_Click);
            // 
            // toolTextRate
            // 
            this.toolTextRate.AutoSize = false;
            this.toolTextRate.ForeColor = System.Drawing.Color.Gray;
            this.toolTextRate.Name = "toolTextRate";
            this.toolTextRate.Size = new System.Drawing.Size(30, 25);
            this.toolTextRate.Text = "500";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(62, 22);
            this.toolStripLabel1.Text = "Kbps，或";
            // 
            // toolTextSpeed
            // 
            this.toolTextSpeed.AutoSize = false;
            this.toolTextSpeed.ForeColor = System.Drawing.Color.Gray;
            this.toolTextSpeed.Name = "toolTextSpeed";
            this.toolTextSpeed.Size = new System.Drawing.Size(30, 25);
            this.toolTextSpeed.Text = "3.0";
            // 
            // toolButtonSpeed
            // 
            this.toolButtonSpeed.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRate,
            this.toolStripSeparator2,
            this.menuSpeedRepair});
            this.toolButtonSpeed.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolButtonSpeed.ForeColor = System.Drawing.Color.Maroon;
            this.toolButtonSpeed.Name = "toolButtonSpeed";
            this.toolButtonSpeed.Size = new System.Drawing.Size(72, 22);
            this.toolButtonSpeed.Text = "倍速处理";
            this.toolButtonSpeed.ButtonClick += new System.EventHandler(this.menuSpeed_Click);
            // 
            // menuRate
            // 
            this.menuRate.Name = "menuRate";
            this.menuRate.Size = new System.Drawing.Size(172, 22);
            this.menuRate.Text = "根据码率计算倍率";
            this.menuRate.Click += new System.EventHandler(this.menuRate_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // menuSpeedRepair
            // 
            this.menuSpeedRepair.Image = global::Tsanie.FlvBugger.Properties.Resources.repair;
            this.menuSpeedRepair.Name = "menuSpeedRepair";
            this.menuSpeedRepair.Size = new System.Drawing.Size(172, 22);
            this.menuSpeedRepair.Text = "倍率修复";
            this.menuSpeedRepair.Click += new System.EventHandler(this.menuSpeedRepair_Click);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel4.Text = "，或前置";
            // 
            // toolTextTime
            // 
            this.toolTextTime.AutoSize = false;
            this.toolTextTime.ForeColor = System.Drawing.Color.Gray;
            this.toolTextTime.Name = "toolTextTime";
            this.toolTextTime.Size = new System.Drawing.Size(40, 25);
            this.toolTextTime.Text = "420.0";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(20, 22);
            this.toolStripLabel3.Text = "秒";
            // 
            // toolButtonRepair
            // 
            this.toolButtonRepair.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolButtonRepair.ForeColor = System.Drawing.Color.Maroon;
            this.toolButtonRepair.Image = global::Tsanie.FlvBugger.Properties.Resources.repair;
            this.toolButtonRepair.Name = "toolButtonRepair";
            this.toolButtonRepair.Size = new System.Drawing.Size(52, 22);
            this.toolButtonRepair.Text = "修复";
            this.toolButtonRepair.Click += new System.EventHandler(this.menuTimeRepair_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "选择视频输出文件夹";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip2);
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip3);
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.listView1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(510, 231);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(510, 303);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolConfig});
            this.toolStrip3.Location = new System.Drawing.Point(432, 25);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(60, 25);
            this.toolStrip3.TabIndex = 6;
            // 
            // toolButtonFore
            // 
            this.toolButtonFore.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolButtonFore.ForeColor = System.Drawing.Color.Maroon;
            this.toolButtonFore.Name = "toolButtonFore";
            this.toolButtonFore.Size = new System.Drawing.Size(36, 22);
            this.toolButtonFore.Text = "傲娇";
            this.toolButtonFore.Click += new System.EventHandler(this.menuTimeFore_Click);
            // 
            // FlvMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 303);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 195);
            this.Name = "FlvMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FlvParser";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FlvMain_FormClosing);
            this.Load += new System.EventHandler(this.FlvMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragEnter);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnID;
        private System.Windows.Forms.ColumnHeader columnType;
        private System.Windows.Forms.ColumnHeader columnTimeStamp;
        private System.Windows.Forms.ColumnHeader columnCodec;
        private System.Windows.Forms.ColumnHeader columnFrameType;
        private System.Windows.Forms.ColumnHeader columnOffset;
        private System.Windows.Forms.ColumnHeader columnSize;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolTextRate;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolTextSpeed;
        private System.Windows.Forms.ToolStripSplitButton toolButtonSpeed;
        private System.Windows.Forms.ToolStripMenuItem menuRate;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox toolTextTime;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox toolComboFolder;
        private System.Windows.Forms.ToolStripButton toolButtonFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripSplitButton toolConfig;
        private System.Windows.Forms.ToolStripMenuItem tool_100;
        private System.Windows.Forms.ToolStripMenuItem tool_80;
        private System.Windows.Forms.ToolStripMenuItem tool_60;
        private System.Windows.Forms.ToolStripMenuItem tool_40;
        private System.Windows.Forms.ToolStripMenuItem tool_20;
        private System.Windows.Forms.ToolStripSplitButton toolButtonBlack;
        private System.Windows.Forms.ToolStripMenuItem toolBlackTime;
        private System.Windows.Forms.ToolStripButton toolButtonRemove;
        private System.Windows.Forms.ToolStripButton toolButtonSave;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripLabel toolLabelProgress;
        private System.Windows.Forms.ToolStripStatusLabel toolLabelMessage;
        private System.Windows.Forms.ToolStripProgressBar toolProgress;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuSpeedRepair;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripMenuItem toolTransparent;
        private System.Windows.Forms.ToolStripMenuItem toolShow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolButtonPlayer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolMenuInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolMenuCopyTime;
        private System.Windows.Forms.ToolStripMenuItem toolMenuRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolButtonRepair;
        private System.Windows.Forms.ToolStripSplitButton toolButtonSplit;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox toolTextSplit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolMenuTop;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripComboBox toolComboFrame;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem menuRateFore;
        private System.Windows.Forms.ToolStripButton toolButtonFore;

    }
}

