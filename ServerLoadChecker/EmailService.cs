using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ServerLoadChecker
{
    /// <summary>
    /// 配置文件中的stmp地址和端口参照
    /// http://blog.csdn.net/haunghui6579/article/details/22337477
    /// 注意：QQ邮箱如果是个人邮箱的话，密码使用的是“授权码”
    /// 163邮箱，内容不规范邮件也会发送失败
    /// </summary>
    public class EmailService
    {
        private static string EMAIL_HOST = ConfigurationManager.AppSettings.Get("email-host");
        private static string EMAIL_PORT = ConfigurationManager.AppSettings.Get("email-port");
        private static string EMAIL_ACCOUNT = ConfigurationManager.AppSettings.Get("email-account");
        private static string EMAIL_PASSWORD = ConfigurationManager.AppSettings.Get("email-password");

        private SmtpClient client;

        public EmailService()
        {
            client = new SmtpClient();
            client.Host = EMAIL_HOST;
            client.Port = Int32.Parse(EMAIL_PORT);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;  
            client.Credentials = new NetworkCredential(EMAIL_ACCOUNT, EMAIL_PASSWORD);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        public void Send(EmailDTO email)
        {
            var message = new MailMessage();
            message.From = new MailAddress(EMAIL_ACCOUNT);
            message.To.Clear();
            message.To.Add(email.toMail);
            foreach (var item in email.ChaoSongMails)
            {
                message.CC.Add(item);
            }
            message.Body = email.body;
            message.Subject = email.subject;
            message.IsBodyHtml = true;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Priority = MailPriority.High;
            //client.SendAsync(message, null);

            client.Send(message);
        }
    }

    public class EmailDTO
    {
        public string toMail;
        public List<string> ChaoSongMails = new List<string>();
        public string subject;
        public string body;
    }
}
