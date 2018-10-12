using System;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Возможные значения параметра display, задающего внешний вид окна авторизации.
	/// </summary>
	[Serializable]
	public sealed class Deactivated : SafetyEnum<Deactivated>
	{
		/// <summary>
		/// Удалён.
		/// </summary>
		public static readonly Deactivated Deleted = RegisterPossibleValue(value: "deleted");

		/// <summary>
		/// Заблокирован.
		/// </summary>
		public static readonly Deactivated Banned = RegisterPossibleValue(value: "banned");

		/// <summary>
		/// Активен.
		/// </summary>
		[DefaultValue]
		public static readonly Deactivated Activated = RegisterPossibleValue(value: "activated");
	}
}
