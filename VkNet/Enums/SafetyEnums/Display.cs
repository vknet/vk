namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Возможные значения параметра display, задающего внешний вид окна авторизации.
	/// </summary>
	public sealed class Display : SafetyEnum<Display>
	{
		/// <summary>
		/// Форма авторизации в отдельном окне;
		/// </summary>
		public static readonly Display Page = RegisterPossibleValue(value: "page");

		/// <summary>
		/// Всплывающее окно.
		/// </summary>
		public static readonly Display Popup = RegisterPossibleValue(value: "popup");

		/// <summary>
		/// Для мобильных устройств.
		/// </summary>
		public static readonly Display Mobile = RegisterPossibleValue(value: "mobile");
	}
}