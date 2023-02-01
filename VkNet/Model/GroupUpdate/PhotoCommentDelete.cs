using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate;

/// <summary>
/// Удаление комментария к фотографии (<c>PhotoCommentDelete</c>)
/// </summary>
[Serializable]
public class PhotoCommentDelete : IGroupUpdate
{
	/// <summary>
	/// Идентификатор комментария
	/// </summary>
	[JsonProperty("id")]
	public ulong? Id { get; set; }

	/// <summary>
	/// Идентификатор фотографии
	/// </summary>
	[JsonProperty("photo_id")]
	public long? PhotoId { get; set; }

	/// <summary>
	/// Идентификатор владельца фотографии
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
	public static PhotoCommentDelete FromJson(VkResponse response) => new()
	{
		Id = response["id"],
		PhotoId = response["photo_id"],
		OwnerId = response["owner_id"],
		UserId = response["user_id"],
		DeleterId = response["deleter_id"]
	};

	/// <summary>
	/// Преобразование класса <see cref="PhotoCommentDelete" /> в <see cref="VkParameters" />
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> Результат преобразования в <see cref="PhotoCommentDelete" /> </returns>
	public static implicit operator PhotoCommentDelete(VkResponse response)
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