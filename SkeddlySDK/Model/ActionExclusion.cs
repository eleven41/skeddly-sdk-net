using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class ActionExclusion
	{
		public string ActionExclusionId { get; set; }

		public string Name { get; set; }

		public string Status { get; set; }
		public bool IsEnabled { get; set; }

		public string CreatedDate { get; set; }
		public string LastModifiedDate { get; set; }
		public string LastModifiedBy { get; set; }

		public string ExpiryDate { get; set; }
		public string TimeZoneId { get; set; }

		public IEnumerable<string> Processes { get; set; }

		public string ResourceType { get; set; }
		public string ResourceIdentificationMethod { get; set; }

		public IEnumerable<string> ResourceIds { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public IEnumerable<string> RegionNames { get; set; }
		public IEnumerable<string> CredentialIds { get; set; }
	}
}
