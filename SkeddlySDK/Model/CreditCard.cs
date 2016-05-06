using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class CreditCard
	{
		public string CardType { get; set; }
		public string Number { get; set; }
		public string ExpiryMonth { get; set; }
		public string ExpiryYear { get; set; }

		public string Status { get; set; }
	}
}
