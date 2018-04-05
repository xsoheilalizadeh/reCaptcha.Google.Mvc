using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Google.ReCaptcha.Mvc.Client
{
    public class GoogleCaptchaClient 
    {
        public async Task<bool> IsAcceptAsync(string response, string secretkey)
        {
            using (var client = new HttpClient())
            {
                var url = $"https://www.google.com/recaptcha/api/siteverify?secret={secretkey}&response={response}";
                
                var result = await client.GetStringAsync(url).ConfigureAwait(false);
                
                return (bool) JObject.Parse(result).SelectToken("success");
            }
        }
    }
}