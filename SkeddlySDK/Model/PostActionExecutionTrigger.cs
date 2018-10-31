using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class PostActionExecutionTrigger
	{
		public string TriggerType { get; set; }
		public IEnumerable<string> Filters { get; set; }
		public PostActionExecutionTriggerInvokeAmazonLambdaFunction InvokeAmazonLambdaFunctionProperties { get; set; }
	}
}
