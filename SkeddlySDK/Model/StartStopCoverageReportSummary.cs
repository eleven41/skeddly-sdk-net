using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class StartStopCoverageReportSummary
	{
		public int NumResourcesTotal { get; set; }
		public int NumResourcesFull { get; set; }
		public int NumResourcesPart { get; set; }
		public int NumResourcesNone { get; set; }
	}
}
