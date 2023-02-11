using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model.Attachments;

/// <inheritdoc />
/// <summary>
/// Опрос.
/// См. описание https://vk.com/dev/objects/poll
/// </summary>
[Serializable]
public class Poll : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "poll";

	/// <summary>
	/// Дата создания опроса
	/// </summary>
	[JsonProperty("created")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? Created { get; set; }

	/// <summary>
	/// Вопрос, заданный в голосовании.
	/// </summary>
	[JsonProperty("question")]
	public string Question { get; set; }

	/// <summary>
	/// Кол-во ответов
	/// </summary>
	[JsonProperty("votes")]
	public int? Votes { get; set; }

	/// <summary>
	/// Идентификатор выбранного ответа
	/// </summary>
	[JsonProperty("answer_id")]
	public long? AnswerId { get; set; }

	/// <summary>
	/// Варианты ответов
	/// </summary>
	[JsonProperty("answers")]
	public ReadOnlyCollection<PollAnswer> Answers { get; set; }

	/// <summary>
	/// Возможность анонимых ответов
	/// </summary>
	[JsonProperty("anonymous")]
	public bool? Anonymous { get; set; }

	/// <summary>
	/// Допускает ли опрос выбор нескольких вариантов ответа.
	/// </summary>
	[JsonProperty("multiple")]
	public bool? Multiple { get; set; }

	/// <summary>
	/// Идентификаторы вариантов ответа, выбранных текущим пользователем.
	/// </summary>
	[JsonProperty("answer_ids")]
	public ReadOnlyCollection<long> AnswerIds { get; set; }

	/// <summary>
	/// Дата завершения опроса в Unixtime. 0, если опрос бессрочный.
	/// </summary>
	[JsonProperty("end_date")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? EndDate { get; set; }

	/// <summary>
	/// Является ли опрос завершенным.
	/// </summary>
	[JsonProperty("closed")]
	public bool? Closed { get; set; }

	/// <summary>
	/// Прикреплён ли опрос к обсуждению.
	/// </summary>
	[JsonProperty("is_board")]
	public bool? IsBoard { get; set; }

	/// <summary>
	/// Можно ли отредактировать опрос.
	/// </summary>
	[JsonProperty("can_edit")]
	public bool? CanEdit { get; set; }

	/// <summary>
	/// Можно ли проголосовать в опросе.
	/// </summary>
	[JsonProperty("can_vote")]
	public bool? CanVote { get; set; }

	/// <summary>
	/// Можно ли пожаловаться на опрос.
	/// </summary>
	[JsonProperty("can_report")]
	public bool? CanReport { get; set; }

	/// <summary>
	/// Можно ли поделиться опросом.
	/// </summary>
	[JsonProperty("can_share")]
	public bool? CanShare { get; set; }

	/// <summary>
	/// Идентификатор автора опроса.
	/// </summary>
	[JsonProperty("author_id")]
	public long? AuthorId { get; set; }

	/// <summary>
	/// Фотография — фон сниппета опроса. Объект фотографии.
	/// </summary>
	[JsonProperty("photo")]
	public Photo Photo { get; set; }

	/// <summary>
	/// Фон сниппета опроса.
	/// </summary>
	[JsonProperty("background")]
	public PollBackground Background { get; set; }

	/// <summary>
	/// Идентификаторы 3 друзей, которые проголосовали в опросе.
	/// </summary>
	[JsonProperty("friends")]
	public ReadOnlyCollection<User> Friends { get; set; }

	[JsonProperty("poll_id")]
	private long? PollId
	{
		get => Id;
		set => Id = value;
	}

	#region Методы

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static Poll FromJson(VkResponse response) => new()
	{
		Id = response["id"] ?? response["poll_id"],
		OwnerId = response["owner_id"],
		Question = response["question"],
		Created = response["created"],
		Votes = response["votes"],
		AnswerId = response["answer_id"],
		Anonymous = response["anonymous"],
		Answers = !response.ContainsKey("answers")?null:JsonConvert.DeserializeObject<ReadOnlyCollection<PollAnswer>>(response["answers"].ToString()),

		IsBoard = response["is_board"],
		EndDate = response["end_date"],
		CanVote = response["can_vote"],
		CanShare = response["can_share"],
		CanReport = response["can_report"],
		CanEdit = response["can_edit"],
		AuthorId = response["author_id"],
		Multiple = response["multiple"],
		Closed = response["closed"],
		Photo = response["photo"],
		Background = !response.ContainsKey("background")?null:JsonConvert.DeserializeObject<PollBackground>(response["background"].ToString()),
		Friends = !response.ContainsKey("friends")?null:JsonConvert.DeserializeObject<ReadOnlyCollection<User>>(response["friends"].ToString()),
		AnswerIds = response["answer_ids"]
			.ToReadOnlyCollectionOf<long>(x => x)
	};

	/// <summary>
	/// Преобразование класса <see cref="Poll" /> в <see cref="VkParameters" />
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns>Результат преобразования в <see cref="Poll" /></returns>
	public static implicit operator Poll(VkResponse response)
	{
		if (response == null)
		{
			return null;
		}

		return response.HasToken()
			? FromJson(response)
			: null;
	}

	#endregion
}