using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип жалобы.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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