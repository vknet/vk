namespace VkNet.Categories
{
#if WINDOWS_PHONE
	using System.Net;
#else
	using System.Web;
#endif
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System;

	using Utils;
	using Enums;
	using Enums.SafetyEnums;
	using Model;
	using Model.Attachments;
	using VkNet.Model.RequestParams.Photo;

	/// <summary>
	/// Методы для работы с фотографиями.
	/// </summary>
	public class PhotoCategory
	{
		private readonly VkApi _vk;

		internal PhotoCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Создает пустой альбом для фотографий.
		/// </summary>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// После успешного выполнения возвращает объект <see cref="PhotoAlbum" />
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.createAlbum" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public PhotoAlbum CreateAlbum(CreateAlbumParams @params)
		{
			if (@params.Title.Length < 2)
			{
				throw new Exception("Параметр title обязательный, минимальная длина 2 символа");
			}
			var parameters = new VkParameters
				{
					{ "title", @params.Title },
					{ "group_id", @params.GroupId },
					{ "description", @params.Description },
					{ "privacy_view", @params.View },
					{ "privacy_comment", @params.Privacy },
					{ "upload_by_admins_only", @params.UploadByAdminsOnly },
					{ "comments_disabled", @params.CommentsDisabled }
				};

			return _vk.Call("photos.createAlbum", parameters);
		}

		/// <summary>
		/// Редактирует данные альбома для фотографий пользователя.
		/// </summary>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.editAlbum" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool EditAlbum(EditAlbumParams @params)
		{
			var parameters = new VkParameters
				{
					{ "album_id", @params.AlbumId },
					{ "title", @params.Title },
					{ "description", @params.Description },
					{ "owner_id", @params.OwnerId },
					{ "privacy_view", string.Join(",", @params.View) },
					{ "privacy_comment", string.Join(",", @params.Privacy) },
					{ "upload_by_admins_only", @params.UploadByAdminsOnly },
					{ "comments_disabled", @params.CommentsDisabled }
				};

			return _vk.Call("photos.editAlbum", parameters);
		}

		/// <summary>
		/// Возвращает список альбомов пользователя или сообщества.
		/// </summary>
		/// <param name="count">Количество альбомов.</param>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// Возвращает список объектов <see cref="PhotoAlbum" />
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getAlbums" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public ReadOnlyCollection<PhotoAlbum> GetAlbums(out int count, GetAlbumsParams @params)
		{
			var parameters = new VkParameters
				{
					{"owner_id", @params.OwnerId},
					{"album_ids", @params.AlbumIds},
					{"offset", @params.Offset},
					{"count", @params.Count},
					{"need_system", @params.NeedSystem},
					{"need_covers", @params.NeedCovers},
					{"photo_sizes", @params.PhotoSizes}
				};

			var response = _vk.Call("photos.getAlbums", parameters);
			count = response["count"];
			return response["items"].ToReadOnlyCollectionOf<PhotoAlbum>(x => x);
		}

		/// <summary>
		/// Возвращает список фотографий в альбоме. 
		/// </summary>
		/// <param name="count">Количество альбомов.</param>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>После успешного выполнения возвращает список объектов <see cref="Photo"/>.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.get"/>.
		/// </remarks>
		[ApiMethodName("photos.get", Skip = true)]
		[ApiVersion("5.37")]
		public ReadOnlyCollection<Photo> Get(out int count, PhotoGetParams @params)
		{
			var parameters = new VkParameters
				{
					{ "owner_id", @params.OwnerId },
					{ "album_id", @params.AlbumId },
					{ "photo_ids", @params.PhotoIds },
					{ "rev", @params.Reversed },
					{ "extended", @params.Extended },
					{ "feed_type", @params.FeedType },
					{ "feed", @params.Feed },
					{ "photo_sizes", @params.PhotoSizes },
					{ "offset", @params.Offset },
					{ "count", @params.Count }
				};

			var response = _vk.Call("photos.get", parameters);
			count = response["count"];
			return response.ToReadOnlyCollectionOf<Photo>(x => x);
		}

		/// <summary>
		/// Возвращает количество доступных альбомов пользователя или сообщества. 
		/// </summary>
		/// <param name="userId">Идентификатор пользователя, количество альбомов которого необходимо получить.</param>
		/// <param name="groupId">Идентификатор сообщества, количество альбомов которого необходимо получить. </param>
		/// <returns>После успешного выполнения возвращает количество альбомов с учетом настроек приватности.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getAlbumsCount"/>.
		/// </remarks>
		[ApiVersion("5.37")]
		public int GetAlbumsCount(long? userId = null, long? groupId = null)
		{
			var parameters = new VkParameters
				{
					{"user_id", userId},
					{"group_id", groupId}
				};

			return _vk.Call("photos.getAlbumsCount", parameters);
		}

		/// <summary>
		/// Возвращает список фотографий со страницы пользователя или сообщества. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, фотографии которого нужно получить. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="photoIds">Идентификаторы фотографий, информацию о которых необходимо вернуть</param>
		/// <param name="rev">Порядок сортировки фотографий (1 — антихронологический, 0 — хронологический). флаг, может принимать значения 1 или 0</param>
		/// <param name="extended"><c>true</c> — будет возвращено дополнительное поле likes. По умолчанию поле likes не возвращается. флаг, может принимать значения 1 или 0</param>
		/// <param name="feedType">Тип новости, получаемый в поле type метода newsfeed.get. строка</param>
		/// <param name="feed">Unixtime, который может быть получен методом newsfeed.get в поле date, для получения всех фотографий загруженных пользователем в определённый день либо на которых пользователь был отмечен. Также нужно указать параметр uid пользователя, с которым произошло событие</param>
		/// <param name="photoSizes">Возвращать ли размеры фотографий в специальном формате</param>
		/// <param name="count">Положительное число, максимальное значение 1000</param>
		/// <param name="offset">Положительное число</param>
		/// <returns>После успешного выполнения возвращает массив объектов <see cref="Photo"/>. В случае, если запись на стене о том, что была обновлена фотография профиля, не удалена, будет возвращено дополнительное поле post_id, содержащее идентификатор записи на стене.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getProfile"/>.
		/// </remarks>
		[ApiVersion("5.9")]
		[Obsolete("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования.")]
		public ReadOnlyCollection<Photo> GetProfile(long? ownerId = null, IEnumerable<long> photoIds = null, bool? rev = null, bool? extended = null, string feedType = null, DateTime? feed = null, bool? photoSizes = null, ulong? count = null, ulong? offset = null)
		{
			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"photo_ids", photoIds},
					{"rev", rev},
					{"extended", extended},
					{"feed_type", feedType},
					{"feed", feed},
					{"photo_sizes", photoSizes},
					{"count", count},
					{"offset", offset}
				};

			VkResponseArray response = _vk.Call("photos.getProfile", parameters);

			return response.ToReadOnlyCollectionOf<Photo>(x => x);
		}

		/// <summary>
		/// Возвращает информацию о фотографиях по их идентификаторам. 
		/// </summary>
		/// <param name="photos">Перечисленные через запятую идентификаторы, которые представляют собой идущие через знак подчеркивания id пользователей, разместивших фотографии, и id самих фотографий. Чтобы получить информацию о фотографии в альбоме группы, вместо id пользователя следует указать -id группы.
		/// <example>
		/// Пример значения photos: 1_129207899,6492_135055734, -20629724_271945303 
		/// </example>
		/// <remarks>
		/// Некоторые фотографии, идентификаторы которых могут быть получены через API, закрыты приватностью, и не будут получены. В этом случае следует использовать ключ доступа фотографии (access_key) в её идентификаторе. Пример значения photos: 1_129207899_220df2876123d3542f, 6492_135055734_e0a9bcc31144f67fbd
		/// 
		/// Поле access_key будет возвращено вместе с остальными данными фотографии в методах, которые возвращают фотографии, закрытые приватностью но доступные в данном контексте. Например данное поле имеют фотографии, возвращаемые методом newsfeed.get. список строк, разделенных через запятую, обязательный параметр
		/// </remarks>
		/// </param>
		/// <param name="extended">True — будут возвращены дополнительные поля likes, comments, tags, can_comment, can_repost. Поля comments и tags содержат только количество объектов. По умолчанию данные поля не возвращается</param>
		/// <param name="photoSizes">Возвращать ли доступные размеры фотографии в специальном формате</param>
		/// <returns>После успешного выполнения возвращает список объектов photo</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getById"/>.
		/// </remarks>
		[ApiMethodName("photos.getById", Skip = true)]
		[ApiVersion("5.37")]
		public ReadOnlyCollection<Photo> GetById(IEnumerable<string> photos, bool? extended = null, bool? photoSizes = null)
		{
			var parameters = new VkParameters
				{
					{"photos", photos},
					{"extended", extended},
					{"photo_sizes", photoSizes}
				};

			VkResponseArray response = _vk.Call("photos.getById", parameters);

			return response.ToReadOnlyCollectionOf<Photo>(x => x);
		}

		/// <summary>
		/// Возвращает адрес сервера для загрузки фотографий. 
		/// </summary>
		/// <param name="albumId">Идентификатор альбома</param>
		/// <param name="groupId">Идентификатор сообщества, которому принадлежит альбом (если необходимо загрузить фотографию в альбом сообщества)</param>
		/// <returns>После успешного выполнения возвращает объект <see cref="UploadServerInfo"/></returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getUploadServer"/>.
		/// </remarks>
		[ApiMethodName("photos.getUploadServer", Skip = true)]
		[ApiVersion("5.37")]
		public UploadServerInfo GetUploadServer(long albumId, long? groupId = null)
		{
			var parameters = new VkParameters
				{
					{"album_id", albumId},
					{"group_id", groupId}
				};

			return _vk.Call("photos.getUploadServer", parameters);
		}

		/// <summary>
		/// Возвращает адрес сервера для загрузки фотографии на страницу пользователя. 
		/// </summary>
		/// <returns>После успешного выполнения возвращает объект с единственным полем upload_url. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getProfileUploadServer"/>.
		/// </remarks>
		[Obsolete("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования. Используйте метод GetOwnerPhotoUploadServer")]
		public UploadServerInfo GetProfileUploadServer()
		{
			return GetOwnerPhotoUploadServer();
		}

		/// <summary>
		/// Возвращает адрес сервера для загрузки фотографии на страницу пользователя.
		/// </summary>
		/// <param name="ownerId">Идентификатор сообщества или текущего пользователя.</param>
		/// <returns>
		/// После успешного выполнения возвращает объект с единственным полем upload_url.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getOwnerPhotoUploadServer" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public UploadServerInfo GetOwnerPhotoUploadServer(long? ownerId = null)
		{
			var parameters = new VkParameters
				{
					{"owner_id", ownerId}
				};
			return _vk.Call("photos.getOwnerPhotoUploadServer", parameters);
		}

		/// <summary>
		/// Позволяет получить адрес для загрузки фотографий мультидиалогов. 
		/// </summary>
		/// <param name="chatId">Идентификатор беседы, для которой нужно загрузить фотографию</param>
		/// <param name="cropX">Положительное число</param>
		/// <param name="cropY">Положительное число</param>
		/// <param name="cropWidth">Ширина фотографии после обрезки в px, минимальное значение 200</param>
		/// <returns>После успешного выполнения возвращает объект с единственным полем upload_url. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getChatUploadServer"/>.
		/// </remarks>
		[ApiMethodName("photos.getChatUploadServer", Skip = true)]
		[ApiVersion("5.37")]
		public UploadServerInfo GetChatUploadServer(ulong chatId, ulong? cropX = null, ulong? cropY = null, ulong? cropWidth = null)
		{
			var parameters = new VkParameters
				{
					{ "chat_id", chatId },
					{ "crop_x", cropX },
					{ "crop_y", cropY },
					{ "crop_width", cropWidth }
				};

			return _vk.Call("photos.getChatUploadServer", parameters);
		}

		/// <summary>
		/// Сохраняет фотографию пользователя после успешной загрузки. 
		/// </summary>
		/// <param name="server">Параметр, возвращаемый в результате загрузки фотографии на сервер.</param>
		/// <param name="hash">Параметр, возвращаемый в результате загрузки фотографии на сервер.</param>
		/// <param name="photo">Параметр, возвращаемый в результате загрузки фотографии на сервер.</param>
		/// <returns>После успешного выполнения возвращает объект, содержащий поля photo_hash и photo_src (при работе через VK.api метод вернёт поля photo_src, photo_src_big, photo_src_small). Параметр photo_hash необходим для подтверждения пользователем изменения его фотографии через вызов метода saveProfilePhoto Javascript API. Поле photo_src содержит путь к загруженной фотографии. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.saveProfilePhoto"/>.
		/// </remarks>
		[ApiMethodName("photos.saveProfilePhoto", Skip = true)]
		[ApiVersion("5.9")]
		[Obsolete("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования. Используйте метод SaveOwnerPhoto")]
		public Photo SaveProfilePhoto(string server = null, string hash = null, string photo = null)
		{
			return SaveOwnerPhoto(server, hash, photo);
		}

		/// <summary>
		/// Сохраняет фотографию пользователя после успешной загрузки. 
		/// </summary>
		/// <param name="server">Параметр, возвращаемый в результате загрузки фотографии на сервер.</param>
		/// <param name="hash">Параметр, возвращаемый в результате загрузки фотографии на сервер.</param>
		/// <param name="photo">Параметр, возвращаемый в результате загрузки фотографии на сервер.</param>
		/// <returns>После успешного выполнения возвращает объект, содержащий поля photo_hash и photo_src (при работе через VK.api метод вернёт поля photo_src, photo_src_big, photo_src_small). Параметр photo_hash необходим для подтверждения пользователем изменения его фотографии через вызов метода saveProfilePhoto Javascript API. Поле photo_src содержит путь к загруженной фотографии. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.saveOwnerPhoto"/>.
		/// </remarks>
		[ApiMethodName("photos.saveOwnerPhoto", Skip = true)]
		[ApiVersion("5.37")]
		public Photo SaveOwnerPhoto(string server = null, string hash = null, string photo = null)
		{
			var parameters = new VkParameters
				{
					{"server", server},
					{"hash", hash},
					{"photo", photo}
				};

			return _vk.Call("photos.saveOwnerPhoto", parameters);
		}

		/// <summary>
		/// Сохраняет фотографии после успешной загрузки на URI, полученный методом <see cref="GetWallUploadServer"/>. 
		/// </summary>
		/// <param name="userId">Идентификатор пользователя, на стену которого нужно сохранить фотографию</param>
		/// <param name="groupId">Идентификатор сообщества, на стену которого нужно сохранить фотографию</param>
		/// <param name="photo">Параметр, возвращаемый в результате загрузки фотографии на сервер</param>
		/// <param name="server">Параметр, возвращаемый в результате загрузки фотографии на сервер. целое число</param>
		/// <param name="hash">Параметр, возвращаемый в результате загрузки фотографии на сервер</param>
		/// <returns>После успешного выполнения возвращает массив с загруженной фотографией, возвращённый объект имеет поля id, pid, aid, owner_id, src, src_big, src_small, created. В случае наличия фотографий в высоком разрешении также будут возвращены адреса с названиями src_xbig и src_xxbig. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.saveWallPhoto"/>.
		/// </remarks>
		[ApiMethodName("photos.saveWallPhoto", Skip = true)]
		[ApiVersion("5.37")]
		public ReadOnlyCollection<Photo> SaveWallPhoto(string photo, ulong? userId = null, ulong? groupId = null, long? server = null, string hash = null)
		{
			var parameters = new VkParameters
				{
					{"user_id", userId},
					{"group_id", groupId},
					{"photo", photo},
					{"server", server},
					{"hash", hash}
				};

			VkResponseArray response = _vk.Call("photos.saveWallPhoto", parameters);
			return response.ToReadOnlyCollectionOf<Photo>(x => x);
		}

		/// <summary>
		/// Возвращает адрес сервера для загрузки фотографии на стену пользователя или сообщества. 
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества, на стену которого нужно загрузить фото (без знака «минус»)</param>
		/// <returns>После успешного выполнения возвращает объект <see cref="UploadServerInfo"/>.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getWallUploadServer"/>.
		/// </remarks>
		[ApiMethodName("photos.getWallUploadServer", Skip = true)]
		[ApiVersion("5.37")]
		public UploadServerInfo GetWallUploadServer(long? groupId = null)
		{
			var parameters = new VkParameters
				{
					{"group_id", groupId}
				};

			return _vk.Call("photos.getWallUploadServer", parameters);
		}

		/// <summary>
		/// Возвращает адрес сервера для загрузки фотографии в личное сообщение пользователю. 
		/// </summary>
		/// <returns>После успешного выполнения возвращает объект <see cref="UploadServerInfo"/>.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getMessagesUploadServer"/>.
		/// </remarks>
		[ApiVersion("5.37")]
		public UploadServerInfo GetMessagesUploadServer()
		{
			return _vk.Call("photos.getMessagesUploadServer", VkParameters.Empty);
		}

		/// <summary>
		/// Сохраняет фотографию после успешной загрузки на URI, полученный методом <see cref="GetMessagesUploadServer"/>. 
		/// </summary>
		/// <param name="photo">Параметр, возвращаемый в результате загрузки фотографии на сервер</param>
		/// <returns>После успешного выполнения возвращает массив с загруженной фотографией, возвращённый объект имеет поля id, pid, aid, owner_id, src, src_big, src_small, created. В случае наличия фотографий в высоком разрешении также будут возвращены адреса с названиями src_xbig и src_xxbig. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.saveMessagesPhoto"/>.
		/// </remarks>
		[ApiMethodName("photos.saveMessagesPhoto", Skip = true)]
		[ApiVersion("5.37")]
		public Photo SaveMessagesPhoto(string photo)
		{
			var parameters = new VkParameters
				{
					{"photo", photo}
				};

			return _vk.Call("photos.saveMessagesPhoto", parameters);
		}

		/// <summary>
		/// Позволяет пожаловаться на фотографию.
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит фотография</param>
		/// <param name="photoId">Идентификатор фотографии</param>
		/// <param name="reason">Тип жалобы</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.report"/>.
		/// </remarks>
		[ApiMethodName("photos.report", Skip = true)]
		[ApiVersion("5.37")]
		public bool Report(long ownerId, ulong photoId, ContentReportType reason)
		{
			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"photo_id", photoId},
					{"reason", reason}
				};

			return _vk.Call("photos.report", parameters);
		}

		/// <summary>
		/// Позволяет пожаловаться на комментарий к фотографии. 
		/// </summary>
		/// <param name="ownerId">Идентификатор владельца фотографии к которой оставлен комментарий</param>
		/// <param name="commentId">Идентификатор комментария</param>
		/// <param name="reason">Тип жалобы</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.reportComment"/>.
		/// </remarks>
		[ApiMethodName("photos.reportComment", Skip = true)]
		[ApiVersion("5.37")]
		public bool ReportComment(long ownerId, ulong commentId, ContentReportType reason)
		{
			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"comment_id", commentId},
					{"reason", reason}
				};

			return _vk.Call("photos.reportComment", parameters);
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
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.search" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public ReadOnlyCollection<Photo> Search(out int count,PhotoSearchParams @params)
		{
			var parameters = new VkParameters
				{
					{ "q", HttpUtility.UrlEncode(@params.Query) },
					{ "lat", @params.Latitude },
					{ "long", @params.Longitude },
					{ "start_time", @params.StartTime },
					{ "end_time", @params.EndTime },
					{ "sort", @params.Sort },
					{ "offset", @params.Offset },
					{ "count", @params.Count },
					{ "radius", @params.Radius }
				};

			var response = _vk.Call("photos.search", parameters, true);
			count = response["count"];
			return response["items"].ToReadOnlyCollectionOf<Photo>(x => x);
		}

		/// <summary>
		/// Сохраняет фотографии после успешной загрузки.
		/// </summary>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов <see cref="Photo" />.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.save" />.
		/// </remarks>
		[ApiMethodName("photos.save", Skip = true)]
		[ApiVersion("5.37")]
		public ReadOnlyCollection<Photo> Save(PhotoSaveParams @params)
		{
			var parameters = new VkParameters
				{
					{ "album_id", @params.AlbumId },
					{ "group_id", @params.GroupId },
					{ "server", @params.Server },
					{ "photos_list", @params.PhotosList },
					{ "hash", @params.Hash },
					{ "latitude", @params.Latitude },
					{ "longitude", @params.Longitude },
					{ "caption", @params.Caption }
				};

			VkResponseArray response = _vk.Call("photos.save", parameters);
			return response.ToReadOnlyCollectionOf<Photo>(x => x);
		}

		/// <summary>
		/// Позволяет скопировать фотографию в альбом &quot;Сохраненные фотографии&quot; 
		/// </summary>
		/// <param name="ownerId">Идентификатор владельца фотографии</param>
		/// <param name="photoId">Индентификатор фотографии</param>
		/// <param name="accessKey">Специальный код доступа для приватных фотографий</param>
		/// <returns>Возвращает идентификатор созданной фотографии.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.copy"/>.
		/// </remarks>
		[ApiMethodName("photos.copy", Skip = true)]
		[ApiVersion("5.37")]
		public long Copy(long ownerId, ulong photoId, string accessKey = null)
		{
			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"photo_id", photoId},
					{"access_key", accessKey}
				};

			return _vk.Call("photos.copy", parameters);
		}

		/// <summary>
		/// Изменяет описание у выбранной фотографии. 
		/// </summary>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>После успешного выполнения возвращает <c>true</c>.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.edit"/>.
		/// </remarks>
		[ApiMethodName("photos.edit", Skip = true)]
		[ApiVersion("5.37")]
		public bool Edit(PhotoEditParams @params)
		{
			var parameters = new VkParameters
				{
					{ "owner_id", @params.OwnerId },
					{ "photo_id", @params.PhotoId },
					{ "caption", @params.Caption },
					{ "latitude", @params.Latitude },
					{ "longitude", @params.Longitude },
					{ "place_str", @params.PlaceStr },
					{ "foursquare_id", @params.FoursquareId },
					{ "delete_place", @params.DeletePlace }
				};

			return _vk.Call("photos.edit", parameters);
		}

		/// <summary>
		/// Переносит фотографию из одного альбома в другой. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="targetAlbumId">Идентификатор альбома, в который нужно переместить фотографию</param>
		/// <param name="photoId">Идентификатор фотографии, которую нужно перенести</param>
		/// <returns>После успешного выполнения возвращает <c>true</c>.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.move"/>.
		/// </remarks>
		[ApiMethodName("photos.move", Skip = true)]
		[ApiVersion("5.37")]
		public bool Move(long targetAlbumId, ulong photoId, long? ownerId = null)
		{
			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"target_album_id", targetAlbumId},
					{"photo_id", photoId}
				};

			return _vk.Call("photos.move", parameters);
		}

		/// <summary>
		/// Делает фотографию обложкой альбома. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="photoId">Идентификатор фотографии</param>
		/// <param name="albumId">Идентификатор альбома</param>
		/// <returns>После успешного выполнения возвращает <c>true</c>.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.makeCover"/>.
		/// </remarks>
		[ApiMethodName("photos.makeCover", Skip = true)]
		[ApiVersion("5.37")]
		public bool MakeCover(ulong photoId, long? ownerId = null, long? albumId = null)
		{
			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"photo_id", photoId},
					{"album_id", albumId}
				};

			return _vk.Call("photos.makeCover", parameters);
		}

		/// <summary>
		/// Меняет порядок альбома в списке альбомов пользователя. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит альбом. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="albumId">Идентификатор альбома</param>
		/// <param name="before">Идентификатор альбома, перед которым следует поместить альбом</param>
		/// <param name="after">Идентификатор альбома, после которого следует поместить альбом</param>
		/// <returns>После успешного выполнения возвращает <c>true</c>.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.reorderAlbums"/>.
		/// </remarks>
		[ApiMethodName("photos.reorderAlbums", Skip = true)]
		[ApiVersion("5.37")]
		public bool ReorderAlbums(long albumId, long? ownerId = null, long? before = null, long? after = null)
		{
			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"album_id", albumId},
					{"before", before},
					{"after", after}
				};

			return _vk.Call("photos.reorderAlbums", parameters);
		}

		/// <summary>
		/// Меняет порядок фотографии в списке фотографий альбома пользователя. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="photoId">Идентификатор фотографии</param>
		/// <param name="before">Идентификатор фотографии, перед которой следует поместить фотографию</param>
		/// <param name="after">Идентификатор фотографии, после которой следует поместить фотографию</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.reorderPhotos"/>.
		/// </remarks>
		[ApiMethodName("photos.reorderPhotos", Skip = true)]
		[ApiVersion("5.37")]
		public bool ReorderPhotos(ulong photoId, long? ownerId = null, long? before = null, long? after = null)
		{
			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"photo_id", photoId},
					{"before", before},
					{"after", after}
				};

			return _vk.Call("photos.reorderPhotos", parameters);
		}

		/// <summary>
		/// Возвращает все фотографии пользователя или сообщества в антихронологическом порядке.
		/// </summary>
		/// <param name="count">Количество пользователей, которым нравится текущая фотография.</param>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов <see cref="Photo" />.
		/// <remarks>
		/// Если был задан параметр extended — будет возвращено поле likes:
		/// user_likes: 1 — текущему пользователю нравится данная фотография, 0 - не указано.
		/// count — количество пользователей, которым нравится текущая фотография.
		/// Если был задан параметр photo_sizes=1, вместо полей width и height возвращаются размеры копий фотографии в специальном формате.
		/// </remarks>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getAll" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public ReadOnlyCollection<Photo> GetAll(out int count,PhotoGetAllParams @params)
		{
			var parameters = new VkParameters
				{
					{ "owner_id", @params.OwnerId },
					{ "extended", @params.Extended },
					{ "offset", @params.Offset },
					{ "count", @params.Count },
					{ "photo_sizes", @params.PhotoSizes },
					{ "no_service_albums", @params.NoServiceAlbums },
					{ "need_hidden", @params.NeedHidden },
					{ "skip_hidden", @params.SkipHidden }
				};

			var response = _vk.Call("photos.getAll", parameters);
			count = response["count"];
			return response["items"].ToReadOnlyCollectionOf<Photo>(x => x);
		}

		/// <summary>
		/// Возвращает список фотографий, на которых отмечен пользователь 
		/// </summary>
		/// <param name="count">Количество.</param>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>После успешного выполнения возвращает список объектов photo. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getUserPhotos"/>.
		/// </remarks>
		[ApiMethodName("photos.getUserPhotos")]
		[VkValue("userId", 178964623)]
		[VkValue("count", 2)]
		[VkValue("offset", 3)]
		[ApiVersion("5.37")]
		public ReadOnlyCollection<Photo> GetUserPhotos(out int count, PhotoGetUserPhotosParams @params)
		{
			var parameters = new VkParameters
				{
					{ "user_id", @params.UserId },
					{ "count", @params.Count },
					{ "offset", @params.Offset },
					{ "extended", @params.Extended },
					{ "sort", @params.Sort }
				};

			var response = _vk.Call("photos.getUserPhotos", parameters);
			count = response["count"];
			return response["items"].ToReadOnlyCollectionOf<Photo>(x => x);
		}

		/// <summary>
		/// Удаляет указанный альбом для фотографий у текущего пользователя 
		/// </summary>
		/// <param name="albumId">Идентификатор альбома</param>
		/// <param name="groupId">Идентификатор сообщества, в котором размещен альбом.</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.deleteAlbum"/>.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool DeleteAlbum(long albumId, long? groupId = null)
		{
			var parameters = new VkParameters
				{
					{"album_id", albumId},
					{"group_id", groupId}
				};

			return _vk.Call("photos.deleteAlbum", parameters);
		}

		/// <summary>
		/// Удаление фотографии на сайте. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="photoId">Идентификатор фотографии</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.delete"/>.
		/// </remarks>
		[ApiMethodName("photos.delete", Skip = true)]
		[ApiVersion("5.37")]
		public bool Delete(ulong photoId, long? ownerId = null)
		{
			var parameters = new VkParameters
				{
					{ "owner_id", ownerId },
					{ "photo_id", photoId }
				};

			return _vk.Call("photos.delete", parameters);
		}

		/// <summary>
		/// Восстанавливает удаленную фотографию.
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="photoId">Идентификатор фотографии</param>
		/// <returns>После успешного выполнения возвращает <c>true</c>.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.restore"/>.
		/// </remarks>
		[ApiMethodName("photos.restore", Skip = true)]
		[ApiVersion("5.37")]
		public bool Restore(ulong photoId, long? ownerId = null)
		{
			var parameters = new VkParameters
				{
					{ "owner_id", ownerId },
					{ "photo_id", photoId }
				};

			return _vk.Call("photos.restore", parameters);
		}

		/// <summary>
		/// Подтверждает отметку на фотографии. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="photoId">Идентификатор фотографии</param>
		/// <param name="tagId">Идентификатор отметки на фотографии</param>
		/// <returns>После успешного выполнения возвращает <c>true</c>.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.confirmTag"/>.
		/// </remarks>
		[ApiMethodName("photos.confirmTag", Skip = true)]
		[ApiVersion("5.37")]
		public bool ConfirmTag(ulong photoId, ulong tagId, long? ownerId = null)
		{
			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"photo_id", photoId},
					{"tag_id", tagId}
				};

			return _vk.Call("photos.confirmTag", parameters);
		}

		/// <summary>
		/// Возвращает список комментариев к фотографии.
		/// </summary>
		/// <param name="count">Количество.</param>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов <see cref="Comment" />.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getComments" />.
		/// </remarks>
		[ApiMethodName("photos.getComments")]
		[VkValue("owner_id", 1)]
		[VkValue("photo_id", 263219735)]
		[ApiVersion("5.37")]
		public ReadOnlyCollection<Comment> GetComments(out int count, PhotoGetCommentsParams @params)
		{
			var parameters = new VkParameters
				{
					{ "owner_id", @params.OwnerId },
					{ "photo_id", @params.PhotoId },
					{ "need_likes", @params.NeedLikes },
					{ "start_comment_id", @params.StartCommentId },
					{ "offset", @params.Offset },
					{ "count", @params.Count },
					{ "sort", @params.Sort },
					{ "access_key", @params.AccessKey },
					{ "extended", @params.Extended },
					{ "fields", @params.Fields }
				};

			var response = _vk.Call("photos.getComments", parameters);
			count = response["count"];
			return response["items"].ToReadOnlyCollectionOf<Comment>(x => x);
		}

		/// <summary>
		/// Возвращает отсортированный в антихронологическом порядке список всех комментариев к конкретному альбому или ко всем альбомам пользователя.
		/// </summary>
		/// <param name="count">Количество комментариев</param>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов <see cref="Comment" />.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getAllComments" />.
		/// </remarks>
		[ApiMethodName("photos.getAllComments", Skip = true)]
		[ApiVersion("5.37")]
		public ReadOnlyCollection<Comment> GetAllComments(out int count, PhotoGetAllCommentsParams @params)
		{
			var parameters = new VkParameters
				{
					{ "owner_id", @params.OwnerId },
					{ "album_id", @params.AlbumId },
					{ "need_likes", @params.NeedLikes },
					{ "offset", @params.Offset },
					{ "count", @params.Count }
				};

			var response = _vk.Call("photos.getAllComments", parameters);
			count = response["count"];
			return response["items"].ToReadOnlyCollectionOf<Comment>(x => x);
		}

		/// <summary>
		/// Создает новый комментарий к фотографии.
		/// </summary>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// После успешного выполнения возвращает идентификатор созданного комментария.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.createComment" />.
		/// </remarks>
		[ApiMethodName("photos.createComment", Skip = true)]
		[ApiVersion("5.37")]
		public long CreateComment(PhotoCreateCommentParams @params)
		{
			// TODO сделать по-нормально работу с аттачментами
			if (@params.Message.Length > 2048)
			{
				throw new Exception("Максимальное количество символов: 2048.");
			}
			var parameters = new VkParameters
				{
					{ "owner_id", @params.OwnerId },
					{ "photo_id", @params.PhotoId },
					{ "message", @params.Message },
					{ "attachments", @params.Attachments },
					{ "from_group", @params.FromGroup },
					{ "reply_to_comment", @params.ReplyToComment },
					{ "sticker_id", @params.StickerId },
					{ "access_key", @params.AccessKey },
					{ "guid", @params.Guid }
				};

			return _vk.Call("photos.createComment", parameters);
		}

		/// <summary>
		/// Удаляет комментарий к фотографии. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="commentId">Идентификатор комментария</param>
		/// <returns>После успешного выполнения возвращает true (false, если комментарий не найден). 
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.deleteComment"/>.
		/// </remarks>
		[ApiMethodName("photos.deleteComment", Skip = true)]
		[ApiVersion("5.37")]
		public bool DeleteComment(ulong commentId, long? ownerId = null)
		{
			var parameters = new VkParameters
				{
					{ "owner_id", ownerId },
					{ "comment_id", commentId }
				};

			return _vk.Call("photos.deleteComment", parameters);
		}

		/// <summary>
		/// Восстанавливает удаленный комментарий к фотографии. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="commentId">Идентификатор удаленного комментария</param>
		/// <returns>После успешного выполнения возвращает true (false, если комментарий с таким идентификатором не является удаленным).</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.restoreComment"/>.
		/// </remarks>
		[ApiMethodName("photos.restoreComment", Skip = true)]
		[ApiVersion("5.37")]
		public long RestoreComment(ulong commentId, long? ownerId = null)
		{
			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"comment_id", commentId}
				};

			return _vk.Call("photos.restoreComment", parameters);
		}

		/// <summary>
		/// Изменяет текст комментария к фотографии. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="commentId">Идентификатор комментария</param>
		/// <param name="message">Новый текст комментария (является обязательным, если не задан параметр attachments)</param>
		/// <param name="attachments">Новый список объектов, приложенных к комментарию и разделённых символом &quot;,&quot;. Поле attachments представляется в формате: &lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt;,&lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt; &lt;type&gt; — тип медиа-вложения: 
		/// photo — фотография 
		/// video — видеозапись 
		/// audio — аудиозапись 
		/// doc — документ 
		/// &lt;owner_id&gt; — идентификатор владельца медиа-вложения 
		/// &lt;media_id&gt; — идентификатор медиа-вложения.
		/// <example>
		/// Например:
		/// photo100172_166443618,photo66748_265827614
		/// </example>
		/// Параметр является обязательным, если не задан параметр message. список строк, разделенных через запятую</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.editComment"/>.
		/// </remarks>
		[ApiMethodName("photos.editComment", Skip = true)]
		[ApiVersion("5.37")]
		public bool EditComment(ulong commentId, string message, long? ownerId = null, IEnumerable<Attachment> attachments = null)
		{
			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"comment_id", commentId},
					{"message", message},
					{"attachments", attachments}
				};

			return _vk.Call("photos.editComment", parameters);
		}

		/// <summary>
		/// Возвращает список отметок на фотографии. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="photoId">Идентификатор фотографии</param>
		/// <param name="accessKey">Строковый ключ доступа, который може быть получен при получении объекта фотографии</param>
		/// <returns>После успешного выполнения возвращает массив объектов <see cref="Tag"/>.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getTags"/>.
		/// </remarks>
		[ApiMethodName("photos.getTags", Skip = true)]
		[ApiVersion("5.37")]
		public ReadOnlyCollection<Tag> GetTags(ulong photoId, long? ownerId = null, string accessKey = null)
		{
			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"photo_id", photoId},
					{"access_key", accessKey}
				};

			VkResponseArray response = _vk.Call("photos.getTags", parameters);

			return response.ToReadOnlyCollectionOf<Tag>(x => x);
		}

		/// <summary>
		/// Добавляет отметку на фотографию.
		/// </summary>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// После успешного выполнения возвращает идентификатор созданной отметки.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.putTag" />.
		/// </remarks>
		[ApiMethodName("photos.putTag", Skip = true)]
		[ApiVersion("5.37")]
		public ulong PutTag(PhotoPutTagParams @params)
		{
			var parameters = new VkParameters
				{
					{ "owner_id", @params.OwnerId },
					{ "photo_id", @params.PhotoId },
					{ "user_id", @params.UserId },
					{ "x", @params.X },
					{ "y", @params.Y },
					{ "x2", @params.X2 },
					{ "y2", @params.Y2 }
				};

			return _vk.Call("photos.putTag", parameters);
		}

		/// <summary>
		/// Удаляет отметку с фотографии. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="photoId">Идентификатор фотографии</param>
		/// <param name="tagId">Идентификатор отметки</param>
		/// <returns>После успешного выполнения возвращает <c>true</c>.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.removeTag"/>.
		/// </remarks>
		[ApiMethodName("photos.removeTag", Skip = true)]
		[ApiVersion("5.37")]
		public bool RemoveTag(ulong tagId, ulong photoId, long? ownerId = null)
		{
			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"photo_id", photoId},
					{"tag_id", tagId}
				};

			return _vk.Call("photos.removeTag", parameters);
		}

		/// <summary>
		/// Возвращает список фотографий, на которых есть непросмотренные отметки.
		/// </summary>
		/// <param name="countTotal">Общее количество.</param>
		/// <param name="offset">Смещение, необходимое для получения определённого подмножества фотографий</param>
		/// <param name="count">Количество фотографий, которые необходимо вернуть. положительное число, максимальное значение 100, по умолчанию 20</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов <see cref="Photo" />.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getNewTags" />.
		/// </remarks>
		[ApiMethodName("photos.getNewTags", Skip = true)]
		[ApiVersion("5.37")]
		public ReadOnlyCollection<Photo> GetNewTags(out int countTotal, uint? offset = null, uint? count = null)
		{
			var parameters = new VkParameters
				{
					{"offset", offset},
					{"count", count}
				};

			var response = _vk.Call("photos.getNewTags", parameters);
			countTotal = response["count"];
			return response["items"].ToReadOnlyCollectionOf<Photo>(x => x);
		}
	}
}