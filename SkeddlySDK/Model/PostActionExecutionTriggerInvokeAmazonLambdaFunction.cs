using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class PostActionExecutionTriggerInvokeAmazonLambdaFunction
	{
		public string LambdaFunction { get; set; }
		public string UserData { get; set; }
	}
}
