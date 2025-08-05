using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Фильтр для задания типов сообщений, которые необходимо получить со стены.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum WallFilter
{
	/// <summary>
	/// Необходимо получить сообщения на стене только от ее владельца.
	/// </summary>
	Owner,

	/// <summary>
	/// Необходимо получить сообщения на стене не от владельца стены.
	/// </summary>
	Others,

	/// <summary>
	/// Необходимо получить все сообщения на стене (Owner + Others).
	/// </summary>
	[VkNetDefaultValue]
	All,

	/// <summary>
	/// Предложенные записи на стене сообщества
	/// </summary>
	Suggests,

	/// <summary>
	/// Отложенные записи
	/// </summary>
	Postponed
}