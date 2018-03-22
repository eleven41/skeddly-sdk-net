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
		#region Reports

		public async Task<GetEstimatedCostSavingsReportResponse> GetEstimatedCostSavingsReportAsync(GetEstimatedCostSavingsReportRequest request)
		{
			List<string> queryParameters = new List<string>();

			if (request.Range != null)
			{
				queryParameters.Add("range.inclusiveStart=" + GetISO8601String(request.Range.InclusiveStart));
				queryParameters.Add("range.exclusiveEnd=" + GetISO8601String(request.Range.ExclusiveEnd));
			}

			if (request.CredentialIds != null)
			{
				queryParameters.Add("credentialIds=" + String.Join(",", request.CredentialIds));
			}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new GetEstimatedCostSavingsReportResponse()
			{
				Report = await this.InvokeGetAsync<Skeddly.Model.EstimatedCostSavingsReport>("/api/Reports/EstimatedCostSavings" + queryString)
			};
		}
		
		#endregion
	}
}
