using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class UnpaidInvoice
	{
		public string InvoiceType { get; set; }
		public string Status { get; set; }
		public string Label { get; set; }
		public string PayPalUrl { get; set; }
	}
}
