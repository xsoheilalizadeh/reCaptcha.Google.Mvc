namespace Google.ReCaptcha.Mvc.Configuration
{
    public class GoogleCaptchaConfig
    {
        public GoogleCaptchaConfig(CaptchaTheme theme)
        {
            Theme = theme;
        }

        public bool EnableInDebuggingMode { get; set; }

        public string Secretkey { get; set; }

        public string Language { get; set; } = "en";

        public string OnLoadCallback  { get; set; }
        
        public string ResponseCallback  { get; set; }

        public string Sitekey { get; set; }

        public string Render { get; set; } = "onload";

        public CaptchaTheme Theme { get; }

        public string ValidationInputName { get; set; } = "google_chaptcha_validation";
        
        public string ValidationMessage { get;  set; } = "Please confirm your identity";

    }
}               