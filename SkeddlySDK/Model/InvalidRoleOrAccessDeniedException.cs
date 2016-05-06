using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class InvalidRoleOrAccessDeniedException : SkeddlyWebException
	{
		public InvalidRoleOrAccessDeniedException(string message)
			: base(System.Net.HttpStatusCode.BadRequest, "InvalidRoleOrAccessDenied", message)
		{
		}
	}
}
