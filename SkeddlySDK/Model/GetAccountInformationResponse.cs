using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class GetAccountInformationResponse
	{
		/// <summary>
		/// Account creation date. In ISO8601 format.
		/// </summary>
		public string CreatedDate { get; set; }

		/// <summary>
		/// Expiry date. In ISO8601 format.
		/// </summary>
		public string ExpiryDate { get; set; }

		/// <summary>
		/// Alias of the account.
		/// </summary>
		public string AccountAlias { get; set; }

		/// <summary>
		/// Name of the current account type.
		/// </summary>
		public string AccountTypeName { get; set; }

		/// <summary>
		/// Name of the account type if the account were to be upgraded.
		/// </summary>
		public string UpgradeAccountTypeName { get; set; }

		/// <summary>
		/// Status of the account.
		/// Possible values are: active, deactivated, expired.
		/// </summary>
		public string AccountStatus { get; set; }
		
		/// <summary>
		/// Status of the email address.
		/// Possible values are: ok, failed.
		/// </summary>
		public string EmailStatus { get; set; }

		/// <summary>
		/// Status of the AWS Marketplace subscription, if any.
		/// Possible values are: created, subscribed, subscribe-failed, unsubscribed, unsubscribe-pending, not-found
		/// </summary>
		public string AwsMarketplaceSubscriptionStatus { get; set; }

	}
}
