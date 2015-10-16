using VkNet.Enums.SafetyEnums;

namespace VkNet.Enums
{
	/// <summary>
	/// Тип запроса для приложений
	/// </summary>
	public sealed class AppRequestType : SafetyEnum<AppRequestType>
	{
		/// <summary>
		/// В случае если запрос отправляется пользователю, не установившему приложение
		/// </summary>
		public static readonly AppRequestType Invite = RegisterPossibleValue("invite");
		/// <summary>
		/// В случае если пользователь уже установил приложение 
		/// </summary>
		public static readonly AppRequestType Request = RegisterPossibleValue("request");
	}
}