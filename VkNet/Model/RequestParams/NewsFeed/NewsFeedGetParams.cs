using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров запроса newsfeed.get
	/// </summary>
	[Serializable]
	public class NewsFeedGetParams
	{
		/// <summary>
		/// Перечисленные через запятую названия списков новостей, которые необходимо
		/// получить. В данный момент поддерживаются
		/// следующие списки новостей: post — новые записи со стен photo — новые фотографии
		/// photo_tag — новые отметки на
		/// фотографиях wall_photo — новые фотографии на стенах friend — новые друзья note
		/// — новые заметки Если параметр не
		/// задан, то будут получены все возможные списки новостей.
		/// </summary>
		public NewsTypes Filters { get; set; }

		/// <summary>
		/// <c> true </c> - включить в выдачу также скрытых из новостей пользователей.
		/// <c> false </c> - не возвращать скрытых
		/// пользователей.
		/// </summary>
		public bool ReturnBanned { get; set; }

		/// <summary>
		/// Время в формате unixtime, начиная с которого следует получить новости для
		/// текущего пользователя.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? StartTime { get; set; }

		/// <summary>
		/// Время в формате unixtime, до которого следует получить новости для текущего
		/// пользователя. Если параметр не задан,
		/// то он считается равным текущему времени.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? EndTime { get; set; }

		/// <summary>
		/// Максимальное количество фотографий, информацию о которых необходимо вернуть. По
		/// умолчанию 5.
		/// </summary>
		public uint MaxPhotos { get; set; }

		/// <summary>
		/// Перечисленные через запятую иcточники новостей, новости от которых необходимо
		/// получить. Идентификаторы
		/// пользователей можно указывать в форматах <uid /> или u<uid /> где <uid /> —
		/// идентификатор друга пользователя.
		/// Идентификаторы сообществ можно указывать в форматах -<gid /> или g<gid /> где
		/// <gid /> — идентификатор сообщества.
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
		public IEnumerable<long> SourceIds { get; set; }

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
		public ushort Count { get; set; }

		/// <summary>
		/// Список дополнительных полей профилей, которые необходимо вернуть.
		/// </summary>
		public UsersFields Fields { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(NewsFeedGetParams p)
		{
			var parameters = new VkParameters
			{
					{ "filters", p.Filters }
					, { "return_banned", p.ReturnBanned }
					, { "start_time", p.StartTime }
					, { "end_time", p.EndTime }
					, { "max_photos", p.MaxPhotos }
					, { "source_ids", p.SourceIds }
					, { "start_from", p.StartFrom }
					, { "count", p.Count }
					, { "fields", p.Fields }
			};

			return parameters;
		}
	}
}