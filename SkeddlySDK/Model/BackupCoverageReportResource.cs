using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class BackupCoverageReportResource
	{
		public string ResourceId { get; set; }
		public string ResourceType { get; set; }
		public string RegionName { get; set; }
		public IEnumerable<Tag> Tags { get; set; }

		public IEnumerable<BackupCoverageReportScheduledAction> ScheduledActions { get; set; }
	}
}
