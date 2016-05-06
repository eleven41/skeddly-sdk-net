using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class ManagedInstanceGroupNotFoundException : SkeddlyWebException
	{
		public ManagedInstanceGroupNotFoundException(string message)
			: base(System.Net.HttpStatusCode.NotFound, "ManagedInstanceGroupNotFound", message)
		{
		}
	}
}
