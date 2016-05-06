using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class ListInvoicesRequest
	{
		public List<InvoiceIncludes> Include { get; set; }
	}
}
