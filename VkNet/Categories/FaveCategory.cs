using System.Security.Policy;

namespace VkNet.Categories
{
	using System.Collections.ObjectModel;
	using Model;
	using Model.Attachments;
	using Utils;

	/// <summary>
	/// Категория работы с закладками.
	/// </summary>
	public class FaveCategory
	{
		/// <summary>
		/// API
		/// </summary>
		private readonly VkApi _vk;

		/// <summary>
		/// Методы для работы с закладками.
		/// </summary>
		/// <param name="vk">API.</param>
		internal FaveCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Возвращает список пользователей, добавленных текущим пользователем в закладки.
		/// </summary>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества пользователей. По умолчанию — 0. положительное число (Положительное число).</param>
		/// <param name="count">Количество пользователей, информацию о которых необходимо вернуть. положительное число, по умолчанию 50 (Положительное число, по умолчанию 50).</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов пользователей.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.getUsers" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<User> GetUsers(int? count = null, int? offset = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => count);
			VkErrors.ThrowIfNumberIsNegative(() => offset);

			var parameters = new VkParameters
				{
					{ "count", count },
					{ "offset", offset }
				};

			VkResponseArray response = _vk.Call("fave.getUsers", parameters);

			return response.ToReadOnlyCollectionOf<User>(x => x);
		}


		/// <summary>
		/// Возвращает фотографии, на которых текущий пользователь поставил отметку "Мне нравится".
		/// </summary>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества фотографий.
		/// По умолчанию 0. положительное число (Положительное число).</param>
		/// <param name="count">Число фотографий, информацию о которых необходимо вернуть. положительное число, по умолчанию 50 (Положительное число, по умолчанию 50).</param>
		/// <param name="photoSizes">Параметр, указывающий нужно ли возвращать ли доступные размеры фотографии в специальном формате. флаг, может принимать значения 1 или 0 (Флаг, может принимать значения 1 или 0).</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов фотографий.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.getPhotos" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<Photo> GetPhotos(int? count = null, int? offset = null, bool? photoSizes = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => count);
			VkErrors.ThrowIfNumberIsNegative(() => offset);

			var parameters = new VkParameters
				{
					{ "count", count },
					{ "offset", offset },
					{ "photo_sizes", photoSizes }
				};

