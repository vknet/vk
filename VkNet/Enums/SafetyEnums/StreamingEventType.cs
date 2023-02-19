using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums;

/// <summary>
/// Тип событий
/// </summary>
[Serializable]
public enum StreamingEventType
{
	/// <summary>
	/// Записи на стене;
	/// </summary>
	[EnumMember(Value = "post")]
	Post,

	/// <summary>
	/// Комментарии;
	/// </summary>
	[EnumMember(Value = "comment")]
	Comment,

	/// <summary>
	/// Репосты;
	/// </summary>
	[EnumMember(Value = "share")]
	Share
}