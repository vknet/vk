using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы с фотографиями.
	/// </summary>
	public partial class PhotoCategory
	{

		/// <summary>
		/// Возвращает список фотографий со страницы пользователя или сообщества.
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, фотографии которого нужно получить. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="photoIds">Идентификаторы фотографий, информацию о которых необходимо вернуть</param>
		/// <param name="rev">Порядок сортировки фотографий (1 — антихронологический, 0 — хронологический). флаг, может принимать значения 1 или 0</param>
		/// <param name="extended"><c>true</c> — будет возвращено дополнительное поле likes. По умолчанию поле likes не возвращается. флаг, может принимать значения 1 или 0</param>
		/// <param name="feedType">Тип новости, получаемый в поле type метода newsfeed.get. строка</param>
		/// <param name="feed">Unixtime, который может быть получен методом newsfeed.get в поле date, для получения всех фотографий загруженных пользователем в определённый день либо на которых пользователь был отмечен. Также нужно указать параметр uid пользователя, с которым произошло событие</param>
		/// <param name="photoSizes">Возвращать ли размеры фотографий в специальном формате</param>
		/// <param name="count">Положительное число, максимальное значение 1000</param>
		/// <param name="offset">Положительное число</param>
		/// <returns>После успешного выполнения возвращает массив объектов Photo</returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/photos.getProfile
		/// </remarks>
		[Obsolete("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования.")]
		public ReadOnlyCollection<Photo> GetProfile(long? ownerId = null, IEnumerable<long> photoIds = null, bool? rev = null, bool? extended = null, string feedType = null, DateTime? feed = null, bool? photoSizes = null, ulong? count = null, ulong? offset = null)
		{
			throw new System.Exception("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования.");
		}

		/// <summary>
		/// Возвращает адрес сервера для загрузки фотографии на страницу пользователя.
		/// </summary>
		/// <returns>После успешного выполнения возвращает объект с единственным полем upload_url. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/photos.getProfileUploadServer
		/// </remarks>
		[Obsolete("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования. Используйте метод GetOwnerPhotoUploadServer")]
		public UploadServerInfo GetProfileUploadServer()
		{
			return GetOwnerPhotoUploadServer();
		}

		/// <summary>
		/// Сохраняет фотографию пользователя после успешной загрузки.
		/// </summary>
		/// <param name="server">Параметр, возвращаемый в результате загрузки фотографии на сервер.</param>
		/// <param name="hash">Параметр, возвращаемый в результате загрузки фотографии на сервер.</param>
		/// <param name="photo">Параметр, возвращаемый в результате загрузки фотографии на сервер.</param>
		/// <returns>После успешного выполнения возвращает объект, содержащий поля photo_hash и photo_src (при работе через VK.api метод вернёт поля photo_src, photo_src_big, photo_src_small). Параметр photo_hash необходим для подтверждения пользователем изменения его фотографии через вызов метода saveProfilePhoto Javascript API. Поле photo_src содержит путь к загруженной фотографии. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/photos.saveProfilePhoto
		/// </remarks>
		[Obsolete("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования. Используйте метод SaveOwnerPhoto")]
		public Photo SaveProfilePhoto(string server = null, string hash = null, string photo = null)
		{
			var response = @"{
				""server"": " + server + @"
				""photo"":" + photo + @"
				""hash"": " + hash + @"
			}";
			return SaveOwnerPhoto(response);
		}

		/// <summary>
		/// Возвращает список альбомов пользователя или сообщества.
		/// </summary>
		/// <param name="count">Количество альбомов.</param>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// Возвращает список объектов PhotoAlbum
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/photos.getAlbums
		/// </remarks>
		[Obsolete("Метод устарел. Используйте вместо него GetAlbums(PhotoGetAlbumsParams @params)")]
		public ReadOnlyCollection<PhotoAlbum> GetAlbums(out int count, PhotoGetAlbumsParams @params)
		{
			var response = GetAlbums(@params);

			count = Convert.ToInt32(response.TotalCount);

			return response.ToReadOnlyCollection();
		}

		/// <summary>
		/// Возвращает список фотографий в альбоме.
		/// </summary>
		/// <param name="count">Количество альбомов.</param>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>После успешного выполнения возвращает список объектов Photo</returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/photos.get
		/// </remarks>
		[Obsolete("Метод устарел. Используйте вместо него Get(PhotoGetParams @params)")]
		public ReadOnlyCollection<Photo> Get(out int count, PhotoGetParams @params)
		{
			var response = Get(@params);

			count = Convert.ToInt32(response.TotalCount);;

			return response.ToReadOnlyCollection();
		}

		/// <summary>
		/// Осуществляет поиск изображений по местоположению или описанию.
		/// </summary>
		/// <param name="count">Количество альбомов.</param>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов фотографий.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/photos.search
		/// </remarks>
		[Obsolete("Метод устарел. Используйте вместо него Search(PhotoSearchParams @params)")]
		public ReadOnlyCollection<Photo> Search(out int count, PhotoSearchParams @params)
		{
			var response = Search(@params);

			count = Convert.ToInt32(response.TotalCount);

			return response.ToReadOnlyCollection();
		}

		/// <summary>
		/// Возвращает все фотографии пользователя или сообщества в антихронологическом порядке.
		/// </summary>
		/// <param name="count">Количество пользователей, которым нравится текущая фотография.</param>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов Photo
		/// <remarks>
		/// Если был задан параметр extended — будет возвращено поле likes:
		/// user_likes: 1 — текущему пользователю нравится данная фотография, 0 - не указано.
		/// count — количество пользователей, которым нравится текущая фотография.
		/// Если был задан параметр photo_sizes=1, вместо полей width и height возвращаются размеры копий фотографии в специальном формате.
		/// </remarks>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/photos.getAll
		/// </remarks>
		[Obsolete("Метод устарел. Используйте вместо него GetAll(PhotoGetAllParams @params)")]
		public ReadOnlyCollection<Photo> GetAll(out int count, PhotoGetAllParams @params)
		{
			var response = GetAll(@params);

			count = Convert.ToInt32(response.TotalCount);

			return response.ToReadOnlyCollection();
		}

		/// <summary>
		/// Возвращает список фотографий, на которых отмечен пользователь.
		/// </summary>
		/// <param name="count">Количество.</param>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>После успешного выполнения возвращает список объектов photo.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/photos.getUserPhotos
		/// </remarks>
		[Obsolete("Метод устарел. Используйте вместо него GetUserPhotos(PhotoGetUserPhotosParams @params)")]
		public ReadOnlyCollection<Photo> GetUserPhotos(out int count, PhotoGetUserPhotosParams @params)
		{
			var response = GetUserPhotos(@params);

			count = Convert.ToInt32(response.TotalCount);

			return response.ToReadOnlyCollection();
		}

		/// <summary>
		/// Возвращает список комментариев к фотографии.
		/// </summary>
		/// <param name="count">Количество.</param>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов Comment
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/photos.getComments
		/// </remarks>
		[Obsolete("Метод устарел. Используйте вместо него GetComments(PhotoGetCommentsParams @params)")]
		public ReadOnlyCollection<Comment> GetComments(out int count, PhotoGetCommentsParams @params)
		{
			var response = GetComments(@params);

			count = Convert.ToInt32(response.TotalCount);

			return response.ToReadOnlyCollection();
		}

		/// <summary>
		/// Возвращает отсортированный в антихронологическом порядке список всех комментариев к конкретному альбому или ко всем альбомам пользователя.
		/// </summary>
		/// <param name="count">Количество комментариев</param>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов Comment
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/photos.getAllComments
		/// </remarks>
		[Obsolete("Метод устарел. Используйте вместо него GetAllComments(PhotoGetAllCommentsParams @params)")]
		public ReadOnlyCollection<Comment> GetAllComments(out int count, PhotoGetAllCommentsParams @params)
		{
			var response = GetAllComments(@params);

			count = Convert.ToInt32(response.TotalCount);

			return response.ToReadOnlyCollection();
		}

		/// <summary>
		/// Возвращает список фотографий, на которых есть непросмотренные отметки.
		/// </summary>
		/// <param name="countTotal">Общее количество.</param>
		/// <param name="offset">Смещение, необходимое для получения определённого подмножества фотографий. целое число (Целое число).</param>
		/// <param name="count">Количество фотографий, которые необходимо вернуть. положительное число, максимальное значение 100, по умолчанию 20 (Положительное число, максимальное значение 100, по умолчанию 20).</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов Photo
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/photos.getNewTags
		/// </remarks>
		[Obsolete("Метод устарел. Используйте вместо него GetNewTags(uint? offset = null, uint? count = null)")]
		public ReadOnlyCollection<Photo> GetNewTags(out int countTotal, uint? offset = null, uint? count = null)
		{
			var response = GetNewTags(offset,count);

			countTotal = Convert.ToInt32(response.TotalCount);

			return response.ToReadOnlyCollection();
		}

	}
}