			VkResponseArray response = _vk.Call("fave.getPhotos", parameters);
			return response.ToReadOnlyCollectionOf<Photo>(x => x);
		}

		/// <summary>
		/// Возвращает записи, на которых текущий пользователь поставил отметку «Мне нравится».
		/// </summary>
		/// <param name="offset">Смещение, необходимо для выборки определенного подмножества записей. По умолчанию — 0. положительное число (Положительное число).</param>
		/// <param name="count">Количество записей, информацию о которых нужно вернуть (но не более 100). положительное число, по умолчанию 50 (Положительное число, по умолчанию 50).</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов записей на стене.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.getPosts" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<Post> GetPosts(int? count = null, int? offset = null)
		{
			var response = GetPostsEx(count, offset);
			return response.WallPosts;
		}

		/// <summary>
		/// Возвращает записи, на которых текущий пользователь поставил отметку «Мне нравится».
		/// </summary>
		/// <param name="offset">Смещение, необходимо для выборки определенного подмножества записей. По умолчанию — 0. положительное число (Положительное число).</param>
		/// <param name="count">Количество записей, информацию о которых нужно вернуть (но не более 100). положительное число, по умолчанию 50 (Положительное число, по умолчанию 50).</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов записей на стене.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.getPosts" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public WallGetObject GetPostsEx(int? count = null, int? offset = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => count);
			VkErrors.ThrowIfNumberIsNegative(() => offset);

			var parameters = new VkParameters
				{
					{ "count", count },
					{ "offset", offset },
					{ "extended", true }
				};

			return _vk.Call("fave.getPosts", parameters);
		}

		/// <summary>
		/// Возвращает список видеозаписей, на которых текущий пользователь поставил отметку «Мне нравится».
		/// </summary>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества видеозаписей. положительное число (Положительное число).</param>
		/// <param name="count">Количество видеозаписей, информацию о которых необходимо вернуть. положительное число, по умолчанию 50 (Положительное число, по умолчанию 50).</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов видеозаписей.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.getVideos" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<Video> GetVideos(int? count = null, int? offset = null)
		{
			var response = GetVideosEx(count, offset);
			return response.Video;
		}

		/// <summary>
		/// Возвращает список видеозаписей, на которых текущий пользователь поставил отметку «Мне нравится».
		/// </summary>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества видеозаписей. положительное число (Положительное число).</param>
		/// <param name="count">Количество видеозаписей, информацию о которых необходимо вернуть. положительное число, по умолчанию 50 (Положительное число, по умолчанию 50).</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов видеозаписей.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.getVideos" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public FaveVideoEx GetVideosEx(int? count = null, int? offset = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => count);
			VkErrors.ThrowIfNumberIsNegative(() => offset);

			var parameters = new VkParameters
				{
					{ "count", count },
					{ "offset", offset },
					{ "extended", true }
				};

			return _vk.Call("fave.getVideos", parameters);
		}

		/// <summary>
		/// Возвращает ссылки, добавленные в закладки текущим пользователем.
		/// </summary>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества ссылок. положительное число (Положительное число).</param>
		/// <param name="count">Количество ссылок, информацию о которых необходимо вернуть. положительное число, по умолчанию 50 (Положительное число, по умолчанию 50).</param>
		/// <returns>
		/// После успешного выполнения возвращает общее количество ссылок и массив объектов link, каждый из которых содержит поля id, url, title, description, photo_50 и photo_100.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.getLinks" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<ExternalLink> GetLinks(int? count = null, int? offset = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => count);
			VkErrors.ThrowIfNumberIsNegative(() => offset);

			var parameters = new VkParameters
				{
					{ "count", count },
					{ "offset", offset}
				};

			VkResponseArray response = _vk.Call("fave.getLinks", parameters);

			return response.ToReadOnlyCollectionOf<ExternalLink>(x => x);
		}

		/// <summary>
		/// Добавляет пользователя в закладки.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя, которого нужно добавить в закладки. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.addUser" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool AddUser(long userId)
		{
			var parameters = new VkParameters
			{
				{ "user_id", userId }
			};
			return _vk.Call("fave.addUser", parameters);
		}


		/// <summary>
		/// Удаляет пользователя из закладок.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя, которого нужно удалить из закладок. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.removeUser" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool RemoveUser(long userId)
		{
			var parameters = new VkParameters
			{
				{ "user_id", userId }
			};
			return _vk.Call("fave.removeUser", parameters);
		}

		/// <summary>
		/// Добавляет сообщество в закладки.
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества, которое нужно добавить в закладки. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.addGroup" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool AddGroup(long groupId)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId }
			};
			return _vk.Call("fave.addGroup", parameters);
		}

		/// <summary>
		/// Удаляет сообщество из закладок.
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества, которое нужно удалить из закладок. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.removeGroup" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool RemoveGroup(long groupId)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId }
			};
			return _vk.Call("fave.removeGroup", parameters);
		}

		/// <summary>
		/// Добавляет ссылку в закладки.
		/// </summary>
		/// <param name="link">Адрес добавляемой ссылки. Поддерживаются только внутренние ссылки на http://vk.com/. строка, обязательный параметр (Строка, обязательный параметр).</param>
		/// <param name="text">Текст ссылки. строка (Строка).</param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.addLink" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool AddLink(Url link, string text)
		{
			var parameters = new VkParameters
			{
				{ "link", link.Value },
				{ "text", text }
			};
			return _vk.Call("fave.addLink", parameters);
		}

		/// <summary>
		/// Удаляет ссылку из закладок.
		/// </summary>
		/// <param name="linkId">Идентификатор ссылки, которую нужно удалить, полученный методом fave.getLinks. строка, обязательный параметр (Строка, обязательный параметр).</param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.removeLink" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool RemoveLink(string linkId)
		{
			var parameters = new VkParameters
			{
				{ "link_id", linkId }
			};
			return _vk.Call("fave.removeLink", parameters);
		}

		/// <summary>
		/// Возвращает товары, добавленные в закладки текущим пользователем.
		/// </summary>
		/// <param name="count">Число товаров, информацию о которых необходимо вернуть. положительное число, по умолчанию 50 (Положительное число, по умолчанию 50).</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества товаров. положительное число, по умолчанию 0 (Положительное число, по умолчанию 0).</param>
		/// <param name="extended">1 — будут возвращены дополнительные поля likes, can_comment, can_repost, photos. По умолчанию данные поля не возвращается. флаг, может принимать значения 1 или 0 (Флаг, может принимать значения 1 или 0).</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов товаров.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.getMarketItems" />.
		/// </remarks>
		public VkCollection<Market> GetMarketItems(ulong? count = null, ulong? offset = null, bool? extended = null)
		{
			var parameters = new VkParameters {
				{ "count", count },
				{ "offset", offset },
				{ "extended", extended }
			};

			return _vk.Call("fave.getMarketItems", parameters).ToVkCollectionOf<Market>(x => x);
		}
	}
}