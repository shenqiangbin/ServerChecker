using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Threading;
using System.Windows.Forms;

namespace ServerLoadChecker
{
    public partial class ServerLoadCheckerUI : Form
    {
        private List<ServerConfigurationData> _configurations = new List<ServerConfigurationData>();
        private readonly string SERVER_CONFIGURATION_DATA_FILE_NAME = "ServerConfiguration.xml";
        private string emailBody;
        private int cntServer;
        private int iServer = 0;
        private int cntMonitorServer;
        private int iMonitorServer = 0;

        public ServerLoadCheckerUI()
        {
            InitializeComponent();

            LoadServerConfigurationData();
            RefreshAllServerStatus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServerName.Text))
            {
                MessageBox.Show("请填写服务器名称！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtServerName.Focus();
                return;
            }
            else
            {
                if (FindRow(txtServerName.Text) != null)
                {
                    MessageBox.Show("服务器“" + txtServerName.Text + "”在监控列表中已经存在，请指定一台新的服务器！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtServerName.Focus();
                    return;
                }
            }
            //if (string.IsNullOrEmpty(this.txtUserName.Text))
            //{
            //    MessageBox.Show("请填写服务器登录用户名！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    this.txtUserName.Focus();
            //    return;
            //}
            //if (string.IsNullOrEmpty(this.txtPassword.Text))
            //{
            //    MessageBox.Show("请填写服务器登录密码！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    this.txtPassword.Focus();
            //    return;
            //}

            DataGridViewRow newRow = AddNewServerMornitor(new ServerConfigurationData()
            {
                ServerName = txtServerName.Text,
                UserName = this.txtUserName.Text,
                Password = this.txtPassword.Text,
                CPUThreshold = this.nUDCPUThreshold.Value,
                RAMThreshold = this.nUDRAMThreshold.Value,
                DiskThreshold = this.nUDDiskThreshold.Value
            });
            newRow.Selected = true;
            UpdateInputFromCurrentRow();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgResult.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择需要移除监控的服务器！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("确定移除选定的服务器？", "移除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RemoveServerMornitor(dgResult.SelectedRows[0]);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshAllServerStatus();
        }

        private void dgResult_SelectionChanged(object sender, EventArgs e)
        {
            UpdateInputFromCurrentRow();
        }

        private void dgResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dgResult.Columns[e.ColumnIndex].Name == "ColServerName")
            {
                ServerLoadHelper.ConnectToRemoteDesktop(dgResult[e.ColumnIndex, e.RowIndex].Value.ToString(),
                    dgResult["ColUserName", e.RowIndex].Value.ToString(),
                    dgResult["ColPassword", e.RowIndex].Value.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgResult.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择一条服务器监控记录用来更新！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(txtServerName.Text))
            {
                MessageBox.Show("请填写服务器名称！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtServerName.Focus();
                return;
            }
            else
            {
                DataGridViewRow row = FindRow(txtServerName.Text);
                if (row != null && dgResult.SelectedRows[0] != row)
                {
                    MessageBox.Show("服务器“" + txtServerName.Text + "”在监控列表中已经存在，请指定一台新的服务器！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtServerName.Focus();
                    return;
                }
            }
            //if (string.IsNullOrEmpty(this.txtUserName.Text))
            //{
            //    MessageBox.Show("请填写服务器登录用户名！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.txtUserName.Focus();
            //    return;
            //}
            //if (string.IsNullOrEmpty(this.txtPassword.Text))
            //{
            //    MessageBox.Show("请填写服务器登录密码！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.txtPassword.Focus();
            //    return;
            //}

            UpdateServerMornitor(dgResult.SelectedRows[0], new ServerConfigurationData()
            {
                ServerName = txtServerName.Text,
                UserName = this.txtUserName.Text,
                Password = this.txtPassword.Text,
                CPUThreshold = this.nUDCPUThreshold.Value,
                RAMThreshold = this.nUDRAMThreshold.Value,
                DiskThreshold = this.nUDDiskThreshold.Value
            });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveServerConfigurationData();
        }

        private void ServerMornitorUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnSave.Enabled)
            {
                DialogResult dialogResult = MessageBox.Show("您对服务器监视配置的修改还未保存\n\n单击“是”保存并退出，单击“否”放弃保存并退出。", "关闭程序", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        SaveServerConfigurationData();
                        e.Cancel = false;
                        break;

                    case DialogResult.No:
                        e.Cancel = false;
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void LoadServerConfigurationData()
        {
            string filePath = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, SERVER_CONFIGURATION_DATA_FILE_NAME);
            if (File.Exists(filePath))
                _configurations = XMLFileSerializationHelper.DeserializeObjectFromXMLFile<List<ServerConfigurationData>>(filePath);

            foreach (ServerConfigurationData configuration in _configurations)
            {
                dgResult.Rows.Add();
                UpdateRowWithConfigurationData(dgResult.Rows[dgResult.Rows.Count - 1], configuration);
            }
            if (dgResult.Rows.Count > 0)
                dgResult.Rows[dgResult.Rows.Count - 1].Selected = true;

            btnSave.Enabled = false;
        }

        /// <summary>
        /// 刷新所有服务器的状态
        /// </summary>
        private void RefreshAllServerStatus()
        {
            btnRefresh.Enabled = false;
            cntMonitorServer = _configurations.Count;
            foreach (ServerConfigurationData configuration in _configurations)
                GetServerUsageAsync(configuration);
        }

        private DataGridViewRow AddNewServerMornitor(ServerConfigurationData newConfigurationData)
        {
            dgResult.Rows.Add();
            DataGridViewRow newRow = dgResult.Rows[dgResult.Rows.Count - 1];

            UpdateRowWithConfigurationData(newRow, newConfigurationData);
            GetServerUsageAsync(newConfigurationData);

            _configurations.Add(newConfigurationData);

            btnSave.Enabled = true;

            return newRow;
        }

        private void UpdateInputFromCurrentRow()
        {
            if (dgResult.SelectedRows.Count == 0)
            {
                txtServerName.Text = string.Empty;
                this.txtUserName.Text = @"Domain\UserName";
                this.txtPassword.Text = "Password";
                this.nUDCPUThreshold.Value = 90;
                this.nUDRAMThreshold.Value = 90;
                this.nUDDiskThreshold.Value = 90;
            }
            else
            {
                DataGridViewRow currentRow = dgResult.SelectedRows[0];
                if (currentRow.Cells["ColServerName"].Value != null)
                    txtServerName.Text = currentRow.Cells["ColServerName"].Value.ToString();
                else
                    txtServerName.Text = string.Empty;
                if (currentRow.Cells["ColUserName"].Value != null)
                    this.txtUserName.Text = currentRow.Cells["ColUserName"].Value.ToString();
                else
                    this.txtUserName.Text = @"Domain\UserName";
                if (currentRow.Cells["ColPassword"].Value != null)
                    this.txtPassword.Text = currentRow.Cells["ColPassword"].Value.ToString();
                else
                    this.txtPassword.Text = "Password";
                if (currentRow.Cells["ColCPUThreshold"].Value != null)
                    this.nUDCPUThreshold.Value = Convert.ToDecimal(currentRow.Cells["ColCPUThreshold"].Value);
                else
                    this.nUDCPUThreshold.Value = 90;
                if (currentRow.Cells["ColRAMThreshold"].Value != null)
                    this.nUDRAMThreshold.Value = Convert.ToDecimal(currentRow.Cells["ColRAMThreshold"].Value);
                else
                    this.nUDRAMThreshold.Value = 90;
                if (currentRow.Cells["ColDiskThreshold"].Value != null)
                    this.nUDDiskThreshold.Value = Convert.ToDecimal(currentRow.Cells["ColDiskThreshold"].Value);
                else
                    this.nUDDiskThreshold.Value = 90;
            }
        }

        private void UpdateServerMornitor(DataGridViewRow currentRow, ServerConfigurationData updatedConfigurationData)
        {
            string originalServerName = currentRow.Cells["ColServerName"].Value.ToString();
            string originalUserName = currentRow.Cells["ColUserName"].Value.ToString();
            string originalPassword = currentRow.Cells["ColPassword"].Value.ToString();
            decimal originalCPUThreshold = Convert.ToDecimal(currentRow.Cells["ColCPUThreshold"].Value);
            decimal originalRAMThreshold = Convert.ToDecimal(currentRow.Cells["ColRAMThreshold"].Value);
            decimal originalDiskThreshold = Convert.ToDecimal(currentRow.Cells["ColDiskThreshold"].Value);

            bool isChanged = !originalServerName.Equals(updatedConfigurationData.ServerName, StringComparison.CurrentCultureIgnoreCase) ||
                !originalUserName.Equals(updatedConfigurationData.UserName, StringComparison.CurrentCultureIgnoreCase) ||
                !originalPassword.Equals(updatedConfigurationData.Password, StringComparison.CurrentCultureIgnoreCase) ||
                originalCPUThreshold != updatedConfigurationData.CPUThreshold ||
                originalRAMThreshold != updatedConfigurationData.RAMThreshold ||
                originalDiskThreshold != updatedConfigurationData.DiskThreshold;

            if (isChanged)
                UpdateRowWithConfigurationData(currentRow, updatedConfigurationData);

            GetServerUsageAsync(updatedConfigurationData);

            int originalConfigurationDataIndex = _configurations.FindIndex(c =>
                c.ServerName.Equals(originalServerName, StringComparison.CurrentCultureIgnoreCase));
            if (originalConfigurationDataIndex >= 0)
            {
                _configurations.RemoveAt(originalConfigurationDataIndex);
                _configurations.Insert(originalConfigurationDataIndex, updatedConfigurationData);
            }
            else
                _configurations.Add(updatedConfigurationData);

            if (isChanged)
                btnSave.Enabled = true;
        }

        public void RemoveServerMornitor(DataGridViewRow currentRow)
        {
            string serverName = currentRow.Cells["ColServerName"].Value.ToString();
            dgResult.Rows.Remove(currentRow);

            int configurationDataIndex = _configurations.FindIndex(c =>
                c.ServerName.Equals(serverName, StringComparison.CurrentCultureIgnoreCase));
            if (configurationDataIndex >= 0)
                _configurations.RemoveAt(configurationDataIndex);

            btnSave.Enabled = true;
        }

        private void SaveServerConfigurationData()
        {
            string filePath = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, SERVER_CONFIGURATION_DATA_FILE_NAME);
            XMLFileSerializationHelper.SerializeObjectToXMLFile<List<ServerConfigurationData>>(_configurations, filePath);
            btnSave.Enabled = false;
        }

        private static void UpdateRowWithConfigurationData(DataGridViewRow row, ServerConfigurationData configurationData)
        {
            row.Cells["ColServerName"].Value = configurationData.ServerName;
            row.Cells["ColUserName"].Value = configurationData.UserName;
            row.Cells["ColPassword"].Value = configurationData.Password;
            row.Cells["ColCPUThreshold"].Value = configurationData.CPUThreshold;
            row.Cells["ColRAMThreshold"].Value = configurationData.RAMThreshold;
            row.Cells["ColDiskThreshold"].Value = configurationData.DiskThreshold;
        }

        private void GetServerUsageAsync(ServerConfigurationData configurationData)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetServerUsageAsync), configurationData);
        }

        private void GetServerUsageAsync(object param)
        {
            if (param == null || !(param is ServerConfigurationData))
            {
                iMonitorServer++;
                //Report Error
                this.BeginInvoke(new Action(() =>
                {
                    if (iMonitorServer == cntMonitorServer)
                    {
                        btnRefresh.Enabled = true;
                        iMonitorServer = 0;
                    }
                    MessageBox.Show("Invalid argument: param", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
                return;
            }

            ServerConfigurationData configuration = param as ServerConfigurationData;

            //Report Progress
            this.BeginInvoke(new Action<string, decimal>(ReportProgress), configuration.ServerName, new Decimal(0));

            try
            {
                ServerLoadData result = ServerLoadHelper.GetServerUsage(configuration.ServerName, configuration.UserName, configuration.Password);

                iMonitorServer++;
                //Complete
                this.BeginInvoke(new Action<ServerLoadData>(OnGetServerUsageAsyncCompleted), result);
            }
            catch (Exception ex)
            {
                iMonitorServer++;
                //Report Error
                this.BeginInvoke(new Action<string, Exception>(ReportError), configuration.ServerName, ex);
            }
        }

        private void ReportProgress(string serverName, decimal percentOfProgress)
        {
            using (DataGridViewRow theRow = FindRow(serverName))
            {
                if (theRow != null)
                {
                    if (percentOfProgress == 0)
                    {
                        theRow.Cells["ColState"].ToolTipText = null;
                        theRow.Cells["ColState"].Value = this.imageList1.Images[3];
                        theRow.Cells["ColCPUUsage"].Value = null;
                        theRow.Cells["ColCPUUsage"].Style.BackColor = Color.White;
                        theRow.Cells["ColCPUUsage"].Style.ForeColor = Color.Black;
                        theRow.Cells["ColRAMUsage"].Value = null;
                        theRow.Cells["ColRAMUsage"].Style.BackColor = Color.White;
                        theRow.Cells["ColRAMUsage"].Style.ForeColor = Color.Black;
                        theRow.Cells["ColDiskUsageNormal"].Value = null;
                        theRow.Cells["ColDiskUsageWarning"].Value = null;
                        theRow.Cells["ColDiskUsageWarning"].Style.BackColor = Color.White;
                        theRow.Cells["ColDiskUsageWarning"].Style.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void ReportError(string serverName, Exception ex)
        {
            using (DataGridViewRow theRow = FindRow(serverName))
            {
                if (theRow != null)
                {
                    theRow.Cells["ColState"].Value = this.imageList1.Images[2];
                    theRow.Cells["ColState"].ToolTipText = ex.Message;
                }
            }
            if (iMonitorServer == cntMonitorServer)
            {
                btnRefresh.Enabled = true;
                iMonitorServer = 0;
            }
        }

        private void OnGetServerUsageAsyncCompleted(ServerLoadData data)
        {
            if (data == null)
                return;

            DataGridViewRow theRow = FindRow(data.ServerName);
            if (theRow == null)
                return;

            int overThresholdCount = 0;

            double cpuThreshold = Convert.ToDouble(theRow.Cells["ColCPUThreshold"].Value);
            double ramThreshold = Convert.ToDouble(theRow.Cells["ColRAMThreshold"].Value);
            double diskThreshold = Convert.ToDouble(theRow.Cells["ColDiskThreshold"].Value);

            overThresholdCount += data.CPUUsage > cpuThreshold ? 1 : 0;
            theRow.Cells["ColCPUUsage"].Value = string.Format("{0}%", data.CPUUsage);
            theRow.Cells["ColCPUUsage"].Style.BackColor = data.CPUUsage > cpuThreshold ? Color.Red : Color.White;
            theRow.Cells["ColCPUUsage"].Style.ForeColor = data.CPUUsage > cpuThreshold ? Color.White : Color.Black;

            overThresholdCount += data.RAMUsage > ramThreshold ? 1 : 0;
            theRow.Cells["ColRAMUsage"].Value = string.Format("{0}%", data.RAMUsage);
            theRow.Cells["ColRAMUsage"].Style.BackColor = data.RAMUsage > ramThreshold ? Color.Red : Color.White;
            theRow.Cells["ColRAMUsage"].Style.ForeColor = data.RAMUsage > ramThreshold ? Color.White : Color.Black;

            string diskUsageNormal = string.Empty;
            string diskUsageWarning = string.Empty;
            foreach (string key in data.DiskUsage.Keys)
            {
                if (data.DiskUsage[key] > diskThreshold)
                {
                    overThresholdCount++;
                    diskUsageWarning += string.Format("{0} {1:0}%{2}", key, data.DiskUsage[key], "  ");
                }
                else
                    diskUsageNormal += string.Format("{0} {1:0}%{2}", key, data.DiskUsage[key], "   ");
            }
            theRow.Cells["ColDiskUsageNormal"].Value = diskUsageNormal;
            theRow.Cells["ColDiskUsageWarning"].Value = diskUsageWarning;
            theRow.Cells["ColDiskUsageWarning"].Style.BackColor = !string.IsNullOrEmpty(diskUsageWarning) ? Color.Red : Color.White;
            theRow.Cells["ColDiskUsageWarning"].Style.ForeColor = !string.IsNullOrEmpty(diskUsageWarning) ? Color.White : Color.Black;

            theRow.Cells["ColState"].Value = this.imageList1.Images[overThresholdCount == 0 ? 0 : 1];
            if (iMonitorServer == cntMonitorServer)
            {
                btnRefresh.Enabled = true;
                iMonitorServer = 0;
            }
        }

        private void chkAutoSendEmailtoSupportTeam_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = chkAutoSendEmailtoSupportTeam.Checked;
            if (chkAutoSendEmailtoSupportTeam.Checked)
                CheckServerDataSendEmail();
        }

        private void CheckServerDataSendEmail()
        {
            emailBody = string.Empty;
            cntServer = _configurations.Count;
            foreach (ServerConfigurationData configuration in _configurations)
                GetServerUsageAsyncForMail(configuration);
        }

        private void GetServerUsageAsyncForMail(ServerConfigurationData configurationData)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetServerUsageAsyncForMail), configurationData);
        }

        private void GetServerUsageAsyncForMail(object param)
        {
            if (param == null || !(param is ServerConfigurationData))
            {
                //Report Error
                this.BeginInvoke(new Action(() =>
                {
                    MessageBox.Show("Invalid argument: param", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
                iServer++;
                if (iServer == cntServer)
                {
                    if (emailBody != string.Empty)
                        SendEmail();
                    iServer = 0;
                }
                return;
            }

            ServerConfigurationData configuration = param as ServerConfigurationData;

            try
            {
                ServerLoadData result = ServerLoadHelper.GetServerUsage(configuration.ServerName, configuration.UserName, configuration.Password);

                iServer++;
                //Complete
                this.BeginInvoke(new Action<ServerLoadData>(OnGetServerUsageAsyncCompletedForMail), result);
            }
            catch (Exception ex)
            {
                iServer++;
                if (iServer == cntServer)
                {
                    if (emailBody != string.Empty)
                        SendEmail();
                    iServer = 0;
                }
                //Report Error
                this.BeginInvoke(new Action<string, Exception>(ReportErrorForEmail), configuration.ServerName, ex);
            }
        }

        private void ReportErrorForEmail(string serverName, Exception ex)
        {
            DataGridViewRow theRow = FindRow(serverName);

            if (theRow != null)
            {
                theRow.Cells["ColState"].Value = this.imageList1.Images[2];
                theRow.Cells["ColState"].ToolTipText = ex.Message;
            }
        }

        private void OnGetServerUsageAsyncCompletedForMail(ServerLoadData data)
        {
            if (data == null)
                return;

            DataGridViewRow theRow = FindRow(data.ServerName);
            if (theRow == null)
                return;

            double cpuThreshold = Convert.ToDouble(theRow.Cells["ColCPUThreshold"].Value);
            double ramThreshold = Convert.ToDouble(theRow.Cells["ColRAMThreshold"].Value);
            double diskThreshold = Convert.ToDouble(theRow.Cells["ColDiskThreshold"].Value);

            string diskUsageWarning = string.Empty;
            foreach (string key in data.DiskUsage.Keys)
            {
                if (data.DiskUsage[key] > diskThreshold)
                    diskUsageWarning += string.Format("{0} {1:0}% ", key, data.DiskUsage[key]);
            }

            string CPUUsage = data.CPUUsage > cpuThreshold ? string.Format("CPU使用率: {0}%", data.CPUUsage) : string.Empty;
            string RAMUsage = data.RAMUsage > ramThreshold ? string.Format("内存使用率: {0}%", data.RAMUsage) : string.Empty;
            string DiskUsageWarning = diskUsageWarning == string.Empty ? string.Empty : string.Format("磁盘使用率: {0}", diskUsageWarning);

            if (CPUUsage != string.Empty || RAMUsage != string.Empty || DiskUsageWarning != string.Empty)
                emailBody += string.Format("<B>{0}: <FONT Color=\"Red\">{1} {2} {3}</FONT></B></P>", data.ServerName, CPUUsage, RAMUsage, DiskUsageWarning);

            if (iServer == cntServer)
            {
                if (emailBody != string.Empty)
                    SendEmail();
                iServer = 0;
            }
        }

        private DataGridViewRow FindRow(string serverName)
        {
            //find the corresponding row with the same server name
            DataGridViewRow theRow = null;
            foreach (DataGridViewRow row in dgResult.Rows)
            {
                if (row.Cells["ColServerName"].Value != null &&
                    serverName.Equals(row.Cells["ColServerName"].Value.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    theRow = row;
                    break;
                }
            }
            return theRow;
        }

        private void SendEmail()
        {
            using (MailMessage message = new MailMessage())
            {
                //message.To.Add("1348907384@qq.com");
                ////message.CC.Add("Enginerr1@company.com");
                ////message.CC.Add("Enginerr2@company.com");
                ////message.CC.Add("Enginerr3@company.com");
                //message.Subject = "服务器负载检查工具对CPU、内存和磁盘使用率过大的警告邮件";
                //message.From = new MailAddress("shenqiangbin@163.com");
                //message.IsBodyHtml = true;
                //message.Body = "这封邮件是服务器负载检查工具自动发出的警告邮件，请不要回复这封邮件。<P />" + emailBody;
                //SmtpClient client = new SmtpClient("MailServer.company.com")
                //{
                //    EnableSsl = false
                //};

                EmailDTO dto = new EmailDTO();
                dto.toMail = "1348907384@qq.com";
                dto.subject = "服务器负载检查工具对CPU、内存和磁盘使用率过大的警告邮件";
                dto.body = "这封邮件是服务器负载检查工具自动发出的警告邮件，请不要回复这封邮件。<P />"+emailBody;
                new EmailService().Send(dto);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckServerDataSendEmail();
        }

        private void ServerLoadCheckerUI_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) //判断是否最小化
            {
                ShowInTaskbar = false; //不显示在系统任务栏
                notifyIcon1.Visible = true; //托盘图标可见
                notifyIcon1.ShowBalloonTip(1000);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Show();
                WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
                ShowInTaskbar = true;
                RefreshAllServerStatus();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ShowInTaskbar)
                RefreshAllServerStatus();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            timer2.Enabled = true;
            if (ShowInTaskbar)
                RefreshAllServerStatus();
        }

        private void ServerLoadCheckerUI_Load(object sender, EventArgs e)
        {
            timer3.Interval = ((((DateTime.Now.Minute > 30 ? 60 : 30) - DateTime.Now.Minute)) * 60 - DateTime.Now.Second) * 1000;
            timer3.Enabled = true;
        }
    }
}
