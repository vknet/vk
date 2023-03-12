using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип жалобы.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum ReportType
{
	/// <summary>
	/// Порнография.
	/// </summary>
	Porn,

	/// <summary>
	/// Рассылка спама.
	/// </summary>
	Spam,

	/// <summary>
	/// Оскорбительное поведение.
	/// </summary>
	Insult,

	/// <summary>
	/// Рекламная страница, засоряющая поиск.
	/// </summary>
	Advertisment
}