using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
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
	}
}
