using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Skeddly.Model
{
	public class ModifyCredentialRequest
	{
		[JsonIgnore]
		public string CredentialId { get; set; }

		public string Name { get; set; }
		public string CloudProviderSubTypeId { get; set; }

		public AmazonIamAccessKeyParameters AmazonIamAccessKey { get; set; }
		public AmazonIamRoleParameters AmazonIamRole { get; set; }
	}
}
