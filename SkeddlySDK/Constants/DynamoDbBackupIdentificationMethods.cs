using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Constants
{
	public static class DynamoDbBackupIdentificationMethods
	{
		public const string AllBackups = "all-backups";
		public const string ByBackupName = "by-backup-name";
		public const string ByTableName = "by-table-name";
		public const string ByResourceTag = "by-resource-tag";
	}
}
