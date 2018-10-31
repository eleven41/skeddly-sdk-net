using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	[Serializable]
	public class SkeddlyException : Exception
	{
		public SkeddlyException()
			: base()
		{
		}

		public SkeddlyException(string message)
			: base(message)
		{
		}

		public SkeddlyException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected SkeddlyException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
			: base(serializationInfo, streamingContext)
		{
		}
	}
}
