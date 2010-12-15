namespace Layer_3_Conversion
{
    partial class frmLAYER
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLAYER));
            this.mstipLayer = new System.Windows.Forms.MenuStrip();
            this.打开文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.信令过滤ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.信令分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出系统EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sstipLayer = new System.Windows.Forms.StatusStrip();
            this.mstipLayerlbFilepath = new System.Windows.Forms.ToolStripStatusLabel();
            this.mstipLayerlbStrsql = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tcLayer = new System.Windows.Forms.TabControl();
            this.打开文件 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbLay3Message = new System.Windows.Forms.ListBox();
            this.lbMessagePara = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.信令过滤 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tvFilterOut = new System.Windows.Forms.TreeView();
            this.lbFilterIn = new System.Windows.Forms.ListBox();
            this.信令分析 = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.btnSaveScript = new System.Windows.Forms.Button();
            this.btnRunScript = new System.Windows.Forms.Button();
            this.rtxtSql = new System.Windows.Forms.RichTextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tvSql = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPara = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rtxtEvent = new System.Windows.Forms.RichTextBox();
            this.ttipLayer = new System.Windows.Forms.ToolStrip();
            this.ttipLayerbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.ttipLayerClearDB = new System.Windows.Forms.ToolStripButton();
            this.ttipLayerFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.ttipLayerGetXml = new System.Windows.Forms.ToolStripButton();
            this.ttipLayerWriteXml = new System.Windows.Forms.ToolStripButton();
            this.ttipLayerExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.mstipLayer.SuspendLayout();
            this.sstipLayer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tcLayer.SuspendLayout();
            this.打开文件.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.信令过滤.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.信令分析.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPara)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.ttipLayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mstipLayer
            // 
            this.mstipLayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开文件ToolStripMenuItem,
            this.信令过滤ToolStripMenuItem,
            this.信令分析ToolStripMenuItem,
            this.帮助HToolStripMenuItem,
            this.退出系统EToolStripMenuItem});
            this.mstipLayer.Location = new System.Drawing.Point(0, 0);
            this.mstipLayer.Name = "mstipLayer";
            this.mstipLayer.Size = new System.Drawing.Size(716, 24);
            this.mstipLayer.TabIndex = 1;
            this.mstipLayer.Text = "mstipLayer";
            // 
            // 打开文件ToolStripMenuItem
            // 
            this.打开文件ToolStripMenuItem.Name = "打开文件ToolStripMenuItem";
            this.打开文件ToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.打开文件ToolStripMenuItem.Text = "打开文件(&O)";
            this.打开文件ToolStripMenuItem.Click += new System.EventHandler(this.打开文件ToolStripMenuItem_Click);
            // 
            // 信令过滤ToolStripMenuItem
            // 
            this.信令过滤ToolStripMenuItem.Name = "信令过滤ToolStripMenuItem";
            this.信令过滤ToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.信令过滤ToolStripMenuItem.Text = "信令过滤(&F)";
            this.信令过滤ToolStripMenuItem.Click += new System.EventHandler(this.信令过滤ToolStripMenuItem_Click);
            // 
            // 信令分析ToolStripMenuItem
            // 
            this.信令分析ToolStripMenuItem.Name = "信令分析ToolStripMenuItem";
            this.信令分析ToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.信令分析ToolStripMenuItem.Text = "信令分析(&A)";
            this.信令分析ToolStripMenuItem.Click += new System.EventHandler(this.信令分析ToolStripMenuItem_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            this.帮助HToolStripMenuItem.Click += new System.EventHandler(this.帮助HToolStripMenuItem_Click);
            // 
            // 退出系统EToolStripMenuItem
            // 
            this.退出系统EToolStripMenuItem.Name = "退出系统EToolStripMenuItem";
            this.退出系统EToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.退出系统EToolStripMenuItem.Text = "退出系统(&E)";
            this.退出系统EToolStripMenuItem.Click += new System.EventHandler(this.退出系统EToolStripMenuItem_Click);
            // 
            // sstipLayer
            // 
            this.sstipLayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mstipLayerlbFilepath,
            this.mstipLayerlbStrsql});
            this.sstipLayer.Location = new System.Drawing.Point(0, 411);
            this.sstipLayer.Name = "sstipLayer";
            this.sstipLayer.Size = new System.Drawing.Size(716, 22);
            this.sstipLayer.TabIndex = 2;
            this.sstipLayer.Text = "sstipLayer";
            // 
            // mstipLayerlbFilepath
            // 
            this.mstipLayerlbFilepath.Name = "mstipLayerlbFilepath";
            this.mstipLayerlbFilepath.Size = new System.Drawing.Size(0, 17);
            // 
            // mstipLayerlbStrsql
            // 
            this.mstipLayerlbStrsql.Name = "mstipLayerlbStrsql";
            this.mstipLayerlbStrsql.Size = new System.Drawing.Size(0, 17);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tcLayer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ttipLayer, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(716, 387);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tcLayer
            // 
            this.tcLayer.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tcLayer.Controls.Add(this.打开文件);
            this.tcLayer.Controls.Add(this.信令过滤);
            this.tcLayer.Controls.Add(this.信令分析);
            this.tcLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcLayer.Location = new System.Drawing.Point(3, 25);
            this.tcLayer.Name = "tcLayer";
            this.tcLayer.SelectedIndex = 0;
            this.tcLayer.Size = new System.Drawing.Size(710, 359);
            this.tcLayer.TabIndex = 3;
            // 
            // 打开文件
            // 
            this.打开文件.Controls.Add(this.splitContainer1);
            this.打开文件.Location = new System.Drawing.Point(4, 4);
            this.打开文件.Name = "打开文件";
            this.打开文件.Padding = new System.Windows.Forms.Padding(3);
            this.打开文件.Size = new System.Drawing.Size(702, 334);
            this.打开文件.TabIndex = 0;
            this.打开文件.Text = "打开文件";
            this.打开文件.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbLay3Message);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbMessagePara);
            this.splitContainer1.Size = new System.Drawing.Size(696, 328);
            this.splitContainer1.SplitterDistance = 232;
            this.splitContainer1.TabIndex = 0;
            // 
            // lbLay3Message
            // 
            this.lbLay3Message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLay3Message.FormattingEnabled = true;
            this.lbLay3Message.ItemHeight = 12;
            this.lbLay3Message.Location = new System.Drawing.Point(0, 0);
            this.lbLay3Message.Name = "lbLay3Message";
            this.lbLay3Message.Size = new System.Drawing.Size(232, 328);
            this.lbLay3Message.TabIndex = 0;
            this.lbLay3Message.SelectedIndexChanged += new System.EventHandler(this.lbLay3Message_SelectedIndexChanged);
            // 
            // lbMessagePara
            // 
            this.lbMessagePara.ContextMenuStrip = this.contextMenuStrip1;
            this.lbMessagePara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMessagePara.FormattingEnabled = true;
            this.lbMessagePara.ItemHeight = 12;
            this.lbMessagePara.Location = new System.Drawing.Point(0, 0);
            this.lbMessagePara.Name = "lbMessagePara";
            this.lbMessagePara.Size = new System.Drawing.Size(460, 328);
            this.lbMessagePara.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 26);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // 信令过滤
            // 
            this.信令过滤.Controls.Add(this.splitContainer2);
            this.信令过滤.Location = new System.Drawing.Point(4, 4);
            this.信令过滤.Name = "信令过滤";
            this.信令过滤.Padding = new System.Windows.Forms.Padding(3);
            this.信令过滤.Size = new System.Drawing.Size(702, 334);
            this.信令过滤.TabIndex = 1;
            this.信令过滤.Text = "信令过滤";
            this.信令过滤.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tvFilterOut);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lbFilterIn);
            this.splitContainer2.Size = new System.Drawing.Size(696, 328);
            this.splitContainer2.SplitterDistance = 232;
            this.splitContainer2.TabIndex = 0;
            // 
            // tvFilterOut
            // 
            this.tvFilterOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFilterOut.Location = new System.Drawing.Point(0, 0);
            this.tvFilterOut.Name = "tvFilterOut";
            this.tvFilterOut.Size = new System.Drawing.Size(232, 328);
            this.tvFilterOut.TabIndex = 0;
            this.tvFilterOut.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFilterOut_AfterSelect);
            // 
            // lbFilterIn
            // 
            this.lbFilterIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFilterIn.FormattingEnabled = true;
            this.lbFilterIn.ItemHeight = 12;
            this.lbFilterIn.Location = new System.Drawing.Point(0, 0);
            this.lbFilterIn.Name = "lbFilterIn";
            this.lbFilterIn.Size = new System.Drawing.Size(460, 328);
            this.lbFilterIn.TabIndex = 0;
            this.lbFilterIn.SelectedIndexChanged += new System.EventHandler(this.lbFilterIn_SelectedIndexChanged);
            // 
            // 信令分析
            // 
            this.信令分析.Controls.Add(this.splitContainer4);
            this.信令分析.Location = new System.Drawing.Point(4, 4);
            this.信令分析.Name = "信令分析";
            this.信令分析.Size = new System.Drawing.Size(702, 334);
            this.信令分析.TabIndex = 2;
            this.信令分析.Text = "信令分析";
            this.信令分析.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.splitContainer5);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer4.Size = new System.Drawing.Size(702, 334);
            this.splitContainer4.SplitterDistance = 76;
            this.splitContainer4.TabIndex = 1;
            // 
            // splitContainer5
            // 
            this.splitContainer5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.btnSaveScript);
            this.splitContainer5.Panel1.Controls.Add(this.btnRunScript);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.rtxtSql);
            this.splitContainer5.Size = new System.Drawing.Size(702, 76);
            this.splitContainer5.SplitterDistance = 235;
            this.splitContainer5.TabIndex = 2;
            // 
            // btnSaveScript
            // 
            this.btnSaveScript.Location = new System.Drawing.Point(64, 43);
            this.btnSaveScript.Name = "btnSaveScript";
            this.btnSaveScript.Size = new System.Drawing.Size(75, 23);
            this.btnSaveScript.TabIndex = 1;
            this.btnSaveScript.Text = "SaveScript";
            this.btnSaveScript.UseVisualStyleBackColor = true;
            // 
            // btnRunScript
            // 
            this.btnRunScript.Location = new System.Drawing.Point(64, 13);
            this.btnRunScript.Name = "btnRunScript";
            this.btnRunScript.Size = new System.Drawing.Size(75, 23);
            this.btnRunScript.TabIndex = 0;
            this.btnRunScript.Text = "RunScript";
            this.btnRunScript.UseVisualStyleBackColor = true;
            this.btnRunScript.Click += new System.EventHandler(this.btnRunScript_Click);
            // 
            // rtxtSql
            // 
            this.rtxtSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtSql.Location = new System.Drawing.Point(0, 0);
            this.rtxtSql.Name = "rtxtSql";
            this.rtxtSql.Size = new System.Drawing.Size(461, 74);
            this.rtxtSql.TabIndex = 1;
            this.rtxtSql.Text = "";
            this.rtxtSql.TextChanged += new System.EventHandler(this.rtxtSql_TextChanged);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tvSql);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer3.Size = new System.Drawing.Size(702, 254);
            this.splitContainer3.SplitterDistance = 234;
            this.splitContainer3.TabIndex = 0;
            // 
            // tvSql
            // 
            this.tvSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSql.Location = new System.Drawing.Point(0, 0);
            this.tvSql.Name = "tvSql";
            this.tvSql.Size = new System.Drawing.Size(234, 254);
            this.tvSql.TabIndex = 0;
            this.tvSql.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSql_AfterSelect);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dgvPara, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.rtxtEvent, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(464, 254);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // dgvPara
            // 
            this.dgvPara.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPara.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPara.ContextMenuStrip = this.contextMenuStrip2;
            this.dgvPara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPara.Location = new System.Drawing.Point(3, 3);
            this.dgvPara.Name = "dgvPara";
            this.dgvPara.RowTemplate.Height = 23;
            this.dgvPara.Size = new System.Drawing.Size(458, 195);
            this.dgvPara.TabIndex = 0;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(101, 26);
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.excelToolStripMenuItem.Text = "Excel";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
            // 
            // rtxtEvent
            // 
            this.rtxtEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtEvent.Location = new System.Drawing.Point(3, 204);
            this.rtxtEvent.Name = "rtxtEvent";
            this.rtxtEvent.Size = new System.Drawing.Size(458, 47);
            this.rtxtEvent.TabIndex = 1;
            this.rtxtEvent.Text = "";
            // 
            // ttipLayer
            // 
            this.ttipLayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttipLayerbtnOpen,
            this.ttipLayerClearDB,
            this.ttipLayerFilter,
            this.toolStripProgressBar1,
            this.ttipLayerGetXml,
            this.ttipLayerWriteXml,
            this.ttipLayerExit,
            this.toolStripComboBox1});
            this.ttipLayer.Location = new System.Drawing.Point(0, 0);
            this.ttipLayer.Name = "ttipLayer";
            this.ttipLayer.Size = new System.Drawing.Size(716, 22);
            this.ttipLayer.TabIndex = 4;
            this.ttipLayer.Text = "ttipLayer";
            // 
            // ttipLayerbtnOpen
            // 
            this.ttipLayerbtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ttipLayerbtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("ttipLayerbtnOpen.Image")));
            this.ttipLayerbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ttipLayerbtnOpen.Name = "ttipLayerbtnOpen";
            this.ttipLayerbtnOpen.Size = new System.Drawing.Size(23, 19);
            this.ttipLayerbtnOpen.Text = "Open";
            this.ttipLayerbtnOpen.Click += new System.EventHandler(this.ttipLayerbtnOpen_Click);
            // 
            // ttipLayerClearDB
            // 
            this.ttipLayerClearDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ttipLayerClearDB.Image = ((System.Drawing.Image)(resources.GetObject("ttipLayerClearDB.Image")));
            this.ttipLayerClearDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ttipLayerClearDB.Name = "ttipLayerClearDB";
            this.ttipLayerClearDB.Size = new System.Drawing.Size(23, 19);
            this.ttipLayerClearDB.Text = "ClearDB";
            this.ttipLayerClearDB.Click += new System.EventHandler(this.ttipLayerClearDB_Click);
            // 
            // ttipLayerFilter
            // 
            this.ttipLayerFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ttipLayerFilter.Image = ((System.Drawing.Image)(resources.GetObject("ttipLayerFilter.Image")));
            this.ttipLayerFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ttipLayerFilter.Name = "ttipLayerFilter";
            this.ttipLayerFilter.Size = new System.Drawing.Size(23, 19);
            this.ttipLayerFilter.Text = "Filter";
            this.ttipLayerFilter.Click += new System.EventHandler(this.ttipLayerFilter_Click);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 19);
            // 
            // ttipLayerGetXml
            // 
            this.ttipLayerGetXml.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ttipLayerGetXml.Image = ((System.Drawing.Image)(resources.GetObject("ttipLayerGetXml.Image")));
            this.ttipLayerGetXml.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ttipLayerGetXml.Name = "ttipLayerGetXml";
            this.ttipLayerGetXml.Size = new System.Drawing.Size(23, 19);
            this.ttipLayerGetXml.Text = "GetXml";
            this.ttipLayerGetXml.Click += new System.EventHandler(this.ttipLayerGetXml_Click);
            // 
            // ttipLayerWriteXml
            // 
            this.ttipLayerWriteXml.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ttipLayerWriteXml.Image = ((System.Drawing.Image)(resources.GetObject("ttipLayerWriteXml.Image")));
            this.ttipLayerWriteXml.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ttipLayerWriteXml.Name = "ttipLayerWriteXml";
            this.ttipLayerWriteXml.Size = new System.Drawing.Size(23, 19);
            this.ttipLayerWriteXml.Text = "WriteXml";
            this.ttipLayerWriteXml.Click += new System.EventHandler(this.ttipLayerWriteXml_Click);
            // 
            // ttipLayerExit
            // 
            this.ttipLayerExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ttipLayerExit.Image = ((System.Drawing.Image)(resources.GetObject("ttipLayerExit.Image")));
            this.ttipLayerExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ttipLayerExit.Name = "ttipLayerExit";
            this.ttipLayerExit.Size = new System.Drawing.Size(23, 19);
            this.ttipLayerExit.Text = "Exit";
            this.ttipLayerExit.Click += new System.EventHandler(this.ttipLayerExit_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(221, 22);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            this.toolStripComboBox1.Click += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // frmLAYER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 433);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.sstipLayer);
            this.Controls.Add(this.mstipLayer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mstipLayer;
            this.Name = "frmLAYER";
            this.Text = "Layer 3 Conversion";
            this.Load += new System.EventHandler(this.frmLAYER_Load);
            this.mstipLayer.ResumeLayout(false);
            this.mstipLayer.PerformLayout();
            this.sstipLayer.ResumeLayout(false);
            this.sstipLayer.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tcLayer.ResumeLayout(false);
            this.打开文件.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.信令过滤.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.信令分析.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPara)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ttipLayer.ResumeLayout(false);
            this.ttipLayer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mstipLayer;
        private System.Windows.Forms.StatusStrip sstipLayer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip ttipLayer;
        private System.Windows.Forms.ToolStripButton ttipLayerbtnOpen;
        private System.Windows.Forms.ToolStripStatusLabel mstipLayerlbFilepath;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripButton ttipLayerClearDB;
        private System.Windows.Forms.ToolStripButton ttipLayerGetXml;
        private System.Windows.Forms.ToolStripButton ttipLayerWriteXml;
        private System.Windows.Forms.ToolStripButton ttipLayerFilter;
        private System.Windows.Forms.ToolStripMenuItem 打开文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 信令过滤ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 信令分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton ttipLayerExit;
        private System.Windows.Forms.ToolStripStatusLabel mstipLayerlbStrsql;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出系统EToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.TabControl tcLayer;
        private System.Windows.Forms.TabPage 打开文件;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lbLay3Message;
        private System.Windows.Forms.ListBox lbMessagePara;
        private System.Windows.Forms.TabPage 信令过滤;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView tvFilterOut;
        private System.Windows.Forms.ListBox lbFilterIn;
        private System.Windows.Forms.TabPage 信令分析;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TreeView tvSql;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvPara;
        private System.Windows.Forms.RichTextBox rtxtSql;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.RichTextBox rtxtEvent;
        private System.Windows.Forms.Button btnRunScript;
        private System.Windows.Forms.Button btnSaveScript;
    }
}

