using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class BackupCoverageReportScheduledAction
	{
		public string ActionId { get; set; }
		public string ActionVersionId { get; set; }
		public string ActionType { get; set; }
		public string ActionName { get; set; }

		public string ResourceType { get; set; }
		public string Coverage { get; set; }

		public ActionSchedule Schedule { get; set; }
	}
}
