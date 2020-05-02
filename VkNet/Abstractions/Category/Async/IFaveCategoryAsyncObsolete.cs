using System;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Устаревшие методы работы с закладками.
	/// </summary>
	public partial interface IFaveCategoryAsync
	{
		/// <summary>
		/// Добавляет ссылку в закладки.
		/// </summary>
		/// <param name="link">
		/// Адрес добавляемой ссылки. Поддерживаются только внутренние ссылки на
		/// http://vk.com/. строка,
		/// обязательный параметр (Строка, обязательный параметр).
		/// </param>
		/// <param name="text"> Текст ссылки. строка (Строка). </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.addLink
		/// </remarks>
		[Obsolete(ObsoleteText.Obsolete + "Используйте вместо него Task<bool> AddLinkAsync(Uri link)")]
		Task<bool> AddLinkAsync(Uri link, string text);

		/// <summary>
		/// Возвращает список пользователей, добавленных текущим пользователем в закладки.
		/// </summary>
		/// <param name="offset">
		/// Смещение, необходимое для выборки определенного подмножества пользователей. По
		/// умолчанию — 0.
		/// положительное число (Положительное число).
		/// </param>
		/// <param name="count">
		/// Количество пользователей, информацию о которых необходимо вернуть.
		/// положительное число, по
		/// умолчанию 50 (Положительное число, по умолчанию 50).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов пользователей.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.getUsers
		/// </remarks>
		[Obsolete(ObsoleteText.Obsolete)]
		Task<VkCollection<User>> GetUsersAsync(int? count = null, int? offset = null);

		/// <summary>
		/// Возвращает фотографии, на которых текущий пользователь поставил отметку "Мне
		/// нравится".
		/// </summary>
		/// <param name="offset">
		/// Смещение, необходимое для выборки определенного подмножества фотографий.
		/// По умолчанию 0. положительное число (Положительное число).
		/// </param>
		/// <param name="count">
		/// Число фотографий, информацию о которых необходимо вернуть. положительное число,
		/// по умолчанию 50
		/// (Положительное число, по умолчанию 50).
		/// </param>
		/// <param name="photoSizes">
		/// Параметр, указывающий нужно ли возвращать ли доступные размеры фотографии в
		/// специальном
		/// формате. флаг, может принимать значения 1 или 0 (Флаг, может принимать значения
		/// 1 или 0).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов фотографий.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.getPhotos
		/// </remarks>
		[Obsolete(ObsoleteText.Obsolete)]
		Task<VkCollection<Photo>> GetPhotosAsync(int? count = null, int? offset = null, bool? photoSizes = null);

		/// <summary>
		/// Возвращает записи, на которых текущий пользователь поставил отметку "Мне
		/// нравится".
		/// </summary>
		/// <param name="offset">
		/// Смещение, необходимо для выборки определенного подмножества записей.
		/// По умолчанию — 0.
		/// (Положительное число).
		/// </param>
		/// <param name="count">
		/// Количество записей, информацию о которых нужно вернуть (но не более 100).
		/// (Положительное число, по умолчанию 50).
		/// </param>
		/// <param name="extended">
		/// 1 — в ответе будут возвращены дополнительные поля profiles и groups, содержащие
		/// информацию о пользователях и
		/// сообществах.
		/// По умолчанию: 0.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов записей на стене.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.getPosts
		/// </remarks>
		[Obsolete(ObsoleteText.Obsolete)]
		Task<WallGetObject> GetPostsAsync(int? count = null, int? offset = null, bool extended = false);

		/// <summary>
		/// Возвращает список видеозаписей, на которых текущий пользователь поставил
		/// отметку "Мне нравится".
		/// </summary>
		/// <param name="offset">
		/// Смещение, необходимое для выборки определенного подмножества видеозаписей.
		/// (Положительное число).
		/// </param>
		/// <param name="count">
		/// Количество видеозаписей, информацию о которых необходимо вернуть.
		/// (Положительное число, по умолчанию 50).
		/// </param>
		/// <param name="extended">
		/// 1 — в ответе будут возвращены дополнительные поля profiles и groups, содержащие
		/// информацию о пользователях и
		/// сообществах.
		/// По умолчанию: 0.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов видеозаписей.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.getVideos
		/// </remarks>
		[Obsolete(ObsoleteText.Obsolete)]
		Task<FaveVideoEx> GetVideosAsync(int? count = null, int? offset = null, bool extended = false);

		/// <summary>
		/// Возвращает ссылки, добавленные в закладки текущим пользователем.
		/// </summary>
		/// <param name="offset">
		/// Смещение, необходимое для выборки определенного подмножества ссылок.
		/// положительное число
		/// (Положительное число).
		/// </param>
		/// <param name="count">
		/// Количество ссылок, информацию о которых необходимо вернуть. положительное
		/// число, по умолчанию 50
		/// (Положительное число, по умолчанию 50).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает общее количество ссылок и массив объектов
		/// link, каждый из которых содержит
		/// поля id, URL, title, description, photo_50 и photo_100.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.getLinks
		/// </remarks>
		[Obsolete(ObsoleteText.Obsolete)]
		Task<VkCollection<ExternalLink>> GetLinksAsync(int? count = null, int? offset = null);

		/// <summary>
		/// Добавляет пользователя в закладки.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя, которого нужно добавить в закладки. положительное
		/// число, обязательный
		/// параметр (Положительное число, обязательный параметр).
		/// </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.addUser
		/// </remarks>
		[Obsolete(ObsoleteText.Obsolete)]
		Task<bool> AddUserAsync(long userId);

		/// <summary>
		/// Удаляет пользователя из закладок.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя, которого нужно удалить из закладок. положительное
		/// число, обязательный
		/// параметр (Положительное число, обязательный параметр).
		/// </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.removeUser
		/// </remarks>
		[Obsolete(ObsoleteText.Obsolete)]
		Task<bool> RemoveUserAsync(long userId);

		/// <summary>
		/// Добавляет сообщество в закладки.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества, которое нужно добавить в закладки. положительное
		/// число, обязательный
		/// параметр (Положительное число, обязательный параметр).
		/// </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.addGroup
		/// </remarks>
		[Obsolete(ObsoleteText.Obsolete)]
		Task<bool> AddGroupAsync(long groupId);

		/// <summary>
		/// Удаляет сообщество из закладок.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества, которое нужно удалить из закладок. положительное
		/// число, обязательный
		/// параметр (Положительное число, обязательный параметр).
		/// </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.removeGroup
		/// </remarks>
		[Obsolete(ObsoleteText.Obsolete)]
		Task<bool> RemoveGroupAsync(long groupId);

		/// <summary>
		/// Возвращает товары, добавленные в закладки текущим пользователем.
		/// </summary>
		/// <param name="count">
		/// Число товаров, информацию о которых необходимо вернуть. положительное число, по
		/// умолчанию 50
		/// (Положительное число, по умолчанию 50).
		/// </param>
		/// <param name="offset">
		/// Смещение, необходимое для выборки определенного подмножества товаров.
		/// положительное число, по
		/// умолчанию 0 (Положительное число, по умолчанию 0).
		/// </param>
		/// <param name="extended">
		/// 1 — будут возвращены дополнительные поля likes, can_comment, can_repost,
		/// photos. По умолчанию
		/// данные поля не возвращается. флаг, может принимать значения 1 или 0 (Флаг,
		/// может принимать значения 1 или 0).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов товаров.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.getMarketItems
		/// </remarks>
		[Obsolete(ObsoleteText.Obsolete)]
		Task<VkCollection<Market>> GetMarketItemsAsync(ulong? count = null, ulong? offset = null, bool? extended = null);
	}
}