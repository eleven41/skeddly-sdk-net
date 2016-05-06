using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skeddly.Model;

namespace Skeddly.Model
{
	public class GetActionTypesResponse
	{
		public IEnumerable<ActionType> ActionTypes { get; set; }
	}
}
