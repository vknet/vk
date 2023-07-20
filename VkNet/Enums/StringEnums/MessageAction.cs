using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Действия для сообщений
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum MessageAction
{
	/// <summary>
	/// обновлена фотография беседы;
	/// </summary>
	ChatPhotoUpdate,

	/// <summary>
	/// удалена фотография беседы;
	/// </summary>
	ChatPhotoRemove,

	/// <summary>
	/// создана беседа;
	/// </summary>
	ChatCreate,

	/// <summary>
	/// обновлено название беседы;
	/// </summary>
	ChatTitleUpdate,

	/// <summary>
	/// приглашен пользователь;
	/// </summary>
	ChatInviteUser,

	/// <summary>
	/// исключен пользователь.
	/// </summary>
	ChatKickUser,

	/// <summary>
	/// закреплено сообщение;
	/// </summary>
	ChatPinMessage,

	/// <summary>
	/// откреплено сообщение.
	/// </summary>
	ChatUnpinMessage,

	/// <summary>
	/// пользователь присоединился к беседе по ссылке.
	/// </summary>
	ChatInviteUserByLink
}