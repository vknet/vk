using VkNet.Exception;
using VkNet.Model.RequestParams.Photo;

namespace VkNet.Categories
{
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System;

	using Utils;
	using Enums;
	using Enums.SafetyEnums;
	using Model;
	using Model.Attachments;
	
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
			var parameters = new VkParameters
				{
					{ "title", @params.Title },
					{ "group_id", @params.GroupId },
					{ "description", @params.Description },
					{ "privacy_view", @params.PrivacyView },
					{ "privacy_comment", @params.PrivacyComment },
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
					{ "privacy_view", @params.PrivacyView },
					{ "privacy_comment", @params.PrivacyComment },
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
		[ApiVersion("5.37")]
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
					{ "rev", @params.Rev },
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
		/// <param name="rev">порядок сортировки фотографий (1 — антихронологический, 0 — хронологический). флаг, может принимать значения 1 или 0</param>
		/// <param name="extended">1 — будет возвращено дополнительное поле likes. По умолчанию поле likes не возвращается. флаг, может принимать значения 1 или 0</param>
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
		public ReadOnlyCollection<Photo> GetProfile(long? ownerId = null, IEnumerable<long> photoIds = null, bool? rev = null, bool? extended = null, string feedType = null, DateTime? feed = null, bool? photoSizes = null, int? count = null, int? offset = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => offset);
			VkErrors.ThrowIfNumberIsNegative(() => count);

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
		[ApiVersion("5.9")]
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
		[ApiVersion("5.9")]
		public UploadServerInfo GetUploadServer(long albumId, long? groupId = null)
		{
			var parameters = new VkParameters
				{
					{"album_id", albumId},
					{"group_id", groupId}
				};

			VkResponse response = _vk.Call("photos.getUploadServer", parameters);

			return response;
		}

		/// <summary>
		/// Возвращает адрес сервера для загрузки фотографии на страницу пользователя. 
		/// </summary>
		/// <returns>После успешного выполнения возвращает объект с единственным полем upload_url. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getProfileUploadServer"/>.
		/// </remarks>
		[ApiVersion("5.9")]
		public UploadServerInfo GetProfileUploadServer()
		{
			return _vk.Call("photos.getProfileUploadServer", VkParameters.Empty);
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
		[ApiVersion("5.9")]
		public UploadServerInfo GetChatUploadServer(long chatId, long? cropX = null, long? cropY = null, long? cropWidth = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => chatId);
			VkErrors.ThrowIfNumberIsNegative(() => cropX);
			VkErrors.ThrowIfNumberIsNegative(() => cropY);
			VkErrors.ThrowIfNumberIsNegative(() => cropWidth);

			var parameters = new VkParameters
				{
					{"chat_id", chatId},
					{"crop_x", cropX},
					{"crop_y", cropY},
					{"crop_width", cropWidth}
				};

			VkResponse response = _vk.Call("photos.getChatUploadServer", parameters);
			return response;
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
		public Photo SaveProfilePhoto(string server = null, string hash = null, string photo = null)
		{
			var parameters = new VkParameters
				{
					{"server", server},
					{"hash", hash},
					{"photo", photo}
				};

			VkResponse response = _vk.Call("photos.saveProfilePhoto", parameters);

			return response;
		}

		/// <summary>
		/// Сохраняет фотографии после успешной загрузки на URI, полученный методом <see cref="GetWallUploadServer"/>. 
		/// </summary>
		/// <param name="userId">Идентификатор пользователя, на стену которого нужно сохранить фотографию</param>
		/// <param name="groupId">Идентификатор сообщества, на стену которого нужно сохранить фотографию</param>
		/// <param name="photo">параметр, возвращаемый в результате загрузки фотографии на сервер</param>
		/// <param name="server">Параметр, возвращаемый в результате загрузки фотографии на сервер. целое число</param>
		/// <param name="hash">Параметр, возвращаемый в результате загрузки фотографии на сервер</param>
		/// <returns>После успешного выполнения возвращает массив с загруженной фотографией, возвращённый объект имеет поля id, pid, aid, owner_id, src, src_big, src_small, created. В случае наличия фотографий в высоком разрешении также будут возвращены адреса с названиями src_xbig и src_xxbig. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.saveWallPhoto"/>.
		/// </remarks>
		[ApiMethodName("photos.saveWallPhoto", Skip = true)]
		[ApiVersion("5.9")]
		public ReadOnlyCollection<Photo> SaveWallPhoto(string photo, long? userId = null, long? groupId = null, long? server = null, string hash = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => userId);
			VkErrors.ThrowIfNumberIsNegative(() => groupId);

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
		[ApiVersion("5.9")]
		public UploadServerInfo GetWallUploadServer(long? groupId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);

			var parameters = new VkParameters
				{
					{"group_id", groupId}
				};

			VkResponse response = _vk.Call("photos.getWallUploadServer", parameters);

			return response;
		}

		/// <summary>
		/// Возвращает адрес сервера для загрузки фотографии в личное сообщение пользователю. 
		/// </summary>
		/// <returns>После успешного выполнения возвращает объект <see cref="UploadServerInfo"/>.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getMessagesUploadServer"/>.
		/// </remarks>
		[ApiVersion("5.9")]
		public UploadServerInfo GetMessagesUploadServer()
		{
			VkResponse response = _vk.Call("photos.getMessagesUploadServer", VkParameters.Empty);
			return response;
		}

		/// <summary>
		/// Сохраняет фотографию после успешной загрузки на URI, полученный методом <see cref="GetMessagesUploadServer"/>. 
		/// </summary>
		/// <param name="photo">параметр, возвращаемый в результате загрузки фотографии на сервер</param>
		/// <returns>После успешного выполнения возвращает массив с загруженной фотографией, возвращённый объект имеет поля id, pid, aid, owner_id, src, src_big, src_small, created. В случае наличия фотографий в высоком разрешении также будут возвращены адреса с названиями src_xbig и src_xxbig. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.saveMessagesPhoto"/>.
		/// </remarks>
		[ApiMethodName("photos.saveMessagesPhoto", Skip = true)]
		[ApiVersion("5.9")]
		public Photo SaveMessagesPhoto(string photo)
		{
			var parameters = new VkParameters
				{
					{"photo", photo}
				};

			VkResponse response = _vk.Call("photos.saveMessagesPhoto", parameters);
			return response;
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
		[ApiVersion("5.9")]
		public bool Report(long ownerId, long photoId, VideoReportType reason)
		{
			VkErrors.ThrowIfNumberIsNegative(() => photoId);

			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"photo_id", photoId},
					{"reason", reason}
				};

			VkResponse response = _vk.Call("photos.report", parameters);

			return response;
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
		[ApiVersion("5.9")]
		public bool ReportComment(long ownerId, long commentId, VideoReportType reason)
		{
			VkErrors.ThrowIfNumberIsNegative(() => commentId);

			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"comment_id", commentId},
					{"reason", reason}
				};

