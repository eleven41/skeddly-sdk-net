using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class CreateIdentityProviderRequest
	{
		public string ProviderType { get; set; }
		public string Name { get; set; }
		public string SamlMetadataBase64 { get; set; }
	}
}
