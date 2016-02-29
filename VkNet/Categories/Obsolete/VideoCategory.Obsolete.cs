using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using VkNet.Enums;
using VkNet.Enums.Filters;
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
    public partial class VideoCategory
    {
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
        [ApiVersion("5.44")]
        [Obsolete("Данный метод устарел. Используйте Get(VideoGetParams @params)")]
        public ReadOnlyCollection<Video> Get(long? ownerId = null, long? albumId = null, VideoWidth width = VideoWidth.Medium160, int? count = null, int? offset = null, bool extended = false)
        {
            var parameters = new VideoGetParams
            {
                OwnerId = ownerId,
                AlbumId = albumId,
                Count = count,
                Offset = offset,
                Extended = extended
            };
            return Get(parameters);
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
        /// <param name="description">Новое описание для видеозаписи.</param>
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
        /// users: friendId, friendId, ..
        ///     </item>
        ///     <item>
        ///         Для того, чтобы разрешить доступ только определённым спискам друзей необходимо указать значение параметра в соответствующем формате:
        /// lists: listId, flistId, .. Списки друзей Вы можете получить используя метод <see cref="FriendsCategory.GetLists"/>.
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
        [ApiVersion("5.44")]
        [Obsolete("Данный метод устарел. Используйте Edit(VideoEditParams @params)")]
        public bool Edit(long videoId, long? ownerId = null, string name = null, string description = null, IEnumerable<Privacy> privacyView = null, IEnumerable<Privacy> privacyComment = null, bool isRepeat = false)
        {
            VkErrors.ThrowIfNumberIsNegative(() => videoId);

            var parameters = new VideoEditParams
            {
                VideoId = videoId,
                OwnerId = ownerId,
                Name = name,
                Desc = description,
                PrivacyComment = privacyComment,
                PrivacyView = privacyView,
                Repeat = isRepeat
            };

            return Edit(parameters);
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
        [ApiVersion("5.44")]
        [Obsolete("Данный метод устарел. Используйте Save(VideoSaveParams @params)")]
        public Video Save(string name = null, string description = null, bool isPrivate = false, bool isPostToWall = false, string link = null, long? groupId = null, long? albumId = null, bool isRepeat = false)
        {
            var parameters = new VideoSaveParams
            {
                Name = name,
                Description = description,
                IsPrivate = isPrivate,
                Wallpost = isPostToWall,
                Link = link,
                GroupId = groupId,
                AlbumId = albumId,
                Repeat = isRepeat
            };

            return Save(parameters);
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
        [ApiVersion("5.44")]
        [Obsolete("Данный метод устарел. Используйте Search(VideoSearchParams @params)")]
        public ReadOnlyCollection<Video> Search(string query, VideoSort sort, bool isHd = false, bool isAdult = false, VideoFilters filters = null, bool isSearchOwn = false, int? count = null, int? offset = null)
        {
            var parameters = new VideoSearchParams
            {
                Query = query,
                Sort = sort,
                Hd = isHd,
                Adult = isAdult,
                Filters = filters,
                SearchOwn = isSearchOwn,
                Offset = offset,
                Count = count
            };

            return Search(parameters);
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
        [ApiVersion("5.44")]
        [Obsolete("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования.")]
        public bool MoveToAlbum(IEnumerable<long> videoIds, long albumId, long? groupId = null)
        {
	        throw new System.Exception("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования.");
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
        [ApiVersion("5.44")]
        [Obsolete("Данный метод устарел. Используйте GetComments(VideoGetCommentsParams @params)")]
        public ReadOnlyCollection<Comment> GetComments(long videoId, long? ownerId = null, bool needLikes = false, int? count = null, int? offset = null, CommentsSort sort = null)
        {
            var parameters = new VideoGetCommentsParams
            {
                VideoId = videoId,
                OwnerId = ownerId,
                NeedLikes = needLikes,
                Count = count,
                Offset = offset,
                Sort = sort
            };
            return GetComments(parameters);
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
        [ApiVersion("5.44")]
        [Obsolete("Данный метод устарел. Используйте CreateComment(VideoCreateCommentParams @params)")]
        public long CreateComment(long videoId, string message, long? ownerId, bool isFromGroup = false)
        {
            var parameters = new VideoCreateCommentParams
            {
                VideoId = videoId,
                OwnerId = ownerId,
                Message = message,
                FromGroup = isFromGroup
            };

            return CreateComment(parameters);
        }

    }
}