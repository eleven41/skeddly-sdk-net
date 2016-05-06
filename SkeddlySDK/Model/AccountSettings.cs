using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class AccountSettings
	{
		/// <summary>
		/// Preferred time zone ID.
		/// </summary>
		public string PreferredTimeZoneId { get; set; }

		/// <summary>
		/// Preferred region name.
		/// </summary>
		public string PreferredRegionName { get; set; }

		public bool IsSendDailySummary { get; set; }
	}
}
