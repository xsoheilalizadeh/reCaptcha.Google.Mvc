namespace Google.ReCaptcha.Mvc.Configuration
{
    public class CaptchaConstraints
    {
        public static string OnloadCallback { get; } = "onload";
        
        public static string Language { get; } = "hl";

        public static string Render { get;  } = "render";

        public static string ValidationInputName { get; } = "";
    }
}       