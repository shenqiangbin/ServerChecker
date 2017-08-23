
namespace ServerLoadChecker
{
    public class ServerConfigurationData
    {
        public string ServerName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public decimal CPUThreshold { get; set; }

        public decimal RAMThreshold { get; set; }

        public decimal DiskThreshold { get; set; }
    }
}
