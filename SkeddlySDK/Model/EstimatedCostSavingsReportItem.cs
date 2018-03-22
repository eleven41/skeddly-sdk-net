using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class EstimatedCostSavingsReportItem
	{
		public string ActionName { get; set; }
		public string ActionId { get; set; }
		public string ActionVersionId { get; set; }
		public string ActionType { get; set; }
		public string CredentialId { get; set; }

		public string Status { get; set; }

		public long? TotalSeconds { get; set; }
		public long? RunningSeconds { get; set; }

		public decimal? RunningPercent { get; set; }
		public decimal? SavingsPercent { get; set; }
	}
}
