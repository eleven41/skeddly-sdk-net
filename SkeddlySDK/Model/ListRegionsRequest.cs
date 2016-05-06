using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class ListRegionsRequest
	{
		public List<RegionIncludes> Include { get; set; }

		public string CloudProviderId { get; set; }
		public string CloudProviderSubTypeId { get; set; }
		public string CredentialId { get; set; }
	}
}
