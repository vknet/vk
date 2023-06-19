using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Фильтр для задания типов сообщений, которые необходимо получить со стены.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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