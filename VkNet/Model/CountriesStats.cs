using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Статистика по стране
	/// </summary>
	[Serializable]
	public class CountriesStats
	{
		/// <summary>
		/// идентификатор страны;
		/// </summary>
		[JsonProperty(propertyName: "country_id")]
		public ulong CountryId { get; set; }

		/// <summary>
		/// число переходов из этой страны
		/// </summary>
		[JsonProperty(propertyName: "views")]
		public ulong Views { get; set; }
	}
}