﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skeddly.Model;

namespace Skeddly
{
	public interface ISkeddlyClient : IDisposable
	{
		#region Account

		Task<GetAccountInformationResponse> GetAccountInformationAsync(GetAccountInformationRequest request);
		Task<GetAccountSettingsResponse> GetAccountSettingsAsync(GetAccountSettingsRequest request);
		Task<GetDashboardInformationResponse> GetDashboardInformationAsync(GetDashboardInformationRequest request);
		Task<GetRssFeedInformationResponse> GetRssFeedInformationAsync();
		Task<CreateRssFeedResponse> CreateRssFeedAsync(CreateRssFeedRequest request);
		Task<GetAccountAliasResponse> GetAccountAliasAsync(GetAccountAliasRequest request);
		Task<SetAccountAliasResponse> SetAccountAliasAsync(SetAccountAliasRequest request);

		#endregion

		#region Credentials

		Task<ListCredentialsResponse> ListCredentialsAsync(ListCredentialsRequest request);
		Task<GetCredentialResponse> GetCredentialAsync(GetCredentialRequest request);
		Task<CreateCredentialResponse> CreateCredentialAsync(CreateCredentialRequest request);
		Task<UpdateCredentialResponse> UpdateCredentialAsync(UpdateCredentialRequest request);
		Task DeleteCredentialAsync(DeleteCredentialRequest request);
		Task<GenerateIamPolicyResponse> GenerateIamPolicyAsync(GenerateIamPolicyRequest request);
		Task<GenerateAmazonIamRoleExternalIdResponse> GenerateAmazonIamRoleExternalIdAsync(GenerateAmazonIamRoleExternalIdRequest request);

		#endregion

		#region Actions

		Task<ListActionsResponse> ListActionsAsync(ListActionsRequest request);
		Task<GetActionResponse> GetActionAsync(GetActionRequest request);
		Task<GetActionTagsResponse> GetActionTagsAsync(GetActionTagsRequest request);
		Task<GetActionTypesResponse> GetActionTypesAsync(GetActionTypesRequest request);
		Task<GetActionRegionsResponse> GetActionRegionsAsync(GetActionRegionsRequest request);
		Task DeleteActionAsync(DeleteActionRequest request);
		Task ExecuteActionAsync(ExecuteActionRequest request);

		#endregion

		#region Action Executions

		Task<ListUpcomingActionExecutionsResponse> ListUpcomingActionExecutionsAsync(ListUpcomingActionExecutionsRequest request);
		Task<ListActionExecutionsResponse> ListActionExecutionsAsync(ListActionExecutionsRequest request);
		Task<GetActionExecutionResponse> GetActionExecutionAsync(GetActionExecutionRequest request);
		Task<CancelActionExecutionResponse> CancelActionExecutionAsync(CancelActionExecutionRequest request);
		Task<GetActionExecutionLogResponse> GetActionExecutionLogAsync(GetActionExecutionLogRequest request);

		#endregion

		#region Managed Instances

		Task<ListManagedInstancesResponse> ListManagedInstancesAsync(ListManagedInstancesRequest request);

		#endregion

		#region Managed Instance Groups

		Task<ListManagedInstanceGroupsResponse> ListManagedInstanceGroupsAsync(ListManagedInstanceGroupsRequest request);
		Task<GetManagedInstanceGroupResponse> GetManagedInstanceGroupAsync(GetManagedInstanceGroupRequest request);
		Task<CreateManagedInstanceGroupResponse> CreateManagedInstanceGroupAsync(CreateManagedInstanceGroupRequest request);
		Task DeleteManagedInstanceGroupAsync(DeleteManagedInstanceGroupRequest request);

		#endregion

		#region Account/Billing

		Task<GetPaymentInformationResponse> GetPaymentInformationAsync();
		Task<ListInvoicesResponse> ListInvoicesAsync(ListInvoicesRequest request);
		Task<GetInvoiceResponse> GetInvoiceAsync(GetInvoiceRequest request);
		Task<GetBillingAddressResponse> GetBillingAddressAsync();
		Task<UpdateBillingAddressResponse> UpdateBillingAddressAsync(UpdateBillingAddressRequest request);
		Task<ListCreditTransactionsResponse> ListCreditTransactionsAsync();

		#endregion

		#region Regions

		Task<ListRegionsResponse> ListRegionsAsync(ListRegionsRequest request);
		Task<GetRegionResponse> GetRegionAsync(GetRegionRequest request);

		#endregion

		#region Time Zones

		Task<ListTimeZonesResponse> ListTimeZonesAsync(ListTimeZonesRequest request);
		Task<GetTimeZoneResponse> GetTimeZoneAsync(GetTimeZoneRequest request);

		#endregion

		#region Users

		Task<ListUsersResponse> ListUsersAsync(ListUsersRequest request);
		Task<GetUserResponse> GetUserAsync(GetUserRequest request);
		Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request);
		Task<ModifyUserResponse> ModifyUserAsync(ModifyUserRequest request);
		Task<RemoveUserMfaResponse> RemoveUserMfaAsync(RemoveUserMfaRequest request);
		Task<AttachManagedPolicyResponse> AttachManagedPolicyAsync(AttachManagedPolicyRequest request);
		Task<DetachManagedPolicyResponse> DetachManagedPolicyAsync(DetachManagedPolicyRequest request);

		#endregion

		#region Managed Policies

		Task<ListManagedPoliciesResponse> ListManagedPoliciesAsync(ListManagedPoliciesRequest request);

		#endregion
	}
}
