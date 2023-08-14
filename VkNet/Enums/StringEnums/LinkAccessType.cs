using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Возвращает информацию о том, является ли внешняя ссылка заблокированной на
/// сайте ВКонтакте.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum LinkAccessType
{
	/// <summary>
	/// Cсылка не заблокирована
	/// </summary>
	NotBanned,

	/// <summary>
	/// Cсылка заблокирована
	/// </summary>
	Banned,

	/// <summary>
	/// Cсылка проверяется; необходимо выполнить повторный запрос через несколько
	/// секунд
	/// </summary>
	Processing
}