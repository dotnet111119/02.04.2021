using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    class Program
    {
        static void Main(string[] args)
        {
            string mailstatus = SendEmail("itayhau@gmail.com", "Testmail", "Hey i have setup my own SMTP server.Let us check it out!!!");
            Console.WriteLine(mailstatus);
            Console.ReadKey();
        }
        public static string SendEmail(string toAddress, string subject, string body)
        {
            string result = "";
            MailMessage message = new MailMessage();
            message.To.Add(new MailAddress("itayhau@gmail.com"));
            message.From = new MailAddress("itaysoft@soft.com");
            message.Subject = "This is a test email";
            message.Body = "This is a quick test email to demonstrate sending emails from .Net";

            try
            {
                SmtpClient client = new SmtpClient("localhost");
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result = "Error sending email.!!!";
            }
            result = "success";
            return result;
        }
    }
}
