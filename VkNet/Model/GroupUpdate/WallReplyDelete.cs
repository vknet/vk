using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate;

/// <summary>
/// Удаление комментария к записи (<c>WallReplyDelete</c>)
/// </summary>
[Serializable]
public class WallReplyDelete : IGroupUpdate
{
	/// <summary>
	/// Идентификатор комментария
	/// </summary>
	[JsonProperty("id")]
	public ulong? Id { get; set; }

	/// <summary>
	/// Идентификатор записи, к которой был оставлен комментарий
	/// </summary>
	[JsonProperty("post_id")]
	public long? PostId { get; set; }

	/// <summary>
	/// Идентификатор владельца стены
	/// </summary>
	[JsonProperty("owner_id")]
	public long? OwnerId { get; set; }

	/// <summary>
	/// Идентификатор автора комментария
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Идентификатор пользователя, который удалил комментарий
	/// </summary>
	[JsonProperty("deleter_id")]
	public long? DeleterId { get; set; }

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	public static WallReplyDelete FromJson(VkResponse response) => new()
	{
		Id = response["id"],
		PostId = response["post_id"],
		OwnerId = response["owner_id"],
		UserId = response["user_id"],
		DeleterId = response["deleter_id"]
	};

	/// <summary>
	/// Преобразование класса <see cref="WallReplyDelete" /> в <see cref="VkParameters" />
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> Результат преобразования в <see cref="WallReplyDelete" /> </returns>
	public static implicit operator WallReplyDelete(VkResponse response)
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