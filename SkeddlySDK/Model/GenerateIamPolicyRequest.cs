using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class GenerateIamPolicyRequest
	{
		public string CredentialId { get; set; }

		public IEnumerable<string> Extras { get; set; }
	}
}
