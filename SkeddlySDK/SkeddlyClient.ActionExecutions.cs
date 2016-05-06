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
		#region Upcoming

		public async Task<ListUpcomingActionExecutionsResponse> ListUpcomingActionExecutionsAsync(ListUpcomingActionExecutionsRequest request)
		{
			List<string> queryParameters = new List<string>();

			// Add items for the filter
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

			return new ListUpcomingActionExecutionsResponse()
			{
				Actions = await this.InvokeGetAsync<IEnumerable<Skeddly.Model.UpcomingActionExecution>>("/api/ActionExecutions/Upcoming" + queryString)
			};
		}

		#endregion

		#region Action Executions

		public async Task<ListActionExecutionsResponse> ListActionExecutionsAsync(ListActionExecutionsRequest request)
		{
			List<string> queryParameters = new List<string>();

			// Add items for the filter
			if (request.Filter != null)
			{
				if (request.Filter.Status.HasValue)
				{
					queryParameters.Add("filter.status=" + request.Filter.Status.ToString());
				}

				if (request.Filter.Range != null)
				{
					queryParameters.Add("filter.range.inclusiveStart=" + GetISO8601String(request.Filter.Range.InclusiveStart));
					queryParameters.Add("filter.range.exclusiveEnd=" + GetISO8601String(request.Filter.Range.ExclusiveEnd));
				}

				if (request.Filter.DateComparesTo.HasValue)
				{
					queryParameters.Add("filter.dateComparesTo=" + request.Filter.DateComparesTo.ToString());
				}

				if (request.Filter.ActionIds != null)
				{
					queryParameters.Add("filter.actionIds=" + String.Join(",", request.Filter.ActionIds));
				}

				if (request.Filter.CredentialIds != null)
				{
					queryParameters.Add("filter.credentialIds=" + String.Join(",", request.Filter.CredentialIds));
				}

				if (request.Filter.ActionClasses != null)
				{
					queryParameters.Add("filter.actionClasses=" + String.Join(",", request.Filter.ActionClasses));
				}
			}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new ListActionExecutionsResponse()
			{
				ActionExecutions = await this.InvokeGetAsync<IEnumerable<Skeddly.Model.ActionExecution>>("/api/ActionExecutions" + queryString)
			};
		}

		private static string GetISO8601String(DateTime date)
		{
			if (date.Kind == DateTimeKind.Local)
				date = date.ToUniversalTime();
			else if (date.Kind == DateTimeKind.Unspecified)
				date = DateTime.SpecifyKind(date, DateTimeKind.Utc);
			return date.ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z");
		}

		public async Task<GetActionExecutionResponse> GetActionExecutionAsync(GetActionExecutionRequest request)
		{
			List<string> queryParameters = new List<string>();

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new GetActionExecutionResponse()
			{
				ActionExecution = await this.InvokeGetAsync<Skeddly.Model.ActionExecution>("/api/ActionExecutions/" + request.ActionExecutionId + queryString)
			};
		}

		public async Task<CancelActionExecutionResponse> CancelActionExecutionAsync(CancelActionExecutionRequest request)
		{
			List<string> queryParameters = new List<string>();

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new CancelActionExecutionResponse()
			{
				ActionExecution = await this.InvokePutAsync<Skeddly.Model.ActionExecution, Skeddly.Model.CancelActionExecutionRequest>("/api/ActionExecutions/" + request.ActionExecutionId + "/Cancel" + queryString, request)
			};
		}

		public async Task<GetActionExecutionLogResponse> GetActionExecutionLogAsync(GetActionExecutionLogRequest request)
		{
			if (request == null)
				throw new ArgumentNullException("request");
			if (request.TargetStream == null)
				throw new ArgumentNullException("request.TargetStream");

			List<string> queryParameters = new List<string>();

			if (!String.IsNullOrEmpty(request.Marker))
			{
				queryParameters.Add("marker=" + request.Marker);
			}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			var headers = await this.InvokeGetAsync("/api/ActionExecutions/" + request.ActionExecutionId + "/Log" + queryString, request.TargetStream);

			var result = new GetActionExecutionLogResponse()
			{
				NextMarker = null,
				More = "none"
			};

			// Get values from the headers
			IEnumerable<string> values;
			if (headers.TryGetValues("X-Skeddly-Next-Marker", out values))
			{
				result.NextMarker = values.First();
			}

			if (headers.TryGetValues("X-Skeddly-More", out values))
			{
				result.More = values.First();
			}

			return result;
		}

		#endregion
	}
}
