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
		#region Managed Instances

		public async Task<ListManagedInstancesResponse> ListManagedInstancesAsync(ListManagedInstancesRequest request)
		{
			List<string> queryParameters = new List<string>();

			// Add items for the filter
			if (request.Filter != null)
			{
				if (request.Filter.CredentialIds != null)
				{
					queryParameters.Add("filter.credentialIds=" + String.Join(",", request.Filter.CredentialIds));
				}

				if (request.Filter.ManagedInstanceIds != null)
				{
					queryParameters.Add("filter.managedInstanceIds=" + String.Join(",", request.Filter.ManagedInstanceIds));
				}

				if (request.Filter.IsIncludeDeleted.HasValue)
				{
					queryParameters.Add("filter.isIncludeDeleted=" + request.Filter.IsIncludeDeleted.Value.ToString());
				}
			}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new ListManagedInstancesResponse()
			{
				ManagedInstances = await this.InvokeGetAsync<IEnumerable<Skeddly.Model.ManagedInstance>>("/api/ManagedInstances" + queryString)
			};
		}

		#endregion
	}
}
