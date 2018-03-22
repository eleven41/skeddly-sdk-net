using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class EstimatedCostSavingsReport
	{
		public string StartDate { get; set; }
		public string EndDate { get; set; }

		public IEnumerable<EstimatedCostSavingsReportItem> Items { get; set; }
	}
}
