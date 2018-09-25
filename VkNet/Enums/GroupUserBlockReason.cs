namespace VkNet.Enums
{
	/// <summary>
	/// Причина блокировки пользователя
	/// </summary>
	public enum GroupUserBlockReason
	{
		/// <summary>
		/// Другое
		/// </summary>
		Other,

		/// <summary>
		/// Спам
		/// </summary>
		Spam,

		/// <summary>
		/// Оскорбление участников
		/// </summary>
		InsultingParticipants,

		/// <summary>
		/// Нецензурные выражения
		/// </summary>
		ObsceneExpressions,

		/// <summary>
		/// Сообщения не по теме
		/// </summary>
		MessagesOffTopic
	}
}