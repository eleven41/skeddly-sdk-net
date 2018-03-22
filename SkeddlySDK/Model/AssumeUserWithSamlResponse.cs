using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class AssumeUserWithSamlResponse
	{
		public string Status { get; set; }

		public string UserId { get; set; }

		public IEnumerable<SamlIdentityProviderModel> IdentityProviders { get; set; }
	}

	public class SamlIdentityProviderModel
	{
		public string IdentityProviderSrn { get; set; }
		public string AccountName { get; set; }

		public IEnumerable<SamlManagdPolicyModel> ManagedPolicies { get; set; }
	}

	public class SamlManagdPolicyModel
	{
		public string ManagdPolicySrn { get; set; }
		public string ManagdPolicyName { get; set; }
	}
}
