using System;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Метка, которая обозначает приблизительное содержание сообщения от сообщества
	/// </summary>
	[Serializable]
	public sealed class Intent : SafetyEnum<Intent>
	{
		/// <summary>
		/// Интент, который должен сопровождать рекламную рассылку для ботов.
		/// </summary>
		public static readonly Intent PromoNewsletter = RegisterPossibleValue(value: "promo_newsletter");

		/// <summary>
		/// Интент, который должен сопровождать сообщения, запрашивающее подтверждение пользователя на отправку этому пользователю рекламы.
		/// </summary>
		public static readonly Intent BotAdInvite = RegisterPossibleValue(value: "bot_ad_invite");

		/// <summary>
		/// Интент, который должен сопровождать сообщение содержащее рекламу от бота.
		/// </summary>
		public static readonly Intent BotAdPromo = RegisterPossibleValue(value: "bot_ad_promo");
	}
}