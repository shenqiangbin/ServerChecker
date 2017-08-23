using System.Collections.Generic;

namespace ServerLoadChecker
{
    public class ServerLoadData
    {
        /// <summary>
        /// 服务器工具名
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// CPU使用率
        /// </summary>
        public double CPUUsage { get; set; }

        /// <summary>
        /// 内存使用率
        /// </summary>
        public double RAMUsage { get; set; }

        /// <summary>
        /// 磁盘使用率
        /// </summary>
        public Dictionary<string, double> DiskUsage { get; set; }
    }
}