			VkResponse response = _vk.Call("photos.reportComment", parameters);

			return response;
		}

		/// <summary>
		/// Осуществляет поиск изображений по местоположению или описанию. 
		/// </summary>
		/// <param name="query">Строка поискового запроса</param>
		/// <param name="lat">Географическая широта отметки, заданная в градусах (от -90 до 90)</param>
		/// <param name="longitude">Географическая долгота отметки, заданная в градусах (от -180 до 180)</param>
		/// <param name="startTime">Время в формате unixtime, не раньше которого должны были быть загружены найденные фотографии. положительное число</param>
		/// <param name="endTime">Время в формате unixtime, не позже которого должны были быть загружены найденные фотографии. положительное число</param>
		/// <param name="sort">True – сортировать по количеству отметок «Мне нравится», false – сортировать по дате добавления фотографии. положительное число</param>
		/// <param name="offset">смещение относительно первой найденной фотографии для выборки определенного подмножества. положительное число</param>
		/// <param name="count">количество возвращаемых фотографий. положительное число, по умолчанию 100, максимальное значение 1000</param>
		/// <param name="radius">радиус поиска в метрах. (работает очень приближенно, поэтому реальное расстояние до цели может отличаться от заданного). Может принимать значения: 10, 100, 800, 6000, 50000 положительное число, по умолчанию 5000</param>
		/// <returns>После успешного выполнения возвращает список объектов фотографий.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.search"/>.
		/// </remarks>
		[ApiVersion("5.9")]
		public ReadOnlyCollection<Photo> Search(string query = null, double? lat = null, double? longitude = null, DateTime? startTime = null, DateTime? endTime = null, bool? sort = null, int? count = null, int? offset = null, int? radius = null)
		{
			// todo add check for latitude and longitude throught VkErrors.ThrowIfNumberNotInRange
			// TODO add verstion with totalCount
			VkErrors.ThrowIfNumberIsNegative(() => offset);
			VkErrors.ThrowIfNumberIsNegative(() => count);
			VkErrors.ThrowIfNumberIsNegative(() => radius);

			//TODO do this check later
//            VkErrors.ThrowIfNumberNotInRange(lat, -90, 90);

			var parameters = new VkParameters
				{
					{"q", query},
					{"lat", lat},
					{"long", longitude},
					{"start_time", startTime},
					{"end_time", endTime},
					{"sort", sort},
					{"offset", offset},
					{"count", count},
					{"radius", radius}
				};

			VkResponseArray response = _vk.Call("photos.search", parameters, true);

			return response.ToReadOnlyCollectionOf<Photo>(x => x);
		}

		/// <summary>
		/// Сохраняет фотографии после успешной загрузки. 
		/// </summary>
		/// <param name="albumId">Идентификатор альбома, в который необходимо сохранить фотографии</param>
		/// <param name="groupId">Идентификатор сообщества, в которое необходимо сохранить фотографии</param>
		/// <param name="server">параметр, возвращаемый в результате загрузки фотографий на сервер</param>
		/// <param name="photosList">Параметр, возвращаемый в результате загрузки фотографий на сервер</param>
		/// <param name="hash">Параметр, возвращаемый в результате загрузки фотографий на сервер</param>
		/// <param name="latitude">Географическая широта, заданная в градусах (от -90 до 90)</param>
		/// <param name="longitude">Географическая долгота, заданная в градусах (от -180 до 180)</param>
		/// <param name="caption">Текст описания фотографии</param>
		/// <param name="description">Текст описания альбома</param>
		/// <returns>После успешного выполнения возвращает список объектов <see cref="Photo"/>. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.save"/>.
		/// </remarks>
		[ApiMethodName("photos.save", Skip = true)]
		[ApiVersion("5.9")]
		public ReadOnlyCollection<Photo> Save(long? albumId = null, long? groupId = null, string server = null, string photosList = null, string hash = null, double? latitude = null, double? longitude = null, string caption = null, string description = null)
		{

			var parameters = new VkParameters
				{
					{"album_id", albumId},
					{"group_id", groupId},
					{"server", server},
					{"photos_list", photosList},
					{"hash", hash},
					{"latitude", latitude},
					{"longitude", longitude},
					{"caption", caption},
					{"description", description}
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
		[ApiVersion("5.9")]
		public long Copy(long ownerId, long photoId, string accessKey = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => photoId);

			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"photo_id", photoId},
					{"access_key", accessKey}
				};

			VkResponse response = _vk.Call("photos.copy", parameters);

			return response;
		}

		/// <summary>
		/// Изменяет описание у выбранной фотографии. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="photoId">Идентификатор фотографии</param>
		/// <param name="caption">Новый текст описания к фотографии. Если параметр не задан, то считается, что он равен пустой строке.</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.edit"/>.
		/// </remarks>
		[ApiMethodName("photos.edit", Skip = true)]
		[ApiVersion("5.9")]
		public bool Edit(long photoId, long? ownerId = null, string caption = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => photoId);

			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"photo_id", photoId},
					{"caption", caption}
				};

			VkResponse response = _vk.Call("photos.edit", parameters);

			return response;
		}

		/// <summary>
		/// Переносит фотографию из одного альбома в другой. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="targetAlbumId">Идентификатор альбома, в который нужно переместить фотографию</param>
		/// <param name="photoId">Идентификатор фотографии, которую нужно перенести</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.move"/>.
		/// </remarks>
		[ApiMethodName("photos.move", Skip = true)]
		[ApiVersion("5.9")]
		public bool Move(long targetAlbumId, long photoId, long? ownerId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => targetAlbumId);
			VkErrors.ThrowIfNumberIsNegative(() => photoId);

			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"target_album_id", targetAlbumId},
					{"photo_id", photoId}
				};

			VkResponse response = _vk.Call("photos.move", parameters);

			return response;
		}

		/// <summary>
		/// Делает фотографию обложкой альбома. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="photoId">Идентификатор фотографии</param>
		/// <param name="albumId">Идентификатор альбома/param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.makeCover"/>.
		/// </remarks>
		[ApiMethodName("photos.makeCover", Skip = true)]
		[ApiVersion("5.9")]
		public bool MakeCover(long photoId, long? ownerId = null, long? albumId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => photoId);
			VkErrors.ThrowIfNumberIsNegative(() => albumId);

			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"photo_id", photoId},
					{"album_id", albumId}
				};

			VkResponse response = _vk.Call("photos.makeCover", parameters);

			return response;
		}

		/// <summary>
		/// Меняет порядок альбома в списке альбомов пользователя. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит альбом. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="albumId">Идентификатор альбома</param>
		/// <param name="before">Идентификатор альбома, перед которым следует поместить альбом</param>
		/// <param name="after">Идентификатор альбома, после которого следует поместить альбом</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.reorderAlbums"/>.
		/// </remarks>
		[ApiMethodName("photos.reorderAlbums", Skip = true)]
		[ApiVersion("5.9")]
		public bool ReorderAlbums(long albumId, long? ownerId = null, long? before = null, long? after = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => albumId);
			VkErrors.ThrowIfNumberIsNegative(() => before);
			VkErrors.ThrowIfNumberIsNegative(() => after);

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
		[ApiVersion("5.9")]
		public bool ReorderPhotos(long photoId, long? ownerId = null, long? before = null, long? after = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => photoId);
			VkErrors.ThrowIfNumberIsNegative(() => before);
			VkErrors.ThrowIfNumberIsNegative(() => after);

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
		/// <param name="ownerId">Идентификатор пользователя или сообщества, фотографии которого нужно получить. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="extended">True — возвращать расширенную информацию о фотографиях</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества фотографий. По умолчанию — 0. положительное число</param>
		/// <param name="count">Число фотографий, информацию о которых необходимо получить. положительное число, по умолчанию 20, максимальное значение 200</param>
		/// <param name="photoSizes">True — будут возвращены размеры фотографий в специальном формате</param>
		/// <param name="noServiceAlbums">false — вернуть все фотографии, включая находящиеся в сервисных альбомах, таких как &quot;Фотографии на моей стене&quot; (по умолчанию);  true — вернуть фотографии только из стандартных альбомов пользователя или сообщества</param>
		/// <returns>После успешного выполнения возвращает список объектов <see cref="Photo"/>.
		/// <remarks>
		/// Если был задан параметр extended — будет возвращено поле likes: 
		/// user_likes: 1 — текущему пользователю нравится данная фотография, 0 - не указано.
		/// count — количество пользователей, которым нравится текущая фотография.
		/// 
		/// Если был задан параметр photo_sizes=1, вместо полей width и height возвращаются размеры копий фотографии в специальном формате.
		/// </remarks>
		///</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getAll"/>.
		/// </remarks>
		[ApiVersion("5.9")]
		public ReadOnlyCollection<Photo> GetAll(long? ownerId = null, bool? extended = null, int? count = null, int? offset = null, bool? photoSizes = null, bool? noServiceAlbums = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => offset);
			VkErrors.ThrowIfNumberIsNegative(() => count);

			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"extended", extended},
					{"count", count},
					{"offset", offset},
					{"photo_sizes", photoSizes},
					{"no_service_albums", noServiceAlbums}
				};

			VkResponseArray response = _vk.Call("photos.getAll", parameters);

			return response.ToReadOnlyCollectionOf<Photo>(x => x);
		}

		/// <summary>
		/// Возвращает список фотографий, на которых отмечен пользователь 
		/// </summary>
		/// <param name="userId">Идентификатор пользователя, список фотографий для которого нужно получить. положительное число, по умолчанию идентификатор текущего пользователя</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества фотографий. По умолчанию — 0. положительное число</param>
		/// <param name="count">Количество фотографий, которое необходимо получить. положительное число, по умолчанию 20, максимальное значение 1000</param>
		/// <param name="extended">True — будут возвращены дополнительные поля likes, comments, tags, can_comment. Поля comments и tags содержат только количество объектов. По умолчанию данные поля не возвращается</param>
		/// <param name="sort">Сортировка результатов (false — по дате добавления отметки в порядке убывания, true — по дате добавления отметки в порядке возрастания)</param>
		/// <returns>После успешного выполнения возвращает список объектов photo. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getUserPhotos"/>.
		/// </remarks>
		[ApiMethodName("photos.getUserPhotos")]
		[VkValue("userId", 178964623)]
		[VkValue("count", 2)]
		[VkValue("offset", 3)]
		[ApiVersion("5.9")]
		public ReadOnlyCollection<Photo> GetUserPhotos(long? userId = null, int? offset = null, int? count = null, bool? extended = null, bool? sort = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => userId);
			VkErrors.ThrowIfNumberIsNegative(() => offset);
			VkErrors.ThrowIfNumberIsNegative(() => count);

			var parameters = new VkParameters
				{
					{"user_id", userId},
					{"count", count},
					{"offset", offset},
					{"extended", extended},
					{"sort", sort}
				};

			VkResponseArray response = _vk.Call("photos.getUserPhotos", parameters);

			return response.ToReadOnlyCollectionOf<Photo>(x => x);
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
		[ApiVersion("5.9")]
		public bool DeleteAlbum(long albumId, long? groupId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => albumId);
			VkErrors.ThrowIfNumberIsNegative(() => groupId);

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
		[ApiVersion("5.9")]
		public bool Delete(long photoId, long? ownerId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => photoId);

			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"photo_id", photoId}
				};

			return _vk.Call("photos.delete", parameters);
		}

		/// <summary>
		/// Подтверждает отметку на фотографии. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="photoId">Идентификатор фотографии</param>
		/// <param name="tagId">Идентификатор отметки на фотографии</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.confirmTag"/>.
		/// </remarks>
		[ApiMethodName("photos.confirmTag", Skip = true)]
		[ApiVersion("5.9")]
		public bool ConfirmTag(long photoId, long tagId, long? ownerId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => photoId);
			VkErrors.ThrowIfNumberIsNegative(() => tagId);

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
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="photoId">Идентификатор фотографии</param>
		/// <param name="needLikes">True — будет возвращено дополнительное поле likes. По умолчанию поле likes не возвращается</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества комментариев</param>
		/// <param name="count">Количество комментариев, которое необходимо получить.</param>
		/// <param name="sort">Порядок сортировки комментариев (asc — от старых к новым, desc - от новых к старым)</param>
		/// <param name="accessKey">строка</param>
		/// <returns>После успешного выполнения возвращает список объектов <see cref="Comment"/>.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getComments"/>.
		/// </remarks>
		[ApiMethodName("photos.getComments")]
		[VkValue("owner_id", 1)]
		[VkValue("photo_id", 263219735)]
		[ApiVersion("5.9")]
		public ReadOnlyCollection<Comment> GetComments(long photoId, long? ownerId = null, bool? needLikes = null, int? count = null, int? offset = null, CommentsSort sort = null, string accessKey = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => photoId);
			VkErrors.ThrowIfNumberIsNegative(() => offset);
			VkErrors.ThrowIfNumberIsNegative(() => count);

			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"photo_id", photoId},
					{"need_likes", needLikes},
					{"offset", offset},
					{"count", count},
					{"sort", sort},
					{"access_key", accessKey}
				};

			VkResponseArray response = _vk.Call("photos.getComments", parameters);

			return response.ToReadOnlyCollectionOf<Comment>(x => x);
		}

		/// <summary>
		/// Возвращает отсортированный в антихронологическом порядке список всех комментариев к конкретному альбому или ко всем альбомам пользователя. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежат фотографии. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="albumId">Идентификатор альбома. Если параметр не задан, то считается, что необходимо получить комментарии ко всем альбомам пользователя или сообщества</param>
		/// <param name="needLikes">True — будет возвращено дополнительное поле likes. По умолчанию поле likes не возвращается</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества комментариево</param>
		/// <param name="count">Количество комментариев, которое необходимо получить. Если параметр не задан, то считается что он равен 20. Максимальное значение параметра 100. положительное число</param>
		/// <returns>После успешного выполнения возвращает список объектов <see cref="Comment"/>.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getAllComments"/>.
		/// </remarks>
		[ApiMethodName("photos.getAllComments", Skip = true)]
		[ApiVersion("5.9")]
		public ReadOnlyCollection<Comment> GetAllComments(long? ownerId = null, long? albumId = null, bool? needLikes = null, int? offset = null, int? count = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => albumId);
			VkErrors.ThrowIfNumberIsNegative(() => offset);
			VkErrors.ThrowIfNumberIsNegative(() => count);

			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"album_id", albumId},
					{"need_likes", needLikes},
					{"offset", offset},
					{"count", count}
				};

			VkResponseArray response = _vk.Call("photos.getAllComments", parameters);

			return response.ToReadOnlyCollectionOf<Comment>(x => x);
		}

		/// <summary>
		/// Создает новый комментарий к фотографии. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="photoId">Идентификатор фотографии</param>
		/// <param name="message">Текст комментария (является обязательным, если не задан параметр attachments)</param>
		/// <param name="attachments">Список объектов, приложенных к комментарию и разделённых символом &quot;,&quot;. Поле attachments представляется в формате: 
		/// &lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt;,&lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt; 
		/// &lt;type&gt; — тип медиа-вложения: 
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
		///Параметр является обязательным, если не задан параметр message. список строк, разделенных через запятую</param>
		/// <param name="fromGroup">Данный параметр учитывается, если oid &lt; 0 (комментарий к фотографии группы). 1 — комментарий будет опубликован от имени группы, 0 — комментарий будет опубликован от имени пользователя (по умолчанию)</param>
		/// <param name="replyToComment"></param>
		/// <param name="accessKey">строка</param>
		/// <returns>После успешного выполнения возвращает идентификатор созданного комментария.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.createComment"/>.
		/// </remarks>
		[ApiMethodName("photos.createComment", Skip = true)]
		[ApiVersion("5.9")]
		public long CreateComment(long photoId, long? ownerId = null, string message = null, IEnumerable<string> attachments = null, bool? fromGroup = null, bool? replyToComment = null, string accessKey = null)
		{
			// TODO сделать по-нормально работу с аттачментами
			VkErrors.ThrowIfNumberIsNegative(() => photoId);

			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"photo_id", photoId},
					{"message", message},
					{"attachments", attachments},
					{"from_group", fromGroup},
					{"reply_to_comment", replyToComment},
					{"access_key", accessKey}
				};

			VkResponse response = _vk.Call("photos.createComment", parameters);

			return response;
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
		[ApiVersion("5.9")]
		public bool DeleteComment(long commentId, long? ownerId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => commentId);

			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"comment_id", commentId}
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
		[ApiVersion("5.9")]
		public long RestoreComment(long commentId, long? ownerId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => commentId);

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
		[ApiVersion("5.9")]
		public bool EditComment(long commentId, string message, long? ownerId = null, IEnumerable<string> attachments = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => commentId);

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
		/// <param name="accessKey">строковой ключ доступа, который може быть получен при получении объекта фотографии</param>
		/// <returns>После успешного выполнения возвращает массив объектов <see cref="Tag"/>.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getTags"/>.
		/// </remarks>
		[ApiMethodName("photos.getTags", Skip = true)]
		[ApiVersion("5.9")]
		public ReadOnlyCollection<Tag> GetTags(long photoId, long? ownerId = null, string accessKey = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => photoId);

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
		/// <param name="ownerId">Идентификатор пользователя, которому принадлежит фотография</param>
		/// <param name="photoId">Идентификатор фотографии</param>
		/// <param name="userId">Идентификатор пользователя</param>
		/// <param name="x">Координата верхнего левого угла области с отметкой в % от ширины фотографии</param>
		/// <param name="y">Координата верхнего левого угла области с отметкой в % от высоты фотографии</param>
		/// <param name="x2">Координата правого нижнего угла области с отметкой в % от ширины фотографии</param>
		/// <param name="y2">Координата правого нижнего угла области с отметкой в % от высоты фотографии</param>
		/// <returns>После успешного выполнения возвращает идентификатор созданной отметки.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.putTag"/>.
		/// </remarks>
		[ApiMethodName("photos.putTag", Skip = true)]
		[ApiVersion("5.9")]
		public long PutTag(long photoId, long userId, long? ownerId = null, double? x = null, double? y = null, double? x2 = null, double? y2 = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => ownerId);
			VkErrors.ThrowIfNumberIsNegative(() => photoId);
			VkErrors.ThrowIfNumberIsNegative(() => userId);

			var parameters = new VkParameters
				{
					{"owner_id", ownerId},
					{"photo_id", photoId},
					{"user_id", userId},
					{"x", x},
					{"y", y},
					{"x2", x2},
					{"y2", y2}
				};

			return _vk.Call("photos.putTag", parameters);
		}

		/// <summary>
		/// Удаляет отметку с фотографии. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
		/// <param name="photoId">Идентификатор фотографии</param>
		/// <param name="tagId">Идентификатор отметки</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.removeTag"/>.
		/// </remarks>
		[ApiMethodName("photos.removeTag", Skip = true)]
		[ApiVersion("5.9")]
		public bool RemoveTag(long tagId, long photoId, long? ownerId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => tagId);
			VkErrors.ThrowIfNumberIsNegative(() => photoId);

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
		/// <param name="offset">Смещение, необходимое для получения определённого подмножества фотографий</param>
		/// <param name="count">Количество фотографий, которые необходимо вернуть. положительное число, максимальное значение 100, по умолчанию 20</param>
		/// <returns>После успешного выполнения возвращает список объектов <see cref="Photo"/>.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getNewTags"/>.
		/// </remarks>
		[ApiMethodName("photos.getNewTags", Skip = true)]
		[ApiVersion("5.9")]
		public ReadOnlyCollection<Photo> GetNewTags(int? offset = null, int? count = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => offset);
			VkErrors.ThrowIfNumberIsNegative(() => count);

			var parameters = new VkParameters
				{
					{"offset", offset},
					{"count", count}
				};

			VkResponseArray response = _vk.Call("photos.getNewTags", parameters);

			return response.ToReadOnlyCollectionOf<Photo>(x => x);
		}
	}
}