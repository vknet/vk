namespace VkNet.Enums
{
	/// <summary>
	/// Уровень доступа для взаимодействия со страницей.
	/// </summary>
	public enum AccessPages
	{
		/// <summary>
		/// Только руководители сообщества.
		/// </summary>
		Leaders = 0

		, /// <summary>
		/// Только участники сообщества.
		/// </summary>
		Participants

		, /// <summary>
		/// Все пользователи.
		/// </summary>
		All
	}
}