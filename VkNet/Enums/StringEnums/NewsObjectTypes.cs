using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Названия списков новостей, которые необходимо получить.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum NewsObjectTypes
{
	/// <summary>
	/// Запись на стене.
	/// </summary>
	Wall,

	/// <summary>
	/// Отметка на фотографии.
	/// </summary>
	Tag,

	/// <summary>
	/// Фотография профиля.
	/// </summary>
	Profilephoto,

	/// <summary>
	/// Видеозапись.
	/// </summary>
	Video,

	/// <summary>
	/// Фотография.
	/// </summary>
	Photo,

	/// <summary>
	/// Аудиозапись.
	/// </summary>
	Audio
}