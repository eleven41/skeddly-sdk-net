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
		#region ActionExclusions

		public async Task<ListActionExclusionsResponse> ListActionExclusionsAsync(ListActionExclusionsRequest request)
		{
			List<string> queryParameters = new List<string>();

			//if (request.Include != null)
			//{
			//	queryParameters.Add("include=" + String.Join(",", request.Include));
			//}

			if (request.Filter != null)
			{
				if (!String.IsNullOrWhiteSpace(request.Filter.Status))
					queryParameters.Add("filter.Status=" + request.Filter.Status);

				if (!String.IsNullOrWhiteSpace(request.Filter.ResourceType))
					queryParameters.Add("filter.ResourceType=" + request.Filter.ResourceType);
			}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new ListActionExclusionsResponse()
			{
				ActionExclusions = await this.InvokeGetAsync<IEnumerable<Skeddly.Model.ActionExclusion>>("/api/ActionExclusions" + queryString)
			};
		}

		public async Task<GetActionExclusionResponse> GetActionExclusionAsync(GetActionExclusionRequest request)
		{
			// Verify required parameters
			if (request == null)
				throw new ArgumentNullException("request");
			if (String.IsNullOrWhiteSpace(request.ActionExclusionId))
				throw new ArgumentNullException("request.ActionExclusionId");

			List<string> queryParameters = new List<string>();

			//if (request.Include != null)
			//{
			//	queryParameters.Add("include=" + String.Join(",", request.Include));
			//}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new GetActionExclusionResponse()
			{
				ActionExclusion = await this.InvokeGetAsync<Skeddly.Model.ActionExclusion>("/api/ActionExclusions/" + request.ActionExclusionId + queryString)
			};
		}

		public async Task<CreateActionExclusionResponse> CreateActionExclusionAsync(CreateActionExclusionRequest request)
		{
			// Verify required parameters
			if (request == null)
				throw new ArgumentNullException("request");
			if (String.IsNullOrWhiteSpace(request.Name))
				throw new ArgumentNullException("request.Name");
			if (String.IsNullOrWhiteSpace(request.ResourceType))
				throw new ArgumentNullException("request.ResourceType");
			if (String.IsNullOrWhiteSpace(request.ResourceIdentificationMethod))
				throw new ArgumentNullException("request.ResourceIdentificationMethod");

			List<string> queryParameters = new List<string>();

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new CreateActionExclusionResponse()
			{
				ActionExclusion = await this.InvokePostAsync<Skeddly.Model.ActionExclusion, CreateActionExclusionRequest>("/api/ActionExclusions/" + queryString, request)
			};
		}

		public async Task<ModifyActionExclusionResponse> ModifyActionExclusionAsync(ModifyActionExclusionRequest request)
		{
			// Verify required parameters
			if (request == null)
				throw new ArgumentNullException("request");
			if (String.IsNullOrWhiteSpace(request.ActionExclusionId))
				throw new ArgumentNullException("request.ActionExclusionId");

			List<string> queryParameters = new List<string>();

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new ModifyActionExclusionResponse()
			{
				ActionExclusion = await this.InvokePutAsync<Skeddly.Model.ActionExclusion, ModifyActionExclusionRequest>("/api/ActionExclusions/" + request.ActionExclusionId + queryString, request)
			};
		}

		public Task DeleteActionExclusionAsync(DeleteActionExclusionRequest request)
		{
			// Verify required parameters
			if (request == null)
				throw new ArgumentNullException("request");
			if (String.IsNullOrWhiteSpace(request.ActionExclusionId))
				throw new ArgumentNullException("request.ActionExclusionId");

			List<string> queryParameters = new List<string>();

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return this.InvokeDeleteAsync("/api/ActionExclusions/" + request.ActionExclusionId + queryString);
		}


		#endregion
	}
}
