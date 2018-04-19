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

			// Add items for the filter
			if (request.Filter != null)
			{
				if (request.Filter.TimeZoneIds != null)
				{
					var encodedTimeZoneIds = request.Filter.TimeZoneIds
						.Select(t => Skeddly.Helpers.WebHelpers.UrlEncode(t));

					queryParameters.Add("filter.timeZoneIds=" + String.Join(",", encodedTimeZoneIds));
				}
			}

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
			if (String.IsNullOrEmpty(request.TimeZoneId))
				throw new ArgumentNullException("request.TimeZoneId");

			List<string> queryParameters = new List<string>();

			string encodedTimeZoneId = Skeddly.Helpers.WebHelpers.UrlEncode(request.TimeZoneId);
			queryParameters.Add("filter.timeZoneIds=" + encodedTimeZoneId);

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			var results = await this.InvokeGetAsync<IEnumerable<Skeddly.Model.TimeZone>>("/api/TimeZones/" + queryString);
			if (!results.Any())
				throw new Skeddly.Model.TimeZoneNotFoundException("Time zone not found: " + request.TimeZoneId);
			return new GetTimeZoneResponse()
			{
				TimeZone = results.First(),
			};
		}

		#endregion
	}
}
