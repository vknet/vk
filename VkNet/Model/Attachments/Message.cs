using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// Личное сообщение пользователя.
/// См. описание http://vk.com/dev/message
/// </summary>
[DebuggerDisplay("[{PeerId}-{Id}] {Text}")]
[Serializable]
public class Message : MediaAttachment, IGroupUpdate
{
	/// <inheritdoc />
	protected override string Alias => "message";

	#region Стандартные поля

	/// <summary>
	/// Идентификатор автора сообщения (для исходящего сообщения — идентификатор
	/// получателя).
	/// </summary>
	[JsonProperty("user_id")]
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
	/// Не возвращается, начиная с версии апи 5.81
	/// </summary>
	[JsonProperty("read_state")]
	[Obsolete(ObsoleteText.Obsolete)]
	public MessageReadState? ReadState { get; set; }

	/// <summary>
	/// Заголовок сообщения или беседы.
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Текст сообщения.
	/// </summary>
	[JsonProperty("body")]
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
	[JsonProperty("emoji")]
	public bool? Emoji { get; set; }

	/// <summary>
	/// Является ли сообщение важным.
	/// </summary>
	[JsonProperty("important")]
	public bool? Important { get; set; }

	/// <summary>
	/// Удалено ли сообщение.
	/// </summary>
	[JsonProperty("deleted")]
	public bool? Deleted { get; set; }

	/// <summary>
	/// Идентификатор, используемый при отправке сообщения. Возвращается только для
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
	[JsonProperty("chat_id")]
	public long? ChatId { get; set; }

	/// <summary>
	/// Идентификаторы участников беседы.
	/// </summary>
	[JsonProperty("chat_active")]
	public ReadOnlyCollection<long> ChatActive { get; set; }

	/// <summary>
	/// Настройки уведомлений для беседы, если они есть. sound и disabled_until
	/// </summary>
	[JsonProperty("push_settings")]
	public ChatPushSettings PushSettings { get; set; }

	/// <summary>
	/// Количество участников беседы.
	/// </summary>
	[JsonProperty("users_count")]
	public int? UsersCount { get; set; }

	/// <summary>
	/// Идентификатор создателя беседы.
	/// </summary>
	[JsonProperty("admin_id")]
	public long? AdminId { get; set; }

	/// <summary>
	/// Для служебных сообщений содержит информацию о действии в беседе.
	/// </summary>
	/// <remarks>
	/// Строка, может быть <c>chat_photo_update</c> или <c>chat_photo_remove</c>, а с версии 5.14 еще
	/// и <c>chat_create</c>, <c>chat_title_update</c>,
	/// <c>chat_invite_user</c>, <c>chat_kick_user</c>
	/// </remarks>
	[JsonProperty("action")]
	public MessageActionObject Action { get; set; }

	/// <summary>
	/// Идентификатор пользователя (если больше 0) или email (если меньше 0), которого
	/// пригласили или исключили.
	/// </summary>
	[JsonProperty("action_mid")]
	public long? ActionMid { get; set; }

	/// <summary>
	/// Email, который пригласили или исключили.
	/// </summary>
	[JsonProperty("action_email")]
	public string ActionEmail { get; set; }

	/// <summary>
	/// Название беседы.
	/// </summary>
	[JsonProperty("action_text")]
	public string ActionText { get; set; }

	/// <summary>
	/// <c> Uri </c> копии фотографии беседы шириной 50px.
	/// </summary>
	[JsonProperty("photo_50")]
	public string Photo50 { get; set; }

	/// <summary>
	/// <c> Uri </c> копии фотографии беседы шириной 100px.
	/// </summary>
	[JsonProperty("photo_100")]
	public string Photo100 { get; set; }

	/// <summary>
	/// <c> Uri </c> копии фотографии беседы шириной 200px.
	/// </summary>
	[JsonProperty("photo_200")]
	public string Photo200 { get; set; }

