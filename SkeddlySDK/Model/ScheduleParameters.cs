using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class ScheduleParameters
	{
	}

	public class NoneScheduleParameters : ScheduleParameters
	{
	}

	public class DailyScheduleParameters : ScheduleParameters
	{
		public List<string> Days { get; set; }
	}

	public class WeeklyScheduleParameters : ScheduleParameters
	{
		public string DayOfWeek { get; set; }
	}

	public class MonthlyScheduleParameters : ScheduleParameters
	{
		public List<string> Months { get; set; }

		public string DayOfMonth { get; set; }
		public WeekAndDay WeekAndDay { get; set; }
	}

	public class WeekAndDay
	{
		public string Week { get; set; }
		public string Day { get; set; }
	}

	public class HourlyScheduleParameters : ScheduleParameters
	{
		public List<int> Hours { get; set; }
	}
}
