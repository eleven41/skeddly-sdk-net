using System;
using System.Collections.Generic;
using System.Text;

using Skeddly;
using Skeddly.Extensions.NETCore.Setup;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
		public static IServiceCollection AddDefaultSkeddlyOptions(this IServiceCollection collection, SkeddlyOptions options)
		{
			collection.Add(new ServiceDescriptor(typeof(SkeddlyOptions), options));
			return collection;
		}

		public static IServiceCollection AddSkeddlyClient(this IServiceCollection collection, ServiceLifetime lifetime = ServiceLifetime.Singleton)
		{
			return AddSkeddlyClient(collection, null, lifetime);
		}

		public static IServiceCollection AddSkeddlyClient(this IServiceCollection collection, SkeddlyOptions options, ServiceLifetime lifetime = ServiceLifetime.Singleton)
		{
			Func<IServiceProvider, object> factory =
				new ClientFactory(options).CreateSkeddlyClient;

			var descriptor = new ServiceDescriptor(typeof(ISkeddlyClient), factory, lifetime);
			collection.Add(descriptor);
			return collection;
		}
	}
}
