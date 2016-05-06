using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class SkeddlyWebException : SkeddlyException
	{
		public SkeddlyWebException(System.Net.HttpStatusCode statusCode)
			: base()
		{
			this.StatusCode = statusCode;
		}

		public SkeddlyWebException(System.Net.HttpStatusCode statusCode, string errorCode, string message)
			: base(message)
		{
			this.StatusCode = statusCode;
			this.ErrorCode = errorCode;
		}

		public System.Net.HttpStatusCode StatusCode { get; set; }
		public string ErrorCode { get; set; }
	}
}
