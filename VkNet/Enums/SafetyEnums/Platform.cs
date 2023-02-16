using System;
using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// </summary>
[Serializable]
public class Platform : SafetyEnum<Platform>
{
	/// <summary>
	/// Android.
	/// </summary>
	[EnumMember(Value = "android")]
	public static readonly Platform Android = RegisterPossibleValue(value: "android");

	/// <summary>
	/// iPhone.
	/// </summary>
	[EnumMember(Value = "iphone")]

	// ReSharper disable once InconsistentNaming
	public static readonly Platform IPhone = RegisterPossibleValue(value: "iphone");

	/// <summary>
	/// wphone.
	/// </summary>
	[EnumMember(Value = "wphone")]
	public static readonly Platform WindowsPhone = RegisterPossibleValue(value: "wphone");
}