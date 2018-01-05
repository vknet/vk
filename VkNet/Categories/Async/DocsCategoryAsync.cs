using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Categories
{
    /// <inheritdoc />
    public partial class DocsCategory
    {
        /// <inheritdoc />
        public async Task<VkCollection<Document>> GetAsync(int? count = null, int? offset = null, long? ownerId = null,
            DocFilter? type = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Docs.Get(count, offset, ownerId, type));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<Document>> GetByIdAsync(IEnumerable<Document> docs)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Docs.GetById(docs));
        }

        /// <inheritdoc />
        public async Task<UploadServerInfo> GetUploadServerAsync(long? groupId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Docs.GetUploadServer(groupId));
        }

        /// <inheritdoc />
        public async Task<UploadServerInfo> GetWallUploadServerAsync(long? groupId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Docs.GetWallUploadServer(groupId));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<Document>> SaveAsync(string file, string title, string tags = null,
            long? captchaSid = null, string captchaKey = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Docs.Save(file, title, tags, captchaSid, captchaKey));
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(long ownerId, long docId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Docs.Delete(ownerId, docId));
        }

        /// <inheritdoc />
        public async Task<long> AddAsync(long ownerId, long docId, string accessKey = null, long? captchaSid = null,
            string captchaKey = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Docs.Add(ownerId, docId, accessKey, captchaSid, captchaKey));
        }

        /// <inheritdoc />
        public async Task<VkCollection<DocumentType>> GetTypesAsync(long ownerId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Docs.GetTypes(ownerId));
        }

        /// <inheritdoc />
        public async Task<VkCollection<Document>> SearchAsync(string query, bool searchOwn, long? count = null,
            long? offset = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Docs.Search(query, searchOwn, count, offset));
        }

        /// <inheritdoc />
        public async Task<bool> EditAsync(long ownerId, long docId, string title, IEnumerable<string> tags)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Docs.Edit(ownerId, docId, title, tags));
        }

        /// <inheritdoc />
        public async Task<UploadServerInfo> GetMessagesUploadServerAsync(long? peerId = null,
            DocMessageType type = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Docs.GetMessagesUploadServer(peerId, type));
        }
    }
}