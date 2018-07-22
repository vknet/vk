namespace VkNet.Enums
{
	/// <summary>
	/// Cтатус модерации объявления.
	/// </summary>
	public enum ModerationStatus
	{
		/// <summary>
		/// Объявление не проходило модерацию
		/// </summary>
		NotModerated = 0,

		/// <summary>
		/// Объявление ожидает модерации
		/// </summary>
		Waiting,

		/// <summary>
		/// Объявление одобрено
		/// </summary>
		Approved,

		/// <summary>
		/// Объявление отклонено
		/// </summary>
		Rejected
	}
}