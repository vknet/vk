using System;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип сообщества
	/// </summary>
	[Serializable]
	public sealed class GroupType : SafetyEnum<GroupType>
	{
		/// <summary>
		/// Публичная страница.
		/// </summary>
		public static readonly GroupType Page = RegisterPossibleValue(value: "page");

		/// <summary>
		/// Группа.
		/// </summary>
		public static readonly GroupType Group = RegisterPossibleValue(value: "group");

		/// <summary>
		/// Мероприятие.
		/// </summary>
		public static readonly GroupType Event = RegisterPossibleValue(value: "event");

		/// <summary>
		/// Не определено.
		/// </summary>
		public static readonly GroupType Undefined = RegisterPossibleValue(value: "undefined");
	}
}