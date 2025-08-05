using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип родственных связей.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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