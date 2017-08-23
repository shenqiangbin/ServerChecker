using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;

namespace ServerLoadChecker
{
    public static class ServerLoadHelper
    {
        public static ServerLoadData GetServerUsage(string serverName, string userName, string password)
        {
            // Build an options object for the remote connection
            // if you plan to connect to the remote
            // computer with a different user name
            // and password than the one you are currently using.
            // This example uses the default values. 

            ConnectionOptions options = new ConnectionOptions();
            if (serverName != ".")
            {
                options.Username = userName;
                options.Password = password;
            }

            // Make a connection to a remote computer.
            // Replace the "FullComputerName" section of the
            // string "\\\\FullComputerName\\root\\cimv2" with
            // the full computer name or IP address of the
            // remote computer.
            ManagementScope scope = new ManagementScope("\\\\" + serverName + "\\root\\cimv2", options);
            scope.Connect();

            SelectQuery sq = null;
            ManagementObjectSearcher mos = null;
            ServerLoadData result = new ServerLoadData();
            result.ServerName = serverName;

            //get CPU usage
            sq = new SelectQuery("SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor WHERE Name=\"_Total\"");
            using (mos = new ManagementObjectSearcher(scope, sq))
                result.CPUUsage = Convert.ToDouble(mos.Get().Cast<ManagementObject>().First()["PercentProcessorTime"]);
            //mos.Dispose();

            //get RAM usage
            //get Available RAM size
            sq = new SelectQuery("SELECT * FROM Win32_PerfFormattedData_PerfOS_Memory");
            Int64 available = 0;
            using (mos = new ManagementObjectSearcher(scope, sq))
            {
                available = Convert.ToInt64(mos.Get().Cast<ManagementObject>().First().Properties["AvailableBytes"].Value);
                //get Total RAM size
                sq = new SelectQuery("SELECT * FROM Win32_ComputerSystem");
            }
            using (mos = new ManagementObjectSearcher(scope, sq))
            {
                Int64 total = Convert.ToInt64(mos.Get().Cast<ManagementObject>().First().Properties["TotalPhysicalMemory"].Value);
                //calculate the RAM usage
                result.RAMUsage = 100 * (total - available) / total;
            }

            //get Disk usage
            Dictionary<string, double> diskUsage = new Dictionary<string, double>();
            sq = new SelectQuery("SELECT * FROM win32_logicaldisk");
            using (mos = new ManagementObjectSearcher(scope, sq))
            {
                foreach (ManagementObject disk in mos.Get())
                {
                    if (disk["DriveType"].ToString() == "3")
                    {
                        double freeSpace = Convert.ToDouble(disk["FreeSpace"]);
                        double totalSize = Convert.ToDouble(disk["Size"]);
                        diskUsage.Add(disk["Name"].ToString(), 100 * (totalSize - freeSpace) / totalSize);
                    }
                }
                result.DiskUsage = diskUsage;
            }

            return result;
        }

        public static void ConnectToRemoteDesktop(string serverName, string userName, string password)
        {
            using (Process rdcProcess = new Process())
            {
                rdcProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe");
                rdcProcess.StartInfo.Arguments = string.Format("/generic:TERMSRV/{0} /user:{1} /pass:{2}", serverName, userName, password);
                rdcProcess.Start();

                rdcProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");
                rdcProcess.StartInfo.Arguments = string.Format("/v {0}", serverName);
                rdcProcess.Start();
            }
        }
    }
}
