using System.Security.Policy;

namespace VkNet.Categories
{
	using System.Collections.ObjectModel;
	using JetBrains.Annotations;

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
		/// <param name="count">Количество пользователей, информацию о которых необходимо вернуть</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества пользователей</param>
		/// <returns>После успешного выполнения возвращает список объектов пользователей.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.getUsers"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.40")]
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
		/// <param name="count">Количество пользователей, информацию о которых необходимо вернуть</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества пользователей</param>
		/// <param name="photoSizes">Параметр, указывающий нужно ли возвращать ли доступные размеры фотографии в специальном формате <seealso cref="PhotoSize"/>. </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов фотографий.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.getPhotos" />.
		/// </remarks>
		[Pure]
		[ApiVersion("5.40")]
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
		/// <param name="count">Количество пользователей, информацию о которых необходимо вернуть</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества пользователей</param>
		/// <returns>После успешного выполнения возвращает список объектов записей на стене.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.getPosts"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.40")]
		public ReadOnlyCollection<Post> GetPosts(int? count = null, int? offset = null)
		{
			var response = GetPostsEx(count, offset);
			return response.WallPosts;
		}

		/// <summary>
		/// Возвращает записи, на которых текущий пользователь поставил отметку «Мне нравится».
		/// </summary>
		/// <param name="count">Количество пользователей, информацию о которых необходимо вернуть</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества пользователей</param>
		/// <returns>После успешного выполнения возвращает список объектов записей на стене.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.getPosts"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.40")]
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
		/// <param name="count">Количество пользователей, информацию о которых необходимо вернуть</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества пользователей</param>
		/// <returns>После успешного выполнения возвращает список объектов записей на стене.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.getVideos"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.40")]
		public ReadOnlyCollection<Video> GetVideos(int? count = null, int? offset = null)
		{
			var response = GetVideosEx(count, offset);
			return response.Video;
		}

		/// <summary>
		/// Возвращает список видеозаписей, на которых текущий пользователь поставил отметку «Мне нравится».
		/// </summary>
		/// <param name="count">Количество пользователей, информацию о которых необходимо вернуть</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества пользователей</param>
		/// <returns>После успешного выполнения возвращает список объектов записей на стене.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.getVideos"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.40")]
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
		/// <param name="count">Количество пользователей, информацию о которых необходимо вернуть</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества пользователей</param>
		/// <returns>После успешного выполнения возвращает общее количество ссылок и массив объектов Link.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.getLinks"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.40")]
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
		/// <param name="userId">Идентификатор пользователя, которого нужно добавить в закладки. </param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/fave.addUser" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool AddUser(ulong userId)
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
		/// <param name="userId">Идентификатор пользователя, которого нужно удалить из закладок.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/fave.removeUser" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool RemoveUser(ulong userId)
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
		/// <param name="groupId">Идентификатор сообщества, которое нужно добавить в закладки.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/fave.addGroup" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool AddGroup(ulong groupId)
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
		/// <param name="groupId">Идентификатор сообщества, которое нужно удалить из закладок.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/fave.removeGroup" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool RemoveGroup(ulong groupId)
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
		/// <param name="link">Адрес добавляемой ссылки. Поддерживаются только внутренние ссылки на http://vk.com/. </param>
		/// <param name="text">The text.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/fave.addLink" />.
		/// </remarks>
		[ApiVersion("5.40")]
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
		/// <param name="linkId">Идентификатор ссылки, которую нужно удалить, полученный методом <seealso cref="GetLinks"/></param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/fave.removeLink" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool RemoveLink(string linkId)
		{
			var parameters = new VkParameters
			{
				{ "link_id", linkId }
			};
			return _vk.Call("fave.removeLink", parameters);
		}

	}
}