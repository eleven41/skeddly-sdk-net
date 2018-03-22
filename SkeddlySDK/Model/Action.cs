using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Skeddly.Model
{
	public class Action
	{
		public string ActionId { get; set; }
		public string ActionVersionId { get; set; }

		public string Name { get; set; }
		public string State { get; set; }
		public string ActionType { get; set; }
		public string CredentialId { get; set; }
		public string RegionName { get; set; }
		public IEnumerable<string> RegionNames { get; set; }

		public string CreatedDate { get; set; }
		public string LastModifiedDate { get; set; }
		public string LastModifiedBy { get; set; }

		public string Comments { get; set; }

		public bool IsEnabled { get; set; }
		public ActionSchedule Schedule { get; set; }

		public string SnsEndpoint { get; set; }

		public IEnumerable<string> Tags { get; set; }

		public string NextExecutionDate { get; set; }
		
		public ActionDisplayData DisplayData { get; set; }

		public int? RunningCount { get; set; }

		public ActionExecution LastExecution { get; set; }

		public ActionParameters Parameters { get; set; }

		public string ManagedInstanceId { get; set; }

		public bool IsCurrentVersion { get; set; }
	}
}
