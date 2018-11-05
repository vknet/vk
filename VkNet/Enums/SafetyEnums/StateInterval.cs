using System;
using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Единица времени для подсчета статистики.
	/// </summary>
	[Serializable]
	[JsonConverter(typeof(SafetyEnumJsonConverter))]
	public class StateInterval : SafetyEnum<StateInterval>
	{
		/// <summary>
		/// День
		/// </summary>
		[DefaultValue]
		public static readonly StateInterval Day = RegisterPossibleValue("day");

		/// <summary>
		/// Неделя
		/// </summary>
		public static readonly StateInterval Week = RegisterPossibleValue("week");

		/// <summary>
		/// Месяц
		/// </summary>
		public static readonly StateInterval Month = RegisterPossibleValue("month");

		/// <summary>
		/// Все время с момента создания ссылки
		/// </summary>
		public static readonly StateInterval Year = RegisterPossibleValue("year");

		/// <summary>
		/// Все время с момента создания ссылки
		/// </summary>
		public static readonly StateInterval All = RegisterPossibleValue("all");
	}
}