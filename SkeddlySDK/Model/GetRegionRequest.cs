using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class GetRegionRequest
	{
		public string RegionName { get; set; }
		public List<RegionIncludes> Include { get; set; }
	}
}
