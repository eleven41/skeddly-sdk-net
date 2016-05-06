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
		#region Users

		public async Task<ListUsersResponse> ListUsersAsync(ListUsersRequest request)
		{
			List<string> queryParameters = new List<string>();

			if (request.Include != null)
			{
				queryParameters.Add("include=" + String.Join(",", request.Include));
			}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new ListUsersResponse()
			{
				Users = await this.InvokeGetAsync<IEnumerable<Skeddly.Model.User>>("/api/Users" + queryString)
			};
		}

		public async Task<GetUserResponse> GetUserAsync(GetUserRequest request)
		{
			// Verify required parameters
			if (request == null)
				throw new ArgumentNullException("request");
			if (String.IsNullOrWhiteSpace(request.UserId))
				throw new ArgumentNullException("request.UserId");

			List<string> queryParameters = new List<string>();

			if (request.Include != null)
			{
				queryParameters.Add("include=" + String.Join(",", request.Include));
			}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new GetUserResponse()
			{
				User = await this.InvokeGetAsync<Skeddly.Model.User>("/api/Users/" + request.UserId + queryString)
			};
		}

		public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
		{
			// Verify required parameters
			if (request == null)
				throw new ArgumentNullException("request");
			if (String.IsNullOrWhiteSpace(request.Username))
				throw new ArgumentNullException("request.Username");
			if (String.IsNullOrWhiteSpace(request.EmailAddress))
				throw new ArgumentNullException("request.EmailAddress");
			if (String.IsNullOrWhiteSpace(request.Password))
				throw new ArgumentNullException("request.Password");

			List<string> queryParameters = new List<string>();

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new CreateUserResponse()
			{
				User = await this.InvokePostAsync<Skeddly.Model.User, CreateUserRequest>("/api/Users/" + queryString, request)
			};
		}

		public async Task<ModifyUserResponse> ModifyUserAsync(ModifyUserRequest request)
		{
			// Verify required parameters
			if (request == null)
				throw new ArgumentNullException("request");
			if (String.IsNullOrWhiteSpace(request.UserId))
				throw new ArgumentNullException("request.UserId");

			List<string> queryParameters = new List<string>();

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new ModifyUserResponse()
			{
				User = await this.InvokePutAsync<Skeddly.Model.User, ModifyUserRequest>("/api/Users/" + request.UserId + queryString, request)
			};
		}

		public async Task<RemoveUserMfaResponse> RemoveUserMfaAsync(RemoveUserMfaRequest request)
		{
			// Verify required parameters
			if (request == null)
				throw new ArgumentNullException("request");
			if (String.IsNullOrWhiteSpace(request.UserId))
				throw new ArgumentNullException("request.UserId");
			if (String.IsNullOrWhiteSpace(request.MfaType))
				throw new ArgumentNullException("request.MfaType");

			List<string> queryParameters = new List<string>();

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new RemoveUserMfaResponse()
			{
				User = await this.InvokePutAsync<Skeddly.Model.User, RemoveUserMfaRequest>("/api/Users/" + request.UserId + "/RemoveMfa" + queryString, request)
			};
		}

		public async Task<AttachManagedPolicyResponse> AttachManagedPolicyAsync(AttachManagedPolicyRequest request)
		{
			// Verify required parameters
			if (request == null)
				throw new ArgumentNullException("request");
			if (String.IsNullOrWhiteSpace(request.UserId))
				throw new ArgumentNullException("request.UserId");
			if (String.IsNullOrWhiteSpace(request.ManagedPolicyId))
				throw new ArgumentNullException("request.ManagedPolicyId");

			List<string> queryParameters = new List<string>();

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new AttachManagedPolicyResponse()
			{
				User = await this.InvokePutAsync<Model.User, AttachManagedPolicyRequest>("/api/Users/" + request.UserId + "/AttachManagedPolicy" + queryString, request)
			};
		}

		public async Task<DetachManagedPolicyResponse> DetachManagedPolicyAsync(DetachManagedPolicyRequest request)
		{
			// Verify required parameters
			if (request == null)
				throw new ArgumentNullException("request");
			if (String.IsNullOrWhiteSpace(request.UserId))
				throw new ArgumentNullException("request.UserId");
			if (String.IsNullOrWhiteSpace(request.ManagedPolicyId))
				throw new ArgumentNullException("request.ManagedPolicyId");

			List<string> queryParameters = new List<string>();

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new DetachManagedPolicyResponse()
			{
				User = await this.InvokePutAsync<Model.User, DetachManagedPolicyRequest>("/api/Users/" + request.UserId + "/DetachManagedPolicy" + queryString, request)
			};
		}

		#endregion
	}
}
