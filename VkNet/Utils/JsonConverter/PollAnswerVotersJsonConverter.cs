using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Model;

namespace VkNet.Utils.JsonConverter;

public class PollAnswerVotersJsonConverter : Newtonsoft.Json.JsonConverter
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

		var isLongMode = false;

		if (response.ContainsKey(key: "users")
			&& response[key: "users"]
				.ContainsKey(key: "items"))
		{
			var array = (VkResponseArray) response[key: "users"][key: "items"];

			if (array.Count > 0
				&& !array[key: 0]
					.ContainsKey(key: "id"))
			{
				isLongMode = true;
			}
		}

		var answer = new PollAnswerVoters
		{
			AnswerId = response[key: "answer_id"]
		};

		if (isLongMode)
		{
			answer.UsersIds = response[key: "users"]
				.ToVkCollectionOf<long>(selector: x => x);
		} else
		{
			answer.Users = response[key: "users"]
				.ToVkCollectionOf(selector: x => JsonConvert.DeserializeObject<User>(x.ToString()));
		}

		return answer;
	}

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => throw new NotImplementedException();
}