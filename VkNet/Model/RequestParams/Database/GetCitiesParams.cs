using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.RequestParams.Database
{
	/// <summary>
	/// Параметры запроса database.getCities
	/// </summary>
	[Serializable]
	public class GetCitiesParams
	{
		/// <summary>
		/// Идентификатор страны, полученный в методе database.getCountries
		/// </summary>
		[JsonProperty(propertyName: "country_id")]
		public int CountryId { get; set; }

		/// <summary>
		/// идентификатор региона, города которого необходимо получить. (параметр не
		/// обязателен)
		/// </summary>
		[JsonProperty(propertyName: "region_id")]
		public int? RegionId { get; set; }

		/// <summary>
		/// Строка поискового запроса. Например, Санкт. Максимальная длина строки — 15
		/// символов.
		/// </summary>
		[JsonProperty(propertyName: "q")]
		public string Query { get; set; }

		/// <summary>
		/// 1 – возвращать все города. 0 – возвращать только основные города.
		/// </summary>
		[JsonProperty(propertyName: "need_all")]
		public bool? NeedAll { get; set; }

		/// <summary>
		/// Количество городов, которые необходимо вернуть.
		/// </summary>
		[JsonProperty(propertyName: "count")]
		public uint? Count { get; set; }

		/// <summary>
		/// Отступ, необходимый для получения определенного подмножества городов.
		/// </summary>
		[JsonProperty(propertyName: "offset")]
		public uint? Offset { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(GetCitiesParams p)
		{
			return new VkParameters
			{
					{ "country_id", p.CountryId }
					, { "region_id", p.RegionId }
					, { "q", p.Query }
					, { "need_all", p.NeedAll }
					, { "count", p.Count }
					, { "offset", p.Offset }
			};
		}
	}
}