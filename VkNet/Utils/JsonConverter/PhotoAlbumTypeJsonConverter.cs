using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Utils.JsonConverter;

public class PhotoAlbumTypeJsonConverter : Newtonsoft.Json.JsonConverter
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

		var obj = JObject.Load(reader);
		var responseJToken = obj["response"] ?? obj;
		var response = new VkResponse(responseJToken);

		switch (response.ToString())
		{
			case "wall":

			{
				return PhotoAlbumType.Wall;
			}

			case "profile":

			{
				return  PhotoAlbumType.Profile;
			}

			case "saved":

			{
				return  PhotoAlbumType.Saved;
			}

			default:

			{
				var input = response.ToString();
				var idPattern = new Regex(pattern: @"([\d]+)");
				long id;

				long.TryParse(idPattern.Match(input: input)
					.Groups[groupnum: 1]
					.Value, out id);

				return PhotoAlbumType.Id(number: id);
			}
		}
	}

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => throw new NotImplementedException();
}