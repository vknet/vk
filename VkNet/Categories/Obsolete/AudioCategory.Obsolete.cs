using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
    /// <summary>
    /// Методы для работы с аудиозаписями.
    /// </summary>
    public partial class AudioCategory
    {
        /// <summary>
        /// Возвращает список аудиозаписей группы.
        /// </summary>
        /// <param name="gid">Идентификатор группы, у которой необходимо получить аудиозаписи.</param>
        /// <param name="albumId">Идентификатор альбома, аудиозаписи которого необходимо вернуть (по умолчанию возвращаются аудиозаписи из всех альбомов).</param>
        /// <param name="aids">
        /// Список идентификаторов аудиозаписей группы, по которым необходимо получить информацию.
        /// Если список не указан (null), то ограничение на идентификаторы аудиозаписей на накладываются.
        /// </param>
        /// <param name="count">Требуемое количество аудиозаписей.</param>
        /// <param name="offset">Смещение относительно первой найденной аудиозаписи (для выборки определенного подмножества аудиозаписей).</param>
        /// <returns>
        /// В случае успеха возвращает затребованный список аудиозаписей группы.
        /// </returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Audio"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/audio.get"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.44")]
        [Obsolete("Данный метод устарел. Используйте Get(out User user, AudioGetParams @params)")]
        public ReadOnlyCollection<Audio> GetFromGroup(long gid, long? albumId = null, IEnumerable<long> aids = null, uint? count = null, uint? offset = null)
        {
            User user;
            return InternalGet("gid", gid, out user, albumId, aids, false, count, offset);
        }

        /// <summary>
        /// Возвращает список аудиозаписей пользователя и краткую информацию о нем.
        /// </summary>
        /// <param name="uid">Идентификатор пользователя, у которого необходимо получить аудиозаписи.</param>
        /// <param name="user">Базовая информация о владельце аудиозаписей - пользователе с идентификатором <paramref name="uid"/> (идентификатор, имя, фотография).</param>
        /// <param name="albumId">Идентификатор альбома пользователя, аудиозаписи которого необходимо получить (по умолчанию возвращаются аудиозаписи из всех альбомов).</param>
        /// <param name="aids">Список идентификаторов аудиозаписей пользователя, по которым необходимо получить информацию.</param>
        /// <param name="count">Требуемое количество аудиозаписей.</param>
        /// <param name="offset">Смещение относительно первой найденной аудиозаписи (для выборки определенного подмножества).</param>
        /// <returns>
        /// В случае успеха возвращает затребованный список аудиозаписей пользователя.
        /// </returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Audio"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/audio.get"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.44")]
        [Obsolete("Данный метод устарел. Используйте Get(out User user, AudioGetParams @params)")]
        public ReadOnlyCollection<Audio> Get(long uid, out User user, long? albumId = null, IEnumerable<long> aids = null, uint? count = null, uint? offset = null)
        {
            return InternalGet("uid", (long)uid, out user, albumId, aids, true, count, offset);
        }

        /// <summary>
        /// Возвращает список аудиозаписей пользователя.
        /// </summary>
        /// <param name="uid">Идентификатор пользователя, у которого необходимо получить аудиозаписи.</param>
        /// <param name="albumId">Идентификатор альбома пользователя, аудиозаписи которого необходимо получить (по умолчанию возвращаются аудиозаписи из всех альбомов).</param>
        /// <param name="aids">Список идентификаторов аудиозаписей пользователя, по которым необходимо получить информацию.</param>
        /// <param name="count">Требуемое количество аудиозаписей.</param>
        /// <param name="offset">Смещение относительно первой найденной аудиозаписи (для выборки определенного подмножества).</param>
        /// <returns>В случае успеха возвращает затребованный список аудиозаписей пользователя.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Audio"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/audio.get"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.44")]
        [Obsolete("Данный метод устарел. Используйте Get(out User user, AudioGetParams @params)")]
        public ReadOnlyCollection<Audio> Get(long uid, long? albumId = null, IEnumerable<long> aids = null, uint? count = null, uint? offset = null)
        {
            User user;
            return InternalGet("uid", (long)uid, out user, albumId, aids, false, count, offset);
        }

        /// <summary>
        /// Возвращает список аудиозаписей пользователя или сообщества.
        /// </summary>
        /// <param name="paramId">Идентификатор параметра.</param>
        /// <param name="id">Идентификатор пользователя или сообщества, у которого необходимо получить аудиозаписи.</param>
        /// <param name="user">Данные о пользователе.</param>
        /// <param name="albumId">Идентификатор альбома пользователя, аудиозаписи которого необходимо получить (по умолчанию возвращаются аудиозаписи из всех альбомов).</param>
        /// <param name="aids">Список идентификаторов аудиозаписей пользователя, по которым необходимо получить информацию.</param>
        /// <param name="needUser"><c>true</c> — возвращать информацию о пользователях, загрузивших аудиозапись.</param>
        /// <param name="count">Требуемое количество аудиозаписей.</param>
        /// <param name="offset">Смещение относительно первой найденной аудиозаписи (для выборки определенного подмножества).</param>
        /// <returns></returns>
        [Pure]
        [ApiVersion("5.44")]
        [Obsolete("Данный метод устарел. Используйте Get(out User user, AudioGetParams @params)")]
        private ReadOnlyCollection<Audio> InternalGet(
            string paramId,
            long id,
            out User user,
            long? albumId = null,
            IEnumerable<long> aids = null,
            bool? needUser = null,
            uint? count = null,
            uint? offset = null)
        {
            var parameters = new AudioGetParams
            {
                OwnerId = id,
                AlbumId = albumId,
                AudioIds = aids,
                NeedUser = needUser,
                Offset = offset,
                Count = count
            };

            return Get(out user, parameters);
        }

        /// <summary>
        /// Возвращает список аудиозаписей в соответствии с заданным критерием поиска.
        /// </summary>
        /// <param name="query">Cтрока поискового запроса</param>
        /// <param name="totalCount">Общее количество аудиозаписей удовлетворяющих запросу</param>
        /// <param name="autoComplete">Если этот параметр равен <c>true</c>, возможные ошибки в поисковом запросе будут исправлены. Например, при поисковом запросе <strong>Иуфдуы</strong> поиск будет осуществляться по строке <strong>Beatles</strong></param>
        /// <param name="sort">Вид сортировки</param>
        /// <param name="findLyrics">Будет ли производиться только по тем аудиозаписям, которые содержат тексты.</param>
        /// <param name="count">Количество возвращаемых аудиозаписей (максимум 200).</param>
        /// <param name="offset">Смещение относительно первой найденной аудиозаписи для выборки определенного подмножества.</param>
        /// <returns>Список объектов класса Audio.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Audio"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/audio.search"/>.
        /// </remarks>
        [Pure]
        [Obsolete("Данный метод устарел. Используйте Search(AudioSearchParams @params, out long totalCount)")]
        public ReadOnlyCollection<Audio> Search(
            string query,
            out long totalCount,
            bool? autoComplete = null,
            AudioSort? sort = null,
            bool? findLyrics = null,
            uint? count = null,
            uint? offset = null)
        {
            var parameters = new AudioSearchParams
            {
                Query = query,
                Autocomplete = autoComplete,
                Sort = sort,
                Lyrics = findLyrics,
                Count = Convert.ToInt32(count),
                Offset = offset
            };

            return Search(parameters, out totalCount);
        }

        /// <summary>
        /// Редактирует данные аудиозаписи на странице пользователя или группы.
        /// </summary>
        /// <param name="audioId">Идентификатор аудиозаписи</param>
        /// <param name="ownerId">Идентификатор владельца аудиозаписи. Если редактируемая аудиозапись находится на странице группы, в этом параметре должно стоять значение, равное -id группы.</param>
        /// <param name="artist">Название исполнителя аудиозаписи.</param>
        /// <param name="title">Название аудиозаписи.</param>
        /// <param name="text">Текст аудиозаписи, если введен.</param>
        /// <param name="noSearch"><c>true</c> - скрывает аудиозапись из поиска по аудиозаписям, <c>false</c> (по умолчанию) - не скрывает.</param>
        /// <param name="genreId">Идентификатор жанра из списка аудио жанров.</param>
        /// <returns>
        /// Идентификатор текста, введенного пользователем
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Artist parameter can not be <see langword="null"/>.
        /// or
        /// Title parameter can not be <see langword="null"/>.
        /// or
        /// Text parameter can not be <see langword="null"/>.
        /// </exception>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Audio" />.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/audio.edit" />.
        /// </remarks>
        [Obsolete("Данный метод устарел. Используйте Edit(AudioEditParams @params)")]
        public long Edit(long audioId, long ownerId, string artist, string title, string text, bool? noSearch = null, AudioGenre? genreId = AudioGenre.Other)
        {
            var parameters = new AudioEditParams
            {
                AudioId = audioId,
                OwnerId = ownerId,
                Artist = artist,
                Title = title,
                Text = text,
                NoSearch = noSearch,
                GenreId = genreId
            };

            return Edit(parameters);
        }
    }
}