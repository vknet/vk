
namespace VkNet.Enums
{
    /// <summary>
    /// Причина отказа
    /// </summary>
    public enum CancelSubscriptionReason
    {
		/// <summary>
		/// По решению пользователя
		/// </summary>
		UserDecision,
		/// <summary>
		/// По решению приложения
		/// </summary>
		AppDecision,
		/// <summary>
		/// Ошибка оплаты
		/// </summary>
		PaymentFail,
		/// <summary>
		/// Неизвестная причина
		/// </summary>
		Unknown
	}
}
