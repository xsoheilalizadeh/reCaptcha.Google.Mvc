# reCaptcha.Google.Mvc

Install Nuget Package:

```
Install-Package reCaptcha.Google.Mvc
```

***Documention***

**Configure Captcha**

In `Global.asax` file and `Application_Start` method you can config Google reCaptcha:

```c#
GoogleCaptchaConfiguration.Register(new GoogleCaptchaConfig(CaptchaTheme.Light)
{
    EnableInDebuggingMode = false,
    Secretkey = "yourSecretkey",
    Sitekey = "yourSitekey",
});
```

**Usage**

To render Captcha use `Html.RenderCaptcha()`:

```razor
@Html.RenderCaptcha()
@Html.RenderCaptcha("siteKey") // also you set Sitekey here
```

To render Captcha script  use `Html.RenderCaptchaScript()`:

```razor
@Html.RenderCaptchaScript()
```

To validation request use `GoogleCaptcha` on the action method:

```c#
[HttpPost]
[Route("sign-up")]
[GoogleCaptcha]
public ActionResult Register()
{
    // more code
}
```





