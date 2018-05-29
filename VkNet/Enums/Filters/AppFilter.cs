using VkNet.Enums.SafetyEnums;

namespace VkNet.Enums.Filters
{
	/// <summary>
	/// Тип фильтрации для приложений.
	/// </summary>
	public sealed class AppFilter : SafetyEnum<AppFilter>
	{
		/// <summary>
		/// Возвращает список установленных приложений (только для мобильных приложений),
		/// </summary>
		public static readonly AppFilter Installed = RegisterPossibleValue(value: "installed");

		/// <summary>
		/// Возвращает список приложений, установленных в "Выбор редакции" (только для
		/// мобильных приложений)
		/// </summary>
		public static readonly AppFilter Featured = RegisterPossibleValue(value: "featured");
	}
}