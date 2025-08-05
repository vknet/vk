using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Model;

namespace VkNet.Utils.JsonConverter;

/// <summary>
/// Converter SearchDialogsResponse
/// </summary>
public class SearchDialogsResponseJsonConverter : Newtonsoft.Json.JsonConverter
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

		var result = new SearchDialogsResponse
		{
			Users = new List<User>(),
			Chats = new List<Chat>(),
			Groups = new List<Group>()
		};

		VkResponseArray responseArray = response;

		foreach (var record in responseArray)
		{
			string type = record[key: "type"];

			switch (type)
			{
				case "profile":

				{
					result.Users.Add(JsonConvert.DeserializeObject<User>(record.ToString()));

					break;
				}

				case "chat":

				{
					result.Chats.Add(JsonConvert.DeserializeObject<Chat>(record.ToString()));

					break;
				}

				case "email":

				{
					// TODO: Add email support.
					continue;
				}

				case "group":

				{
					result.Groups.Add(JsonConvert.DeserializeObject<Group>(record.ToString()));

					break;
				}
			}
		}

		return result;
	}

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => throw new NotImplementedException();
}