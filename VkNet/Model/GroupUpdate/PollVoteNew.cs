using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate;

/// <summary>
/// Добавление голоса в публичном опросе
/// </summary>
[Serializable]
public class PollVoteNew : IGroupUpdate
{
	/// <summary>
	/// Идентификатор пользователя
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Идентификатор опроса
	/// </summary>
	[JsonProperty("poll_id")]
	public long? PollId { get; set; }

	/// <summary>
	/// Идентификатор варианта ответа
	/// </summary>
	[JsonProperty("option_id")]
	public long? OptionId { get; set; }

	/// <summary>
	/// Идентификатор владельца опроса
	/// </summary>
	[JsonProperty("owner_id")]
	public long? OwnerId { get; set; }

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	public static PollVoteNew FromJson(VkResponse response) => new()
	{
		UserId = response["user_id"],
		PollId = response["poll_id"],
		OptionId = response["option_id"],
		OwnerId = response["owner_id"]
	};

	/// <summary>
	/// Преобразование класса <see cref="PollVoteNew" /> в <see cref="VkParameters" />
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> Результат преобразования в <see cref="PollVoteNew" /> </returns>
	public static implicit operator PollVoteNew(VkResponse response)
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