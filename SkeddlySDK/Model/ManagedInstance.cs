using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class ManagedInstance
	{
		public string ManagedInstanceId { get; set; }

		public string Name { get; set; }

		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }
		public string InstanceName { get; set; }

		public string DisplayInstance { get; set; }
		public string DisplayName { get; set; }

		public string CredentialId { get; set; }

		public string ManagedInstanceGroupId { get; set; }
	}
}
