

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

	using System.Text;
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
		[ApiVersion("5.40")]
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
		[ApiVersion("5.9")]
		public ReadOnlyCollection<Comment> GetComments(
			long ownerId,
			long postId,
			out int totalCount,
			CommentsSort sort = null,
			bool needLikes = false,
			int? count = null,
			int? offset = null,
			int previewLength = 0)
		{
			VkErrors.ThrowIfNumberIsNegative(() => postId);
			VkErrors.ThrowIfNumberIsNegative(() => offset);
			VkErrors.ThrowIfNumberIsNegative(() => count);
			VkErrors.ThrowIfNumberIsNegative(() => previewLength);

			var parameters = new VkParameters
							 {
								 { "owner_id", ownerId },
								 { "post_id", postId },
								 { "need_likes", needLikes },
								 { "count", count },
								 { "offset", offset },
								 { "preview_length", previewLength },
								 { "sort", sort }
							 };

			var response = _vk.Call("wall.getComments", parameters);

			totalCount = response["count"];

			return response["items"].ToReadOnlyCollectionOf<Comment>(c => c);
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
		[Obsolete]
		public ReadOnlyCollection<Post> GetById(IEnumerable<string> posts)
		{
			if (posts == null)
				throw new ArgumentNullException("posts");

			if (!posts.Any())
				throw new ArgumentException("Posts collection was empty.", "posts");

			var parameters = new VkParameters { { "posts", posts } };

			VkResponseArray response = _vk.Call("wall.getById", parameters);

			return response.ToReadOnlyCollectionOf<Post>(x => x);
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
		//TODO: добавить Extended версию и параметр copy_history_depth
		public ReadOnlyCollection<Post> GetById(IEnumerable<KeyValuePair<long, long>> posts)
		{
			if (posts == null)
				throw new ArgumentNullException("posts");
			var pairs = posts as KeyValuePair<long, long>[] ?? posts.ToArray();
			if (!pairs.Any())
				throw new ArgumentException("Posts collection must have more then 0 elements.", "posts");

			var builder = new StringBuilder();
			foreach (var pair in pairs)
			{
				if (builder.Length != 0)
					builder.AppendFormat(",");
				builder.AppendFormat("{0}_{1}", pair.Key, pair.Value);
			}

			var parameters = new VkParameters { { "posts", builder.ToString() } };

			VkResponseArray response = _vk.Call("wall.getById", parameters);

			return response.ToReadOnlyCollectionOf<Post>(x => x);
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
		public long Post(long? ownerId = null, bool friendsOnly = false, bool fromGroup = false,
			string message = null, IEnumerable<MediaAttachment> mediaAttachments = null, string url = null,
			string services = null, bool signed = false, DateTime? publishDate = null,
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

			var attachments = mediaAttachments.JoinNonEmpty();
			if (!string.IsNullOrEmpty(url))
				attachments += (attachments.Length > 0 ? "," : string.Empty) + url;

			var parameters = new VkParameters
							{
								{"owner_id", ownerId},
								{"friends_only", friendsOnly},
								{"from_group", fromGroup},
								{"message", message},
								{"attachments", attachments},
								{"services", services},
								{"signed", signed},
								{"publish_date", publishDate},
								{"lat", lat},
								{"long", @long},
								{"place_id", placeId},
								{"post_id", postId}
							};
			return _vk.Call("wall.post", parameters)["post_id"];
		}


		/// <summary>
		/// Копирует объект на стену пользователя или сообщества. 
		/// </summary>
		/// <param name="object">Строковый идентификатор объекта, который необходимо разместить на стене, например, wall66748_3675 или wall-1_340364.</param>
		/// <param name="message">Сопроводительный текст, который будет добавлен к записи с объектом.</param>
		/// <param name="groupId">Идентификатор сообщества, на стене которого будет размещена запись с объектом. 
		/// Если не указан, запись будет размещена на стене текущего пользователя. </param>
		/// <returns>Результат выполнения копирвоания и информация о скопированном объекте.</returns>
		public RepostResult Repost(string @object, string message = null, long? groupId = null)
		{
			VkErrors.ThrowIfNullOrEmpty(() => @object);
			VkErrors.ThrowIfNumberIsNegative(() => groupId);

			var parameters = new VkParameters
									{
										{"object", @object},
										{"message", message},
										{"group_id", groupId}
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
		public bool Edit(long postId, long? ownerId = null, bool friendsOnly = false,
			string message = null, IEnumerable<MediaAttachment> mediaAttachments = null, string url = null,
			string services = null, bool signed = false, DateTime? publishDate = null,
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

			var attachments = mediaAttachments.JoinNonEmpty();
			if (!string.IsNullOrEmpty(url))
				attachments += (attachments.Length > 0 ? "," : string.Empty) + url;

			var parameters = new VkParameters
							{
								{"post_id", postId},
								{"owner_id", ownerId},
								{"friends_only", friendsOnly},
								{"message", message},
								{"attachments", attachments},
								{"services", services},
								{"signed", signed},
								{"publish_date", publishDate},
								{"lat", lat},
								{"long", @long},
								{"place_id", placeId}
							};
			return _vk.Call("wall.edit", parameters);
		}

		/// <summary>
		/// Удаляет запись со стены. 
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, на стене которого находится запись.</param>
		/// <param name="postId">Идентификатор записи на стене.</param>
		/// <returns>
		/// После успешного выполнения возвращает true.
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Wall"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.delete"/>.
		/// </remarks>
		public bool Delete(long ownerId, long postId)
		{
			VkErrors.ThrowIfNumberIsNegative(() => postId);

			var parameters = new VkParameters
						 {
							 { "owner_id", ownerId },
							 { "post_id", postId }
						 };

			return _vk.Call("wall.delete", parameters);
		}

		/// <summary>
		/// Восстанавливает удаленную запись на стене пользователя или сообщества. 
		/// </summary>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Wall"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.restore"/>.
		/// </remarks>
		public void Restore()
		{
			// TODO:
			throw new NotImplementedException();
		}

		/// <summary>
		/// Добавляет комментарий к записи на стене пользователя или сообщества. 
		/// </summary>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Wall"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.addComment"/>.
		/// </remarks>
		public void AddComment()
		{
			// TODO:
			throw new NotImplementedException();
		}

		/// <summary>
		/// Удаляет комментарий текущего пользователя к записи на своей или чужой стене. 
		/// </summary>
		/// <param name="commentId">Идентификатор пользователя, на чьей стене находится комментарий к записи. </param>
		/// <param name="ownerId">Идентификатор комментария.</param>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Wall"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.deleteComment"/>.
		/// </remarks>
		public bool DeleteComment(long ownerId, long commentId)
		{
			VkErrors.ThrowIfNumberIsNegative(() => commentId);

			var parameters = new VkParameters
					{
							{ "owner_id", ownerId },
							{ "comment_id", commentId }
					};

			return _vk.Call("wall.deleteComment", parameters);
		}

		/// <summary>
		/// Восстанавливает комментарий текущего пользователя к записи на своей или чужой стене. 
		/// </summary>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Wall"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.restoreComment"/>.
		/// </remarks>
		public void RestoreComment()
		{
			// TODO:
			throw new NotImplementedException();
		}

		/// <summary>
		/// Добавляет запись на стене пользователя или сообщества в список Мне нравится, а также создает копию понравившейся записи на 
		/// стене текущего пользователя при необходимости. 
		/// </summary>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Wall"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.addLike"/>.
		/// </remarks>
		public void AddLike()
		{
			// TODO: ДАННЫЙ МЕТОД УСТАРЕЛ.
			throw new NotImplementedException();
		}

		/// <summary>
		/// Удаляет запись на стене пользователя из списка Мне нравится. 
		/// </summary>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Wall"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.deleteLike"/>.
		/// </remarks>
		public void DeleteLike()
		{
			// TODO: ДАННЫЙ МЕТОД УСТАРЕЛ.
			throw new NotImplementedException();
		}
	}
}
