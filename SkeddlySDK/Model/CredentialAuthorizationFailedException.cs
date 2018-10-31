using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	[Serializable]
	public class CredentialAuthorizationFailedException : SkeddlyWebException
	{
		public CredentialAuthorizationFailedException(string message)
			: base (System.Net.HttpStatusCode.BadRequest, "CredentialAuthorizationFailed", message)
		{
		}

		protected CredentialAuthorizationFailedException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
			: base(serializationInfo, streamingContext)
		{
		}
	}
}
