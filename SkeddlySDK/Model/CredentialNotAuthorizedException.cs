using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	[Serializable]
	public class CredentialNotAuthorizedException : SkeddlyWebException
	{
		public CredentialNotAuthorizedException(string message)
			: base (System.Net.HttpStatusCode.BadRequest, "CredentialNotAuthorized", message)
		{
		}

		protected CredentialNotAuthorizedException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
			: base(serializationInfo, streamingContext)
		{
		}
	}
}
