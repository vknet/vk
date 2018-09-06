using System;
using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Состояние дружбы с пользователями.
	/// </summary>
	[Serializable]
	public enum FriendStatus
	{
		/// <summary>
		/// Пользователь не является другом.
		/// </summary>
		[DefaultValue]
		NotFriend = 0

		, /// <summary>
		/// Пользователю отправлена заявка/подписка.
		/// </summary>
		OutputRequest = 1

		, /// <summary>
		/// Имеется входящая заявка/подписка от пользователя.
		/// </summary>
		InputRequest = 2

		, /// <summary>
		/// Пользователь является другом.
		/// </summary>
		Friend = 3
	}
}