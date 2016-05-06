using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Skeddly.Model;

namespace Skeddly
{
	public partial class SkeddlyClient : ISkeddlyClient
    {
		#region Credentials

		/// <summary>
		/// Retrieves the list of credentials for the authorized account.
		/// </summary>
		/// <returns>The list of credentials.</returns>
		public async Task<ListCredentialsResponse> ListCredentialsAsync(ListCredentialsRequest request)
		{
			return new ListCredentialsResponse()
			{
				Credentials = await this.InvokeGetAsync<IEnumerable<Credential>>("api/Credentials")
			};
		}

		public async Task<GetCredentialResponse> GetCredentialAsync(GetCredentialRequest request)
		{
			List<string> queryParameters = new List<string>();

			if (request.IsIncludeDeleted.HasValue)
			{
				queryParameters.Add("isIncludeDeleted=" + request.IsIncludeDeleted.Value.ToString());
			}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new GetCredentialResponse()
			{
				Credential = await this.InvokeGetAsync<Credential>("api/Credentials/" + request.CredentialId + queryString)
			};
		}

		public async Task<CreateCredentialResponse> CreateCredentialAsync(CreateCredentialRequest request)
		{
			return new CreateCredentialResponse()
			{
				Credential = await this.InvokePostAsync<Credential, CreateCredentialRequest>("api/Credentials/", request)
			};
		}

		public Task DeleteCredentialAsync(DeleteCredentialRequest request)
		{
			return this.InvokeDeleteAsync("api/Credentials/" + request.CredentialId);
		}

		public async Task<GenerateIamPolicyResponse> GenerateIamPolicyAsync(GenerateIamPolicyRequest request)
		{
			return new GenerateIamPolicyResponse()
			{
				IamPolicy = await this.InvokeGetAsync<string>("api/Credentials/" + request.CredentialId + "/IamPolicy")
			};
		}

		public async Task<UpdateCredentialResponse> UpdateCredentialAsync(UpdateCredentialRequest request)
		{
			return new UpdateCredentialResponse()
			{
				Credential = await this.InvokePutAsync<Credential, UpdateCredentialRequest>("api/Credentials/" + request.CredentialId, request)
			};
		}

		public async Task<GenerateAmazonIamRoleExternalIdResponse> GenerateAmazonIamRoleExternalIdAsync(GenerateAmazonIamRoleExternalIdRequest request)
		{
			return new GenerateAmazonIamRoleExternalIdResponse()
			{
				AmazonIamRoleExternalId = await this.InvokeGetAsync<AmazonIamRoleExternalId>("api/Credentials/GenerateAmazonIamRoleExternalId")
			};
		}


		#endregion
	}
}
