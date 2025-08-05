using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Enums;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы с документами (получение списка, загрузка, удаление и т.д.)
/// </summary>
public interface IDocsCategory : IDocsCategoryAsync
{
	/// <inheritdoc cref="IDocsCategoryAsync.GetAsync"/>
	VkCollection<Document> Get(int? count = null, int? offset = null, long? ownerId = null, DocFilter? type = null);

	/// <inheritdoc cref="IDocsCategoryAsync.GetByIdAsync"/>
	ReadOnlyCollection<Document> GetById(IEnumerable<Document> docs);

	/// <inheritdoc cref="IDocsCategoryAsync.GetUploadServerAsync"/>
	UploadServerInfo GetUploadServer(long? groupId = null);

	/// <inheritdoc cref="IDocsCategoryAsync.GetWallUploadServerAsync"/>
	UploadServerInfo GetWallUploadServer(long? groupId = null);

	/// <inheritdoc cref="IDocsCategoryAsync.SaveAsync(string,string,string, System.Threading.CancellationToken)"/>
	ReadOnlyCollection<Attachment> Save(string file, string title = null, string tags = null);

	/// <inheritdoc cref="IDocsCategoryAsync.DeleteAsync"/>
	bool Delete(long ownerId, long docId);

	/// <inheritdoc cref="IDocsCategoryAsync.AddAsync(long,long,string, System.Threading.CancellationToken)"/>
	long Add(long ownerId, long docId, string accessKey = null);

	/// <inheritdoc cref="IDocsCategoryAsync.GetTypesAsync"/>
	VkCollection<DocumentType> GetTypes(long ownerId);

	/// <inheritdoc cref="IDocsCategoryAsync.SearchAsync"/>
	VkCollection<Document> Search(string query, bool searchOwn, long? count = null, long? offset = null);

	/// <inheritdoc cref="IDocsCategoryAsync.EditAsync"/>
	bool Edit(long ownerId, long docId, string title, IEnumerable<string> tags);

	/// <inheritdoc cref="IDocsCategoryAsync.GetMessagesUploadServerAsync"/>
	UploadServerInfo GetMessagesUploadServer(long? peerId = null, DocMessageType? type = null);
}