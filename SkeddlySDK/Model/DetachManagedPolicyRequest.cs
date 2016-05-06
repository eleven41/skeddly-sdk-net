using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class DetachManagedPolicyRequest
	{
		public string UserId { get; set; }
		public string ManagedPolicyId { get; set; }
	}
}
