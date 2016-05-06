using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Constants
{
	public static class ConflictResolutionMethods
	{
		public const string Skip = "skip";
		public const string AllowDuplicate = "allow-duplicate";
		public const string DeleteAndRecopy = "delete-and-recopy";
		public const string FailAndStop = "fail-and-stop";
		public const string FailAndContinue = "fail-and-continue";
	}
}
