using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Падеж.
/// </summary>
public sealed class NameCase : SafetyEnum<NameCase>
{
	/// <summary>
	/// Именительный.
	/// </summary>
	[EnumMember(Value = "nom")]
	public static readonly NameCase Nom = RegisterPossibleValue(value: "nom");

	/// <summary>
	/// Родительный.
	/// </summary>
	[EnumMember(Value = "gen")]
	public static readonly NameCase Gen = RegisterPossibleValue(value: "gen");

	/// <summary>
	/// Дательный.
	/// </summary>
	[EnumMember(Value = "dat")]
	public static readonly NameCase Dat = RegisterPossibleValue(value: "dat");

	/// <summary>
	/// Винительный.
	/// </summary>
	[EnumMember(Value = "acc")]
	public static readonly NameCase Acc = RegisterPossibleValue(value: "acc");

	/// <summary>
	/// Творительный.
	/// </summary>
	[EnumMember(Value = "ins")]
	public static readonly NameCase Ins = RegisterPossibleValue(value: "ins");

	/// <summary>
	/// Предложный.
	/// </summary>
	[EnumMember(Value = "abl")]
	public static readonly NameCase Abl = RegisterPossibleValue(value: "abl");
}