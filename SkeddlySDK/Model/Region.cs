using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class Region
	{
		public string RegionName { get; set; }
		public string DisplayName { get; set; }

		public string CloudProviderSubTypeId { get; set; }

		public IEnumerable<string> AvailabilityZones { get; set; }
	}
}
