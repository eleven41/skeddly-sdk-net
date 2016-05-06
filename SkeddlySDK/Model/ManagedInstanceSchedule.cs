using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class ManagedInstanceSchedule
	{
		public string ScheduleType { get; set; }

		public string TimeOfDay { get; set; }

		public ScheduleParameters Parameters { get; set; }
	}
}
