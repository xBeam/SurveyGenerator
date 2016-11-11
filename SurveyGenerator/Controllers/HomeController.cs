using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SurveyGenerator.Context;
using SurveyGenerator.Helpers;
using SurveyGenerator.Models;

namespace SurveyGenerator.Controllers
{
    public class HomeController : Controller
    {
        private SurveyDbContext db = new SurveyDbContext();

        public const int PageSize = 8;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult> SendEmail(EmailFormModel model, string recaptcha)
        {
            if (ModelState.IsValid)
            {
                bool isCaptchaValid = RecaptchaResponse.Validate(recaptcha) == "True";
                if (isCaptchaValid)
                {
                    var emailTo = ConfigurationManager.AppSettings["emailReceiver"];
                    var keys = ConfigurationManager.AppSettings.AllKeys.Where(k => k.StartsWith("email"));
                    var emails = keys.Select(k => new KeyValuePair<string, string>
                        (k, ConfigurationManager.AppSettings[k]));

                    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                    var message = new MailMessage();

                    foreach (var item in emails)
                    {
                        message.To.Add(new MailAddress(item.Value));
                    }

                    message.Subject = "New Trump Request";
                    message.Body = string.Format(body, model.FromName, model.FromEmail, model.MessageToSend);
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient())
                    {
                        await smtp.SendMailAsync(message);
                        return Json("Your message has been sent");
                    }
                }
                return Json("Please verify that you are not a robot");

            }
            return Json("Something went wrong");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}