using System;
using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Статус, возвращаемый после отправки запроса на добавления в друзья
	/// </summary>
	[Flags]
	public enum AddFriendStatus
	{
		/// <summary>
		/// Статус в случае ошибки ответа
		/// </summary>
		[DefaultValue]
		Unknown = 0

		, /// <summary>
		/// Заявка на добавление данного пользователя в друзья отправлена
		/// </summary>
		Sended = 1

		, /// <summary>
		/// Заявка на добавление в друзья от данного пользователя одобрена
		/// </summary>
		Accepted = 2

		, /// <summary>
		/// Повторная отправка заявки
		/// </summary>
		Resubmit = 4
	}
}