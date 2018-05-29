using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Единица времени для подсчета статистики.
	/// </summary>
	public class LinkStatInterval : SafetyEnum<LinkStatInterval>
	{
		/// <summary>
		/// Час
		/// </summary>
		public static readonly LinkStatInterval Hour = RegisterPossibleValue(value: "hour");

		/// <summary>
		/// День
		/// </summary>
		[DefaultValue]
		public static readonly LinkStatInterval Day = RegisterPossibleValue(value: "day");

		/// <summary>
		/// Неделя
		/// </summary>
		public static readonly LinkStatInterval Week = RegisterPossibleValue(value: "week");

		/// <summary>
		/// Месяц
		/// </summary>
		public static readonly LinkStatInterval Month = RegisterPossibleValue(value: "month");

		/// <summary>
		/// Все время с момента создания ссылки
		/// </summary>
		public static readonly LinkStatInterval Forever = RegisterPossibleValue(value: "forever");
	}
}