using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	[Serializable]
	public class CredentialNotFoundException : SkeddlyWebException
	{
		public CredentialNotFoundException(string message)
			: base (System.Net.HttpStatusCode.NotFound, "CredentialNotFound", message)
		{
		}

		protected CredentialNotFoundException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
			: base(serializationInfo, streamingContext)
		{
		}
	}
}
