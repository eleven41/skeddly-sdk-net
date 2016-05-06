using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Skeddly.Model;

namespace Skeddly
{
	public partial class SkeddlyClient : ISkeddlyClient
    {
		#region Payment Information

		public async Task<GetPaymentInformationResponse> GetPaymentInformationAsync()
		{
			return new GetPaymentInformationResponse()
			{
				PaymentInformation = await this.InvokeGetAsync<PaymentInformation>("/api/Account/Billing/PaymentInformation")
			};
		}

		#endregion

		#region Invoices

		public async Task<ListInvoicesResponse> ListInvoicesAsync(ListInvoicesRequest request)
		{
			List<string> queryParameters = new List<string>();

			if (request.Include != null)
			{
				queryParameters.Add("include=" + String.Join(",", request.Include));
			}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new ListInvoicesResponse()
			{
				Invoices = await this.InvokeGetAsync<IEnumerable<Invoice>>("/api/Account/Billing/Invoices" + queryString)
			};
		}

		public async Task<GetInvoiceResponse> GetInvoiceAsync(GetInvoiceRequest request)
		{
			List<string> queryParameters = new List<string>();

			if (request.Include != null)
			{
				queryParameters.Add("include=" + String.Join(",", request.Include));
			}

			string queryString = null;
			if (queryParameters.Any())
				queryString = "?" + String.Join("&", queryParameters);

			return new GetInvoiceResponse()
			{
				Invoice = await this.InvokeGetAsync<Invoice>("/api/Account/Billing/Invoices/" + request.InvoiceId + queryString)
			};
		}

		#endregion

		#region Billing Address

		public async Task<GetBillingAddressResponse> GetBillingAddressAsync()
		{
			return new GetBillingAddressResponse()
			{
				BillingAddress = await this.InvokeGetAsync<BillingAddress>("/api/Account/Billing/Address")
			};
		}

		public async Task<UpdateBillingAddressResponse> UpdateBillingAddressAsync(UpdateBillingAddressRequest request)
		{
			return new UpdateBillingAddressResponse()
			{
				BillingAddress = await this.InvokePutAsync<BillingAddress, UpdateBillingAddressRequest>("/api/Account/Billing/Address", request)
			};
		}

		#endregion

		#region Credit Transactions

		public async Task<ListCreditTransactionsResponse> ListCreditTransactionsAsync()
		{
			return new ListCreditTransactionsResponse()
			{
				CreditTransactions = await this.InvokeGetAsync<IEnumerable<CreditTransaction>>("/api/Account/Billing/CreditTransactions")
			};
		}

		#endregion
	}
}
