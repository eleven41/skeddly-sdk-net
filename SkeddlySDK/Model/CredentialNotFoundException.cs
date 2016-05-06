using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class CredentialNotFoundException : SkeddlyWebException
	{
		public CredentialNotFoundException(string message)
			: base (System.Net.HttpStatusCode.NotFound, "CredentialNotFound", message)
		{
		}
	}
}
