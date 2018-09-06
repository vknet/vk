namespace VkNet.Enums
{
	/// <summary>
	/// Код ошибки для allowed = false.
	/// </summary>
	public enum CanWriteReason
	{
		/// <summary>
		/// Пользователь заблокирован или удален
		/// </summary>
		UserBannedOrDeleted = 18,

		/// <summary>
		/// Нельзя отправить сообщение пользователю, который в чёрном списке;
		/// </summary>
		BlackListedUser = 900,

		/// <summary>
		/// Пользователь запретил сообщения от сообщества;
		/// </summary>
		LockMessagesFromGroup = 901,

		/// <summary>
		/// Пользователь запретил присылать ему сообщения с помощью настроек приватности;
		/// </summary>
		LockMessagesFromUser = 902,

		/// <summary>
		/// В сообществе отключены сообщения;
		/// </summary>
		GroupMessagesOff = 915,

		/// <summary>
		/// В сообществе заблокированы сообщения;
		/// </summary>
		GroupMessagesLocked = 916,

		/// <summary>
		/// Нет доступа к чату;
		/// </summary>
		ChatAccessDenied = 917,

		/// <summary>
		/// Нет доступа к e-mail;
		/// </summary>
		MailAccessDenied = 918,

		/// <summary>
		/// Нет доступа к сообществу.
		/// </summary>
		GroupAccessDenied = 203
	}
}