using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	[Serializable]
	public class ManagedInstanceGroupNotFoundException : SkeddlyWebException
	{
		public ManagedInstanceGroupNotFoundException(string message)
			: base(System.Net.HttpStatusCode.NotFound, "ManagedInstanceGroupNotFound", message)
		{
		}

		protected ManagedInstanceGroupNotFoundException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
			: base(serializationInfo, streamingContext)
		{
		}
	}
}
