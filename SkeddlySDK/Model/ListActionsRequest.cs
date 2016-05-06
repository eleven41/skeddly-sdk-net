using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class ListActionsRequest
	{
		public List<ActionIncludes> Include { get; set; }
		public ListActionsFilter Filter { get; set; }
	}
}
