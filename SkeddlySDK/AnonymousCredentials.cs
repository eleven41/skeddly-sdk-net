using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly
{
	public class AnonymousCredentials : ISkeddlyCredentials
	{
		public AnonymousCredentials()
		{
		}

		public string GetAuthorizationScheme()
		{
			return null;
		}

		public string GetAuthorizationParameter()
		{
			return null;
		}
	}
}
