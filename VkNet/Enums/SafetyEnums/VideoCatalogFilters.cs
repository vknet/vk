using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Фильтры для видео каталога
/// </summary>
public class VideoCatalogFilters : SafetyEnum<VideoCatalogFilters>
{
	/// <summary>
	/// Видео из ленты новостей пользователя
	/// </summary>
	[EnumMember(Value = "feed")]
	public static readonly VideoCatalogFilters Feed = RegisterPossibleValue(value: "feed");

	/// <summary>
	/// популярное
	/// </summary>
	[EnumMember(Value = "ugc")]
	public static readonly VideoCatalogFilters Ugc = RegisterPossibleValue(value: "ugc");

	/// <summary>
	/// выбор редакции
	/// </summary>
	[EnumMember(Value = "top")]
	public static readonly VideoCatalogFilters Top = RegisterPossibleValue(value: "top");

	/// <summary>
	/// сериалы и телешоу
	/// </summary>
	[EnumMember(Value = "series")]
	public static readonly VideoCatalogFilters Series = RegisterPossibleValue(value: "series");

	/// <summary>
	/// прочие блоки
	/// </summary>
	[EnumMember(Value = "other")]
	public static readonly VideoCatalogFilters Other = RegisterPossibleValue(value: "other");
}