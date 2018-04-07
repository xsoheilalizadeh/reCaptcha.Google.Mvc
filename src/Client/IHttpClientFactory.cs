using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Google.ReCaptcha.Mvc.Client
{
    public interface IHttpClientFactory : IDisposable
    {
        HttpClient GetOrCreate(
            Uri baseAddress,
            IDictionary<string, string> defaultRequestHeaders = null,
            TimeSpan? timeout = null,
            long? maxResponseContentBufferSize = null,
            HttpMessageHandler handler = null);
    }
}