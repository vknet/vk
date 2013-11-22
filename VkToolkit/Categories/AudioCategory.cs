using System.Collections.Generic;
using System.Linq;
using VkToolkit.Enums;
using VkToolkit.Exception;
using VkToolkit.Model;
using VkToolkit.Utils;

namespace VkToolkit.Categories
{
    public class AudioCategory
    {
        private readonly VkApi _vk;

        public AudioCategory(VkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Возвращает список аудиозаписей группы.
        /// </summary>
        /// <param name="gid">id группы, которой принадлежат аудиозаписи. </param>
        /// <param name="albumId">id альбома, аудиозаписи которого необходимо вернуть (по умолчанию возвращаются аудиозаписи из всех альбомов).</param>
        /// <param name="aids">перечисленные через запятую id аудиозаписей, входящие в выборку по gid.</param>
        /// <param name="count">количество возвращаемых аудиозаписей.</param>
        /// <param name="offset">смещение относительно первой найденной аудиозаписи для выборки определенного подмножества.</param>
        /// <returns>Список объектов класса Audio.</returns>
        public List<Audio> GetFromGroup(long gid, long? albumId = null, IEnumerable<long> aids = null,  int? count = null, int? offset = null)
        {
            User user;
            return InternalGet("gid", gid, out user, albumId, aids, false, count, offset);
        }

        /// <summary>
        /// Возвращает список аудиозаписей пользователя.
        /// </summary>
        /// <param name="uid">id пользователя, которому принадлежат аудиозаписи</param>
        /// <param name="user">базовая информация о владельце аудиозаписей</param>
        /// <param name="albumId">id альбома, аудиозаписи которого необходимо вернуть (по умолчанию возвращаются аудиозаписи из всех альбомов).</param>
        /// <param name="aids">перечисленные через запятую id аудиозаписей, входящие в выборку по uid</param>
        /// <param name="count">количество возвращаемых аудиозаписей.</param>
        /// <param name="offset">смещение относительно первой найденной аудиозаписи для выборки определенного подмножества.</param>
        /// <returns>Список объектов класса Audio.</returns>
        public List<Audio> Get(long uid, out User user, long? albumId = null, IEnumerable<long> aids = null,  int? count = null, int? offset = null)
        {
            return InternalGet("uid", uid, out user, albumId, aids, true, count, offset);
        }

        /// <summary>
        /// Возвращает список аудиозаписей пользователя.
        /// </summary>
        /// <param name="uid">id пользователя, которому принадлежат аудиозаписи</param>
        /// <param name="albumId">id альбома, аудиозаписи которого необходимо вернуть (по умолчанию возвращаются аудиозаписи из всех альбомов).</param>
        /// <param name="aids">перечисленные через запятую id аудиозаписей, входящие в выборку по uid</param>
        /// <param name="count">количество возвращаемых аудиозаписей.</param>
        /// <param name="offset">смещение относительно первой найденной аудиозаписи для выборки определенного подмножества.</param>
        /// <returns>Список объектов класса Audio.</returns>
        public List<Audio> Get(long uid, long? albumId = null, IEnumerable<long> aids = null, int? count = null, int? offset = null)
        {
            User user;
            return InternalGet("uid", uid, out user, albumId, aids, false, count, offset);
        }

        private List<Audio> InternalGet(string paramId, long id, out User user, long? albumId = null, IEnumerable<long> aids = null, bool? needUser = null, int? count = null, int? offset = null)
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
        /// Возвращает информацию об аудиозаписях. 
        /// </summary>
        /// <param name="audios">Перечисленные идентификаторов – идущие через знак подчеркивания id пользователей, которым принадлежат аудиозаписи, и id самих аудиозаписей.</param>
        /// <returns>Список объектов класса Audio.</returns>
        public List<Audio> GetById(IEnumerable<string> audios)
        {
            if (audios == null)
                throw new InvalidParamException("audios param is null.");

            var parameters = new VkParameters { { "audios", audios } };

            return _vk.Call("audio.getById", parameters);
        }

        /// <summary>
        /// Возвращает количество аудиозаписей пользователя или группы.
        /// </summary>
        /// <param name="ownerId">id владельца аудиозаписей. Если необходимо получить количество аудиозаписей группы, в этом параметре должно стоять значение, равное -id группы.</param>
        /// <returns>Количество аудиозаписей.</returns>
        public int GetCount(long ownerId)
        {
            var parameters = new VkParameters { { "oid", ownerId } };

            return _vk.Call("audio.getCount", parameters);
        }

        /// <summary>
        /// Возвращает текст аудиозаписи.
        /// </summary>
        /// <param name="id">id текста аудиозаписи</param>
        /// <returns>Текст аудиозаписи и его id</returns>
        public Lyrics GetLyrics(long id)
        {
            var parameters = new VkParameters { { "lyrics_id", id } };

            return _vk.Call("audio.getLyrics", parameters);
        }

        /// <summary>
        /// Возвращает адрес сервера для загрузки аудиозаписей. 
        /// </summary>
        /// <returns>Адрес сервера для загрузки аудиозаписей</returns>
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
        public List<Audio> Search(string query, out int totalCount, bool? autoComplete = null, AudioSort? sort = null, bool? findLyrics = null, int? count = null, int? offset = null)
        {
            if (string.IsNullOrEmpty(query))
                throw new InvalidParamException("Query is null or empty.");

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
        /// <returns>идентификатор созданной аудиозаписи</returns>
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
        public long Edit(long audioId, long ownerId, string artist, string title, string text, bool noSearch = false)
        {
            if (artist == null)
                throw new InvalidParamException("artist parameter is null.");

            if (title == null)
                throw new InvalidParamException("title parameter is null.");

            if (text == null)
                throw new InvalidParamException("text parameter is null.");

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
        public bool Reorder(long audioId, long ownerId, long after, long before)
        {
            var parameters = new VkParameters { { "aid", audioId }, { "oid", ownerId }, { "after", after }, { "before", before } };

            return _vk.Call("audio.reorder", parameters);
        }
    }
}