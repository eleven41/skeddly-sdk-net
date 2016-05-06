using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class ListInvoicesResponse
	{
		public IEnumerable<Invoice> Invoices { get; set; }
	}
}
