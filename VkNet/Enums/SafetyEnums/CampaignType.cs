namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип рекламного кабинета.
	/// </summary>
	public sealed class CampaignType : SafetyEnum<CampaignType>
	{
		/// <summary>
		/// Обычная кампания, в которой можно создавать любые объявления, кроме мобильной
		/// рекламы и записей в сообществе
		/// </summary>
		public static readonly CampaignType Normal = RegisterPossibleValue(value: "normal");

		/// <summary>
		/// Кампания, в которой можно рекламировать только администрируемые Вами приложения
		/// и у которой есть отдельный бюджет
		/// </summary>
		public static readonly CampaignType VkAppsManaged = RegisterPossibleValue(value: "vk_apps_managed");

		/// <summary>
		/// Кампания, в которой можно рекламировать только мобильные приложения
		/// </summary>
		public static readonly CampaignType MobileApps = RegisterPossibleValue(value: "mobile_apps");

		/// <summary>
		/// Кампания, в которой можно рекламировать только записи в сообществе
		/// </summary>
		public static readonly CampaignType PromotedPosts = RegisterPossibleValue(value: "promoted_posts");
	}
}