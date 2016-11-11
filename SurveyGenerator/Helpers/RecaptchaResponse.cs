using System.Collections.Generic;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;

namespace SurveyGenerator.Helpers
{
    public class RecaptchaResponse
    {
        private string m_Success;

        [JsonProperty("success")]
        public string Success
        {
            get { return m_Success;}
            set { m_Success = value; }
        }

        private List<string> m_ErrorCodes;

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes
        {
            get { return m_ErrorCodes; }
            set { m_ErrorCodes = value; }
        }

        public static string Validate(string encodedResponse)
        {
            var client = new WebClient();

            string privateKey = ConfigurationManager.AppSettings["RecaptchaPrivateKey"];

            var reply = client.DownloadString($"https://www.google.com/recaptcha/api/siteverify?secret={privateKey}&response={encodedResponse}");

            var captchaResponse = JsonConvert.DeserializeObject<RecaptchaResponse>(reply);
            return captchaResponse.Success;
        }
    }
}