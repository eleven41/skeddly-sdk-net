using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class User
	{
		public string UserId { get; set; }
		public string Username { get; set; }
		public string EmailAddress { get; set; }

		public string Status { get; set; }

		public string MfaType { get; set; }

		public string LastAccessDate { get; set; }

		public IEnumerable<ManagedPolicy> ManagedPolicies { get; set; }
	}
}
