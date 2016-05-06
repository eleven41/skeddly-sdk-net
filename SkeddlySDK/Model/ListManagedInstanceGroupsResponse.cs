using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class ListManagedInstanceGroupsResponse
	{
		public IEnumerable<ManagedInstanceGroup> ManagedInstanceGroups { get; set; }
	}
}
