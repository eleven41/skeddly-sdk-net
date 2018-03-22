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
		#region Managed Instance Groups

		public async Task<ListManagedInstanceGroupsResponse> ListManagedInstanceGroupsAsync(ListManagedInstanceGroupsRequest request)
		{
			List<string> queryParameters = new List<string>();

			List<JsonConverter> jsonConverters = new List<JsonConverter>();

			if (request.Include != null)
			{
				queryParameters.Add("include=" + String.Join(",", request.Include));

				// If we want parameters, then
				// add our custom converter to properly handle them.
				if (request.Include.Contains(ManagedInstanceGroupIncludes.Parameters))
					jsonConverters.Add(new Skeddly.JsonConverters.ManagedInstanceScheduleConverter());
			}

			// Add items for the filter
			//if (request.Filter != null)
			//{
				
			//}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new ListManagedInstanceGroupsResponse()
			{
				ManagedInstanceGroups = await this.InvokeGetAsync<IEnumerable<Skeddly.Model.ManagedInstanceGroup>>("/api/ManagedInstanceGroups" + queryString, jsonConverters)
			};
		}

		public Task DeleteManagedInstanceGroupAsync(DeleteManagedInstanceGroupRequest request)
		{
			return this.InvokeDeleteAsync("api/ManagedInstanceGroups/" + request.ManagedInstanceGroupId);
		}

		public async Task<GetManagedInstanceGroupResponse> GetManagedInstanceGroupAsync(GetManagedInstanceGroupRequest request)
		{
			List<string> queryParameters = new List<string>();

			List<JsonConverter> jsonConverters = new List<JsonConverter>();

			if (request.IsIncludeDeleted.HasValue)
			{
				queryParameters.Add("isIncludeDeleted=" + request.IsIncludeDeleted.Value.ToString());
			}

			if (request.Include != null)
			{
				queryParameters.Add("include=" + String.Join(",", request.Include));

				// If we want parameters, then
				// add our custom converter to properly handle them.
				if (request.Include.Contains(ManagedInstanceGroupIncludes.Parameters))
					jsonConverters.Add(new Skeddly.JsonConverters.ManagedInstanceScheduleConverter());
			}

			// Add items for the filter
			//if (request.Filter != null)
			//{

			//}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new GetManagedInstanceGroupResponse()
			{
				ManagedInstanceGroup = await this.InvokeGetAsync<Skeddly.Model.ManagedInstanceGroup>("/api/ManagedInstanceGroups/" + request.ManagedInstanceGroupId + queryString, jsonConverters)
			};
		}

		public async Task<CreateManagedInstanceGroupResponse> CreateManagedInstanceGroupAsync(CreateManagedInstanceGroupRequest request)
		{
			List<string> queryParameters = new List<string>();

			// Our response includes schedules for the new managed instance group.
			// So we need to include a json converter so we properly
			// deserialize into the correct derived parameter classes.
			List<JsonConverter> jsonConverters = new List<JsonConverter>()
			{
				new Skeddly.JsonConverters.ManagedInstanceScheduleConverter()
			};

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new CreateManagedInstanceGroupResponse()
			{
				ManagedInstanceGroup = await this.InvokePostAsync<Skeddly.Model.ManagedInstanceGroup, Skeddly.Model.CreateManagedInstanceGroupRequest>("/api/ManagedInstanceGroups" + queryString, request, jsonConverters)
			};
		}

		public async Task<ModifyManagedInstanceGroupResponse> ModifyManagedInstanceGroupAsync(ModifyManagedInstanceGroupRequest request)
		{
			List<string> queryParameters = new List<string>();

			// Our response includes schedules for the new managed instance group.
			// So we need to include a json converter so we properly
			// deserialize into the correct derived parameter classes.
			List<JsonConverter> jsonConverters = new List<JsonConverter>()
			{
				new Skeddly.JsonConverters.ManagedInstanceScheduleConverter()
			};

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new ModifyManagedInstanceGroupResponse()
			{
				ManagedInstanceGroup = await this.InvokePutAsync<Skeddly.Model.ManagedInstanceGroup, Skeddly.Model.ModifyManagedInstanceGroupRequest>("/api/ManagedInstanceGroups/" + request.ManagedInstanceGroupId + queryString, request, jsonConverters)
			};
		}

		#endregion
	}
}
