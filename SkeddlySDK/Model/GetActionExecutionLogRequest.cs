using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class GetActionExecutionLogRequest
	{
		public string ActionExecutionId { get; set; }
		public string Marker { get; set; }
		public System.IO.Stream TargetStream { get; set; }
	}
}
