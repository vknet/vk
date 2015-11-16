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
					{"count", count},
					{"offset", offset}
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
					{"count", count},
					{"offset", offset},
					{"extended", true}
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
		[ApiVersion("5.9")]
		public ReadOnlyCollection<Video> GetVideos(int? count = null, int? offset = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => count);
			VkErrors.ThrowIfNumberIsNegative(() => offset);

			var parameters = new VkParameters
				{
					{"count", count},
					{"offset", offset}
				};

			VkResponseArray response = _vk.Call("fave.getVideos", parameters);

			return response.ToReadOnlyCollectionOf<Video>(x => x);
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
		[ApiVersion("5.9")]
		public ReadOnlyCollection<ExternalLink> GetLinks(int? count = null, int? offset = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => count);
			VkErrors.ThrowIfNumberIsNegative(() => offset);

			var parameters = new VkParameters
				{
					{"count", count},
					{"offset", offset}
				};

			VkResponseArray response = _vk.Call("fave.getLinks", parameters);

			return response.ToReadOnlyCollectionOf<ExternalLink>(x => x);
		}
	}
}