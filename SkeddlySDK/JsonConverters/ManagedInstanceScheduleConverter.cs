using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Skeddly.JsonConverters
{
	public class ManagedInstanceScheduleConverter : Newtonsoft.Json.Converters.CustomCreationConverter<Skeddly.Model.ManagedInstanceSchedule>
	{
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null)
				return null;
			// Load JObject from stream 
			JObject jObject = JObject.Load(reader);

			Skeddly.Model.ScheduleParameters p = null;

			// Search the dictionary "case insensitive"
			Dictionary<string, JToken> d = new Dictionary<string, JToken>(jObject.ToObject<IDictionary<string, JToken>>(), StringComparer.CurrentCultureIgnoreCase);
			var scheduleTypeToken = d["scheduleType"];
			if (scheduleTypeToken != null)
			{
				if (scheduleTypeToken.Type == JTokenType.String)
				{
					string scheduleType = scheduleTypeToken.Value<string>();
					p = ScheduleParametersFactory.Create(scheduleType);
				}
			}
			
			// Create target object based on JObject 
			var target = new Skeddly.Model.ManagedInstanceSchedule()
			{
				Parameters = p
			};

			// Populate the object properties 
			serializer.Populate(jObject.CreateReader(), target);

			return target;
		}

		public override Skeddly.Model.ManagedInstanceSchedule Create(Type objectType)
		{
			return new Skeddly.Model.ManagedInstanceSchedule();
		}
	}
}
