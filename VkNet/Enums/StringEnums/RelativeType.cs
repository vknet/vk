using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип родственных связей.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum RelativeType
{
	/// <summary>
	/// Брат/Сестра.
	/// </summary>
	Sibling,

	/// <summary>
	/// Родитель.
	/// </summary>
	Parent,

	/// <summary>
	/// Ребенок.
	/// </summary>
	Child,

	/// <summary>
	/// Дедушка/Бабушка.
	/// </summary>
	Grandparent,

	/// <summary>
	/// Внук.
	/// </summary>
	Grandchild
}