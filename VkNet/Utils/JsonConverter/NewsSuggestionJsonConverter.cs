using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Utils.JsonConverter;

/// <inheritdoc />
public class NewsSuggestionJsonConverter : Newtonsoft.Json.JsonConverter
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

		var newsSuggestions = new NewsSuggestions
		{
			Users = new(),
			Groups = new()
		};

		VkResponseArray result = response;

		foreach (var item in result)
		{
			switch (item[key: "type"]
						.ToString())
			{
				case "page":
				case "group":

				{
					var group = JsonConvert.DeserializeObject<Group>(item);
					newsSuggestions.Groups.Add(item: group);
				}

					break;

				case "profile":

				{
					var user = JsonConvert.DeserializeObject<User>(item);
					newsSuggestions.Users.Add(item: user);
				}

					break;

				default:

				{
					throw new VkApiException(message: string.Format(
						"Типа '{0}' не существует. Пожалуйста заведите задачу на сайте проекта: https://github.com/vknet/vk/issues"
						, item[key: "type"]));
				}
			}
		}

		return newsSuggestions;
	}

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => throw new NotImplementedException();
}