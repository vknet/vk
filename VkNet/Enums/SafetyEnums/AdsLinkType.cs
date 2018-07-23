using JetBrains.Annotations;

namespace VkNet.Enums.SafetyEnums
{
	/// <inheritdoc />
	[UsedImplicitly]
	public class AdsLinkType : SafetyEnum<AdsLinkType>
	{
		/// <summary>
		/// Сообщество
		/// </summary>
		public static readonly AdsLinkType Community = RegisterPossibleValue(value: "community");

		/// <summary>
		/// Запись в сообществе;
		/// </summary>
		public static readonly AdsLinkType Post = RegisterPossibleValue(value: "post");

		/// <summary>
		/// Приложение ВКонтакте;
		/// </summary>
		public static readonly AdsLinkType Application = RegisterPossibleValue(value: "application");

		/// <summary>
		/// Видеозапись;
		/// </summary>
		public static readonly AdsLinkType Video = RegisterPossibleValue(value: "video");

		/// <summary>
		/// Внешний сайт.
		/// </summary>
		public static readonly AdsLinkType Site = RegisterPossibleValue(value: "site");
	}
}