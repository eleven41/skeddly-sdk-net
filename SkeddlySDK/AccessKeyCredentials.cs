using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly
{
	public class AccessKeyCredentials : ISkeddlyCredentials
	{
		public AccessKeyCredentials(string accessKeyId)
		{
			this.AccessKeyId = accessKeyId;
		}

		public string AccessKeyId { get; set; }

		public string GetAuthorizationScheme()
		{
			return "AccessKey";
		}

		public string GetAuthorizationParameter()
		{
			return this.AccessKeyId;
		}
	}
}
