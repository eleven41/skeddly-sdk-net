using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Skeddly.Providers
{
    public interface IHttpClientProvider
    {
		HttpClient CreateHttpClient();
    }
}
