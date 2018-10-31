﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skeddly.Model
{
	public class GetActionRequest
	{
		public string ActionId { get; set; }
		public bool? IsIncludeDeleted { get; set; }
		public List<ActionIncludes> Include { get; set; }
	}
}
