using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class StartStopCoverageReportResource
	{
		public string ResourceId { get; set; }
		public string ResourceType { get; set; }
		public string RegionName { get; set; }
		public IEnumerable<Tag> Tags { get; set; }

		public IEnumerable<StartStopCoverageReportScheduledAction> ScheduledActions { get; set; }
	}
}
