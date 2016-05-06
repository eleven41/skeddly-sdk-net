﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class ActionNotFoundException : SkeddlyWebException
	{
		public ActionNotFoundException(string message)
			: base (System.Net.HttpStatusCode.NotFound, "ActionNotFound", message)
		{
		}
	}
}
