using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Личное сообщение пользователя.
	/// См. описание http://vk.com/dev/message
	/// </summary>
	[DebuggerDisplay(value: "[{UserId}-{Id}] {Body}")]
	[Serializable]
	public class Message : MediaAttachment
	{
		/// <summary>
		/// Подарок.
		/// </summary>
		static Message()
		{
			RegisterType(type: typeof(Message), match: "message");
		}

	#region Методы

		/// <summary>
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
		public static Message FromJson(VkResponse response)
		{
			if (response.ContainsKey(key: "message"))
			{
				response = response[key: "message"];
			}

			var message = new Message
			{
					Unread = response.ContainsKey(key: "unread") ? response[key: "unread"] : 0
					, Id = response[key: "id"]
					, UserId = response[key: "user_id"]
					, Date = response[key: "date"]
					, ReadState = response[key: "read_state"]
					, Type = response[key: "out"]
					, Title = response[key: "title"]
					, Body = response[key: "body"]
					, Attachments = response[key: "attachments"].ToReadOnlyCollectionOf<Attachment>(selector: x => x)
					, Geo = response[key: "geo"]
					, ForwardedMessages = response[key: "fwd_messages"].ToReadOnlyCollectionOf<Message>(selector: x => x)
					, Emoji = response[key: "emoji"]
					, Important = response[key: "important"]
					, Deleted = response[key: "deleted"]
					, FromId = response[key: "from_id"]
					,

					// дополнительные поля бесед
					ChatId = response[key: "chat_id"]
					, ChatActive = response[key: "chat_active"].ToReadOnlyCollectionOf<long>(selector: x => x)
					, UsersCount = response[key: "users_count"]
					, AdminId = response[key: "admin_id"]
					, PhotoPreviews = response
					, PushSettings = response[key: "push_settings"]
					, Action = response[key: "action"]
					, ActionMid = response[key: "action_mid"]
					, ActionEmail = response[key: "action_email"]
					, ActionText = response[key: "action_text"]
					, Photo50 = response[key: "photo_50"]
					, Photo100 = response[key: "photo_100"]
					, Photo200 = response[key: "photo_200"]
					, InRead = response[key: "in_read"]
					, OutRead = response[key: "out_read"]
					, Out = response[key: "out"]
					, UpdateTime = response[key: "update_time"]
			};

			return message;
		}

	#endregion

	#region Стандартные поля

		/// <summary>
		/// Идентификатор автора сообщения (для исходящего сообщения — идентификатор
		/// получателя).
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Идентификатор автора сообщения.
		/// </summary>
		public long? FromId { get; set; }

		/// <summary>
		/// Дата отправки сообщения.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Статус сообщения (не возвращается для пересланных сообщений).
		/// </summary>
		public MessageReadState? ReadState { get; set; }

		/// <summary>
		/// тип сообщения (0 — полученное, 1 — отправленное, не возвращается для
		/// пересланных сообщений).
		/// </summary>
		[JsonProperty(propertyName: "out")]
		public bool? Out { get; set; }

		/// <summary>
		/// Заголовок сообщения или беседы.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Текст сообщения.
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// Гео данные.
		/// </summary>
		public Geo Geo { get; set; }

		/// <summary>
		/// Массив медиа-вложений (прикреплений).
		/// </summary>
		public ReadOnlyCollection<Attachment> Attachments { get; set; }

		/// <summary>
		/// Массив пересланных сообщений (если есть).
		/// </summary>
		public ReadOnlyCollection<Message> ForwardedMessages { get; set; }

		/// <summary>
		/// Содержатся ли в сообщении emoji-смайлы.
		/// </summary>
		public bool Emoji { get; set; }

		/// <summary>
		/// Является ли сообщение важным.
		/// </summary>
		public bool Important { get; set; }

		/// <summary>
		/// Удалено ли сообщение.
		/// </summary>
		public bool? Deleted { get; set; }

		/// <summary>
		/// идентификатор, используемый при отправке сообщения. Возвращается только для
		/// исходящих сообщений.
		/// </summary>
		[JsonProperty(propertyName: "random_id")]
		public long RandomId { get; set; }

	#endregion

	#region Дополнительные поля в сообщениях бесед (мультидиалогов)

		/// <summary>
		/// Идентификатор беседы.
		/// </summary>
		public long? ChatId { get; set; }

		/// <summary>
		/// Идентификаторы участников беседы.
		/// </summary>
		public ReadOnlyCollection<long> ChatActive { get; set; }

		/// <summary>
		/// Настройки уведомлений для беседы, если они есть. sound и disabled_until
		/// </summary>
		public ChatPushSettings PushSettings { get; set; }

		/// <summary>
		/// Количество участников беседы.
		/// </summary>
		public int? UsersCount { get; set; }

		/// <summary>
		/// Идентификатор создателя беседы.
		/// </summary>
		public long? AdminId { get; set; }

		/// <summary>
		/// поле передано, если это служебное сообщение
		/// </summary>
		/// <remarks>
		/// строка, может быть chat_photo_update или chat_photo_remove, а с версии 5.14 еще
		/// и chat_create, chat_title_update,
		/// chat_invite_user, chat_kick_user
		/// </remarks>
		public MessageAction Action { get; set; }

		/// <summary>
		/// Идентификатор пользователя (если больше 0) или email (если меньше 0), которого
		/// пригласили или исключили.
		/// </summary>
		public long? ActionMid { get; set; }

		/// <summary>
		/// email, который пригласили или исключили.
		/// </summary>
		public string ActionEmail { get; set; }

		/// <summary>
		/// Название беседы.
		/// </summary>
		public string ActionText { get; set; }

		/// <summary>
		/// <c> Uri </c> копии фотографии беседы шириной 50px.
		/// </summary>
		public string Photo50 { get; set; }

		/// <summary>
		/// <c> Uri </c> копии фотографии беседы шириной 100px.
		/// </summary>
		public string Photo100 { get; set; }

		/// <summary>
		/// <c> Uri </c> копии фотографии беседы шириной 200px.
		/// </summary>
		public string Photo200 { get; set; }

	#endregion

	#region недокументированные

		/// <summary>
		/// Тип сообщения (не возвращается для пересланных сообщений).
		/// </summary>
		public MessageType? Type { get; set; }

		/// <summary>
		/// Содержит количество непрочитанных сообщений в текущем диалоге (если это
		/// значение было возвращено, иначе 0)
		/// </summary>
		public int Unread { get; set; }

		/// <summary>
		/// Информация о ссылках на предпросмотр фотографий беседы.
		/// </summary>
		public Previews PhotoPreviews { get; set; }

		/// <summary>
		/// Идентификатор последнего прочитанного сообщения текущим пользователем
		/// </summary>
		public ulong? InRead { get; set; }

		/// <summary>
		/// Идентификатор последнего прочитанного сообщения собеседником
		/// </summary>
		public ulong? OutRead { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty(propertyName: "update_time")]
		public string UpdateTime { get; set; }

	#endregion
	}
}