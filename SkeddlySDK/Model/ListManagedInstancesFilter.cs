using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class ListManagedInstancesFilter
	{
		public IEnumerable<string> CredentialIds { get; set; }
		public IEnumerable<string> ManagedInstanceIds { get; set; }

		/// <summary>
		/// True to include active and deleted managed instances. False to include only active managed instances.
		/// </summary>
		public bool? IsIncludeDeleted { get; set; }
	}
}
