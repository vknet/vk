namespace VkNet.Categories
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using JetBrains.Annotations;

	using Enums;
	using Model;
	using Model.RequestParams;
	using Utils;
	using Enums.Filters;
	using Enums.SafetyEnums;
	using Model.Attachments;

	/// <summary>
	/// Методы для работы со стеной пользователя.
	/// </summary>
	public class WallCategory
	{
		private readonly VkApi _vk;

		internal WallCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Возвращает список записей со стены пользователя или сообщества.
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя. Чтобы получить записи со стены группы (публичной страницы, встречи), укажите её идентификатор
		/// со знаком "минус": например, owner_id=-1 соответствует группе с идентификатором 1.</param>
		/// <param name="totalCount">Общее количество записей на стене.</param>
		/// <param name="count">Количество сообщений, которое необходимо получить (но не более 100).</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества сообщений.</param>
		/// <param name="filter">Типы сообщений, которые необходимо получить (по умолчанию возвращаются все сообщения).</param>
		/// <returns>В случае успеха возвращается запрошенный список записей со стены.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.get"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.9")]
		[Obsolete("Устаревшая версия API. Используйте метод Get(WallGetParams @params)")]
		public ReadOnlyCollection<Post> Get(long ownerId, out int totalCount, int? count = null, int? offset = null, WallFilter filter = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => count);
			VkErrors.ThrowIfNumberIsNegative(() => offset);
			if (filter != null && filter == WallFilter.Suggests && ownerId >= 0)
			{
				throw new ArgumentException("OwnerID must be negative in case filter equal to Suggests", "ownerId");
			}
			var result = Get(new WallGetParams
			{
				OwnerId = ownerId,
				Count = (ulong)count,
				Offset = (ulong)offset,
				Filter = filter
			});
			totalCount = Convert.ToInt32(result.TotalCount);
			return result.WallPosts;
		}

		/// <summary>
		/// Возвращает список записей со стены пользователя или сообщества.
		/// </summary>
		/// <param name="params">Входные параметры.</param>
		/// <returns>
		/// В случае успеха возвращается запрошенный список записей со стены.
		/// </returns>
		/// <exception cref="System.ArgumentException">OwnerID must be negative in case filter equal to Suggests;ownerId</exception>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.get" />.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public WallGetObject Get(WallGetParams @params)
		{
			if (@params.Filter != null && @params.Filter == WallFilter.Suggests && @params.OwnerId >= 0)
			{
				throw new ArgumentException("OwnerID must be negative in case filter equal to Suggests", "ownerId");
			}

			return _vk.Call("wall.get", @params, @params.Filter != WallFilter.Suggests && @params.Filter != WallFilter.Postponed);
		}

		/// <summary>
		/// Возвращает три  коллекции в out параметрах <paramref name="wallPosts"/>, <paramref name="profiles"/> и <paramref name="groups"/>.
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя. Чтобы получить записи со стены группы (публичной страницы, встречи), укажите её идентификатор
		/// со знаком "минус": например, owner_id=-1 соответствует группе с идентификатором 1.</param>
		/// <param name="wallPosts">Коллекция записей на стене.</param>
		/// <param name="profiles">Коллекция профилей, так или иначе связанных с полученными в <paramref name="wallPosts"/> записями.</param>
		/// <param name="groups">Коллекция групп, так или иначе связанных с полученными в <paramref name="wallPosts"/> записями.</param>
		/// <param name="count">Количество сообщений, которое необходимо получить (но не более 100).</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества сообщений.</param>
		/// <param name="filter">Типы сообщений, которые необходимо получить (по умолчанию возвращаются все сообщения).</param>
		/// <returns>В случае успеха возвращается количество записей на стене.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.get"/>, для случая, когда параметр extended = 1.
		/// </remarks>
		[Pure]
		[ApiVersion("5.9")]
		[Obsolete("Устаревшая версия API. Используйте метод Get(WallGetParams @params)")]
		public int GetExtended(long ownerId, out ReadOnlyCollection<Post> wallPosts, out ReadOnlyCollection<User> profiles, out ReadOnlyCollection<Group> groups, int? count = null, int? offset = null, WallFilter filter = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => count);
			VkErrors.ThrowIfNumberIsNegative(() => offset);
			if (filter != null && filter == WallFilter.Suggests && ownerId >= 0)
			{
				throw new ArgumentException("OwnerID must be negative in case filter equal to Suggests", "ownerId");
			}
			var result = Get(new WallGetParams
			{
				OwnerId = ownerId,
				Count = (ulong)count,
				Offset = (ulong)offset,
				Filter = filter,
				Extended = true
			});
			wallPosts = result.WallPosts;
			profiles = result.Profiles;
			groups = result.Groups;
			return Convert.ToInt32(result.TotalCount);
		}


		/// <summary>
		/// Возвращает список комментариев к записи на стене пользователя.
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя, на чьей стене находится запись, к которой необходимо получить комментарии.</param>
		/// <param name="postId">Идентификатор записи на стене пользователя.</param>
		/// <param name="totalCount">Общее количество комментариев к записи.</param>
		/// <param name="sort">Порядок сортировки комментариев (по умолчанию хронологический).</param>
		/// <param name="needLikes">Признак нужно ли возвращать поле Likes в комментариях.</param>
		/// <param name="count">Количество комментариев, которое необходимо получить (но не более 100).</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества комментариев.</param>
		/// <param name="previewLength">Количество символов, по которому нужно обрезать комментарии. Если указано 0, то комментарии не образеютяс.
		/// Обратите внимание, что комментарии обрезаются по словам.</param>
		/// <returns>
		/// Список комментариев к записи на стене пользователя.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.getComments"/>.
		/// </remarks>
		[Pure]
		[Obsolete("Устаревшая версия API. Используйте метод GetComments(out int totalCount, WallGetCommentsParams @params)")]
		public ReadOnlyCollection<Comment> GetComments(
			long ownerId,
			long postId,
			out int totalCount,
			SortOrderBy? sort = null,
			bool needLikes = false,
			int? count = null,
			int? offset = null,
			int previewLength = 0)
		{
			VkErrors.ThrowIfNumberIsNegative(() => postId);
			VkErrors.ThrowIfNumberIsNegative(() => offset);
			VkErrors.ThrowIfNumberIsNegative(() => count);
			VkErrors.ThrowIfNumberIsNegative(() => previewLength);

			var parameters = new WallGetCommentsParams
			{
				OwnerId = ownerId,
				PostId = postId,
				NeedLikes = needLikes,
				Count = count,
				Offset = offset,
				PreviewLength = previewLength,
				Sort = sort
			};

			return GetComments(out totalCount, parameters);
		}

		/// <summary>
		/// Возвращает список комментариев к записи на стене.
		/// </summary>
		/// <param name="totalCount">Общее количество комментариев к записи.</param>
		/// <param name="params">Входные параметры выборки.</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов комментариев.
		/// Если был задан параметр need_likes=1, у объектов комментариев возвращается дополнительное поле likes:
		/// count — число пользователей, которым понравился комментарий;
		/// user_likes — наличие отметки «Мне нравится» от текущего пользователя
		/// (1 — есть, 0 — нет);
		/// can_like — информация о том, может ли текущий пользователь поставить отметку «Мне нравится»
		/// (1 — может, 0 — не может).
		/// Если был передан параметр start_comment_id, будет также возвращено поле real_offset – итоговое смещение данного подмножества комментариев (оно может быть отрицательным, если был указан отрицательный offset).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.getComments" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<Comment> GetComments(out int totalCount, WallGetCommentsParams @params)
		{
			var response = _vk.Call("wall.getComments", @params);
			totalCount = response["count"];
			return response["items"].ToReadOnlyCollectionOf<Comment>(x => x);
		}

		/// <summary>
		/// Возвращает список записей со стен пользователей или сообществ по их идентификаторам.
		/// </summary>
		/// <param name="posts">
		/// Список строковых идентификаторов записий в формате - идентификатор пользователя (группы), знак подчеркивания и идентификатор записи.
		/// Примеры возможных значений идентификаторов: "93388_21539", "93388_20904", "-2943_4276".
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов записей со стены.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.getById"/>.
		/// </remarks>
		[Pure]
		[Obsolete("Данный метод устарел. Используйте GetById(IEnumerable<string> posts, bool? extended = null, long? copyHistoryDepth = null, ProfileFields fields = null)")]
		public ReadOnlyCollection<Post> GetById(IEnumerable<string> posts)
		{
			if (posts == null)
			{
				throw new ArgumentNullException("posts");
			}

			if (!posts.Any())
			{
				throw new ArgumentException("Posts collection was empty.", "posts");
			}

			return GetById(posts, null, null, null).WallPosts;
		}

		/// <summary>
		/// Возвращает список записей со стен пользователей или сообществ по их идентификаторам.
		/// </summary>
		/// <param name="posts">
		/// Список идентификаторов записей. Key - идентификатор пользователя (группы), Value - идентификатор записи (положительное число).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов записей со стены.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.getById"/>.
		/// </remarks>
		[Pure]
		[Obsolete("Данный метод устарел. Используйте GetById(IEnumerable<string> posts, bool? extended = null, long? copyHistoryDepth = null, ProfileFields fields = null)")]
		public ReadOnlyCollection<Post> GetById(IEnumerable<KeyValuePair<long, long>> posts)
		{
			if (posts == null)
			{
				throw new ArgumentNullException("posts");
			}

			if (!posts.Any())
			{
				throw new ArgumentException("Posts collection must have more then 0 elements.", "posts");
			}

			return GetById(posts.Select(x => x.Key + "_" + x.Value), null, null, null).WallPosts;
		}


		/// <summary>
		/// Возвращает список записей со стен пользователей или сообществ по их идентификаторам.
		/// </summary>
		/// <param name="posts">Перечисленные через запятую идентификаторы, которые представляют собой идущие через знак подчеркивания id владельцев стен и id самих записей на стене.
		/// Пример значения posts:
		/// 93388_21539,93388_20904,-1_340364 список строк, разделенных через запятую, обязательный параметр (Список строк, разделенных через запятую, обязательный параметр).</param>
		/// <param name="extended">1 - возвращает объекты пользователей и групп, необходимые для отображения записей. флаг, может принимать значения 1 или 0 (Флаг, может принимать значения 1 или 0).</param>
		/// <param name="copyHistoryDepth">Определяет размер массива copy_history, возвращаемого в ответе, если запись является репостом записи с другой стены. 
		/// Например, copy_history_depth=1 — copy_history будет содержать один элемент с информацией о записи, прямым репостом которой является текущая. 
		/// copy_history_depth=2 — copy_history будет содержать два элемента, добавляется информация о записи, репостом которой является первый элемент, и так далее (при условии, что иерархия репостов требуемой глубины для текущей записи существует). целое число, по умолчанию 2 (Целое число, по умолчанию 2).</param>
		/// <param name="fields">Список дополнительных полей для профилей и  групп, которые необходимо вернуть. См. описание полей объекта user и описание полей объекта group. 
		/// Обратите внимание, этот параметр учитывается только при extended=1. список строк, разделенных через запятую (Список строк, разделенных через запятую).</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов записей со стены. 
		/// Если был задан параметр extended=1, ответ содержит три отдельных списка: 
		/// 
		/// items — содержит объекты записей со стены; 
		/// profiles — содержит объекты пользователей с дополнительными полями sex, photo, photo_medium_rec и online; 
		/// groups — содержит объекты сообществ. 
		/// 
		/// Если запись является репостом записи с другой стены, в ответе дополнительно возвращается массив copy_history записей со стены, репостом которых является текущая.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.getById" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public WallGetObject GetById(IEnumerable<string> posts, bool? extended = null, long? copyHistoryDepth = null, ProfileFields fields = null)
		{
			if (posts == null)
			{
				throw new ArgumentNullException("posts");
			}

			if (!posts.Any())
			{
				throw new ArgumentException("Posts collection was empty.", "posts");
			}

			var parameters = new VkParameters {
				{ "posts", posts },
				{ "extended", extended },
				{ "copy_history_depth", copyHistoryDepth },
				{ "fields", fields }
			};

			return _vk.Call("wall.getById", parameters);
		}

		/// <summary>
		/// Публикует новую запись на своей или чужой стене.
		/// Данный метод позволяет создать новую запись на стене, а также опубликовать предложенную новость или отложенную запись.
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, на стене которого должна быть опубликована запись. </param>
		/// <param name="friendsOnly">Доступна ли запись только друзьям (по умолчанию - доступна всем).</param>
		/// <param name="fromGroup">При публикации в группе показывает, от чьего имени публикуется запись (по умолчанию - от имени пользователя).</param>
		/// <param name="message">Тескт сообщения. Обязательное поле, если список <paramref name="mediaAttachments"/> не задан или пуст.</param>
		/// <param name="mediaAttachments">Список приложенных к записи объектов.
		/// Обязательно наличие хотя бы одного элемента в списке, если <paramref name="message"/> не задано.
		/// Свойства <see cref="MediaAttachment.Id"/> и <see cref="MediaAttachment.OwnerId"/> обязательно должны быть заданы. </param>
		/// <param name="url">Ссылка на внешнюю страницу. В строке может содержаться только одна ссылка.</param>
		/// <param name="services">Список сервисов или сайтов, на которые необходимо экспортировать запись, в случае если пользователь настроил соответствующую опцию.
		///  Например, twitter, facebook</param>
		/// <param name="signed">Добавляется ли подпись (имя опубликовавшего) к записи в группе, если запись сделана от имени группы.</param>
		/// <param name="publishDate">Дата публикации записи. Если параметр указан, публикация записи будет отложена до указанного времени. </param>
		/// <param name="lat">Географическая широта отметки, заданная в градусах (от -90 до 90).</param>
		/// <param name="long">Географическая долгота отметки, заданная в градусах (от -180 до 180).</param>
		/// <param name="placeId">Идентификатор места, в котором отмечен пользователь (положительное число).</param>
		/// <param name="postId">Идентификатор записи, которую необходимо опубликовать.
		/// Данный параметр используется для публикации отложенных записей и предложенных новостей.
		/// При публикации отложенной записи все параметры кроме owner_id и post_id игнорируются. </param>
		/// <returns>Идентификатор созданной записи</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Wall"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.post"/>.
		/// </remarks>
		[Obsolete("Данный метод устарел. Используйте Post(WallPostParams @params)")]
		public long Post(long? ownerId = null, bool friendsOnly = false, bool fromGroup = false,
			string message = null, IEnumerable<MediaAttachment> mediaAttachments = null, string url = null,
			IEnumerable<Services> services = null, bool signed = false, DateTime? publishDate = null,
			double? lat = null, double? @long = null, long? placeId = null, long? postId = null)
		{
			if (string.IsNullOrEmpty(message) && (mediaAttachments == null || !mediaAttachments.Any()) && string.IsNullOrEmpty(url))
				throw new ArgumentException("Message and attachments cannot be null or empty at the same time.");
			VkErrors.ThrowIfNumberIsNegative(() => placeId);
			VkErrors.ThrowIfNumberIsNegative(() => postId);
			if (lat.HasValue && (Math.Abs(lat.Value) > 90))
				throw new ArgumentOutOfRangeException("lat", lat, "lat must be at range from -90 to 90");
			if (@long.HasValue && (Math.Abs(@long.Value) > 180))
				throw new ArgumentOutOfRangeException("long", @long, "long must be at range from -90 to 90");

			var parameters = new WallPostParams
			{
				OwnerId = ownerId,
				FriendsOnly = friendsOnly,
				FromGroup = fromGroup,
				Message = message,
				Attachments = mediaAttachments,
				Services = services,
				Signed = signed,
				PublishDate = publishDate,
				Lat = lat,
				Long = @long,
				PlaceId = placeId,
				PostId = postId
			};
			return Post(parameters);
		}


		/// <summary>
		/// Публикует новую запись на своей или чужой стене.
		/// </summary>
		/// <param name="params">Входные параметры выборки.</param>
		/// <returns>
		/// После успешного выполнения возвращает идентификатор созданной записи (post_id).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.post" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public long Post(WallPostParams @params)
		{
			return _vk.Call("wall.post", @params)["post_id"];
		}

		/// <summary>
		/// Копирует объект на стену пользователя или сообщества.
		/// </summary>
		/// <param name="object">Строковый идентификатор объекта, который необходимо разместить на стене, например, wall66748_3675 или wall-1_340364.</param>
		/// <param name="message">Сопроводительный текст, который будет добавлен к записи с объектом.</param>
		/// <param name="groupId">Идентификатор сообщества, на стене которого будет размещена запись с объектом.
		/// Если не указан, запись будет размещена на стене текущего пользователя. </param>
		/// <returns>Результат выполнения копирвоания и информация о скопированном объекте.</returns>
		[Obsolete("Данный метод устарел. Используйте Repost(string @object, string message, long? groupId, string @ref)")]
		public RepostResult Repost(string @object, string message = null, long? groupId = null)
		{
			return Repost(@object, message, groupId, null);
		}

		/// <summary>
		/// Копирует объект на стену пользователя или сообщества.
		/// </summary>
		/// <param name="object">Строковый идентификатор объекта, который необходимо разместить на стене, например, wall66748_3675 или wall-1_340364. строка, обязательный параметр (Строка, обязательный параметр).</param>
		/// <param name="message">Сопроводительный текст, который будет добавлен к записи с объектом. строка (Строка).</param>
		/// <param name="groupId">Идентификатор сообщества, на стене которого будет размещена запись с объектом. Если не указан, запись будет размещена на стене текущего пользователя. положительное число (Положительное число).</param>
		/// <param name="ref">Строка (Строка).</param>
		/// <returns>
		/// После успешного выполнения возвращает объект со следующими полями: 
		/// 
		/// success 
		/// post_id — идентификатор созданной записи; 
		/// reposts_count — количество репостов объекта с учетом осуществленного; 
		/// likes_count — число отметок «Мне нравится» у объекта.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.repost" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public RepostResult Repost(string @object, string message, long? groupId, string @ref)
		{
			VkErrors.ThrowIfNullOrEmpty(() => @object);
			VkErrors.ThrowIfNumberIsNegative(() => groupId);
			var parameters = new VkParameters {
				{ "object", @object },
				{ "message", message },
				{ "group_id", groupId },
				{ "ref", @ref }
			};

			return _vk.Call("wall.repost", parameters);
		}

		/// <summary>
		/// Редактирует запись на стене.
		/// </summary>
		/// <param name="postId">Идентификатор записи, которую необходимо отредактировать.</param>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, на стене которого опубликована запись.</param>
		/// <param name="friendsOnly">Доступна ли запись только друзьям (по умолчанию - доступна всем).</param>
		/// <param name="message">Тескт сообщения. Обязательное поле, если список <paramref name="mediaAttachments"/> не задан или пуст.</param>
		/// <param name="mediaAttachments">Список приложенных к записи объектов.
		/// Обязательно наличие хотя бы одного элемента в списке, если <paramref name="message"/> не задано.
		/// Свойства <see cref="MediaAttachment.Id"/> и <see cref="MediaAttachment.OwnerId"/> обязательно должны быть заданы. </param>
		/// <param name="url">Ссылка на внешнюю страницу. В строке может содержаться только одна ссылка.</param>
		/// <param name="services">Список сервисов или сайтов, на которые необходимо экспортировать запись, в случае если пользователь настроил соответствующую опцию.
		///  Например, twitter, facebook</param>
		/// <param name="signed">Добавляется ли подпись (имя опубликовавшего) к записи в группе, если запись сделана от имени группы.</param>
		/// <param name="publishDate">Дата публикации записи. Если параметр не указан, отложенная запись будет опубликована.
		/// Параметр учитывается только при редактировании отложенной записи.</param>
		/// <param name="lat">Географическая широта отметки, заданная в градусах (от -90 до 90).</param>
		/// <param name="long">Географическая долгота отметки, заданная в градусах (от -180 до 180).</param>
		/// <param name="placeId">Идентификатор места, в котором отмечен пользователь (положительное число).</param>
		/// <returns>Результат выполнения редактирования.</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Wall"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.edit"/>.
		/// </remarks>
		[Obsolete("Данный метод устарел. Используйте Edit(WallEditParams @params)")]
		public bool Edit(long postId, long? ownerId = null, bool friendsOnly = false,
			string message = null, IEnumerable<MediaAttachment> mediaAttachments = null, string url = null,
			IEnumerable<Services> services = null, bool signed = false, DateTime? publishDate = null,
			double? lat = null, double? @long = null, long? placeId = null)
		{
			if (string.IsNullOrEmpty(message) && (mediaAttachments == null || !mediaAttachments.Any()) && string.IsNullOrEmpty(url))
				throw new ArgumentException("Message and attachments cannot be null or empty at the same time.");
			VkErrors.ThrowIfNumberIsNegative(() => placeId);
			VkErrors.ThrowIfNumberIsNegative(() => postId);
			if (lat.HasValue && (Math.Abs(lat.Value) > 90))
				throw new ArgumentOutOfRangeException("lat", lat, "lat must be at range from -90 to 90");
			if (@long.HasValue && (Math.Abs(@long.Value) > 180))
				throw new ArgumentOutOfRangeException("long", @long, "long must be at range from -90 to 90");

			var parameters = new WallEditParams
			{
				PostId = postId,
				OwnerId = ownerId,
				FriendsOnly = friendsOnly,
				Message = message,
				Attachments = mediaAttachments,
				Services = services,
				Signed = signed,
				PublishDate = publishDate,
				Lat = lat,
				Long = @long,
				PlaceId = placeId
			};
			return Edit(parameters);
		}

		/// <summary>
		/// Редактирует запись на стене.
		/// </summary>
		/// <param name="params">Входные параметры выборки.</param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.edit" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool Edit(WallEditParams @params)
		{
			return _vk.Call("wall.edit", @params);
		}

		/// <summary>
		/// Удаляет запись со стены.
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, на стене которого находится запись. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя (Целое число, по умолчанию идентификатор текущего пользователя).</param>
		/// <param name="postId">Идентификатор записи на стене. положительное число (Положительное число).</param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.delete" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool Delete(long? ownerId = null, long? postId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => postId);
			var parameters = new VkParameters {
				{ "owner_id", ownerId },
				{ "post_id", postId }
			};

			return _vk.Call("wall.delete", parameters);
		}


		/// <summary>
		/// Восстанавливает удаленную запись на стене пользователя или сообщества.
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, на стене которого находилась удаленная запись. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя (Целое число, по умолчанию идентификатор текущего пользователя).</param>
		/// <param name="postId">Идентификатор записи на стене. положительное число (Положительное число).</param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.restore" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool Restore(long? ownerId = null, long? postId = null)
		{
			var parameters = new VkParameters {
				{ "owner_id", ownerId },
				{ "post_id", postId }
			};

			return _vk.Call("wall.restore", parameters);
		}



		/// <summary>
		/// Добавляет комментарий к записи на стене пользователя или сообщества.
		/// </summary>
		/// <param name="params">Входные параметры выборки.</param>
		/// <returns>
		/// После успешного выполнения возвращает идентификатор добавленного комментария (comment_id).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.addComment" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public long AddComment(WallAddCommentParams @params)
		{
			return _vk.Call("wall.addComment", @params)["comment_id"];
		}
		
		/// <summary>
		/// Удаляет комментарий текущего пользователя к записи на своей или чужой стене.
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя, на чьей стене находится комментарий к записи. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя (Целое число, по умолчанию идентификатор текущего пользователя).</param>
		/// <param name="commentId">Идентификатор комментария. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.deleteComment" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool DeleteComment(long? ownerId, long commentId)
		{
			var parameters = new VkParameters {
				{ "owner_id", ownerId },
				{ "comment_id", commentId }
			};

			return _vk.Call("wall.deleteComment", parameters);
		}


		/// <summary>
		/// Восстанавливает комментарий текущего пользователя к записи на своей или чужой стене.
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, на стене которого находится комментарий к записи. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя (Целое число, по умолчанию идентификатор текущего пользователя).</param>
		/// <param name="commentId">Идентификатор комментария на стене. целое число, обязательный параметр (Целое число, обязательный параметр).</param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.restoreComment" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool RestoreComment(long commentId, long? ownerId)
		{
			var parameters = new VkParameters {
				{ "owner_id", ownerId },
				{ "comment_id", commentId }
			};

			return _vk.Call("wall.restoreComment", parameters);
		}

		/// <summary>
		/// Метод, позволяющий осуществлять поиск по стенам пользователей.
		/// </summary>
		/// <param name="params">Входные параметры выборки.</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов записей на стене.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.search" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<Post> Search(WallSearchParams @params)
		{
			return _vk.Call("wall.search", @params).ToReadOnlyCollectionOf<Post>(x => x);
		}

		/// <summary>
		/// Позволяет получать список репостов заданной записи.
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, на стене которого находится запись. Если параметр не задан, то он считается равным идентификатору текущего пользователя. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя (Целое число, по умолчанию идентификатор текущего пользователя).</param>
		/// <param name="postId">Идентификатор записи на стене. положительное число (Положительное число).</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества записей. положительное число (Положительное число).</param>
		/// <param name="count">Количество записей, которое необходимо получить. положительное число, по умолчанию 20, максимальное значение 1000 (Положительное число, по умолчанию 20, максимальное значение 1000).</param>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий поля: 
		/// 
		/// items — содержит массив записей-репостов; 
		/// profiles — содержит объекты пользователей с дополнительными полями sex, online, photo, photo_medium_rec, screen_name; 
		/// groups — содержит информацию о сообществах.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.getReposts" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public WallGetObject GetReposts(long? ownerId, long? postId, long? offset, long? count)
		{
			var parameters = new VkParameters {
				{ "owner_id", ownerId },
				{ "post_id", postId },
				{ "offset", offset },
				{ "count", count }
			};

			return _vk.Call("wall.getReposts", parameters);
		}

		/// <summary>
		/// Закрепляет запись на стене (запись будет отображаться выше остальных).
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, на стене которого находится запись. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя (Целое число, по умолчанию идентификатор текущего пользователя).</param>
		/// <param name="postId">Идентификатор записи на стене. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.pin" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool Pin(long postId, long? ownerId = null)
		{
			var parameters = new VkParameters {
				{ "owner_id", ownerId },
				{ "post_id", postId }
			};

			return _vk.Call("wall.pin", parameters);
		}

		/// <summary>
		/// Отменяет закрепление записи на стене.
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, на стене которого находится запись. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя (Целое число, по умолчанию идентификатор текущего пользователя).</param>
		/// <param name="postId">Идентификатор записи на стене. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.unpin" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool Unpin(long postId, long? ownerId = null)
		{
			var parameters = new VkParameters {
				{ "owner_id", ownerId },
				{ "post_id", postId }
			};

			return _vk.Call("wall.unpin", parameters);
		}

		/// <summary>
		/// Редактирует комментарий на стене пользователя или сообщества.
		/// </summary>
		/// <param name="ownerId">Идентификатор владельца стены. целое число, по умолчанию идентификатор текущего пользователя (Целое число, по умолчанию идентификатор текущего пользователя).</param>
		/// <param name="commentId">Идентификатор комментария, который необходимо отредактировать. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <param name="message">Новый текст комментария. строка (Строка).</param>
		/// <param name="attachments">Новые вложения к комментарию. список строк, разделенных через запятую (Список строк, разделенных через запятую).</param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.editComment" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool EditComment(long commentId, string message, long? ownerId = null, IEnumerable<string> attachments = null)
		{
			var parameters = new VkParameters {
				{ "owner_id", ownerId },
				{ "comment_id", commentId },
				{ "message", message },
				{ "attachments", attachments }
			};

			return _vk.Call("wall.editComment", parameters);
		}

		/// <summary>
		/// Позволяет пожаловаться на запись.
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит запись. целое число, обязательный параметр (Целое число, обязательный параметр).</param>
		/// <param name="postId">Идентификатор записи. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <param name="reason">Причина жалобы: 
		/// 
		/// 0 — спам; 
		/// 1 — детская порнография; 
		/// 2 — экстремизм; 
		/// 3 — насилие; 
		/// 4 — пропаганда наркотиков; 
		/// 5 — материал для взрослых; 
		/// 6 — оскорбление. 
		/// положительное число (Положительное число).</param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.reportPost" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool ReportPost(long ownerId, long postId, ReportReason? reason = null)
		{
			var parameters = new VkParameters {
				{ "owner_id", ownerId },
				{ "post_id", postId },
				{ "reason", reason }
			};

			return _vk.Call("wall.reportPost", parameters);
		}

		/// <summary>
		/// Позволяет пожаловаться на комментарий к записи.
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит комментарий. целое число, обязательный параметр (Целое число, обязательный параметр).</param>
		/// <param name="commentId">Идентификатор комментария. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <param name="reason">Причина жалобы: 
		/// 
		/// 0 — спам; 
		/// 1 — детская порнография; 
		/// 2 — экстремизм; 
		/// 3 — насилие; 
		/// 4 — пропаганда наркотиков; 
		/// 5 — материал для взрослых; 
		/// 6 — оскорбление. 
		/// положительное число (Положительное число).</param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.reportComment" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool ReportComment(long ownerId, long commentId, ReportReason? reason)
		{
			var parameters = new VkParameters {
				{ "owner_id", ownerId },
				{ "comment_id", commentId },
				{ "reason", reason }
			};

			return _vk.Call("wall.reportComment", parameters);
		}
	}
}
