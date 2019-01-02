namespace VkNet.Utils
{
	/// <summary>
	/// Тексты для атрибута Obsolete
	/// </summary>
	public static class ObsoleteText
	{
		/// <summary>
		/// Параметры для капчи устаревшие.
		/// Необходимо реализовать интефейс ICapthaSolver и внедрить через констуктор.
		/// </summary>
		public const string CaptchaNeeded = "Использование параметров капчи устаревший метод взаимодействия с Captcha."
											+ " Необходимо реализовать интефейс ICapthaSolver и внедрить через констуктор."
											+ " Данный параметр будет удален в версии 2.0.0";

		/// <summary>
		/// Stats.Get
		/// </summary>
		public const string StatsGet = "Устаревший параметр, доступен только для версий меньше 5.86";

		/// <summary>
		/// Stats.Get
		/// </summary>
		public const string Validate = "Данный метод устарел, используйте перегрузку void Validate(string validateUrl);";

		/// <summary>
		/// Messages.GetConversations
		/// </summary>
		public const string MessageGet =
			"Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования. Используйте вместо него GetConversations";

		/// <summary>
		/// Messages.SearchConversations
		/// </summary>
		public const string MessageSearchDialogs =
			"Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования. Используйте вместо него SearchConversations";

		/// <summary>
		/// Messages.MessageMarkAsImportantDialog
		/// </summary>
		public const string MessageMarkAsImportantDialog =
			"Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования. Используйте вместо него MarkAsImportantConversation";

		/// <summary>
		/// Messages.MarkAsAnsweredDialog
		/// </summary>
		public const string MessageMarkAsAnsweredDialog =
			"Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования. Используйте вместо него MarkAsAnsweredConversation";

		/// <summary>
		/// Messages.DeleteConversation
		/// </summary>
		public const string MessageDeleteDialog =
			"Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования. Используйте вместо него DeleteConversation";

		/// <summary>
		/// Messages.DeleteConversation
		/// </summary>
		public const string MessageGetChatUsers =
			"Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования. Используйте вместо него GetConversationMembers";

		/// <summary>
		/// Messages.DeleteConversation
		/// </summary>
		public const string MessageGetById =
			"Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования."
			+ " Используйте вместо него GetById(IEnumerable<ulong> messageIds, IEnumerable<string> fields, ulong? previewLength = null, bool? extended = null, ulong? groupId = null)";
	}
}