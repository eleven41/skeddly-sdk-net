using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class ModifyManagedInstanceGroupRequest
	{
		public string ManagedInstanceGroupId { get; set; }

		public string Name { get; set; }
		public string TimeZoneId { get; set; }

		public StartStopParameters StartStopParameters { get; set; }
		public BackupParameters BackupParameters { get; set; }
		public DeleteBackupsParameters DeleteBackupsParameters { get; set; }
	}
}
