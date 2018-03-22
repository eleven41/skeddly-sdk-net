using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class AssumeUserWithSamlRequest
	{
		public string SamlResponseBase64 { get; set; }
		public bool? IsAssumeOnSingleProvider { get; set; }
		public string IdentityProviderSrn { get; set; }
		public IEnumerable<string> ManagedPolicySrns { get; set; }
	}
}
