using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Skeddly.Extensions.NETCore.Setup
{
    internal class ClientFactory
    {
		SkeddlyOptions _options;

		public ClientFactory(SkeddlyOptions options)
		{
			_options = options;
		}

		internal object CreateSkeddlyClient(IServiceProvider provider)
		{
			var options = _options ?? provider.GetService<SkeddlyOptions>();
			return CreateSkeddlyClient(options);
		}

		internal ISkeddlyClient CreateSkeddlyClient(SkeddlyOptions options)
		{
			return new SkeddlyClient(options);
		}

	}
}
