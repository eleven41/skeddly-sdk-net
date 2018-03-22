using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Constants
{
	public static class EbsSnapshotIdentificationMethods
	{
		public const string AllSnapshots = "all-snapshots";
		public const string BySnapshotNameTag = "by-snapshot-name-tag";
		public const string BySnapshotId = "by-snapshot-id";
		public const string ByVolumeId = "by-volume-id";
		public const string SnapshotsNewerThan = "snapshots-newer-than";
		public const string ByResourceTag = "by-resource-tag";
		public const string ByDescription = "by-description";
	}
}
