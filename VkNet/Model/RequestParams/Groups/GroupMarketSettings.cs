using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// настройки блока товаров.
	/// </summary>
	[Serializable]
	public class GroupMarketSettings
	{
		/// <summary>
		/// Включен ли блок товаров
		/// </summary>
		[JsonProperty("enabled")]
		public bool? Enabled { get; set; }

		/// <summary>
		/// Включены ли комментарии к товарам
		/// </summary>
		[JsonProperty("comments_enabled")]
		public bool? CommentsEnabled { get; set; }

		/// <summary>
		/// Включены ли сообщения сообщества
		/// </summary>
		[JsonProperty("can_message")]
		public bool? CanMessage { get; set; }

		/// <summary>
		/// Идентификаторы стран;
		/// </summary>
		[JsonProperty("country_ids")]
		public ReadOnlyCollection<long> CountryIds { get; set; }

		/// <summary>
		/// Идентификаторы городов
		/// </summary>
		[JsonProperty("city_ids")]
		public ReadOnlyCollection<long> CityIds { get; set; }

		/// <summary>
		/// Идентификатор контактного лица;
		/// </summary>
		[JsonProperty("contact_id")]
		public long? ContactId { get; set; }

		/// <summary>
		/// Объект, описывающий валюту.
		/// </summary>
		[JsonProperty("currency")]
		public Currency Currency { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GroupMarketSettings FromJson(VkResponse response)
		{
			return new GroupMarketSettings
			{
				Enabled = response["enabled"],
				CommentsEnabled = response["comments_enabled"],
				CanMessage = response["can_message"],
				CountryIds = response["country_ids"].ToReadOnlyCollectionOf<long>(x => x),
				CityIds = response["city_ids"].ToReadOnlyCollectionOf<long>(x => x),
				ContactId = response["contact_id"],
				Currency = response["currency"]
			};
		}
	}
}