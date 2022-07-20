using System;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Метка, которая обозначает приблизительное содержание сообщения от сообщества
	/// </summary>
	[Serializable]
	public sealed class Intent : SafetyEnum<Intent>
	{
		/// <summary>
		/// Для рекламной рассылки от ботов.
		/// </summary>
		public static readonly Intent PromoNewsletter = RegisterPossibleValue(value: "promo_newsletter");

		/// <summary>
		/// Рекламный API / монетизация.
		/// </summary>
		public static readonly Intent BotAdInvite = RegisterPossibleValue(value: "bot_ad_invite");

		/// <summary>
		/// Рекламный API / монетизация.
		/// </summary>
		public static readonly Intent BotAdPromo = RegisterPossibleValue(value: "bot_ad_promo");

		/// <summary>
		/// Информационные рассылки.
		/// </summary>
		public static readonly Intent NonPromoNewsLetter = RegisterPossibleValue(value: "non_promo_newsletter");

		/// <summary>
		/// Любые уведомления о событиях или действиях, на которые пользователь дал согласие.
		/// </summary>
		public static readonly Intent ConfirmedNotification = RegisterPossibleValue(value: "confirmed_notification");

		/// <summary>
		/// Обновления/уведомления о покупке, сделанной пользователем.
		/// </summary>
		public static readonly Intent PurchaseUpdate = RegisterPossibleValue(value: "purchase_update");

		/// <summary>
		/// Нерегулярные обновления /уведомления, связанные с аккаунтом или приложением.
		/// </summary>
		public static readonly Intent AccountUpdate = RegisterPossibleValue(value: "account_update");

		/// <summary>
		/// Уведомления от игр; ретеншен-сообщения; уведомления, связанные с дейтингом, и т. д.
		/// </summary>
		public static readonly Intent GameNotification = RegisterPossibleValue(value: "game_notification");

		/// <summary>
		/// Ответы сотрудников поддержки сервиса на запросы пользователя.
		/// </summary>
		public static readonly Intent CustomerSupport = RegisterPossibleValue(value: "customer_support");

		/// <summary>
		/// Стандартный интент, подставляется автоматически если не указан другой.
		/// </summary>
		public static readonly Intent Default = RegisterPossibleValue(value: "default");

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator Intent(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken() ? FromJson(response) : null;
		}
	}
}