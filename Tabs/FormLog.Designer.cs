namespace TanHungHa.Tabs
{
    partial class FormLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_control = new System.Windows.Forms.Panel();
            this.btnRefresh = new MaterialSkin.Controls.MaterialButton();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_select_log = new System.Windows.Forms.Label();
            this.lb_range_log = new System.Windows.Forms.Label();
            this.lb_select_date = new System.Windows.Forms.Label();
            this.cblSelLog = new System.Windows.Forms.CheckedListBox();
            this.dp_endDate = new System.Windows.Forms.DateTimePicker();
            this.dp_startDate = new System.Windows.Forms.DateTimePicker();
            this.cl_DateSelector = new System.Windows.Forms.MonthCalendar();
            this.panel_view = new System.Windows.Forms.Panel();
            this.dg_Log = new System.Windows.Forms.DataGridView();
            this.panel_control.SuspendLayout();
            this.panel_view.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Log)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_control
            // 
            this.panel_control.Controls.Add(this.btnRefresh);
            this.panel_control.Controls.Add(this.label3);
            this.panel_control.Controls.Add(this.lb_select_log);
            this.panel_control.Controls.Add(this.lb_range_log);
            this.panel_control.Controls.Add(this.lb_select_date);
            this.panel_control.Controls.Add(this.cblSelLog);
            this.panel_control.Controls.Add(this.dp_endDate);
            this.panel_control.Controls.Add(this.dp_startDate);
            this.panel_control.Controls.Add(this.cl_DateSelector);
            this.panel_control.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_control.Location = new System.Drawing.Point(3, 0);
            this.panel_control.Name = "panel_control";
            this.panel_control.Size = new System.Drawing.Size(260, 518);
            this.panel_control.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = false;
            this.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefresh.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRefresh.Depth = 0;
            this.btnRefresh.HighEmphasis = true;
            this.btnRefresh.Icon = null;
            this.btnRefresh.Location = new System.Drawing.Point(16, 448);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRefresh.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRefresh.Size = new System.Drawing.Size(227, 49);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnRefresh.UseAccentColor = false;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "~";
            // 
            // lb_select_log
            // 
            this.lb_select_log.AutoSize = true;
            this.lb_select_log.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_select_log.Location = new System.Drawing.Point(19, 298);
            this.lb_select_log.Name = "lb_select_log";
            this.lb_select_log.Size = new System.Drawing.Size(78, 15);
            this.lb_select_log.TabIndex = 4;
            this.lb_select_log.Text = "▶ Select Log";
            // 
            // lb_range_log
            // 
            this.lb_range_log.AutoSize = true;
            this.lb_range_log.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_range_log.Location = new System.Drawing.Point(19, 209);
            this.lb_range_log.Name = "lb_range_log";
            this.lb_range_log.Size = new System.Drawing.Size(54, 15);
            this.lb_range_log.TabIndex = 4;
            this.lb_range_log.Text = "▶ Range";
            // 
            // lb_select_date
            // 
            this.lb_select_date.AutoSize = true;
            this.lb_select_date.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_select_date.Location = new System.Drawing.Point(19, 11);
            this.lb_select_date.Name = "lb_select_date";
            this.lb_select_date.Size = new System.Drawing.Size(84, 15);
            this.lb_select_date.TabIndex = 4;
            this.lb_select_date.Text = "▶ Select Date";
            // 
            // cblSelLog
            // 
            this.cblSelLog.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cblSelLog.FormattingEnabled = true;
            this.cblSelLog.Location = new System.Drawing.Point(16, 315);
            this.cblSelLog.Name = "cblSelLog";
            this.cblSelLog.Size = new System.Drawing.Size(227, 124);
            this.cblSelLog.TabIndex = 3;
            // 
            // dp_endDate
            // 
            this.dp_endDate.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dp_endDate.Location = new System.Drawing.Point(45, 254);
            this.dp_endDate.Name = "dp_endDate";
            this.dp_endDate.Size = new System.Drawing.Size(206, 23);
            this.dp_endDate.TabIndex = 2;
            // 
            // dp_startDate
            // 
            this.dp_startDate.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dp_startDate.Location = new System.Drawing.Point(16, 226);
            this.dp_startDate.Name = "dp_startDate";
            this.dp_startDate.Size = new System.Drawing.Size(227, 23);
            this.dp_startDate.TabIndex = 1;
            // 
            // cl_DateSelector
            // 
            this.cl_DateSelector.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cl_DateSelector.Location = new System.Drawing.Point(16, 32);
            this.cl_DateSelector.Name = "cl_DateSelector";
            this.cl_DateSelector.TabIndex = 0;
            // 
            // panel_view
            // 
            this.panel_view.Controls.Add(this.dg_Log);
            this.panel_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_view.Location = new System.Drawing.Point(263, 0);
            this.panel_view.Name = "panel_view";
            this.panel_view.Size = new System.Drawing.Size(668, 518);
            this.panel_view.TabIndex = 2;
            // 
            // dg_Log
            // 
            this.dg_Log.AllowUserToAddRows = false;
            this.dg_Log.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dg_Log.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_Log.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_Log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_Log.Location = new System.Drawing.Point(0, 0);
            this.dg_Log.Name = "dg_Log";
            this.dg_Log.Size = new System.Drawing.Size(668, 518);
            this.dg_Log.TabIndex = 0;
            // 
            // FormLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 521);
            this.Controls.Add(this.panel_view);
            this.Controls.Add(this.panel_control);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "FormLog";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Text = "FormLog";
            this.panel_control.ResumeLayout(false);
            this.panel_control.PerformLayout();
            this.panel_view.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Log)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_control;
        private MaterialSkin.Controls.MaterialButton btnRefresh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_select_log;
        private System.Windows.Forms.Label lb_range_log;
        private System.Windows.Forms.Label lb_select_date;
        private System.Windows.Forms.CheckedListBox cblSelLog;
        private System.Windows.Forms.DateTimePicker dp_endDate;
        private System.Windows.Forms.DateTimePicker dp_startDate;
        private System.Windows.Forms.MonthCalendar cl_DateSelector;
        private System.Windows.Forms.Panel panel_view;
        private System.Windows.Forms.DataGridView dg_Log;
    }
}