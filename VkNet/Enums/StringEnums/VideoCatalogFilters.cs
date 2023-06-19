using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Фильтры для видео каталога
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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