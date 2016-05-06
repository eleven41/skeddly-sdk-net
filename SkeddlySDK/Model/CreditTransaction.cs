using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class CreditTransaction
	{
		public string TransactionId { get; set; }
		public string TransactionDate { get; set; }
		public string TransactionType { get; set; }
		public decimal? Payment { get; set; }
		public decimal? Debit { get; set; }
		public decimal Balance { get; set; }
	}
}
