using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Model;

namespace VkNet.Utils.JsonConverter;

/// <inheritdoc />
public class GetChatUsersJsonConverter : Newtonsoft.Json.JsonConverter
{
	/// <inheritdoc />
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

	/// <inheritdoc />
	/// <exception cref="T:System.TypeAccessException"> </exception>
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		if (objectType.IsGenericType)
		{
			throw new TypeAccessException();
		}

		var obj = JObject.Load(reader);
		var responseJToken = obj["response"] ?? obj;

		var list = new List<User>();
		var users = JsonConvert.DeserializeObject<Dictionary<string, List<User>>>(responseJToken.ToString());

		foreach (var user in users)
		{
			foreach (var item in user.Value)
			{
				var exist = list.Exists(first => first.Id == item.Id);
				if (!exist)
				{
					list.Add(item);
				}
			}
		}

		return new GetChatUsers
		{
			Users = list.ToReadOnlyCollection()
		};
	}

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => throw new NotImplementedException();
}