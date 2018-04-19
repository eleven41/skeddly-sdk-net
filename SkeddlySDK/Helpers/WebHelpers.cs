using System;
using System.Collections.Generic;
using System.Text;

namespace Skeddly.Helpers
{
    public static class WebHelpers
    {
		public static string UrlEncode(string s)
		{
			return System.Net.WebUtility.UrlEncode(s);
		}
	}
}
