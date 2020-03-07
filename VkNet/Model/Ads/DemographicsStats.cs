using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	///
	/// </summary>
	[Serializable]
	public class DemographicsStats
	{
		/// <summary>
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("day")]
		public string Day { get; set; }

		/// <summary>
		/// обязательный параметр, строка
		/// </summary>
		[JsonProperty("month")]
		public string Month { get; set; }

		/// <summary>
		/// обязательный параметр, строка
		/// </summary>
		[JsonProperty("overall")]
		public string OverAll { get; set; }

		/// <summary>
		/// обязательный параметр, строка
		/// </summary>
		[JsonProperty("sex")]
		public ReadOnlyCollection<StatsSexAgeCities> Sex { get; set; }

		/// <summary>
		/// обязательный параметр, строка
		/// </summary>
		[JsonProperty("age")]
		public ReadOnlyCollection<StatsSexAgeCities> Age { get; set; }

		/// <summary>
		/// обязательный параметр, строка
		/// </summary>
		[JsonProperty("sex_age")]
		public ReadOnlyCollection<StatsSexAgeCities> SexAge { get; set; }

		/// <summary>
		/// обязательный параметр, строка
		/// </summary>
		[JsonProperty("cities")]
		public ReadOnlyCollection<StatsSexAgeCities> Cities { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static DemographicsStats FromJson(VkResponse response)
		{
			return new DemographicsStats
			{
				Day = response["day"],
				Month = response["month"],
				OverAll = response["overall"],
				Sex = response["sex"].ToReadOnlyCollectionOf<StatsSexAgeCities>(x=>x),
				SexAge = response["sex_age"].ToReadOnlyCollectionOf<StatsSexAgeCities>(x=>x),
				Age = response["age"].ToReadOnlyCollectionOf<StatsSexAgeCities>(x=>x),
				Cities = response["cities"].ToReadOnlyCollectionOf<StatsSexAgeCities>(x=>x)
			};
		}
	}
}