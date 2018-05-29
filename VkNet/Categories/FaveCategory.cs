using System;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Категория работы с закладками.
	/// </summary>
	public partial class FaveCategory : IFaveCategory
	{
		/// <summary>
		/// API
		/// </summary>
		private readonly VkApi _vk;

		/// <summary>
		/// Методы для работы с закладками.
		/// </summary>
		/// <param name="vk"> API. </param>
		public FaveCategory(VkApi vk)
		{
			_vk = vk;
		}

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
		public VkCollection<User> GetUsers(int? count = null, int? offset = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => offset);

			var parameters = new VkParameters
			{
					{ "count", count }
					, { "offset", offset }
			};

			return _vk.Call(methodName: "fave.getUsers", parameters: parameters).ToVkCollectionOf<User>(selector: x => x);
		}

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
		public VkCollection<Photo> GetPhotos(int? count = null, int? offset = null, bool? photoSizes = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => offset);

			var parameters = new VkParameters
			{
					{ "count", count }
					, { "offset", offset }
					, { "photo_sizes", photoSizes }
			};

			return _vk.Call(methodName: "fave.getPhotos", parameters: parameters).ToVkCollectionOf<Photo>(selector: x => x);
		}

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
		public WallGetObject GetPosts(int? count = null, int? offset = null, bool extended = false)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => offset);

			var parameters = new VkParameters
			{
					{ "count", count }
					, { "offset", offset }
					, { "extended", true }
			};

			return _vk.Call(methodName: "fave.getPosts", parameters: parameters);
		}

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
		public FaveVideoEx GetVideos(int? count = null, int? offset = null, bool extended = false)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => offset);

			var parameters = new VkParameters
			{
					{ "count", count }
					, { "offset", offset }
					, { "extended", true }
			};

			return _vk.Call(methodName: "fave.getVideos", parameters: parameters);
		}

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
		public VkCollection<ExternalLink> GetLinks(int? count = null, int? offset = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => offset);

			var parameters = new VkParameters
			{
					{ "count", count }
					, { "offset", offset }
			};

			return _vk.Call(methodName: "fave.getLinks", parameters: parameters).ToVkCollectionOf<ExternalLink>(selector: x => x);
		}

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
		public bool AddUser(long userId)
		{
			var parameters = new VkParameters
			{
					{ "user_id", userId }
			};

			return _vk.Call(methodName: "fave.addUser", parameters: parameters);
		}

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
		public bool RemoveUser(long userId)
		{
			var parameters = new VkParameters
			{
					{ "user_id", userId }
			};

			return _vk.Call(methodName: "fave.removeUser", parameters: parameters);
		}

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
		public bool AddGroup(long groupId)
		{
			var parameters = new VkParameters
			{
					{ "group_id", groupId }
			};

			return _vk.Call(methodName: "fave.addGroup", parameters: parameters);
		}

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
		public bool RemoveGroup(long groupId)
		{
			var parameters = new VkParameters
			{
					{ "group_id", groupId }
			};

			return _vk.Call(methodName: "fave.removeGroup", parameters: parameters);
		}

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
		public bool AddLink(Uri link, string text)
		{
			var parameters = new VkParameters
			{
					{ "link", link }
					, { "text", text }
			};

			return _vk.Call(methodName: "fave.addLink", parameters: parameters);
		}

		/// <summary>
		/// Удаляет ссылку из закладок.
		/// </summary>
		/// <param name="linkId">
		/// Идентификатор ссылки, которую нужно удалить, полученный методом fave.getLinks.
		/// строка,
		/// обязательный параметр (Строка, обязательный параметр).
		/// </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.removeLink
		/// </remarks>
		public bool RemoveLink(string linkId)
		{
			var parameters = new VkParameters
			{
					{ "link_id", linkId }
			};

			return _vk.Call(methodName: "fave.removeLink", parameters: parameters);
		}

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
		public VkCollection<Market> GetMarketItems(ulong? count = null, ulong? offset = null, bool? extended = null)
		{
			var parameters = new VkParameters
			{
					{ "count", count }
					, { "offset", offset }
					, { "extended", extended }
			};

			return _vk.Call(methodName: "fave.getMarketItems", parameters: parameters).ToVkCollectionOf<Market>(selector: x => x);
		}
	}
}