using System.Runtime.Serialization;

namespace VkNet.Enums;

/// <summary>
/// Тип шаблона.
/// </summary>
public enum TemplateType
{
	/// <summary>
	/// Карусель
	/// </summary>
	[EnumMember(Value = "carousel")]
	Carousel
}