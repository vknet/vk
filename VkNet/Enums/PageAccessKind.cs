using System;

namespace VkNet.Enums
{
	/// <summary>
	/// Режим доступа к странице
	/// </summary>
	[Serializable]
	public enum PageAccessKind
	{
		/// <summary>
		/// Доступ только руководителям сообщества.
		/// </summary>
		OnlyAdministrators = 0

		, /// <summary>
		/// Доступ только членам сообщества.
		/// </summary>
		OnlyMembers = 1

		, /// <summary>
		/// Неограниченный доступ.
		/// </summary>
		Unrestricted = 2
	}
}