using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Model.Attachments;
using VkNet.Model.Keyboard;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Личное сообщение пользователя.
	/// См. описание http://vk.com/dev/message
	/// </summary>
	[DebuggerDisplay("[{PeerId}-{Id}] {Text}")]
	[Serializable]
	public class Message : MediaAttachment
	{
		/// <inheritdoc />
		protected override string Alias => "message";

	#region Методы

		/// <summary>
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
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
				PeerId = response["peer_id"],
				FromId = response["from_id"],
				Text = response["text"],
				RandomId = response["random_id"],
				Attachments = response["attachments"].ToReadOnlyCollectionOf<Attachment>(x => x),
				Important = response["important"],
				Geo = response["geo"],
				Payload = response["payload"],
				ForwardedMessages = response["fwd_messages"].ToReadOnlyCollectionOf<Message>(x => x),
				ReadState = response["read_state"],
				Action = response["action"],
				Type = response["out"],
				Title = response["title"],
				Body = response["body"],
				Emoji = response["emoji"],
				Deleted = response["deleted"],

				// дополнительные поля бесед
				ChatId = response["chat_id"],
				ChatActive = response["chat_active"].ToReadOnlyCollectionOf<long>(x => x),
				UsersCount = response["users_count"],
				AdminId = response["admin_id"],
				PhotoPreviews = response,
				PushSettings = response["push_settings"],
				ActionMid = response["action_mid"],
				ActionEmail = response["action_email"],
				ActionText = response["action_text"],
				Photo50 = response["photo_50"],
				Photo100 = response["photo_100"],
				Photo200 = response["photo_200"],
				InRead = response["in_read"],
				IsCropped = response["is_cropped"],
				OutRead = response["out_read"],
				Out = response["out"],
				UpdateTime = response["update_time"],
				Keyboard = response["keyboard"],
				ConversationMessageId = response["conversation_message_id"],
				Ref = response["ref"],
				RefSource = response["ref_source"],
				ReplyMessage = response["reply_message"]
			};

			return message;
		}

		/// <summary>
		/// Преобразование класса <see cref="Message" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="Message" /></returns>
		public static implicit operator Message(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
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
		[JsonProperty("from_id")]
		public long? FromId { get; set; }

		/// <summary>
		/// Идентификатор назначения.
		/// </summary>
		[JsonProperty("peer_id")]
		public long? PeerId { get; set; }

		/// <summary>
		/// Текст сообщения.
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

		/// <summary>
		/// Дата отправки сообщения.
		/// </summary>
		[JsonProperty("date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Сервисное поле для сообщений ботам (полезная нагрузка).
		/// </summary>
		[JsonProperty("payload")]
		public string Payload { get; set; }

		/// <summary>
		/// Статус сообщения (не возвращается для пересланных сообщений).
		/// </summary>
		public MessageReadState? ReadState { get; set; }

		/// <summary>
		/// тип сообщения (0 — полученное, 1 — отправленное, не возвращается для
		/// пересланных сообщений).
		/// </summary>
		[JsonProperty("out")]
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
		[JsonProperty("geo")]
		public Geo Geo { get; set; }

		/// <summary>
		/// Массив медиа-вложений (прикреплений).
		/// </summary>
		[JsonProperty("attachments")]
		[JsonConverter(typeof(AttachmentJsonConverter))]
		public ReadOnlyCollection<Attachment> Attachments { get; set; }

		/// <summary>
		/// Массив пересланных сообщений (если есть).
		/// </summary>
		[JsonProperty("fwd_messages")]
		public ReadOnlyCollection<Message> ForwardedMessages { get; set; }

		/// <summary>
		/// Содержатся ли в сообщении emoji-смайлы.
		/// </summary>
		public bool? Emoji { get; set; }

		/// <summary>
		/// Является ли сообщение важным.
		/// </summary>
		[JsonProperty("important")]
		public bool? Important { get; set; }

		/// <summary>
		/// Удалено ли сообщение.
		/// </summary>
		public bool? Deleted { get; set; }

		/// <summary>
		/// идентификатор, используемый при отправке сообщения. Возвращается только для
		/// исходящих сообщений.
		/// </summary>
		[JsonProperty("random_id")]
		public long? RandomId { get; set; }

		/// <summary>
		/// Произвольный параметр для работы с источниками переходов.
		/// </summary>
		[JsonProperty("ref")]
		public string Ref { get; set; }

		/// <summary>
		/// Произвольный параметр для работы с источниками переходов.
		/// </summary>
		[JsonProperty("ref_source")]
		public string RefSource { get; set; }

		/// <summary>
		/// Сообщение, в ответ на которое отправлено текущее.
		/// </summary>
		[JsonProperty("reply_message")]
		public Message ReplyMessage { get; set; }

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

		[JsonProperty("action")]
		public MessageActionObject Action { get; set; }

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

	#region Дополнительные поля в сообщениях сообществ

		/// <summary>
		/// Клавиатура, присланная ботом
		/// </summary>
		public MessageKeyboard Keyboard { get; set; }

		/// <summary>
		/// Является ли сообщение обрезаным.
		/// </summary>
		[JsonProperty("is_cropped")]
		public bool? IsCropped { get; set; }

	#endregion

	#region недокументированные

		/// <summary>
		/// Идентификатор сообщения в беседе
		/// </summary>
		[JsonProperty("conversation_message_id")]
		public long? ConversationMessageId { get; set; }

		/// <summary>
		/// Тип сообщения (не возвращается для пересланных сообщений).
		/// </summary>
		public MessageType? Type { get; set; }

		/// <summary>
		/// Содержит количество непрочитанных сообщений в текущем диалоге (если это
		/// значение было возвращено, иначе 0)
		/// </summary>
		public int? Unread { get; set; }

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
		[JsonProperty("update_time")]
		public string UpdateTime { get; set; }

	#endregion
	}
}