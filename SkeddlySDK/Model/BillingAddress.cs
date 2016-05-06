using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class BillingAddress
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Company { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string ProvinceOrRegion { get; set; }
		public string Country { get; set; }
		public string PostalOrZipCode { get; set; }
	}
}
