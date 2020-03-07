using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода GetCategories
	/// </summary>
	[Serializable]
	public class GetCategoriesResult
	{
		/// <summary>
		/// Массив объектов описывающих устаревшие тематики
		/// </summary>
		[JsonProperty("v1")]
		public ReadOnlyCollection<AdsCategories> V1 { get; set; }

		/// <summary>
		/// Массив объектов описывающих актуальные тематики
		/// </summary>
		[JsonProperty("v2")]
		public ReadOnlyCollection<AdsCategories> V2 { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GetCategoriesResult FromJson(VkResponse response)
		{
			return new GetCategoriesResult
			{
				V1 = response["v1"].ToReadOnlyCollectionOf<AdsCategories>(x=>x),
				V2 = response["v2"].ToReadOnlyCollectionOf<AdsCategories>(x=>x)
			};
		}
	}
}