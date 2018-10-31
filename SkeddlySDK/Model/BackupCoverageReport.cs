using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class BackupCoverageReport
	{
		public string CredentialId { get; set; }
		public string RegionName { get; set; }
		public string ResourceType { get; set; }

		public BackupCoverageReportSummary Summary { get; set; }

		public IEnumerable<BackupCoverageReportResource> Resources { get; set; }
	}
}
