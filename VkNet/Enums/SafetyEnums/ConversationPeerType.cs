using System;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип пира беседы
	/// </summary>
	[Serializable]
	public class ConversationPeerType : SafetyEnum<ConversationPeerType>
	{
		/// <summary>
		/// Пользователь.
		/// </summary>
		public static readonly ConversationPeerType User = RegisterPossibleValue("user");

		/// <summary>
		/// Чат.
		/// </summary>
		public static readonly ConversationPeerType Chat = RegisterPossibleValue("chat");

		/// <summary>
		/// Группа.
		/// </summary>
		public static readonly ConversationPeerType Group = RegisterPossibleValue("group");

		/// <summary>
		/// E-mail.
		/// </summary>
		public static readonly ConversationPeerType Email = RegisterPossibleValue("email");
	}
}