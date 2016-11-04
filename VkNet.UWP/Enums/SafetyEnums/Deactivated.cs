using System;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Возможные значения параметра display, задающего внешний вид окна авторизации.
	/// </summary>
	[DataContract]
	public sealed class Deactivated : SafetyEnum<Deactivated>
    {
		/// <summary>
		/// Удалено.
		/// </summary>
		public static readonly Deactivated Deleted = RegisterPossibleValue("deleted");

		/// <summary>
		/// Заблокировано.
		/// </summary>
		public static readonly Deactivated Banned = RegisterPossibleValue("banned");

		/// <summary>
		/// Активно.
		/// </summary>
		[DefaultValue]
		public static readonly Deactivated Activated = RegisterPossibleValue("activated");
	}
}