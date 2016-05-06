using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class ManagedInstanceGroup
	{
		public string ManagedInstanceGroupId { get; set; }

		public string Name { get; set; }

		public string CreatedDate { get; set; }
		public string TimeZoneId { get; set; }

		/// <summary>
		/// ID of the last user to modify the action.
		/// </summary>
		public string LastModifiedBy { get; set; }

		public bool IsStartInstance { get; set; }
		public bool IsBackupInstance { get; set; }
		public bool IsDeleteBackups { get; set; }

		public StartStopParameters StartStopParameters { get; set; }
		public BackupParameters BackupParameters { get; set; }
		public DeleteBackupsParameters DeleteBackupsParameters { get; set; }
	}

	public class StartStopParameters
	{
		public ManagedInstanceSchedule Schedule { get; set; }

		public int StopTimeInSeconds { get; set; }
	}

	public class BackupParameters
	{
		public ManagedInstanceSchedule Schedule { get; set; }

		public string BackupName { get; set; }
		public IEnumerable<Tag> Tags { get; set; }
	}

	public class DeleteBackupsParameters
	{
		public ManagedInstanceSchedule Schedule { get; set; }

		public int OlderThanDays { get; set; }
		public int MinimumToKeep { get; set; }
		public bool IsPerVolume { get; set; }
	}
}
