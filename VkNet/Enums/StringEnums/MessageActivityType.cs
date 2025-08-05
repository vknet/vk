using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип актиновсти в диалоге.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum MessageActivityType
{
	/// <summary>
	/// Пользователь начал набирать текст.
	/// </summary>
	Typing,

	/// <summary>
	/// Пользователь записывает голосовое сообщение.
	/// </summary>
	Audiomessage,

	/// <summary>
	/// Пользователь отправляет фото.
	/// </summary>
	Photo,

	/// <summary>
	/// Пользователь отправляет видео.
	/// </summary>
	Video
}