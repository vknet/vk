using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class DocsCategory
{
	/// <inheritdoc />
	public Task<VkCollection<Document>> GetAsync(int? count = null,
												int? offset = null,
												long? ownerId = null,
												DocFilter? type = null,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(count, offset, ownerId, type));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Document>> GetByIdAsync(IEnumerable<Document> docs,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetById(docs));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetUploadServerAsync(long? groupId = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetUploadServer(groupId));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetWallUploadServerAsync(long? groupId = null,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetWallUploadServer(groupId));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Attachment>> SaveAsync(string file,
														string title = null,
														string tags = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Save(file, title, tags));

	/// <inheritdoc />
	[Obsolete(ObsoleteText.CaptchaNeeded, true)]
	public Task<ReadOnlyCollection<Attachment>> SaveAsync(string file,
														long? captchaSid = null,
														string title = null ,
														string tags = null,
														string captchaKey = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Save(file, captchaSid, title, tags, captchaKey));

	/// <inheritdoc />
	public Task<bool> DeleteAsync(long ownerId,
								long docId,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Delete(ownerId, docId));

	/// <inheritdoc />
	public Task<long> AddAsync(long ownerId,
								long docId,
								string accessKey = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Add(ownerId, docId, accessKey));

	/// <inheritdoc />
	[Obsolete(ObsoleteText.CaptchaNeeded, true)]
	public Task<long> AddAsync(long ownerId,
								long docId,
								string accessKey = null,
								long? captchaSid = null,
								string captchaKey = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Add(ownerId, docId, accessKey, captchaSid, captchaKey));

	/// <inheritdoc />
	public Task<VkCollection<DocumentType>> GetTypesAsync(long ownerId,
														CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetTypes(ownerId: ownerId));

	/// <inheritdoc />
	public Task<VkCollection<Document>> SearchAsync(string query,
													bool searchOwn,
													long? count = null,
													long? offset = null,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Search(query, searchOwn, count, offset));

	/// <inheritdoc />
	public Task<bool> EditAsync(long ownerId,
								long docId,
								string title,
								IEnumerable<string> tags,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Edit(ownerId, docId, title, tags));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetMessagesUploadServerAsync(long? peerId = null,
																DocMessageType? type = null,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetMessagesUploadServer(peerId, type));
}