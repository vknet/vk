using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Является опциональным и содержит следующие данные в зависимости от значения
/// поля type:
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum PostSourceData
{
	/// <summary>
	/// Изменение статуса под именем пользователя.
	/// </summary>
	ProfileActivity,

	/// <summary>
	/// Изменение профильной фотографии пользователя.
	/// </summary>
	ProfilePhoto,

	/// <summary>
	/// Виджет комментариев.
	/// </summary>
	Comments,

	/// <summary>
	/// Виджет «Мне нравится».
	/// </summary>
	Like,

	/// <summary>
	/// Виджет опросов.
	/// </summary>
	Poll
}