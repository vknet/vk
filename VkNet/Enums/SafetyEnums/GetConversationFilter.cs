using System;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Фильтр беседы
	/// </summary>
	[Serializable]
	public class GetConversationFilter: SafetyEnum<GetConversationFilter>
	{
		/// <summary>
		/// Все беседы.
		/// </summary>
		[DefaultValue]
		public static readonly GetConversationFilter All = RegisterPossibleValue(value: "all");
		/// <summary>
		/// Беседы с непрочитанными сообщениями;
		/// </summary>
		public static readonly GetConversationFilter Unread = RegisterPossibleValue(value: "unread");
		/// <summary>
		/// Беседы, помеченные как важные (только для сообщений сообществ);
		/// </summary>
		public static readonly GetConversationFilter Important = RegisterPossibleValue(value: "important");
		/// <summary>
		/// Беседы, помеченные как неотвеченные (только для сообщений сообществ).
		/// </summary>
		public static readonly GetConversationFilter Unanswered = RegisterPossibleValue(value: "unanswered");
	}
}