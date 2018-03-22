using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class PaymentInformation
	{
		public string PaymentMethod { get; set; }

		public CreditCard Card { get; set; }
		public CreditBalance CreditBalance { get; set; }
		public PaymentPartner PaymentPartner { get; set; }
		public AwsMarketplaceSubscription AwsMarketplaceSubscription { get; set; }
	}
}
