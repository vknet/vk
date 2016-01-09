using System.ComponentModel.DataAnnotations;
using VkNet.Properties;
using VkNet.Utils;

namespace VkNet.Enums
{
    /// <summary>
    /// Статус, возвращаемый после отправки запроса на добавления в друзья
    /// </summary>
    public enum AddFriendStatus
    {
		/// <summary>
		/// Статус в случае ошибки ответа
		/// </summary>
		[Display(ResourceType = typeof (Resources), Name = "AddFriendStatus_Unknown")]
		[DefaultValue]
        Unknown = 0,

		/// <summary>
		/// Заявка на добавление данного пользователя в друзья отправлена
		/// </summary>
		[Display(ResourceType = typeof (Resources), Name = "AddFriendStatus_Sended")]
		Sended = 1,

		/// <summary>
		/// Заявка на добавление в друзья от данного пользователя одобрена
		/// </summary>
		[Display(ResourceType = typeof (Resources), Name = "AddFriendStatus_Accepted")]
		Accepted = 2,

		/// <summary>
		/// Повторная отправка заявки
		/// </summary>
		[Display(ResourceType = typeof (Resources), Name = "AddFriendStatus_Resubmit")]
		Resubmit = 4
    }
}