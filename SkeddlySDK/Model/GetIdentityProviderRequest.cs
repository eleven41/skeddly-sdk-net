using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class GetIdentityProviderRequest
	{
		public string IdentityProviderId { get; set; }

		public IEnumerable<IdentityProviderIncludes> Include { get; set; }
	}
}
