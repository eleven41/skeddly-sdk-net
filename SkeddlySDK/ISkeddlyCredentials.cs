using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly
{
	public interface ISkeddlyCredentials
	{
		string GetAuthorizationScheme();
		string GetAuthorizationParameter();
	}
}
