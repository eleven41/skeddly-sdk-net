using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class RemoveUserMfaRequest
	{
		public string UserId { get; set; }
		public string MfaType { get; set; }
	}
}
