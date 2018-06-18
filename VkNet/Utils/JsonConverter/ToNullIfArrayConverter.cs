using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace VkNet.Utils.JsonConverter
{
	/// <summary>
	/// TODO: Description
	/// </summary>
	public class ToNullIfArrayConverter<T> : Newtonsoft.Json.JsonConverter
	{
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JToken token = JToken.Load(reader);
			if (token.Type == JTokenType.Array)
			{
				return null;
			}
			return token.ToObject<T>();
		}

		/// <summary>
		/// TODO: Description
		/// </summary>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// TODO: Description
		/// </summary>
		public override bool CanConvert(Type objectType)
		{
			throw new NotImplementedException();
		}
	}
}
