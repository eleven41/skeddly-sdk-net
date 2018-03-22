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
		#region Actions

		public async Task<ListActionsResponse> ListActionsAsync(ListActionsRequest request)
		{
			List<string> queryParameters = new List<string>();

			List<JsonConverter> jsonConverters = new List<JsonConverter>()
			{
				new Skeddly.JsonConverters.ActionScheduleConverter()
			};

			if (request.Include != null)
			{
				queryParameters.Add("include=" + String.Join(",", request.Include));

				// If we want parameters, then
				// add our custom converter to properly handle them.
				if (request.Include.Contains(ActionIncludes.Parameters))
					jsonConverters.Add(new Skeddly.JsonConverters.ActionConverter());
			}

			// Add items for the filter
			if (request.Filter != null)
			{
				if (request.Filter.ActionTypes != null)
				{
					queryParameters.Add("filter.actionTypes=" + String.Join(",", request.Filter.ActionTypes));
				}
				if (request.Filter.CredentialIds != null)
				{
					queryParameters.Add("filter.credentialIds=" + String.Join(",", request.Filter.CredentialIds));
				}
				if (request.Filter.IsEnabled.HasValue)
				{
					queryParameters.Add("filter.isEnabled=" + request.Filter.IsEnabled.Value.ToString());
				}
				if (request.Filter.Regions != null)
				{
					queryParameters.Add("filter.regions=" + String.Join(",", request.Filter.Regions));
				}
				if (request.Filter.Tags != null)
				{
					queryParameters.Add("filter.tags=" + String.Join(",", request.Filter.Tags));

					if (!String.IsNullOrEmpty(request.Filter.TagsRequired))
						queryParameters.Add("filter.tagsRequired=" + request.Filter.TagsRequired);
				}

				if (request.Filter.ActionClasses != null)
				{
					queryParameters.Add("filter.actionClasses=" + String.Join(",", request.Filter.ActionClasses));
				}

				if (request.Filter.ManagedInstanceIds != null)
				{
					queryParameters.Add("filter.managedInstanceIds=" + String.Join(",", request.Filter.ManagedInstanceIds));
				}
			}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new ListActionsResponse()
			{
				Actions = await this.InvokeGetAsync<IEnumerable<Skeddly.Model.Action>>("/api/Actions" + queryString, jsonConverters)
			};
		}

		public async Task<GetActionResponse> GetActionAsync(GetActionRequest request)
		{
			List<string> queryParameters = new List<string>();

			List<JsonConverter> jsonConverters = new List<JsonConverter>()
			{
				new Skeddly.JsonConverters.ActionScheduleConverter()
			};

			if (request.Include != null)
			{
				queryParameters.Add("include=" + String.Join(",", request.Include));

				// If we want parameters, then
				// add our custom converter to properly handle them.
				if (request.Include.Contains(ActionIncludes.Parameters))
					jsonConverters.Add(new Skeddly.JsonConverters.ActionConverter());
			}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new GetActionResponse()
			{
				Action = await this.InvokeGetAsync<Skeddly.Model.Action>("/api/Actions/" + request.ActionId + queryString, jsonConverters)
			};
		}

		public async Task<GetActionTagsResponse> GetActionTagsAsync(GetActionTagsRequest request)
		{
			List<string> queryParameters = new List<string>();

			if (request.Filter != null)
			{
				if (request.Filter.ActionClasses != null)
				{
					queryParameters.Add("filter.actionClasses=" + String.Join(",", request.Filter.ActionClasses));
				}
			}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new GetActionTagsResponse()
			{
				Tags = await this.InvokeGetAsync<IEnumerable<Skeddly.Model.ActionTag>>("/api/Actions/Tags" + queryString)
			};
		}

		public async Task<GetActionTypesResponse> GetActionTypesAsync(GetActionTypesRequest request)
		{
			List<string> queryParameters = new List<string>();

			if (request.Filter != null)
			{
				if (request.Filter.ActionClasses != null)
				{
					queryParameters.Add("filter.actionClasses=" + String.Join(",", request.Filter.ActionClasses));
				}
			}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new GetActionTypesResponse()
			{
				ActionTypes = await this.InvokeGetAsync<IEnumerable<Skeddly.Model.ActionType>>("/api/Actions/Types" + queryString)
			};
		}

		public async Task<GetActionRegionsResponse> GetActionRegionsAsync(GetActionRegionsRequest request)
		{
			List<string> queryParameters = new List<string>();

			if (request.Filter != null)
			{
				if (request.Filter.ActionClasses != null)
				{
					queryParameters.Add("filter.actionClasses=" + String.Join(",", request.Filter.ActionClasses));
				}
			}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new GetActionRegionsResponse()
			{
				Regions = await this.InvokeGetAsync<IEnumerable<Skeddly.Model.ActionRegion>>("/api/Actions/Regions" + queryString)
			};
		}

		public Task DeleteActionAsync(DeleteActionRequest request)
		{
			return this.InvokeDeleteAsync("api/Actions/" + request.ActionId);
		}

		public async Task<ExecuteActionResponse> ExecuteActionAsync(ExecuteActionRequest request)
		{
			return new ExecuteActionResponse()
			{
				ActionExecution = await this.InvokePutAsync<ActionExecution, ExecuteActionRequest>("api/Actions/" + request.ActionId + "/Execute", request)
			};
		}

		#endregion
	}
}
