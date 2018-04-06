using System;

namespace Google.ReCaptcha.Mvc
{
    public class CaptchException : Exception
    {
        public CaptchException(string massage) : base(massage)
        {
            
        }

        public CaptchException()
        {
            
        }
        public static string ThrowSiteKeyNotInitialized()
        {
            throw new CaptchException("SiteKey does not initialized !");
        }

        public static string ThrowSecretkeyNotInitilized()
        {
            throw new CaptchException("Secretkey does not initialized !");
        }
    }
}