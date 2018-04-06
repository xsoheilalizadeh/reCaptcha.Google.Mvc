# reCaptcha.Google.Mvc

Install Nuget Package:

`Install-Package reCaptcha.Google.Mvc -Version 1.0.1`

**Documention**

**configure Captcha**

In `Global.asax` file and `Application_Start` method you can config Google reCaptcha:

``
  GoogleCaptchaConfiguration.Register(new GoogleCaptchaConfig(CaptchaTheme.Light)
            {
                EnableInDebuggingMode = false,
                Secretkey = "yourSecretkey",
                Sitekey = "yourSitekey",
            });

``

