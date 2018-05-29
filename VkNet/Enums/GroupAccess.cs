using System;
using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Уровень доступа к сообществу.
	/// </summary>
	[Serializable]
	public enum GroupAccess
	{
		/// <summary>
		/// 0 — открытая;
		/// </summary>
		[DefaultValue]
		Open = 0

		, /// <summary>
		/// Закрытая
		/// </summary>
		Closed

		, /// <summary>
		/// Частная
		/// </summary>
		Private
	}
}