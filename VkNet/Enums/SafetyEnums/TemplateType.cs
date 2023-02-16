using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип шаблона.
/// </summary>
public class TemplateType : SafetyEnum<TemplateType>
{
	/// <summary>
	/// Карусель
	/// </summary>
	[EnumMember(Value = "carousel")]
	public static readonly TemplateType Carousel = RegisterPossibleValue("carousel");

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator TemplateType(VkResponse response) => response != null && response.HasToken()
		? FromJson(response)
		: null;
}