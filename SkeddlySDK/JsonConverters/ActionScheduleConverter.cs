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
	public class ActionScheduleConverter : Newtonsoft.Json.Converters.CustomCreationConverter<Skeddly.Model.ActionSchedule>
	{
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null)
				return null;
			// Load JObject from stream 
			JObject jObject = JObject.Load(reader);

			Skeddly.Model.ScheduleParameters p = null;

			var scheduleTypeToken = jObject["scheduleType"];
			if (scheduleTypeToken != null)
			{
				if (scheduleTypeToken.Type == JTokenType.String)
				{
					string scheduleType = scheduleTypeToken.Value<string>();
					p = ScheduleParametersFactory.Create(scheduleType);
				}
			}
			
			// Create target object based on JObject 
			var target = new Skeddly.Model.ActionSchedule()
			{
				Parameters = p
			};

			// Populate the object properties 
			serializer.Populate(jObject.CreateReader(), target);

			return target;
		}

		public override Skeddly.Model.ActionSchedule Create(Type objectType)
		{
			return new Skeddly.Model.ActionSchedule();
		}
	}

	public static class ScheduleParametersFactory
	{
		private static ConcurrentDictionary<string, Type> _typeCache = new ConcurrentDictionary<string, Type>();

		public static Skeddly.Model.ScheduleParameters Create(string scheduleType)
		{
			switch (scheduleType)
			{
				case Constants.ScheduleTypes.None:
					return new Skeddly.Model.NoneScheduleParameters();
				case Constants.ScheduleTypes.Hourly:
					return new Skeddly.Model.HourlyScheduleParameters();
				case Constants.ScheduleTypes.Daily:
					return new Skeddly.Model.DailyScheduleParameters();
				case Constants.ScheduleTypes.Weekly:
					return new Skeddly.Model.WeeklyScheduleParameters();
				case Constants.ScheduleTypes.Monthly:
					return new Skeddly.Model.MonthlyScheduleParameters();
				default:
					return null;
			}
		}

	}
}
