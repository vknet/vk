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

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static RelativeType FromJson(VkResponse response)
		{
			switch (response.ToString())
			{
				case "sibling":
					{
						return Sibling;
					}
				case "parent":
					{
						return Parent;
					}
				case "child":
					{
						return Child;
					}
				case "grandparent":
					{
						return Grandparent;
					}
				case "grandchild":
					{
						return Grandchild;
					}
				default:
					{
						return null;
					}
			}
		}
	}
}