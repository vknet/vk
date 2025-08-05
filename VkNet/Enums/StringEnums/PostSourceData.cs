using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Является опциональным и содержит следующие данные в зависимости от значения
/// поля type:
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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