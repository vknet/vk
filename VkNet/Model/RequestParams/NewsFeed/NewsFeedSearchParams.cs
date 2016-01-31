﻿using System;
using VkNet.Enums.Filters;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров запроса newsfeed.search
	/// </summary>
	public struct NewsFeedSearchParams
	{
		/// <summary>
		/// Список параметров запроса newsfeed.search
		/// </summary>
		public NewsFeedSearchParams(bool gog = true)
		{
			Extended = false;
			Count = 30;
			Query = null;
			Latitude = 0;
			Longitude = 0;
			StartTime = null;
			EndTime = null;
			StartFrom = 0;
			Fields = null;
		}
		/// <summary>
		/// Поисковой запрос.
		/// </summary>
		public string Query
		{ get; set; }

		/// <summary>
		/// Указывается 1, если необходимо получить информацию о пользователе или группе, разместившей запись.
		/// </summary>
		public bool? Extended
		{ get; set; }

		/// <summary>
		/// Указывает, какое максимальное число записей следует возвращать.
		/// </summary>
		public long? Count
		{ get; set; }

		/// <summary>
		/// Географическая широта точки, в радиусе от которой необходимо производить поиск, заданная в градусах (от -90 до 90).
		/// </summary>
		public double? Latitude
		{ get; set; }

		/// <summary>
		/// Географическая долгота точки, в радиусе от которой необходимо производить поиск, заданная в градусах (от -180 до 180).
		/// </summary>
		public double? Longitude
		{ get; set; }

		/// <summary>
		/// Время в формате unixtime, начиная с которого следует получить новости для текущего пользователя. Если параметр не задан, то он считается равным значению времени, которое было сутки назад.
		/// </summary>
		public DateTime? StartTime
		{ get; set; }

		/// <summary>
		/// Время в формате unixtime, до которого следует получить новости для текущего пользователя. Если параметр не задан, то он считается равным текущему времени.
		/// </summary>
		public DateTime? EndTime
		{ get; set; }

		/// <summary>
		/// Идентификатор, необходимый для получения следующей страницы результатов. Значение, необходимое для передачи в этом параметре, возвращается в поле ответа next_from.
		/// </summary>
		public long? StartFrom
		{ get; set; }

		/// <summary>
		/// Список дополнительных полей профилей, которые необходимо вернуть. Игнорируется при отсутствии параметра extended=1.
		/// </summary>
		public UsersFields Fields
		{ get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(NewsFeedSearchParams p)
		{
			var parameters = new VkParameters
			{
				{ "q", p.Query },
				{ "extended", p.Extended },
				{ "latitude", p.Latitude },
				{ "longitude", p.Longitude },
				{ "start_time", p.StartTime },
				{ "end_time", p.EndTime },
				{ "start_from", p.StartFrom },
				{ "fields", p.Fields }
			};
			if (p.Count <= 200)
			{
				parameters.Add("count", p.Count);
			}

			return parameters;
		}
	}
}
