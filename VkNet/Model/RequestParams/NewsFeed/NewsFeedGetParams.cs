using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.Filters;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров запроса newsfeed.get
	/// </summary>
	[Serializable]
	public class NewsFeedGetParams
	{
		/// <summary>
		/// Названия списков новостей, которые необходимо
		/// получить.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public NewsTypes Filters { get; set; }

		/// <summary>
		/// <c> true </c> - включить в выдачу также скрытых из новостей пользователей.
		/// <c> false </c> - не возвращать скрытых
		/// пользователей.
		/// </summary>
		public bool? ReturnBanned { get; set; }

		/// <summary>
		/// Время в формате unixtime, начиная с которого следует получить новости для
		/// текущего пользователя.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? StartTime { get; set; }

		/// <summary>
		/// Время в формате unixtime, до которого следует получить новости для текущего
		/// пользователя. Если параметр не задан,
		/// то он считается равным текущему времени.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? EndTime { get; set; }

		/// <summary>
		/// Максимальное количество фотографий, информацию о которых необходимо вернуть. По
		/// умолчанию 5.
		/// </summary>
		public uint? MaxPhotos { get; set; }

		/// <summary>
		/// Перечисленные через запятую иcточники новостей, новости от которых необходимо
		/// получить. Идентификаторы
		/// пользователей можно указывать в форматах {uid} или u{uid} где {uid} —
		/// идентификатор друга пользователя.
		/// Идентификаторы сообществ можно указывать в форматах -{gid} или g{gid} где
		/// {gid} — идентификатор сообщества.
		/// Помимо этого параметр может принимать строковые значения: friends - список
		/// друзей пользователя groups - список
		/// групп, на которые подписан текущий пользователь pages - список публичных
		/// страниц, на который подписан тeкущий
		/// пользователь following - список пользователей, на которых подписан текущий
		/// пользователь list{идентификатор списка
		/// новостей} - список новостей. Вы можете найти все списки новостей пользователя
		/// используя метод newsfeed.getLists
		/// Если параметр не задан, то считается, что он включает список всех друзей и
		/// групп пользователя, за исключением
		/// скрытых источников, которые можно получить методом newsfeed.getBanned.  строка.
		/// </summary>
		public IEnumerable<string> SourceIds { get; set; }

		/// <summary>
		/// Идентификатор, необходимый для получения следующей страницы результатов.
		/// Значение, необходимое для передачи в этом
		/// параметре, возвращается в поле ответа next_from.
		/// </summary>
		public string StartFrom { get; set; }

		/// <summary>
		/// Указывает, какое максимальное число новостей следует возвращать, но не более
		/// 100. По умолчанию 50.
		/// </summary>
		public ushort? Count { get; set; }

		/// <summary>
		/// Список дополнительных полей профилей и сообществ, которые необходимо вернуть.
		/// </summary>
		public IEnumerable<string> Fields { get; set; }

		/// <summary>
		/// Раздел новостной ленты.
		/// </summary>
		public string Section { get; set; }
	}
}