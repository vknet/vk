using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Model;

namespace VkNet.Utils.JsonConverter;

/// <inheritdoc />
public class PushSettingsJsonConverter : Newtonsoft.Json.JsonConverter
{
	/// <inheritdoc />
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

	/// <inheritdoc />
	/// <exception cref="T:System.TypeAccessException"> </exception>
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		if (!objectType.IsGenericType)
		{
			throw new TypeAccessException();
		}

		var obj = JObject.Load(reader);
		var responseJToken = obj["response"] ?? obj;
		var response = new VkResponse(responseJToken);

		var result = new PushSettings
		{
			Msg = !response.ContainsKey("msg") ? null : JsonConvert.DeserializeObject<MessagesPushSettings>(response[key: "msg"].ToString()),
			Chat = !response.ContainsKey("chat") ? null : JsonConvert.DeserializeObject<MessagesPushSettings>(response[key: "chat"].ToString()),
			Friend = response.ContainsKey(key: "friend") && response[key: "mutual"],
			FriendFound = response[key: "friend_found"],
			FriendAccepted = response[key: "friend_accepted"],
			Reply = response[key: "reply"],
			Comment = response.ContainsKey(key: "comment") && response[key: "fr_of_fr"],
			Mention = response.ContainsKey(key: "mention") && response[key: "fr_of_fr"],
			Like = response.ContainsKey(key: "like") && response[key: "fr_of_fr"],
			Repost = response.ContainsKey(key: "repost") && response[key: "fr_of_fr"],
			WallPost = response[key: "wall_post"],
			WallPublish = response[key: "wall_publish"],
			GroupInvite = response[key: "group_invite"],
			GroupAccepted = response[key: "group_accepted"],
			EventSoon = response[key: "event_soon"],
			TagPhoto = response.ContainsKey(key: "tag_photo") && response[key: "fr_of_fr"],
			AppRequest = response[key: "app_request"],
			SdkOpen = response[key: "sdk_open"],
			NewPost = response[key: "new_post"],
			Birthday = response[key: "birthday"]
		};

		return result;
	}

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => throw new NotImplementedException();
}