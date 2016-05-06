using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class ModifyUserRequest
	{
		public string UserId { get; set; }

		public string EmailAddress { get; set; }
		public string Status { get; set; }
	}
}
