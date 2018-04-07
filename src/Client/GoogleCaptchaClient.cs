using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Google.ReCaptcha.Mvc.Client
{
    public class GoogleCaptchaClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GoogleCaptchaClient()
        {
            _httpClientFactory = new HttpClientFactory();
        }

        public async Task<bool> IsAcceptAsync(string response, string secretkey)
        {
            var url = new Uri( $"https://www.google.com/recaptcha/api/siteverify?secret={secretkey}&response={response}");

            var client = _httpClientFactory.GetOrCreate(url);

            var result = await client.GetStringAsync(url).ConfigureAwait(false);

            return (bool) JObject.Parse(result).SelectToken("success");
        }
    }
}