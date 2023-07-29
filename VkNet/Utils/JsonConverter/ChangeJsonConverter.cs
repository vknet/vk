using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Model;

namespace VkNet.Utils.JsonConverter;

/// <inheritdoc />
public class ChangeJsonConverter : Newtonsoft.Json.JsonConverter
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

		if (reader.TokenType is JsonToken.Null)
		{
			return null;
		}

		var obj = JObject.Load(reader);
		var responseJToken = obj["response"] ?? obj;
		var response = new VkResponse(responseJToken);

		var field = "";

		if (response["title"] is not null)
		{
			field = "title";
		} else if (response["description"] is not null)
		{
			field = "description";
		} else if (response["access"] is not null)
		{
			field = "access";
		} else if (response["screen_name"] is not null)
		{
			field = "screen_name";
		} else if (response["public_category"] is not null)
		{
			field = "public_category";
		} else if (response["age_limits"] is not null)
		{
			field = "age_limits";
		} else if (response["website"] is not null)
		{
			field = "website";
		} else if (response["public_subcategory"] is not null)
		{
			field = "public_subcategory";
		} else if (response["enable_status_default"] is not null)
		{
			field = "enable_status_default";
		} else if (response["enable_audio"] is not null)
		{
			field = "enable_audio";
		} else if (response["enable_photo"] is not null)
		{
			field = "enable_photo";
		} else if (response["enable_video"] is not null)
		{
			field = "enable_video";
		} else if (response["enable_market"] is not null)
		{
			field = "enable_market";
		}

		if (field != "")
		{
			return new Change
			{
				Field = field,
				NewValue = response[field]["new_value"],
				OldValue = response[field]["old_value"]
			};
		}

		return new Change
		{
			Field = field,
			NewValue = null,
			OldValue = null
		};
	}

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => throw new NotImplementedException();
}