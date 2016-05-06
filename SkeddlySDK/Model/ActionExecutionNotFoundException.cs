using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class ActionExecutionNotFoundException : SkeddlyWebException
	{
		public ActionExecutionNotFoundException(string message)
			: base (System.Net.HttpStatusCode.NotFound, "ActionExecutionNotFound", message)
		{
		}
	}
}
