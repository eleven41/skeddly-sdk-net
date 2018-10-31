using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	[Serializable]
	public class ActionExecutionNotFoundException : SkeddlyWebException
	{
		public ActionExecutionNotFoundException(string message)
			: base (System.Net.HttpStatusCode.NotFound, "ActionExecutionNotFound", message)
		{
		}

		protected ActionExecutionNotFoundException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
			: base(serializationInfo, streamingContext)
		{
		}
	}
}
