using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Utils.JsonConverter;

/// <inheritdoc />
public class UserOrGroupJsonConverter : Newtonsoft.Json.JsonConverter
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

		var userOrGroup = new UserOrGroup
		{
			Users = new(),
			Groups = new()
		};

		if (response.ContainsKey(key: "count"))
		{
			userOrGroup.TotalCount = response[key: "count"];
		}

		VkResponseArray result = response;

		foreach (var item in result)
		{
			switch (item["type"].ToString())
			{
				case "group":
					userOrGroup.Groups.Add(JsonConvert.DeserializeObject<Group>(item.ToString()));
					break;

				case "profile":
					userOrGroup.Users.Add(JsonConvert.DeserializeObject<User>(item.ToString()));
					break;

				default:
					throw new VkApiException(message:
						$"Типа '{item[key: "type"]}' не существует. Пожалуйста заведите задачу на сайте проекта: https://github.com/vknet/vk/issues");
			}
		}
		return userOrGroup;
	}

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => throw new NotImplementedException();
}