using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Месячные ограничения
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(LowerCaseWithDigitNamingStrategy))]
public enum MonthlyLimit
{
	/// <summary>
	/// 1 месяц.
	/// </summary>
	Tier1,

	/// <summary>
	/// 2 месяца.
	/// </summary>
	Tier2,

	/// <summary>
	/// 3 месяца.
	/// </summary>
	Tier3,

	/// <summary>
	/// 4 месяца.
	/// </summary>
	Tier4,

	/// <summary>
	/// 5 месяцев.
	/// </summary>
	Tier5,

	/// <summary>
	/// 6 месяцев.
	/// </summary>
	Tier6,

	/// <summary>
	/// Безлимитный доступ.
	/// </summary>
	Unlimited
}