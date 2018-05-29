using System;
using System.Collections.Generic;
using System.Text;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода polls.getById
	/// </summary>
	[Serializable]
	public class PollsGetVotersParams
	{
		/// <summary>
		/// Идентификатор владельца опроса.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// True — опрос находится в обсуждении, False — опрос прикреплен к стене.
		/// По умолчанию — False.
		/// </summary>
		public bool? IsBoard { get; set; }

		/// <summary>
		/// Идентификатор опроса.
		/// </summary>
		public long PollId { get; set; }

		/// <summary>
		/// Идентификаторы вариантов ответа.
		/// </summary>
		public List<long> AnswersIds { get; set; }

		/// <summary>
		/// Указывает, необходимо ли возвращать только пользователей, которые являются
		/// друзьями текущего пользователя.
		/// </summary>
		public bool? FriendsOnly { get; set; }

		/// <summary>
		/// Смещение относительно начала списка, для выборки определенного подмножества.
		/// Если параметр не задан, то считается,
		/// что он равен 0.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Количество возвращаемых идентификаторов пользователей.
		/// Если параметр не задан, то считается, что он равен 100, если не задан параметр
		/// friends_only, в противном случае 10.
		/// Максимальное значение параметра 1000, если не задан параметр friends_only, в
		/// противном случае 100.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Список дополнительных полей, которые необходимо вернуть.
		/// </summary>
		public ProfileFields Fields { get; set; }

		/// <summary>
		/// Падеж для склонения имени и фамилии пользователя. Возможные значения:
		/// именительный – nom, родительный – gen,
		/// дательный – dat, винительный – acc, творительный – ins, предложный – abl. По
		/// умолчанию nom. строка.
		/// </summary>
		public NameCase NameCase { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(PollsGetVotersParams p)
		{
			return new VkParameters
			{
					{ "owner_id", p.OwnerId }
					, { "is_board", p.IsBoard }
					, { "poll_id", p.PollId }
					, { "answer_ids", FormatList(answersIds: p.AnswersIds) }
					, { "friends_only", p.FriendsOnly }
					, { "offset", p.Offset }
					, { "count", p.Count }
					, { "fields", p.Fields }
					, { "name_case", p.NameCase }
			};
		}

		private static object FormatList(IList<long> answersIds)
		{
			if (answersIds == null)
			{
				return null;
			}

			var stringBuilder = new StringBuilder();

			for (var i = 0; i < answersIds.Count; i++)
			{
				stringBuilder.Append(value: answersIds[index: i]);

				if (i + 1 < answersIds.Count)
				{
					stringBuilder.Append(value: ',');
				}
			}

			return stringBuilder.ToString();
		}
	}
}