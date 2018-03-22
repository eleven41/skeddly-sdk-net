using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Constants
{
	public static class StopRdsInstancesDeleteReplicasOptions
	{
		public const string None = "none";
		public const string DeleteOnly = "delete-only";
		public const string DeleteAndRecreate = "delete-and-recreate";
	}
}
