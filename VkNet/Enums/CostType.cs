namespace VkNet.Enums
{
	/// <summary>
	/// Тип оплаты
	/// </summary>
	public enum CostType
	{
		/// <summary>
		/// Оплата за переходы
		/// </summary>
		Cpc = 0,

		/// <summary>
		/// Оплата за показы
		/// </summary>
		Cpm = 1,

		/// <summary>
		/// Отправка заявок
		/// </summary>
		OCpm = 3
	}
}