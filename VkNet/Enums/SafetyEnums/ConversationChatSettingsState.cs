using System;

namespace VkNet.Enums.SafetyEnums
{
	[Serializable]
	public class ConversationChatSettingsState : SafetyEnum<ConversationChatSettingsState>
	{
		/// <summary>
		/// Состоит в чате.
		/// </summary>
		public static readonly ConversationChatSettingsState In = RegisterPossibleValue("in");

		/// <summary>
		/// Исключён из чата.
		/// </summary>
		public static readonly ConversationChatSettingsState Kicked = RegisterPossibleValue("kicked");

		/// <summary>
		/// Покинул чат.
		/// </summary>
		public static readonly ConversationChatSettingsState Left = RegisterPossibleValue("left");
	}
}