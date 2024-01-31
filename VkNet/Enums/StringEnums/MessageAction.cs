using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Действия для сообщений
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum MessageAction
{
	/// <summary>
	/// Обновлена фотография беседы;
	/// </summary>
	ChatPhotoUpdate,

	/// <summary>
	/// Удалена фотография беседы;
	/// </summary>
	ChatPhotoRemove,

	/// <summary>
	/// Создана беседа;
	/// </summary>
	ChatCreate,

	/// <summary>
	/// Обновлено название беседы;
	/// </summary>
	ChatTitleUpdate,

	/// <summary>
	/// Приглашен пользователь;
	/// </summary>
	ChatInviteUser,

	/// <summary>
	/// Исключен пользователь.
	/// </summary>
	ChatKickUser,

	/// <summary>
	/// Закреплено сообщение;
	/// </summary>
	ChatPinMessage,

	/// <summary>
	/// Откреплено сообщение.
	/// </summary>
	ChatUnpinMessage,

	/// <summary>
	/// Пользователь присоединился к беседе по ссылке.
	/// </summary>
	ChatInviteUserByLink,

	/// <summary>
	/// Обновление оформления беседы
	/// </summary>
	ConversationStyleUpdate,

	/// <summary>
	/// Скриншот чата
	/// </summary>
	ChatScreenshot,

	/// <summary>
	/// Пригласить пользователя в чат по запросу сообщения
	/// </summary>
	ChatInviteUserByMessageRequest
}