using System;
using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Доступность значения.
/// </summary>
[Serializable]
public sealed class StoryObjectState : SafetyEnum<StoryObjectState>
{
	/// <summary>
	/// Доступно.
	/// </summary>
	[EnumMember(Value = "on")]
	public static readonly StoryObjectState On = RegisterPossibleValue("on");

	/// <summary>
	/// Недоступно.
	/// </summary>
	[EnumMember(Value = "off")]
	public static readonly StoryObjectState Off = RegisterPossibleValue("off");

	/// <summary>
	/// Недоступно.
	/// </summary>
	[EnumMember(Value = "hidden")]
	public static readonly StoryObjectState Hidden = RegisterPossibleValue("hidden");
}