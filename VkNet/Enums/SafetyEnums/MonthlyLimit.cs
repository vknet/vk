using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums
{
	/// <inheritdoc />
	/// <summary>
	/// Месячные ограничения
	/// </summary>
	[Serializable]
	[JsonConverter(converterType: typeof(SafetyEnumJsonConverter))]
	public class MonthlyLimit : SafetyEnum<MonthlyLimit>
	{
		/// <summary>
		/// 1 месяц.
		/// </summary>
		public static readonly MonthlyLimit Tier1 = RegisterPossibleValue(value: "tier_1");

		/// <summary>
		/// 2 месяца.
		/// </summary>
		public static readonly MonthlyLimit Tier2 = RegisterPossibleValue(value: "tier_2");

		/// <summary>
		/// 3 месяца.
		/// </summary>
		public static readonly MonthlyLimit Tier3 = RegisterPossibleValue(value: "tier_3");

		/// <summary>
		/// 4 месяца.
		/// </summary>
		public static readonly MonthlyLimit Tier4 = RegisterPossibleValue(value: "tier_4");

		/// <summary>
		/// 5 месяцев.
		/// </summary>
		public static readonly MonthlyLimit Tier5 = RegisterPossibleValue(value: "tier_5");

		/// <summary>
		/// 6 месяцев.
		/// </summary>
		public static readonly MonthlyLimit Tier6 = RegisterPossibleValue(value: "tier_6");

		/// <summary>
		/// Безлимитный доступ.
		/// </summary>
		public static readonly MonthlyLimit Unlimited = RegisterPossibleValue(value: "unlimited");
	}
}