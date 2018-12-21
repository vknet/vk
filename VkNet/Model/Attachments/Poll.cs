using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
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
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? Created { get; set; }

		/// <summary>
		/// Вопрос, заданный в голосовании.
		/// </summary>
		public string Question { get; set; }

		/// <summary>
		/// Кол-во ответов
		/// </summary>
		public int? Votes { get; set; }

		/// <summary>
		/// Идентификатор выбранного ответа
		/// </summary>
		public long? AnswerId { get; set; }

		/// <summary>
		/// Варианты ответов
		/// </summary>
		public ReadOnlyCollection<PollAnswer> Answers { get; set; }

		/// <summary>
		/// Возможность анонимых ответов
		/// </summary>
		public bool? Anonymous { get; set; }

		/// <summary>
		/// Допускает ли опрос выбор нескольких вариантов ответа.
		/// </summary>
		public bool? Multiple { get; set; }

		/// <summary>
		/// Идентификаторы вариантов ответа, выбранных текущим пользователем.
		/// </summary>
		public ReadOnlyCollection<long> AnswerIds { get; set; }

		/// <summary>
		/// Дата завершения опроса в Unixtime. 0, если опрос бессрочный.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// Является ли опрос завершенным.
		/// </summary>
		public bool? Closed { get; set; }

		/// <summary>
		/// Прикреплён ли опрос к обсуждению.
		/// </summary>
		public bool? IsBoard { get; set; }

		/// <summary>
		/// Можно ли отредактировать опрос.
		/// </summary>
		public bool? CanEdit { get; set; }

		/// <summary>
		/// Можно ли проголосовать в опросе.
		/// </summary>
		public bool? CanVote { get; set; }

		/// <summary>
		/// Можно ли пожаловаться на опрос.
		/// </summary>
		public bool? CanReport { get; set; }

		/// <summary>
		/// Можно ли поделиться опросом.
		/// </summary>
		public bool? CanShare { get; set; }

		/// <summary>
		/// Идентификатор автора опроса.
		/// </summary>
		public long? AuthorId { get; set; }

		/// <summary>
		/// Фотография — фон сниппета опроса. Объект фотографии.
		/// </summary>
		public Photo Photo { get; set; }

		/// <summary>
		/// Фон сниппета опроса.
		/// </summary>
		public PollBackground Background { get; set; }

		/// <summary>
		/// Идентификаторы 3 друзей, которые проголосовали в опросе.
		/// </summary>
		public ReadOnlyCollection<User> Friends { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Poll FromJson(VkResponse response)
		{
			return new Poll
			{
				Id = response["id"] ?? response["poll_id"],
				OwnerId = response["owner_id"],
				Question = response["question"],
				Created = response["created"],
				Votes = response["votes"],
				AnswerId = response["answer_id"],
				Anonymous = response["anonymous"],
				Answers = response["answers"].ToReadOnlyCollectionOf<PollAnswer>(x => x),
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
				Background = response["background"],
				Friends = response["friends"].ToReadOnlyCollectionOf<User>(x => x),
				AnswerIds = response["answer_ids"].ToReadOnlyCollectionOf<long>(x => x)
			};
		}

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
}