using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class IdentityProvider
	{
		public string IdentityProviderId { get; set; }
		public string IdentityProviderSrn { get; set; }

		public string ProviderType { get; set; }
		public string Name { get; set; }

		public string CreatedDate { get; set; }
		public string LastModifiedDate { get; set; }
		public string LastModifiedBy { get; set; }

		public string SamlMetadataBase64 { get; set; }
	}
}
