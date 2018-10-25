using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;

namespace VkNet.Utils.JsonConverter
{
	public class IgnoreUnexpectedArraysConverter<T> : IgnoreUnexpectedArraysConverterBase
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(T).IsAssignableFrom(objectType);
		}
	}

	public class IgnoreUnexpectedArraysConverter : IgnoreUnexpectedArraysConverterBase
	{
		private readonly IContractResolver resolver;

		public IgnoreUnexpectedArraysConverter(IContractResolver resolver)
		{
			if (resolver == null)
				throw new ArgumentNullException();
			this.resolver = resolver;
		}

		public override bool CanConvert(Type objectType)
		{
			if (objectType.IsPrimitive || objectType == typeof(string))
				return false;
			return resolver.ResolveContract(objectType) is JsonObjectContract;
		}
	}

	public abstract class IgnoreUnexpectedArraysConverterBase : Newtonsoft.Json.JsonConverter
	{
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var contract = serializer.ContractResolver.ResolveContract(objectType);
			if (!(contract is JsonObjectContract))
			{
				throw new JsonSerializationException(string.Format("{0} is not a JSON object", objectType));
			}

			do
			{
				if (reader.TokenType == JsonToken.Null)
				{
					return null;
				} else if (reader.TokenType == JsonToken.StartArray)
				{
					var array = JArray.Load(reader);
					if (array.Count > 0)
						throw new JsonSerializationException("Array was not empty.");
					return null;
				} else if (reader.TokenType == JsonToken.StartObject)
				{
					// Prevent infinite recursion by using Populate()
					existingValue = existingValue ?? contract.DefaultCreator();
					serializer.Populate(reader, existingValue);
					return existingValue;
				} else
				{
					throw new JsonSerializationException(string.Format("Unexpected token {0}", reader.TokenType));
				}
			}
			while (reader.Read());
			throw new JsonSerializationException("Unexpected end of JSON.");
		}

		public override bool CanWrite { get { return false; } }

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}