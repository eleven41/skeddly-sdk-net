using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skeddly.Model;

namespace Skeddly.Model
{
	public class GetActionRegionsResponse
	{
		public IEnumerable<ActionRegion> Regions { get; set; }
	}
}
