using EASendMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt");

                // Your gmail email address
                oMail.From = "dotnet31102018@gmail.com";

                // Set recipient email address
                oMail.To = "dotnet31102018@gmail.com";

                // Set email subject
                oMail.Subject = "test email from gmail account";

                // Set email body
                oMail.TextBody = "Hello from gmail smtp";

                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");

                // Gmail user authentication
                // For example: your email is "gmailid@gmail.com", then the user should be the same
                oServer.User = "dotnet31102018@gmail.com";
                oServer.Password = "updateeeeeeeeeeeeeeeeeeeeeeeeeeeeee!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11";

                // If you want to use direct SSL 465 port,
                // please add this line, otherwise TLS will be used.
                // oServer.Port = 465;

                // set 587 TLS port;
                oServer.Port = 587;

                // detect SSL/TLS automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                Console.WriteLine("start to send email over SSL ...");

                EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }
            Console.WriteLine("Success!");
        }
    }
}
