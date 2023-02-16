using System;
using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип фона опроса.
/// </summary>
[Serializable]
public class PollBackgroundType : SafetyEnum<PollBackgroundType>
{
	/// <summary>
	/// Gradient.
	/// </summary>
	[EnumMember(Value = "gradient")]
	public static readonly PollBackgroundType Gradient = RegisterPossibleValue("gradient");

	/// <summary>
	/// tile.
	/// </summary>
	[EnumMember(Value = "tile")]
	public static readonly PollBackgroundType Tile = RegisterPossibleValue("tile");
}