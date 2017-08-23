using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string host = ".";
            string userName = "administrator";
            string password = "P@$$W0rd";

            ConnectionOptions connectionOptions = new ConnectionOptions();
            if (host != ".")
            {
                connectionOptions.Username = userName;
                connectionOptions.Password = password;
            }
            ManagementScope managementScope = new ManagementScope("//" + host + "/root/cimv2", connectionOptions);
            try
            {
                managementScope.Connect();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ObjectQuery query = new ObjectQuery(
            "SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(managementScope, query);

            ManagementObjectCollection queryCollection = searcher.Get();
            foreach (ManagementObject m in queryCollection)
            {
                // Display the remote computer information
                Console.WriteLine("Computer Name : {0}",
                    m["csname"]);
                Console.WriteLine("Windows Directory : {0}",
                    m["WindowsDirectory"]);
                Console.WriteLine("Operating System: {0}",
                    m["Caption"]);
                Console.WriteLine("Version: {0}", m["Version"]);
                Console.WriteLine("Manufacturer : {0}",
                    m["Manufacturer"]);
            }

            Console.ReadKey();
        }
    }
}
