using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Abstractions;
using VkNet.Enums;
using VkNet.Enums.StringEnums;
using VkNet.Infrastructure;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IDocsCategory" />
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
	public DocsCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc />
	[Pure]
	public VkCollection<Document> Get(int? count = null, int? offset = null, long? ownerId = null, DocFilter? type = null)
	{
		VkErrors.ThrowIfNumberIsNegative(expr: () => count);
		VkErrors.ThrowIfNumberIsNegative(expr: () => offset);

		var parameters = new VkParameters
		{
			{
				"count", count
			},
			{
				"offset", offset
			},
			{
				"owner_id", ownerId
			},
			{
				"type", type
			}
		};

		return _vk.Call<VkCollection<Document>>("docs.get", parameters);
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
			{
				"docs", string.Concat(values: docs.Select(selector: it => it.OwnerId + "_" + it.Id + ","))
			}
		};

		return _vk.Call<ReadOnlyCollection<Document>>("docs.getById", parameters);
	}

	/// <inheritdoc />
	[Pure]
	public UploadServerInfo GetUploadServer(long? groupId = null)
	{
		VkErrors.ThrowIfNumberIsNegative(expr: () => groupId);

		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			}
		};

		return _vk.Call<UploadServerInfo>("docs.getUploadServer", parameters);
	}

	/// <inheritdoc />
	[Pure]
	public UploadServerInfo GetWallUploadServer(long? groupId = null)
	{
		VkErrors.ThrowIfNumberIsNegative(expr: () => groupId);

		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			}
		};

		return _vk.Call<UploadServerInfo>("docs.getWallUploadServer", parameters);
	}


	/// <inheritdoc />
	public ReadOnlyCollection<Attachment> Save(string file, string title = null, string tags = null)
	{
		VkErrors.ThrowIfNullOrEmpty(() => title);

		if (VkResponseEx.IsValidJson(file))
		{
			var responseJson = file.ToJObject();

			file = responseJson["file"]
				.ToString();
		}

		var parameters = new VkParameters
		{
			{
				"file", file
			},
			{
				"title", title
			},
			{
				"tags", tags
			}
		};

		var response = _vk.Call("docs.save", parameters);

		var responseArray = (VkResponseArray) response;

		if (responseArray is null)
		{

			if (response.ContainsKey("audio_message"))
			{
				return new(new List<Attachment>
				{
					CreateTyped(JsonConvert.DeserializeObject<AudioMessage>(response["audio_message"].ToString()))
				});
			}
			return new(new List<Attachment>
			{
				CreateTyped(JsonConvert.DeserializeObject<Document>(response["doc"].ToString()))
			});
		}

		if (response.ContainsKey("audio_message"))
		{
			return new ((from parsedObject in JArray.Parse(response.ToString()).Children<JObject>()
						from parsedProperty in parsedObject.Properties()
						let propertyName = parsedProperty.Name
						where propertyName.Equals("audio_message")
						select CreateTyped(JsonConvert.DeserializeObject<AudioMessage>(parsedProperty.Value.ToString()))).ToList());
		}

		var parsedArray = JArray.Parse(response.ToString());
		var list = (from parsedObject in parsedArray.Children<JObject>()
					from parsedProperty in parsedObject.Properties()
					let propertyName = parsedProperty.Name
					where propertyName.Equals("doc")
					select CreateTyped(JsonConvert.DeserializeObject<Document>(parsedProperty.Value.ToString()))).ToList();

		return new (list);
	}

	private static Attachment CreateTyped<TAttachment>(TAttachment instance)
		where TAttachment : MediaAttachment
	{
		var attachment = new Attachment
		{
			Type = typeof(TAttachment),
			Instance = instance
		};

		return attachment;
	}

	/// <inheritdoc />
	[Pure]
	public bool Delete(long ownerId, long docId)
	{
		VkErrors.ThrowIfNumberIsNegative(expr: () => ownerId);
		VkErrors.ThrowIfNumberIsNegative(expr: () => docId);

		var parameters = new VkParameters
		{
			{
				"owner_id", ownerId
			},
			{
				"doc_id", docId
			}
		};

		return _vk.Call<bool>("docs.delete", parameters);
	}



	/// <inheritdoc />
	public long Add(long ownerId, long docId, string accessKey = null)
	{
		VkErrors.ThrowIfNumberIsNegative(expr: () => ownerId);
		VkErrors.ThrowIfNumberIsNegative(expr: () => docId);

		var parameters = new VkParameters
		{
			{
				"owner_id", ownerId
			},
			{
				"doc_id", docId
			},
			{
				"access_key", accessKey
			}
		};

		return _vk.Call<long>("docs.add", parameters);
	}

	/// <inheritdoc />
	public VkCollection<DocumentType> GetTypes(long ownerId)
	{
		var parameters = new VkParameters
		{
			{
				"owner_id", ownerId
			}
		};

		return _vk.Call<VkCollection<DocumentType>>("docs.getTypes", parameters);
	}

	/// <inheritdoc />
	public VkCollection<Document> Search(string query, bool searchOwn, long? count = null, long? offset = null)
	{
		var parameters = new VkParameters
		{
			{
				"q", query
			},
			{
				"count", count
			},
			{
				"offset", offset
			},
			{
				"search_own", searchOwn
			}
		};

		return _vk.Call<VkCollection<Document>>("docs.search", parameters);
	}

	/// <inheritdoc />
	public bool Edit(long ownerId, long docId, string title, IEnumerable<string> tags)
	{
		var parameters = new VkParameters
		{
			{
				"owner_id", ownerId
			},
			{
				"doc_id", docId
			},
			{
				"title", title
			},
			{
				"tags", tags
			}
		};

		return _vk.Call<bool>("docs.edit", parameters);
	}

	/// <inheritdoc />
	public UploadServerInfo GetMessagesUploadServer(long? peerId = null, DocMessageType? type = null)
	{
		var parameters = new VkParameters
		{
			{
				"peer_id", peerId
			},
			{
				"type", type
			}
		};

		return _vk.Call<UploadServerInfo>("docs.getMessagesUploadServer", parameters);
	}
}