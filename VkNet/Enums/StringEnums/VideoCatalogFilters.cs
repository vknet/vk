using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Фильтры для видео каталога
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum VideoCatalogFilters
{
	/// <summary>
	/// Видео из ленты новостей пользователя
	/// </summary>
	Feed,

	/// <summary>
	/// популярное
	/// </summary>
	Ugc,

	/// <summary>
	/// выбор редакции
	/// </summary>
	Top,

	/// <summary>
	/// сериалы и телешоу
	/// </summary>
	Series,

	/// <summary>
	/// прочие блоки
	/// </summary>
	Other
}