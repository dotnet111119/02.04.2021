using EASendMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WpfPasswordEmail.Controllers
{
    public class HomeController : Controller
    {
        // localhost:9005/Home/Index
        // localhost:9005
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            //return Content("Hello world!");

            //return Redirect("https://www.ynet.co.il/home/0,7340,L-8,00.html");

            return new FilePathResult("~/Views/Home/HtmlPage1.html", "text/html");
        }

        // localhost:9005/Home/EmailVerify
        public ActionResult EmailVerify()
        {
            var q = Request.QueryString;
            var guid = q.Get("guid");

            object user_name = HttpContext.Application[guid];// Session["guid"];
            if (user_name == null)
            {
                return Content($"<p1 style=\"color:red\">NO GUID</p1>");
            }

                return Content($"Email verified! for {user_name}");
 

            //return Content($"<p1 style=\"color:red\">WRONG GUID</p1>");
        }

        // localhost:9005/Home/SendEmail
        public ActionResult SendEmail()
        {
            ViewBag.Title = "Send Email";

            try
            {
                SmtpMail oMail = new SmtpMail("TryIt");

                // Your gmail email address
                oMail.From = "dotnet31102018@gmail.com";

                // Set recipient email address
                oMail.To = "itayhau@gmail.com";

                // Set email subject
                oMail.Subject = "test email from gmail account";

                string guid = Guid.NewGuid().ToString();

                //Session["guid"] = guid; // insert into THIS session a key named guid and its value
                HttpContext.Application[guid] = "itayhau@gmail.com"; // insert into THIS session a key named guid and its value

                // Set email body
                oMail.TextBody = "Welcome\nclick link : http://localhost:9005/home/EmailVerify?guid=" + guid;

                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");

                // Gmail user authentication
                // For example: your email is "gmailid@gmail.com", then the user should be the same
                oServer.User = "dotnet31102018@gmail.com";
                oServer.Password = "updateeeeeeeeeeeeeeeeeeeeeeeeeee!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";

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

                return Content($"<p1 style=\"color:red\">ERROR {ep.Message }</p1>");
            }
            return Content("Verification sent to your adress !");
        }
    }
}
