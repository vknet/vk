using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип актиновсти в диалоге.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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