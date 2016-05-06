using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class ActionSchedule
	{
		public string ScheduleType { get; set; }

		public string StartDate { get; set; }
		public string EndDate { get; set; }
		public string TimeOfDay { get; set; }

		public string TimeZoneId { get; set; }

		public ScheduleParameters Parameters { get; set; }
	}
}
