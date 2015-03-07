namespace VkNet.Categories
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using JetBrains.Annotations;

    using Utils;

    using Model.Attachments;
    using VkNet.Model;

    /// <summary>
    /// Методы для работы с документами (получение списка, загрузка, удаление и т.д.)
    /// </summary>
    public class DocsCategory
    {
        private readonly VkApi _vk;

        internal DocsCategory(VkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Возвращает расширенную информацию о документах пользователя или сообщества.
        /// </summary>
        /// <param name="count">Количество документов, информацию о которых нужно вернуть. По умолчанию — все документы.</param>
        /// <param name="offset">Смещение, необходимое для выборки определенного подмножества документов. Положительное число.</param>
        /// <param name="owner_id">Идентификатор пользователя или сообщества, которому принадлежат документы. Целое число, по умолчанию идентификатор текущего пользователя.</param>
        /// <returns>После успешного выполнения возвращает список объектов документов.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/docs.get"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.28")]
        public ReadOnlyCollection<Document> Get(int? count = null, int? offset = null, long? owner_id = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => count);
            VkErrors.ThrowIfNumberIsNegative(() => offset);

            var parameters = new VkParameters{ { "count", count }, { "offset", offset }, { "owner_id", owner_id } };

            VkResponse response = _vk.Call("docs.get", parameters);

            var totalCount = response["count"];

            VkResponseArray items = response["items"];
            return items.ToReadOnlyCollectionOf<Document>(r => r);
        }

        /// <summary>
        /// Возвращает информацию о документах по их идентификаторам.
        /// </summary>
        /// <param name="docs">Идентификаторы документов, информацию о которых нужно вернуть.</param>
        /// <returns>После успешного выполнения возвращает список объектов документов.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/docs.getById"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.28")]
        public ReadOnlyCollection<Document> GetById(IEnumerable<Document> docs)
        {
            foreach (var doc in docs)
            {
                VkErrors.ThrowIfNumberIsNegative(() => doc.Id);
                VkErrors.ThrowIfNumberIsNegative(() => doc.OwnerId);
            }

            var parameters = new VkParameters { { "docs", string.Concat(docs.Select(it => it.OwnerId + "_" + it.Id + ",")) } };

            VkResponse response = _vk.Call("docs.getById", parameters);
            return response.ToReadOnlyCollectionOf<Document>(r => r);
        }

        /// <summary>
        /// Возвращает адрес сервера для загрузки документов. 
        /// </summary>
        /// <param name="group_id">Идентификатор сообщества (если необходимо загрузить документ в список документов сообщества). Если документ нужно загрузить в список пользователя, метод вызывается без дополнительных параметров. Положительное число</param>
        /// <returns>После успешного выполнения возвращает объект <see cref="UploadServerInfo"/></returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/docs.getUploadServer"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.28")]
        public UploadServerInfo GetUploadServer(long? group_id = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => group_id);

            var parameters = new VkParameters { { "group_id", group_id } };

            return _vk.Call("docs.getUploadServer", parameters);
        }

        /// <summary>
        /// Возвращает адрес сервера для загрузки документов в папку Отправленные, для последующей отправки документа на стену или личным сообщением. 
        /// </summary>
        /// <param name="group_id">Идентификатор сообщества, в которое нужно загрузить документ. Положительное число.</param>
        /// <returns>После успешного выполнения возвращает объект <see cref="UploadServerInfo"/></returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/docs.getWallUploadServer"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.28")]
        public string GetWallUploadServer(long? group_id = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => group_id);

            var parameters = new VkParameters { { "group_id", group_id } };

            return _vk.Call("docs.getWallUploadServer", parameters);
        }

        /// <summary>
        /// Сохраняет документ после его успешной загрузки на сервер.
        /// </summary>
        /// <param name="file">Параметр, возвращаемый в результате загрузки файла на сервер. Обязательный параметр.</param>
        /// <param name="title">Название документа.</param>
        /// <param name="tags">Метки для поиска.</param>
        /// <param name="captcha_sid">Id капчи (только если для вызова метода необходимо ввести капчу)</param>
        /// <param name="captcha_key">Текст капчи (только если для вызова метода необходимо ввести капчу)</param>
        /// <returns>Возвращает массив с загруженными объектами. </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/docs.save"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.28")]
        public ReadOnlyCollection<Document> Save(string file, string title, string tags = null, long? captcha_sid = null, string captcha_key = null)
        {
            VkErrors.ThrowIfNullOrEmpty(() => file);
            VkErrors.ThrowIfNullOrEmpty(() => title);

            var parameters = new VkParameters
            {
                { "file", file },
                { "title", title },
                { "tags", tags },
                { "captcha_sid", captcha_sid },
                { "captcha_key", captcha_key },
            };

            VkResponse response = _vk.Call("docs.save", parameters);
            return response.ToReadOnlyCollectionOf<Document>(r => r);
        }

        /// <summary>
        /// Удаляет документ пользователя или группы. 
        /// </summary>
        /// <param name="owner_id">идентификатор пользователя или сообщества, которому принадлежит документ. Целое число, обязательный параметр</param>
        /// <param name="doc_id">Идентификатор документа. Положительное число, обязательный параметр</param>
        /// <returns>После успешного выполнения возвращает 1. </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/docs.delete"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.28")]
        public int Delete(long owner_id, long doc_id)
        {
            VkErrors.ThrowIfNumberIsNegative(() => owner_id);
            VkErrors.ThrowIfNumberIsNegative(() => doc_id);

            var parameters = new VkParameters { { "owner_id", doc_id }, { "doc_id", doc_id } };

            VkResponse response = _vk.Call("docs.delete", parameters);
            return response;
        }

        /// <summary>
        /// Копирует документ в документы текущего пользователя.
        /// </summary>
        /// <param name="owner_id">Идентификатор пользователя или сообщества, которому принадлежит документ. Целое число, обязательный параметр</param>
        /// <param name="doc_id">Идентификатор документа. Положительное число, обязательный параметр</param>
        /// <param name="access_key">Ключ доступа документа. Этот параметр следует передать, если вместе с остальными данными о документе было возвращено поле access_key.</param>
        /// <returns>После успешного выполнения возвращает идентификатор созданного документа (did).</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/docs.add"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.28")]
        public int Add(long owner_id, long doc_id, string access_key = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => owner_id);
            VkErrors.ThrowIfNumberIsNegative(() => doc_id);

            var parameters = new VkParameters { { "owner_id", owner_id }, { "doc_id", doc_id }, { "access_key", access_key } };

            return _vk.Call("docs.add", parameters);
        }
    }
}