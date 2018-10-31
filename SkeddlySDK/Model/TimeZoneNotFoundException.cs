using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	[Serializable]
	public class TimeZoneNotFoundException : SkeddlyWebException
	{
		public TimeZoneNotFoundException(string message)
			: base(System.Net.HttpStatusCode.NotFound, "TimeZoneNotFound", message)
		{
		}

		protected TimeZoneNotFoundException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
			: base(serializationInfo, streamingContext)
		{
		}
	}
}
