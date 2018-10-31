using System.Collections.Generic;

namespace Skeddly.Model
{
	public class ListCredentialsFilter
	{
		public IEnumerable<string> CredentialIds { get; set; }
		public bool? IsIncludeDeleted { get; set; }
		public IEnumerable<string> CloudProviderIds { get; set; }
		public IEnumerable<string> CloudProviderSubTypeIds { get; set; }
	}
}