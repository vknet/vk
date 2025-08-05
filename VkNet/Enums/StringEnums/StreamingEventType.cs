using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип событий
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum StreamingEventType
{
	/// <summary>
	/// Записи на стене;
	/// </summary>
	Post,

	/// <summary>
	/// Комментарии;
	/// </summary>
	Comment,

	/// <summary>
	/// Репосты;
	/// </summary>
	Share
}