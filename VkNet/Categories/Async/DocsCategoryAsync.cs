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
		public async Task<VkCollection<Document>> GetAsync(int? count = null
															, int? offset = null
															, long? ownerId = null
															, DocFilter? type = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Docs.Get(count: count, offset: offset, ownerId: ownerId, type: type));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<Document>> GetByIdAsync(IEnumerable<Document> docs)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Docs.GetById(docs: docs));
		}

		/// <inheritdoc />
		public async Task<UploadServerInfo> GetUploadServerAsync(long? groupId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Docs.GetUploadServer(groupId: groupId));
		}

		/// <inheritdoc />
		public async Task<UploadServerInfo> GetWallUploadServerAsync(long? groupId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Docs.GetWallUploadServer(groupId: groupId));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<Document>> SaveAsync(string file
																, string title
																, string tags = null
																, long? captchaSid = null
																, string captchaKey = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Docs.Save(file: file, title: title, tags: tags, captchaSid: captchaSid, captchaKey: captchaKey));
		}

		/// <inheritdoc />
		public async Task<bool> DeleteAsync(long ownerId, long docId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Docs.Delete(ownerId: ownerId, docId: docId));
		}

		/// <inheritdoc />
		public async Task<long> AddAsync(long ownerId
										, long docId
										, string accessKey = null
										, long? captchaSid = null
										, string captchaKey = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Docs.Add(ownerId: ownerId, docId: docId, accessKey: accessKey, captchaSid: captchaSid, captchaKey: captchaKey));
		}

		/// <inheritdoc />
		public async Task<VkCollection<DocumentType>> GetTypesAsync(long ownerId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Docs.GetTypes(ownerId: ownerId));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Document>> SearchAsync(string query, bool searchOwn, long? count = null, long? offset = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Docs.Search(query: query, searchOwn: searchOwn, count: count, offset: offset));
		}

		/// <inheritdoc />
		public async Task<bool> EditAsync(long ownerId, long docId, string title, IEnumerable<string> tags)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Docs.Edit(ownerId: ownerId, docId: docId, title: title, tags: tags));
		}

		/// <inheritdoc />
		public async Task<UploadServerInfo> GetMessagesUploadServerAsync(long? peerId = null, DocMessageType type = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Docs.GetMessagesUploadServer(peerId: peerId, type: type));
		}
	}
}