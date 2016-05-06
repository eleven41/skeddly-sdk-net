using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class ListActionsFilter
	{
		public List<string> ActionTypes { get; set; }
		public List<string> CredentialIds { get; set; }
		public bool? IsEnabled { get; set; }
		public List<string> Regions { get; set; }
		public List<string> Tags { get; set; }
		public string TagsRequired { get; set; }

		public List<ActionClasses> ActionClasses { get; set; }
		public List<string> ManagedInstanceIds { get; set; }
	}
}
