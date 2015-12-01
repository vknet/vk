using VkNet.Utils;

namespace VkNet.Enums.Filters
{
	/// <summary>
	/// Список типов уведомлений.
	/// </summary>
	public sealed class SubscribeFilter : MultivaluedFilter<SubscribeFilter>
	{

		public static readonly SubscribeFilter Message = RegisterPossibleValue(1 << 0, "msg");
		public static readonly SubscribeFilter Friend = RegisterPossibleValue(1 << 1, "friend");
		public static readonly SubscribeFilter Call = RegisterPossibleValue(1 << 2, "call");
		public static readonly SubscribeFilter Reply = RegisterPossibleValue(1 << 3, "reply");
		public static readonly SubscribeFilter Mention = RegisterPossibleValue(1 << 4, "mention");
		public static readonly SubscribeFilter Group = RegisterPossibleValue(1 << 5, "group");
		public static readonly SubscribeFilter Like = RegisterPossibleValue(1 << 6, "like");
		public static readonly SubscribeFilter All = Message | Friend | Call | Reply | Mention | Group | Like;



	}
}