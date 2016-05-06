using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class ListUsersResponse
	{
		public IEnumerable<User> Users { get; set; }
	}
}
