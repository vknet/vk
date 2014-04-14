using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Список типов уведомлений.
	/// </summary>
	public class SubscribeFilter : VkFilter
	{

		public static readonly SubscribeFilter Message = new SubscribeFilter(1 << 0, "msg");
		public static readonly SubscribeFilter Friend = new SubscribeFilter(1 << 1, "friend");
		public static readonly SubscribeFilter Call = new SubscribeFilter(1 << 2, "call");
		public static readonly SubscribeFilter Reply = new SubscribeFilter(1 << 3, "reply");
		public static readonly SubscribeFilter Mention = new SubscribeFilter(1 << 4, "mention");
		public static readonly SubscribeFilter Group = new SubscribeFilter(1 << 5, "group");
		public static readonly SubscribeFilter Like = new SubscribeFilter(1 << 6, "like");
		public static readonly SubscribeFilter All = Message | Friend | Call | Reply | Mention | Group | Like;

		
		
		private SubscribeFilter(long value, string name) : base(value, name)
		{
		}

		private SubscribeFilter(VkFilter left, VkFilter right) : base(left, right)
		{
		}

		/// <summary>
		/// Оператор объединения полей профиля.
		/// </summary>
		/// <param name="left">Левое поле выражения объединения.</param>
		/// <param name="right">Правое поле выражения объединения.</param>
		/// <returns>Результат объединения.</returns>
		public static SubscribeFilter operator |(SubscribeFilter left, SubscribeFilter right)
		{
			return new SubscribeFilter(left, right);
		}

	}
}