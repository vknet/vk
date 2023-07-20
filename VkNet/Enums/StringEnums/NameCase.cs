using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Падеж.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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