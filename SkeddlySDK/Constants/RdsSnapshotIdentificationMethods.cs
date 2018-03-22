using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Constants
{
	public static class RdsSnapshotIdentificationMethods
	{
		public const string AllSnapshots = "all-snapshots";
		public const string BySnapshotId = "by-snapshot-id";
		public const string ByInstanceId = "by-instance-id";
		public const string ByClusterId = "by-cluster-id";
		public const string BySourceId = "by-source-id";
		public const string ByResourceTag = "by-resource-tag";
	}
}
