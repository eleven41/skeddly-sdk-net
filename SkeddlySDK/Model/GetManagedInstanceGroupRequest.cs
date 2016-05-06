using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class GetManagedInstanceGroupRequest
	{
		public string ManagedInstanceGroupId { get; set; }

		public bool? IsIncludeDeleted { get; set; }
		public List<ManagedInstanceGroupIncludes> Include { get; set; }
	}
}
