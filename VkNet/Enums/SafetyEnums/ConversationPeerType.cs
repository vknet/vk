using System;

namespace VkNet.Enums.SafetyEnums
{
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
		public static readonly ConversationPeerType chat = RegisterPossibleValue("chat");

		/// <summary>
		/// Группа.
		/// </summary>
		public static readonly ConversationPeerType group = RegisterPossibleValue("group");

		/// <summary>
		/// E-mail.
		/// </summary>
		public static readonly ConversationPeerType email = RegisterPossibleValue("email");
	}
}