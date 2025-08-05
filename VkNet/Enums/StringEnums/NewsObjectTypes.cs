using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Названия списков новостей, которые необходимо получить.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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