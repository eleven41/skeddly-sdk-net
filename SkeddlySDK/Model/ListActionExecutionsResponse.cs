using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class ListActionExecutionsResponse
	{
		public IEnumerable<ActionExecution> ActionExecutions { get; set; }
	}
}
