using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class CreateCredentialRequest
	{
		public string Name { get; set; }
		public string CredentialType { get; set; }
		public string CloudProviderSubTypeId { get; set; }

		public string RoleArn { get; set; }
		public string ExternalId { get; set; }

		public string AccessKeyId { get; set; }
		public string SecretAccessKey { get; set; }
	}
}
