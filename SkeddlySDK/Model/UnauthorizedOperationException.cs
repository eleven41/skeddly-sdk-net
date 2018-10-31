using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	[Serializable]
	public class UnauthorizedOperationException : SkeddlyWebException
	{
		public UnauthorizedOperationException(string message)
			: base(System.Net.HttpStatusCode.Forbidden, "UnauthorizedOperation", message)
		{
		}

		protected UnauthorizedOperationException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
			: base(serializationInfo, streamingContext)
		{
		}
	}
}
