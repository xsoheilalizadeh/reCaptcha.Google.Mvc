using System;

namespace Google.ReCaptcha.Mvc.Configuration
{
    public static class GoogleCaptchaConfiguration
    {
        public static bool EnableInDebuggingMode { get; private set; }

        public static string Secretkey { get; set; }

        public static string Language { get; private set; } 

        public static string OnLoadCallback  { get; private set; }
        
        public static string ResponseCallback  { get; set; }
    
        public static string Sitekey { get; private set; }

        public static string Render { get; private set; } 

        public static CaptchaTheme Theme { get; private set; }
        
        public static string ValidationInputName { get; private set; } 

        public static string ValidationMessage { get; private set; }

        public static void Register(GoogleCaptchaConfig config)
        {
            Language = config.Language;
            Secretkey = config.Secretkey;
            EnableInDebuggingMode = config.EnableInDebuggingMode;
            OnLoadCallback = config.OnLoadCallback;
            Theme = config.Theme;
            Render = config.Render;
            ResponseCallback = config.ResponseCallback;
            ValidationInputName = config.ValidationInputName;
            ValidationMessage = config.ValidationMessage;

        }
    }
}       