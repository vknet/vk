using System;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип родственных связей.
	/// </summary>
	[Serializable]
	public sealed class RelativeType : SafetyEnum<RelativeType>
	{
		/// <summary>
		/// Брат/Сестра.
		/// </summary>
		public static readonly RelativeType Sibling = RegisterPossibleValue(value: "sibling");

		/// <summary>
		/// Родитель.
		/// </summary>
		public static readonly RelativeType Parent = RegisterPossibleValue(value: "parent");

		/// <summary>
		/// Ребенок.
		/// </summary>
		public static readonly RelativeType Child = RegisterPossibleValue(value: "child");

		/// <summary>
		/// Дедушка/Бабушка.
		/// </summary>
		public static readonly RelativeType Grandparent = RegisterPossibleValue(value: "grandparent");

		/// <summary>
		/// Внук.
		/// </summary>
		public static readonly RelativeType Grandchild = RegisterPossibleValue(value: "grandchild");
	}
}