using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkNet.Enums
{
	/// <summary>
	/// Значение приватности подарка (только для текущего пользователя).
	/// </summary>
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
		NameHideMessageUser
	}
}
