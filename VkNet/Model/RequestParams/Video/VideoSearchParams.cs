﻿using System.Collections.Generic;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода video.search
	/// </summary>
	public struct VideoSearchParams
	{
		/// <summary>
		/// Параметры метода video.search
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public VideoSearchParams(bool gag = true)
		{
			Query = null;
			Sort = null;
			Hd = null;
			Adult = null;
			Filters = null;
			SearchOwn = null;
			Offset = null;
			Longer = null;
			Shorter = null;
			Count = null;
			Extended = null;
		}


		/// <summary>
		/// Строка поискового запроса. Например, The Beatles. строка, обязательный параметр.
		/// </summary>
		public string Query { get; set; }

		/// <summary>
		/// Вид сортировки. 0 — по дате добавления видеозаписи, 1 — по длительности, 2 — по релевантности. целое число.
		/// </summary>
		public VideoSort? Sort { get; set; }

		/// <summary>
		/// Если не равен нулю, то поиск производится только по видеозаписям высокого качества. целое число.
		/// </summary>
		public bool? Hd { get; set; }

		/// <summary>
		/// Фильтр «Безопасный поиск» (1 — выключен, 0 — включен). флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? Adult { get; set; }

		/// <summary>
		/// Список критериев, по которым требуется отфильтровать видео: 
		/// 
		/// mp4 — искать только видео в формате mp4 (воспроиводимое на iOS); 
		/// youtube — возвращать только youtube видео; 
		/// vimeo — возвращать только vimeo видео; 
		/// short — возвращать только короткие видеозаписи; 
		/// long — возвращать только длинные видеозаписи. 
		/// список строк, разделенных через запятую.
		/// </summary>
		public VideoFilters Filters { get; set; }

		/// <summary>
		/// 1 – искать по видеозаписям пользователя, 0 – не искать по видеозаписям пользователя (по умолчанию). флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? SearchOwn { get; set; }

		/// <summary>
		/// Смещение относительно первой найденной видеозаписи для выборки определенного подмножества. положительное число.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Количество секунд, видеозаписи длиннее которого необходимо вернуть. положительное число.
		/// </summary>
		public long? Longer { get; set; }

		/// <summary>
		/// Количество секунд, видеозаписи короче которого необходимо вернуть. положительное число.
		/// </summary>
		public long? Shorter { get; set; }

		/// <summary>
		/// Количество возвращаемых видеозаписей. Обратите внимание — даже при использовании параметра offset для получения информации доступны только первые 1000 результатов. 
		///  положительное число, по умолчанию 20, максимальное значение 200.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// 1 — возвращать дополнительные объекты profiles и groups, которые содержат id и имя/название владельцев видео. флаг, может принимать значения 1 или 0, по умолчанию 0.
		/// </summary>
		public bool? Extended { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(VideoSearchParams p)
		{
			var parameters = new VkParameters
			{
				{ "q", p.Query },
				{ "sort", p.Sort },
				{ "hd", p.Hd },
				{ "adult", p.Adult },
				{ "filters", p.Filters },
				{ "search_own", p.SearchOwn },
				{ "offset", p.Offset },
				{ "longer", p.Longer },
				{ "shorter", p.Shorter },
				{ "count", p.Count },
				{ "extended", p.Extended }
			};

			return parameters;
		}
	}
}