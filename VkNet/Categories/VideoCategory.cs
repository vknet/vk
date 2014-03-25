namespace VkNet.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using JetBrains.Annotations;

    using Enums;
    using Model;
    using Utils;

    /// <summary>
    /// Методы для работы с видео.
    /// </summary>
    public class VideoCategory
    {
        private readonly VkApi _vk;

        public VideoCategory(VkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Возвращает информацию о видеозаписях.
        /// </summary>
        /// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежат видеозаписи.</param>
        /// <param name="albumId">идентификатор альбома, видеозаписи из которого нужно вернуть. </param>
        /// <param name="width">требуемая ширина изображений видеозаписей в пикселах. </param>
        /// <param name="count">количество возвращаемых видеозаписей. </param>
        /// <param name="offset">смещение относительно первой найденной видеозаписи для выборки определенного подмножества. </param>
        /// <param name="extended">определяет, возвращать ли информацию о настройках приватности видео для текущего пользователя. </param>
        /// <returns>После успешного выполнения возвращает список объектов видеозаписей с дополнительным полем comments, содержащим число комментариев у видеозаписи. </returns>
        /// <remarks>
        /// 
        /// </remarks>
        [Pure]
        public ReadOnlyCollection<Video> Get(long? ownerId = null, long? albumId = null, VideoWidth width = VideoWidth.Medium160, int? count = null, int? offset = null, bool extended = false)
        {
            VkErrors.ThrowIfNumberIsNegative(albumId, "albumId");
            VkErrors.ThrowIfNumberIsNegative(count, "count");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");

            var parameters = new VkParameters
                {
                    {"owner_id", ownerId},
                    {"album_id", albumId},
                    {"width", width},
                    {"count", count},
                    {"offset", offset},
                    {"extended", extended},
                    {"v", _vk.Version}
                };

            VkResponseArray response = _vk.Call("video.get", parameters);

            return response.ToReadOnlyCollectionOf<Video>(x => x);
        }

        /// <summary>
        /// Редактирует данные видеозаписи на странице пользователя.
        /// </summary>
        /// <param name="videoId">идентификатор видеозаписи.</param>
        /// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит видеозапись.</param>
        /// <param name="name">новое название для видеозаписи. </param>
        /// <param name="desc">новое описание для видеозаписи.</param>
        /// <param name="privacyView">настройки приватности</param>
        /// <param name="privacyComment">настройки приватности</param>
        /// <param name="isRepeat">зацикливание воспроизведения видеозаписи.</param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// 
        /// </remarks>
        public bool Edit(long videoId, long? ownerId = null, string name = null, string desc = null, string privacyView = null, string privacyComment = null, bool isRepeat = false)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);

            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"name", name},
                    {"desc", desc},
                    {"privacy_view", privacyView},
                    {"privacy_comment", privacyComment},
                    {"repeat", isRepeat},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.edit", parameters);
        }

        /// <summary>
        /// Добавляет видеозапись в список пользователя.
        /// </summary>
        /// <param name="videoId">идентификатор видеозаписи.</param>
        /// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит видеозапись.</param>
        /// <returns>После успешного выполнения возвращает идентификатор созданной видеозаписи.</returns>
        /// <remarks>
        /// 
        /// </remarks>
        public long Add(long videoId, long? ownerId = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            
            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"v", _vk.Version}
                };

            VkResponse response = _vk.Call("video.add", parameters);

            return response;
        }

        /// <summary>
        /// Возвращает адрес сервера (необходимый для загрузки) и данные видеозаписи.
        /// </summary>
        /// <param name="name">название видеофайла. </param>
        /// <param name="description">описание видеофайла.</param>
        /// <param name="isPrivate">указывается true в случае последующей отправки видеозаписи личным сообщением. После загрузки с этим параметром видеозапись не будет отображаться в списке видеозаписей пользователя и не будет доступна другим пользователям по id.</param>
        /// <param name="isPostToWall">требуется ли после сохранения опубликовать запись с видео на стене</param>
        /// <param name="link">url для встраивания видео с внешнего сайта, например, с youtube. В этом случае нужно вызвать полученный upload_url не прикрепляя файл, достаточно просто обратиться по этому адресу. </param>
        /// <param name="groupId">идентификатор сообщества, в которое будет сохранен видеофайл. По умолчанию файл сохраняется на страницу текущего пользователя. </param>
        /// <param name="albumId">идентификатор альбома, в который будет загружен видео файл.</param>
        /// <param name="isRepeat">зацикливание воспроизведения видеозаписи.</param>
        /// <returns>Возвращает объект видеозаписи, который имеет поля upload_url, video_id, title, description, owner_id. </returns>
        /// <remarks>
        /// 
        /// </remarks>
        public Video Save(string name = null, string description = null, bool isPrivate = false, bool isPostToWall = false, string link = null, long? groupId = null, long? albumId = null, bool isRepeat = false)
        {
            var parameters = new VkParameters
                {
                    {"name", name},
                    {"description", description},
                    {"is_private", isPrivate},
                    {"wallpost", isPostToWall},
                    {"link", link},
                    {"group_id", groupId},
                    {"album_id", albumId},
                    {"repeat", isRepeat},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.save", parameters);
        }

        /// <summary>
        /// Удаляет видеозапись со страницы пользователя.
        /// </summary>
        /// <param name="videoId">идентификатор видеозаписи.</param>
        /// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит видеозапись.</param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// 
        /// </remarks>
        public bool Delete(long videoId, long? ownerId = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            
            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.delete", parameters);
        }

        /// <summary>
        /// Восстанавливает удаленную видеозапись.
        /// </summary>
        /// <param name="videoId">идентификатор видеозаписи.</param>
        /// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит видеозапись.</param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// 
        /// </remarks>
        public bool Restore(long videoId, long? ownerId = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            
            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.restore", parameters);
        }

        /// <summary>
        /// Возвращает список видеозаписей в соответствии с заданным критерием поиска.
        /// </summary>
        /// <param name="query">строка поискового запроса.</param>
        /// <param name="sort">вид сортировки. </param>
        /// <param name="isHd">если true, то поиск производится только по видеозаписям высокого качества. </param>
        /// <param name="isAdult">фильтр «Безопасный поиск» </param>
        /// <param name="filters">список критериев, по которым требуется отфильтровать видео.</param>
        /// <param name="isSearchOwn">искать по видеозаписям пользователя.</param>
        /// <param name="count">количество возвращаемых видеозаписей.</param>
        /// <param name="offset">смещение относительно первой найденной видеозаписи для выборки определенного подмножества. </param>
        /// <returns>После успешного выполнения возвращает список объектов видеозаписей. </returns>
        /// <remarks>
        /// 
        /// </remarks>
        [Pure]
        public ReadOnlyCollection<Video> Search(string query, VideoSort sort, bool isHd = false, bool isAdult = false, VideoFilters filters = null, bool isSearchOwn = false, int? count = null, int? offset = null)
        {
            VkErrors.ThrowIfNullOrEmpty(() => query);
            VkErrors.ThrowIfNumberIsNegative(() => count);
            VkErrors.ThrowIfNumberIsNegative(() => offset);

            var parameters = new VkParameters
                {
                    {"q", query},
                    {"sort", sort},
                    {"hd", isHd},
                    {"adult", isAdult},
                    {"filters", filters},
                    {"search_own", isSearchOwn},
                    {"offset", offset},
                    {"count", count},
                    {"v", _vk.Version}
                };

            VkResponseArray response = _vk.Call("video.search", parameters);
            return response.ToReadOnlyCollectionOf<Video>(x => x);
        }

        /// <summary>
        /// Возвращает список видеозаписей, на которых отмечен пользователь.
        /// </summary>
        /// <param name="userId">идентификатор пользователя. </param>
        /// <param name="count">количество возвращаемых видеозаписей. </param>
        /// <param name="offset">смещение относительно первой найденной видеозаписи для выборки определенного подмножества. </param>
        /// <returns>После успешного выполнения возвращает список объектов видеозаписей.</returns>
        /// <remarks>
        /// ЭТОТ МЕТОД ВЫБРАСЫВАЕТ ИСКЛЮЧЕНИЕ НА СЕРВЕРЕ ВК!!!
        /// </remarks>
        [Pure]
        public ReadOnlyCollection<Video> GetUserVideos(long userId, int? count = null, int? offset = null)
        {
            //throw new NotImplementedException("Метод некорректно работает на самом сервере вконтакте");

            VkErrors.ThrowIfNumberIsNegative(userId, "userId");
            VkErrors.ThrowIfNumberIsNegative(count, "count");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");

            var parameters = new VkParameters
                {
                    {"user_id", userId},
                    {"count", count},
                    {"offset", offset},
                    {"v", _vk.Version}
                };

            VkResponseArray response = _vk.Call("video.getUserVideos", parameters);

            return response.ToReadOnlyCollectionOf<Video>(x => x);
        }

        /// <summary>
        /// Возвращает список альбомов видеозаписей пользователя или сообщества.
        /// </summary>
        /// <param name="ownerId">идентификатор владельца альбомов (пользователь или сообщество). По умолчанию — идентификатор текущего пользователя. </param>
        /// <param name="count">количество альбомов, информацию о которых нужно вернуть.</param>
        /// <param name="offset">смещение, необходимое для выборки определенного подмножества альбомов.</param>
        /// <param name="extended">True – позволяет получать поля count, photo320 и photo160 для каждого альбома.</param>
        /// <returns>После успешного выполнения возвращает массив объектов Album</returns>
        /// <remarks>
        /// 
        /// </remarks>
        [Pure]
        public ReadOnlyCollection<VideoAlbum> GetAlbums(long ownerId, int? count = null, int? offset = null, bool extended = false)
        {
            VkErrors.ThrowIfNumberIsNegative(() => count);
            VkErrors.ThrowIfNumberIsNegative(() => offset);

            var parameters = new VkParameters
                {
                    {"owner_id", ownerId},
                    {"count", count},
                    {"offset", offset},
                    {"extended", extended},
                    {"v", _vk.Version}
                };

            VkResponseArray response = _vk.Call("video.getAlbums", parameters);

            return response.ToReadOnlyCollectionOf<VideoAlbum>(x => x);
        }

        /// <summary>
        /// Создает пустой альбом видеозаписей.
        /// </summary>
        /// <param name="title">название альбома.</param>
        /// <param name="groupId">идентификатор сообщества (если необходимо создать альбом в сообществе).</param>
        /// <returns>После успешного выполнения возвращает идентификатор созданного альбома.</returns>
        /// <remarks>
        /// 
        /// </remarks>
        public long AddAlbum(string title, long? groupId = null)
        {
            VkErrors.ThrowIfNullOrEmpty(() => title);
            VkErrors.ThrowIfNumberIsNegative(() => groupId);

            var parameters = new VkParameters
                {
                    {"group_id", groupId},
                    {"title", title},
                    {"v", _vk.Version}
                };
            
            VkResponse response = _vk.Call("video.addAlbum", parameters);

            return response["album_id"];
        }

        /// <summary>
        /// Редактирует название альбома видеозаписей.
        /// </summary>
        /// <param name="albumId">идентификатор альбома. </param>
        /// <param name="title">новое название для альбома. </param>
        /// <param name="groupId">идентификатор сообщества (если нужно отредактировать альбом, принадлежащий сообществу). </param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// 
        /// </remarks>
        public bool EditAlbum(long albumId, string title, long? groupId = null)
        {
            VkErrors.ThrowIfNullOrEmpty(() => title);
            VkErrors.ThrowIfNumberIsNegative(() => albumId);
            VkErrors.ThrowIfNumberIsNegative(() => groupId);

            var parameters = new VkParameters
                {
                    {"album_id", albumId},
                    {"title", title},
                    {"group_id", groupId},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.editAlbum", parameters);
        }

        /// <summary>
        /// Удаляет альбом видеозаписей.
        /// </summary>
        /// <param name="albumId">идентификатор альбома.</param>
        /// <param name="groupId">идентификатор сообщества (если альбом, который необходимо удалить, принадлежит сообществу). </param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// 
        /// </remarks>
        public bool DeleteAlbum(long albumId, long? groupId = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => albumId);
           
            var parameters = new VkParameters
                {
                    {"group_id", groupId},
                    {"album_id", albumId},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.deleteAlbum", parameters);
        }

        /// <summary>
        /// Перемещает видеозаписи в альбом.
        /// </summary>
        /// <param name="videoIds">список идентификаторов видеороликов. </param>
        /// <param name="albumId">идентификатор альбома, в который перемещаются видеозаписи. </param>
        /// <param name="groupId">идентификатор сообщества, которому принадлежат видеозаписи. Если параметр не указан, то работа ведется с альбомом текущего пользователя.</param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// 
        /// </remarks>
        public bool MoveToAlbum(IEnumerable<long> videoIds, long albumId, long? groupId = null)
        {
            if (videoIds == null)
                throw new ArgumentNullException("Не указаны идентификаторы видеозаписей.", "videoIds");

            VkErrors.ThrowIfNumberIsNegative(() => albumId);

            var parameters = new VkParameters { { "album_id", albumId }, { "group_id", groupId } };
            parameters.Add("video_ids", videoIds);
            parameters.Add("v", _vk.Version);

            return _vk.Call("video.moveToAlbum", parameters);
        }

        /// <summary>
        /// Возвращает список комментариев к видеозаписи.
        /// </summary>
        /// <param name="videoId">идентификатор видеозаписи. </param>
        /// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит видеозапись.</param>
        /// <param name="needLikes">true — будет возвращено дополнительное поле likes. По умолчанию поле likes не возвращается.</param>
        /// <param name="count">количество комментариев, информацию о которых необходимо вернуть.</param>
        /// <param name="offset">смещение, необходимое для выборки определенного подмножества комментариев.</param>
        /// <param name="sort">порядок сортировки комментариев (asc — от старых к новым, desc — от новых к старым)</param>
        /// <returns>После успешного выполнения возвращает общее количество комментариев и массив объектов Comment.</returns>
        /// <remarks>
        /// 
        /// </remarks>
        [Pure]
        public ReadOnlyCollection<Comment> GetComments(long videoId, long? ownerId = null, bool needLikes = false, int? count = null, int? offset = null, CommentsSort sort = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            VkErrors.ThrowIfNumberIsNegative(() => count);
            VkErrors.ThrowIfNumberIsNegative(() => offset);

            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"need_likes", needLikes},
                    {"count", count},
                    {"offset", offset},
                    {"sort", sort},
                    {"v", _vk.Version}
                };

            VkResponse response = _vk.Call("video.getComments", parameters);

            return response.ToReadOnlyCollectionOf<Comment>(x => x);
        }

        /// <summary>
        /// ДАННЫЙ МЕТОД НЕ РЕАЛИЗОВАН!!!
        /// </summary>
        /// <param name="attach"></param>
        /// <returns></returns>
        public long CreateComment(Attachment attach)
        {
            // todo сделать версию с прикладыванием приложения
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cоздает новый комментарий к видеозаписи.
        /// </summary>
        /// <param name="videoId">идентификатор видеозаписи. </param>
        /// <param name="message">текст комментария</param>
        /// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит видеозапись.</param>
        /// <param name="isFromGroup">Данный параметр учитывается, если oid &lt; false (комментарий к видеозаписи группы). True — комментарий будет опубликован от имени группы, false — комментарий будет опубликован от имени пользователя (по умолчанию).</param>
        /// <returns>После успешного выполнения возвращает идентификатор созданного комментария.</returns>
        /// <remarks>
        /// 
        /// </remarks>
        public long CreateComment(long videoId, string message, long? ownerId, bool isFromGroup = false)
        {
            VkErrors.ThrowIfNullOrEmpty(() => message);
            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            
            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"message", message},
                    {"from_group", isFromGroup},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.createComment", parameters);
        }

        /// <summary>
        /// Удаляет комментарий к видеозаписи.
        /// </summary>
        /// <param name="commentId">идентификатор комментария. </param>
        /// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит видеозапись.</param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// 
        /// </remarks>
        public bool DeleteComment(long commentId, long? ownerId)
        {
            VkErrors.ThrowIfNumberIsNegative(() => commentId);
            
            var parameters = new VkParameters { { "comment_id", commentId }, { "owner_id", ownerId }, {"v", _vk.Version} };

            return _vk.Call("video.deleteComment", parameters);
        }

        /// <summary>
        /// Восстанавливает удаленный комментарий к видеозаписи.
        /// </summary>
        /// <param name="commentId">идентификатор удаленного комментария.</param>
        /// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит видеозапись.</param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// 
        /// </remarks>
        public bool RestoreComment(long commentId, long? ownerId)
        {
            VkErrors.ThrowIfNumberIsNegative(() => commentId);
            
            var parameters = new VkParameters { { "comment_id", commentId }, { "owner_id", ownerId }, { "v", _vk.Version } };

            return _vk.Call("video.restoreComment", parameters);
        }

        /// <summary>
        /// ДАННЫЙ МЕТОД НЕ РЕАЛИЗОВАН!!!
        /// </summary>
        /// <param name="attach"></param>
        /// <returns></returns>
        public bool EditComment(Attachment attach)
        {
            // todo add version with attachment
            throw new NotImplementedException();
        }

        /// <summary>
        /// Изменяет текст комментария к видеозаписи.
        /// </summary>
        /// <param name="commentId">идентификатор комментария. </param>
        /// <param name="message">новый текст комментария </param>
        /// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит видеозапись.</param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// 
        /// </remarks>
        public bool EditComment(long commentId, string message, long? ownerId)
        {
            VkErrors.ThrowIfNullOrEmpty(() => message);
            VkErrors.ThrowIfNumberIsNegative(() => commentId);
            
            var parameters = new VkParameters
                {
                    {"comment_id", commentId},
                    {"message", message},
                    {"owner_id", ownerId},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.editComment", parameters);
        }

        // todo add unit test
        [Pure]
        public void GetTags(long videoId, long? ownerId)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            
            var parameters = new VkParameters { { "video_id", videoId }, { "owner_id", ownerId }, {"v", _vk.Version} };

            VkResponseArray response = _vk.Call("video.getTags", parameters);

            throw new NotImplementedException();
        }

        // todo add unit tests
        public long PutTag(long videoId, long userId, long? ownerId, string taggedName)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            VkErrors.ThrowIfNumberIsNegative(() => userId);

            var parameters = new VkParameters
                {
                    {"user_id", userId},
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"tagged_name", taggedName},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.putTag", parameters);

            throw new NotImplementedException();
        }

        // todo add unit test
        public bool RemoveTag(long tagId, long videoId, long? ownerId)
        {
            VkErrors.ThrowIfNumberIsNegative(() => tagId);
            VkErrors.ThrowIfNumberIsNegative(() => videoId);

            var parameters = new VkParameters
                {
                    {"tag_id", tagId},
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.removeTag", parameters);

            throw new NotImplementedException();
        }

        // todo add unit test + parse new fields
        [Pure]
        public ReadOnlyCollection<Video> GetNewTags(int? count = null, int? offset = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => count);
            VkErrors.ThrowIfNumberIsNegative(() => offset);

            var parameters = new VkParameters
                {
                    {"count", count},
                    {"offset", offset},
                    {"v", _vk.Version}
                };

            VkResponseArray response = _vk.Call("video.getNewTags", parameters);

            return response.ToReadOnlyCollectionOf<Video>(x => x);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Позволяет пожаловаться на видеозапись.
        /// </summary>
        /// <param name="videoId">идентификатор видеозаписи. </param>
        /// <param name="reason">тип жалобы</param>
        /// <param name="ownerId">идентификатор пользователя или сообщества, которому принадлежит видеозапись.</param>
        /// <param name="comment">комментарий для жалобы.</param>
        /// <param name="searchQuery">поисковой запрос, если видеозапись была найдена через поиск.</param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// 
        /// </remarks>
        public bool Report(long videoId, VideoReportType reason, long? ownerId, string comment = null, string searchQuery = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);

            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"reason", reason},
                    {"comment", comment},
                    {"search_query", searchQuery},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.report", parameters);
        }

        /// <summary>
        /// Позволяет пожаловаться на комментарий к видеозаписи.
        /// </summary>
        /// <param name="commentId">идентификатор комментария.</param>
        /// <param name="ownerId">идентификатор владельца видеозаписи, к которой оставлен комментарий.</param>
        /// <param name="reason">тип жалобы</param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// 
        /// </remarks>
        public bool ReportComment(long commentId, long ownerId, VideoReportType reason)
        {
            VkErrors.ThrowIfNumberIsNegative(() => commentId);

            var parameters = new VkParameters
                {
                    {"comment_id", commentId},
                    {"owner_id", ownerId},
                    {"reason", reason},
                    {"v", _vk.Version}
                };

            return _vk.Call("video.reportComment", parameters);
        }
    }
}