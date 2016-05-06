using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Constants
{
	public static class OverwriteS3ObjectRules
	{
		public const string NeverOverwrite = "never-overwrite";
		public const string OverwriteOlderObjectsOnly = "overwrite-older-objects-only";
		public const string AlwaysOverwrite = "always-overwrite";
	}
}
