using System;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace SurveyGenerator.Helpers
{
    public static class HtmlHelpers
    {
        public static IHtmlString ReCaptcha(this HtmlHelper helper)
        {
            StringBuilder sb = new StringBuilder();
            string publicKey = WebConfigurationManager.AppSettings["RecaptchaPublicKey"];
            sb.AppendLine("<script type=\"text/javascript\" src = 'https://www.google.com/recaptcha/api.js' ></script> ");
            sb.AppendLine("");
            sb.AppendLine("<div class=\"g-recaptcha\" data-sitekey=\"" + publicKey + "\"></div>");
            return MvcHtmlString.Create(sb.ToString());
        }
    }
}