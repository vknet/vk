namespace VkNet.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using JetBrains.Annotations;

    using Enums;
    using Enums.Filters;
    using Enums.SafetyEnums;
    using Model;
    using Model.Attachments;
    using Utils;

    /// <summary>
    /// Методы для работы с видеофайлами.
    /// </summary>
    public class VideoCategory
    {
        private readonly VkApi _vk;

        internal VideoCategory(VkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Возвращает информацию о видеозаписях.
        /// </summary>
        /// <param name="ownerId">
        /// Идентификатор пользователя или сообщества, которому принадлежат видеозаписи.
        /// Обратите внимание, идентификатор сообщества в параметре <paramref name="ownerId"/> необходимо указывать со знаком "-" — например, 
        /// <paramref name="ownerId"/>=-1 соответствует идентификатору сообщества ВКонтакте API (club1).
        /// </param>
        /// <param name="albumId">Идентификатор альбома, видеозаписи из которого нужно вернуть.</param>
        /// <param name="width">Требуемая ширина изображений видеозаписей в пикселах.</param>
        /// <param name="count">Количество возвращаемых видеозаписей.</param>
        /// <param name="offset">Смещение относительно первой найденной видеозаписи для выборки определенного подмножества.</param>
        /// <param name="extended">Определяет, возвращать ли информацию о настройках приватности видео для текущего пользователя.</param>
        /// <returns>После успешного выполнения возвращает список объектов видеозаписей с дополнительным полем comments, содержащим число комментариев у 
        /// видеозаписи. Если был задан параметр <paramref name="extended"/>, то для каждой видеозаписи возвращаются дополнительные поля: 
        /// <see cref="Video.CanComment"/>, <see cref="Video.CanRepost"/>, <see cref="Video.Likes"/></returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.get"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.9")]
        public ReadOnlyCollection<Video> Get(long? ownerId = null, long? albumId = null, VideoWidth width = VideoWidth.Medium160, int? count = null, int? offset = null, bool extended = false)
        {
            VkErrors.ThrowIfNumberIsNegative(() => albumId);
            VkErrors.ThrowIfNumberIsNegative(() => count);
            VkErrors.ThrowIfNumberIsNegative(() => offset);

            var parameters = new VkParameters
                {
                    {"owner_id", ownerId},
                    {"album_id", albumId},
                    {"width", width},
                    {"count", count},
                    {"offset", offset},
                    {"extended", extended}
                };

            VkResponseArray response = _vk.Call("video.get", parameters);

            return response.ToReadOnlyCollectionOf<Video>(x => x);
        }

        /// <summary>
        /// Редактирует данные видеозаписи на странице пользователя.
        /// </summary>
        /// <param name="videoId">Идентификатор видеозаписи.</param>
        /// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
        /// Обратите внимание, идентификатор сообщества в параметре <paramref name="ownerId"/> необходимо указывать со знаком "-" — например, 
        /// <paramref name="ownerId"/>=-1 соответствует идентификатору сообщества ВКонтакте API (club1).
        /// </param>
        /// <param name="name">Новое название для видеозаписи.</param>
        /// <param name="desc">Новое описание для видеозаписи.</param>
        /// <param name="privacyView">Настройки приватности для просмотра. 
        /// Могут принимать следующие значения: 
        /// <list type="number">
        ///     <item>
        ///         Простые значения приватности:
        ///         <list type="bullet">
        ///             <item>0 – все пользователи</item>
        ///             <item>1 – только друзья</item>
        ///             <item>2 – друзья и друзья друзей</item>
        ///             <item>3 - только я</item>
        ///         </list>
        ///     </item>
        ///     <item>
        ///         Для того, чтобы разрешить доступ только определённым друзьям необходимо указать значение параметра в соответствующем формате: 
        /// users: friendId, friendId, ...
        ///     </item>
        ///     <item>
        ///         Для того, чтобы разрешить доступ только определённым спискам друзей необходимо указать значение параметра в соответствующем формате: 
        /// lists: listId, flistId, ... Списки друзей Вы можете получить используя метод <see cref="FriendsCategory.GetLists"/>.
        /// </item>
        /// </list>
        /// </param>
        /// <param name="privacyComment">Настройки приватности для добавления комментариев  видео. 
        /// Формат задания тот же, что и для <paramref name="privacyView"/>.
        /// </param>
        /// <param name="isRepeat">Зацикливание воспроизведения видеозаписи.</param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.edit"/>.
        /// </remarks>
        [ApiVersion("5.9")]
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
                    {"repeat", isRepeat}
                };

            return _vk.Call("video.edit", parameters);
        }

        /// <summary>
        /// Добавляет видеозапись в список пользователя.
        /// </summary>
        /// <param name="videoId">Идентификатор видеозаписи.</param>
        /// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
        /// Обратите внимание, идентификатор сообщества в параметре <paramref name="ownerId"/> необходимо указывать со знаком "-" — например, 
        /// <paramref name="ownerId"/>=-1 соответствует идентификатору сообщества ВКонтакте API (club1).
        /// </param>
        /// <returns>После успешного выполнения возвращает идентификатор созданной видеозаписи.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.add"/>.
        /// </remarks>
        [ApiVersion("5.9")]
        public long Add(long videoId, long? ownerId = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            
            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId}
                };

            VkResponse response = _vk.Call("video.add", parameters);

            return response;
        }

        /// <summary>
        /// Возвращает адрес сервера (необходимый для загрузки) и данные видеозаписи.
        /// </summary>
        /// <param name="name">Название видеофайла.</param>
        /// <param name="description">Описание видеофайла.</param>
        /// <param name="isPrivate">Указывается true в случае последующей отправки видеозаписи личным сообщением. После загрузки с этим 
        /// параметром видеозапись не будет отображаться в списке видеозаписей пользователя и не будет доступна другим пользователям 
        /// по id.</param>
        /// <param name="isPostToWall">Требуется ли после сохранения опубликовать запись с видео на стене.</param>
        /// <param name="link">Url для встраивания видео с внешнего сайта, например, с youtube. В этом случае нужно вызвать полученный 
        /// <see cref="Video.UploadUrl"/>, не прикрепляя файл, достаточно просто обратиться по этому адресу.</param>
        /// <param name="groupId">Идентификатор сообщества, в которое будет сохранен видеофайл. По умолчанию файл сохраняется на страницу
        /// текущего пользователя.</param>
        /// <param name="albumId">Идентификатор альбома, в который будет загружен видео файл.</param>
        /// <param name="isRepeat">Зацикливание воспроизведения видеозаписи.</param>
        /// <returns>Возвращает объект видеозаписи, который имеет поля <see cref="Video.UploadUrl"/>, <see cref="MediaAttachment.Id"/>, 
        /// <see cref="Video.Title"/>, <see cref="Video.Description"/> и <see cref="MediaAttachment.OwnerId"/>.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.save"/>.
        /// Метод может быть вызван не более 5000 раз в сутки для одного сервиса. 
        /// </remarks>
        [ApiVersion("5.9")]
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
                    {"repeat", isRepeat}
                };

            return _vk.Call("video.save", parameters);
        }

        /// <summary>
        /// Удаляет видеозапись со страницы пользователя.
        /// </summary>
        /// <param name="videoId">Идентификатор видеозаписи.</param>
        /// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
        /// Обратите внимание, идентификатор сообщества в параметре <paramref name="ownerId"/> необходимо указывать со знаком "-" — например, 
        /// <paramref name="ownerId"/>=-1 соответствует идентификатору сообщества ВКонтакте API (club1).
        /// </param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.delete"/>.
        /// </remarks>
        [ApiVersion("5.9")]
        public bool Delete(long videoId, long? ownerId = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            
            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId}
                };

            return _vk.Call("video.delete", parameters);
        }

        /// <summary>
        /// Восстанавливает удаленную видеозапись.
        /// </summary>
        /// <param name="videoId">Идентификатор видеозаписи.</param>
        /// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
        /// Если <paramref name="ownerId"/> не указан, то производится восстановление видеозаписи у текущего пользователя.
        /// Обратите внимание, идентификатор сообщества в параметре <paramref name="ownerId"/> необходимо указывать со знаком "-" — например, 
        /// <paramref name="ownerId"/>=-1 соответствует идентификатору сообщества ВКонтакте API (club1).
        /// </param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.restorehttp://vk.com/dev/video.restore"/>.
        /// </remarks>
        [ApiVersion("5.9")]
        public bool Restore(long videoId, long? ownerId = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            
            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId}
                };

            return _vk.Call("video.restore", parameters);
        }

        /// <summary>
        /// Возвращает список видеозаписей в соответствии с заданным критерием поиска.
        /// </summary>
        /// <param name="query">Строка поискового запроса.</param>
        /// <param name="sort">Вид сортировки.</param>
        /// <param name="isHd">Если true, то поиск производится только по видеозаписям высокого качества.</param>
        /// <param name="isAdult">Фильтр «Безопасный поиск».</param>
        /// <param name="filters">Список критериев, по которым требуется отфильтровать видео.</param>
        /// <param name="isSearchOwn">Искать по видеозаписям пользователя.</param>
        /// <param name="count">
        /// Количество возвращаемых видеозаписей.
        /// Обратите внимание — даже при использовании параметра <paramref name="offset"/> для получения информации доступны только первые 1000 результатов. 
        /// </param>
        /// <param name="offset">Смещение относительно первой найденной видеозаписи для выборки определенного подмножества.</param>
        /// <returns>После успешного выполнения возвращает список объектов видеозаписей.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.search"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.9")]
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
                    {"count", count}
                };

            VkResponseArray response = _vk.Call("video.search", parameters);
            return response.ToReadOnlyCollectionOf<Video>(x => x);
        }

        /// <summary>
        /// Возвращает список видеозаписей, на которых отмечен пользователь.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="count">Количество возвращаемых видеозаписей.</param>
        /// <param name="offset">Смещение относительно первой найденной видеозаписи для выборки определенного подмножества.</param>
        /// <returns>После успешного выполнения возвращает список объектов видеозаписей.</returns>
        /// <remarks>
        /// ЭТОТ МЕТОД ВЫБРАСЫВАЕТ ИСКЛЮЧЕНИЕ НА СЕРВЕРЕ ВК!!!
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.getUserVideos"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.9")]
        public ReadOnlyCollection<Video> GetUserVideos(long userId, int? count = null, int? offset = null)
        {
            // throw new NotImplementedException("Метод некорректно работает на самом сервере вконтакте");

            VkErrors.ThrowIfNumberIsNegative(() => userId);
            VkErrors.ThrowIfNumberIsNegative(() => count);
            VkErrors.ThrowIfNumberIsNegative(() => offset);

            var parameters = new VkParameters
                {
                    {"user_id", userId},
                    {"count", count},
                    {"offset", offset}
                };

            VkResponseArray response = _vk.Call("video.getUserVideos", parameters);

            return response.ToReadOnlyCollectionOf<Video>(x => x);
        }

        /// <summary>
        /// Возвращает список альбомов видеозаписей пользователя или сообщества.
        /// </summary>
        /// <param name="ownerId">Идентификатор владельца альбомов (пользователь или сообщество). По умолчанию — идентификатор текущего 
        /// пользователя.</param>
        /// <param name="count">Количество альбомов, информацию о которых нужно вернуть.
        /// По умолчанию — не больше 50, максимум — 100. 
        /// </param>
        /// <param name="offset">Смещение, необходимое для выборки определенного подмножества альбомов.</param>
        /// <param name="extended">true – позволяет получать поля <see cref="VideoAlbum.Count"/>, <see cref="VideoAlbum.Photo160"/> и 
        /// <see cref="VideoAlbum.Photo320"/> для каждого альбома.</param>
        /// <returns>
        /// После успешного выполнения возвращает массив объектов <see cref="VideoAlbum"/>, каждый из которых содержит следующие 
        /// поля: <see cref="VideoAlbum.Id"/>, <see cref="VideoAlbum.OwnerId"/> и <see cref="VideoAlbum.Title"/>.
        /// </returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.getAlbums"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.9")]
        public ReadOnlyCollection<VideoAlbum> GetAlbums(long ownerId, int? count = null, int? offset = null, bool extended = false)
        {
            VkErrors.ThrowIfNumberIsNegative(() => count);
            VkErrors.ThrowIfNumberIsNegative(() => offset);

            var parameters = new VkParameters
                {
                    {"owner_id", ownerId},
                    {"count", count},
                    {"offset", offset},
                    {"extended", extended}
                };

            VkResponseArray response = _vk.Call("video.getAlbums", parameters);

            return response.ToReadOnlyCollectionOf<VideoAlbum>(x => x);
        }

        /// <summary>
        /// Создает пустой альбом видеозаписей.
        /// </summary>
        /// <param name="title">Название альбома.</param>
        /// <param name="groupId">Идентификатор сообщества (если необходимо создать альбом в сообществе).</param>
        /// <returns>После успешного выполнения возвращает идентификатор созданного альбома.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.addAlbum"/>.
        /// </remarks>
        [ApiVersion("5.9")]
        public long AddAlbum(string title, long? groupId = null)
        {
            VkErrors.ThrowIfNullOrEmpty(() => title);
            VkErrors.ThrowIfNumberIsNegative(() => groupId);

            var parameters = new VkParameters
                {
                    {"group_id", groupId},
                    {"title", title}
                };
            
            VkResponse response = _vk.Call("video.addAlbum", parameters);

            return response["album_id"];
        }

        /// <summary>
        /// Редактирует название альбома видеозаписей.
        /// </summary>
        /// <param name="albumId">Идентификатор альбома.</param>
        /// <param name="title">Новое название для альбома.</param>
        /// <param name="groupId">Идентификатор сообщества (если нужно отредактировать альбом, принадлежащий сообществу).</param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.editAlbum"/>.
        /// </remarks>
        [ApiVersion("5.9")]
        public bool EditAlbum(long albumId, string title, long? groupId = null)
        {
            VkErrors.ThrowIfNullOrEmpty(() => title);
            VkErrors.ThrowIfNumberIsNegative(() => albumId);
            VkErrors.ThrowIfNumberIsNegative(() => groupId);

            var parameters = new VkParameters
                {
                    {"album_id", albumId},
                    {"title", title},
                    {"group_id", groupId}
                };

            return _vk.Call("video.editAlbum", parameters);
        }

        /// <summary>
        /// Удаляет альбом видеозаписей.
        /// </summary>
        /// <param name="albumId">Идентификатор альбома.</param>
        /// <param name="groupId">Идентификатор сообщества (если альбом, который необходимо удалить, принадлежит сообществу).</param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.deleteAlbum"/>.
        /// </remarks>
        [ApiVersion("5.9")]
        public bool DeleteAlbum(long albumId, long? groupId = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => albumId);
           
            var parameters = new VkParameters
                {
                    {"group_id", groupId},
                    {"album_id", albumId}
                };

            return _vk.Call("video.deleteAlbum", parameters);
        }

        /// <summary>
        /// Перемещает видеозаписи в альбом.
        /// </summary>
        /// <param name="videoIds">Список идентификаторов видеороликов.</param>
        /// <param name="albumId">Идентификатор альбома, в который перемещаются видеозаписи.</param>
        /// <param name="groupId">Идентификатор сообщества, которому принадлежат видеозаписи. Если параметр не указан, то работа 
        /// ведется с альбомом текущего пользователя.</param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.moveToAlbum"/>.
        /// </remarks>
        [ApiVersion("5.9")]
        public bool MoveToAlbum(IEnumerable<long> videoIds, long albumId, long? groupId = null)
        {
            if (videoIds == null)
                throw new ArgumentNullException("videoIds", "Не указаны идентификаторы видеозаписей.");

            VkErrors.ThrowIfNumberIsNegative(() => albumId);

            var parameters = new VkParameters { { "album_id", albumId }, { "group_id", groupId } };
            parameters.Add("video_ids", videoIds);
            
            return _vk.Call("video.moveToAlbum", parameters);
        }

        /// <summary>
        /// Возвращает список комментариев к видеозаписи.
        /// </summary>
        /// <param name="videoId">Идентификатор видеозаписи.</param>
        /// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
        /// Обратите внимание, идентификатор сообщества в параметре <paramref name="ownerId"/> необходимо указывать со знаком "-" — например, 
        /// <paramref name="ownerId"/>=-1 соответствует идентификатору сообщества ВКонтакте API (club1).
        /// </param>
        /// <param name="needLikes">true — будет возвращено дополнительное поле <see cref="Comment.Likes"/>. По умолчанию поле <see cref="Comment.Likes"/> 
        /// не возвращается.</param>
        /// <param name="count">Количество комментариев, информацию о которых необходимо вернуть.
        /// (по умолчанию 20, максимальное значение 100).
        /// </param>
        /// <param name="offset">Смещение, необходимое для выборки определенного подмножества комментариев.</param>
        /// <param name="sort">Порядок сортировки комментариев.</param>
        /// <returns>После успешного выполнения возвращает общее количество комментариев и массив объектов <see cref="Comment"/>.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.getComments"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.9")]
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
                    {"sort", sort}
                };

            VkResponse response = _vk.Call("video.getComments", parameters);

            return response.ToReadOnlyCollectionOf<Comment>(x => x);
        }

        /// <summary>
        /// ДАННЫЙ МЕТОД НЕ РЕАЛИЗОВАН!!!
        /// </summary>
        /// <param name="attach"></param>
        /// <returns></returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.createComment"/>.
        /// </remarks>
        public long CreateComment(Attachment attach)
        {
            // todo сделать версию с прикладыванием приложения
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cоздает новый комментарий к видеозаписи.
        /// </summary>
        /// <param name="videoId">Идентификатор видеозаписи.</param>
        /// <param name="message">Текст комментария.</param>
        /// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
        /// Обратите внимание, идентификатор сообщества в параметре <paramref name="ownerId"/> необходимо указывать со знаком "-" — например, 
        /// <paramref name="ownerId"/>=-1 соответствует идентификатору сообщества ВКонтакте API (club1).
        /// </param>
        /// <param name="isFromGroup">Данный параметр учитывается, если <paramref name="ownerId"/> &lt; 0 (комментарий к видеозаписи группы). 
        /// true — комментарий будет опубликован от имени группы, false — комментарий будет опубликован от имени пользователя.
        /// (по умолчанию).</param>
        /// <returns>После успешного выполнения возвращает идентификатор созданного комментария.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.createComment"/>.
        /// </remarks>
        [ApiVersion("5.9")]
        public long CreateComment(long videoId, string message, long? ownerId, bool isFromGroup = false)
        {
            VkErrors.ThrowIfNullOrEmpty(() => message);
            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            
            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"message", message},
                    {"from_group", isFromGroup}
                };

            return _vk.Call("video.createComment", parameters);
        }

        /// <summary>
        /// Удаляет комментарий к видеозаписи.
        /// </summary>
        /// <param name="commentId">Идентификатор комментария.</param>
        /// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит видеозапись.</param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.deleteComment"/>.
        /// </remarks>
        [ApiVersion("5.9")]
        public bool DeleteComment(long commentId, long? ownerId)
        {
            VkErrors.ThrowIfNumberIsNegative(() => commentId);
            
            var parameters = new VkParameters {{ "comment_id", commentId }, { "owner_id", ownerId }};

            return _vk.Call("video.deleteComment", parameters);
        }

        /// <summary>
        /// Восстанавливает удаленный комментарий к видеозаписи.
        /// </summary>
        /// <param name="commentId">Идентификатор удаленного комментария.</param>
        /// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
        /// Обратите внимание, идентификатор сообщества в параметре <paramref name="ownerId"/> необходимо указывать со знаком "-" — например, 
        /// <paramref name="ownerId"/>=-1 соответствует идентификатору сообщества ВКонтакте API (club1).
        /// </param>
        /// <returns>После успешного выполнения возвращает true, false если комментарий с таким идентификатором не является удаленным.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.restoreComment"/>.
        /// </remarks>
        [ApiVersion("5.9")]
        public bool RestoreComment(long commentId, long? ownerId)
        {
            VkErrors.ThrowIfNumberIsNegative(() => commentId);
            
            var parameters = new VkParameters {{ "comment_id", commentId }, { "owner_id", ownerId }};

            return _vk.Call("video.restoreComment", parameters);
        }

        /// <summary>
        /// ДАННЫЙ МЕТОД НЕ РЕАЛИЗОВАН!!!
        /// </summary>
        /// <param name="attach"></param>
        /// <returns></returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.editComment"/>.
        /// </remarks>
        public bool EditComment(Attachment attach)
        {
            // todo add version with attachment
            throw new NotImplementedException();
        }

        /// <summary>
        /// Изменяет текст комментария к видеозаписи.
        /// </summary>
        /// <param name="commentId">Идентификатор комментария.</param>
        /// <param name="message">Новый текст комментария.</param>
        /// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
        /// Обратите внимание, идентификатор сообщества в параметре <paramref name="ownerId"/> необходимо указывать со знаком "-" — например, 
        /// <paramref name="ownerId"/>=-1 соответствует идентификатору сообщества ВКонтакте API (club1).
        /// </param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.editComment"/>.
        /// </remarks>
        [ApiVersion("5.9")]
        public bool EditComment(long commentId, string message, long? ownerId)
        {
            VkErrors.ThrowIfNullOrEmpty(() => message);
            VkErrors.ThrowIfNumberIsNegative(() => commentId);
            
            var parameters = new VkParameters
                {
                    {"comment_id", commentId},
                    {"message", message},
                    {"owner_id", ownerId}
                };

            return _vk.Call("video.editComment", parameters);
        }
        
        /// <summary>
        /// Возвращает список отметок на видеозаписи. 
        /// </summary>
        /// <param name="videoId">Идентификатор видеозаписи.</param>
        /// <param name="ownerId">Идентификатор владельца видеозаписи (пользователь или сообщество). По умолчанию — идентификатор текущего пользователя.</param>
        /// <returns>После успешного выполнения возвращает массив объектов <see cref="Tag"/>, каждый из которых содержит следующие поля:
        /// <see cref="Tag.Id"/>, <see cref="Tag.Id"/>, <see cref="Tag.PlacerId"/>, <see cref="Tag.Name"/>, <see cref="Tag.Date"/> и <see cref="Tag.IsViewed"/>.
        /// </returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.getTags"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.9")]
        public ReadOnlyCollection<Tag> GetTags(long videoId, long? ownerId)
        {
            // todo add unit test

            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            
            var parameters = new VkParameters {{ "video_id", videoId }, { "owner_id", ownerId }};

            VkResponseArray response = _vk.Call("video.getTags", parameters);

            return response.ToReadOnlyCollectionOf<Tag>(t => t);
        }
        
        /// <summary>
        /// Добавляет отметку на видеозапись. 
        /// </summary>
        /// <param name="videoId">Идентификатор видеозаписи.</param>
        /// <param name="userId">Идентификатор пользователя, которого нужно отметить.</param>
        /// <param name="ownerId">Идентификатор владельца видеозаписи (пользователь или сообщество). По умолчанию — идентификатор текущего пользователя.</param>
        /// <param name="taggedName">Текст отметки.</param>
        /// <returns>После успешного выполнения возвращает идентификатор созданной отметки <see cref="Tag.Id"/>.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.putTag"/>.
        /// </remarks>
        [ApiVersion("5.9")]
        public long PutTag(long videoId, long userId, long? ownerId, string taggedName)
        {
            // todo add unit tests

            VkErrors.ThrowIfNumberIsNegative(() => videoId);
            VkErrors.ThrowIfNumberIsNegative(() => userId);

            var parameters = new VkParameters
                {
                    {"user_id", userId},
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"tagged_name", taggedName}
                };

            return _vk.Call("video.putTag", parameters);
        }
        
        /// <summary>
        /// Удаляет отметку с видеозаписи. 
        /// </summary>
        /// <param name="tagId">Идентификатор отметки.</param>
        /// <param name="videoId">Идентификатор видеозаписи.</param>
        /// <param name="ownerId">Идентификатор владельца видеозаписи (пользователь или сообщество). По умолчанию — идентификатор текущего пользователя.</param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.removeTag"/>.
        /// </remarks>
        [ApiVersion("5.9")]
        public bool RemoveTag(long tagId, long videoId, long? ownerId)
        {
            // todo add unit test

            VkErrors.ThrowIfNumberIsNegative(() => tagId);
            VkErrors.ThrowIfNumberIsNegative(() => videoId);

            var parameters = new VkParameters
                {
                    {"tag_id", tagId},
                    {"video_id", videoId},
                    {"owner_id", ownerId}
                };

            return _vk.Call("video.removeTag", parameters);
        }
        
        /// <summary>
        /// Возвращает список видеозаписей, на которых есть непросмотренные отметки. 
        /// </summary>
        /// <param name="count">Количество видеозаписей, которые необходимо вернуть (максимальное значение 100, по умолчанию 20).
        /// </param>
        /// <param name="offset">Смещение, необходимое для получения определённого подмножества видеозаписей.</param>
        /// <returns>
        /// После успешного выполнения возвращает список объектов <see cref="Video"/> с дополнительным полем <see cref="Video.Tag"/>.
        /// </returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.getNewTags"/>.
        /// </remarks>        
        [Pure]
        [ApiVersion("5.9")]
        public ReadOnlyCollection<Video> GetNewTags(int? count = null, int? offset = null)
        {
            // todo add unit test + parse new fields

            VkErrors.ThrowIfNumberIsNegative(() => count);
            VkErrors.ThrowIfNumberIsNegative(() => offset);

            var parameters = new VkParameters
                {
                    {"count", count},
                    {"offset", offset}
                };

            VkResponseArray response = _vk.Call("video.getNewTags", parameters);

            return response.ToReadOnlyCollectionOf<Video>(x => x);
        }

        /// <summary>
        /// Позволяет пожаловаться на видеозапись.
        /// </summary>
        /// <param name="videoId">Идентификатор видеозаписи.</param>
        /// <param name="reason">Тип жалобы.</param>
        /// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит видеозапись.</param>
        /// <param name="comment">Комментарий для жалобы.</param>
        /// <param name="searchQuery">Поисковой запрос, если видеозапись была найдена через поиск.</param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.report"/>.
        /// </remarks>
        [ApiVersion("5.9")]    
        public bool Report(long videoId, VideoReportType reason, long? ownerId, string comment = null, string searchQuery = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);

            var parameters = new VkParameters
                {
                    {"video_id", videoId},
                    {"owner_id", ownerId},
                    {"reason", reason},
                    {"comment", comment},
                    {"search_query", searchQuery}
                };

            return _vk.Call("video.report", parameters);
        }

        /// <summary>
        /// Позволяет пожаловаться на комментарий к видеозаписи.
        /// </summary>
        /// <param name="commentId">Идентификатор комментария.</param>
        /// <param name="ownerId">Идентификатор владельца видеозаписи, к которой оставлен комментарий.</param>
        /// <param name="reason">Тип жалобы</param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Video"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/video.reportComment"/>.
        /// </remarks>
        [ApiVersion("5.9")]  
        public bool ReportComment(long commentId, long ownerId, VideoReportType reason)
        {
            VkErrors.ThrowIfNumberIsNegative(() => commentId);

            var parameters = new VkParameters
                {
                    {"comment_id", commentId},
                    {"owner_id", ownerId},
                    {"reason", reason}
                };

            return _vk.Call("video.reportComment", parameters);
        }
    }
}