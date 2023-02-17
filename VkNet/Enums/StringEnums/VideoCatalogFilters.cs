using System.Runtime.Serialization;

namespace VkNet.Enums;

/// <summary>
/// Фильтры для видео каталога
/// </summary>
public enum VideoCatalogFilters
{
	/// <summary>
	/// Видео из ленты новостей пользователя
	/// </summary>
	[EnumMember(Value = "feed")]
	Feed,

	/// <summary>
	/// популярное
	/// </summary>
	[EnumMember(Value = "ugc")]
	Ugc,

	/// <summary>
	/// выбор редакции
	/// </summary>
	[EnumMember(Value = "top")]
	Top,

	/// <summary>
	/// сериалы и телешоу
	/// </summary>
	[EnumMember(Value = "series")]
	Series,

	/// <summary>
	/// прочие блоки
	/// </summary>
	[EnumMember(Value = "other")]
	Other
}