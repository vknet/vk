using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип источника исходной аудитории.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum SourceType
{
	/// <summary>
	/// Аудитория ретаргетинга
	/// </summary>
	RetargetingGroup
}