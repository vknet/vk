using System;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Информация о текущем роде занятия пользователя.
	/// </summary>
	[Serializable]
	public class OnlineStatusType : SafetyEnum<OnlineStatusType>
	{
		/// <summary>
		/// Сообщество не онлайн
		/// </summary>
		[DefaultValue]
		public static readonly OnlineStatusType None = RegisterPossibleValue("none");

		/// <summary>
		/// Сообщество онлайн (отвечает мгновенно)
		/// </summary>
		public static readonly OnlineStatusType Online = RegisterPossibleValue("online");

		/// <summary>
		/// Сообщество отвечает быстро.
		/// </summary>
		public static readonly OnlineStatusType AnswerMark = RegisterPossibleValue("answer_mark");
	}
}