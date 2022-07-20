using System;
using VkNet.Enums;

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
	}
}