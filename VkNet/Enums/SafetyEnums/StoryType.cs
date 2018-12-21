using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <inheritdoc />
	public class StoryType : SafetyEnum<StoryType>
	{
		/// <summary>
		/// Фотография
		/// </summary>
		public static readonly StoryType Photo = RegisterPossibleValue("photo");

		/// <summary>
		/// Видеозапись
		/// </summary>
		public static readonly StoryType Video = RegisterPossibleValue("video");

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator StoryType(VkResponse response)
		{
			return response != null && response.HasToken()
				? FromJson(response)
				: null;
		}
	}
}