using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace VkNet.Utils.JsonConverter
{
	/// <summary>
	/// TODO: Description
	/// </summary>
	public class SafetyEnumJsonConverter : Newtonsoft.Json.JsonConverter
	{
		/// <summary>
		/// TODO: Description
		/// </summary>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteValue(value.ToString());
		}

		/// <summary>
		/// TODO: Description
		/// </summary>
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null)
			{
				return null;
			}

			var value = reader.Value;

			if (value == null)
			{
				if (reader.TokenType == JsonToken.StartObject)
				{
					reader.Read();
				}

				if (reader.TokenType == JsonToken.PropertyName)
				{
					reader.Read();
				}

				value = reader.Value;

				var hasRead = true;

				while (hasRead)
				{
					hasRead = reader.Read();
				}
			}

			var result = Activator.CreateInstance(type: objectType);

			var methods = result.GetType()
				.GetMethods(bindingAttr: BindingFlags.NonPublic|BindingFlags.Public|BindingFlags.Static|BindingFlags.FlattenHierarchy);

			result = methods
				.FirstOrDefault(predicate: x => x.Name == "FromJsonString")
				?.Invoke(obj: result, parameters: new object[] { $"{value}" });

			var fields = result?.GetType().GetFields();

			if (fields == null)
			{
				return null;
			}

			foreach (var field in fields)
			{
				field.GetValue(null);
			}

			return result;
		}

		/// <inheritdoc />
		public override bool CanConvert(Type objectType)
		{
			throw new NotImplementedException();
		}
	}
}