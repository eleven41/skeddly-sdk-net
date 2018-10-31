using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	[Serializable]
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

		protected SkeddlyWebException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
			: base(serializationInfo, streamingContext)
		{
			this.StatusCode = (System.Net.HttpStatusCode)serializationInfo.GetInt32("StatusCode");
			this.ErrorCode = serializationInfo.GetString("ErrorCode");
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);

			info.AddValue("StatusCode", (int)this.StatusCode);
			info.AddValue("ErrorCode", this.ErrorCode);
		}

		public System.Net.HttpStatusCode StatusCode { get; set; }
		public string ErrorCode { get; set; }
	}
}
