using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class ActionExecution
	{
		public string ActionExecutionId { get; set; }
		public string StartDate { get; set; }
		public string EndDate { get; set; }
		public string Status { get; set; }
		public ActionExecutionResult Result { get; set; }
		public ActionExecutionTrigger Trigger { get; set; }

		// Action information
		public string ActionId { get; set; }
		public string ActionVersionId { get; set; }
		public string ActionType { get; set; }
		public string ActionName { get; set; }
		public string TimeZoneId { get; set; }
		public string CredentialId { get; set; }

		public string ManagedInstanceId { get; set; }
	};
}
