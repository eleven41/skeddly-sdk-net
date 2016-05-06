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
		#region Regions

		public async Task<ListRegionsResponse> ListRegionsAsync(ListRegionsRequest request)
		{
			List<string> queryParameters = new List<string>();

			if (request.Include != null)
			{
				queryParameters.Add("include=" + String.Join(",", request.Include));
			}

			if (request.CloudProviderId != null)
			{
				queryParameters.Add("cloudProviderId=" + request.CloudProviderId);
			}

			if (request.CloudProviderSubTypeId != null)
			{
				queryParameters.Add("cloudProviderSubTypeId=" + request.CloudProviderSubTypeId);
			}

			if (request.CredentialId != null)
			{
				queryParameters.Add("credentialId=" + request.CredentialId);
			}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new ListRegionsResponse()
			{
				Regions = await this.InvokeGetAsync<IEnumerable<Skeddly.Model.Region>>("/api/Regions" + queryString)
			};
		}

		public async Task<GetRegionResponse> GetRegionAsync(GetRegionRequest request)
		{
			List<string> queryParameters = new List<string>();

			if (request.Include != null)
			{
				queryParameters.Add("include=" + String.Join(",", request.Include));
			}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new GetRegionResponse()
			{
				Region = await this.InvokeGetAsync<Skeddly.Model.Region>("/api/Regions/" + request.RegionName + queryString)
			};
		}

		#endregion
	}
}
