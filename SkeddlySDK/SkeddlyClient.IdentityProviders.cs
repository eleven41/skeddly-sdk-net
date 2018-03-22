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
		#region IdentityProviders

		public async Task<ListIdentityProvidersResponse> ListIdentityProvidersAsync(ListIdentityProvidersRequest request)
		{
			List<string> queryParameters = new List<string>();

			//if (request.Include != null)
			//{
			//	queryParameters.Add("include=" + String.Join(",", request.Include));
			//}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new ListIdentityProvidersResponse()
			{
				IdentityProviders = await this.InvokeGetAsync<IEnumerable<Skeddly.Model.IdentityProvider>>("/api/Sso/IdentityProviders" + queryString)
			};
		}

		public async Task<GetIdentityProviderResponse> GetIdentityProviderAsync(GetIdentityProviderRequest request)
		{
			// Verify required parameters
			if (request == null)
				throw new ArgumentNullException("request");
			if (String.IsNullOrWhiteSpace(request.IdentityProviderId))
				throw new ArgumentNullException("request.IdentityProviderId");

			List<string> queryParameters = new List<string>();

			if (request.Include != null)
			{
				queryParameters.Add("include=" + String.Join(",", request.Include));
			}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new GetIdentityProviderResponse()
			{
				IdentityProvider = await this.InvokeGetAsync<Skeddly.Model.IdentityProvider>("/api/Sso/IdentityProviders/" + request.IdentityProviderId + queryString)
			};
		}

		public async Task<CreateIdentityProviderResponse> CreateIdentityProviderAsync(CreateIdentityProviderRequest request)
		{
			// Verify required parameters
			if (request == null)
				throw new ArgumentNullException("request");
			if (String.IsNullOrWhiteSpace(request.Name))
				throw new ArgumentNullException("request.Name");
			if (String.IsNullOrWhiteSpace(request.ProviderType))
				throw new ArgumentNullException("request.ProviderType");
			if (String.IsNullOrWhiteSpace(request.SamlMetadataBase64))
				throw new ArgumentNullException("request.SamlMetadataBase64");

			List<string> queryParameters = new List<string>();

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new CreateIdentityProviderResponse()
			{
				IdentityProvider = await this.InvokePostAsync<Skeddly.Model.IdentityProvider, CreateIdentityProviderRequest>("/api/Sso/IdentityProviders/" + queryString, request)
			};
		}

		public async Task<ModifyIdentityProviderResponse> ModifyIdentityProviderAsync(ModifyIdentityProviderRequest request)
		{
			// Verify required parameters
			if (request == null)
				throw new ArgumentNullException("request");
			if (String.IsNullOrWhiteSpace(request.IdentityProviderId))
				throw new ArgumentNullException("request.IdentityProviderId");

			List<string> queryParameters = new List<string>();

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new ModifyIdentityProviderResponse()
			{
				IdentityProvider = await this.InvokePutAsync<Skeddly.Model.IdentityProvider, ModifyIdentityProviderRequest>("/api/Sso/IdentityProviders/" + request.IdentityProviderId + queryString, request)
			};
		}

		public Task DeleteIdentityProviderAsync(DeleteIdentityProviderRequest request)
		{
			// Verify required parameters
			if (request == null)
				throw new ArgumentNullException("request");
			if (String.IsNullOrWhiteSpace(request.IdentityProviderId))
				throw new ArgumentNullException("request.IdentityProviderId");

			List<string> queryParameters = new List<string>();

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return this.InvokeDeleteAsync("/api/Sso/IdentityProviders/" + request.IdentityProviderId + queryString);
		}


		#endregion
	}
}
