namespace VkToolkit.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Enums;
    using Model;
    using Utils;

    /// <summary>
    /// Методы для работы с аудиозаписями.
    /// </summary>
    public class AudioCategory
    {
        private readonly VkApi _vk;

        public AudioCategory(VkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Возвращает количество аудиозаписей пользователя или группы.
        /// </summary>
        /// <param name="ownerId">
        /// Идентификатор владельца аудиозаписей (пользователь или сообщество). 
        /// Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — 
        /// например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1) 
        /// </param>
        /// <returns>
        /// Возвращает число, равное количеству аудиозаписей на странице пользователя или группы.
        /// </returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Audio"/>.
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/audio.getCount"/>.
        /// </remarks>
        public int GetCount(long ownerId)
        {
            var parameters = new VkParameters { { "owner_id", ownerId }, { "v", VkApi.Version } };

            return _vk.Call("audio.getCount", parameters);
        }

        /// <summary>
        /// Возвращает текст аудиозаписи по идентификатору текста аудиозаписи (<see cref="Audio.LyricsId"/>).
        /// Параметр <see cref="lyricsId"/> может быть получен с помощью методов <see cref="Get(long,out VkToolkit.Model.User,System.Nullable{long},System.Collections.Generic.IEnumerable{long},System.Nullable{int},System.Nullable{int})"/>,
        /// <see cref="GetById(System.Collections.Generic.IEnumerable{string})"/> или <see cref="Search"/>.
        /// </summary>
        /// <param name="lyricsId">Идентификатор текста аудиозаписи, информацию о котором необходимо вернуть.</param>
        /// <returns>В случае успеха возвращает найденный текст адиозаписи. В качестве переводов строк в тексте используется \n. </returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Audio"/>.
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/audio.getLyrics"/>.
        /// </remarks>
        public Lyrics GetLyrics(long lyricsId)
        {
            var parameters = new VkParameters { { "lyrics_id", lyricsId }, { "v", VkApi.Version } };

            return _vk.Call("audio.getLyrics", parameters);
        }

        /// <summary>
        /// Возвращает информацию об аудиозаписях. 
        /// </summary>
        /// <param name="audios">
        /// Список строковых идентификаторов аудиозаписей в формате - {owner_id}_{audio_id}.
        /// Если аудиозапись принадлежит группе, то в качестве первого параметра используется -id группы. 
        /// Примеры возможных значений идентификаторов: "2_67859194", "-683495_39822725", "2_63937759".
        /// </param>
        /// <returns>
        /// В случае успеха возвращает информацию о запрошенных аудиозаписях пользователя (группы).
        /// </returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Audio"/>.
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/audio.getById"/>.
        /// </remarks>
        public List<Audio> GetById(IEnumerable<string> audios)
        {
            if (audios == null)
                throw new ArgumentNullException("audios");

            var parameters = new VkParameters { { "audios", audios } };

            return _vk.Call("audio.getById", parameters);
        }

        /// <summary>
        /// Возвращает информацию об аудиозаписях. 
        /// </summary>
        /// <param name="audios">
        /// Список строковых идентификаторов аудиозаписей в формате - {owner_id}_{audio_id}.
        /// Если аудиозапись принадлежит группе, то в качестве первого параметра используется -id группы. 
        /// Примеры возможных значений идентификаторов: "2_67859194", "-683495_39822725", "2_63937759".
        /// </param>
        /// <returns>
        /// В случае успеха возвращает информацию о запрошенных аудиозаписях пользователя (группы).
        /// </returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Audio"/>.
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/audio.getById"/>.
        /// </remarks>
        public List<Audio> GetById(params string[] audios)
        {
            return GetById((IEnumerable<string>)audios);
        }

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
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/audio.get"/>.
        /// </remarks>       
        public List<Audio> GetFromGroup(long gid, long? albumId = null, IEnumerable<long> aids = null, int? count = null, int? offset = null)
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
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/audio.get"/>.
        /// </remarks>
        public List<Audio> Get(long uid, out User user, long? albumId = null, IEnumerable<long> aids = null, int? count = null, int? offset = null)
        {
            return InternalGet("uid", uid, out user, albumId, aids, true, count, offset);
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
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/audio.get"/>.
        /// </remarks>
        public List<Audio> Get(long uid, long? albumId = null, IEnumerable<long> aids = null, int? count = null, int? offset = null)
        {
            User user;
            return InternalGet("uid", uid, out user, albumId, aids, false, count, offset);
        }

        private List<Audio> InternalGet(
            string paramId,
            long id,
            out User user,
            long? albumId = null,
            IEnumerable<long> aids = null,
            bool? needUser = null,
            int? count = null,
            int? offset = null)
        {
            var parameters = new VkParameters
                             {
                                 { paramId, id },
                                 { "album_id", albumId },
                                 { "aids", aids },
                                 { "need_user", needUser },
                                 { "count", count },
                                 { "offset", offset }
                             };

            VkResponseArray response = _vk.Call("audio.get", parameters);

            IEnumerable<VkResponse> items = response.ToList();

            user = null;
            if (needUser.HasValue && needUser.Value && items.Any())
            {
                user = items.First();
                items = items.Skip(1);
            }

            return items.ToListOf(r => (Audio)r);
        }

        /// <summary>
        /// Возвращает адрес сервера для загрузки аудиозаписей. 
        /// </summary>
        /// <returns>
        /// В случае успеха возвращает адрес сервера для загрузки аудиозаписей.
        /// </returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Audio"/>.
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/audio.getUploadServer"/>.
        /// </remarks>
        public string GetUploadServer()
        {
            var response = _vk.Call("audio.getUploadServer", VkParameters.Empty);

            return response["upload_url"];
        }

        /// <summary>
        /// Возвращает список аудиозаписей в соответствии с заданным критерием поиска.
        /// </summary>
        /// <param name="query">Cтрока поискового запроса</param>
        /// <param name="totalCount">Общее количество аудиозаписей удовлетворяющих запросу</param>
        /// <param name="autoComplete">Если этот параметр равен true, возможные ошибки в поисковом запросе будут исправлены. Например, при поисковом запросе <strong>Иуфдуы</strong> поиск будет осуществляться по строке <strong>Beatles</strong></param>
        /// <param name="sort">Вид сортировки</param>
        /// <param name="findLyrics">Будет ли производиться только по тем аудиозаписям, которые содержат тексты.</param>
        /// <param name="count">Количество возвращаемых аудиозаписей (максимум 200).</param>
        /// <param name="offset">Смещение относительно первой найденной аудиозаписи для выборки определенного подмножества.</param>
        /// <returns>Список объектов класса Audio.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Audio"/>.
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/audio.search"/>.
        /// </remarks>
        public List<Audio> Search(
            string query,
            out int totalCount,
            bool? autoComplete = null,
            AudioSort? sort = null,
            bool? findLyrics = null,
            int? count = null,
            int? offset = null)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("Query is null or empty.", "query");

            var parameters = new VkParameters
                             {
                                 { "q", query },
                                 { "auto_complete", autoComplete },
                                 { "sort", sort },
                                 { "lyrics", findLyrics },
                                 { "count", count },
                                 { "offset", offset }
                             };

            VkResponseArray response = _vk.Call("audio.search", parameters);

            totalCount = response[0];

            return response.Skip(1).ToListOf(r => (Audio)r);
        }

        /// <summary>
        /// Копирует аудиозапись на страницу пользователя или группы. 
        /// </summary>
        /// <param name="audioId">id аудиозаписи</param>
        /// <param name="ownerId">id владельца аудиозаписи</param>
        /// <param name="groupId">id группы, в которую следует копировать аудиозапись. Если параметр не указан, аудиозапись копируется не в группу, а на страницу текущего пользователя. </param>
        /// <returns>Идентификатор созданной аудиозаписи</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Audio"/>.
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/audio.add"/>.
        /// </remarks>
        public long Add(long audioId, long ownerId, long? groupId = null)
        {
            var parameters = new VkParameters { { "aid", audioId }, { "oid", ownerId }, { "gid", groupId } };

            return _vk.Call("audio.add", parameters);
        }

        /// <summary>
        /// Удаляет аудиозапись со страницы пользователя или группы.
        /// </summary>
        /// <param name="audioId">id аудиозаписи</param>
        /// <param name="ownerId">id владельца аудиозаписи</param>
        /// <returns>При успешном удалении аудиозаписи сервер вернет true</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Audio"/>.
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/audio.delete"/>.
        /// </remarks>
        public bool Delete(long audioId, long ownerId)
        {
            var parameters = new VkParameters { { "aid", audioId }, { "oid", ownerId } };

            return _vk.Call("audio.delete", parameters);
        }

        /// <summary>
        /// Редактирует данные аудиозаписи на странице пользователя или группы. 
        /// </summary>
        /// <param name="audioId">id аудиозаписи</param>
        /// <param name="ownerId">id владельца аудиозаписи. Если редактируемая аудиозапись находится на странице группы, в этом параметре должно стоять значение, равное -id группы.</param>
        /// <param name="artist">Название исполнителя аудиозаписи.</param>
        /// <param name="title">Название аудиозаписи.</param>
        /// <param name="text">Текст аудиозаписи, если введен.</param>
        /// <param name="noSearch">true - скрывает аудиозапись из поиска по аудиозаписям, false (по умолчанию) - не скрывает.</param>
        /// <returns>id текста, введенного пользователем</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Audio"/>.
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/audio.edit"/>.
        /// </remarks>
        public long Edit(long audioId, long ownerId, string artist, string title, string text, bool noSearch = false)
        {
            if (artist == null)
                throw new ArgumentNullException("artist", "Artist parameter can not be null.");

            if (title == null)
                throw new ArgumentNullException("title", "Title parameter can not be null.");

            if (text == null)
                throw new ArgumentNullException("text", "Text parameter can not be null.");

            var parameters = new VkParameters
                             {
                                 { "aid", audioId },
                                 { "oid", ownerId },
                                 { "artist", artist },
                                 { "title", title },
                                 { "text", text },
                                 { "no_search", noSearch }
                             };

            return _vk.Call("audio.edit", parameters);
        }

        /// <summary>
        /// Восстанавливает удаленную аудиозапись пользователя после удаления.
        /// </summary>
        /// <param name="audioId">id удаленной аудиозаписи</param>
        /// <param name="ownerId">id владельца аудиозаписи</param>
        /// <returns>Удаленная аудиозапись.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Audio"/>.
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/audio.restore"/>.
        /// </remarks>
        public Audio Restore(long audioId, long? ownerId = null)
        {
            var parameters = new VkParameters { { "aid", audioId }, { "oid", ownerId } };

            return _vk.Call("audio.restore", parameters);
        }

        /// <summary>
        /// Изменяет порядок аудиозаписи, перенося ее между аудиозаписями, идентификаторы которых переданы параметрами after и before.
        /// </summary>
        /// <param name="audioId">id аудиозаписи, порядок которой изменяется</param>
        /// <param name="ownerId">id владельца изменяемой аудиозаписи</param>
        /// <param name="after">id аудиозаписи, после которой нужно поместить аудиозапись. Если аудиозапись переносится в начало, параметр может быть равен нулю.</param>
        /// <param name="before">id аудиозаписи, перед которой нужно поместить аудиозапись. Если аудиозапись переносится в конец, параметр может быть равен нулю.</param>
        /// <returns>При успешном изменении порядка аудиозаписи сервер вернет true</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Audio"/>.
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/audio.reorder"/>.
        /// </remarks>
        public bool Reorder(long audioId, long ownerId, long after, long before)
        {
            var parameters = new VkParameters { { "aid", audioId }, { "oid", ownerId }, { "after", after }, { "before", before } };

            return _vk.Call("audio.reorder", parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public long AddAlbum(string title, long? groupId = null)
        {
            VkErrors.ThrowIfNullOrEmpty(title);
            VkErrors.ThrowIfNumberIsNegative(groupId, "groupId");

            var parameters = new VkParameters
                {
                    {"title", title},
                    {"group_id", groupId}
                };

            VkResponse response = _vk.Call("audio.addAlbum", parameters);
            return response["album_id"];
        }

        // todo add comment
        public bool EditAlbum(string title, long albumId, long? groupId = null)
        {
            VkErrors.ThrowIfNullOrEmpty(title);
            VkErrors.ThrowIfNumberIsNegative(albumId, "albumId");
            VkErrors.ThrowIfNumberIsNegative(groupId, "groupId");

            var parameters = new VkParameters
                {
                    {"title", title},
                    {"group_id", groupId},
                    {"album_id", albumId}
                };

            VkResponse response = _vk.Call("audio.editAlbum", parameters);

            return response;
        }

        // todo add comment
        public bool DeleteAlbum(long albumId, long? groupId = null)
        {
            VkErrors.ThrowIfNumberIsNegative(albumId, "albumId");
            VkErrors.ThrowIfNumberIsNegative(groupId, "groupId");

            var parameters = new VkParameters
                {
                    {"album_id", albumId},
                    {"group_id", groupId}

                };

            return _vk.Call("audio.deleteAlbum", parameters);
        }

        // todo add comment
        public List<Audio> GetPopular(bool onlyEng = false, AudioGenre? genre = null, int? count = null, int? offset = null)
        {
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");
            VkErrors.ThrowIfNumberIsNegative(count, "count");

            var parameters = new VkParameters
                {
                    {"only_eng", onlyEng},
                    {"genre_id", genre},
                    {"offset", offset},
                    {"count", count}
                };

            VkResponseArray response = _vk.Call("audio.getPopular", parameters);

            return response.ToListOf<Audio>(x => x);
        }

        // todo add comment
        public List<AudioAlbum> GetAlbums(long ownerid, int? count = null, int? offset = null)
        {
            VkErrors.ThrowIfNumberIsNegative(ownerid, "ownerid");
            VkErrors.ThrowIfNumberIsNegative(count, "count");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");

            var parameters = new VkParameters
                {
                    {"owner_id", ownerid},
                    {"count", count},
                    {"offset", offset}
                };

            VkResponseArray response = _vk.Call("audio.getAlbums", parameters);

            return response.Skip(1).ToListOf<AudioAlbum>(x => x);
        }

        // todo add comment
        public bool MoveToAlbum(long albumId, IEnumerable<long> audioIds, long? groupId = null)
        {
            VkErrors.ThrowIfNumberIsNegative(albumId, "albumId");
            VkErrors.ThrowIfNumberIsNegative(groupId, "groupId");

            var parameters = new VkParameters
                {
                    {"album_id", albumId},
                    {"group_id", groupId}
                };
            parameters.Add("audio_ids", audioIds);

            VkResponse response = _vk.Call("audio.moveToAlbum", parameters);

            return response;
        }

        // todo add comment
        public List<Audio> GetRecommendations(long? userId = null, int? count = null, int? offset = null, bool shuffle = true, string targetAudio = "")
        {
            VkErrors.ThrowIfNumberIsNegative(userId, "userId");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");
            VkErrors.ThrowIfNumberIsNegative(count, "count");

            var parameters = new VkParameters
                {
                    {"target_audio", targetAudio},
                    {"user_id", userId},
                    {"offset", offset},
                    {"count", count},
                    {"shuffle", shuffle}
                };

            VkResponseArray response = _vk.Call("audio.getRecommendations", parameters);

            return response.ToListOf<Audio>(x => x);
        }

        // todo add comment
        public List<long> SetBroadcast(string audio, IEnumerable<long> targetIds)
        {
            VkErrors.ThrowIfNullOrEmpty(audio);

            var parameters = new VkParameters
                {
                    {"audio", audio}
                };
            parameters.Add("target_ids", targetIds);

            VkResponseArray response = _vk.Call("audio.setBroadcast", parameters);

            return response.ToListOf<long>(x => x);
        }

        /// <summary>
        /// НЕ РЕАЛИЗОВАН!
        /// </summary>
        public void GetBroadcastList()
        {
            // TODO Audio.GetBroadcastList - реализовать когда будет больше тестовых данных
            throw new NotImplementedException();
        }
    }
}