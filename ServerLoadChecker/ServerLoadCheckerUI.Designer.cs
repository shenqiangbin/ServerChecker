namespace ServerLoadChecker
{
    partial class ServerLoadCheckerUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerLoadCheckerUI));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.nUDDiskThreshold = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nUDRAMThreshold = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nUDCPUThreshold = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dgResult = new System.Windows.Forms.DataGridView();
            this.ColState = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColServerName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColUserName = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColPassword = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColCPUThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCPUUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRAMThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRAMUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDiskThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDiskUsageWarning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDiskUsageNormal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.chkAutoSendEmailtoSupportTeam = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nUDDiskThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRAMThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCPUThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgResult)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ok.png");
            this.imageList1.Images.SetKeyName(1, "alert.png");
            this.imageList1.Images.SetKeyName(2, "error.png");
            this.imageList1.Images.SetKeyName(3, "wait.png");
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(780, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 77);
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(386, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 48;
            this.label8.Text = "%";
            // 
            // nUDDiskThreshold
            // 
            this.nUDDiskThreshold.Location = new System.Drawing.Point(337, 67);
            this.nUDDiskThreshold.Name = "nUDDiskThreshold";
            this.nUDDiskThreshold.Size = new System.Drawing.Size(46, 21);
            this.nUDDiskThreshold.TabIndex = 47;
            this.nUDDiskThreshold.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(244, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 46;
            this.label9.Text = "磁盘使用率阈值";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(386, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 45;
            this.label6.Text = "%";
            // 
            // nUDRAMThreshold
            // 
            this.nUDRAMThreshold.Location = new System.Drawing.Point(337, 40);
            this.nUDRAMThreshold.Name = "nUDRAMThreshold";
            this.nUDRAMThreshold.Size = new System.Drawing.Size(46, 21);
            this.nUDRAMThreshold.TabIndex = 44;
            this.nUDRAMThreshold.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(386, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 42;
            this.label5.Text = "%";
            // 
            // nUDCPUThreshold
            // 
            this.nUDCPUThreshold.Location = new System.Drawing.Point(337, 13);
            this.nUDCPUThreshold.Name = "nUDCPUThreshold";
            this.nUDCPUThreshold.Size = new System.Drawing.Size(46, 21);
            this.nUDCPUThreshold.TabIndex = 41;
            this.nUDCPUThreshold.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 40;
            this.label4.Text = "CPU使用率阈值";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(510, 11);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(84, 77);
            this.btnUpdate.TabIndex = 39;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(600, 11);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(84, 77);
            this.btnRemove.TabIndex = 37;
            this.btnRemove.Text = "移除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "rdp";
            this.openFileDialog1.Filter = "Remote Desktop File (*.rdp)|*.rdp";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(244, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 43;
            this.label7.Text = "内存使用率阈值";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(690, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(84, 77);
            this.btnRefresh.TabIndex = 38;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 3600000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dgResult
            // 
            this.dgResult.AllowUserToAddRows = false;
            this.dgResult.AllowUserToDeleteRows = false;
            this.dgResult.AllowUserToResizeRows = false;
            this.dgResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColState,
            this.ColServerName,
            this.ColUserName,
            this.ColPassword,
            this.ColCPUThreshold,
            this.ColCPUUsage,
            this.ColRAMThreshold,
            this.ColRAMUsage,
            this.ColDiskThreshold,
            this.ColDiskUsageWarning,
            this.ColDiskUsageNormal});
            this.dgResult.Location = new System.Drawing.Point(13, 115);
            this.dgResult.MultiSelect = false;
            this.dgResult.Name = "dgResult";
            this.dgResult.ReadOnly = true;
            this.dgResult.RowHeadersVisible = false;
            this.dgResult.RowTemplate.Height = 23;
            this.dgResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgResult.Size = new System.Drawing.Size(851, 360);
            this.dgResult.TabIndex = 36;
            this.dgResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResult_CellContentClick);
            this.dgResult.SelectionChanged += new System.EventHandler(this.dgResult_SelectionChanged);
            // 
            // ColState
            // 
            this.ColState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColState.Frozen = true;
            this.ColState.HeaderText = "状态";
            this.ColState.Name = "ColState";
            this.ColState.ReadOnly = true;
            this.ColState.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColState.Width = 42;
            // 
            // ColServerName
            // 
            this.ColServerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColServerName.Frozen = true;
            this.ColServerName.HeaderText = "服务器";
            this.ColServerName.Name = "ColServerName";
            this.ColServerName.ReadOnly = true;
            this.ColServerName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColServerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColServerName.Width = 61;
            // 
            // ColUserName
            // 
            this.ColUserName.HeaderText = "用户名";
            this.ColUserName.Name = "ColUserName";
            this.ColUserName.ReadOnly = true;
            this.ColUserName.Visible = false;
            // 
            // ColPassword
            // 
            this.ColPassword.HeaderText = "密码";
            this.ColPassword.Name = "ColPassword";
            this.ColPassword.ReadOnly = true;
            this.ColPassword.Visible = false;
            // 
            // ColCPUThreshold
            // 
            this.ColCPUThreshold.HeaderText = "CPU使用率阈值";
            this.ColCPUThreshold.Name = "ColCPUThreshold";
            this.ColCPUThreshold.ReadOnly = true;
            this.ColCPUThreshold.Visible = false;
            // 
            // ColCPUUsage
            // 
            this.ColCPUUsage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColCPUUsage.HeaderText = "CPU使用率";
            this.ColCPUUsage.Name = "ColCPUUsage";
            this.ColCPUUsage.ReadOnly = true;
            this.ColCPUUsage.Width = 67;
            // 
            // ColRAMThreshold
            // 
            this.ColRAMThreshold.HeaderText = "内存使用率阈值";
            this.ColRAMThreshold.Name = "ColRAMThreshold";
            this.ColRAMThreshold.ReadOnly = true;
            this.ColRAMThreshold.Visible = false;
            // 
            // ColRAMUsage
            // 
            this.ColRAMUsage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColRAMUsage.HeaderText = "内存使用率";
            this.ColRAMUsage.Name = "ColRAMUsage";
            this.ColRAMUsage.ReadOnly = true;
            this.ColRAMUsage.Width = 72;
            // 
            // ColDiskThreshold
            // 
            this.ColDiskThreshold.HeaderText = "磁盘使用率阈值";
            this.ColDiskThreshold.Name = "ColDiskThreshold";
            this.ColDiskThreshold.ReadOnly = true;
            this.ColDiskThreshold.Visible = false;
            // 
            // ColDiskUsageWarning
            // 
            this.ColDiskUsageWarning.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColDiskUsageWarning.HeaderText = "磁盘使用率 (警告)";
            this.ColDiskUsageWarning.Name = "ColDiskUsageWarning";
            this.ColDiskUsageWarning.ReadOnly = true;
            this.ColDiskUsageWarning.Width = 94;
            // 
            // ColDiskUsageNormal
            // 
            this.ColDiskUsageNormal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColDiskUsageNormal.HeaderText = "磁盘使用率 (正常)";
            this.ColDiskUsageNormal.Name = "ColDiskUsageNormal";
            this.ColDiskUsageNormal.ReadOnly = true;
            this.ColDiskUsageNormal.Width = 94;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 35;
            this.label3.Text = "密码";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(75, 66);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(148, 21);
            this.txtPassword.TabIndex = 34;
            this.txtPassword.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "用户名";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(75, 39);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(148, 21);
            this.txtUserName.TabIndex = 32;
            this.txtUserName.Text = "Domain\\UserName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "服务器名称";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(420, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 77);
            this.btnAdd.TabIndex = 30;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(75, 12);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(148, 21);
            this.txtServerName.TabIndex = 29;
            this.txtServerName.Text = ".";
            // 
            // chkAutoSendEmailtoSupportTeam
            // 
            this.chkAutoSendEmailtoSupportTeam.AutoSize = true;
            this.chkAutoSendEmailtoSupportTeam.Location = new System.Drawing.Point(12, 93);
            this.chkAutoSendEmailtoSupportTeam.Name = "chkAutoSendEmailtoSupportTeam";
            this.chkAutoSendEmailtoSupportTeam.Size = new System.Drawing.Size(480, 16);
            this.chkAutoSendEmailtoSupportTeam.TabIndex = 50;
            this.chkAutoSendEmailtoSupportTeam.Text = "如果服务器的CPU、内存和磁盘使用率超过阈值，则每1小时发送一次邮件给IT工程师。";
            this.chkAutoSendEmailtoSupportTeam.UseVisualStyleBackColor = true;
            this.chkAutoSendEmailtoSupportTeam.CheckedChanged += new System.EventHandler(this.chkAutoSendEmailtoSupportTeam_CheckedChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "双击托盘图标还原服务器负载检查工具";
            this.notifyIcon1.BalloonTipTitle = "检查工具仍在运行";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "服务器负载检查工具";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1800000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // ServerLoadCheckerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 487);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nUDDiskThreshold);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nUDRAMThreshold);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nUDCPUThreshold);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.chkAutoSendEmailtoSupportTeam);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ServerLoadCheckerUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务器负载检查工具";
            this.Load += new System.EventHandler(this.ServerLoadCheckerUI_Load);
            this.SizeChanged += new System.EventHandler(this.ServerLoadCheckerUI_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.nUDDiskThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRAMThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCPUThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nUDDiskThreshold;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nUDRAMThreshold;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nUDCPUThreshold;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dgResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.CheckBox chkAutoSendEmailtoSupportTeam;
        private System.Windows.Forms.DataGridViewImageColumn ColState;
        private System.Windows.Forms.DataGridViewLinkColumn ColServerName;
        private System.Windows.Forms.DataGridViewImageColumn ColUserName;
        private System.Windows.Forms.DataGridViewImageColumn ColPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCPUThreshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCPUUsage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRAMThreshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRAMUsage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDiskThreshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDiskUsageWarning;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDiskUsageNormal;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
    }
}

