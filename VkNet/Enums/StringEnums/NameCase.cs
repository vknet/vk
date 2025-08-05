using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Падеж.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum NameCase
{
	/// <summary>
	/// Именительный.
	/// </summary>
	Nom,

	/// <summary>
	/// Родительный.
	/// </summary>
	Gen,

	/// <summary>
	/// Дательный.
	/// </summary>
	Dat,

	/// <summary>
	/// Винительный.
	/// </summary>
	Acc,

	/// <summary>
	/// Творительный.
	/// </summary>
	Ins,

	/// <summary>
	/// Предложный.
	/// </summary>
	Abl
}