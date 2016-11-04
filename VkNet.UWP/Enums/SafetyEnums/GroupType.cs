using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums
{
	using System;

	/// <summary>
	/// Тип сообщества
	/// </summary>
	[DataContract]
	public sealed class GroupType : SafetyEnum<GroupType>
	{
		/// <summary>
		/// Публичная страница.
		/// </summary>
		public static readonly GroupType Page = RegisterPossibleValue("page");

		/// <summary>
		/// Группа.
		/// </summary>
		public static readonly GroupType Group = RegisterPossibleValue("group");

		/// <summary>
		/// Мероприятие.
		/// </summary>
		public static readonly GroupType Event = RegisterPossibleValue("event");

		/// <summary>
		/// Не определено.
		/// </summary>
		public static readonly GroupType Undefined = RegisterPossibleValue("undefined");
	}
}