using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Skeddly.Providers
{
	class DefaultHttpClientProvider : IHttpClientProvider
	{
		public HttpClient CreateHttpClient()
		{
			return new HttpClient();
		}
	}
}
