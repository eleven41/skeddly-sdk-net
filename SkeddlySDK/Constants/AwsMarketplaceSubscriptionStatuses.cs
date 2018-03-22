using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Constants
{
	public static class AwsMarketplaceSubscriptionStatuses
	{
		public const string Created = "created";
		public const string Subscribed = "subscribed";
		public const string SubscribeFailed = "subscribe-failed";
		public const string UnsubscribePending = "unsubscribe-pending";
		public const string Unsubscribed = "unsubscribed";
		public const string NotFound = "not-found";
	}
}
