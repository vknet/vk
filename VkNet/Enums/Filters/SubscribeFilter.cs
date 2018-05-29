namespace VkNet.Enums.Filters
{
	/// <summary>
	/// Список типов уведомлений.
	/// </summary>
	public sealed class SubscribeFilter : MultivaluedFilter<SubscribeFilter>
	{
		/// <summary>
		/// Сообщение.
		/// </summary>
		public static readonly SubscribeFilter Message = RegisterPossibleValue(mask: 1 << 0, value: "msg");

		/// <summary>
		/// Друг.
		/// </summary>
		public static readonly SubscribeFilter Friend = RegisterPossibleValue(mask: 1 << 1, value: "friend");

		/// <summary>
		/// Вызов.
		/// </summary>
		public static readonly SubscribeFilter Call = RegisterPossibleValue(mask: 1 << 2, value: "call");

		/// <summary>
		/// Ответ.
		/// </summary>
		public static readonly SubscribeFilter Reply = RegisterPossibleValue(mask: 1 << 3, value: "reply");

		/// <summary>
		/// Упоминание.
		/// </summary>
		public static readonly SubscribeFilter Mention = RegisterPossibleValue(mask: 1 << 4, value: "mention");

		/// <summary>
		/// Группа.
		/// </summary>
		public static readonly SubscribeFilter Group = RegisterPossibleValue(mask: 1 << 5, value: "group");

		/// <summary>
		/// Лайк.
		/// </summary>
		public static readonly SubscribeFilter Like = RegisterPossibleValue(mask: 1 << 6, value: "like");

		/// <summary>
		/// Все.
		/// </summary>
		public static readonly SubscribeFilter All = Message|Friend|Call|Reply|Mention|Group|Like;
	}
}