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

		public AmazonIamAccessKeyParameters AmazonIamAccessKey { get; set; }
		public AmazonIamRoleParameters AmazonIamRole { get; set; }
		public AzureCredentialParameters AzureCredential { get; set; }
	}
}
