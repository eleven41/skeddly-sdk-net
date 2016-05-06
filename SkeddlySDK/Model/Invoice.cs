using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class Invoice
	{
		public string InvoiceId { get; set; }
		public string IssueDate { get; set; }
		public decimal Amount { get; set; }
		public decimal Taxes { get; set; }
		public decimal OutstandingBalance { get; set; }
		public string Status { get; set; }

		public string AccountName { get; set; }

		public List<InvoiceCharge> Charges { get; set; }
		public List<InvoicePayment> Payments { get; set; }
		public string LastPaymentDate { get; set; }
	}

	public class InvoiceCharge
	{
		public int Year { get; set; }
		public int Month { get; set; }
		public decimal Usage { get; set; }
		public decimal Taxes { get; set; }
		public decimal Amount { get; set; }
		public string TaxName { get; set; }
	}

	public class InvoicePayment
	{
		public string PaymentType { get; set; }
		public string Status { get; set; }
		public string PaymentDate { get; set; }
		public decimal Amount { get; set; }

		public string PaypalInvoiceUrl { get; set; }
		public string CreditTransactionId { get; set; }
	}
}
