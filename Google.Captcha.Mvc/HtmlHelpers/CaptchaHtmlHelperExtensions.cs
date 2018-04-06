using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI.HtmlControls;
using Google.ReCaptcha.Mvc.Configuration;

namespace Google.ReCaptcha.Mvc.HtmlHelpers
{
    public static class CaptchaHtmlHelperExtensions
    {
        public static MvcHtmlString RenderCaptcha(this HtmlHelper helper, string sitekey = null)
        {
            var validationInputName = GoogleCaptchaConfiguration.ValidationInputName;
            
            var captchaTag = new TagBuilder("div");

            var htmlString = new StringBuilder();

            var hiddenInput = helper.Hidden(validationInputName);

            if (helper.ViewData.ModelState[validationInputName] != null &&
                helper.ViewData.ModelState[validationInputName].Errors.Any())
            {
                var validationInput = helper.ValidationMessage(validationInputName);

                htmlString.AppendLine(validationInput.ToHtmlString());
            }

            captchaTag.Attributes.Add("class", "g-recaptcha");

            captchaTag.Attributes.Add("data-sitekey", sitekey ?? GoogleCaptchaConfiguration.Sitekey ?? CaptchException.ThrowSiteKeyNotInitialized());

            captchaTag.Attributes.Add("data-theme", GoogleCaptchaConfiguration.Theme.ToString().ToLower());

            captchaTag.Attributes.Add("data-callback", GoogleCaptchaConfiguration.ResponseCallback);

            htmlString.AppendLine(captchaTag.ToString());
            
            htmlString.AppendLine(hiddenInput.ToHtmlString());

            return MvcHtmlString.Create(htmlString.ToString());
        }

        public static MvcHtmlString RenderCaptchaScript(this HtmlHelper helper)
        {
            var captchaScriptTag = new TagBuilder("script");

            var scriptSrcUri = new Uri("https://www.google.com/recaptcha/api.js");

            scriptSrcUri.AddParameter(CaptchaConstraints.OnloadCallback, GoogleCaptchaConfiguration.OnLoadCallback);

            scriptSrcUri.AddParameter(CaptchaConstraints.Language, GoogleCaptchaConfiguration.Language);

            scriptSrcUri.AddParameter(CaptchaConstraints.Render, GoogleCaptchaConfiguration.Render);

            captchaScriptTag.Attributes.Add("src", scriptSrcUri.ToString());

            captchaScriptTag.Attributes.Add("async", string.Empty);

            captchaScriptTag.Attributes.Add("defer", string.Empty);

            return MvcHtmlString.Create(captchaScriptTag.ToString());
        }


        private static Uri AddParameter(this Uri url, string paramName, string paramValue)
        {
            if (string.IsNullOrEmpty(paramName))
            {
                return url;
            }

            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            query[paramName] = paramValue;
            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }
    }
}