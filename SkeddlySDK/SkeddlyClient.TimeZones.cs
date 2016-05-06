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
		#region Time Zones

		public async Task<ListTimeZonesResponse> ListTimeZonesAsync(ListTimeZonesRequest request)
		{
			List<string> queryParameters = new List<string>();

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new ListTimeZonesResponse()
			{
				TimeZones = await this.InvokeGetAsync<IEnumerable<Skeddly.Model.TimeZone>>("/api/TimeZones" + queryString)
			};
		}

		public async Task<GetTimeZoneResponse> GetTimeZoneAsync(GetTimeZoneRequest request)
		{
			List<string> queryParameters = new List<string>();

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new GetTimeZoneResponse()
			{
				TimeZone = await this.InvokeGetAsync<Skeddly.Model.TimeZone>("/api/TimeZones/" + request.TimeZoneId + queryString)
			};
		}

		#endregion
	}
}
