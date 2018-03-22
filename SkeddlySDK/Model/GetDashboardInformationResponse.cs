using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class GetDashboardInformationResponse
	{
		/// <summary>
		/// Expiry date. In ISO8601 format.
		/// </summary>
		public string ExpiryDate { get; set; }

		public bool IsShowGettingStarted { get; set; }
		public bool IsShowActionAlerts { get; set; }

		public string AccountStatus { get; set; }
		public string EmailStatus { get; set; }
		public string CreditCardStatus { get; set; }
		public string AwsMarketplaceSubscriptionStatus { get; set; }

		public IEnumerable<UnpaidInvoice> UnpaidInvoices { get; set; }
	}
}
