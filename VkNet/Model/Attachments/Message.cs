using System.Runtime.Serialization;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;

namespace VkNet.Model
{
	using System;
	using System.Diagnostics;
	using System.Collections.ObjectModel;

	using Enums;
	using Utils;

	/// <summary>
	/// Личное сообщение пользователя.
	/// См. описание http://vk.com/dev/message
	/// </summary>
	[DebuggerDisplay("[{UserId}-{Id}] {Body}")]
	[Serializable]
	public class Message : MediaAttachment
	{
		/// <summary>
		/// Подарок.
		/// </summary>
		static Message()
		{
			RegisterType(typeof(Message), "message");
		}
		#region Стандартные поля

		/// <summary>
		/// Идентификатор автора сообщения (для исходящего сообщения — идентификатор получателя).
		/// </summary>
		public long? UserId
		{ get; set; }

		/// <summary>
		/// Дата отправки сообщения.
		/// </summary>
		public DateTime? Date
		{ get; set; }

		/// <summary>
		/// Статус сообщения (не возвращается для пересланных сообщений).
		/// </summary>
		public MessageReadState? ReadState
		{ get; set; }

		/// <summary>
		/// Тип сообщения (не возвращается для пересланных сообщений).
		/// </summary>
		public MessageType? Type
		{ get; set; }

		/// <summary>
		/// Содержит количество непрочитанных сообщений в текущем диалоге (если это значение было возвращено, иначе 0)
		/// </summary>
		public int Unread
		{ get; set; }

		/// <summary>
		/// Заголовок сообщения или беседы.
		/// </summary>
		public string Title
		{ get; set; }

		/// <summary>
		/// Текст сообщения.
		/// </summary>
		public string Body
		{ get; set; }

		/// <summary>
		/// Массив медиа-вложений (прикреплений).
		/// </summary>
		public Collection<Attachment> Attachments
		{ get; set; }

		/// <summary>
		/// Гео данные.
		/// </summary>
		public Geo Geo
		{ get; set; }

		/// <summary>
		/// Массив пересланных сообщений (если есть).
		/// </summary>
		public Collection<Message> ForwardedMessages
		{ get; set; }

		/// <summary>
		/// Содержатся ли в сообщении emoji-смайлы.
		/// </summary>
		public bool ContainsEmojiSmiles
		{ get; set; }

		/// <summary>
		/// Является ли сообщение важным.
		/// </summary>
		public bool IsImportant
		{ get; set; }

		/// <summary>
		/// Удалено ли сообщение.
		/// </summary>
		public bool? IsDeleted
		{ get; set; }

		/// <summary>
		/// Идентификатор автора сообщения.
		/// </summary>
		public long? FromId
		{ get; set; }

		#endregion

		#region Дополнительные поля в сообщениях бесед (мультидиалогов)

		/// <summary>
		/// Идентификатор беседы.
		/// </summary>
		public long? ChatId
		{ get; set; }

		/// <summary>
		/// Идентификаторы участников беседы.
		/// </summary>
		public Collection<long> ChatActiveIds
		{ get; set; }

		/// <summary>
		/// Количество участников беседы.
		/// </summary>
		public int? UsersCount
		{ get; set; }

		/// <summary>
		/// Идентификатор создателя беседы.
		/// </summary>
		public long? AdminId
		{ get; set; }

		/// <summary>
		/// Информация о ссылках на предпросмотр фотографий беседы.
		/// </summary>
		public Previews PhotoPreviews
		{ get; set; }

		/// <summary>
		/// Настройки уведомлений для беседы, если они есть. sound и disabled_until
		/// </summary>
		public ChatPushSettings ChatPushSettings
		{ get; set; }

		/// <summary>
		/// поле передано, если это служебное сообщение
		/// </summary>
		/// <remarks>
		/// строка, может быть chat_photo_update или chat_photo_remove, а с версии 5.14 еще и chat_create, chat_title_update, chat_invite_user, chat_kick_user
		/// </remarks>
		public MessageAction Action
		{ get; set; }

		/// <summary>
		/// Идентификатор пользователя (если больше 0) или email (если меньше 0), которого пригласили или исключили.
		/// </summary>
		public long? ActionMid
		{ get; set; }

		/// <summary>
		/// email, который пригласили или исключили.
		/// </summary>
		public string ActionEmail
		{ get; set; }

		/// <summary>
		/// Название беседы.
		/// </summary>
		public string ActionText
		{ get; set; }

		/// <summary>
		/// <c>Uri</c> копии фотографии беседы шириной 50px.
		/// </summary>
		public string Photo50
		{ get; set; }

		/// <summary>
		/// <c>Uri</c> копии фотографии беседы шириной 100px.
		/// </summary>
		public string Photo100
		{ get; set; }

		/// <summary>
		/// <c>Uri</c> копии фотографии беседы шириной 200px.
		/// </summary>
		public string Photo200
		{ get; set; }

		/// <summary>
		/// Идентификатор последнего прочитанного сообщения текущим пользователем
		/// </summary>
		public ulong? InRead
		{ get; set; }

		/// <summary>
		/// Идентификатор последнего прочитанного сообщения собеседником
		/// </summary>
		public ulong? OutRead
		{ get; set; }

		#endregion

		#region Методы

		/// <summary>
		/// 
		/// </summary>
		/// <param name="response"></param>
		/// <returns></returns>
		public static Message FromJson(VkResponse response)
		{
			if (response.ContainsKey("message"))
			{
				response = response["message"];
			}
			var message = new Message
			{
				Unread = response.ContainsKey("unread") ? response["unread"] : 0,
				Id = response["id"],
				UserId = response["user_id"],
				Date = response["date"],
				ReadState = response["read_state"],
				Type = response["out"],
				Title = response["title"],
				Body = response["body"],
				Attachments = response["attachments"],
				Geo = response["geo"],
				ForwardedMessages = response["fwd_messages"],
				ContainsEmojiSmiles = response["emoji"],
				IsImportant = response["important"],
				IsDeleted = response["deleted"],
				FromId = response["from_id"],
				// дополнительные поля бесед
				ChatId = response["chat_id"],
				ChatActiveIds = response["chat_active"],
				UsersCount = response["users_count"],
				AdminId = response["admin_id"],
				PhotoPreviews = response,
				ChatPushSettings = response["push_settings"],
				Action = response["action"],
				ActionMid = response["action_mid"],
				ActionEmail = response["action_email"],
				ActionText = response["action_text"],
				Photo50 = response["photo_50"],
				Photo100 = response["photo_100"],
				Photo200 = response["photo_200"],

				InRead = response["in_read"],
				OutRead = response["out_read"]
			};

			return message;
		}

		#endregion
	}
}
