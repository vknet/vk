using VkNet.Utils;

namespace VkNet.Enums
{
    /// <summary>
    /// Статус, возвращаемый после отправки запроса на добавления в друзья
    /// </summary>
    public enum AddFriendStatus //TODO: V3059 http://www.viva64.com/en/w/V3059 Members of the 'AddFriendStatus' enum are powers of 2. Consider adding '[Flags]' attribute to the enum.
    {
        /// <summary>
        /// Статус в случае ошибки ответа
        /// </summary>
        [DefaultValue]
        Unknown = 0,

		/// <summary>
		/// Заявка на добавление данного пользователя в друзья отправлена
		/// </summary>
		Sended = 1,

		/// <summary>
		/// Заявка на добавление в друзья от данного пользователя одобрена
		/// </summary>
		Accepted = 2,

		/// <summary>
		/// Повторная отправка заявки
		/// </summary>
		Resubmit = 4
    }
}