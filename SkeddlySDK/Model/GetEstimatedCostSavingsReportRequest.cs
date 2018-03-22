using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class GetEstimatedCostSavingsReportRequest
	{
		/// <summary>
		/// Date range to include.
		/// </summary>
		public DateRange Range { get; set; }

		/// <summary>
		/// One or more credential IDs.
		/// </summary>
		public IEnumerable<string> CredentialIds { get; set; }
	}
}
