using System;
using System.Collections.Generic;
using System.Text;

namespace Skeddly
{
    public class SkeddlyOptions
    {
		public string AccessKeyId { get; set; }
		public string EndPoint { get; set; }
		public ISkeddlyCredentials Credentials { get; set; }

		public ISkeddlyClient CreateClient()
		{
			return new SkeddlyClient(this);
		}
	}
}
