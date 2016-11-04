using System;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Значение приватности подарка (только для текущего пользователя).
	/// </summary>
	[DataContract]
	public enum GiftPrivacy
	{
		/// <summary>
		/// 0 — имя отправителя и сообщение видно всем
		/// </summary>
		All = 0,
		/// <summary>
		/// 1 — имя отправителя видно всем, сообщение видно только получателю
		/// </summary>
		NameAllMessageUser,
		/// <summary>
		/// 2 — имя отправителя скрыто, сообщение видно только получателю
		/// </summary>
		[DefaultValue]
		NameHideMessageUser
	}
}
