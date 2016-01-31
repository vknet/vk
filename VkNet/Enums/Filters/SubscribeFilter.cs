using VkNet.Utils;

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
		public static readonly SubscribeFilter Message = RegisterPossibleValue(1 << 0, "msg");

		/// <summary>
		/// Друг.
		/// </summary>
		public static readonly SubscribeFilter Friend = RegisterPossibleValue(1 << 1, "friend");

		/// <summary>
		/// Вызов.
		/// </summary>
		public static readonly SubscribeFilter Call = RegisterPossibleValue(1 << 2, "call");

		/// <summary>
		/// Ответ.
		/// </summary>
		public static readonly SubscribeFilter Reply = RegisterPossibleValue(1 << 3, "reply");

		/// <summary>
		/// Упоминание.
		/// </summary>
		public static readonly SubscribeFilter Mention = RegisterPossibleValue(1 << 4, "mention");

		/// <summary>
		/// Группа.
		/// </summary>
		public static readonly SubscribeFilter Group = RegisterPossibleValue(1 << 5, "group");

		/// <summary>
		/// Лайк.
		/// </summary>
		public static readonly SubscribeFilter Like = RegisterPossibleValue(1 << 6, "like");

		/// <summary>
		/// Все.
		/// </summary>
		public static readonly SubscribeFilter All = Message | Friend | Call | Reply | Mention | Group | Like;



	}
}