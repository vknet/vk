using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Настройки Push-уведомлений
	/// </summary>
	[Serializable]
	public class PushSettings
	{
		/// <summary>
		/// Личные сообщения. Может принимать массив значений.
		/// </summary>
		public MessagesPushSettings Msg { get; set; }

		/// <summary>
		/// Групповые чаты. Может принимать массив значений.
		/// </summary>
		public MessagesPushSettings Chat { get; set; }

		/// <summary>
		/// Запрос на добавления в друзья. Может принимать массив значений.
		/// </summary>
		public bool? Friend { get; set; }

		/// <summary>
		/// Регистрация импортированного контакта.
		/// </summary>
		public bool? FriendFound { get; set; }

		/// <summary>
		/// Подтверждение заявки в друзья.
		/// </summary>
		public bool? FriendAccepted { get; set; }

		/// <summary>
		/// Ответы.
		/// </summary>
		public bool? Reply { get; set; }

		/// <summary>
		/// Комментарии. Может принимать массив значений.
		/// </summary>
		public bool? Comment { get; set; }

		/// <summary>
		/// Упоминания. Может принимать массив значений.
		/// </summary>
		public bool? Mention { get; set; }

		/// <summary>
		/// Отметки "Мне нравится". Может принимать массив значений.
		/// </summary>
		public bool? Like { get; set; }

		/// <summary>
		/// Действия "Рассказать друзьям". Может принимать массив значений.
		/// </summary>
		public bool? Repost { get; set; }

		/// <summary>
		/// Новая запись на стене пользователя.
		/// </summary>
		public bool? WallPost { get; set; }

		/// <summary>
		/// Размещение предложенной новости.
		/// </summary>
		public bool? WallPublish { get; set; }

		/// <summary>
		/// Приглашение в сообщество.
		/// </summary>
		public bool? GroupInvite { get; set; }

		/// <summary>
		/// Подтверждение заявки на вступление в группу.
		/// </summary>
		public bool? GroupAccepted { get; set; }

		/// <summary>
		/// Ближайшие мероприятия.
		/// </summary>
		public bool? EventSoon { get; set; }

		/// <summary>
		/// Отметки на фотографиях. Может принимать массив значений.
		/// </summary>
		public bool? TagPhoto { get; set; }

		/// <summary>
		/// Запросы в приложениях.
		/// </summary>
		public bool? AppRequest { get; set; }

		/// <summary>
		/// Установка приложения.
		/// </summary>
		public bool? SdkOpen { get; set; }

		/// <summary>
		/// Записи выбранных людей и сообществ.
		/// </summary>
		public bool? NewPost { get; set; }

		/// <summary>
		/// Уведомления о днях рождения на текущую дату.
		/// </summary>
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
					Msg = response[key: "msg"]
					, Chat = response[key: "chat"]
					, Friend = response.ContainsKey(key: "friend") && response[key: "mutual"]
					, FriendFound = response[key: "friend_found"]
					, FriendAccepted = response[key: "friend_accepted"]
					, Reply = response[key: "reply"]
					, Comment = response.ContainsKey(key: "comment") && response[key: "fr_of_fr"]
					, Mention = response.ContainsKey(key: "mention") && response[key: "fr_of_fr"]
					, Like = response.ContainsKey(key: "like") && response[key: "fr_of_fr"]
					, Repost = response.ContainsKey(key: "repost") && response[key: "fr_of_fr"]
					, WallPost = response[key: "wall_post"]
					, WallPublish = response[key: "wall_publish"]
					, GroupInvite = response[key: "group_invite"]
					, GroupAccepted = response[key: "group_accepted"]
					, EventSoon = response[key: "event_soon"]
					, TagPhoto = response.ContainsKey(key: "tag_photo") && response[key: "fr_of_fr"]
					, AppRequest = response[key: "app_request"]
					, SdkOpen = response[key: "sdk_open"]
					, NewPost = response[key: "new_post"]
					, Birthday = response[key: "birthday"]
			};

			return result;
		}
	}
}