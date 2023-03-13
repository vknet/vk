using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип рекламного кабинета.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum CampaignType
{
	/// <summary>
	/// Обычная кампания, в которой можно создавать любые объявления, кроме мобильной
	/// рекламы и записей в сообществе
	/// </summary>
	Normal,

	/// <summary>
	/// Кампания, в которой можно рекламировать только администрируемые Вами приложения
	/// и у которой есть отдельный бюджет
	/// </summary>
	VkAppsManaged,

	/// <summary>
	/// Кампания, в которой можно рекламировать только мобильные приложения
	/// </summary>
	MobileApps,

	/// <summary>
	/// Кампания, в которой можно рекламировать только записи в сообществе
	/// </summary>
	PromotedPosts
}