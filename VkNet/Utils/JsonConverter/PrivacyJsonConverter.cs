using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Utils.JsonConverter;

/// <inheritdoc />
public class PrivacyJsonConverter : Newtonsoft.Json.JsonConverter
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
			case "all":

			{
				return Privacy.All;
			}

			case "friends":

			{
				return  Privacy.Friends;
			}

			case "friends_of_friends":

			{
				return  Privacy.FriendsOfFriends;
			}

			case "friends_of_friends_only":

			{
				return  Privacy.FriendsOfFriendsOnly;
			}

			case "nobody":

			{
				return  Privacy.Nobody;
			}

			case "only_me":

			{
				return  Privacy.OnlyMe;
			}

			default:

			{
				var input = response.ToString();
				var idPattern = new Regex(pattern: @"([\d]+)");
				long id;

				long.TryParse(idPattern.Match(input: input)
					.Groups[groupnum: 1]
					.Value, out id);

				if (input.StartsWith(value: "list"))
				{
					return  Privacy.AvailableForList(number: id);
				}

				if (input.StartsWith(value: "-list"))
				{
					return  Privacy.UnAvailableForList(number: id);
				}

				return input.StartsWith(value: "-")
					?  Privacy.UnAvailableForUser(number: id)
					:  Privacy.AvailableForUser(number: id);
			}
		}
	}

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => throw new NotImplementedException();
}