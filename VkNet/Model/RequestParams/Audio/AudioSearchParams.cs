using System;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Критерии поиска аудиозаписей.
	/// </summary>
	[Serializable]
	public class AudioSearchParams
	{
		/// <summary>
		/// Текст поискового запроса (прим., The Beatles).
		/// </summary>
		public string Query { get; set; }

		/// <summary>
		/// Количество аудиозаписей, информацию о которых необходимо вернуть.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножетсва аудиозаписей.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Автоматически исправлять ошибки в поисковом запросе (прим. при строке Query
		/// "Иуфедуы" поиск будет осуществляться по
		/// строке "Beatles").
		/// </summary>
		public bool? Autocomplete { get; set; }

		/// <summary>
		/// Поиск только по тем аудиозаписям, которые содержат тексты.
		/// </summary>
		public bool? Lyrics { get; set; }

		/// <summary>
		/// Поиск только по названию исполнителя.
		/// </summary>
		public bool? PerformerOnly { get; set; }

		/// <summary>
		/// Сортировка аудиозаписей при поиске.
		/// </summary>
		public AudioSort? Sort { get; set; }

		/// <summary>
		/// Производить ли поиск по аудиозаписям пользователя.
		/// </summary>
		public bool? SearchOwn { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(AudioSearchParams p)
		{
			return new VkParameters
			{
					{ "q", p.Query }
					, { "auto_complete", p.Autocomplete }
					, { "sort", p.Sort }
					, { "lyrics", p.Lyrics }
					, { "performer_only", p.PerformerOnly }
					, { "search_own", p.SearchOwn }
					, { "count", p.Count }
					, { "offset", p.Offset }
			};
		}
	}
}