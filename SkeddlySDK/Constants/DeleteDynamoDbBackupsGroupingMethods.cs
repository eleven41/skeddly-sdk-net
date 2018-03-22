using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Constants
{
	public static class DeleteDynamoDbBackupsGroupingMethods
	{
		public const string None = "none";
		public const string ByRegion = "by-region";
		public const string ByTable = "by-table";
		public const string ByResourceTag = "by-resource-tag";
	}
}
