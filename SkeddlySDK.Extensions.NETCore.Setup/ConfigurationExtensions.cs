using System;
using Microsoft.Extensions.Configuration;

namespace Skeddly
{
    public static class ConfigurationExtensions
    {
		public static SkeddlyOptions GetSkeddlyOptions(this IConfiguration config)
		{
			return GetSkeddlyOptions(config, "Skeddly");
		}

		public static SkeddlyOptions GetSkeddlyOptions(this IConfiguration config, string configSection)
		{
			if (configSection == null)
				throw new ArgumentNullException("configSection");
			if (String.IsNullOrEmpty(configSection))
				throw new ArgumentOutOfRangeException("configSection");

			var result = new SkeddlyOptions();

			IConfiguration section = config.GetSection(configSection);

			if (!String.IsNullOrEmpty(section["AccessKeyId"]))
				result.AccessKeyId = section["AccessKeyId"];

			if (!String.IsNullOrEmpty(section["EndPoint"]))
				result.EndPoint = section["EndPoint"];

			return result;
		}
	}
}
