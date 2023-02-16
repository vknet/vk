using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Источник контента.
/// </summary>
[Serializable]
[JsonConverter(typeof(SafetyEnumJsonConverter))]
public class MessageContentSourceType : SafetyEnum<MessageContentSourceType>
{
	/// <summary>
	/// Сообщение
	/// </summary>
	[EnumMember(Value = "message")]
	public static readonly MessageContentSourceType Message = RegisterPossibleValue("message");

	/// <summary>
	/// Ссылка
	/// </summary>
	[EnumMember(Value = "url")]
	public static readonly MessageContentSourceType Url = RegisterPossibleValue("url");
}