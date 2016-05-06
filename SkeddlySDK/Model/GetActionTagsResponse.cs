using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skeddly.Model;

namespace Skeddly.Model
{
	public class GetActionTagsResponse
	{
		public IEnumerable<ActionTag> Tags { get; set; }
	}
}