	/// <summary>
	/// Шаблон сообщения
	/// </summary>
	[JsonProperty("template")]
	public MessageTemplate Template { get; set; }

	#endregion

	#region Дополнительные поля в сообщениях сообществ

	/// <summary>
	/// Клавиатура, присланная ботом
	/// </summary>
	[JsonProperty("keyboard")]
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
	/// Идентификатор администратора в беседе
	/// </summary>
	[JsonProperty("admin_author_id")]
	public long? AdminAuthorId { get; set; }

	/// <summary>
	/// Тип сообщения (не возвращается для пересланных сообщений).
	/// </summary>
	[JsonProperty("out")]
	public MessageType? Type { get; set; }

	/// <summary>
	/// Содержит количество непрочитанных сообщений в текущем диалоге (если это
	/// значение было возвращено, иначе 0)
	/// </summary>
	[JsonProperty("unread")]
	public int? Unread { get; set; }

	/// <summary>
	/// Информация о ссылках на предпросмотр фотографий беседы.
	/// </summary>
	[JsonConverter(typeof(PhotoJsonConverter))]
	[JsonProperty("photo_previews")]
	public Previews PhotoPreviews { get; set; }

	/// <summary>
	/// Идентификатор последнего прочитанного сообщения текущим пользователем
	/// </summary>
	[JsonProperty("in_read")]
	public ulong? InRead { get; set; }

	/// <summary>
	/// Идентификатор последнего прочитанного сообщения собеседником
	/// </summary>
	[JsonProperty("out_read")]
	public ulong? OutRead { get; set; }

	/// <summary>
	/// Время последнего редактирования сообщения.
	/// <remarks>
	/// Присутствует только для отредактированных сообщений. Во всех остальных случаях - <c>null</c>
	/// </remarks>
	/// </summary>
	[JsonProperty("update_time")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? UpdateTime { get; set; }

	/// <summary>
	/// Служебное поле, назначение неизвестно
	/// <remarks>
	/// Возможно это поле отвечает за новую фичу ВК - скрытие сообщение с нецензурными выражениями.
	/// TODO @sampletext32
	/// </remarks>
	/// </summary>
	[JsonProperty("is_hidden")]
	public bool IsHidden { get; set; }

	/// <summary>
	/// Время закрепления сообщения
	/// <remarks>
	/// Присутствует только в закреплённых сообщениях. Во всех остальных случаях - <c>null</c>.
	/// </remarks>
	/// </summary>
	[JsonProperty("pinned_at")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? PinnedAt { get; set; }

	/// <summary>
	/// Было ли прослушано голосовое сообщение
	/// <remarks>
	/// Присутствует только в сообщениях с <b>прослушанным</b> <see cref="AudioMessage">голосовым Attachment</see>. Во всех остальных случаях - <c>null</c>.
	/// </remarks>>
	/// </summary>
	[JsonProperty("was_listened")]
	public bool? WasListened { get; set; }

	/// <summary>
	/// Было ли сообщение отправлено с пометкой "Без звука"
	/// </summary>
	[JsonProperty("is_silent")]
	public bool? IsSilent { get; set; }

	/// <summary>
	/// Время жизни саморазрушаемого сообщения
	/// <remarks>
	/// Присутствует только в саморазрушаемых сообщениях. Во всех остальных случаях - <c>null</c>.
	/// </remarks>>
	/// </summary>
	[JsonProperty("expire_ttl")]
	public uint? ExpireTtl { get; set; }

	/// <summary>
	/// Истекло ли время жизни саморазрушаемого сообщения
	/// <remarks>
	/// Присутствует только в <b>истёкших</b> саморазрушаемых сообщениях. Во всех остальных случаях - <c>null</c>.
	/// </remarks>>
	/// </summary>
	[JsonProperty("is_expired")]
	public bool? IsExpired { get; set; }

	#endregion
}