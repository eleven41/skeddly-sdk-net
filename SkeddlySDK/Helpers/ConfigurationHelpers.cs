using System;
using System.Collections.Generic;
using System.Text;

namespace Skeddly.Helpers
{
    public static class ConfigurationHelpers
    {
		public static string AppSetting(string s)
		{
			return System.Configuration.ConfigurationManager.AppSettings[s];
		}
    }
}
