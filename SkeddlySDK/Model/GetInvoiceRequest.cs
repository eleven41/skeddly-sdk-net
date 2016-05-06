using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class GetInvoiceRequest
	{
		public string InvoiceId { get; set; }
		public List<InvoiceIncludes> Include { get; set; }
	}
}
