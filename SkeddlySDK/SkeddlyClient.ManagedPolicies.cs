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
		#region Managed Policies

		public async Task<ListManagedPoliciesResponse> ListManagedPoliciesAsync(ListManagedPoliciesRequest request)
		{
			List<string> queryParameters = new List<string>();

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new ListManagedPoliciesResponse()
			{
				ManagedPolicies = await this.InvokeGetAsync<IEnumerable<Skeddly.Model.ManagedPolicy>>("/api/ManagedPolicies" + queryString)
			};
		}

		#endregion
	}
}
