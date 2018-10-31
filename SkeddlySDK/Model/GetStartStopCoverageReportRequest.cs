using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class GetStartStopCoverageReportRequest
	{
		public string CredentialId { get; set; }
		public string RegionName { get; set; }
		public string ResourceType { get; set; }
	}
}
