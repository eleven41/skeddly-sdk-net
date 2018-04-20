using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using RichardSzalay.MockHttp;
using Skeddly;

namespace SkeddlySDK.UnitTests
{
    public static class MockedRequestExtensions
    {
		public static MockedRequest WithAuthorizationHeader(this MockedRequest self, SkeddlyOptions options)
		{
			return self.WithHeaders("Authorization", "AccessKey " + options.AccessKeyId);
		}

		public static void RespondJson(this MockedRequest self, Object obj)
		{
			var json = Serialize(obj);
			self.Respond("application/json", json);
		}

		public static string Serialize(Object obj)
		{
			if (obj == null)
				throw new ArgumentNullException("obj");

			using (StringWriter stringWriter = new StringWriter())
			{
				using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter)
				{
					CloseOutput = false
				})
				{
					var serializer = new JsonSerializer()
					{
						NullValueHandling = NullValueHandling.Ignore,
						//ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
					};
					serializer.Serialize(jsonTextWriter, obj);
					jsonTextWriter.Flush();
				}

				return stringWriter.ToString();
			}
		}
	}
}
