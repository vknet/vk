using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IDocsCategory" />
public partial class DocsCategory
{
	/// <inheritdoc />
	public Task<VkCollection<Document>> GetAsync(int? count = null,
												int? offset = null,
												long? ownerId = null,
												DocFilter? type = null,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(count, offset, ownerId, type), token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Document>> GetByIdAsync(IEnumerable<Document> docs,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetById(docs), token);

	/// <inheritdoc />
	public Task<UploadServerInfo> GetUploadServerAsync(long? groupId = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetUploadServer(groupId), token);

	/// <inheritdoc />
	public Task<UploadServerInfo> GetWallUploadServerAsync(long? groupId = null,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetWallUploadServer(groupId), token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Attachment>> SaveAsync(string file,
														string title = null,
														string tags = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Save(file, title, tags), token);


	/// <inheritdoc />
	public Task<bool> DeleteAsync(long ownerId,
								long docId,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Delete(ownerId, docId), token);

	/// <inheritdoc />
	public Task<long> AddAsync(long ownerId,
								long docId,
								string accessKey = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Add(ownerId, docId, accessKey), token);

	/// <inheritdoc />
	public Task<VkCollection<DocumentType>> GetTypesAsync(long ownerId,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetTypes(ownerId: ownerId), token);

	/// <inheritdoc />
	public Task<VkCollection<Document>> SearchAsync(string query,
													bool searchOwn,
													long? count = null,
													long? offset = null,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Search(query, searchOwn, count, offset), token);

	/// <inheritdoc />
	public Task<bool> EditAsync(long ownerId,
								long docId,
								string title,
								IEnumerable<string> tags,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Edit(ownerId, docId, title, tags), token);

	/// <inheritdoc />
	public Task<UploadServerInfo> GetMessagesUploadServerAsync(long? peerId = null,
																DocMessageType? type = null,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetMessagesUploadServer(peerId, type), token);
}