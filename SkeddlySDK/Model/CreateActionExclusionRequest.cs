using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class CreateActionExclusionRequest
	{
		public string Name { get; set; }

		public bool IsEnabled { get; set; }

		public string StartDate { get; set; }
		public string ExpiryDate { get; set; }
		public string TimeZoneId { get; set; }

		public string ResourceType { get; set; }

		public string ResourceIdentificationMethod { get; set; }

		public IEnumerable<string> ResourceIds { get; set; }

		public ResourceTagComparison ResourceTagComparison { get; set; }

		public IEnumerable<string> RegionNames { get; set; }
		public IEnumerable<string> CredentialIds { get; set; }

		public IEnumerable<string> Processes { get; set; }
	}
}
