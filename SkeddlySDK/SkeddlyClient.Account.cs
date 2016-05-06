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
		#region Account

		public Task<GetAccountInformationResponse> GetAccountInformationAsync(GetAccountInformationRequest request)
		{
			List<string> queryParameters = new List<string>();

			// Add any query parameters if they are added to the request later

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return this.InvokeGetAsync<Skeddly.Model.GetAccountInformationResponse>("/api/Account" + queryString);
		}

		public async Task<GetAccountSettingsResponse> GetAccountSettingsAsync(GetAccountSettingsRequest request)
		{
			List<string> queryParameters = new List<string>();

			// Add any query parameters if they are added to the request later

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new GetAccountSettingsResponse()
			{
				AccountSettings = await this.InvokeGetAsync<Skeddly.Model.AccountSettings>("/api/Account/Settings" + queryString)
			};
		}

		public Task<GetDashboardInformationResponse> GetDashboardInformationAsync(GetDashboardInformationRequest request)
		{
			List<string> queryParameters = new List<string>();

			// Add any query parameters if they are added to the request later

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return this.InvokeGetAsync<Skeddly.Model.GetDashboardInformationResponse>("/api/Account/Dashboard" + queryString);
		}

		public async Task<GetRssFeedInformationResponse> GetRssFeedInformationAsync()
		{
			List<string> queryParameters = new List<string>();

			// Add any query parameters if they are added to the request later

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new GetRssFeedInformationResponse()
			{
				Feed = await this.InvokeGetAsync<Skeddly.Model.RssFeed>("/api/Account/Rss" + queryString)
			};
		}

		public async Task<CreateRssFeedResponse> CreateRssFeedAsync(CreateRssFeedRequest request)
		{
			List<string> queryParameters = new List<string>();

			// Add any query parameters if they are added to the request later

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new CreateRssFeedResponse()
			{
				Feed = await this.InvokePostAsync<Skeddly.Model.RssFeed, Skeddly.Model.CreateRssFeedRequest>("/api/Account/Rss" + queryString, request)
			};
		}

		public Task<GetAccountAliasResponse> GetAccountAliasAsync(GetAccountAliasRequest request)
		{
			List<string> queryParameters = new List<string>();

			// Add any query parameters if they are added to the request later

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return this.InvokeGetAsync<Skeddly.Model.GetAccountAliasResponse>("/api/Account/Alias" + queryString);
		}

		public Task<SetAccountAliasResponse> SetAccountAliasAsync(SetAccountAliasRequest request)
		{
			List<string> queryParameters = new List<string>();

			// Add any query parameters if they are added to the request later

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return this.InvokePostAsync<Skeddly.Model.SetAccountAliasResponse, Skeddly.Model.SetAccountAliasRequest>("/api/Account/Alias" + queryString, request);
		}

		#endregion
	}
}
