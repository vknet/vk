namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Метка, которая обозначает приблизительное содержание сообщения от сообщества
	/// </summary>
	public sealed class Intent : SafetyEnum<Intent>
	{
		/// <summary>
		/// Интент, который должен сопровождать рекламную рассылку для ботов.
		/// </summary>
		public static readonly Intent PromoNewsletter = RegisterPossibleValue(value: "promo_newsletter");
	}
}
