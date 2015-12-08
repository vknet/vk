namespace VkNet.Enums.SafetyEnums
{
	using System;

	using Utils;

	/// <summary>
	/// Тип сообщества
	/// </summary>
	[Serializable]
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

		internal static GroupType FromJson(VkResponse response)
		{
			switch ((string)response)
			{
				case "page":
					{
						return Page;
					}
				case "event":
					{
						return Event;
					}
				case "group":
					{
						return Group;
					}
				default:
					{
						return Undefined;
					}
			}
		}
	}
}