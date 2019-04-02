namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип ответа, который необходимо получить.
	/// </summary>
	public class ResponseType : SafetyEnum<ResponseType>
	{
		/// <summary>
		/// Токен.
		/// </summary>
		public static readonly ResponseType Token = RegisterPossibleValue("token");

		/// <summary>
		/// Код.
		/// </summary>
		public static readonly ResponseType Сode = RegisterPossibleValue("code");
	}
}