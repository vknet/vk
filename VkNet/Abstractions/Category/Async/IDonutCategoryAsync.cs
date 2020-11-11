using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Методы для работы с VK Donut.
	/// </summary>
	public interface IDonutCategoryAsync
	{
		/// <summary>
		/// Возвращает информацию о том, подписан ли пользователь на платный контент (является доном).
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор сообщества — владельца записи. Указывается
		/// со знаком «минус».
		/// </param>
		/// <returns>
		/// Если пользователь является доном, возвращается 1. Если нет, возвращается 0.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/donut.isDon
		/// </remarks>
		public Task<bool> IsDonAsync(long ownerId);

		/// <summary>
		/// Возвращает список донов, которые подписаны на определенные сообщества, из числа друзей пользователя.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор сообщества — владельца записи. Указывается
		/// со знаком «минус».
		/// </param>
		/// <param name="offset">
		/// Смещение, необходимое для выборки определенного подмножества друзей.
		/// </param>
		/// <param name="count">
		/// Количество друзей, информацию о которых необходимо вернуть.
		/// </param>
		/// <param name="fields">
		/// Список дополнительных полей профилей, которые необходимо вернуть (через запятую).
		/// См. https://vk.com/dev/objects/user.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий число друзей в поле count и массив объектов пользователей в поле items.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/donut.getFriends
		/// </remarks>
		public Task<VkCollection<User>> GetFriendsAsync(long ownerId, ulong offset, byte count, UsersFields fields);

		/// <summary>
		/// Возвращает информацию о подписке VK Donut.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор сообщества — владельца записи. Указывается
		/// со знаком «минус».
		/// </param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/donut.getSubscription
		/// </remarks>
		public Task<Subscription> GetSubscriptionAsync(long ownerId);

		/// <summary>
		/// Возвращает информацию о подписке VK Donut.
		/// </summary>
		/// <param name="fields">
		/// Список дополнительных полей профилей, которые необходимо вернуть (через запятую).
		/// См. https://vk.com/dev/objects/user.
		/// </param>
		/// <param name="offset">
		/// Смещение, необходимое для выборки определенного подмножества подписок.
		/// </param>
		/// <param name="count">
		/// Соличество подписок, информацию о которых необходимо вернуть.
		/// </param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/donut.getSubscriptions
		/// </remarks>
		public Task<SubscriptionsInfo> GetSubscriptionsAsync(UsersFields fields, ulong offset, byte count);
	}
}
