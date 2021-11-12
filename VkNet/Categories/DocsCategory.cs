using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using VkNet.Abstractions;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Infrastructure;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class DocsCategory : IDocsCategory
	{
		/// <summary>
		/// API
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// Методы для работы с документами (получение списка, загрузка, удаление и т.д.).
		/// </summary>
		/// <param name="vk"> API. </param>
		public DocsCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		[Pure]
		public VkCollection<Document> Get(int? count = null, int? offset = null, long? ownerId = null, DocFilter? type = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => offset);

			var parameters = new VkParameters
			{
				{ "count", count },
				{ "offset", offset },
				{ "owner_id", ownerId },
				{ "type", type }
			};

			return _vk.Call("docs.get", parameters).ToVkCollectionOf<Document>(selector: r => r);
		}

		/// <inheritdoc />
		[Pure]
		public ReadOnlyCollection<Document> GetById(IEnumerable<Document> docs)
		{
			foreach (var doc in docs)
			{
				VkErrors.ThrowIfNumberIsNegative(expr: () => doc.Id);
				VkErrors.ThrowIfNumberIsNegative(expr: () => doc.OwnerId);
			}

			var parameters = new VkParameters
			{
				{ "docs", string.Concat(values: docs.Select(selector: it => it.OwnerId + "_" + it.Id + ",")) }
			};

			var response = _vk.Call("docs.getById", parameters);

			return response.ToReadOnlyCollectionOf<Document>(selector: r => r);
		}

		/// <inheritdoc />
		[Pure]
		public UploadServerInfo GetUploadServer(long? groupId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => groupId);

			var parameters = new VkParameters
			{
				{ "group_id", groupId }
			};

			return _vk.Call("docs.getUploadServer", parameters);
		}

		/// <inheritdoc />
		[Pure]
		public UploadServerInfo GetWallUploadServer(long? groupId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => groupId);

			var parameters = new VkParameters
			{
				{ "group_id", groupId }
			};

			return _vk.Call("docs.getWallUploadServer", parameters);
		}

		/// <inheritdoc />
		[Pure]
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public ReadOnlyCollection<Attachment> Save(string file, string title, string tags = null, long? captchaSid = null,
													string captchaKey = null)
		{
			return Save(file, title, tags);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<Attachment> Save(string file, string title, string tags = null)
		{
			VkErrors.ThrowIfNullOrEmpty(() => title);

			if (VkResponseEx.IsValidJson(file))
			{
				var responseJson = file.ToJObject();
				file = responseJson["file"].ToString();
			}

			var parameters = new VkParameters
			{
				{ "file", file },
				{ "title", title },
				{ "tags", tags }
			};

			var response = _vk.Call("docs.save", parameters);

			var responseArray = (VkResponseArray) response;

			if (responseArray == null)
			{
				return new ReadOnlyCollection<Attachment>(new List<Attachment>
				{
					response
				});
			}

			return response.ToReadOnlyCollectionOf<Attachment>(r => r);
		}

		/// <inheritdoc />
		[Pure]
		public bool Delete(long ownerId, long docId)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => ownerId);
			VkErrors.ThrowIfNumberIsNegative(expr: () => docId);

			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "doc_id", docId }
			};

			return _vk.Call("docs.delete", parameters);
		}

		/// <inheritdoc />
		[Pure]
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public long Add(long ownerId, long docId, string accessKey = null, long? captchaSid = null, string captchaKey = null)
		{
			return Add(ownerId, docId, accessKey);
		}

		/// <inheritdoc />
		public long Add(long ownerId, long docId, string accessKey = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => ownerId);
			VkErrors.ThrowIfNumberIsNegative(expr: () => docId);

			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "doc_id", docId },
				{ "access_key", accessKey }
			};

			return _vk.Call("docs.add", parameters);
		}

		/// <inheritdoc />
		public VkCollection<DocumentType> GetTypes(long ownerId)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId }
			};

			return _vk.Call("docs.getTypes", parameters).ToVkCollectionOf<DocumentType>(selector: x => x);
		}

		/// <inheritdoc />
		public VkCollection<Document> Search(string query, bool searchOwn, long? count = null, long? offset = null)
		{
			var parameters = new VkParameters
			{
				{ "q", query },
				{ "count", count },
				{ "offset", offset },
				{ "search_own", searchOwn }
			};

			return _vk.Call("docs.search", parameters).ToVkCollectionOf<Document>(selector: x => x);
		}

		/// <inheritdoc />
		public bool Edit(long ownerId, long docId, string title, IEnumerable<string> tags)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "doc_id", docId },
				{ "title", title },
				{ "tags", tags }
			};

			return _vk.Call("docs.edit", parameters);
		}

		/// <inheritdoc />
		public UploadServerInfo GetMessagesUploadServer(long? groupId = null, DocMessageType type = null)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "type", type }
			};

			return _vk.Call("docs.getMessagesUploadServer", parameters);
		}
	}
}