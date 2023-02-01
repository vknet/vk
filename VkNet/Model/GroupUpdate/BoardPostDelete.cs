using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate;

/// <summary>
/// Удаление комментария в обсуждении (<c>BoardPostDelete</c>)
/// </summary>
[Serializable]
public class BoardPostDelete : IGroupUpdate
{
	/// <summary>
	/// Идентификатор комментария
	/// </summary>
	[JsonProperty("id")]
	public ulong? Id { get; set; }

	/// <summary>
	/// Идентификатор обсуждения
	/// </summary>
	[JsonProperty("topic_id")]
	public ulong? TopicId { get; set; }

	/// <summary>
	/// Идентификатор владельца обсуждения
	/// </summary>
	[JsonProperty("topic_owner_id")]
	public long? TopicOwnerId { get; set; }

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	public static BoardPostDelete FromJson(VkResponse response) => new()
	{
		Id = response["id"],
		TopicId = response["topic_id"],
		TopicOwnerId = response["topic_owner_id"]
	};

	/// <summary>
	/// Преобразование класса <see cref="Message" /> в <see cref="VkParameters" />
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> Результат преобразования в <see cref="Message" /> </returns>
	public static implicit operator BoardPostDelete(VkResponse response)
	{
		if (response == null)
		{
			return null;
		}

		return response.HasToken()
			? FromJson(response)
			: null;
	}
}