using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Constants
{
	public static class PaymentMethods
	{
		public const string None = "none";
		public const string CreditBalance = "credit-balance";
		public const string CreditCard = "credit-card";
		public const string Invoice = "invoice";
		public const string WireTransfer = "wire-transfer";
		public const string Cheque = "cheque";
	}
}
