using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Abstractions;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы с видеофайлами.
	/// </summary>
	public partial class VideoCategory : IVideoCategory
	{
		private readonly VkApi _vk;

		/// <summary>
		/// </summary>
		/// <param name="vk"> </param>
		public VideoCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Возвращает информацию о видеозаписях.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов видеозаписей с
		/// дополнительным полем comments, содержащим
		/// число комментариев  у видеозаписи.
		/// Если был задан параметр extended=1, возвращаются дополнительные поля:
		/// privacy_view — настройки приватности в формате настроек приватности; (приходит
		/// только для текущего пользователя)
		/// privacy_comment — настройки приватности в формате настроек приватности;
		/// (приходит только для текущего пользователя)
		/// can_comment — может ли текущий пользователь оставлять комментарии к ролику (1 —
		/// может, 0 — не может);
		/// can_repost — может ли текущий пользователь скопировать ролик с помощью функции
		/// «Рассказать друзьям» (1 — может, 0 —
		/// не может);
		/// likes — информация об отметках «Мне нравится»:
		/// user_likes — есть ли отметка «Мне нравится» от текущего пользователя;
		/// count — число отметок «Мне нравится»;
		/// repeat — зацикливание воспроизведения видеозаписи (1 — зацикливается, 0 — не
		/// зацикливается).
		/// Если в Вашем приложении используется  прямая авторизация, возвращается
		/// дополнительное поле files, содержащее ссылку
		/// на файл с видео (если ролик размещен на сервере ВКонтакте) или ссылку на
		/// внешний ресурс (если ролик встроен с
		/// какого-либо видеохостинга).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.get
		/// </remarks>
		public VkCollection<Video> Get(VideoGetParams @params)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.AlbumId);
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.Count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.Offset);

			return _vk.Call(methodName: "video.get", parameters: @params).ToVkCollectionOf<Video>(selector: x => x);
		}

		/// <summary>
		/// Редактирует данные видеозаписи.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.edit
		/// </remarks>
		public bool Edit(VideoEditParams @params)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.VideoId);

			return _vk.Call(methodName: "video.edit", parameters: @params);
		}

		/// <summary>
		/// Добавляет видеозапись в список пользователя.
		/// </summary>
		/// <param name="targetId">
		/// Идентификатор пользователя или сообщества, в которое нужно добавить видео.
		/// Обратите внимание, идентификатор сообщества в параметре target_id необходимо
		/// указывать со знаком "-" — например,
		/// target_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)
		/// целое число (Целое число).
		/// </param>
		/// <param name="videoId">
		/// Идентификатор видеозаписи. положительное число, обязательный параметр
		/// (Положительное число,
		/// обязательный параметр).
		/// </param>
		/// <param name="ownerId">
		/// Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
		/// Обратите внимание,
		/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
		/// "-" — например, owner_id=-1
		/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число,
		/// обязательный параметр (Целое число,
		/// обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.add
		/// </remarks>
		public long Add(long videoId, long ownerId, long? targetId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => videoId);

			var parameters = new VkParameters
			{
					{ "target_id", targetId }
					, { "video_id", videoId }
					, { "owner_id", ownerId }
			};

			return _vk.Call(methodName: "video.add", parameters: parameters);
		}

		/// <summary>
		/// Возвращает адрес сервера (необходимый для загрузки) и данные видеозаписи.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// Возвращает объект, который имеет поля upload_url, video_id, title, description,
		/// owner_id.
		/// Метод может быть вызван не более 5000 раз в сутки для одного сервиса.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.save
		/// </remarks>
		public Video Save(VideoSaveParams @params)
		{
			return _vk.Call(methodName: "video.save", parameters: @params);
		}

		/// <summary>
		/// Удаляет видеозапись со страницы пользователя.
		/// </summary>
		/// <param name="videoId">
		/// Идентификатор видеозаписи. положительное число, обязательный параметр
		/// (Положительное число,
		/// обязательный параметр).
		/// </param>
		/// <param name="ownerId">
		/// Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
		/// Обратите внимание,
		/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
		/// "-" — например, owner_id=-1
		/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по
		/// умолчанию идентификатор текущего
		/// пользователя (Целое число, по умолчанию идентификатор текущего пользователя).
		/// </param>
		/// <param name="targetId">
		/// Идентификатор пользователя или сообщества, для которого нужно удалить
		/// видеозапись.
		/// Обратите внимание, идентификатор сообщества в параметре target_id необходимо
		/// указывать со знаком "-" — например,
		/// target_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)
		/// целое число (Целое число).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.delete
		/// </remarks>
		public bool Delete(long videoId, long? ownerId = null, long? targetId = null)
		{
			var parameters = new VkParameters
			{
					{ "video_id", videoId }
					, { "owner_id", ownerId }
					, { "target_id", targetId }
			};

			return _vk.Call(methodName: "video.delete", parameters: parameters);
		}

		/// <summary>
		/// Восстанавливает удаленную видеозапись.
		/// </summary>
		/// <param name="videoId">
		/// Идентификатор видеозаписи. положительное число, обязательный параметр
		/// (Положительное число,
		/// обязательный параметр).
		/// </param>
		/// <param name="ownerId">
		/// Идентификатор владельца видеозаписи (пользователь или сообщество). Обратите
		/// внимание,
		/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
		/// "-" — например, owner_id=-1
		/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по
		/// умолчанию идентификатор текущего
		/// пользователя (Целое число, по умолчанию идентификатор текущего пользователя).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.restore
		/// </remarks>
		public bool Restore(long videoId, long? ownerId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => videoId);

			var parameters = new VkParameters
			{
					{ "video_id", videoId }
					, { "owner_id", ownerId }
			};

			return _vk.Call(methodName: "video.restore", parameters: parameters);
		}

		/// <summary>
		/// Возвращает список видеозаписей в соответствии с заданным критерием поиска.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов видеозаписей.
		/// Если в Вашем приложении используется  прямая авторизация, возвращается
		/// дополнительное поле files, содержащее ссылку
		/// на файл с видео (если ролик размещен на сервере ВКонтакте) или ссылку на
		/// внешний ресурс (если ролик встроен с
		/// какого-либо видеохостинга).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.search
		/// </remarks>
		public VkCollection<Video> Search(VideoSearchParams @params)
		{
			VkErrors.ThrowIfNullOrEmpty(expr: () => @params.Query);
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.Count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.Offset);

			return _vk.Call(methodName: "video.search", parameters: @params).ToVkCollectionOf<Video>(selector: x => x);
		}

		/// <summary>
		/// Возвращает список альбомов видеозаписей пользователя или сообщества.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор владельца альбомов (пользователь или сообщество). По умолчанию —
		/// идентификатор
		/// текущего пользователя. целое число, по умолчанию идентификатор текущего
		/// пользователя (Целое число, по умолчанию
		/// идентификатор текущего пользователя).
		/// </param>
		/// <param name="offset">
		/// Смещение, необходимое для выборки определенного подмножества альбомов. По
		/// умолчанию — 0.
		/// положительное число (Положительное число).
		/// </param>
		/// <param name="count">
		/// Количество альбомов, информацию о которых нужно вернуть. По умолчанию — не
		/// больше 50, максимум —
		/// 100). положительное число, по умолчанию 50, максимальное значение 100
		/// (Положительное число, по умолчанию 50,
		/// максимальное значение 100).
		/// </param>
		/// <param name="extended">
		/// 1 – позволяет получать поля count, photo_320, photo_160 и updated_time для
		/// каждого альбома. Если
		/// альбом пустой, то поля photo_320 и photo_160 возвращены не будут. По умолчанию
		/// – 0. флаг, может принимать значения
		/// 1 или 0 (Флаг, может принимать значения 1 или 0).
		/// </param>
		/// <param name="needSystem">
		/// 1 — возвращать системные альбомы. флаг, может принимать значения 1 или 0, по
		/// умолчанию 0
		/// (Флаг, может принимать значения 1 или 0, по умолчанию 0).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает общее количество альбомов с
		/// видеозаписями, и массив объектов album, каждый из
		/// которых содержит следующие поля:
		/// id — идентификатор альбома;
		/// owner_id — идентификатор владельца альбома;
		/// title — название альбома.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.getAlbums
		/// </remarks>
		public VkCollection<VideoAlbum> GetAlbums(long? ownerId = null
												, long? offset = null
												, long? count = null
												, bool? extended = null
												, bool? needSystem = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => offset);

			var parameters = new VkParameters
			{
					{ "owner_id", ownerId }
					, { "offset", offset }
					, { "count", count }
					, { "extended", extended }
					, { "need_system", needSystem }
			};

			return _vk.Call(methodName: "video.getAlbums", parameters: parameters).ToVkCollectionOf<VideoAlbum>(selector: x => x);
		}

		/// <summary>
		/// Создает пустой альбом видеозаписей.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества (если необходимо создать альбом в сообществе).
		/// положительное число
		/// (Положительное число).
		/// </param>
		/// <param name="title"> Название альбома. строка (Строка). </param>
		/// <param name="privacy">
		/// Уровень доступа к альбому в специальном формате.
		/// Приватность доступна для альбомов с видео в профиле пользователя. список строк,
		/// разделенных через запятую (Список
		/// строк, разделенных через запятую).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает  идентификатор созданного альбома
		/// (album_id).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.addAlbum
		/// </remarks>
		public long AddAlbum(string title, long? groupId = null, IEnumerable<Privacy> privacy = null)
		{
			VkErrors.ThrowIfNullOrEmpty(expr: () => title);
			VkErrors.ThrowIfNumberIsNegative(expr: () => groupId);

			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "title", title }
					, { "privacy", privacy }
			};

			var response = _vk.Call(methodName: "video.addAlbum", parameters: parameters);

			return response[key: "album_id"];
		}

		/// <summary>
		/// Редактирует название альбома видеозаписей.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества (если нужно отредактировать альбом, принадлежащий
		/// сообществу).
		/// положительное число (Положительное число).
		/// </param>
		/// <param name="albumId">
		/// Идентификатор альбома. положительное число, обязательный параметр
		/// (Положительное число,
		/// обязательный параметр).
		/// </param>
		/// <param name="title">
		/// Новое название для альбома. строка, обязательный параметр (Строка, обязательный
		/// параметр).
		/// </param>
		/// <param name="privacy">
		/// Уровень доступа к альбому в специальном формате.
		/// Приватность доступна для альбомов с видео в профиле пользователя. целое число
		/// (Целое число).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.editAlbum
		/// </remarks>
		public bool EditAlbum(long albumId, string title, long? groupId = null, Privacy privacy = null)
		{
			VkErrors.ThrowIfNullOrEmpty(expr: () => title);
			VkErrors.ThrowIfNumberIsNegative(expr: () => albumId);
			VkErrors.ThrowIfNumberIsNegative(expr: () => groupId);

			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "album_id", albumId }
					, { "title", title }
					, { "privacy", privacy }
			};

			return _vk.Call(methodName: "video.editAlbum", parameters: parameters);
		}

		/// <summary>
		/// Удаляет альбом видеозаписей.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества (если альбом, который необходимо удалить, принадлежит
		/// сообществу).
		/// положительное число (Положительное число).
		/// </param>
		/// <param name="albumId">
		/// Идентификатор альбома. положительное число
		/// (Положительное число).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.deleteAlbum
		/// </remarks>
		public bool DeleteAlbum(long albumId, long? groupId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => albumId);

			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "album_id", albumId }
			};

			return _vk.Call(methodName: "video.deleteAlbum", parameters: parameters);
		}

		/// <summary>
		/// Возвращает список комментариев к видеозаписи.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// После успешного выполнения возвращает общее количество комментариев и массив
		/// объектов comment, каждый из которых
		/// содержит следующие поля:
		/// id — идентификатор комментария;
		/// from_id — идентификатор автора комментария;
		/// date — дата добавления комментария в формате unixtime;
		/// text — текст комментария;
		/// likes — информация об отметках «Мне нравится» текущего комментария (если был
		/// задан параметр need_likes), объект с
		/// полями:
		/// count — число пользователей, которым понравился комментарий,
		/// user_likes — наличие отметки «Мне нравится» от текущего пользователя
		/// (1 — есть, 0 — нет),
		/// can_like — информация о том, может ли текущий пользователь поставить отметку
		/// «Мне нравится»
		/// (1 — может, 0 — не может).
		/// Если был передан параметр start_comment_id, будет также возвращено поле
		/// real_offset – итоговое смещение данного
		/// подмножества комментариев (оно может быть отрицательным, если был указан
		/// отрицательный offset).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.getComments
		/// </remarks>
		public VkCollection<Comment> GetComments(VideoGetCommentsParams @params)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.VideoId);
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.Count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.Offset);

			return _vk.Call(methodName: "video.getComments", parameters: @params).ToVkCollectionOf<Comment>(selector: x => x);
		}

		/// <summary>
		/// Cоздает новый комментарий к видеозаписи.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// После успешного выполнения возвращает идентификатор созданного комментария.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.createComment
		/// </remarks>
		public long CreateComment(VideoCreateCommentParams @params)
		{
			VkErrors.ThrowIfNullOrEmpty(expr: () => @params.Message);
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.VideoId);

			return _vk.Call(methodName: "video.createComment", parameters: @params);
		}

		/// <summary>
		/// Удаляет комментарий к видеозаписи.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
		/// целое число, по
		/// умолчанию идентификатор текущего пользователя (Целое число, по умолчанию
		/// идентификатор текущего пользователя).
		/// </param>
		/// <param name="commentId">
		/// Идентификатор комментария. целое число, обязательный параметр (Целое число,
		/// обязательный
		/// параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.deleteComment
		/// </remarks>
		public bool DeleteComment(long commentId, long? ownerId)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => commentId);

			var parameters = new VkParameters
			{
					{ "comment_id", commentId }
					, { "owner_id", ownerId }
			};

			return _vk.Call(methodName: "video.deleteComment", parameters: parameters);
		}

		/// <summary>
		/// Восстанавливает удаленный комментарий к видеозаписи.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
		/// Обратите внимание,
		/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
		/// "-" — например, owner_id=-1
		/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по
		/// умолчанию идентификатор текущего
		/// пользователя (Целое число, по умолчанию идентификатор текущего пользователя).
		/// </param>
		/// <param name="commentId">
		/// Идентификатор удаленного комментария. целое число, обязательный параметр (Целое
		/// число,
		/// обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c> (0, если комментарий с
		/// таким идентификатором не является
		/// удаленным).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.restoreComment
		/// </remarks>
		public bool RestoreComment(long commentId, long? ownerId)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => commentId);

			var parameters = new VkParameters
			{
					{ "comment_id", commentId }
					, { "owner_id", ownerId }
			};

			return _vk.Call(methodName: "video.restoreComment", parameters: parameters);
		}

		/// <summary>
		/// Изменяет текст комментария к видеозаписи.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
		/// Обратите внимание,
		/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
		/// "-" — например, owner_id=-1
		/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по
		/// умолчанию идентификатор текущего
		/// пользователя (Целое число, по умолчанию идентификатор текущего пользователя).
		/// </param>
		/// <param name="commentId">
		/// Идентификатор комментария. целое число, обязательный параметр (Целое число,
		/// обязательный
		/// параметр).
		/// </param>
		/// <param name="message">
		/// Новый текст комментария (является обязательным, если не задан параметр
		/// attachments). строка
		/// (Строка).
		/// </param>
		/// <param name="attachments">
		/// Новый список объектов, приложенных к комментарию и разделённых символом ",".
		/// Поле attachments представляется в
		/// формате:
		/// &lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt;,&lt;type&gt;&lt;owner_id&gt;_&lt;
		/// media_id&gt;
		/// &lt;type&gt; — тип медиа-вложения:
		/// photo — фотография
		/// video — видеозапись
		/// audio — аудиозапись
		/// doc — документ
		/// &lt;owner_id&gt; — идентификатор владельца медиа-вложения
		/// &lt;media_id&gt; — идентификатор медиа-вложения.
		/// Например:
		/// photo100172_166443618,photo66748_265827614
		/// Параметр является обязательным, если не задан параметр message. список строк,
		/// разделенных через запятую (Список
		/// строк, разделенных через запятую).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.editComment
		/// </remarks>
		public bool EditComment(long commentId, string message, long? ownerId = null, IEnumerable<MediaAttachment> attachments = null)
		{
			VkErrors.ThrowIfNullOrEmpty(expr: () => message);
			VkErrors.ThrowIfNumberIsNegative(expr: () => commentId);

			var parameters = new VkParameters
			{
					{ "owner_id", ownerId }
					, { "comment_id", commentId }
					, { "message", message }
					, { "attachments", attachments }
			};

			return _vk.Call(methodName: "video.editComment", parameters: parameters);
		}

		/// <summary>
		/// Позволяет пожаловаться на видеозапись.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
		/// целое число,
		/// обязательный параметр (Целое число, обязательный параметр).
		/// </param>
		/// <param name="videoId">
		/// Идентификатор видеозаписи. положительное число, обязательный параметр
		/// (Положительное число,
		/// обязательный параметр).
		/// </param>
		/// <param name="reason">
		/// Тип жалобы:
		/// 0 – это спам
		/// 1 – детская порнография
		/// 2 – экстремизм
		/// 3 – насилие
		/// 4 – пропаганда наркотиков
		/// 5 – материал для взрослых
		/// 6 – оскорбление положительное число (Положительное число).
		/// </param>
		/// <param name="comment"> Комментарий для жалобы. строка (Строка). </param>
		/// <param name="searchQuery">
		/// Поисковой запрос, если видеозапись была найдена
		/// через поиск. строка (Строка).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.report
		/// </remarks>
		public bool Report(long videoId, ReportReason reason, long? ownerId, string comment = null, string searchQuery = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => videoId);

			var parameters = new VkParameters
			{
					{ "video_id", videoId }
					, { "owner_id", ownerId }
					, { "reason", reason }
					, { "comment", comment }
					, { "search_query", searchQuery }
			};

			return _vk.Call(methodName: "video.report", parameters: parameters);
		}

		/// <summary>
		/// Позволяет пожаловаться на комментарий к видеозаписи.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор владельца видеозаписи, к которой оставлен комментарий. целое
		/// число, обязательный
		/// параметр (Целое число, обязательный параметр).
		/// </param>
		/// <param name="commentId">
		/// Идентификатор комментария. положительное число, обязательный параметр
		/// (Положительное число,
		/// обязательный параметр).
		/// </param>
		/// <param name="reason">
		/// Тип жалобы:
		/// 0 – это спам
		/// 1 – детская порнография
		/// 2 – экстремизм
		/// 3 – насилие
		/// 4 – пропаганда наркотиков
		/// 5 – материал для взрослых
		/// 6 – оскорбление положительное число (Положительное число).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.reportComment
		/// </remarks>
		public bool ReportComment(long commentId, long ownerId, ReportReason reason)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => commentId);

			var parameters = new VkParameters
			{
					{ "comment_id", commentId }
					, { "owner_id", ownerId }
					, { "reason", reason }
			};

			return _vk.Call(methodName: "video.reportComment", parameters: parameters);
		}

		/// <summary>
		/// Позволяет получить информацию об альбоме с видео.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор пользователя или сообщества, которому принадлежит альбом. целое
		/// число, по умолчанию
		/// идентификатор текущего пользователя (Целое число, по умолчанию идентификатор
		/// текущего пользователя).
		/// </param>
		/// <param name="albumId">
		/// Идентификатор альбома. целое число, обязательный параметр (Целое число,
		/// обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает объект, который содержит следующие поля:
		/// id — идентификатор альбома;
		/// owner_id — идентификатор владельца альбома;
		/// title — название альбома;
		/// count — число видеозаписей в альбоме;
		/// photo_320 — url обложки альбома с шириной 320px;
		/// photo_160 — url обложки альбома с шириной 160px;
		/// updated_time — время последнего обновления в формате unixtime.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.getAlbumById
		/// </remarks>
		public VideoAlbum GetAlbumById(long albumId, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
					{ "owner_id", ownerId }
					, { "album_id", albumId }
			};

			return _vk.Call(methodName: "video.getAlbumById", parameters: parameters);
		}

		/// <summary>
		/// Позволяет изменить порядок альбомов с видео.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор пользователя или сообщества, которому принадлежит альбом.
		/// Обратите внимание,
		/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
		/// "-" — например, owner_id=-1
		/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по
		/// умолчанию идентификатор текущего
		/// пользователя (Целое число, по умолчанию идентификатор текущего пользователя).
		/// </param>
		/// <param name="albumId">
		/// Идентификатор альбома, который нужно переместить. положительное число,
		/// обязательный параметр
		/// (Положительное число, обязательный параметр).
		/// </param>
		/// <param name="before">
		/// Идентификатор альбома, перед которым нужно поместить текущий. положительное
		/// число (Положительное
		/// число).
		/// </param>
		/// <param name="after">
		/// Идентификатор альбома, после которого нужно поместить текущий. положительное
		/// число (Положительное
		/// число).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.reorderAlbums
		/// </remarks>
		public bool ReorderAlbums(long albumId, long? ownerId, long? before, long? after)
		{
			var parameters = new VkParameters
			{
					{ "owner_id", ownerId }
					, { "album_id", albumId }
					, { "before", before }
					, { "after", after }
			};

			return _vk.Call(methodName: "video.reorderAlbums", parameters: parameters);
		}

		/// <summary>
		/// Позволяет переместить видеозапись в альбоме.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.reorderVideos
		/// </remarks>
		public bool ReorderVideos(VideoReorderVideosParams @params)
		{
			return _vk.Call(methodName: "video.reorderVideos", parameters: @params);
		}

		/// <summary>
		/// Позволяет добавить видеозапись в альбом.
		/// </summary>
		/// <param name="targetId">
		/// Идентификатор владельца альбома, в который нужно добавить видео.
		/// Обратите внимание, идентификатор сообщества в параметре target_id необходимо
		/// указывать со знаком "-" — например,
		/// target_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)
		/// целое число, по умолчанию идентификатор
		/// текущего пользователя (Целое число, по умолчанию идентификатор текущего
		/// пользователя).
		/// </param>
		/// <param name="albumId">
		/// Идентификатор альбома, в который нужно добавить видео (0 соответствует  общему
		/// списку
		/// видеозаписей «без альбома»). целое число (Целое число).
		/// </param>
		/// <param name="albumIds">
		/// Идентификаторы альбомов, в которые нужно добавить видео. список целых чисел,
		/// разделенных
		/// запятыми (Список целых чисел, разделенных запятыми).
		/// </param>
		/// <param name="ownerId">
		/// Идентификатор владельца видеозаписи.
		/// Обратите внимание, идентификатор сообщества в параметре owner_id необходимо
		/// указывать со знаком "-" — например,
		/// owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)
		/// целое число, обязательный параметр
		/// (Целое число, обязательный параметр).
		/// </param>
		/// <param name="videoId">
		/// Идентификатор видеозаписи. положительное число, обязательный параметр
		/// (Положительное число,
		/// обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.addToAlbum
		/// </remarks>
		public bool AddToAlbum(long ownerId, long videoId, IEnumerable<string> albumIds, long? targetId = null, long? albumId = null)
		{
			var parameters = new VkParameters
			{
					{ "target_id", targetId }
					, { "album_id", albumId }
					, { "album_ids", albumIds }
					, { "owner_id", ownerId }
					, { "video_id", videoId }
			};

			return _vk.Call(methodName: "video.addToAlbum", parameters: parameters);
		}

		/// <summary>
		/// Позволяет убрать видеозапись из альбома.
		/// </summary>
		/// <param name="targetId">
		/// Идентификатор владельца альбома. Обратите внимание, идентификатор сообщества в
		/// параметре
		/// target_id необходимо указывать со знаком "-" — например, target_id=-1
		/// соответствует идентификатору сообщества
		/// ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего
		/// пользователя (Целое число, по умолчанию
		/// идентификатор текущего пользователя).
		/// </param>
		/// <param name="albumId">
		/// Идентификатор альбома, из которого нужно убрать видео. целое число (Целое
		/// число).
		/// </param>
		/// <param name="albumIds">
		/// Идентификаторы альбомов, из которых нужно убрать видео. список целых чисел,
		/// разделенных запятыми
		/// (Список целых чисел, разделенных запятыми).
		/// </param>
		/// <param name="ownerId">
		/// Идентификатор владельца видеозаписи. Обратите внимание, идентификатор
		/// сообщества в параметре
		/// owner_id необходимо указывать со знаком "-" — например, owner_id=-1
		/// соответствует идентификатору сообщества
		/// ВКонтакте API (club1)  целое число, обязательный параметр (Целое число,
		/// обязательный параметр).
		/// </param>
		/// <param name="videoId">
		/// Идентификатор видеозаписи. положительное число, обязательный параметр
		/// (Положительное число,
		/// обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.removeFromAlbum
		/// </remarks>
		public bool RemoveFromAlbum(long ownerId, long videoId, IEnumerable<string> albumIds, long? targetId = null, long? albumId = null)
		{
			var parameters = new VkParameters
			{
					{ "target_id", targetId }
					, { "album_id", albumId }
					, { "album_ids", albumIds }
					, { "owner_id", ownerId }
					, { "video_id", videoId }
			};

			return _vk.Call(methodName: "video.removeFromAlbum", parameters: parameters);
		}

		/// <summary>
		/// Возвращает список альбомов, в которых находится видеозапись.
		/// </summary>
		/// <param name="targetId">
		/// Идентификатор пользователя или сообщества, для которого нужно получить список
		/// альбомов, содержащих видеозапись.
		/// Обратите внимание, идентификатор сообщества в параметре target_id необходимо
		/// указывать со знаком "-" — например,
		/// target_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)
		/// целое число, по умолчанию идентификатор
		/// текущего пользователя (Целое число, по умолчанию идентификатор текущего
		/// пользователя).
		/// </param>
		/// <param name="ownerId">
		/// Идентификатор владельца видеозаписи.
		/// Обратите внимание, идентификатор сообщества в параметре owner_id необходимо
		/// указывать со знаком "-" — например,
		/// owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)
		/// целое число, обязательный параметр
		/// (Целое число, обязательный параметр).
		/// </param>
		/// <param name="videoId">
		/// Идентификатор видеозаписи. положительное число, обязательный параметр
		/// (Положительное число,
		/// обязательный параметр).
		/// </param>
		/// <param name="extended">
		/// 1 — возвращать расширенную информацию об альбомах. флаг, может принимать
		/// значения 1 или 0, по
		/// умолчанию 0 (Флаг, может принимать значения 1 или 0, по умолчанию 0).
		/// </param>
		/// <returns>
		/// Возвращает список идентификаторов альбомов, в которых видеозапись находится у
		/// пользователя или сообщества с
		/// идентификатором target_id. Если был передан параметр extended=1, возвращается
		/// список объектов альбомов с
		/// дополнительной информацией о каждом из них.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.getAlbumsByVideo
		/// </remarks>
		public VkCollection<VideoAlbum> GetAlbumsByVideo(long? targetId, long ownerId, long videoId, bool? extended)
		{
			var parameters = new VkParameters
			{
					{ "target_id", targetId }
					, { "owner_id", ownerId }
					, { "video_id", videoId }
					, { "extended", extended }
			};

			return _vk.Call(methodName: "video.getAlbumsByVideo", parameters: parameters).ToVkCollectionOf<VideoAlbum>(selector: x => x);
		}

		/// <summary>
		/// Позволяет получить представление каталога видео.
		/// </summary>
		/// <param name="params"> Позволяет получить представление каталога видео. </param>
		/// <returns>
		/// После успешного выполнения возвращает массив объектов — блоков видеокаталога.
		/// Каждый из объектов содержит массив
		/// объектов — элементов блока и дополнительную информацию для отображения блока.
		/// Данные для отображения блока видеокаталога
		/// name заголовок блока.
		/// строка id идентификатор блока. Возвращается строка для предопределенных блоков.
		/// Для других возвращается число.
		/// Предопределенные блоки:
		/// my — видеозаписи пользователя;
		/// feed — записи сообществ и друзей, содержащие видеозаписи, а также новые
		/// видеозаписи, добавленные ими;
		/// ugc — популярные видеозаписи;
		/// series — сериалы и телешоу.
		/// строка или число can_hide наличие возможности скрыть блок.
		/// флаг, может принимать значения 1 или 0 type тип блока. Может принимать
		/// значения:
		/// channel — видеозаписи сообщества;
		/// category — подборки видеозаписей.
		/// строка next параметр для получения следующей страницы результатов. Необходимо
		/// передать его значение в from в
		/// следующем вызове, чтобы получить содержимое каталога, следующее за полученным в
		/// текущем вызове.
		/// строка
		/// Элемент блока видеокаталога
		/// id идентификатор элемента.
		/// положительное число owner_id идентификатор владельца элемента.
		/// int (числовое значение) title заголовок.
		/// строка type тип элемента. Может принимать значения:
		/// video — видеоролик;
		/// album — альбом.
		/// строка
		/// type=video. Дополнительные поля для элемента-видеоролика
		/// duration длительность в секундах.
		/// положительное число description описание.
		/// строка date дата добавления.
		/// положительное число views число просмотров.
		/// положительное число comments число комментариев.
		/// положительное число photo_130 URL изображения-обложки видео с размером
		/// 130x98px.
		/// строка photo_320 URL изображения-обложки видео с размером 320x240px.
		/// строка photo_640 URL изображения-обложки видео с размером 640x480px (если
		/// размер есть).
		/// строка can_add наличие возможности добавить видео в свой список.
		/// флаг, может принимать значения 1 или 0 can_edit наличие возможности
		/// редактировать видео.
		/// флаг, может принимать значения 1 или 0
		/// type=album. Дополнительные поля для элемента-альбома
		/// count число видеозаписей в альбоме.
		/// положительное число photo_320 URL изображения-обложки альбома с размером
		/// 544x300px.
		/// строка photo_160 URL изображения-обложки альбома с размером 272x150px.
		/// строка updated_time время последнего обновления альбома.
		/// положительное число
		/// Если был передан параметр extended=1, возвращаются дополнительные объекты
		/// profiles и groups, содержащие информацию
		/// о пользователях и сообществах.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.getCatalog
		/// </remarks>
		public ReadOnlyCollection<VideoCatalog> GetCatalog(VideoGetCatalogParams @params)
		{
			var parameters = new VkParameters
			{
					{ "count", @params.Count }
					, { "items_count", @params.ItemsCount }
					, { "from", @params.From }
					, { "extended", @params.Extended }
			};

			return _vk.Call(methodName: "video.getCatalog", parameters: parameters).ToReadOnlyCollectionOf<VideoCatalog>(selector: x => x);
		}

		/// <summary>
		/// Позволяет получить отдельный блок видеокаталога.
		/// </summary>
		/// <param name="sectionId">
		/// Значение id, полученное с блоком в методе video.getCatalog. строка,
		/// обязательный параметр
		/// (Строка, обязательный параметр).
		/// </param>
		/// <param name="from">
		/// Значение next, полученное с блоком в методе video.getCatalog строка,
		/// обязательный параметр (Строка,
		/// обязательный параметр).
		/// </param>
		/// <param name="count">
		/// Число элементов блока, которое нужно вернуть. положительное число, по умолчанию
		/// 10, максимальное
		/// значение 16 (Положительное число, по умолчанию 10, максимальное значение 16).
		/// </param>
		/// <param name="extended">
		/// 1 — возвращать дополнительную информацию о пользователях и сообществах в полях
		/// profiles и
		/// groups. флаг, может принимать значения 1 или 0, по умолчанию 0 (Флаг, может
		/// принимать значения 1 или 0, по
		/// умолчанию 0).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает массив элементов блока видеокаталога и
		/// поле next для текущего блока.
		/// Элемент блока видеокаталога
		/// id идентификатор элемента.
		/// положительное число owner_id идентификатор владельца элемента.
		/// int (числовое значение) title заголовок.
		/// строка type тип элемента. Может принимать значения:
		/// video — видеоролик;
		/// album — альбом.
		/// строка
		/// type=video. Дополнительные поля для элемента-видеоролика
		/// duration длительность в секундах.
		/// положительное число description описание.
		/// строка date дата добавления.
		/// положительное число views число просмотров.
		/// положительное число comments число комментариев.
		/// положительное число photo_130 URL изображения-обложки видео с размером
		/// 130x98px.
		/// строка photo_320 URL изображения-обложки видео с размером 320x240px.
		/// строка photo_640 URL изображения-обложки видео с размером 640x480px (если
		/// размер есть).
		/// строка can_add наличие возможности добавить видео в свой список.
		/// флаг, может принимать значения 1 или 0 can_edit наличие возможности
		/// редактировать видео.
		/// флаг, может принимать значения 1 или 0
		/// type=album. Дополнительные поля для элемента-альбома
		/// count число видеозаписей в альбоме.
		/// положительное число photo_320 URL изображения-обложки альбома с размером
		/// 544x300px.
		/// строка photo_160 URL изображения-обложки альбома с размером 272x150px.
		/// строка updated_time время последнего обновления альбома.
		/// положительное число
		/// Если был передан параметр extended=1, возвращаются дополнительные объекты
		/// profiles и groups, содержащие информацию
		/// о пользователях и сообществах.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.getCatalogSection
		/// </remarks>
		public ReadOnlyCollection<VideoCatalogItem> GetCatalogSection(string sectionId
																	, string from
																	, long? count = null
																	, bool? extended = null)
		{
			var parameters = new VkParameters
			{
					{ "section_id", sectionId }
					, { "from", from }
					, { "count", count }
					, { "extended", extended }
			};

			return _vk.Call(methodName: "video.getCatalogSection", parameters: parameters)
					.ToReadOnlyCollectionOf<VideoCatalogItem>(selector: x => x);
		}

		/// <summary>
		/// Скрывает для пользователя раздел видеокаталога.
		/// </summary>
		/// <param name="sectionId">
		/// Значение id, полученное с блоком, который необходимо скрыть, в методе
		/// video.getCatalog
		/// обязательный параметр, целое число (Обязательный параметр, целое число).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/video.hideCatalogSection
		/// </remarks>
		public bool HideCatalogSection(long sectionId)
		{
			var parameters = new VkParameters
			{
					{ "section_id", sectionId }
			};

			return _vk.Call(methodName: "video.hideCatalogSection", parameters: parameters);
		}
	}
}