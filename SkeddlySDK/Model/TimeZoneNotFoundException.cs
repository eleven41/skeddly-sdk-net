using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class TimeZoneNotFoundException : SkeddlyWebException
	{
		public TimeZoneNotFoundException(string message)
			: base(System.Net.HttpStatusCode.NotFound, "TimeZoneNotFound", message)
		{
		}
	}
}
