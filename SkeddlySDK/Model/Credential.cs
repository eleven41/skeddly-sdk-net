using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class Credential
	{
		public string CredentialId { get; set; }

		public string Name { get; set; }
		public string CredentialType { get; set; }
		public string CloudProviderSubTypeId { get; set; }

		public string CreatedDate { get; set; }
		public string LastModifiedDate { get; set; }
		public string LastModifiedBy { get; set; }
		public string Status { get; set; }

		public string RoleArn { get; set; }
		public string ExternalId { get; set; }
		public string AccessKeyId { get; set; }

		public IEnumerable<string> ActionIds { get; set; }
		public IEnumerable<string> ManagedInstanceIds { get; set; }

		public bool IsUsedForSnsNotifications { get; set; }
	}
}
