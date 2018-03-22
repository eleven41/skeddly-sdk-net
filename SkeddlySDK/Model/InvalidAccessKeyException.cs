using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class InvalidAccessKeyException : SkeddlyWebException
	{
		public InvalidAccessKeyException(string message)
			: base(System.Net.HttpStatusCode.BadRequest, "InvalidAccessKey", message)
		{
		}
	}
}
