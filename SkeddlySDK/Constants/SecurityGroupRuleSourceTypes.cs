using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Constants
{
	public static class SecurityGroupRuleSourceTypes
	{
		public const string Cidr = "cidr";
		public const string SecurityGroup = "security-group";
		public const string DomainName = "domain-name";
	}
}
