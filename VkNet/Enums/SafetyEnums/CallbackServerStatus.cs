using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Статус сервера
	/// </summary>
	public class CallbackServerStatus : SafetyEnum<CallbackServerStatus>
	{
		/// <summary>
		/// Адрес не задан;
		/// </summary>
		[DefaultValue]
		public static readonly CallbackServerStatus Unconfigured = RegisterPossibleValue(value: "unconfigured");

		/// <summary>
		/// Подтвердить адрес не удалось
		/// </summary>
		public static readonly CallbackServerStatus Fail = RegisterPossibleValue(value: "fail");

		/// <summary>
		/// Адрес ожидает подтверждения
		/// </summary>
		public static readonly CallbackServerStatus Wait = RegisterPossibleValue(value: "wait");

		/// <summary>
		/// Сервер подключен
		/// </summary>
		public static readonly CallbackServerStatus Ok = RegisterPossibleValue(value: "ok");
	}
}