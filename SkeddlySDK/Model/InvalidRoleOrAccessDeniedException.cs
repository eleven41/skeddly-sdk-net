using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	[Serializable]
	public class InvalidRoleOrAccessDeniedException : SkeddlyWebException
	{
		public InvalidRoleOrAccessDeniedException(string message)
			: base(System.Net.HttpStatusCode.BadRequest, "InvalidRoleOrAccessDenied", message)
		{
		}

		protected InvalidRoleOrAccessDeniedException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
			: base(serializationInfo, streamingContext)
		{
		}
	}
}
