using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

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
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public NameCase NameCase { get; set; }
	}
}