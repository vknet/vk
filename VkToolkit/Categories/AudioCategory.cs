using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
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
        public IEnumerable<Audio> GetFromGroup(long gid, long? albumId = null, IEnumerable<long> aids = null,  int? count = null, int? offset = null)
        {
            Profile user;
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
        public IEnumerable<Audio> Get(long uid, out Profile user, long? albumId = null, IEnumerable<long> aids = null,  int? count = null, int? offset = null)
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
        public IEnumerable<Audio> Get(long uid, long? albumId = null, IEnumerable<long> aids = null, int? count = null, int? offset = null)
        {
            Profile user;
            return InternalGet("uid", uid, out user, albumId, aids, false, count, offset);
        }

        private IEnumerable<Audio> InternalGet(string paramId, long id, out Profile user, long? albumId = null, IEnumerable<long> aids = null, bool? needUser = null, int? count = null, int? offset = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add(paramId, id + "");
            if (albumId.HasValue && albumId.Value > 0)
                values.Add("album_id", albumId + "");
            if (aids != null)
                values.Add("aids", Utilities.GetEnumerationAsString(aids));
            if (needUser.HasValue && needUser.Value)
                values.Add("need_user", "1");
            else
                user = null;
            if (count.HasValue && count.Value > 0)
                values.Add("count", count.Value + "");
            if (offset.HasValue && offset.Value > 0)
                values.Add("offset", offset.Value + "");

            string url = _vk.GetApiUrl("audio.get", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            user = null;
            var output = new List<Audio>();
            foreach (var t in response)
            {
                if (user == null && needUser.HasValue && needUser.Value)
                {
                    user = Utilities.GetProfileFromJObject((JObject) t);
                    continue;
                }
                Audio audio = Utilities.GetAudioFromJObject((JObject) t);
                output.Add(audio);
            }
            return output;
        }

        /// <summary>
        /// Возвращает информацию об аудиозаписях. 
        /// </summary>
        /// <param name="audios">перечисленные идентификаторов – идущие через знак подчеркивания id пользователей, которым принадлежат аудиозаписи, и id самих аудиозаписей.</param>
        /// <returns>Список объектов класса Audio.</returns>
        public IEnumerable<Audio> GetById(IEnumerable<string> audios)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            if (audios == null)
                throw new InvalidParamException("audios param is null.");

            var values = new Dictionary<string, string>();
            values.Add("audios", Utilities.GetEnumerationAsString(audios));

            string url = _vk.GetApiUrl("audio.getById", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            return response.Select(it => Utilities.GetAudioFromJObject((JObject) it)).ToList();
        }

        /// <summary>
        /// Возвращает количество аудиозаписей пользователя или группы.
        /// </summary>
        /// <param name="oid">id владельца аудиозаписей. Если необходимо получить количество аудиозаписей группы, в этом параметре должно стоять значение, равное -id группы.</param>
        /// <returns>Количество аудиозаписей.</returns>
        public int GetCount(long oid)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("oid", oid + "");

            string url = _vk.GetApiUrl("audio.getCount", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (string) obj["response"];

            int count;
            return int.TryParse(response, out count) ? count : 0;
        }

        /// <summary>
        /// Возвращает текст аудиозаписи.
        /// </summary>
        /// <param name="id">id текста аудиозаписи</param>
        /// <returns>Текст аудиозаписи и его id</returns>
        public Lyrics GetLyrics(long id)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("lyrics_id", id + "");

            string url = _vk.GetApiUrl("audio.getLyrics", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JObject)obj["response"];

            return Utilities.GetLyrics(response);
        }

        /// <summary>
        /// Возвращает адрес сервера для загрузки аудиозаписей. 
        /// </summary>
        /// <returns>Адрес сервера для загрузки аудиозаписей</returns>
        public string GetUploadServer()
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            string url = _vk.GetApiUrl("audio.getUploadServer", new Dictionary<string, string>());
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            return (string)obj["response"]["upload_url"];
        }

        /// <summary>
        /// Возвращает список аудиозаписей в соответствии с заданным критерием поиска.
        /// </summary>
        /// <param name="query">строка поискового запроса</param>
        /// <param name="totalCount">Общее количество аудиозаписей удовлетворяющих запросу</param>
        /// <param name="autoComplete">Если этот параметр равен true, возможные ошибки в поисковом запросе будут исправлены. Например, при поисковом запросе <strong>Иуфдуы</strong> поиск будет осуществляться по строке <strong>Beatles</strong></param>
        /// <param name="sort">Вид сортировки</param>
        /// <param name="findLyrics">Будет ли производиться только по тем аудиозаписям, которые содержат тексты.</param>
        /// <param name="count">количество возвращаемых аудиозаписей (максимум 200).</param>
        /// <param name="offset">смещение относительно первой найденной аудиозаписи для выборки определенного подмножества.</param>
        /// <returns>Список объектов класса Audio.</returns>
        public IEnumerable<Audio> Search(string query, out int totalCount, bool? autoComplete = null, AudioSort? sort = null, bool? findLyrics = null, int? count = null, int? offset = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            if (string.IsNullOrEmpty(query))
                throw new InvalidParamException("Query is null or empty.");

            var values = new Dictionary<string, string>();
            values.Add("q", query);
            if (autoComplete.HasValue && autoComplete.Value)
                values.Add("auto_complete", "1");
            if (sort.HasValue)
                values.Add("sort", (int)sort + "");
            if (findLyrics.HasValue && findLyrics.Value)
                values.Add("lyrics", "1");
            if (count.HasValue && count.Value > 0)
                values.Add("count", count + "");
            if (offset.HasValue && offset.Value > 0)
                values.Add("offset", offset + "");

            string url = _vk.GetApiUrl("audio.search", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var array = (JArray)obj["response"];

            totalCount = (int) array[0];

            var output = new List<Audio>();
            for (int i = 1; i < array.Count; i++)
            {
                Audio audio = Utilities.GetAudioFromJObject((JObject) array[i]);
                output.Add(audio);

            }
            return output;
        }

        /// <summary>
        /// Копирует аудиозапись на страницу пользователя или группы. 
        /// </summary>
        /// <param name="aid">id аудиозаписи</param>
        /// <param name="oid">id владельца аудиозаписи</param>
        /// <param name="gid">id группы, в которую следует копировать аудиозапись</param>
        /// <returns>идентификатор созданной аудиозаписи</returns>
        public long Add(long aid, long oid, long? gid = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("aid", aid + "");
            values.Add("oid", oid + "");
            if (gid.HasValue)
                values.Add("gid", gid + "");

            string url = _vk.GetApiUrl("audio.add", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            return (long)obj["response"];
        }

        /// <summary>
        /// Удаляет аудиозапись со страницы пользователя или группы.
        /// </summary>
        /// <param name="aid">id аудиозаписи</param>
        /// <param name="oid">id владельца аудиозаписи</param>
        /// <returns>При успешном удалении аудиозаписи сервер вернет true</returns>
        public bool Delete(long aid, long oid)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("aid", aid + "");
            values.Add("oid", oid + "");

            string url = _vk.GetApiUrl("audio.delete", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            return (int)obj["response"] == 1;
        }

        /// <summary>
        /// Редактирует данные аудиозаписи на странице пользователя или группы. 
        /// </summary>
        /// <param name="aid">id аудиозаписи</param>
        /// <param name="oid">id владельца аудиозаписи. Если редактируемая аудиозапись находится на странице группы, в этом параметре должно стоять значение, равное -id группы.</param>
        /// <param name="artist">название исполнителя аудиозаписи.</param>
        /// <param name="title">название аудиозаписи.</param>
        /// <param name="text">текст аудиозаписи, если введен.</param>
        /// <param name="noSearch">true - скрывает аудиозапись из поиска по аудиозаписям, false (по умолчанию) - не скрывает.</param>
        /// <returns> id текста, введенного пользователем</returns>
        public long Edit(long aid, long oid, string artist, string title, string text, bool noSearch = false)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            if (artist == null)
                throw new InvalidParamException("artist parameter is null.");

            if (title == null)
                throw new InvalidParamException("title parameter is null.");

            if (text == null)
                throw new InvalidParamException("text parameter is null.");

            var values = new Dictionary<string, string>();
            values.Add("aid", aid + "");
            values.Add("oid", oid + "");
            values.Add("artist", artist);
            values.Add("title", title);
            values.Add("text", text);
            values.Add("no_search", noSearch ? "1" : "0");

            string url = _vk.GetApiUrl("audio.edit", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            return (long) obj["response"];
        }

        /// <summary>
        /// Восстанавливает удаленную аудиозапись пользователя после удаления.
        /// </summary>
        /// <param name="audioId">id удаленной аудиозаписи</param>
        /// <param name="ownerId">id владельца аудиозаписи</param>
        /// <returns>Удаленная аудиозапись.</returns>
        public Audio Restore(long audioId, long? ownerId = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("aid", audioId + "");
            if (ownerId.HasValue)
                values.Add("oid",ownerId + "");

            string url = _vk.GetApiUrl("audio.restore", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JObject) obj["response"];

            return Utilities.GetAudioFromJObject(response);
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
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("aid", audioId + "");
            values.Add("oid", ownerId + "");
            values.Add("after", after + "");
            values.Add("before", before + "");

            string url = _vk.GetApiUrl("audio.reorder", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            return (int)obj["response"] == 1;
        }
    }
}