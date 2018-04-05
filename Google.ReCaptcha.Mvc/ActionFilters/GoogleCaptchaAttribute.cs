using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Google.ReCaptcha.Mvc.Client;
using Google.ReCaptcha.Mvc.Configuration;

namespace Google.ReCaptcha.Mvc.ActionFilters
{
    public class GoogleCaptchaAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!GoogleCaptchaConfiguration.EnableInDebuggingMode)
            {
                if (HttpContext.Current.IsDebuggingEnabled)
                {
                    return;
                }
            }

            var response = GetResponseKey(filterContext, "g-recaptcha-response");

            var client = new GoogleCaptchaClient();

            var secretkey = GoogleCaptchaConfiguration.Secretkey;

            var validationKey = GoogleCaptchaConfiguration.ValidationInputName;

            var validationMessage = GoogleCaptchaConfiguration.ValidationMessage;

            if (!Task.Run(() => client.IsAcceptAsync(response, secretkey)).Result)
            {
                filterContext.Controller.ViewData.ModelState.AddModelError(validationKey, validationMessage);

                filterContext.Result = new ViewResult
                {
                    ViewName = filterContext.ActionDescriptor.ActionName,
                    ViewData = filterContext.Controller.ViewData,
                    TempData = filterContext.Controller.TempData
                };
            }

            base.OnActionExecuting(filterContext);
        }

        private static string GetResponseKey(ControllerContext context, string key) =>
            context.RequestContext.HttpContext.Request[key];
    }
}