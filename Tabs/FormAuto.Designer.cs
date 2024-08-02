namespace TanHungHa.Tabs
{
    partial class FormAuto
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAuto));
            this.panelTop = new System.Windows.Forms.Panel();
            this.spreadsheetControl = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.commonBar1 = new DevExpress.XtraSpreadsheet.UI.CommonBar();
            this.btnOpen = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            this.btnSaveAs = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            this.btnStart = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnStop = new DevExpress.XtraBars.BarLargeButtonItem();
            this.BarHeaderFileName = new DevExpress.XtraBars.BarHeaderItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.spreadsheetFormulaBar1 = new DevExpress.XtraSpreadsheet.SpreadsheetFormulaBar();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.dataPointBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spreadsheetBarController1 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetBarController(this.components);
            this.lvLogAuto = new MaterialSkin.Controls.MaterialListView();
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLog = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelBot = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataPointBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spreadsheetBarController1)).BeginInit();
            this.panelBot.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.spreadsheetControl);
            this.panelTop.Controls.Add(this.splitterControl1);
            this.panelTop.Controls.Add(this.spreadsheetFormulaBar1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(526, 310);
            this.panelTop.TabIndex = 2;
            // 
            // spreadsheetControl
            // 
            this.spreadsheetControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spreadsheetControl.Location = new System.Drawing.Point(0, 36);
            this.spreadsheetControl.MenuManager = this.barManager1;
            this.spreadsheetControl.Name = "spreadsheetControl";
            this.spreadsheetControl.Size = new System.Drawing.Size(526, 274);
            this.spreadsheetControl.TabIndex = 0;
            this.spreadsheetControl.Text = "spreadsheetControl1";
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowItemAnimatedHighlighting = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.commonBar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.HideBarsWhenMerging = false;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnOpen,
            this.btnSaveAs,
            this.btnStart,
            this.btnStop,
            this.BarHeaderFileName});
            this.barManager1.MaxItemId = 24;
            this.barManager1.ShowScreenTipsInToolbars = false;
            this.barManager1.ShowShortcutInScreenTips = false;
            this.barManager1.ShowToolbarsContextMenu += new DevExpress.XtraBars.ShowToolbarsContextMenuEventHandler(this.barManager1_ShowToolbarsContextMenu);
            // 
            // commonBar1
            // 
            this.commonBar1.Control = this.spreadsheetControl;
            this.commonBar1.DockCol = 0;
            this.commonBar1.DockRow = 0;
            this.commonBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.commonBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOpen),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSaveAs),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnStart),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnStop, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarHeaderFileName)});
            this.commonBar1.OptionsBar.AllowQuickCustomization = false;
            this.commonBar1.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.OnlyMenu;
            this.commonBar1.OptionsBar.DrawBorder = false;
            this.commonBar1.OptionsBar.DrawDragBorder = false;
            this.commonBar1.OptionsBar.RotateWhenVertical = false;
            // 
            // btnOpen
            // 
            this.btnOpen.CommandName = "FileOpen";
            this.btnOpen.Id = 5;
            this.btnOpen.Name = "btnOpen";
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.CommandName = "FileSaveAs";
            this.btnSaveAs.Id = 7;
            this.btnSaveAs.Name = "btnSaveAs";
            // 
            // btnStart
            // 
            this.btnStart.Caption = "Start";
            this.btnStart.Id = 12;
            this.btnStart.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.ImageOptions.Image")));
            this.btnStart.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnStart.ImageOptions.LargeImage")));
            this.btnStart.Name = "btnStart";
            this.btnStart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStart_ItemClick);
            // 
            // btnStop
            // 
            this.btnStop.Caption = "Stop";
            this.btnStop.Id = 13;
            this.btnStop.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.ImageOptions.Image")));
            this.btnStop.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnStop.ImageOptions.LargeImage")));
            this.btnStop.Name = "btnStop";
            this.btnStop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStop_ItemClick);
            // 
            // BarHeaderFileName
            // 
            this.BarHeaderFileName.Id = 14;
            this.BarHeaderFileName.Name = "BarHeaderFileName";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(3, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(928, 60);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(3, 518);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(928, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(3, 60);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 458);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(931, 60);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 458);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl1.Location = new System.Drawing.Point(0, 24);
            this.splitterControl1.MinSize = 20;
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(526, 12);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            // 
            // spreadsheetFormulaBar1
            // 
            this.spreadsheetFormulaBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.spreadsheetFormulaBar1.Location = new System.Drawing.Point(0, 0);
            this.spreadsheetFormulaBar1.MinimumSize = new System.Drawing.Size(0, 24);
            this.spreadsheetFormulaBar1.Name = "spreadsheetFormulaBar1";
            this.spreadsheetFormulaBar1.Size = new System.Drawing.Size(526, 24);
            this.spreadsheetFormulaBar1.SpreadsheetControl = this.spreadsheetControl;
            this.spreadsheetFormulaBar1.TabIndex = 2;
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl.Location = new System.Drawing.Point(535, 3);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0D;
            this.zedGraphControl.ScrollMaxX = 0D;
            this.zedGraphControl.ScrollMaxY = 0D;
            this.zedGraphControl.ScrollMaxY2 = 0D;
            this.zedGraphControl.ScrollMinX = 0D;
            this.zedGraphControl.ScrollMinY = 0D;
            this.zedGraphControl.ScrollMinY2 = 0D;
            this.zedGraphControl.Size = new System.Drawing.Size(390, 310);
            this.zedGraphControl.TabIndex = 3;
            this.zedGraphControl.UseExtendedPrintDialog = true;
            // 
            // dataPointBindingSource
            // 
            this.dataPointBindingSource.AllowNew = false;
            // 
            // spreadsheetBarController1
            // 
            this.spreadsheetBarController1.BarItems.Add(this.btnOpen);
            this.spreadsheetBarController1.BarItems.Add(this.btnSaveAs);
            this.spreadsheetBarController1.Control = this.spreadsheetControl;
            // 
            // lvLogAuto
            // 
            this.lvLogAuto.AutoSizeTable = false;
            this.lvLogAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lvLogAuto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvLogAuto.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTime,
            this.columnHeaderLog});
            this.lvLogAuto.Depth = 0;
            this.lvLogAuto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLogAuto.FullRowSelect = true;
            this.lvLogAuto.HideSelection = false;
            this.lvLogAuto.Location = new System.Drawing.Point(0, 0);
            this.lvLogAuto.MinimumSize = new System.Drawing.Size(200, 100);
            this.lvLogAuto.MouseLocation = new System.Drawing.Point(-1, -1);
            this.lvLogAuto.MouseState = MaterialSkin.MouseState.OUT;
            this.lvLogAuto.Name = "lvLogAuto";
            this.lvLogAuto.OwnerDraw = true;
            this.lvLogAuto.Size = new System.Drawing.Size(928, 142);
            this.lvLogAuto.TabIndex = 2;
            this.lvLogAuto.UseCompatibleStateImageBehavior = false;
            this.lvLogAuto.View = System.Windows.Forms.View.Details;
            this.lvLogAuto.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvLogAuto_MouseDoubleClick);
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "TimeStamp";
            this.columnHeaderTime.Width = 200;
            // 
            // columnHeaderLog
            // 
            this.columnHeaderLog.Text = "Info";
            this.columnHeaderLog.Width = 900;
            // 
            // panelBot
            // 
            this.panelBot.Controls.Add(this.lvLogAuto);
            this.panelBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBot.Location = new System.Drawing.Point(3, 376);
            this.panelBot.Name = "panelBot";
            this.panelBot.Size = new System.Drawing.Size(928, 142);
            this.panelBot.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.43534F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.56466F));
            this.tableLayoutPanel1.Controls.Add(this.panelTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.zedGraphControl, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(928, 316);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // FormAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 521);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelBot);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "FormAuto";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Text = "FormAuto";
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataPointBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spreadsheetBarController1)).EndInit();
            this.panelBot.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelTop;
        private DevExpress.XtraSpreadsheet.SpreadsheetControl spreadsheetControl;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraSpreadsheet.UI.CommonBar commonBar1;
        private DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem btnOpen;
        private DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem btnSaveAs;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraSpreadsheet.SpreadsheetFormulaBar spreadsheetFormulaBar1;
        private DevExpress.XtraSpreadsheet.UI.SpreadsheetBarController spreadsheetBarController1;
        private DevExpress.XtraBars.BarLargeButtonItem btnStart;
        private DevExpress.XtraBars.BarLargeButtonItem btnStop;
        private System.Windows.Forms.Panel panelBot;
        public MaterialSkin.Controls.MaterialListView lvLogAuto;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.ColumnHeader columnHeaderLog;
        private DevExpress.XtraBars.BarHeaderItem BarHeaderFileName;
        private System.Windows.Forms.BindingSource dataPointBindingSource;
        private ZedGraph.ZedGraphControl zedGraphControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}