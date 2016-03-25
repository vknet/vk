using System;
using VkNet.Utils;

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
		public static readonly RelativeType Sibling = RegisterPossibleValue("sibling");


		/// <summary>
		/// Родитель.
		/// </summary>
		public static readonly RelativeType Parent = RegisterPossibleValue("parent");


		/// <summary>
		/// Ребенок.
		/// </summary>
		public static readonly RelativeType Child = RegisterPossibleValue("child");


		/// <summary>
		/// Дедушка/Бабушка.
		/// </summary>
		public static readonly RelativeType Grandparent = RegisterPossibleValue("grandparent");


		/// <summary>
		/// Внук.
		/// </summary>
		public static readonly RelativeType Grandchild = RegisterPossibleValue("grandchild");
	}
}