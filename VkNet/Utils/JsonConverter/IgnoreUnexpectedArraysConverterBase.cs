using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace VkNet.Utils.JsonConverter
{
	/// <inheritdoc />
	public abstract class IgnoreUnexpectedArraysConverterBase : Newtonsoft.Json.JsonConverter
	{
		/// <inheritdoc />
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var contract = serializer.ContractResolver.ResolveContract(objectType);

			if (!(contract is JsonObjectContract))
			{
				throw new JsonSerializationException(string.Format("{0} is not a JSON object", objectType));
			}

			do
			{
				switch (reader.TokenType)
				{
					case JsonToken.Null:
						return null;
					case JsonToken.StartArray:
					{
						var array = JArray.Load(reader);

						if (array.Count > 0)
						{
							throw new JsonSerializationException("Array was not empty.");
						}

						return null;
					}
					case JsonToken.StartObject:
						// Prevent infinite recursion by using Populate()
						existingValue ??= contract.DefaultCreator();
						serializer.Populate(reader, existingValue);

						return existingValue;
					default:
						throw new JsonSerializationException($"Unexpected token {reader.TokenType}");
				}
			} while (reader.Read());

			throw new JsonSerializationException("Unexpected end of JSON.");
		}

		/// <inheritdoc />
		public override bool CanWrite => false;

		/// <inheritdoc />
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}