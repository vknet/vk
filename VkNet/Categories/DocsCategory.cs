using VkNet.Enums.SafetyEnums;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using VkNet.Abstractions;
using VkNet.Enums;
using VkNet.Utils;
using VkNet.Model.Attachments;
using VkNet.Model;

namespace VkNet.Categories
{
    /// <summary>
    /// Методы для работы с документами (получение списка, загрузка, удаление и т.д.)
    /// </summary>
    public partial class DocsCategory : IDocsCategory
    {
        /// <summary>
        /// API
        /// </summary>
        private readonly VkApi _vk;

        /// <summary>
        /// Методы для работы с документами (получение списка, загрузка, удаление и т.д.).
        /// </summary>
        /// <param name="vk">API.</param>
        public DocsCategory(VkApi vk)
        {
            _vk = vk;
        }

        /// <inheritdoc />
        [Pure]
        public VkCollection<Document> Get(int? count = null, int? offset = null, long? ownerId = null,
            DocFilter? type = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => count);
            VkErrors.ThrowIfNumberIsNegative(() => offset);

            var parameters = new VkParameters
            {
                {"count", count},
                {"offset", offset},
                {"owner_id", ownerId},
                {"type", type}
            };

            return _vk.Call("docs.get", parameters).ToVkCollectionOf<Document>(r => r);
        }

        /// <inheritdoc />
        [Pure]
        public ReadOnlyCollection<Document> GetById(IEnumerable<Document> docs)
        {
            foreach (var doc in docs)
            {
                VkErrors.ThrowIfNumberIsNegative(() => doc.Id);
                VkErrors.ThrowIfNumberIsNegative(() => doc.OwnerId);
            }

            var parameters = new VkParameters
            {
                {"docs", string.Concat(docs.Select(it => it.OwnerId + "_" + it.Id + ","))}
            };

            var response = _vk.Call("docs.getById", parameters);
            return response.ToReadOnlyCollectionOf<Document>(r => r);
        }

        /// <inheritdoc />
        [Pure]
        public UploadServerInfo GetUploadServer(long? groupId = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => groupId);

            var parameters = new VkParameters
            {
                {"group_id", groupId}
            };

            return _vk.Call("docs.getUploadServer", parameters);
        }

        /// <inheritdoc />
        [Pure]
        public UploadServerInfo GetWallUploadServer(long? groupId = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => groupId);

            var parameters = new VkParameters {{"group_id", groupId}};

            return _vk.Call("docs.getWallUploadServer", parameters);
        }

        /// <inheritdoc />
        [Pure]
        public ReadOnlyCollection<Document> Save(string file, string title, string tags = null, long? captchaSid = null,
            string captchaKey = null)
        {
			var file1 = file;
			VkErrors.ThrowIfNullOrEmpty(() => file1);
            VkErrors.ThrowIfNullOrEmpty(() => title);
            var responseJson = JObject.Parse(file);
            file = responseJson["file"].ToString();
            var parameters = new VkParameters
            {
                {"file", file},
                {"title", title},
                {"tags", tags},
                {"captcha_sid", captchaSid},
                {"captcha_key", captchaKey}
            };

            var response = _vk.Call("docs.save", parameters);
            return response.ToReadOnlyCollectionOf<Document>(r => r);
        }

        /// <inheritdoc />
        [Pure]
        public bool Delete(long ownerId, long docId)
        {
            VkErrors.ThrowIfNumberIsNegative(() => ownerId);
            VkErrors.ThrowIfNumberIsNegative(() => docId);

            var parameters = new VkParameters
            {
                {"owner_id", ownerId},
                {"doc_id", docId}
            };
            return _vk.Call("docs.delete", parameters);
        }

        /// <inheritdoc />
        [Pure]
        public long Add(long ownerId, long docId, string accessKey = null, long? captchaSid = null,
            string captchaKey = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => ownerId);
            VkErrors.ThrowIfNumberIsNegative(() => docId);

            var parameters = new VkParameters
            {
                {"owner_id", ownerId},
                {"doc_id", docId},
                {"access_key", accessKey},
                {"captcha_sid", captchaSid},
                {"captcha_key", captchaKey}
            };

            return _vk.Call("docs.add", parameters);
        }

        /// <inheritdoc />
        public VkCollection<DocumentType> GetTypes(long ownerId)
        {
            var parameters = new VkParameters
            {
                {"owner_id", ownerId}
            };

            return _vk.Call("docs.getTypes", parameters).ToVkCollectionOf<DocumentType>(x => x);
        }

        /// <inheritdoc />
        public VkCollection<Document> Search(string query, bool searchOwn, long? count = null, long? offset = null)
        {
            var parameters = new VkParameters
            {
                {"q", query},
                {"count", count},
                {"offset", offset},
                {"search_own", searchOwn}
            };

            return _vk.Call("docs.search", parameters).ToVkCollectionOf<Document>(x => x);
        }

        /// <inheritdoc />
        public bool Edit(long ownerId, long docId, string title, IEnumerable<string> tags)
        {
            var parameters = new VkParameters
            {
                {"owner_id", ownerId},
                {"doc_id", docId},
                {"title", title},
                {"tags", tags}
            };

            return _vk.Call("docs.edit", parameters);
        }

        /// <inheritdoc />
        public UploadServerInfo GetMessagesUploadServer(long? peerId = null, DocMessageType type = null)
        {
            var parameters = new VkParameters
            {
                {"peer_id", peerId},
                {"type", type}
            };

            return _vk.Call("docs.getMessagesUploadServer", parameters);
        }
    }
}