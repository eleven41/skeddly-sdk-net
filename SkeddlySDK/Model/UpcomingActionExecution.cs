using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class UpcomingActionExecution
	{
		public string ActionId { get; set; }
		public string ActionVersionId { get; set; }
		public string ManagedInstanceId { get; set; }
		public string ActionType { get; set; }
		public string ActionName { get; set; }
		public string TimeZoneId { get; set; }

		public string StartDate { get; set; }
	}
}
