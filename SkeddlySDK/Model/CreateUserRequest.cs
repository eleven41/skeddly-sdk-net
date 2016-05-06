using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class CreateUserRequest
	{
		public string Username { get; set; }
		public string EmailAddress { get; set; }
		public string Password { get; set; }
		public IEnumerable<string> ManagedPolicyIds { get; set; }
	}
}
