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
	public class ActionConverter : Newtonsoft.Json.Converters.CustomCreationConverter<Skeddly.Model.Action>
	{
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null)
				return null;
			// Load JObject from stream 
			JObject jObject = JObject.Load(reader);

			Skeddly.Model.ActionParameters p = null;

			// Search the dictionary "case insensitive"
			Dictionary<string, JToken> d = new Dictionary<string, JToken>(jObject.ToObject<IDictionary<string, JToken>>(), StringComparer.CurrentCultureIgnoreCase);
			var actionTypeToken = d["actionType"];

			if (actionTypeToken != null)
			{
				if (actionTypeToken.Type == JTokenType.String)
				{
					string actionType = actionTypeToken.Value<string>();
					try 
					{	        
						p = ActionParametersFactory.Create(actionType);
					}
					catch
					{
						p = null;
					}
				}
			}
			
			// Create target object based on JObject 
			var target = new Skeddly.Model.Action()
			{
				Parameters = p
			};

			// Populate the object properties 
			serializer.Populate(jObject.CreateReader(), target);

			return target;
		}

		public override Skeddly.Model.Action Create(Type objectType)
		{
			return new Skeddly.Model.Action();
		}
	}

	public static class ActionParametersFactory
	{
		private static ConcurrentDictionary<string, Type> _typeCache = new ConcurrentDictionary<string, Type>();

		public static Skeddly.Model.ActionParameters Create(string actionType)
		{
			// See if we already have a cached value
			Type parameterType = null;
			if (!_typeCache.TryGetValue(actionType, out parameterType))
			{
				string classSafeActionType = GetClassSafeActionType(actionType);

				// We do not have a cached value, so find the type in the assembly
				var assembly = System.Reflection.Assembly.GetExecutingAssembly();
				var types = assembly.GetTypes();
				foreach (var type in types)
				{
					if (type.Name == classSafeActionType + "Parameters")
					{
						parameterType = type;
						break;
					}
				}

				// Add to the cache
				_typeCache.TryAdd(actionType, parameterType);
			}

			// If nothing was found, then throw an exception
			if (parameterType == null)
				throw new Exception("Invalid action type: " + actionType);

			// Create the controller based on the found type
			return (Skeddly.Model.ActionParameters)Activator.CreateInstance(parameterType);
		}

		private static string GetClassSafeActionType(string actionType)
		{
			System.Text.StringBuilder sb = new StringBuilder();

			bool isConvertNext = true;
			for (int i = 0; i < actionType.Length; ++i)
			{
				char c = actionType[i];
				if (c == '-')
				{
					isConvertNext = true;
					continue;
				}
				else if (isConvertNext)
				{
					isConvertNext = false;
					c = Char.ToUpper(c);
				}

				sb.Append(c);
			}

			actionType = sb.ToString();

			// Special case handling
			actionType = actionType
				.Replace("Elasticache", "ElastiCache")
				.Replace("Cloudformation", "CloudFormation")
				.Replace("Dynamodb", "DynamoDb")
				.Replace("Mysql", "MySQL");
			return actionType;
		}
	}
}
