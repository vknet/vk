using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Настройки Push-уведомлений
/// </summary>
[Serializable]
public class PushSettings
{
	/// <summary>
	/// Личные сообщения. Может принимать массив значений.
	/// </summary>
	[JsonProperty("msg")]
	public MessagesPushSettings Msg { get; set; }

	/// <summary>
	/// Групповые чаты. Может принимать массив значений.
	/// </summary>
	[JsonProperty("chat")]
	public MessagesPushSettings Chat { get; set; }

	/// <summary>
	/// Запрос на добавления в друзья. Может принимать массив значений.
	/// </summary>
	[JsonProperty("friend")]
	public bool? Friend { get; set; }

	/// <summary>
	/// Регистрация импортированного контакта.
	/// </summary>
	[JsonProperty("friend_found")]
	public bool? FriendFound { get; set; }

	/// <summary>
	/// Подтверждение заявки в друзья.
	/// </summary>
	[JsonProperty("friend_accepted")]
	public bool? FriendAccepted { get; set; }

	/// <summary>
	/// Ответы.
	/// </summary>
	[JsonProperty("reply")]
	public bool? Reply { get; set; }

	/// <summary>
	/// Комментарии. Может принимать массив значений.
	/// </summary>
	[JsonProperty("comment")]
	public bool? Comment { get; set; }

	/// <summary>
	/// Упоминания. Может принимать массив значений.
	/// </summary>
	[JsonProperty("mention")]
	public bool? Mention { get; set; }

	/// <summary>
	/// Отметки "Мне нравится". Может принимать массив значений.
	/// </summary>
	[JsonProperty("like")]
	public bool? Like { get; set; }

	/// <summary>
	/// Действия "Рассказать друзьям". Может принимать массив значений.
	/// </summary>
	[JsonProperty("repost")]
	public bool? Repost { get; set; }

	/// <summary>
	/// Новая запись на стене пользователя.
	/// </summary>
	[JsonProperty("wall_post")]
	public bool? WallPost { get; set; }

	/// <summary>
	/// Размещение предложенной новости.
	/// </summary>
	[JsonProperty("wall_publish")]
	public bool? WallPublish { get; set; }

	/// <summary>
	/// Приглашение в сообщество.
	/// </summary>
	[JsonProperty("group_invite")]
	public bool? GroupInvite { get; set; }

	/// <summary>
	/// Подтверждение заявки на вступление в группу.
	/// </summary>
	[JsonProperty("group_accepted")]
	public bool? GroupAccepted { get; set; }

	/// <summary>
	/// Ближайшие мероприятия.
	/// </summary>
	[JsonProperty("event_soon")]
	public bool? EventSoon { get; set; }

	/// <summary>
	/// Отметки на фотографиях. Может принимать массив значений.
	/// </summary>
	[JsonProperty("tag_photo")]
	public bool? TagPhoto { get; set; }

	/// <summary>
	/// Запросы в приложениях.
	/// </summary>
	[JsonProperty("app_request")]
	public bool? AppRequest { get; set; }

	/// <summary>
	/// Установка приложения.
	/// </summary>
	[JsonProperty("sdk_open")]
	public bool? SdkOpen { get; set; }

	/// <summary>
	/// Записи выбранных людей и сообществ.
	/// </summary>
	[JsonProperty("new_post")]
	public bool? NewPost { get; set; }

	/// <summary>
	/// Уведомления о днях рождения на текущую дату.
	/// </summary>
	[JsonProperty("birthday")]
	public bool? Birthday { get; set; }

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static PushSettings FromJson(VkResponse response)
	{
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
}