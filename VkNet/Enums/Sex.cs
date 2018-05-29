using System;
using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Пол.
	/// </summary>
	[Serializable]
	public enum Sex
	{
		/// <summary>
		/// Деактивированный аккаунт
		/// </summary>
		Deactivated = -1

		, /// <summary>
		/// Не указан
		/// </summary>
		[DefaultValue]
		Unknown = 0

		, /// <summary>
		/// Женский
		/// </summary>
		Female = 1

		, /// <summary>
		/// Мужской
		/// </summary>
		Male = 2
	}
}