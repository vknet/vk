using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Model;

namespace VkNet.Utils.JsonConverter;

/// <inheritdoc />
public class FriendOnlineJsonConverter : Newtonsoft.Json.JsonConverter
{
	/// <inheritdoc />
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

	/// <inheritdoc />
	/// <exception cref="T:System.TypeAccessException"> </exception>
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{


		var obj = JObject.Load(reader);
		var responseJToken = obj["response"] ?? obj;
		var response = new VkResponse(responseJToken);

		if (response.ContainsKey(key: "online"))
		{
			return new FriendOnline
			{
				MobileOnline = response[key: "online_mobile"]
					.ToReadOnlyCollectionOf<long>(selector: x => x),
				Online = response[key: "online"]
					.ToReadOnlyCollectionOf<long>(selector: x => x)
			};
		}

		return new FriendOnline
		{
			Online = response.ToReadOnlyCollectionOf<long>(selector: x => x)
		};
	}

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => typeof(ReadOnlyCollection<>).IsAssignableFrom(c: objectType);
}