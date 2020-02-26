using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип шаблона.
	/// </summary>
	public class TemplateType : SafetyEnum<TemplateType>
	{
		/// <summary>
		/// Карусель
		/// </summary>
		public static readonly TemplateType Carousel = RegisterPossibleValue("carousel");

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator TemplateType(VkResponse response)
		{
			return response != null && response.HasToken()
				? FromJson(response)
				: null;
		}
	}
}