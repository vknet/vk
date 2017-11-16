using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Настройки Push-уведомлений
	/// </summary>
	[DataContract]
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
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static PushSettings FromJson(VkResponse response)
		{
			var result = new PushSettings
			{
				Msg = response["msg"],
				Chat = response["chat"],
				Friend = response.ContainsKey("friend") && response["mutual"],
				FriendFound = response["friend_found"],
				FriendAccepted = response["friend_accepted"],
				Reply = response["reply"],
				Comment = response.ContainsKey("comment") && response["fr_of_fr"],
				Mention = response.ContainsKey("mention") && response["fr_of_fr"],
				Like = response.ContainsKey("like") && response["fr_of_fr"],
				Repost = response.ContainsKey("repost") && response["fr_of_fr"],
				WallPost = response["wall_post"],
				WallPublish = response["wall_publish"],
				GroupInvite = response["group_invite"],
				GroupAccepted = response["group_accepted"],
				EventSoon = response["event_soon"],
				TagPhoto = response.ContainsKey("tag_photo") && response["fr_of_fr"],
				AppRequest = response["app_request"],
				SdkOpen = response["sdk_open"],
				NewPost = response["new_post"],
				Birthday = response["birthday"]
			};

			return result;
		}
	}
}