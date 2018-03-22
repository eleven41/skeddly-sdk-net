using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Skeddly.Model;

namespace Skeddly
{
	public partial class SkeddlyClient : ISkeddlyClient
    {
		#region SSO

		public async Task<AssumeUserWithSamlResponse> AssumeUserWithSamlAsync(AssumeUserWithSamlRequest request)
		{
			// Verify required parameters
			if (request == null)
				throw new ArgumentNullException("request");
			if (String.IsNullOrWhiteSpace(request.SamlResponseBase64))
				throw new ArgumentNullException("request.SamlResponseBase64");

			List<string> queryParameters = new List<string>();

			//if (request.Include != null)
			//{
			//	queryParameters.Add("include=" + String.Join(",", request.Include));
			//}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return await this.InvokePostAsync<Skeddly.Model.AssumeUserWithSamlResponse, AssumeUserWithSamlRequest>("/api/Sso/AssumeUserWithSaml" + queryString, request);
		}

		#endregion
	}
}
