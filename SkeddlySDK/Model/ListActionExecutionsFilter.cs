using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class ListActionExecutionsFilter
	{
		public ListActionExecutionsFilterStatuses? Status { get; set; }

		/// <summary>
		/// Date range to include.
		/// </summary>
		public DateRange Range { get; set; }

		public ActionExecutionDateComparesToOptions? DateComparesTo { get; set; }

		/// <summary>
		/// One or more action IDs.
		/// </summary>
		public IEnumerable<string> ActionIds { get; set; }

		/// <summary>
		/// One or more credential IDs.
		/// </summary>
		public IEnumerable<string> CredentialIds { get; set; }

		public IEnumerable<ActionClasses> ActionClasses { get; set; }
	}

	public enum ListActionExecutionsFilterStatuses
	{
		All,
		ErrorsOnly,
		CompletedOnly,
		RunningOnly
	}
}
