﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class ListCreditTransactionsResponse
	{
		public IEnumerable<CreditTransaction> CreditTransactions { get; set; }
	}
}
