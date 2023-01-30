using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Enums;
using VkNet.Model;

namespace VkNet.Utils.JsonConverter;

public class VkObjectJsonConverter : Newtonsoft.Json.JsonConverter
{
	/// <inheritdoc />
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

	/// <inheritdoc />
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		if (objectType.IsGenericType)
		{
			throw new TypeAccessException();
		}

		if (reader.TokenType == JsonToken.Null)
		{
			return null;
		}

		var objct = JObject.Load(reader);
		var responseJToken = objct["response"] ?? objct;
		var response = new VkResponse(responseJToken);

		var obj = new VkObject
		{
			Id = response[key: "object_id"]
		};

		string type = response[key: "type"];

		switch (type)
		{
			case "group":

			{
				obj.Type = VkObjectType.Group;

				break;
			}

			case "user":

			{
				obj.Type = VkObjectType.User;

				break;
			}

			case "application":

			{
				obj.Type = VkObjectType.Application;

				break;
			}

			case "page":

			{
				obj.Type = VkObjectType.Page;

				break;
			}

			default:

			{
				return obj;
			}
		}

		return obj;
	}

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => throw new NotImplementedException();
}