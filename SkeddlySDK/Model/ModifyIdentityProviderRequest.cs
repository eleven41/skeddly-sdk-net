using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class ModifyIdentityProviderRequest
	{
		public string IdentityProviderId { get; set; }

		public string SamlMetadataBase64 { get; set; }
	}
}
